using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tyuiu.UsoltsevGP.Sprint7.V8.Lib;

namespace Tyuiu.UsoltsevGP.Sprint7.V8
{
    public partial class FormMain : Form
    {
        private DataService dataService = new DataService();
        private List<Car> currentDisplayedCars = new List<Car>();

        public FormMain()
        {
            InitializeComponent();
            SetupDataGridView();
            SetupChart();
        }

        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("LicensePlate", "Номерной знак");
            dataGridView1.Columns.Add("Brand", "Марка автомобиля");
            dataGridView1.Columns.Add("Condition", "Тех. состояние");
            dataGridView1.Columns.Add("AverageSpeed", "Сред. скорость (км/ч)");
            dataGridView1.Columns.Add("FuelConsumption", "Расход топлива (л/100км)");

            dataGridView1.Columns["AverageSpeed"].ValueType = typeof(double);
            dataGridView1.Columns["FuelConsumption"].ValueType = typeof(double);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void SetupChart()
        {
            if (chart1 == null) return;

            chart1.Series.Clear();

            if (currentDisplayedCars == null || currentDisplayedCars.Count == 0)
                return;

            // Создаем 3 серии (состояние, скорость, расход)
            Series conditionSeries = new Series("Тех. состояние")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Blue,
                IsValueShownAsLabel = true
            };

            Series speedSeries = new Series("Сред. скорость")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Red,
                IsValueShownAsLabel = true
            };

