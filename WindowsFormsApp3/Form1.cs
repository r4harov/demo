using System;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ValidationApp
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string _currentPhoneNumber = string.Empty;

        public Form1()
        {
            InitializeComponent();
            _httpClient.BaseAddress = new Uri("http://localhost:4444/TransferSimulator/");
        }

        // Кнопка "Получить данные"
        private async void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                btnGetData.Enabled = false;
                lblStatus.Text = "Загрузка данных...";
                lblStatus.ForeColor = Color.Blue;

                HttpResponseMessage response = await _httpClient.GetAsync("mobilePhone");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(jsonResponse);

                    _currentPhoneNumber = data["value"]?.ToString() ?? string.Empty;
                    txtPhoneNumber.Text = _currentPhoneNumber;

                    lblResult.Text = "Ожидание проверки...";
                    lblResult.ForeColor = Color.Gray;
                    lblStatus.Text = "Данные получены";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    MessageBox.Show($"Ошибка получения данных: {response.StatusCode}\nОбратитесь к главному эксперту.",
                        "Ошибка API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "Ошибка получения данных";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось подключиться к эмулятору.\nУбедитесь, что TransferSimulator.exe запущен.\n\nОшибка: {ex.Message}",
                    "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Ошибка соединения";
                lblStatus.ForeColor = Color.Red;
            }
            finally
            {
                btnGetData.Enabled = true;
            }
        }

        // Кнопка "Отправить результат теста"
        private void btnSendResult_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentPhoneNumber))
            {
                MessageBox.Show("Сначала получите данные, нажав 'Получить данные'.",
                    "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string validationResult = ValidatePhoneNumber(_currentPhoneNumber);

            lblResult.Text = validationResult;

            if (validationResult.Contains("Корректный"))
            {
                lblResult.ForeColor = Color.Green;
                lblStatus.Text = "Валидация пройдена";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblResult.ForeColor = Color.Red;
                lblStatus.Text = "Валидация не пройдена";
                lblStatus.ForeColor = Color.Red;
            }

            // Здесь можно добавить код для записи в ТестКейс.docx
            // WriteToWord(validationResult);
        }

        // Метод валидации номера телефона
        private string ValidatePhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return "Не корректный номер телефона (пустой номер)";

            // Критерий 1: Проверка на недопустимые символы
            if (!Regex.IsMatch(phone, @"^[\+\d\s\-\(\)]+$"))
            {
                return "Не корректный номер телефона (недопустимые символы)";
            }

            // Критерий 2: Проверка длины и структуры
            string cleanedPhone = Regex.Replace(phone, @"[\s\-\(\)]", "");

            if (cleanedPhone.StartsWith("+7") && cleanedPhone.Length == 12)
            {
                return "Корректный номер телефона";
            }
            else if (cleanedPhone.StartsWith("8") && cleanedPhone.Length == 11)
            {
                return "Корректный номер телефона";
            }
            else if (cleanedPhone.StartsWith("+7") && cleanedPhone.Length != 12)
            {
                return $"Не корректный номер телефона (неверная длина: {cleanedPhone.Length} цифр, должно быть 11)";
            }
            else
            {
                return $"Не корректный номер телефона (неверный формат)";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblResult.Text = "Ожидание загрузки данных...";
            lblResult.ForeColor = Color.Gray;
            txtPhoneNumber.ReadOnly = true;
            this.Text = "Валидация данных";
        }
    }
}