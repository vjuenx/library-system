using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SimpleWindowsForm.Models;

namespace SimpleWindowsForm
{
    public partial class BorrowRecordManagementForm : Form
    {
        private Label lblTitle;
        private Label lblStudentSelect;
        private Label lblBookSelect;
        private Label lblBorrowDate;
        private Label lblDueDate;
        
        private ComboBox cmbStudents;
        private ComboBox cmbBooks;
        private DateTimePicker dtpBorrowDate;
        private DateTimePicker dtpDueDate;
        
        private Button btnBorrow;
        private Button btnReturn;
        private Button btnRefresh;
        private Button btnClose;
        
        private ListBox lstBorrowRecords;
        private Label lblRecordCount;
        
        private Database database;
        private User currentUser;

        public BorrowRecordManagementForm(User user, Database db)
        {
            currentUser = user;
            database = db;
            InitializeComponent();
            LoadData();
            
            // Tema değişikliği event'ini dinle
            ThemeManager.ThemeChanged += OnThemeChanged;
            // İlk tema uygulaması
            ThemeManager.ApplyTheme(this);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblStudentSelect = new Label();
            this.lblBookSelect = new Label();
            this.lblBorrowDate = new Label();
            this.lblDueDate = new Label();
            this.cmbStudents = new ComboBox();
            this.cmbBooks = new ComboBox();
            this.dtpBorrowDate = new DateTimePicker();
            this.dtpDueDate = new DateTimePicker();
            this.btnBorrow = new Button();
            this.btnReturn = new Button();
            this.btnRefresh = new Button();
            this.btnClose = new Button();
            this.lstBorrowRecords = new ListBox();
            this.lblRecordCount = new Label();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.DarkBlue;
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(250, 26);
            this.lblTitle.Text = "📖 Ödünç Alma Kayıtları";

            // 
            // lblStudentSelect
            // 
            this.lblStudentSelect.AutoSize = true;
            this.lblStudentSelect.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblStudentSelect.Location = new Point(20, 70);
            this.lblStudentSelect.Name = "lblStudentSelect";
            this.lblStudentSelect.Size = new Size(60, 15);
            this.lblStudentSelect.Text = "Öğrenci:";

            // 
            // cmbStudents
            // 
            this.cmbStudents.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStudents.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.cmbStudents.Location = new Point(100, 67);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new Size(200, 23);
            this.cmbStudents.TabIndex = 0;

            // 
            // lblBookSelect
            // 
            this.lblBookSelect.AutoSize = true;
            this.lblBookSelect.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblBookSelect.Location = new Point(320, 70);
            this.lblBookSelect.Name = "lblBookSelect";
            this.lblBookSelect.Size = new Size(40, 15);
            this.lblBookSelect.Text = "Kitap:";

            // 
            // cmbBooks
            // 
            this.cmbBooks.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBooks.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.cmbBooks.Location = new Point(370, 67);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new Size(250, 23);
            this.cmbBooks.TabIndex = 1;

            // 
            // lblBorrowDate
            // 
            this.lblBorrowDate.AutoSize = true;
            this.lblBorrowDate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblBorrowDate.Location = new Point(20, 110);
            this.lblBorrowDate.Name = "lblBorrowDate";
            this.lblBorrowDate.Size = new Size(75, 15);
            this.lblBorrowDate.Text = "Alış Tarihi:";

            // 
            // dtpBorrowDate
            // 
            this.dtpBorrowDate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.dtpBorrowDate.Location = new Point(100, 107);
            this.dtpBorrowDate.Name = "dtpBorrowDate";
            this.dtpBorrowDate.Size = new Size(200, 21);
            this.dtpBorrowDate.TabIndex = 2;
            this.dtpBorrowDate.Value = DateTime.Now;

            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblDueDate.Location = new Point(320, 110);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new Size(75, 15);
            this.lblDueDate.Text = "İade Tarihi:";

            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.dtpDueDate.Location = new Point(400, 107);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new Size(200, 21);
            this.dtpDueDate.TabIndex = 3;
            this.dtpDueDate.Value = DateTime.Now.AddDays(14); // 2 hafta sonra

            // 
            // btnBorrow
            // 
            this.btnBorrow.BackColor = Color.LightGreen;
            this.btnBorrow.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnBorrow.Location = new Point(20, 150);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new Size(100, 30);
            this.btnBorrow.TabIndex = 4;
            this.btnBorrow.Text = "📖 Ödünç Ver";
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new EventHandler(this.btnBorrow_Click);

            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = Color.LightBlue;
            this.btnReturn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnReturn.Location = new Point(130, 150);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new Size(100, 30);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "✅ İade Al";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new EventHandler(this.btnReturn_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = Color.LightYellow;
            this.btnRefresh.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnRefresh.Location = new Point(240, 150);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(100, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "🔄 Yenile";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // 
            // btnClose
            // 
            this.btnClose.BackColor = Color.LightCoral;
            this.btnClose.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnClose.Location = new Point(520, 150);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(100, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "❌ Kapat";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // 
            // lstBorrowRecords
            // 
            this.lstBorrowRecords.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lstBorrowRecords.FormattingEnabled = true;
            this.lstBorrowRecords.ItemHeight = 15;
            this.lstBorrowRecords.Location = new Point(20, 200);
            this.lstBorrowRecords.Name = "lstBorrowRecords";
            this.lstBorrowRecords.Size = new Size(600, 200);
            this.lstBorrowRecords.TabIndex = 8;
            this.lstBorrowRecords.SelectedIndexChanged += new EventHandler(this.lstBorrowRecords_SelectedIndexChanged);

            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblRecordCount.Location = new Point(20, 410);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new Size(100, 15);
            this.lblRecordCount.Text = "Toplam: 0 kayıt";

            // 
            // BorrowRecordManagementForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(650, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStudentSelect);
            this.Controls.Add(this.cmbStudents);
            this.Controls.Add(this.lblBookSelect);
            this.Controls.Add(this.cmbBooks);
            this.Controls.Add(this.lblBorrowDate);
            this.Controls.Add(this.dtpBorrowDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstBorrowRecords);
            this.Controls.Add(this.lblRecordCount);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorrowRecordManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Ödünç Alma Kayıtları - Kütüphane Sistemi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LoadData()
        {
            LoadStudents();
            LoadBooks();
            LoadBorrowRecords();
        }

        private void LoadStudents()
        {
            try
            {
                using (var context = database.GetDbContext())
                {
                    var students = context.Students.OrderBy(s => s.Name).ToList();
                    cmbStudents.Items.Clear();
                    cmbStudents.Items.Add("-- Öğrenci Seçin --");
                    
                    foreach (var student in students)
                    {
                        cmbStudents.Items.Add($"{student.Id} - {student.Name} ({student.StudentNumber})");
                    }
                    cmbStudents.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Öğrenci listesi yüklenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {
            try
            {
                using (var context = database.GetDbContext())
                {
                    var books = context.Books
                        .Where(b => b.IsActive && b.AvailableCopies > 0)
                        .OrderBy(b => b.Title)
                        .ToList();
                    
                    cmbBooks.Items.Clear();
                    cmbBooks.Items.Add("-- Kitap Seçin --");
                    
                    foreach (var book in books)
                    {
                        cmbBooks.Items.Add($"{book.Id} - {book.Title} ({book.AvailableCopies} adet)");
                    }
                    cmbBooks.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitap listesi yüklenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBorrowRecords()
        {
            try
            {
                using (var context = database.GetDbContext())
                {
                    var records = context.BorrowRecords
                        .Include(br => br.Student)
                        .Include(br => br.Book)
                        .Include(br => br.CreatedByUser)
                        .OrderByDescending(br => br.BorrowDate)
                        .ToList();
                    
                    lstBorrowRecords.Items.Clear();
                    
                    foreach (var record in records)
                    {
                        string status = record.IsReturned ? "✅ İade Edildi" : "📖 Ödünçte";
                        string returnInfo = record.IsReturned ? 
                            $" - İade: {record.ReturnDate?.ToString("dd.MM.yyyy")}" : 
                            $" - Son Tarih: {record.DueDate.ToString("dd.MM.yyyy")}";
                        
                        lstBorrowRecords.Items.Add(
                            $"{record.Id} - {record.Student?.Name} | {record.Book?.Title} | " +
                            $"{record.BorrowDate.ToString("dd.MM.yyyy")} | {status}{returnInfo}"
                        );
                    }
                    
                    lblRecordCount.Text = $"Toplam: {records.Count} kayıt";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt listesi yüklenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudents.SelectedIndex <= 0 || cmbBooks.SelectedIndex <= 0)
                {
                    MessageBox.Show("Lütfen öğrenci ve kitap seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Seçilen öğrenci ve kitap ID'lerini al
                int studentId = int.Parse(cmbStudents.SelectedItem.ToString().Split('-')[0].Trim());
                int bookId = int.Parse(cmbBooks.SelectedItem.ToString().Split('-')[0].Trim());

                using (var context = database.GetDbContext())
                {
                    // Kitabın müsait olup olmadığını kontrol et
                    var book = context.Books.Find(bookId);
                    if (book == null || book.AvailableCopies <= 0)
                    {
                        MessageBox.Show("Seçilen kitap müsait değil!", "Uyarı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Yeni ödünç kaydı oluştur
                    var borrowRecord = new BorrowRecord
                    {
                        StudentId = studentId,
                        BookId = bookId,
                        BorrowDate = dtpBorrowDate.Value,
                        DueDate = dtpDueDate.Value,
                        IsReturned = false,
                        CreatedBy = currentUser.Id,
                        CreatedDate = DateTime.Now
                    };

                    context.BorrowRecords.Add(borrowRecord);
                    
                    // Kitabın müsait kopya sayısını azalt
                    book.AvailableCopies--;
                    
                    context.SaveChanges();
                }

                MessageBox.Show("✅ Kitap başarıyla ödünç verildi!", "Başarılı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadData(); // Verileri yenile
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBorrowRecords.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen iade edilecek kaydı seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int recordId = int.Parse(lstBorrowRecords.SelectedItem.ToString().Split('-')[0].Trim());

                using (var context = database.GetDbContext())
                {
                    var record = context.BorrowRecords
                        .Include(br => br.Book)
                        .FirstOrDefault(br => br.Id == recordId);
                    
                    if (record == null)
                    {
                        MessageBox.Show("Kayıt bulunamadı!", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (record.IsReturned)
                    {
                        MessageBox.Show("Bu kitap zaten iade edilmiş!", "Uyarı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // İade işlemi
                    record.IsReturned = true;
                    record.ReturnDate = DateTime.Now;
                    
                    // Gecikme cezası hesapla (günlük 1 TL)
                    if (DateTime.Now > record.DueDate)
                    {
                        int lateDays = (DateTime.Now - record.DueDate).Days;
                        record.LateFee = lateDays * 1.0m; // 1 TL/gün
                    }
                    
                    // Kitabın müsait kopya sayısını artır
                    if (record.Book != null)
                    {
                        record.Book.AvailableCopies++;
                    }
                    
                    context.SaveChanges();
                }

                MessageBox.Show("✅ Kitap başarıyla iade alındı!", "Başarılı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadData(); // Verileri yenile
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("✅ Veriler yenilendi!", "Bilgi", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstBorrowRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen kayıt için detay gösterebiliriz (opsiyonel)
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