using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleWindowsForm.Models;

namespace SimpleWindowsForm
{
    public partial class MainMenuForm : Form
    {
        private Label lblTitle;
        private Label lblUserInfo;
        private Button btnEmployeeManagement;
        private Button btnStudentManagement;
        private Button btnBookManagement;
        private Button btnBorrowManagement;
        private Button btnReservationManagement;
        private Button btnCategoryManagement;
        private Button btnSettings;
        private Button btnLogout;
        private User currentUser;
        private Database database;

        public MainMenuForm(User user)
        {
            currentUser = user;
            InitializeComponent();
            InitializeDatabase();
            SetupUserPermissions();
            
            // Tema değişikliği event'ini dinle
            ThemeManager.ThemeChanged += OnThemeChanged;
            // İlk tema uygulaması
            ThemeManager.ApplyTheme(this);
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
            }
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblUserInfo = new Label();
            this.btnEmployeeManagement = new Button();
            this.btnStudentManagement = new Button();
            this.btnBookManagement = new Button();
            this.btnBorrowManagement = new Button();
            this.btnReservationManagement = new Button();
            this.btnCategoryManagement = new Button();
            this.btnSettings = new Button();
            this.btnLogout = new Button();
            this.SuspendLayout();
            
            // Modern form ayarları
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            // 
            // lblTitle - Modern başlık tasarımı
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblTitle.Location = new Point(120, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(450, 45);
            this.lblTitle.Text = "📚 Kütüphane Yönetim Sistemi";
            this.lblTitle.BackColor = Color.Transparent;

            // 
            // lblUserInfo - Modern kullanıcı bilgisi
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblUserInfo.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblUserInfo.Location = new Point(120, 85);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new Size(300, 25);
            this.lblUserInfo.Text = $"🎯 Hoş geldiniz, {currentUser.FullName}";
            this.lblUserInfo.BackColor = Color.Transparent;

            // 
            // btnEmployeeManagement - Modern card tasarımı
            // 
            this.btnEmployeeManagement.BackColor = Color.FromArgb(52, 152, 219);
            this.btnEmployeeManagement.FlatStyle = FlatStyle.Flat;
            this.btnEmployeeManagement.FlatAppearance.BorderSize = 0;
            this.btnEmployeeManagement.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnEmployeeManagement.ForeColor = Color.White;
            this.btnEmployeeManagement.Location = new Point(120, 140);
            this.btnEmployeeManagement.Name = "btnEmployeeManagement";
            this.btnEmployeeManagement.Size = new Size(220, 70);
            this.btnEmployeeManagement.Text = "👥 Görevli Yönetimi";
            this.btnEmployeeManagement.UseVisualStyleBackColor = false;
            this.btnEmployeeManagement.Cursor = Cursors.Hand;
            this.btnEmployeeManagement.Click += new EventHandler(this.btnEmployeeManagement_Click);
            this.btnEmployeeManagement.MouseEnter += new EventHandler(this.Button_MouseEnter);
            this.btnEmployeeManagement.MouseLeave += new EventHandler(this.Button_MouseLeave);

            // 
            // btnStudentManagement - Modern card tasarımı
            // 
            this.btnStudentManagement.BackColor = Color.FromArgb(46, 204, 113);
            this.btnStudentManagement.FlatStyle = FlatStyle.Flat;
            this.btnStudentManagement.FlatAppearance.BorderSize = 0;
            this.btnStudentManagement.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnStudentManagement.ForeColor = Color.White;
            this.btnStudentManagement.Location = new Point(360, 140);
            this.btnStudentManagement.Name = "btnStudentManagement";
            this.btnStudentManagement.Size = new Size(220, 70);
            this.btnStudentManagement.Text = "🎓 Öğrenci Yönetimi";
            this.btnStudentManagement.UseVisualStyleBackColor = false;
            this.btnStudentManagement.Cursor = Cursors.Hand;
            this.btnStudentManagement.Click += new EventHandler(this.btnStudentManagement_Click);
            this.btnStudentManagement.MouseEnter += new EventHandler(this.Button_MouseEnter);
            this.btnStudentManagement.MouseLeave += new EventHandler(this.Button_MouseLeave);

            // 
            // btnBookManagement - Modern card tasarımı
            // 
            this.btnBookManagement.BackColor = Color.FromArgb(241, 196, 15);
            this.btnBookManagement.FlatStyle = FlatStyle.Flat;
            this.btnBookManagement.FlatAppearance.BorderSize = 0;
            this.btnBookManagement.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnBookManagement.ForeColor = Color.White;
            this.btnBookManagement.Location = new Point(120, 230);
            this.btnBookManagement.Name = "btnBookManagement";
            this.btnBookManagement.Size = new Size(220, 70);
            this.btnBookManagement.Text = "📚 Kitap Yönetimi";
            this.btnBookManagement.UseVisualStyleBackColor = false;
            this.btnBookManagement.Cursor = Cursors.Hand;
            this.btnBookManagement.Click += new EventHandler(this.btnBookManagement_Click);
            this.btnBookManagement.MouseEnter += new EventHandler(this.Button_MouseEnter);
            this.btnBookManagement.MouseLeave += new EventHandler(this.Button_MouseLeave);

            // 
            // btnBorrowManagement - Modern card tasarımı
            // 
            this.btnBorrowManagement.BackColor = Color.FromArgb(231, 76, 60);
            this.btnBorrowManagement.FlatStyle = FlatStyle.Flat;
            this.btnBorrowManagement.FlatAppearance.BorderSize = 0;
            this.btnBorrowManagement.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnBorrowManagement.ForeColor = Color.White;
            this.btnBorrowManagement.Location = new Point(360, 230);
            this.btnBorrowManagement.Name = "btnBorrowManagement";
            this.btnBorrowManagement.Size = new Size(220, 70);
            this.btnBorrowManagement.Text = "📋 Ödünç Kayıtları";
            this.btnBorrowManagement.UseVisualStyleBackColor = false;
            this.btnBorrowManagement.Cursor = Cursors.Hand;
            this.btnBorrowManagement.Click += new EventHandler(this.btnBorrowManagement_Click);
            this.btnBorrowManagement.MouseEnter += new EventHandler(this.Button_MouseEnter);
            this.btnBorrowManagement.MouseLeave += new EventHandler(this.Button_MouseLeave);

            // 
            // btnReservationManagement - Modern card tasarımı
            // 
            this.btnReservationManagement.BackColor = Color.FromArgb(155, 89, 182);
            this.btnReservationManagement.FlatStyle = FlatStyle.Flat;
            this.btnReservationManagement.FlatAppearance.BorderSize = 0;
            this.btnReservationManagement.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnReservationManagement.ForeColor = Color.White;
            this.btnReservationManagement.Location = new Point(120, 320);
            this.btnReservationManagement.Name = "btnReservationManagement";
            this.btnReservationManagement.Size = new Size(220, 70);
            this.btnReservationManagement.Text = "📅 Rezervasyonlar";
            this.btnReservationManagement.UseVisualStyleBackColor = false;
            this.btnReservationManagement.Cursor = Cursors.Hand;
            this.btnReservationManagement.Click += new EventHandler(this.btnReservationManagement_Click);
            this.btnReservationManagement.MouseEnter += new EventHandler(this.Button_MouseEnter);
            this.btnReservationManagement.MouseLeave += new EventHandler(this.Button_MouseLeave);

            // 
            // btnCategoryManagement - Modern card tasarımı
            // 
            this.btnCategoryManagement.BackColor = Color.FromArgb(230, 126, 34);
            this.btnCategoryManagement.FlatStyle = FlatStyle.Flat;
            this.btnCategoryManagement.FlatAppearance.BorderSize = 0;
            this.btnCategoryManagement.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCategoryManagement.ForeColor = Color.White;
            this.btnCategoryManagement.Location = new Point(360, 320);
            this.btnCategoryManagement.Name = "btnCategoryManagement";
            this.btnCategoryManagement.Size = new Size(220, 70);
            this.btnCategoryManagement.Text = "📂 Kategori Yönetimi";
            this.btnCategoryManagement.UseVisualStyleBackColor = false;
            this.btnCategoryManagement.Cursor = Cursors.Hand;
            this.btnCategoryManagement.Click += new EventHandler(this.btnCategoryManagement_Click);
            this.btnCategoryManagement.MouseEnter += new EventHandler(this.Button_MouseEnter);
            this.btnCategoryManagement.MouseLeave += new EventHandler(this.Button_MouseLeave);

            // 
            // btnSettings - Modern card tasarımı
            // 
            this.btnSettings.BackColor = Color.FromArgb(149, 165, 166);
            this.btnSettings.FlatStyle = FlatStyle.Flat;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnSettings.ForeColor = Color.White;
            this.btnSettings.Location = new Point(240, 410);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new Size(220, 70);
            this.btnSettings.Text = "⚙️ Ayarlar";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Cursor = Cursors.Hand;
            this.btnSettings.Click += new EventHandler(this.btnSettings_Click);
            this.btnSettings.MouseEnter += new EventHandler(this.Button_MouseEnter);
            this.btnSettings.MouseLeave += new EventHandler(this.Button_MouseLeave);

            // 
            // btnLogout - Küçük çıkış butonu (sol üst)
            // 
            this.btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(20, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new Size(80, 30);
            this.btnLogout.Text = "🚪 Çıkış";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);
            this.btnLogout.MouseEnter += new EventHandler(this.Button_MouseEnter);
            this.btnLogout.MouseLeave += new EventHandler(this.Button_MouseLeave);

            // 
            // MainMenuForm - Modern form tasarımı
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(700, 520);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnCategoryManagement);
            this.Controls.Add(this.btnReservationManagement);
            this.Controls.Add(this.btnBorrowManagement);
            this.Controls.Add(this.btnBookManagement);
            this.Controls.Add(this.btnStudentManagement);
            this.Controls.Add(this.btnEmployeeManagement);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Ana Menü - Kütüphane Sistemi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupUserPermissions()
        {
            // Kullanıcı rolüne göre butonları etkinleştir/devre dışı bırak
            switch (currentUser.Role.ToLower())
            {
                case "admin":
                    // Admin tüm işlemleri yapabilir
                    btnBorrowManagement.Text = "📋 Ödünç Kayıtları";
                    btnReservationManagement.Enabled = true;
                    btnReservationManagement.BackColor = Color.LightGray;
                    btnCategoryManagement.Enabled = true;
                    btnCategoryManagement.BackColor = Color.LightGray;
                    break;
                case "librarian":
                    // Kütüphaneci görevli yönetimi yapamaz
                    btnEmployeeManagement.Enabled = false;
                    btnEmployeeManagement.BackColor = Color.Gray;
                    btnBorrowManagement.Text = "📋 Ödünç Kayıtları";
                    btnReservationManagement.Enabled = true;
                    btnReservationManagement.BackColor = Color.LightGray;
                    btnCategoryManagement.Enabled = true;
                    btnCategoryManagement.BackColor = Color.LightGray;
                    break;
                case "user":
                    // Normal kullanıcı sadece kitap arama ve ödünç alma yapabilir
                    btnEmployeeManagement.Enabled = false;
                    btnEmployeeManagement.BackColor = Color.Gray;
                    btnStudentManagement.Enabled = false;
                    btnStudentManagement.BackColor = Color.Gray;
                    btnBookManagement.Enabled = false;
                    btnBookManagement.BackColor = Color.Gray;
                    btnBorrowManagement.Text = "📖 Ödünç Alma";
                    btnBorrowManagement.Enabled = true;
                    btnBorrowManagement.BackColor = Color.LightCoral;
                    btnReservationManagement.Enabled = false;
                    btnReservationManagement.BackColor = Color.Gray;
                    btnCategoryManagement.Enabled = false;
                    btnCategoryManagement.BackColor = Color.Gray;
                    btnSettings.Enabled = false;
                    btnSettings.BackColor = Color.Gray;
                    break;
            }
        }

