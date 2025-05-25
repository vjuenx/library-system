using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SimpleWindowsForm.Models;

namespace SimpleWindowsForm
{
    public partial class ReservationManagementForm : Form
    {
        private Label lblTitle;
        private Label lblStudentSelect;
        private Label lblBookSelect;
        private Label lblReservationDate;
        private Label lblExpiryDate;
        private Label lblNotes;
        
        private ComboBox cmbStudents;
        private ComboBox cmbBooks;
        private DateTimePicker dtpReservationDate;
        private DateTimePicker dtpExpiryDate;
        private TextBox txtNotes;
        
        private Button btnCreateReservation;
        private Button btnFulfillReservation;
        private Button btnCancelReservation;
        private Button btnRefresh;
        private Button btnClose;
        
        private ListBox lstReservations;
        private Label lblReservationCount;
        private Label lblActiveCount;
        private Label lblExpiredCount;
        
        private Database database;
        private User currentUser;

        public ReservationManagementForm(User user, Database db)
        {
            currentUser = user;
            database = db;
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblStudentSelect = new Label();
            this.lblBookSelect = new Label();
            this.lblReservationDate = new Label();
            this.lblExpiryDate = new Label();
            this.lblNotes = new Label();
            this.cmbStudents = new ComboBox();
            this.cmbBooks = new ComboBox();
            this.dtpReservationDate = new DateTimePicker();
            this.dtpExpiryDate = new DateTimePicker();
            this.txtNotes = new TextBox();
            this.btnCreateReservation = new Button();
            this.btnFulfillReservation = new Button();
            this.btnCancelReservation = new Button();
            this.btnRefresh = new Button();
            this.btnClose = new Button();
            this.lstReservations = new ListBox();
            this.lblReservationCount = new Label();
            this.lblActiveCount = new Label();
            this.lblExpiredCount = new Label();
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
            this.lblTitle.Text = "📅 Rezervasyon Yönetimi";

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
            // lblReservationDate
            // 
            this.lblReservationDate.AutoSize = true;
            this.lblReservationDate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblReservationDate.Location = new Point(20, 110);
            this.lblReservationDate.Name = "lblReservationDate";
            this.lblReservationDate.Size = new Size(75, 15);
            this.lblReservationDate.Text = "Rezervasyon:";

            // 
            // dtpReservationDate
            // 
            this.dtpReservationDate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.dtpReservationDate.Location = new Point(100, 107);
            this.dtpReservationDate.Name = "dtpReservationDate";
            this.dtpReservationDate.Size = new Size(200, 21);
            this.dtpReservationDate.TabIndex = 2;
            this.dtpReservationDate.Value = DateTime.Now;

            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblExpiryDate.Location = new Point(320, 110);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new Size(75, 15);
            this.lblExpiryDate.Text = "Son Tarih:";

            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.dtpExpiryDate.Location = new Point(400, 107);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new Size(200, 21);
            this.dtpExpiryDate.TabIndex = 3;
            this.dtpExpiryDate.Value = DateTime.Now.AddDays(7); // 1 hafta sonra

            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblNotes.Location = new Point(20, 150);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new Size(40, 15);
            this.lblNotes.Text = "Notlar:";

            // 
            // txtNotes
            // 
            this.txtNotes.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtNotes.Location = new Point(100, 147);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new Size(500, 21);
            this.txtNotes.TabIndex = 4;
            this.txtNotes.PlaceholderText = "Opsiyonel notlar...";

            // 
            // btnCreateReservation
            // 
            this.btnCreateReservation.BackColor = Color.LightGreen;
            this.btnCreateReservation.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCreateReservation.Location = new Point(20, 190);
            this.btnCreateReservation.Name = "btnCreateReservation";
            this.btnCreateReservation.Size = new Size(120, 30);
            this.btnCreateReservation.TabIndex = 5;
            this.btnCreateReservation.Text = "📅 Rezerve Et";
            this.btnCreateReservation.UseVisualStyleBackColor = false;
            this.btnCreateReservation.Click += new EventHandler(this.btnCreateReservation_Click);

            // 
            // btnFulfillReservation
            // 
            this.btnFulfillReservation.BackColor = Color.LightBlue;
            this.btnFulfillReservation.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnFulfillReservation.Location = new Point(150, 190);
            this.btnFulfillReservation.Name = "btnFulfillReservation";
            this.btnFulfillReservation.Size = new Size(120, 30);
            this.btnFulfillReservation.TabIndex = 6;
            this.btnFulfillReservation.Text = "✅ Tamamla";
            this.btnFulfillReservation.UseVisualStyleBackColor = false;
            this.btnFulfillReservation.Click += new EventHandler(this.btnFulfillReservation_Click);

            // 
            // btnCancelReservation
            // 
            this.btnCancelReservation.BackColor = Color.LightCoral;
            this.btnCancelReservation.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCancelReservation.Location = new Point(280, 190);
            this.btnCancelReservation.Name = "btnCancelReservation";
            this.btnCancelReservation.Size = new Size(120, 30);
            this.btnCancelReservation.TabIndex = 7;
            this.btnCancelReservation.Text = "❌ İptal Et";
            this.btnCancelReservation.UseVisualStyleBackColor = false;
            this.btnCancelReservation.Click += new EventHandler(this.btnCancelReservation_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = Color.LightYellow;
            this.btnRefresh.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnRefresh.Location = new Point(410, 190);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(100, 30);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "🔄 Yenile";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // 
            // btnClose
            // 
            this.btnClose.BackColor = Color.LightGray;
            this.btnClose.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnClose.Location = new Point(520, 190);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(100, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "🔙 Kapat";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // 
            // lstReservations
            // 
            this.lstReservations.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lstReservations.FormattingEnabled = true;
            this.lstReservations.ItemHeight = 15;
            this.lstReservations.Location = new Point(20, 240);
            this.lstReservations.Name = "lstReservations";
            this.lstReservations.Size = new Size(600, 200);
            this.lstReservations.TabIndex = 10;
            this.lstReservations.SelectedIndexChanged += new EventHandler(this.lstReservations_SelectedIndexChanged);

            // 
            // lblReservationCount
            // 
            this.lblReservationCount.AutoSize = true;
            this.lblReservationCount.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblReservationCount.Location = new Point(20, 450);
            this.lblReservationCount.Name = "lblReservationCount";
            this.lblReservationCount.Size = new Size(100, 15);
            this.lblReservationCount.Text = "Toplam: 0 rezervasyon";

            // 
            // lblActiveCount
            // 
            this.lblActiveCount.AutoSize = true;
            this.lblActiveCount.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblActiveCount.ForeColor = Color.Green;
            this.lblActiveCount.Location = new Point(200, 450);
            this.lblActiveCount.Name = "lblActiveCount";
            this.lblActiveCount.Size = new Size(80, 15);
            this.lblActiveCount.Text = "Aktif: 0";

            // 
            // lblExpiredCount
            // 
            this.lblExpiredCount.AutoSize = true;
            this.lblExpiredCount.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblExpiredCount.ForeColor = Color.Red;
            this.lblExpiredCount.Location = new Point(320, 450);
            this.lblExpiredCount.Name = "lblExpiredCount";
            this.lblExpiredCount.Size = new Size(80, 15);
            this.lblExpiredCount.Text = "Süresi Dolmuş: 0";

            // 
            // ReservationManagementForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(650, 490);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStudentSelect);
            this.Controls.Add(this.cmbStudents);
            this.Controls.Add(this.lblBookSelect);
            this.Controls.Add(this.cmbBooks);
            this.Controls.Add(this.lblReservationDate);
            this.Controls.Add(this.dtpReservationDate);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnCreateReservation);
            this.Controls.Add(this.btnFulfillReservation);
            this.Controls.Add(this.btnCancelReservation);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstReservations);
            this.Controls.Add(this.lblReservationCount);
            this.Controls.Add(this.lblActiveCount);
            this.Controls.Add(this.lblExpiredCount);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReservationManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Rezervasyon Yönetimi - Kütüphane Sistemi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LoadData()
        {
            LoadStudents();
            LoadBooks();
            LoadReservations();
            UpdateCounts();
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
                        .Where(b => b.IsActive)
                        .OrderBy(b => b.Title)
                        .ToList();
                    
                    cmbBooks.Items.Clear();
                    cmbBooks.Items.Add("-- Kitap Seçin --");
                    
                    foreach (var book in books)
                    {
                        cmbBooks.Items.Add($"{book.Id} - {book.Title} (Mevcut: {book.AvailableCopies})");
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

        private void LoadReservations()
        {
            try
            {
                using (var context = database.GetDbContext())
                {
                    var reservations = context.Reservations
                        .Include(r => r.Student)
                        .Include(r => r.Book)
                        .Include(r => r.CreatedByUser)
                        .OrderByDescending(r => r.ReservationDate)
                        .ToList();
                    
                    lstReservations.Items.Clear();
                    
                    foreach (var reservation in reservations)
                    {
                        string status = GetReservationStatus(reservation);
                        string expiryInfo = reservation.ExpiryDate.ToString("dd.MM.yyyy");
                        
                        lstReservations.Items.Add(
                            $"{reservation.Id} - {reservation.Student?.Name} | {reservation.Book?.Title} | " +
                            $"{reservation.ReservationDate.ToString("dd.MM.yyyy")} | Son: {expiryInfo} | {status}"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rezervasyon listesi yüklenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetReservationStatus(Reservation reservation)
        {
            if (reservation.IsFulfilled)
                return "✅ Tamamlandı";
            else if (!reservation.IsActive)
                return "❌ İptal Edildi";
            else if (reservation.ExpiryDate < DateTime.Now)
                return "⏰ Süresi Doldu";
            else
                return "📅 Aktif";
        }

        private void UpdateCounts()
        {
            try
            {
                int total = database.GetReservationCount();
                int active = database.GetActiveReservationCount();
                int expired = database.GetExpiredReservationCount();
                
                lblReservationCount.Text = $"Toplam: {total} rezervasyon";
                lblActiveCount.Text = $"Aktif: {active}";
                lblExpiredCount.Text = $"Süresi Dolmuş: {expired}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sayaçlar güncellenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
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
                    // Aynı öğrenci için aynı kitap rezervasyonu var mı kontrol et
                    var existingReservation = context.Reservations
                        .FirstOrDefault(r => r.StudentId == studentId && r.BookId == bookId && 
                                           r.IsActive && !r.IsFulfilled);
                    
                    if (existingReservation != null)
                    {
                        MessageBox.Show("Bu öğrenci için bu kitap zaten rezerve edilmiş!", "Uyarı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Yeni rezervasyon oluştur
                    var reservation = new Reservation
                    {
                        StudentId = studentId,
                        BookId = bookId,
                        ReservationDate = dtpReservationDate.Value,
                        ExpiryDate = dtpExpiryDate.Value,
                        IsActive = true,
                        IsFulfilled = false,
                        CreatedBy = currentUser.Id,
                        CreatedDate = DateTime.Now,
                        Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text
                    };

                    context.Reservations.Add(reservation);
                    context.SaveChanges();
                }

                MessageBox.Show("✅ Rezervasyon başarıyla oluşturuldu!", "Başarılı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Formu temizle
                cmbStudents.SelectedIndex = 0;
                cmbBooks.SelectedIndex = 0;
                txtNotes.Clear();
                dtpReservationDate.Value = DateTime.Now;
                dtpExpiryDate.Value = DateTime.Now.AddDays(7);
                
                LoadData(); // Verileri yenile
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFulfillReservation_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstReservations.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen tamamlanacak rezervasyonu seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int reservationId = int.Parse(lstReservations.SelectedItem.ToString().Split('-')[0].Trim());

                using (var context = database.GetDbContext())
                {
                    var reservation = context.Reservations.Find(reservationId);
                    
                    if (reservation == null)
                    {
                        MessageBox.Show("Rezervasyon bulunamadı!", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (reservation.IsFulfilled)
                    {
                        MessageBox.Show("Bu rezervasyon zaten tamamlanmış!", "Uyarı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!reservation.IsActive)
                    {
                        MessageBox.Show("Bu rezervasyon iptal edilmiş!", "Uyarı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Rezervasyonu tamamla
                    reservation.IsFulfilled = true;
                    reservation.FulfilledDate = DateTime.Now;
                    
                    context.SaveChanges();
                }

                MessageBox.Show("✅ Rezervasyon başarıyla tamamlandı!", "Başarılı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadData(); // Verileri yenile
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstReservations.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen iptal edilecek rezervasyonu seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int reservationId = int.Parse(lstReservations.SelectedItem.ToString().Split('-')[0].Trim());

                using (var context = database.GetDbContext())
                {
                    var reservation = context.Reservations.Find(reservationId);
                    
                    if (reservation == null)
                    {
                        MessageBox.Show("Rezervasyon bulunamadı!", "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (reservation.IsFulfilled)
                    {
                        MessageBox.Show("Tamamlanmış rezervasyon iptal edilemez!", "Uyarı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!reservation.IsActive)
                    {
                        MessageBox.Show("Bu rezervasyon zaten iptal edilmiş!", "Uyarı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Rezervasyonu iptal et
                    reservation.IsActive = false;
                    
                    context.SaveChanges();
                }

                MessageBox.Show("✅ Rezervasyon başarıyla iptal edildi!", "Başarılı", 
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

        private void lstReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen rezervasyon için detay gösterebiliriz (opsiyonel)
        }
    }
} 