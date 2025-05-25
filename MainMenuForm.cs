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

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.DarkBlue;
            this.lblTitle.Location = new Point(50, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(350, 29);
            this.lblTitle.Text = "Kütüphane Yönetim Sistemi";

            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblUserInfo.ForeColor = Color.DarkGreen;
            this.lblUserInfo.Location = new Point(50, 60);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new Size(200, 20);
            this.lblUserInfo.Text = $"Hoş geldiniz, {currentUser.FullName}";

            // 
            // btnEmployeeManagement
            // 
            this.btnEmployeeManagement.BackColor = Color.LightBlue;
            this.btnEmployeeManagement.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnEmployeeManagement.Location = new Point(50, 120);
            this.btnEmployeeManagement.Name = "btnEmployeeManagement";
            this.btnEmployeeManagement.Size = new Size(200, 50);
            this.btnEmployeeManagement.Text = "👥 Görevli Yönetimi";
            this.btnEmployeeManagement.UseVisualStyleBackColor = false;
            this.btnEmployeeManagement.Click += new EventHandler(this.btnEmployeeManagement_Click);

            // 
            // btnStudentManagement
            // 
            this.btnStudentManagement.BackColor = Color.LightGreen;
            this.btnStudentManagement.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnStudentManagement.Location = new Point(270, 120);
            this.btnStudentManagement.Name = "btnStudentManagement";
            this.btnStudentManagement.Size = new Size(200, 50);
            this.btnStudentManagement.Text = "🎓 Öğrenci Yönetimi";
            this.btnStudentManagement.UseVisualStyleBackColor = false;
            this.btnStudentManagement.Click += new EventHandler(this.btnStudentManagement_Click);

            // 
            // btnBookManagement
            // 
            this.btnBookManagement.BackColor = Color.LightYellow;
            this.btnBookManagement.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnBookManagement.Location = new Point(50, 190);
            this.btnBookManagement.Name = "btnBookManagement";
            this.btnBookManagement.Size = new Size(200, 50);
            this.btnBookManagement.Text = "📚 Kitap Yönetimi";
            this.btnBookManagement.UseVisualStyleBackColor = false;
            this.btnBookManagement.Click += new EventHandler(this.btnBookManagement_Click);

            // 
            // btnBorrowManagement
            // 
            this.btnBorrowManagement.BackColor = Color.LightCoral;
            this.btnBorrowManagement.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnBorrowManagement.Location = new Point(270, 190);
            this.btnBorrowManagement.Name = "btnBorrowManagement";
            this.btnBorrowManagement.Size = new Size(200, 50);
            this.btnBorrowManagement.Text = "📋 Ödünç Kayıtları";
            this.btnBorrowManagement.UseVisualStyleBackColor = false;
            this.btnBorrowManagement.Click += new EventHandler(this.btnBorrowManagement_Click);

            // 
            // btnReservationManagement
            // 
            this.btnReservationManagement.BackColor = Color.LightGray;
            this.btnReservationManagement.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnReservationManagement.Location = new Point(50, 260);
            this.btnReservationManagement.Name = "btnReservationManagement";
            this.btnReservationManagement.Size = new Size(200, 50);
            this.btnReservationManagement.Text = "📅 Rezervasyonlar";
            this.btnReservationManagement.UseVisualStyleBackColor = false;
            this.btnReservationManagement.Click += new EventHandler(this.btnReservationManagement_Click);

            // 
            // btnCategoryManagement
            // 
            this.btnCategoryManagement.BackColor = Color.LightGray;
            this.btnCategoryManagement.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCategoryManagement.Location = new Point(270, 260);
            this.btnCategoryManagement.Name = "btnCategoryManagement";
            this.btnCategoryManagement.Size = new Size(200, 50);
            this.btnCategoryManagement.Text = "📋 Kategori Yönetimi";
            this.btnCategoryManagement.UseVisualStyleBackColor = false;
            this.btnCategoryManagement.Click += new EventHandler(this.btnCategoryManagement_Click);

            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = Color.LightGray;
            this.btnSettings.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnSettings.Location = new Point(50, 330);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new Size(200, 50);
            this.btnSettings.Text = "⚙️ Ayarlar";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new EventHandler(this.btnSettings_Click);

            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = Color.IndianRed;
            this.btnLogout.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(370, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new Size(100, 35);
            this.btnLogout.Text = "🚪 Çıkış Yap";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);

            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(520, 450);
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
                var borrowForm = new BorrowManagementForm();
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
    }
} 