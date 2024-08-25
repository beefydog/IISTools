namespace CreateSelfSignedCert;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        LblSubdomain = new Label();
        TxtSubdomain = new TextBox();
        BtnCreateCert = new Button();
        TxtADdomain = new TextBox();
        LblADdomain = new Label();
        TxtYears = new TextBox();
        label1 = new Label();
        progressBar1 = new ProgressBar();
        textBox1 = new TextBox();
        button1 = new Button();
        SuspendLayout();
        // 
        // LblSubdomain
        // 
        LblSubdomain.AutoSize = true;
        LblSubdomain.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        LblSubdomain.Location = new Point(108, 59);
        LblSubdomain.Name = "LblSubdomain";
        LblSubdomain.Size = new Size(89, 19);
        LblSubdomain.TabIndex = 0;
        LblSubdomain.Text = "Subdomain:";
        // 
        // TxtSubdomain
        // 
        TxtSubdomain.BorderStyle = BorderStyle.FixedSingle;
        TxtSubdomain.Font = new Font("Segoe UI", 10F);
        TxtSubdomain.Location = new Point(108, 81);
        TxtSubdomain.Name = "TxtSubdomain";
        TxtSubdomain.Size = new Size(175, 25);
        TxtSubdomain.TabIndex = 1;
        // 
        // BtnCreateCert
        // 
        BtnCreateCert.BackColor = Color.White;
        BtnCreateCert.FlatAppearance.BorderColor = Color.DarkGreen;
        BtnCreateCert.FlatStyle = FlatStyle.Flat;
        BtnCreateCert.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        BtnCreateCert.ForeColor = Color.DarkGreen;
        BtnCreateCert.Location = new Point(225, 181);
        BtnCreateCert.Name = "BtnCreateCert";
        BtnCreateCert.Size = new Size(191, 38);
        BtnCreateCert.TabIndex = 5;
        BtnCreateCert.Text = "Create Certificate";
        BtnCreateCert.UseVisualStyleBackColor = false;
        BtnCreateCert.Click += BtnCreateCert_Click;
        // 
        // TxtADdomain
        // 
        TxtADdomain.BorderStyle = BorderStyle.FixedSingle;
        TxtADdomain.Font = new Font("Segoe UI", 10F);
        TxtADdomain.Location = new Point(108, 31);
        TxtADdomain.Name = "TxtADdomain";
        TxtADdomain.Size = new Size(175, 25);
        TxtADdomain.TabIndex = 0;
        // 
        // LblADdomain
        // 
        LblADdomain.AutoSize = true;
        LblADdomain.CausesValidation = false;
        LblADdomain.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        LblADdomain.Location = new Point(108, 9);
        LblADdomain.Name = "LblADdomain";
        LblADdomain.Size = new Size(130, 19);
        LblADdomain.TabIndex = 3;
        LblADdomain.Text = "AD domain w/ext:";
        // 
        // TxtYears
        // 
        TxtYears.BorderStyle = BorderStyle.FixedSingle;
        TxtYears.Font = new Font("Segoe UI", 10F);
        TxtYears.Location = new Point(244, 129);
        TxtYears.MaxLength = 3;
        TxtYears.Name = "TxtYears";
        TxtYears.Size = new Size(39, 25);
        TxtYears.TabIndex = 2;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        label1.Location = new Point(108, 132);
        label1.Name = "label1";
        label1.Size = new Size(137, 19);
        label1.TabIndex = 5;
        label1.Text = "Expiration in Years:";
        // 
        // progressBar1
        // 
        progressBar1.Dock = DockStyle.Bottom;
        progressBar1.Location = new Point(0, 311);
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(435, 23);
        progressBar1.Style = ProgressBarStyle.Marquee;
        progressBar1.TabIndex = 7;
        // 
        // textBox1
        // 
        textBox1.BackColor = Color.LightGoldenrodYellow;
        textBox1.BorderStyle = BorderStyle.FixedSingle;
        textBox1.Location = new Point(17, 245);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.Size = new Size(399, 60);
        textBox1.TabIndex = 6;
        // 
        // button1
        // 
        button1.BackColor = Color.White;
        button1.FlatAppearance.BorderColor = Color.DodgerBlue;
        button1.FlatAppearance.BorderSize = 2;
        button1.FlatStyle = FlatStyle.Flat;
        button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        button1.ForeColor = Color.DodgerBlue;
        button1.Location = new Point(17, 181);
        button1.Name = "button1";
        button1.Size = new Size(191, 38);
        button1.TabIndex = 4;
        button1.Text = "Preview PS Statement";
        button1.UseVisualStyleBackColor = false;
        button1.Click += Button1_Click;
        // 
        // Form1
        // 
        AcceptButton = BtnCreateCert;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(435, 334);
        Controls.Add(button1);
        Controls.Add(textBox1);
        Controls.Add(progressBar1);
        Controls.Add(TxtYears);
        Controls.Add(label1);
        Controls.Add(TxtADdomain);
        Controls.Add(LblADdomain);
        Controls.Add(BtnCreateCert);
        Controls.Add(TxtSubdomain);
        Controls.Add(LblSubdomain);
        MaximizeBox = false;
        MaximumSize = new Size(451, 373);
        MinimizeBox = false;
        MinimumSize = new Size(451, 373);
        Name = "Form1";
        ShowIcon = false;
        SizeGripStyle = SizeGripStyle.Hide;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Create Self-Signed Certificate For IIS";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label LblSubdomain;
    private TextBox TxtSubdomain;
    private Button BtnCreateCert;
    private TextBox TxtADdomain;
    private Label LblADdomain;
    private TextBox TxtYears;
    private Label label1;
    private ProgressBar progressBar1;
    private TextBox textBox1;
    private Button button1;
}