            Series fuelSeries = new Series("Расход топлива")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Green,
                IsValueShownAsLabel = true
            };

            // Заполняем данными для КАЖДОГО автомобиля
            for (int i = 0; i < currentDisplayedCars.Count; i++)
            {
                var car = currentDisplayedCars[i];

                if (string.IsNullOrEmpty(car.LicensePlate))
                    continue;

                // Значения
                double conditionValue = car.Condition.Contains("Хорош") ? 3 :
                                       car.Condition.Contains("Сред") ? 2 : 1;

                // Добавляем точки в каждую серию
                // Все 3 серии получат точку с одинаковой X-координатой (i)
                conditionSeries.Points.AddXY(i + 1, conditionValue);
                speedSeries.Points.AddXY(i + 1, car.AverageSpeed);
                fuelSeries.Points.AddXY(i + 1, car.FuelConsumption);

                // Подписываем ось X номерным знаком
                conditionSeries.Points[i].AxisLabel = car.LicensePlate;
            }

            // Добавляем серии на график
            chart1.Series.Add(conditionSeries);
            chart1.Series.Add(speedSeries);
            chart1.Series.Add(fuelSeries);

            // Настройки для группированных столбцов
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            // Настройка расстояния между группами столбцов
            chart1.ChartAreas[0].AxisX.IsMarginVisible = true;
        }

        private void DisplayCars(List<Car> cars)
        {
            currentDisplayedCars = cars;
            dataGridView1.Rows.Clear();

            foreach (var car in cars)
            {
                dataGridView1.Rows.Add(
                    car.LicensePlate,
                    car.Brand,
                    car.Condition,
                    car.AverageSpeed,
                    car.FuelConsumption
                );
            }

            // ОБНОВЛЯЕМ ГРАФИК ПОСЛЕ ЗАГРУЗКИ ДАННЫХ
            SetupChart();
        }

        // Загрузка CSV файла
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        dataService.LoadFromCSV(openFileDialog.FileName);
                        DisplayCars(dataService.Cars);
                        MessageBox.Show("Файл успешно загружен!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки файла: {ex.Message}",
                                      "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Сохранение в CSV файл
        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.DefaultExt = "csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        dataService.SaveToCSV(saveFileDialog.FileName);
                        MessageBox.Show("Файл успешно сохранен!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения файла: {ex.Message}",
                                      "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Добавление нового автомобиля
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка заполнения полей
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("Все поля должны быть заполнены!",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Парсинг числовых значений
                if (!double.TryParse(textBox4.Text, out double speed) ||
                    !double.TryParse(textBox5.Text, out double fuelConsumption))
                {
                    MessageBox.Show("Некорректные числовые значения!",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Создание нового автомобиля
                var newCar = new Car(
                    textBox1.Text.Trim(),
                    textBox2.Text.Trim(),
                    textBox3.Text.Trim(),
                    speed,
                    fuelConsumption
                );

                // Добавление в менеджер и отображение
                dataService.AddCar(newCar);
                DisplayCars(dataService.Cars);

                // Очистка полей ввода
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                MessageBox.Show("Автомобиль успешно добавлен!",
                              "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении автомобиля: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Поиск по марке автомобиля
        private void button4_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox6.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                DisplayCars(dataService.Cars);
            }
            else
            {
                var searchResults = dataService.SearchByBrand(searchTerm);
                DisplayCars(searchResults);
            }
        }

        // Фильтрация по техническому состоянию
        private void button6_Click(object sender, EventArgs e)
        {
            var conditions = dataService.GetAllConditions();
            if (conditions.Count == 0)
            {
                MessageBox.Show("Нет данных для фильтрации",
                              "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var form = new FormFilter(conditions, "Выберите техническое состояние:"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var filteredCars = dataService.FilterByCondition(form.SelectedValue);
                    DisplayCars(filteredCars);
                }
            }
        }

        // Фильтрация по средней скорости
        private void button7_Click(object sender, EventArgs e)
        {
            using (var form = new FormSpeedFilter())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var filteredCars = dataService.FilterBySpeedRange(form.MinSpeed, form.MaxSpeed);
                    DisplayCars(filteredCars);
                }
            }
        }

        // Фильтрация по расходу топлива
        private void button8_Click(object sender, EventArgs e)
        {
            using (var form = new FormFuelFilter())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var filteredCars = dataService.FilterByFuelConsumptionRange(
                        form.MinConsumption, form.MaxConsumption);
                    DisplayCars(filteredCars);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAbout aboutForm = new FormAbout();
    aboutForm.ShowDialog();
        }
    }

    // Вспомогательные формы для фильтрации
    public class FormFilter : Form
    {
        private ComboBox comboBox;
        public string SelectedValue { get; private set; }

        public FormFilter(List<string> items, string labelText)
        {
            InitializeComponents(items, labelText);
        }

        private void InitializeComponents(List<string> items, string labelText)
        {
            this.Text = "Фильтр";
            this.Size = new Size(300, 150);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var label = new Label
            {
                Text = labelText,
                Location = new Point(10, 10),
                Size = new Size(280, 20)
            };

            comboBox = new ComboBox
            {
                Location = new Point(10, 40),
                Size = new Size(260, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            foreach (var item in items)
            {
                comboBox.Items.Add(item);
            }

            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;

            var btnOk = new Button
            {
                Text = "OK",
                Location = new Point(60, 70),
                Size = new Size(80, 30),
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button
            {
                Text = "Отмена",
                Location = new Point(150, 70),
                Size = new Size(80, 30),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.Add(label);
            this.Controls.Add(comboBox);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);

            btnOk.Click += (s, e) =>
            {
                SelectedValue = comboBox.SelectedItem?.ToString();
                this.Close();
            };
        }
    }

    public class FormSpeedFilter : Form
    {
        public double MinSpeed { get; private set; }
        public double MaxSpeed { get; private set; }

        private TextBox txtMin;
        private TextBox txtMax;

        public FormSpeedFilter()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Фильтр по скорости";
            this.Size = new Size(300, 150);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            var lblMin = new Label { Text = "Минимальная скорость:", Location = new Point(10, 10), Width = 140 };
            var lblMax = new Label { Text = "Максимальная скорость:", Location = new Point(10, 40), Width = 140 };

            txtMin = new TextBox { Location = new Point(150, 10), Size = new Size(100, 20) };
            txtMax = new TextBox { Location = new Point(150, 40), Size = new Size(100, 20) };

            var btnOk = new Button
            {
                Text = "OK",
                Location = new Point(60, 70),
                Size = new Size(80, 30),
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button
            {
                Text = "Отмена",
                Location = new Point(150, 70),
                Size = new Size(80, 30),
                DialogResult = DialogResult.Cancel
            };

            btnOk.Click += (s, e) =>
            {
                if (double.TryParse(txtMin.Text, out double min) &&
                    double.TryParse(txtMax.Text, out double max))
                {
                    MinSpeed = min;
                    MaxSpeed = max;
                }
            };

            this.Controls.AddRange(new Control[] { lblMin, lblMax, txtMin, txtMax, btnOk, btnCancel });
        }
    }

    public class FormFuelFilter : Form
    {
        public double MinConsumption { get; private set; }
        public double MaxConsumption { get; private set; }

        private TextBox txtMin;
        private TextBox txtMax;

        public FormFuelFilter()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Фильтр по расходу топлива";
            this.Size = new Size(300, 150);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            var lblMin = new Label { Text = "Минимальный расход:", Location = new Point(10, 10), Width = 140 };
            var lblMax = new Label { Text = "Максимальный расход:", Location = new Point(10, 40), Width = 140 };

            txtMin = new TextBox { Location = new Point(150, 10), Size = new Size(100, 20) };
            txtMax = new TextBox { Location = new Point(150, 40), Size = new Size(100, 20) };

            var btnOk = new Button
            {
                Text = "OK",
                Location = new Point(60, 70),
                Size = new Size(80, 30),
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button
            {
                Text = "Отмена",
                Location = new Point(150, 70),
                Size = new Size(80, 30),
                DialogResult = DialogResult.Cancel
            };

            btnOk.Click += (s, e) =>
            {
                if (double.TryParse(txtMin.Text, out double min) &&
                    double.TryParse(txtMax.Text, out double max))
                {
                    MinConsumption = min;
                    MaxConsumption = max;
                }
            };

            this.Controls.AddRange(new Control[] { lblMin, lblMax, txtMin, txtMax, btnOk, btnCancel });
        }
    }
}