using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleWindowsForm.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleWindowsForm
{
    public partial class Form1 : Form
    {
        private Label label1;
        private Button button1;
        private Label dbStatusLabel;
        private Label efStatusLabel;
        private Database database;

        // CRUD işlemleri için kontroller
        private TextBox txtName;
        private TextBox txtStudentNumber;
        private TextBox txtEmail;
        private Button btnCreate;
        private Button btnRead;
        private Button btnUpdate;
        private Button btnDelete;
        private ListBox lstStudents;
        private Label lblName;
        private Label lblStudentNumber;
        private Label lblEmail;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                database = new Database();
                dbStatusLabel.Text = "✅ Veritabanı Bağlantısı: Başarılı";
                dbStatusLabel.ForeColor = Color.Green;
                
                // Entity Framework durumunu göster
                int studentCount = database.GetStudentCount();
                efStatusLabel.Text = $"✅ Entity Framework: Aktif ({studentCount} öğrenci)";
                efStatusLabel.ForeColor = Color.Green;

                // Öğrenci listesini yükle
                LoadStudents();
            }
            catch (Exception ex)
            {
                dbStatusLabel.Text = "❌ Veritabanı Bağlantısı: Başarısız";
                dbStatusLabel.ForeColor = Color.Red;
                efStatusLabel.Text = "❌ Entity Framework: Başarısız";
                efStatusLabel.ForeColor = Color.Red;
                MessageBox.Show($"Veritabanı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.button1 = new Button();
            this.dbStatusLabel = new Label();
            this.efStatusLabel = new Label();
            
            // CRUD kontrolleri
            this.lblName = new Label();
            this.lblStudentNumber = new Label();
            this.lblEmail = new Label();
            this.txtName = new TextBox();
            this.txtStudentNumber = new TextBox();
            this.txtEmail = new TextBox();
            this.btnCreate = new Button();
            this.btnRead = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.lstStudents = new ListBox();
            
            this.SuspendLayout();

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.label1.Location = new Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(300, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entity Framework CRUD İşlemleri";

            // 
            // dbStatusLabel
            // 
            this.dbStatusLabel.AutoSize = true;
            this.dbStatusLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.dbStatusLabel.Location = new Point(20, 40);
            this.dbStatusLabel.Name = "dbStatusLabel";
            this.dbStatusLabel.Size = new Size(200, 15);
            this.dbStatusLabel.TabIndex = 2;
            this.dbStatusLabel.Text = "Veritabanı durumu kontrol ediliyor...";

            // 
            // efStatusLabel
            // 
            this.efStatusLabel.AutoSize = true;
            this.efStatusLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.efStatusLabel.Location = new Point(20, 60);
            this.efStatusLabel.Name = "efStatusLabel";
            this.efStatusLabel.Size = new Size(200, 15);
            this.efStatusLabel.TabIndex = 3;
            this.efStatusLabel.Text = "Entity Framework kontrol ediliyor...";

            // CRUD Form Alanları
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(20, 100);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(28, 15);
            this.lblName.Text = "Ad:";

            // 
            // txtName
            // 
            this.txtName.Location = new Point(120, 97);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(200, 23);
            this.txtName.TabIndex = 4;

            // 
            // lblStudentNumber
            // 
            this.lblStudentNumber.AutoSize = true;
            this.lblStudentNumber.Location = new Point(20, 130);
            this.lblStudentNumber.Name = "lblStudentNumber";
            this.lblStudentNumber.Size = new Size(85, 15);
            this.lblStudentNumber.Text = "Öğrenci No:";

            // 
            // txtStudentNumber
            // 
            this.txtStudentNumber.Location = new Point(120, 127);
            this.txtStudentNumber.Name = "txtStudentNumber";
            this.txtStudentNumber.Size = new Size(200, 23);
            this.txtStudentNumber.TabIndex = 5;

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(20, 160);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(39, 15);
            this.lblEmail.Text = "Email:";

            // 
            // txtEmail
            // 
            this.txtEmail.Location = new Point(120, 157);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(200, 23);
            this.txtEmail.TabIndex = 6;

            // CRUD Butonları
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = Color.LightGreen;
            this.btnCreate.Location = new Point(20, 200);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new Size(70, 30);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Ekle (C)";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new EventHandler(this.btnCreate_Click);

            // 
            // btnRead
            // 
            this.btnRead.BackColor = Color.LightBlue;
            this.btnRead.Location = new Point(100, 200);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new Size(70, 30);
            this.btnRead.TabIndex = 8;
            this.btnRead.Text = "Listele (R)";
            this.btnRead.UseVisualStyleBackColor = false;
            this.btnRead.Click += new EventHandler(this.btnRead_Click);

            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = Color.LightYellow;
            this.btnUpdate.Location = new Point(180, 200);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new Size(70, 30);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Güncelle (U)";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = Color.LightCoral;
            this.btnDelete.Location = new Point(260, 200);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(70, 30);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Sil (D)";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            // 
            // lstStudents
            // 
            this.lstStudents.FormattingEnabled = true;
            this.lstStudents.ItemHeight = 15;
            this.lstStudents.Location = new Point(20, 250);
            this.lstStudents.Name = "lstStudents";
            this.lstStudents.Size = new Size(400, 150);
            this.lstStudents.TabIndex = 11;
            this.lstStudents.SelectedIndexChanged += new EventHandler(this.lstStudents_SelectedIndexChanged);

            // 
            // button1
            // 
            this.button1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.button1.Location = new Point(350, 40);
            this.button1.Name = "button1";
            this.button1.Size = new Size(120, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "EF Durumunu Kontrol Et";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 430);
            this.Controls.Add(this.lstStudents);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtStudentNumber);
            this.Controls.Add(this.lblStudentNumber);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.efStatusLabel);
            this.Controls.Add(this.dbStatusLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Entity Framework CRUD Projesi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // CREATE - Yeni öğrenci ekle
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtStudentNumber.Text))
                {
                    MessageBox.Show("Ad ve Öğrenci No alanları zorunludur!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var context = database.GetDbContext())
                {
                    var student = new Student
                    {
                        Name = txtName.Text.Trim(),
                        StudentNumber = txtStudentNumber.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        CreatedDate = DateTime.Now
                    };

                    context.Students.Add(student);
                    context.SaveChanges();
                }

                MessageBox.Show("✅ Öğrenci başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadStudents();
                UpdateStudentCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // READ - Öğrencileri listele
        private void btnRead_Click(object sender, EventArgs e)
        {
            LoadStudents();
            MessageBox.Show("✅ Öğrenci listesi yenilendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // UPDATE - Seçili öğrenciyi güncelle
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstStudents.SelectedItem == null)
                {
                    MessageBox.Show("Güncellemek için bir öğrenci seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtStudentNumber.Text))
                {
                    MessageBox.Show("Ad ve Öğrenci No alanları zorunludur!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedText = lstStudents.SelectedItem.ToString();
                int studentId = int.Parse(selectedText.Split('-')[0].Trim());

                using (var context = database.GetDbContext())
                {
                    var student = context.Students.Find(studentId);
                    if (student != null)
                    {
                        student.Name = txtName.Text.Trim();
                        student.StudentNumber = txtStudentNumber.Text.Trim();
                        student.Email = txtEmail.Text.Trim();
                        context.SaveChanges();
                    }
                }

                MessageBox.Show("✅ Öğrenci başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DELETE - Seçili öğrenciyi sil
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstStudents.SelectedItem == null)
                {
                    MessageBox.Show("Silmek için bir öğrenci seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Seçili öğrenciyi silmek istediğinizden emin misiniz?", 
                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string selectedText = lstStudents.SelectedItem.ToString();
                    int studentId = int.Parse(selectedText.Split('-')[0].Trim());

                    using (var context = database.GetDbContext())
                    {
                        var student = context.Students.Find(studentId);
                        if (student != null)
                        {
                            context.Students.Remove(student);
                            context.SaveChanges();
                        }
                    }

                    MessageBox.Show("✅ Öğrenci başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadStudents();
                    UpdateStudentCount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Öğrenci listesini yükle
        private void LoadStudents()
        {
            try
            {
                using (var context = database.GetDbContext())
                {
                    var students = context.Students.OrderBy(s => s.Id).ToList();
                    lstStudents.Items.Clear();
                    
                    foreach (var student in students)
                    {
                        lstStudents.Items.Add($"{student.Id} - {student.Name} ({student.StudentNumber}) - {student.Email}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Liste yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Listeden öğrenci seçildiğinde form alanlarını doldur
        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstStudents.SelectedItem != null)
                {
                    string selectedText = lstStudents.SelectedItem.ToString();
                    int studentId = int.Parse(selectedText.Split('-')[0].Trim());

                    using (var context = database.GetDbContext())
                    {
                        var student = context.Students.Find(studentId);
                        if (student != null)
                        {
                            txtName.Text = student.Name;
                            txtStudentNumber.Text = student.StudentNumber;
                            txtEmail.Text = student.Email;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Öğrenci bilgileri yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Form alanlarını temizle
        private void ClearForm()
        {
            txtName.Clear();
            txtStudentNumber.Clear();
            txtEmail.Clear();
            lstStudents.ClearSelected();
        }

        // Öğrenci sayısını güncelle
        private void UpdateStudentCount()
        {
            int studentCount = database.GetStudentCount();
            efStatusLabel.Text = $"✅ Entity Framework: Aktif ({studentCount} öğrenci)";
        }

        // EF Durum kontrolü
        private void button1_Click(object sender, EventArgs e)
        {
            if (database != null && database.TestConnection())
            {
                string dbPath = database.GetDatabasePath();
                int studentCount = database.GetStudentCount();
                
                MessageBox.Show($"✅ Entity Framework bağlantısı başarılı!\n\n" +
                    $"Veritabanı konumu:\n{dbPath}\n\n" +
                    $"Toplam öğrenci sayısı: {studentCount}", 
                    "Entity Framework Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("❌ Entity Framework bağlantısı başarısız!", 
                    "Bağlantı Testi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 