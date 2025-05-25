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

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.DarkBlue;
            this.lblTitle.Location = new Point(80, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(240, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Kütüphane Yönetim Sistemi";

            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblUsername.Location = new Point(50, 100);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(85, 17);
            this.lblUsername.Text = "Kullanıcı Adı:";

            // 
            // txtUsername
            // 
            this.txtUsername.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtUsername.Location = new Point(150, 97);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(200, 23);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "admin"; // Varsayılan değer

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblPassword.Location = new Point(50, 140);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(37, 17);
            this.lblPassword.Text = "Şifre:";

            // 
            // txtPassword
            // 
            this.txtPassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtPassword.Location = new Point(150, 137);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(200, 23);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "123456"; // Varsayılan değer
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);

            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = Color.LightGreen;
            this.btnLogin.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnLogin.Location = new Point(150, 180);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(90, 35);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Giriş Yap";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // 
            // btnExit
            // 
            this.btnExit.BackColor = Color.LightCoral;
            this.btnExit.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnExit.Location = new Point(260, 180);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(90, 35);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Çıkış";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);

            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Italic, GraphicsUnit.Point);
            this.lblInfo.ForeColor = Color.Gray;
            this.lblInfo.Location = new Point(50, 240);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new Size(300, 60);
            this.lblInfo.Text = "Varsayılan Kullanıcılar:\n" +
                               "admin / 123456 (Yönetici)\n" +
                               "librarian / 123456 (Kütüphaneci)\n" +
                               "user / 123456 (Kullanıcı)";

            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(400, 320);
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
            this.Text = "Kullanıcı Girişi";
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
    }
} 