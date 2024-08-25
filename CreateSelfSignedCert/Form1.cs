using System;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateSelfSignedCert;

public partial class Form1 : Form
{
    private readonly string settingsFilePath = "settings.txt";
    private readonly string powerShellPath = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";

    public Form1()
    {
        InitializeComponent();
        progressBar1.Visible = false;
        progressBar1.Style = ProgressBarStyle.Marquee;

        if (!IsProcessElevated())
        {
            MessageBox.Show("This application requires elevated privileges to run. Please run the application as an administrator.", "Insufficient Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Environment.Exit(0); 
        }

        // Check if PowerShell 5.1 exists - this is, so far, not compatible with later versions
        if (!File.Exists(powerShellPath))
        {
            MessageBox.Show(
                "PowerShell 5.1 is not installed on this system. Please enable it by going to 'Programs and Features' > 'Turn Windows features on or off' and checking the 'Windows PowerShell 2.0' box.",
                "PowerShell 5.1 Not Found",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            Environment.Exit(0); 
        }

        LoadSettings();

        TxtSubdomain.TextChanged += TextBox_TextChanged;
        TxtADdomain.TextChanged += TextBox_TextChanged;
        TxtYears.TextChanged += TextBox_TextChanged;
    }

    private static bool IsProcessElevated()
    {
        using WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    private void LoadSettings()
    {
        if (File.Exists(settingsFilePath))
        {
            var settings = File.ReadAllLines(settingsFilePath);
            foreach (var line in settings)
            {
                var keyValue = line.Split('=');
                if (keyValue.Length == 2)
                {
                    if (keyValue[0] == "ADdomain")
                    {
                        TxtADdomain.Text = keyValue[1];
                    }
                    else if (keyValue[0] == "Years")
                    {
                        TxtYears.Text = keyValue[1];
                    }
                }
            }
        }
        UpdateButtonState();
    }

    private void SaveSettings()
    {
        var settings = new[]
        {
            $"ADdomain={TxtADdomain.Text.Trim()}",
            $"Years={TxtYears.Text.Trim()}"
        };
        File.WriteAllLines(settingsFilePath, settings);
    }

    private async void BtnCreateCert_Click(object sender, EventArgs e)
    {
        string command = CreatePowerShellStatement();

        progressBar1.Visible = true;

        try
        {
            await ExecutePowerShellCommandAsync(command);
            SaveSettings();
            MessageBox.Show("Certificate generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            progressBar1.Visible = false;
        }
    }

    private string CreatePowerShellStatement()
    {
        var validationResult = ValidateInputs();
        if (!validationResult.IsValid)
        {
            MessageBox.Show(validationResult.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return "";
        }

        string subdomain = TxtSubdomain.Text.Trim();
        string ADdomain = TxtADdomain.Text.Trim();
        string years = TxtYears.Text.Trim();
        string command = $"$cert = New-SelfSignedCertificate -DnsName \"{subdomain.ToLower()}.{ADdomain}\" -Subject \"{subdomain.ToLower()}.{ADdomain}\" -FriendlyName \"{subdomain}\" -NotAfter (Get-Date).AddYears({years})";
        return command;
    }

    private ValidationResult ValidateInputs()
    {
        string subdomain = TxtSubdomain.Text.Trim();
        string ADdomain = TxtADdomain.Text.Trim();
        string years = TxtYears.Text.Trim();

        if (string.IsNullOrWhiteSpace(subdomain) || !RegexSubdomain().IsMatch(subdomain))
        {
            return new ValidationResult(false, "Please enter a valid subdomain. Subdomains can only contain letters, numbers, and hyphens.");
        }

        if (string.IsNullOrWhiteSpace(ADdomain) || !RegexDomain().IsMatch(ADdomain))
        {
            return new ValidationResult(false, "Please enter a valid AD domain. Domains must be in the form 'example.com' or 'example.local'.");
        }

        if (string.IsNullOrWhiteSpace(years) || !int.TryParse(years, out int yearsInt) || yearsInt < 1 || yearsInt > 99)
        {
            return new ValidationResult(false, "Please enter a valid number of years (1-99).");
        }

        return ValidationResult.Success;
    }

    private bool ValidateInputsWithoutAlert()
    {
        return ValidateInputs().IsValid;
    }

    private async Task ExecutePowerShellCommandAsync(string command)
    {
        await Task.Run(() =>
        {
            using Process powerShellProcess = new();
            powerShellProcess.StartInfo.FileName = powerShellPath;
            powerShellProcess.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"";
            powerShellProcess.StartInfo.CreateNoWindow = true;
            powerShellProcess.StartInfo.UseShellExecute = false;
            powerShellProcess.StartInfo.RedirectStandardError = true;
            powerShellProcess.StartInfo.RedirectStandardOutput = true;

            powerShellProcess.Start();

            string output = powerShellProcess.StandardOutput.ReadToEnd();
            string error = powerShellProcess.StandardError.ReadToEnd();

            powerShellProcess.WaitForExit();

            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception($"PowerShell error: {error}");
            }
        });
    }

    private void TextBox_TextChanged(object? sender, EventArgs e)
    {
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        BtnCreateCert.Enabled = ValidateInputsWithoutAlert();
        this.AcceptButton = BtnCreateCert.Enabled ? BtnCreateCert : null;
    }

    private class ValidationResult(bool isValid, string errorMessage)
    {
        public bool IsValid { get; } = isValid;
        public string ErrorMessage { get; } = errorMessage;

        public static ValidationResult Success => new(true, string.Empty);
    }

    [GeneratedRegex(@"^[a-zA-Z0-9\-]+$")]
    private static partial Regex RegexSubdomain();

    [GeneratedRegex(@"^(?:[a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,63}|local$")]
    private static partial Regex RegexDomain();

    private void Button1_Click(object sender, EventArgs e)
    {
        string command = CreatePowerShellStatement();
        textBox1.Text = command;
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
}
