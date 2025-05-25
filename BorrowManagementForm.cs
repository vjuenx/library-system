using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleWindowsForm.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleWindowsForm
{
    public partial class BorrowManagementForm : Form
    {
        private Label lblTitle;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClear;
        private Button btnClose;
        
        private ListBox lstAvailableBooks;
        private Label lblBookList;
        private Label lblBookCount;
        private Label lblSelectedBook;
        private TextBox txtSelectedBookInfo;
        
        private Database database;
        private Book? selectedBook;

        public BorrowManagementForm()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadAvailableBooks();
        }

        private void InitializeDatabase()
        {
            database = new Database();
        }

        private void InitializeComponent()
        {
            this.Text = "Ödünç Alma";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Başlık
            lblTitle = new Label();
            lblTitle.Text = "📖 ÖDÜNÇ ALMA SİSTEMİ";
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(350, 30);

            // Sol panel - Arama
            int leftX = 20;
            int startY = 70;

            lblSearch = new Label();
            lblSearch.Text = "🔍 Kitap Ara (Başlık, Yazar veya ISBN):";
            lblSearch.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblSearch.Location = new Point(leftX, startY);
            lblSearch.Size = new Size(300, 20);

            txtSearch = new TextBox();
            txtSearch.Location = new Point(leftX, startY + 25);
            txtSearch.Size = new Size(300, 25);
            txtSearch.Font = new Font("Microsoft Sans Serif", 10F);
            txtSearch.KeyPress += txtSearch_KeyPress;

            btnSearch = new Button();
            btnSearch.Text = "🔍 Ara";
            btnSearch.Location = new Point(leftX, startY + 60);
            btnSearch.Size = new Size(80, 30);
            btnSearch.BackColor = Color.LightBlue;
            btnSearch.Click += btnSearch_Click;

            btnClear = new Button();
            btnClear.Text = "🧹 Temizle";
            btnClear.Location = new Point(leftX + 90, startY + 60);
            btnClear.Size = new Size(80, 30);
            btnClear.BackColor = Color.LightYellow;
            btnClear.Click += btnClear_Click;

            // Sağ panel - Kitap listesi
            int rightX = 350;

            lblBookList = new Label();
            lblBookList.Text = "📚 Müsait Kitaplar";
            lblBookList.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblBookList.Location = new Point(rightX, startY);
            lblBookList.Size = new Size(200, 25);

            lstAvailableBooks = new ListBox();
            lstAvailableBooks.Location = new Point(rightX, startY + 30);
            lstAvailableBooks.Size = new Size(400, 300);
            lstAvailableBooks.Font = new Font("Microsoft Sans Serif", 9F);
            lstAvailableBooks.SelectedIndexChanged += lstAvailableBooks_SelectedIndexChanged;

            lblBookCount = new Label();
            lblBookCount.Text = "Toplam: 0 müsait kitap";
            lblBookCount.Location = new Point(rightX, startY + 340);
            lblBookCount.Size = new Size(200, 20);
            lblBookCount.ForeColor = Color.DarkGreen;

            // Seçilen kitap bilgisi
            lblSelectedBook = new Label();
            lblSelectedBook.Text = "📋 Seçilen Kitap Detayı:";
            lblSelectedBook.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblSelectedBook.Location = new Point(leftX, startY + 120);
            lblSelectedBook.Size = new Size(200, 20);

            txtSelectedBookInfo = new TextBox();
            txtSelectedBookInfo.Location = new Point(leftX, startY + 145);
            txtSelectedBookInfo.Size = new Size(300, 120);
            txtSelectedBookInfo.Multiline = true;
            txtSelectedBookInfo.ReadOnly = true;
            txtSelectedBookInfo.ScrollBars = ScrollBars.Vertical;
            txtSelectedBookInfo.BackColor = Color.LightGray;

            // Kapat butonu
            btnClose = new Button();
            btnClose.Text = "🔙 Kapat";
            btnClose.Location = new Point(rightX + 300, startY + 370);
            btnClose.Size = new Size(100, 35);
            btnClose.BackColor = Color.LightGray;
            btnClose.Click += btnClose_Click;

            // Kontrolleri forma ekle
            this.Controls.AddRange(new Control[] {
                lblTitle, lblSearch, txtSearch, btnSearch, btnClear,
                lblBookList, lstAvailableBooks, lblBookCount,
                lblSelectedBook, txtSelectedBookInfo, btnClose
            });
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchBooks();
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchBooks();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSelectedBookInfo.Clear();
            selectedBook = null;
            LoadAvailableBooks();
        }

        private void lstAvailableBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvailableBooks.SelectedItem is Book book)
            {
                selectedBook = book;
                ShowBookDetails(book);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadAvailableBooks()
        {
            try
            {
                using (var context = database.GetDbContext())
                {
                    var availableBooks = context.Books
                        .Where(b => b.IsActive && b.AvailableCopies > 0)
                        .OrderBy(b => b.Title)
                        .ToList();

                    lstAvailableBooks.Items.Clear();
                    foreach (var book in availableBooks)
                    {
                        lstAvailableBooks.Items.Add(book);
                    }

                    lblBookCount.Text = $"Toplam: {availableBooks.Count} müsait kitap";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitaplar yüklenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBooks()
        {
            string searchTerm = txtSearch.Text.Trim();
            
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadAvailableBooks();
                return;
            }

            try
            {
                using (var context = database.GetDbContext())
                {
                    var searchResults = context.Books
                        .Where(b => b.IsActive && 
                                   (b.Title.Contains(searchTerm) || 
                                    b.Author.Contains(searchTerm) || 
                                    b.ISBN.Contains(searchTerm)))
                        .OrderBy(b => b.AvailableCopies > 0 ? 0 : 1) // Müsait olanlar önce
                        .ThenBy(b => b.Title)
                        .ToList();

                    lstAvailableBooks.Items.Clear();
                    foreach (var book in searchResults)
                    {
                        lstAvailableBooks.Items.Add(book);
                    }

                    int availableCount = searchResults.Count(b => b.AvailableCopies > 0);
                    lblBookCount.Text = $"Arama: {searchResults.Count} sonuç ({availableCount} müsait)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Arama sırasında hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowBookDetails(Book book)
        {
            string status = book.AvailableCopies > 0 ? "✅ MÜSAİT" : "❌ TÜKENDİ";
            string statusColor = book.AvailableCopies > 0 ? "Yeşil" : "Kırmızı";

            txtSelectedBookInfo.Text = $@"📚 KITAP BİLGİLERİ

📖 Başlık: {book.Title}
✍️ Yazar: {book.Author}
🏷️ ISBN: {book.ISBN}
🏢 Yayınevi: {book.Publisher}
📅 Yayın Yılı: {book.PublicationYear}
📂 Kategori: {book.Category}
📍 Raf Konumu: {book.ShelfLocation}

📊 DURUM BİLGİSİ
{status}
📦 Toplam Kopya: {book.TotalCopies}
✅ Müsait Kopya: {book.AvailableCopies}
📤 Ödünç Verilen: {book.BorrowedCopies}

📝 Açıklama: {book.Description}";

            // Durum rengini ayarla
            txtSelectedBookInfo.ForeColor = book.AvailableCopies > 0 ? Color.DarkGreen : Color.DarkRed;
        }
    }
} 