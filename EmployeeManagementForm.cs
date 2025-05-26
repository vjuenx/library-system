using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleWindowsForm.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleWindowsForm
{
    public partial class EmployeeManagementForm : Form
    {
        private Label lblTitle;
        private Label lblFullName;
        private Label lblEmployeeNumber;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblDepartment;
        private Label lblPosition;
        private Label lblSalary;
        private Label lblHireDate;
        
        private TextBox txtFullName;
        private TextBox txtEmployeeNumber;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private ComboBox cmbDepartment;
        private ComboBox cmbPosition;
        private NumericUpDown nudSalary;
        private DateTimePicker dtpHireDate;
        private CheckBox chkIsActive;
        
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnClose;
        
        private ListBox lstEmployees;
        private Label lblEmployeeCount;
        
        private User currentUser;
        private Database database;

        public EmployeeManagementForm(User user, Database db)
        {
            currentUser = user;
            database = db;
            InitializeComponent();
            LoadEmployees();
            LoadDepartments();
            LoadPositions();
            
            // Tema değişikliği event'ini dinle
            ThemeManager.ThemeChanged += OnThemeChanged;
            // İlk tema uygulaması
            ThemeManager.ApplyTheme(this);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblFullName = new Label();
            this.lblEmployeeNumber = new Label();
            this.lblEmail = new Label();
            this.lblPhone = new Label();
            this.lblDepartment = new Label();
            this.lblPosition = new Label();
            this.lblSalary = new Label();
            this.lblHireDate = new Label();
            
            this.txtFullName = new TextBox();
            this.txtEmployeeNumber = new TextBox();
            this.txtEmail = new TextBox();
            this.txtPhone = new TextBox();
            this.cmbDepartment = new ComboBox();
            this.cmbPosition = new ComboBox();
            this.nudSalary = new NumericUpDown();
            this.dtpHireDate = new DateTimePicker();
            this.chkIsActive = new CheckBox();
            
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.btnClear = new Button();
            this.btnClose = new Button();
            
            this.lstEmployees = new ListBox();
            this.lblEmployeeCount = new Label();
            
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.DarkBlue;
            this.lblTitle.Location = new Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(200, 26);
            this.lblTitle.Text = "👥 Görevli Yönetimi";

            // Form alanları - Sol taraf
            int leftX = 20;
            int rightX = 150;
            int startY = 60;
            int spacing = 35;

            // Ad Soyad
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new Point(leftX, startY);
            this.lblFullName.Text = "Ad Soyad:";
            this.txtFullName.Location = new Point(rightX, startY - 3);
            this.txtFullName.Size = new Size(200, 23);

            // Görevli No
            this.lblEmployeeNumber.AutoSize = true;
            this.lblEmployeeNumber.Location = new Point(leftX, startY + spacing);
            this.lblEmployeeNumber.Text = "Görevli No:";
            this.txtEmployeeNumber.Location = new Point(rightX, startY + spacing - 3);
            this.txtEmployeeNumber.Size = new Size(200, 23);

            // Email
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(leftX, startY + spacing * 2);
            this.lblEmail.Text = "Email:";
            this.txtEmail.Location = new Point(rightX, startY + spacing * 2 - 3);
            this.txtEmail.Size = new Size(200, 23);

            // Telefon
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new Point(leftX, startY + spacing * 3);
            this.lblPhone.Text = "Telefon:";
            this.txtPhone.Location = new Point(rightX, startY + spacing * 3 - 3);
            this.txtPhone.Size = new Size(200, 23);

            // Departman
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new Point(leftX, startY + spacing * 4);
            this.lblDepartment.Text = "Departman:";
            this.cmbDepartment.Location = new Point(rightX, startY + spacing * 4 - 3);
            this.cmbDepartment.Size = new Size(200, 23);
            this.cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;

            // Pozisyon
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new Point(leftX, startY + spacing * 5);
            this.lblPosition.Text = "Pozisyon:";
            this.cmbPosition.Location = new Point(rightX, startY + spacing * 5 - 3);
            this.cmbPosition.Size = new Size(200, 23);
            this.cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;

            // Maaş
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new Point(leftX, startY + spacing * 6);
            this.lblSalary.Text = "Maaş (TL):";
            this.nudSalary.Location = new Point(rightX, startY + spacing * 6 - 3);
            this.nudSalary.Size = new Size(200, 23);
            this.nudSalary.Maximum = 999999;
            this.nudSalary.DecimalPlaces = 2;

            // İşe Giriş Tarihi
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Location = new Point(leftX, startY + spacing * 7);
            this.lblHireDate.Text = "İşe Giriş Tarihi:";
            this.dtpHireDate.Location = new Point(rightX, startY + spacing * 7 - 3);
            this.dtpHireDate.Size = new Size(200, 23);
            this.dtpHireDate.Format = DateTimePickerFormat.Short;

            // Aktif mi?
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new Point(rightX, startY + spacing * 8);
            this.chkIsActive.Text = "Aktif Görevli";
            this.chkIsActive.Checked = true;

            // Butonlar - Daha fazla boşluk bırakarak
            int btnY = startY + spacing * 9 + 20; // 20px daha aşağı
            int btnSpacing = 95; // Butonlar arası boşluk artırıldı
            
            this.btnAdd.BackColor = Color.LightGreen;
            this.btnAdd.Location = new Point(leftX, btnY);
            this.btnAdd.Size = new Size(85, 35); // Buton boyutu artırıldı
            this.btnAdd.Text = "➕ Ekle";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            this.btnUpdate.BackColor = Color.LightYellow;
            this.btnUpdate.Location = new Point(leftX + btnSpacing, btnY);
            this.btnUpdate.Size = new Size(85, 35);
            this.btnUpdate.Text = "✏️ Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            this.btnDelete.BackColor = Color.LightCoral;
            this.btnDelete.Location = new Point(leftX + btnSpacing * 2, btnY);
            this.btnDelete.Size = new Size(85, 35);
            this.btnDelete.Text = "🗑️ Sil";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            this.btnClear.BackColor = Color.LightBlue;
            this.btnClear.Location = new Point(leftX + btnSpacing * 3, btnY);
            this.btnClear.Size = new Size(85, 35);
            this.btnClear.Text = "🧹 Temizle";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            // Görevli Listesi - Sağ taraf
            int listX = 420; // Liste daha sağa kaydırıldı
            this.lblEmployeeCount.AutoSize = true;
            this.lblEmployeeCount.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblEmployeeCount.Location = new Point(listX, startY);
            this.lblEmployeeCount.Text = "Görevli Listesi (0)";

            this.lstEmployees.Location = new Point(listX, startY + 25);
            this.lstEmployees.Size = new Size(480, 280); // Liste boyutu artırıldı
            this.lstEmployees.SelectedIndexChanged += new EventHandler(this.lstEmployees_SelectedIndexChanged);

            // Kapat butonu
            this.btnClose.BackColor = Color.IndianRed;
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnClose.Location = new Point(820, 10); // Kapat butonu daha sağa
            this.btnClose.Size = new Size(80, 35);
            this.btnClose.Text = "❌ Kapat";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // 
            // EmployeeManagementForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(920, 450); // Form boyutu artırıldı
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstEmployees);
            this.Controls.Add(this.lblEmployeeCount);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.dtpHireDate);
            this.Controls.Add(this.nudSalary);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtEmployeeNumber);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblEmployeeNumber);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Görevli Yönetimi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LoadDepartments()
        {
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.AddRange(new string[]
            {
                "Kütüphane",
                "Bilgi İşlem",
                "İnsan Kaynakları",
                "Muhasebe",
                "Temizlik",
                "Güvenlik",
                "Yönetim"
            });
        }

        private void LoadPositions()
        {
            cmbPosition.Items.Clear();
            cmbPosition.Items.AddRange(new string[]
            {
                "Kütüphaneci",
                "Kıdemli Kütüphaneci",
                "Kütüphane Müdürü",
                "IT Uzmanı",
                "Sistem Yöneticisi",
                "İK Uzmanı",
                "Muhasebeci",
                "Temizlik Görevlisi",
                "Güvenlik Görevlisi",
                "Genel Müdür"
            });
        }

        private void LoadEmployees()
        {
            try
            {
                using (var context = database.GetDbContext())
                {
                    var employees = context.Employees.OrderBy(e => e.FullName).ToList();
                    lstEmployees.Items.Clear();
                    
                    foreach (var employee in employees)
                    {
                        string status = employee.IsActive ? "✅" : "❌";
                        lstEmployees.Items.Add($"{employee.Id} - {employee.FullName} ({employee.EmployeeNumber}) - {employee.Department} - {status}");
                    }
                    
                    lblEmployeeCount.Text = $"Görevli Listesi ({employees.Count})";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Görevli listesi yüklenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm()) return;

                using (var context = database.GetDbContext())
                {
                    var employee = new Employee
                    {
                        FullName = txtFullName.Text.Trim(),
                        EmployeeNumber = txtEmployeeNumber.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Department = cmbDepartment.SelectedItem?.ToString() ?? "",
                        Position = cmbPosition.SelectedItem?.ToString() ?? "",
                        Salary = nudSalary.Value,
                        HireDate = dtpHireDate.Value,
                        IsActive = chkIsActive.Checked,
                        CreatedDate = DateTime.Now
                    };

                    context.Employees.Add(employee);
                    context.SaveChanges();
                }

                MessageBox.Show("✅ Görevli başarıyla eklendi!", "Başarılı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstEmployees.SelectedItem == null)
                {
                    MessageBox.Show("Güncellemek için bir görevli seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateForm()) return;

                string selectedText = lstEmployees.SelectedItem.ToString();
                int employeeId = int.Parse(selectedText.Split('-')[0].Trim());

                using (var context = database.GetDbContext())
                {
                    var employee = context.Employees.Find(employeeId);
                    if (employee != null)
                    {
                        employee.FullName = txtFullName.Text.Trim();
                        employee.EmployeeNumber = txtEmployeeNumber.Text.Trim();
                        employee.Email = txtEmail.Text.Trim();
                        employee.Phone = txtPhone.Text.Trim();
                        employee.Department = cmbDepartment.SelectedItem?.ToString() ?? "";
                        employee.Position = cmbPosition.SelectedItem?.ToString() ?? "";
                        employee.Salary = nudSalary.Value;
                        employee.HireDate = dtpHireDate.Value;
                        employee.IsActive = chkIsActive.Checked;
                        
                        context.SaveChanges();
                    }
                }

                MessageBox.Show("✅ Görevli başarıyla güncellendi!", "Başarılı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstEmployees.SelectedItem == null)
                {
                    MessageBox.Show("Silmek için bir görevli seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Seçili görevliyi silmek istediğinizden emin misiniz?", 
                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string selectedText = lstEmployees.SelectedItem.ToString();
                    int employeeId = int.Parse(selectedText.Split('-')[0].Trim());

                    using (var context = database.GetDbContext())
                    {
                        var employee = context.Employees.Find(employeeId);
                        if (employee != null)
                        {
                            context.Employees.Remove(employee);
                            context.SaveChanges();
                        }
                    }

                    MessageBox.Show("✅ Görevli başarıyla silindi!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstEmployees.SelectedItem != null)
                {
                    string selectedText = lstEmployees.SelectedItem.ToString();
                    int employeeId = int.Parse(selectedText.Split('-')[0].Trim());

                    using (var context = database.GetDbContext())
                    {
                        var employee = context.Employees.Find(employeeId);
                        if (employee != null)
                        {
                            txtFullName.Text = employee.FullName;
                            txtEmployeeNumber.Text = employee.EmployeeNumber;
                            txtEmail.Text = employee.Email;
                            txtPhone.Text = employee.Phone;
                            cmbDepartment.SelectedItem = employee.Department;
                            cmbPosition.SelectedItem = employee.Position;
                            nudSalary.Value = employee.Salary;
                            dtpHireDate.Value = employee.HireDate;
                            chkIsActive.Checked = employee.IsActive;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Görevli bilgileri yüklenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Ad Soyad alanı zorunludur!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmployeeNumber.Text))
            {
                MessageBox.Show("Görevli No alanı zorunludur!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeNumber.Focus();
                return false;
            }

            if (cmbDepartment.SelectedItem == null)
            {
                MessageBox.Show("Departman seçimi zorunludur!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartment.Focus();
                return false;
            }

            if (cmbPosition.SelectedItem == null)
            {
                MessageBox.Show("Pozisyon seçimi zorunludur!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPosition.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtFullName.Clear();
            txtEmployeeNumber.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            nudSalary.Value = 0;
            dtpHireDate.Value = DateTime.Now;
            chkIsActive.Checked = true;
            lstEmployees.ClearSelected();
        }
        
        private void OnThemeChanged(object? sender, EventArgs e)
        {
            // Tema değiştiğinde bu formu güncelle
            ThemeManager.ApplyTheme(this);
        }
        
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Event listener'ı temizle
            ThemeManager.ThemeChanged -= OnThemeChanged;
            base.OnFormClosed(e);
        }
    }
} 