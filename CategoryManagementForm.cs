using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SimpleWindowsForm.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleWindowsForm
{
    public partial class CategoryManagementForm : Form
    {
        // UI Kontrolleri
        private Label lblTitle;
        private Label lblName;
        private Label lblDescription;
        
        private TextBox txtName;
        private TextBox txtDescription;
        private CheckBox chkIsActive;
        
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnClose;
        
        private ListBox lstCategories;
        private Label lblCategoryCount;
        
        private Database database;
        private Category? selectedCategory;

        public CategoryManagementForm()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadCategories();
        }

        private void InitializeDatabase()
        {
            database = new Database();
        }

        private void InitializeComponent()
        {
            this.Text = "Kategori Yönetimi";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Başlık
            lblTitle = new Label();
            lblTitle.Text = "📚 KATEGORİ YÖNETİMİ";
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

            // Kategori Adı
            lblName = new Label();
            lblName.Text = "Kategori Adı:";
            lblName.Location = new Point(leftX, startY);
            lblName.Size = new Size(labelWidth, 20);

            txtName = new TextBox();
            txtName.Location = new Point(leftX + labelWidth, startY);
            txtName.Size = new Size(textWidth, 20);

            // Açıklama
            lblDescription = new Label();
            lblDescription.Text = "Açıklama:";
            lblDescription.Location = new Point(leftX, startY + rowHeight);
            lblDescription.Size = new Size(labelWidth, 20);

            txtDescription = new TextBox();
            txtDescription.Location = new Point(leftX + labelWidth, startY + rowHeight);
            txtDescription.Size = new Size(textWidth, 60);
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;

            // Aktif mi?
            chkIsActive = new CheckBox();
            chkIsActive.Text = "Aktif";
            chkIsActive.Location = new Point(leftX + labelWidth, startY + rowHeight * 3);
            chkIsActive.Size = new Size(100, 20);
            chkIsActive.Checked = true;

            // Butonlar
            int buttonY = startY + rowHeight * 4;
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

            btnClose = new Button();
            btnClose.Text = "❌ Kapat";
            btnClose.Location = new Point(leftX + buttonSpacing, buttonY + 40);
            btnClose.Size = new Size(buttonWidth, 30);
            btnClose.BackColor = Color.LightGray;
            btnClose.Click += btnClose_Click;

            // Sağ panel - Kategori listesi
            int rightX = 400;
            
            Label lblCategoryList = new Label();
            lblCategoryList.Text = "📋 Kategori Listesi";
            lblCategoryList.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblCategoryList.Location = new Point(rightX, startY);
            lblCategoryList.Size = new Size(200, 25);

            lstCategories = new ListBox();
            lstCategories.Location = new Point(rightX, startY + 30);
            lstCategories.Size = new Size(350, 350);
            lstCategories.SelectedIndexChanged += lstCategories_SelectedIndexChanged;

            lblCategoryCount = new Label();
            lblCategoryCount.Text = "Toplam: 0 kategori";
            lblCategoryCount.Location = new Point(rightX, startY + 390);
            lblCategoryCount.Size = new Size(200, 20);
            lblCategoryCount.ForeColor = Color.DarkGreen;

            // Kontrolleri forma ekle
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblName);
            this.Controls.Add(lblDescription);
            this.Controls.Add(txtName);
            this.Controls.Add(txtDescription);
            this.Controls.Add(chkIsActive);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnClose);
            this.Controls.Add(lblCategoryList);
            this.Controls.Add(lstCategories);
            this.Controls.Add(lblCategoryCount);
        }

        private void LoadCategories()
        {
            try
            {
                using (var context = database.GetDbContext())
                {
                    var categories = context.Categories
                        .Where(c => c.IsActive)
                        .OrderBy(c => c.Name)
                        .ToList();

                    lstCategories.Items.Clear();
                    foreach (var category in categories)
                    {
                        lstCategories.Items.Add(category);
                    }

                    lblCategoryCount.Text = $"Toplam: {categories.Count} kategori";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler yüklenirken hata oluştu: {ex.Message}", 
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
                        var category = new Category
                        {
                            Name = txtName.Text.Trim(),
                            Description = txtDescription.Text.Trim(),
                            IsActive = chkIsActive.Checked,
                            CreatedDate = DateTime.Now
                        };

                        context.Categories.Add(category);
                        context.SaveChanges();

                        MessageBox.Show("Kategori başarıyla eklendi!", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        ClearForm();
                        LoadCategories();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategori eklenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCategory == null)
                {
                    MessageBox.Show("Lütfen güncellenecek kategoriyi seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ValidateInput())
                {
                    using (var context = database.GetDbContext())
                    {
                        var category = context.Categories.Find(selectedCategory.Id);
                        if (category != null)
                        {
                            category.Name = txtName.Text.Trim();
                            category.Description = txtDescription.Text.Trim();
                            category.IsActive = chkIsActive.Checked;

                            context.SaveChanges();

                            MessageBox.Show("Kategori başarıyla güncellendi!", "Başarılı", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            ClearForm();
                            LoadCategories();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategori güncellenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCategory == null)
                {
                    MessageBox.Show("Lütfen silinecek kategoriyi seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kategoriye bağlı kitap var mı kontrol et
                using (var context = database.GetDbContext())
                {
                    var bookCount = context.Books.Count(b => b.CategoryId == selectedCategory.Id && b.IsActive);
                    if (bookCount > 0)
                    {
                        MessageBox.Show($"Bu kategoriye bağlı {bookCount} kitap bulunmaktadır. Önce kitapları başka kategoriye taşıyın veya silin.", 
                            "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var result = MessageBox.Show($"'{selectedCategory.Name}' kategorisini silmek istediğinizden emin misiniz?", 
                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var context = database.GetDbContext())
                    {
                        var category = context.Categories.Find(selectedCategory.Id);
                        if (category != null)
                        {
                            // Soft delete - IsActive = false
                            category.IsActive = false;
                            context.SaveChanges();

                            MessageBox.Show("Kategori başarıyla silindi!", "Başarılı", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            ClearForm();
                            LoadCategories();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategori silinirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem is Category category)
            {
                selectedCategory = category;
                
                txtName.Text = category.Name;
                txtDescription.Text = category.Description ?? "";
                chkIsActive.Checked = category.IsActive;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Kategori adı boş olamaz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Kategori adı en az 2 karakter olmalıdır!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtDescription.Clear();
            chkIsActive.Checked = true;
            selectedCategory = null;
            lstCategories.SelectedIndex = -1;
        }
    }
} 