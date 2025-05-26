using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleWindowsForm.Models;

namespace SimpleWindowsForm
{
    public partial class LoginForm : Form
    {
        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private Label lblInfo;
        private Database database;
        
        public User? LoggedInUser;

        public LoginForm()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                database = new Database();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı bağlantı hatası: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnExit = new Button();
            this.lblInfo = new Label();
            this.SuspendLayout();
            
            // Modern form ayarları
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            // 
            // lblTitle - Modern başlık tasarımı
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblTitle.Location = new Point(60, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(380, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📚 Kütüphane Sistemi";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblUsername - Modern etiket tasarımı
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblUsername.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblUsername.Location = new Point(80, 120);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(105, 21);
            this.lblUsername.Text = "👤 Kullanıcı Adı";

            // 
            // txtUsername - Modern textbox tasarımı
            // 
            this.txtUsername.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtUsername.Location = new Point(80, 145);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(340, 27);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "admin";
            this.txtUsername.BorderStyle = BorderStyle.FixedSingle;
            this.txtUsername.BackColor = Color.White;
            this.txtUsername.ForeColor = Color.FromArgb(52, 73, 94);

            // 
            // lblPassword - Modern etiket tasarımı
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblPassword.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblPassword.Location = new Point(80, 190);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(68, 21);
            this.lblPassword.Text = "🔒 Şifre";

            // 
            // txtPassword - Modern textbox tasarımı
            // 
            this.txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtPassword.Location = new Point(80, 215);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new Size(340, 27);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "123456";
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.BackColor = Color.White;
            this.txtPassword.ForeColor = Color.FromArgb(52, 73, 94);
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);

            // 
            // btnLogin - Modern giriş butonu
            // 
            this.btnLogin.BackColor = Color.FromArgb(46, 204, 113);
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Location = new Point(80, 270);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(160, 45);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "🚀 Giriş Yap";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseEnter += new EventHandler(this.Button_MouseEnter);
            this.btnLogin.MouseLeave += new EventHandler(this.Button_MouseLeave);

            // 
            // btnExit - Modern çıkış butonu
            // 
            this.btnExit.BackColor = Color.FromArgb(231, 76, 60);
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnExit.ForeColor = Color.White;
            this.btnExit.Location = new Point(260, 270);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(160, 45);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "❌ Çıkış";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Cursor = Cursors.Hand;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new EventHandler(this.Button_MouseEnter);
            this.btnExit.MouseLeave += new EventHandler(this.Button_MouseLeave);

            // 
            // lblInfo - Modern bilgi etiketi
            // 
            this.lblInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblInfo.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblInfo.Location = new Point(80, 340);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new Size(340, 80);
            this.lblInfo.Text = "💡 Varsayılan Hesaplar:\n\n" +
                               "🔹 admin / 123456 (Sistem Yöneticisi)\n" +
                               "🔹 librarian / 123456 (Kütüphaneci)\n" +
                               "🔹 user / 123456 (Normal Kullanıcı)";
            this.lblInfo.TextAlign = ContentAlignment.TopLeft;

            // 
            // LoginForm - Modern form tasarımı
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(500, 450);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Kütüphane Sistemi - Kullanıcı Girişi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kullanıcı adı ve şifre alanları boş bırakılamaz!", 
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LoggedInUser = database.AuthenticateUser(username, password);

                if (LoggedInUser != null)
                {
                    MessageBox.Show($"Hoş geldiniz, {LoggedInUser.FullName}!\nRol: {LoggedInUser.Role}", 
                        "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", 
                        "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş sırasında hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter tuşuna basıldığında giriş yap
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
        
        // Modern hover efektleri
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Butonun rengini biraz daha açık yap
                Color originalColor = button.BackColor;
                int r = Math.Min(255, originalColor.R + 20);
                int g = Math.Min(255, originalColor.G + 20);
                int b = Math.Min(255, originalColor.B + 20);
                button.BackColor = Color.FromArgb(r, g, b);
                
                // Hafif gölge efekti simülasyonu
                button.FlatAppearance.BorderSize = 2;
                button.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 255, 100);
            }
        }
        
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Orijinal renge geri dön
                if (button == btnLogin)
                    button.BackColor = Color.FromArgb(46, 204, 113);
                else if (button == btnExit)
                    button.BackColor = Color.FromArgb(231, 76, 60);
                
                // Border'ı kaldır
                button.FlatAppearance.BorderSize = 0;
            }
        }
    }
} 