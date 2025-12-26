using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tyuiu.UsoltsevGP.Sprint7.V8.Lib
{
    public class Car
    {
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Condition { get; set; }
        public double AverageSpeed { get; set; }
        public double FuelConsumption { get; set; }

        public Car() { }

        public Car(string licensePlate, string brand, string condition,
                   double averageSpeed, double fuelConsumption)
        {
            LicensePlate = licensePlate;
            Brand = brand;
            Condition = condition;
            AverageSpeed = averageSpeed;
            FuelConsumption = fuelConsumption;
        }

        public override string ToString()
        {
            return $"{LicensePlate},{Brand},{Condition},{AverageSpeed},{FuelConsumption}";
        }
    }

    public class DataService
    {
        private List<Car> cars = new List<Car>();

        public List<Car> Cars => cars;

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void RemoveCar(Car car)
        {
            cars.Remove(car);
        }

        public List<Car> SearchByBrand(string brand)
        {
            return cars.Where(c => c.Brand.ToLower().Contains(brand.ToLower())).ToList();
        }

        public List<Car> FilterByCondition(string condition)
        {
            return cars.Where(c => c.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Car> FilterBySpeedRange(double minSpeed, double maxSpeed)
        {
            return cars.Where(c => c.AverageSpeed >= minSpeed && c.AverageSpeed <= maxSpeed).ToList();
        }

        public List<Car> FilterByFuelConsumptionRange(double minConsumption, double maxConsumption)
        {
            return cars.Where(c => c.FuelConsumption >= minConsumption && c.FuelConsumption <= maxConsumption).ToList();
        }

        public void LoadFromCSV(string filePath)
        {
            cars.Clear();

            try
            {
                // Читаем весь файл
                string[] allLines = File.ReadAllLines(filePath, Encoding.UTF8);

                foreach (string line in allLines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Ручной парсинг для Excel CSV
                    List<string> fields = new List<string>();
                    bool inQuotes = false;
                    string currentField = "";

                    for (int i = 0; i < line.Length; i++)
                    {
                        char c = line[i];

                        if (c == '"')
                        {
                            inQuotes = !inQuotes;
                        }
                        else if ((c == ',' || c == ';') && !inQuotes)
                        {
                            fields.Add(currentField.Trim('"', ' '));
                            currentField = "";
                        }
                        else
                        {
                            currentField += c;
                        }
                    }

                    // Добавляем последнее поле
                    if (!string.IsNullOrEmpty(currentField))
                        fields.Add(currentField.Trim('"', ' '));

                    // Нужно 5 полей
                    if (fields.Count >= 5)
                    {
                        try
                        {
                            var car = new Car(
                                fields[0],
                                fields[1],
                                fields[2],
                                double.Parse(fields[3].Replace('.', ',')),
                                double.Parse(fields[4].Replace('.', ','))
                            );
                            cars.Add(car);
                        }
                        catch
                        {
                            // Пропускаем если ошибка парсинга (возможно заголовок)
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при загрузке CSV файла: {ex.Message}");
            }
        }


        public void SaveToCSV(string filePath)
        {
            try
            {
                var lines = new List<string>();
                foreach (var car in cars)
                {
                    lines.Add(car.ToString());
                }
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при сохранении CSV файла: {ex.Message}");
            }
        }

        public List<string> GetAllBrands()
        {
            return cars.Select(c => c.Brand).Distinct().ToList();
        }

        public List<string> GetAllConditions()
        {
            return cars.Select(c => c.Condition).Distinct().ToList();
        }
    }
}