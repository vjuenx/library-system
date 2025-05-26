using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleWindowsForm
{
    public static class ThemeManager
    {
        public static bool IsDarkTheme { get; private set; } = false;
        
        // Tema değişikliği event'i
        public static event EventHandler? ThemeChanged;
        
        // Tema değiştirme metodu
        public static void SetTheme(bool isDark)
        {
            IsDarkTheme = isDark;
            ThemeChanged?.Invoke(null, EventArgs.Empty);
        }
        
        // Form'a tema uygulama metodu
        public static void ApplyTheme(Form form)
        {
            if (IsDarkTheme)
            {
                ApplyDarkTheme(form);
            }
            else
            {
                ApplyLightTheme(form);
            }
        }
        
        private static void ApplyDarkTheme(Form form)
        {
            // Form arka planı
            form.BackColor = Color.FromArgb(45, 45, 48);
            form.ForeColor = Color.White;
            
            // Tüm kontrolleri dolaş ve tema uygula
            ApplyDarkThemeToControls(form.Controls);
        }
        
        private static void ApplyLightTheme(Form form)
        {
            // Form arka planı
            form.BackColor = Color.WhiteSmoke;
            form.ForeColor = Color.Black;
            
            // Tüm kontrolleri dolaş ve tema uygula
            ApplyLightThemeToControls(form.Controls);
        }
        
        private static void ApplyDarkThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case Label label:
                        if (label.Name == "lblTitle")
                            label.ForeColor = Color.LightBlue;
                        else if (label.Name == "lblAppName")
                            label.ForeColor = Color.LightGreen;
                        else
                            label.ForeColor = Color.LightGray;
                        break;
                        
                    case Button button:
                        ApplyDarkButtonTheme(button);
                        break;
                        
                    case TextBox textBox:
                        textBox.BackColor = Color.FromArgb(60, 60, 60);
                        textBox.ForeColor = Color.White;
                        break;
                        
                    case ComboBox comboBox:
                        comboBox.BackColor = Color.FromArgb(60, 60, 60);
                        comboBox.ForeColor = Color.White;
                        break;
                        
                    case ListBox listBox:
                        listBox.BackColor = Color.FromArgb(60, 60, 60);
                        listBox.ForeColor = Color.White;
                        break;
                        
                    case GroupBox groupBox:
                        groupBox.ForeColor = Color.White;
                        break;
                        
                    case CheckBox checkBox:
                        checkBox.ForeColor = Color.White;
                        break;
                        
                    case RadioButton radioButton:
                        radioButton.ForeColor = Color.White;
                        break;
                        
                    case NumericUpDown numericUpDown:
                        numericUpDown.BackColor = Color.FromArgb(60, 60, 60);
                        numericUpDown.ForeColor = Color.White;
                        break;
                        
                    case DateTimePicker dateTimePicker:
                        dateTimePicker.BackColor = Color.FromArgb(60, 60, 60);
                        dateTimePicker.ForeColor = Color.White;
                        break;
                }
                
                // Alt kontrolleri de işle
                if (control.HasChildren)
                {
                    ApplyDarkThemeToControls(control.Controls);
                }
            }
        }
        
        private static void ApplyLightThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case Label label:
                        if (label.Name == "lblTitle")
                            label.ForeColor = Color.DarkBlue;
                        else if (label.Name == "lblAppName")
                            label.ForeColor = Color.DarkGreen;
                        else
                            label.ForeColor = Color.Black;
                        break;
                        
                    case Button button:
                        ApplyLightButtonTheme(button);
                        break;
                        
                    case TextBox textBox:
                        textBox.BackColor = Color.White;
                        textBox.ForeColor = Color.Black;
                        break;
                        
                    case ComboBox comboBox:
                        comboBox.BackColor = Color.White;
                        comboBox.ForeColor = Color.Black;
                        break;
                        
                    case ListBox listBox:
                        listBox.BackColor = Color.White;
                        listBox.ForeColor = Color.Black;
                        break;
                        
                    case GroupBox groupBox:
                        groupBox.ForeColor = Color.Black;
                        break;
                        
                    case CheckBox checkBox:
                        checkBox.ForeColor = Color.Black;
                        break;
                        
                    case RadioButton radioButton:
                        radioButton.ForeColor = Color.Black;
                        break;
                        
                    case NumericUpDown numericUpDown:
                        numericUpDown.BackColor = Color.White;
                        numericUpDown.ForeColor = Color.Black;
                        break;
                        
                    case DateTimePicker dateTimePicker:
                        dateTimePicker.BackColor = Color.White;
                        dateTimePicker.ForeColor = Color.Black;
                        break;
                }
                
                // Alt kontrolleri de işle
                if (control.HasChildren)
                {
                    ApplyLightThemeToControls(control.Controls);
                }
            }
        }
        
        private static void ApplyDarkButtonTheme(Button button)
        {
            // Ana menü butonları için özel renkler
            if (button.Text.Contains("Görevli Yönetimi"))
            {
                button.BackColor = Color.FromArgb(0, 100, 150); // Koyu mavi
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("Öğrenci Yönetimi"))
            {
                button.BackColor = Color.FromArgb(0, 120, 70); // Koyu yeşil
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("Kitap Yönetimi"))
            {
                button.BackColor = Color.FromArgb(180, 140, 0); // Koyu sarı
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("Ödünç"))
            {
                button.BackColor = Color.FromArgb(150, 50, 50); // Koyu kırmızı
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("Rezervasyon"))
            {
                button.BackColor = Color.FromArgb(139, 69, 19); // Koyu kahverengi
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("Kategori"))
            {
                button.BackColor = Color.FromArgb(120, 60, 120); // Koyu mor
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("Ayarlar"))
            {
                button.BackColor = Color.FromArgb(80, 80, 80); // Koyu gri
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("Yenile") || button.Text.Contains("🔄"))
            {
                button.BackColor = Color.FromArgb(255, 165, 0); // Koyu turuncu
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("Kapat") || button.Text.Contains("🔙"))
            {
                button.BackColor = Color.FromArgb(105, 105, 105); // Koyu gri
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("Rezerve Et") || button.Text.Contains("📅"))
            {
                button.BackColor = Color.FromArgb(0, 100, 200); // Koyu mavi
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("Tamamla") || button.Text.Contains("✅"))
            {
                button.BackColor = Color.FromArgb(0, 150, 0); // Koyu yeşil
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("İptal Et") || button.Text.Contains("❌"))
            {
                button.BackColor = Color.FromArgb(200, 0, 0); // Koyu kırmızı
                button.ForeColor = Color.White;
            }
            // CRUD butonları için renkler
            else if (button.BackColor == Color.LightGreen || button.Name.Contains("Add") || button.Text.Contains("Ekle"))
            {
                button.BackColor = Color.FromArgb(0, 120, 70);
                button.ForeColor = Color.White;
            }
            else if (button.BackColor == Color.LightBlue || button.Name.Contains("Update") || button.Text.Contains("Güncelle"))
            {
                button.BackColor = Color.FromArgb(0, 122, 204);
                button.ForeColor = Color.White;
            }
            else if (button.BackColor == Color.LightCoral || button.Name.Contains("Delete") || button.Text.Contains("Sil"))
            {
                button.BackColor = Color.FromArgb(196, 43, 28);
                button.ForeColor = Color.White;
            }
            else if (button.BackColor == Color.LightYellow || button.Name.Contains("Clear") || button.Text.Contains("Temizle"))
            {
                button.BackColor = Color.FromArgb(255, 193, 7);
                button.ForeColor = Color.Black;
            }
            else if (button.BackColor == Color.IndianRed || button.Text.Contains("Çıkış") || button.Text.Contains("Kapat"))
            {
                button.BackColor = Color.FromArgb(196, 43, 28);
                button.ForeColor = Color.White;
            }
            else
            {
                button.BackColor = Color.FromArgb(70, 70, 70);
                button.ForeColor = Color.White;
            }
        }
        
        private static void ApplyLightButtonTheme(Button button)
        {
            // Ana menü butonları için orijinal renkler
            if (button.Text.Contains("Görevli Yönetimi"))
            {
                button.BackColor = Color.LightBlue;
                button.ForeColor = Color.Black;
            }
            else if (button.Text.Contains("Öğrenci Yönetimi"))
            {
                button.BackColor = Color.LightGreen;
                button.ForeColor = Color.Black;
            }
            else if (button.Text.Contains("Kitap Yönetimi"))
            {
                button.BackColor = Color.LightYellow;
                button.ForeColor = Color.Black;
            }
            else if (button.Text.Contains("Ödünç"))
            {
                button.BackColor = Color.LightCoral;
                button.ForeColor = Color.Black;
            }
            else if (button.Text.Contains("Rezervasyon"))
            {
                button.BackColor = Color.SandyBrown; // Açık kahverengi
                button.ForeColor = Color.Black;
            }
            else if (button.Text.Contains("Ayarlar"))
            {
                button.BackColor = Color.LightGray;
                button.ForeColor = Color.Black;
            }
            else if (button.Text.Contains("Kategori"))
            {
                button.BackColor = Color.Plum; // Açık mor
                button.ForeColor = Color.Black;
            }
            else if (button.Text.Contains("Yenile") || button.Text.Contains("🔄"))
            {
                button.BackColor = Color.Orange; // Açık turuncu
                button.ForeColor = Color.Black;
            }
            else if (button.Text.Contains("Kapat") || button.Text.Contains("🔙"))
            {
                button.BackColor = Color.LightGray; // Açık gri
                button.ForeColor = Color.Black;
            }
            else if (button.Text.Contains("Rezerve Et") || button.Text.Contains("📅"))
            {
                button.BackColor = Color.CornflowerBlue; // Açık mavi
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("Tamamla") || button.Text.Contains("✅"))
            {
                button.BackColor = Color.MediumSeaGreen; // Açık yeşil
                button.ForeColor = Color.White;
            }
            else if (button.Text.Contains("İptal Et") || button.Text.Contains("❌"))
            {
                button.BackColor = Color.IndianRed; // Açık kırmızı
                button.ForeColor = Color.White;
            }
            // CRUD butonları için renkler
            else if (button.Name.Contains("Add") || button.Text.Contains("Ekle"))
            {
                button.BackColor = Color.LightGreen;
                button.ForeColor = Color.Black;
            }
            else if (button.Name.Contains("Update") || button.Text.Contains("Güncelle"))
            {
                button.BackColor = Color.LightBlue;
                button.ForeColor = Color.Black;
            }
            else if (button.Name.Contains("Delete") || button.Text.Contains("Sil"))
            {
                button.BackColor = Color.LightCoral;
                button.ForeColor = Color.Black;
            }
            else if (button.Name.Contains("Clear") || button.Text.Contains("Temizle"))
            {
                button.BackColor = Color.LightYellow;
                button.ForeColor = Color.Black;
            }
            else if (button.Text.Contains("Çıkış") || button.Text.Contains("Kapat"))
            {
                button.BackColor = Color.IndianRed;
                button.ForeColor = Color.White;
            }
            else
            {
                button.BackColor = Color.LightGray;
                button.ForeColor = Color.Black;
            }
        }
    }
} 