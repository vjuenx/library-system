using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleWindowsForm.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleWindowsForm
{
    public partial class BookManagementForm : Form
    {
        private Label lblTitle;
        private Label lblBookTitle;
        private Label lblAuthor;
        private Label lblISBN;
        private Label lblPublisher;
        private Label lblYear;
        private Label lblCategory;
        private Label lblShelfLocation;
        private Label lblTotalCopies;
        private Label lblAvailableCopies;
        private Label lblDescription;
        
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtISBN;
        private TextBox txtPublisher;
        private NumericUpDown nudYear;
        private ComboBox cmbCategory;
        private TextBox txtShelfLocation;
        private NumericUpDown nudTotalCopies;
        private NumericUpDown nudAvailableCopies;
        private TextBox txtDescription;
        private CheckBox chkIsActive;
        
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnClose;
        
        private ListBox lstBooks;
        private Label lblBookCount;
        
        private Database database;
        private Book? selectedBook;

        public BookManagementForm()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadCategories();
            LoadBooks();
            
            // Tema değişikliği event'ini dinle
            ThemeManager.ThemeChanged += OnThemeChanged;
            // İlk tema uygulaması
            ThemeManager.ApplyTheme(this);
        }

        private void InitializeDatabase()
        {
            database = new Database();
        }

        private void InitializeComponent()
        {
            this.Text = "Kitap Yönetimi";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Başlık
            lblTitle = new Label();
            lblTitle.Text = "📚 KİTAP YÖNETİMİ";
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(300, 30);

            // Sol panel - Form alanları
            int leftX = 20;
            int startY = 70;
            int labelWidth = 120;
            int textWidth = 200;
            int rowHeight = 35;

            // Kitap Adı
            lblBookTitle = new Label();
            lblBookTitle.Text = "Kitap Adı:";
            lblBookTitle.Location = new Point(leftX, startY);
            lblBookTitle.Size = new Size(labelWidth, 20);

            txtTitle = new TextBox();
            txtTitle.Location = new Point(leftX + labelWidth, startY);
            txtTitle.Size = new Size(textWidth, 20);

            // Yazar
            lblAuthor = new Label();
            lblAuthor.Text = "Yazar:";
            lblAuthor.Location = new Point(leftX, startY + rowHeight);
            lblAuthor.Size = new Size(labelWidth, 20);

            txtAuthor = new TextBox();
            txtAuthor.Location = new Point(leftX + labelWidth, startY + rowHeight);
            txtAuthor.Size = new Size(textWidth, 20);

            // ISBN
            lblISBN = new Label();
            lblISBN.Text = "ISBN:";
            lblISBN.Location = new Point(leftX, startY + rowHeight * 2);
            lblISBN.Size = new Size(labelWidth, 20);

            txtISBN = new TextBox();
            txtISBN.Location = new Point(leftX + labelWidth, startY + rowHeight * 2);
            txtISBN.Size = new Size(textWidth, 20);

            // Yayınevi
            lblPublisher = new Label();
            lblPublisher.Text = "Yayınevi:";
            lblPublisher.Location = new Point(leftX, startY + rowHeight * 3);
            lblPublisher.Size = new Size(labelWidth, 20);

            txtPublisher = new TextBox();
            txtPublisher.Location = new Point(leftX + labelWidth, startY + rowHeight * 3);
            txtPublisher.Size = new Size(textWidth, 20);

            // Yayın Yılı
            lblYear = new Label();
            lblYear.Text = "Yayın Yılı:";
            lblYear.Location = new Point(leftX, startY + rowHeight * 4);
            lblYear.Size = new Size(labelWidth, 20);

            nudYear = new NumericUpDown();
            nudYear.Location = new Point(leftX + labelWidth, startY + rowHeight * 4);
            nudYear.Size = new Size(100, 20);
            nudYear.Minimum = 1900;
            nudYear.Maximum = DateTime.Now.Year + 5;
            nudYear.Value = DateTime.Now.Year;

            // Kategori
            lblCategory = new Label();
            lblCategory.Text = "Kategori:";
            lblCategory.Location = new Point(leftX, startY + rowHeight * 5);
            lblCategory.Size = new Size(labelWidth, 20);

            cmbCategory = new ComboBox();
            cmbCategory.Location = new Point(leftX + labelWidth, startY + rowHeight * 5);
            cmbCategory.Size = new Size(textWidth, 20);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            // Raf Konumu
            lblShelfLocation = new Label();
            lblShelfLocation.Text = "Raf Konumu:";
            lblShelfLocation.Location = new Point(leftX, startY + rowHeight * 6);
            lblShelfLocation.Size = new Size(labelWidth, 20);

            txtShelfLocation = new TextBox();
            txtShelfLocation.Location = new Point(leftX + labelWidth, startY + rowHeight * 6);
            txtShelfLocation.Size = new Size(100, 20);
            txtShelfLocation.PlaceholderText = "Örn: A1, B2, C3";

            // Toplam Kopya
            lblTotalCopies = new Label();
            lblTotalCopies.Text = "Toplam Kopya:";
            lblTotalCopies.Location = new Point(leftX, startY + rowHeight * 7);
            lblTotalCopies.Size = new Size(labelWidth, 20);

            nudTotalCopies = new NumericUpDown();
            nudTotalCopies.Location = new Point(leftX + labelWidth, startY + rowHeight * 7);
            nudTotalCopies.Size = new Size(80, 20);
            nudTotalCopies.Minimum = 1;
            nudTotalCopies.Maximum = 100;
            nudTotalCopies.Value = 1;
            nudTotalCopies.ValueChanged += nudTotalCopies_ValueChanged;

            // Mevcut Kopya
            lblAvailableCopies = new Label();
            lblAvailableCopies.Text = "Mevcut Kopya:";
            lblAvailableCopies.Location = new Point(leftX, startY + rowHeight * 8);
            lblAvailableCopies.Size = new Size(labelWidth, 20);

            nudAvailableCopies = new NumericUpDown();
            nudAvailableCopies.Location = new Point(leftX + labelWidth, startY + rowHeight * 8);
            nudAvailableCopies.Size = new Size(80, 20);
            nudAvailableCopies.Minimum = 0;
            nudAvailableCopies.Maximum = 100;
            nudAvailableCopies.Value = 1;

            // Açıklama
            lblDescription = new Label();
            lblDescription.Text = "Açıklama:";
            lblDescription.Location = new Point(leftX, startY + rowHeight * 9);
            lblDescription.Size = new Size(labelWidth, 20);

            txtDescription = new TextBox();
            txtDescription.Location = new Point(leftX + labelWidth, startY + rowHeight * 9);
            txtDescription.Size = new Size(textWidth, 60);
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;

            // Aktif mi?
            chkIsActive = new CheckBox();
            chkIsActive.Text = "Aktif";
            chkIsActive.Location = new Point(leftX + labelWidth, startY + rowHeight * 11);
            chkIsActive.Size = new Size(100, 20);
            chkIsActive.Checked = true;

            // Butonlar
            int buttonY = startY + rowHeight * 12;
            int buttonWidth = 80;
            int buttonSpacing = 90;

            btnAdd = new Button();
            btnAdd.Text = "➕ Ekle";
            btnAdd.Location = new Point(leftX, buttonY);
            btnAdd.Size = new Size(buttonWidth, 30);
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.Click += btnAdd_Click;

            btnUpdate = new Button();
            btnUpdate.Text = "✏️ Güncelle";
            btnUpdate.Location = new Point(leftX + buttonSpacing, buttonY);
            btnUpdate.Size = new Size(buttonWidth, 30);
            btnUpdate.BackColor = Color.LightBlue;
            btnUpdate.Click += btnUpdate_Click;

            btnDelete = new Button();
            btnDelete.Text = "🗑️ Sil";
            btnDelete.Location = new Point(leftX + buttonSpacing * 2, buttonY);
            btnDelete.Size = new Size(buttonWidth, 30);
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.Click += btnDelete_Click;

            btnClear = new Button();
            btnClear.Text = "🧹 Temizle";
            btnClear.Location = new Point(leftX, buttonY + 40);
            btnClear.Size = new Size(buttonWidth, 30);
            btnClear.BackColor = Color.LightYellow;
            btnClear.Click += btnClear_Click;

            // Sağ panel - Kitap listesi
            int rightX = 400;

            Label lblBookList = new Label();
            lblBookList.Text = "📖 Kitap Listesi";
            lblBookList.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblBookList.Location = new Point(rightX, startY);
            lblBookList.Size = new Size(200, 25);

            lstBooks = new ListBox();
            lstBooks.Location = new Point(rightX, startY + 30);
            lstBooks.Size = new Size(450, 400);
            lstBooks.SelectedIndexChanged += lstBooks_SelectedIndexChanged;

            lblBookCount = new Label();
            lblBookCount.Text = "Toplam: 0 kitap";
            lblBookCount.Location = new Point(rightX, startY + 440);
            lblBookCount.Size = new Size(200, 20);
            lblBookCount.ForeColor = Color.DarkGreen;

            btnClose = new Button();
            btnClose.Text = "🔙 Kapat";
            btnClose.Location = new Point(rightX + 350, startY + 470);
            btnClose.Size = new Size(100, 35);
            btnClose.BackColor = Color.LightGray;
            btnClose.Click += btnClose_Click;

            // Kontrolleri forma ekle
            this.Controls.AddRange(new Control[] {
                lblTitle, lblBookTitle, lblAuthor, lblISBN, lblPublisher, lblYear,
                lblCategory, lblShelfLocation, lblTotalCopies, lblAvailableCopies, lblDescription,
                txtTitle, txtAuthor, txtISBN, txtPublisher, nudYear, cmbCategory,
                txtShelfLocation, nudTotalCopies, nudAvailableCopies, txtDescription, chkIsActive,
                btnAdd, btnUpdate, btnDelete, btnClear, btnClose,
                lblBookList, lstBooks, lblBookCount
            });
        }

        private void nudTotalCopies_ValueChanged(object sender, EventArgs e)
        {
            // Mevcut kopya sayısı toplam kopyadan fazla olamaz
            if (nudAvailableCopies.Value > nudTotalCopies.Value)
            {
                nudAvailableCopies.Value = nudTotalCopies.Value;
            }
            nudAvailableCopies.Maximum = nudTotalCopies.Value;
        }

        private void LoadBooks()
        {
            try
            {
                using (var context = database.GetDbContext())
                {
                    var books = context.Books
                        .Include(b => b.Category)
                        .Where(b => b.IsActive)
                        .OrderBy(b => b.Title)
                        .ToList();

                    lstBooks.Items.Clear();
                    foreach (var book in books)
                    {
                        lstBooks.Items.Add(book);
                    }

                    lblBookCount.Text = $"Toplam: {books.Count} kitap";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitaplar yüklenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    using (var context = database.GetDbContext())
                    {
                        // CategoryId'yi al
                        int? categoryId = null;
                        if (cmbCategory.SelectedIndex > 0) // "-- Kategori Seçin --" seçili değilse
                        {
                            string selectedText = cmbCategory.SelectedItem.ToString();
                            categoryId = int.Parse(selectedText.Split('-')[0].Trim());
                        }

                        var book = new Book
                        {
                            Title = txtTitle.Text.Trim(),
                            Author = txtAuthor.Text.Trim(),
                            ISBN = txtISBN.Text.Trim(),
                            Publisher = txtPublisher.Text.Trim(),
                            PublicationYear = (int)nudYear.Value,
                            CategoryId = categoryId,
                            ShelfLocation = txtShelfLocation.Text.Trim().ToUpper(),
                            TotalCopies = (int)nudTotalCopies.Value,
                            AvailableCopies = (int)nudAvailableCopies.Value,
                            Description = txtDescription.Text.Trim(),
                            IsActive = chkIsActive.Checked,
                            CreatedDate = DateTime.Now
                        };

                        context.Books.Add(book);
                        context.SaveChanges();

                        MessageBox.Show("Kitap başarıyla eklendi!", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        ClearForm();
                        LoadBooks();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitap eklenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBook == null)
                {
                    MessageBox.Show("Lütfen güncellenecek kitabı seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ValidateInput())
                {
                    using (var context = database.GetDbContext())
                    {
                        var book = context.Books.Find(selectedBook.Id);
                        if (book != null)
                        {
                            book.Title = txtTitle.Text.Trim();
                            book.Author = txtAuthor.Text.Trim();
                            book.ISBN = txtISBN.Text.Trim();
                            book.Publisher = txtPublisher.Text.Trim();
                            book.PublicationYear = (int)nudYear.Value;
                            book.CategoryId = cmbCategory.SelectedIndex > 0 ? int.Parse(cmbCategory.SelectedItem.ToString().Split('-')[0].Trim()) : null;
                            book.ShelfLocation = txtShelfLocation.Text.Trim().ToUpper();
                            book.TotalCopies = (int)nudTotalCopies.Value;
                            book.AvailableCopies = (int)nudAvailableCopies.Value;
                            book.Description = txtDescription.Text.Trim();
                            book.IsActive = chkIsActive.Checked;
                            book.UpdatedDate = DateTime.Now;

                            context.SaveChanges();

                            MessageBox.Show("Kitap başarıyla güncellendi!", "Başarılı", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            ClearForm();
                            LoadBooks();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitap güncellenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBook == null)
                {
                    MessageBox.Show("Lütfen silinecek kitabı seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"'{selectedBook.Title}' kitabını silmek istediğinizden emin misiniz?", 
                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var context = database.GetDbContext())
                    {
                        var book = context.Books.Find(selectedBook.Id);
                        if (book != null)
                        {
                            // Soft delete - IsActive = false
                            book.IsActive = false;
                            book.UpdatedDate = DateTime.Now;
                            context.SaveChanges();

                            MessageBox.Show("Kitap başarıyla silindi!", "Başarılı", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            ClearForm();
                            LoadBooks();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitap silinirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBooks.SelectedItem is Book book)
            {
                selectedBook = book;
                
                txtTitle.Text = book.Title;
                txtAuthor.Text = book.Author;
                txtISBN.Text = book.ISBN;
                txtPublisher.Text = book.Publisher;
                nudYear.Value = book.PublicationYear;
                
                // Kategori seçimi
                if (book.CategoryId.HasValue)
                {
                    for (int i = 1; i < cmbCategory.Items.Count; i++) // 0. index "-- Kategori Seçin --"
                    {
                        string item = cmbCategory.Items[i].ToString();
                        if (item.StartsWith($"{book.CategoryId} -"))
                        {
                            cmbCategory.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    cmbCategory.SelectedIndex = 0; // "-- Kategori Seçin --"
                }
                
                txtShelfLocation.Text = book.ShelfLocation;
                nudTotalCopies.Value = book.TotalCopies;
                nudAvailableCopies.Value = book.AvailableCopies;
                txtDescription.Text = book.Description;
                chkIsActive.Checked = book.IsActive;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Kitap adı boş olamaz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Yazar adı boş olamaz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("ISBN numarası boş olamaz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtISBN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtShelfLocation.Text))
            {
                MessageBox.Show("Raf konumu boş olamaz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtShelfLocation.Focus();
                return false;
            }

            if (nudAvailableCopies.Value > nudTotalCopies.Value)
            {
                MessageBox.Show("Mevcut kopya sayısı toplam kopyadan fazla olamaz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudAvailableCopies.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            selectedBook = null;
            txtTitle.Clear();
            txtAuthor.Clear();
            txtISBN.Clear();
            txtPublisher.Clear();
            nudYear.Value = DateTime.Now.Year;
            cmbCategory.SelectedIndex = -1;
            txtShelfLocation.Clear();
            nudTotalCopies.Value = 1;
            nudAvailableCopies.Value = 1;
            txtDescription.Clear();
            chkIsActive.Checked = true;
            lstBooks.SelectedIndex = -1;
        }

        private void LoadCategories()
        {
            try
            {
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("-- Kategori Seçin --");
                
                var categories = database.GetActiveCategories();
                foreach (var category in categories)
                {
                    cmbCategory.Items.Add($"{category.Id} - {category.Name}");
                }
                
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler yüklenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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