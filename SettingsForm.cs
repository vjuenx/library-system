using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleWindowsForm.Models;

namespace SimpleWindowsForm
{
    public partial class SettingsForm : Form
    {
        private Label lblTitle;
        private GroupBox grpAbout;
        private Label lblAppName;
        private Label lblVersion;
        private Label lblDescription;
        private Label lblContact;
        
        private GroupBox grpTheme;
        private RadioButton rbLightTheme;
        private RadioButton rbDarkTheme;
        private Button btnApplyTheme;
        
        private Button btnClose;
        
        private User currentUser;
        private bool isDarkTheme = false;

        public SettingsForm(User user)
        {
            currentUser = user;
            InitializeComponent();
            LoadCurrentTheme();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.grpAbout = new GroupBox();
            this.lblAppName = new Label();
            this.lblVersion = new Label();
            this.lblDescription = new Label();
            this.lblContact = new Label();
            this.grpTheme = new GroupBox();
            this.rbLightTheme = new RadioButton();
            this.rbDarkTheme = new RadioButton();
            this.btnApplyTheme = new Button();
            this.btnClose = new Button();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.DarkBlue;
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(100, 26);
            this.lblTitle.Text = "⚙️ Ayarlar";

            // 
            // grpAbout
            // 
            this.grpAbout.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.grpAbout.Location = new Point(20, 70);
            this.grpAbout.Name = "grpAbout";
            this.grpAbout.Size = new Size(460, 180);
            this.grpAbout.Text = "📋 Uygulama Hakkında";
            this.grpAbout.Controls.Add(this.lblAppName);
            this.grpAbout.Controls.Add(this.lblVersion);
            this.grpAbout.Controls.Add(this.lblDescription);
            this.grpAbout.Controls.Add(this.lblContact);

            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblAppName.ForeColor = Color.DarkGreen;
            this.lblAppName.Location = new Point(15, 30);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new Size(250, 20);
            this.lblAppName.Text = "📚 Kütüphane Yönetim Sistemi";

            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblVersion.Location = new Point(15, 60);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new Size(120, 17);
            this.lblVersion.Text = "🔢 Versiyon: 1.0.0";

            // 
            // lblDescription
            // 
            this.lblDescription.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblDescription.Location = new Point(15, 90);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(430, 50);
            this.lblDescription.Text = "📝 Bu uygulama, kütüphane işlemlerini yönetmek için geliştirilmiş modern bir Windows Forms uygulamasıdır. Öğrenci, kitap ve ödünç alma işlemlerini kolayca yönetebilirsiniz.";

            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblContact.Location = new Point(15, 150);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new Size(200, 15);
            this.lblContact.Text = "📧 İletişim: library@example.com";

            // 
            // grpTheme
            // 
            this.grpTheme.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.grpTheme.Location = new Point(20, 270);
            this.grpTheme.Name = "grpTheme";
            this.grpTheme.Size = new Size(460, 100);
            this.grpTheme.Text = "🎨 Tema Ayarları";
            this.grpTheme.Controls.Add(this.rbLightTheme);
            this.grpTheme.Controls.Add(this.rbDarkTheme);
            this.grpTheme.Controls.Add(this.btnApplyTheme);

            // 
            // rbLightTheme
            // 
            this.rbLightTheme.AutoSize = true;
            this.rbLightTheme.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.rbLightTheme.Location = new Point(20, 30);
            this.rbLightTheme.Name = "rbLightTheme";
            this.rbLightTheme.Size = new Size(100, 19);
            this.rbLightTheme.Text = "☀️ Açık Tema";
            this.rbLightTheme.UseVisualStyleBackColor = true;
            this.rbLightTheme.Checked = true;

            // 
            // rbDarkTheme
            // 
            this.rbDarkTheme.AutoSize = true;
            this.rbDarkTheme.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.rbDarkTheme.Location = new Point(150, 30);
            this.rbDarkTheme.Name = "rbDarkTheme";
            this.rbDarkTheme.Size = new Size(100, 19);
            this.rbDarkTheme.Text = "🌙 Koyu Tema";
            this.rbDarkTheme.UseVisualStyleBackColor = true;

            // 
            // btnApplyTheme
            // 
            this.btnApplyTheme.BackColor = Color.LightBlue;
            this.btnApplyTheme.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnApplyTheme.Location = new Point(300, 25);
            this.btnApplyTheme.Name = "btnApplyTheme";
            this.btnApplyTheme.Size = new Size(120, 30);
            this.btnApplyTheme.Text = "✅ Temayı Uygula";
            this.btnApplyTheme.UseVisualStyleBackColor = false;
            this.btnApplyTheme.Click += new EventHandler(this.btnApplyTheme_Click);

            // 
            // btnClose
            // 
            this.btnClose.BackColor = Color.LightCoral;
            this.btnClose.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnClose.Location = new Point(380, 390);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(100, 35);
            this.btnClose.Text = "❌ Kapat";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(500, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpAbout);
            this.Controls.Add(this.grpTheme);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Ayarlar - Kütüphane Sistemi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LoadCurrentTheme()
        {
            // Varsayılan olarak açık tema seçili
            rbLightTheme.Checked = !isDarkTheme;
            rbDarkTheme.Checked = isDarkTheme;
            ApplyTheme();
        }

        private void btnApplyTheme_Click(object sender, EventArgs e)
        {
            isDarkTheme = rbDarkTheme.Checked;
            ApplyTheme();
            MessageBox.Show("✅ Tema başarıyla uygulandı!", "Tema Değişti", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ApplyTheme()
        {
            if (isDarkTheme)
            {
                // Koyu tema
                this.BackColor = Color.FromArgb(45, 45, 48);
                this.ForeColor = Color.White;
                
                lblTitle.ForeColor = Color.LightBlue;
                grpAbout.ForeColor = Color.White;
                grpTheme.ForeColor = Color.White;
                lblAppName.ForeColor = Color.LightGreen;
                lblVersion.ForeColor = Color.LightGray;
                lblDescription.ForeColor = Color.LightGray;
                lblContact.ForeColor = Color.LightGray;
                rbLightTheme.ForeColor = Color.White;
                rbDarkTheme.ForeColor = Color.White;
                
                btnApplyTheme.BackColor = Color.FromArgb(0, 122, 204);
                btnApplyTheme.ForeColor = Color.White;
                btnClose.BackColor = Color.FromArgb(196, 43, 28);
                btnClose.ForeColor = Color.White;
            }
            else
            {
                // Açık tema
                this.BackColor = Color.WhiteSmoke;
                this.ForeColor = Color.Black;
                
                lblTitle.ForeColor = Color.DarkBlue;
                grpAbout.ForeColor = Color.Black;
                grpTheme.ForeColor = Color.Black;
                lblAppName.ForeColor = Color.DarkGreen;
                lblVersion.ForeColor = Color.Black;
                lblDescription.ForeColor = Color.Black;
                lblContact.ForeColor = Color.Black;
                rbLightTheme.ForeColor = Color.Black;
                rbDarkTheme.ForeColor = Color.Black;
                
                btnApplyTheme.BackColor = Color.LightBlue;
                btnApplyTheme.ForeColor = Color.Black;
                btnClose.BackColor = Color.LightCoral;
                btnClose.ForeColor = Color.Black;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 