        private void btnEmployeeManagement_Click(object sender, EventArgs e)
        {
            var employeeForm = new EmployeeManagementForm(currentUser, database);
            employeeForm.ShowDialog();
        }

        private void btnStudentManagement_Click(object sender, EventArgs e)
        {
            var studentForm = new Form1(currentUser);
            studentForm.ShowDialog();
        }

        private void btnBookManagement_Click(object sender, EventArgs e)
        {
            var bookForm = new BookManagementForm();
            bookForm.ShowDialog();
        }

        private void btnBorrowManagement_Click(object sender, EventArgs e)
        {
            if (currentUser.Role.ToLower() == "user")
            {
                // Normal kullanıcı için kitap arama/görüntüleme formu
                var borrowForm = new BorrowManagementForm(currentUser);
                borrowForm.ShowDialog();
            }
            else
            {
                // Admin/Librarian için ödünç kayıtları yönetim formu
                var borrowRecordForm = new BorrowRecordManagementForm(currentUser, database);
                borrowRecordForm.ShowDialog();
            }
        }

        private void btnReservationManagement_Click(object sender, EventArgs e)
        {
            var reservationForm = new ReservationManagementForm(currentUser, database);
            reservationForm.ShowDialog();
        }

        private void btnCategoryManagement_Click(object sender, EventArgs e)
        {
            var categoryForm = new CategoryManagementForm();
            categoryForm.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(currentUser);
            settingsForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", 
                "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
        
        private void OnThemeChanged(object? sender, EventArgs e)
        {
            // Tema değiştiğinde bu formu güncelle
            ThemeManager.ApplyTheme(this);
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
                if (button == btnEmployeeManagement)
                    button.BackColor = Color.FromArgb(52, 152, 219);
                else if (button == btnStudentManagement)
                    button.BackColor = Color.FromArgb(46, 204, 113);
                else if (button == btnBookManagement)
                    button.BackColor = Color.FromArgb(241, 196, 15);
                else if (button == btnBorrowManagement)
                    button.BackColor = Color.FromArgb(231, 76, 60);
                else if (button == btnReservationManagement)
                    button.BackColor = Color.FromArgb(155, 89, 182);
                else if (button == btnCategoryManagement)
                    button.BackColor = Color.FromArgb(230, 126, 34);
                else if (button == btnSettings)
                    button.BackColor = Color.FromArgb(149, 165, 166);
                else if (button == btnLogout)
                    button.BackColor = Color.FromArgb(192, 57, 43);
                
                // Border'ı kaldır
                button.FlatAppearance.BorderSize = 0;
            }
        }
        
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Event listener'ı temizle
            ThemeManager.ThemeChanged -= OnThemeChanged;
            base.OnFormClosed(e);
        }
    }
} 