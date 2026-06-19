using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Validator
{
    public partial class Form1 : Form
    {
        private const string ApiAddress = "http://localhost:4444/TransferSimulator/mobilePhone";
        private const string TestCasePath = @"C:\Users\pupochek128\Desktop\готовая демка\6\ТестКейс.docx";

        public Form1()
        {
            InitializeComponent();
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new WebClient { Encoding = System.Text.Encoding.UTF8 };
                string json = client.DownloadString(ApiAddress);
                phoneLabel.Text = ExtractPhone(json);
                resultLabel.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ShowError("Не удалось получить данные от эмулятора.", ex);
            }
        }

        private void sendResultButton_Click(object sender, EventArgs e)
        {
            string phone = phoneLabel.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Сначала получите данные от эмулятора.", "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool validFormat = ValidateFormat(phone);
            bool validSymbols = ValidateSymbols(phone);
            resultLabel.Text = validFormat && validSymbols ? "Корректный номер телефона" : "Некорректный номер телефона";

            SaveResults(validFormat, validSymbols);
        }

        private string ExtractPhone(string json)
        {
            var match = Regex.Match(json, "\"value\"\\s*:\\s*\"(?<phone>[^\"]*)\"");
            return match.Success ? match.Groups["phone"].Value : json;
        }

        private void SaveResults(bool validFormat, bool validSymbols)
        {
            if (!File.Exists(TestCasePath))
            {
                throw new FileNotFoundException("Файл тест-кейса не найден.", TestCasePath);
            }

            Word.Application wordApp = new Word.Application();
            Word.Document document = null;

            try
            {
                document = wordApp.Documents.Open(TestCasePath);

                WriteToBookmark(document, "СпецСимвол1", validFormat ? "Успешно" : "Не успешно: номер не соответствует шаблону +7 900 123-45-67");
                WriteToBookmark(document, "СпецСимвол2", validSymbols ? "Успешно" : "Не успешно: номер содержит недопустимые символы");

                document.Save();
            }
            finally
            {
                Cleanup(wordApp, document);
            }
        }

        private void WriteToBookmark(Word.Document doc, string bookmarkName, string text)
        {
            if (!doc.Bookmarks.Exists(bookmarkName))
            {
                throw new InvalidOperationException($"Не найдена закладка \"{bookmarkName}\".");
            }

            Word.Range range = doc.Bookmarks[bookmarkName].Range;
            range.Text = text;
            doc.Bookmarks.Add(bookmarkName, range);
        }

        private void Cleanup(Word.Application app, Word.Document doc)
        {
            doc?.Close(false);
            Marshal.ReleaseComObject(doc);
            app?.Quit();
            Marshal.ReleaseComObject(app);
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show($"{message}\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidateFormat(string phone)
        {
            return Regex.IsMatch(phone, @"^\+7\s\d{3}\s\d{3}-\d{2}-\d{2}$");
        }

        private bool ValidateSymbols(string phone)
        {
            return Regex.IsMatch(phone, @"^[0-9+\s-]+$");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
