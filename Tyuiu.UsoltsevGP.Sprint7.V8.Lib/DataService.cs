using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

// Пространство имен можно адаптировать под ваш проект
namespace Tyuiu.UsoltsevGP.Sprint7.V8.Library
{
    // Класс автомобиля
    public class Vehicle
    {
        public string RegNumber { get; set; }      // номерной знак
        public string Make { get; set; }           // марка
        public string Condition { get; set; }      // техническое состояние (описание)
        public double AvgSpeed { get; set; }       // средняя скорость
        public double FuelConsumption { get; set; } // расход топлива

        public Vehicle(string regNumber, string make, string condition, double avgSpeed, double fuelConsumption)
        {
            RegNumber = regNumber;
            Make = make;
            Condition = condition;
            AvgSpeed = avgSpeed;
            FuelConsumption = fuelConsumption;
        }

        // Перегрузка ToString для удобного вывода
        public override string ToString()
        {
            return $"{RegNumber} | {Make} | {Condition} | {AvgSpeed} km/h | {FuelConsumption} L/100km";
        }
    }

    // Водитель
    public class Driver
    {
        public string FullName { get; set; }    // ФИО
        public string Initials { get; set; }    // Инициалы (например, И.И. Иванов)
        public int YearsExperience { get; set; } // стаж водителя в годах

        public Driver(string fullName, string initials, int years)
        {
            FullName = fullName;
            Initials = initials;
            YearsExperience = years;
        }

        public override string ToString()
        {
            return $"{FullName} ({Initials}), стаж: {YearsExperience} лет";
        }
    }

    // Связка автомобиль-водитель и состояние
    public class FleetItem
    {
        public Vehicle Vehicle { get; set; }
        public Driver Driver { get; set; }

        // Класс автомобиля для графика
        public CarClass CarClass { get; set; }

        public FleetItem(Vehicle vehicle, Driver driver, CarClass carClass)
        {
            Vehicle = vehicle;
            Driver = driver;
            CarClass = carClass;
        }
    }

    // Перечисление классов автомобиля для графика
    public enum CarClass
    {
        Economy,
        Comfort,
        Business
    }

    // Репозиторий чтения/записи CSV
    public static class CsvHelper
    {
        // Заголовки CSV
        private const string CsvHeader = "RegNumber,Make,Condition,AvgSpeed,FuelConsumption,DriverInitials,DriverFullName,DriverYears,CarClass";

        public static List<FleetItem> LoadFromCsv(string path)
        {
            var items = new List<FleetItem>();
            if (!File.Exists(path))
                return items;

            foreach (var line in File.ReadAllLines(path).Skip(1)) // пропустим заголовок
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var cols = SplitCsvLine(line);
                if (cols.Length < 9) continue;

                var vehicle = new Vehicle(
                    cols[0], // RegNumber
                    cols[1], // Make
                    cols[2], // Condition
                    ParseDouble(cols[3]), // AvgSpeed
                    ParseDouble(cols[4])  // FuelConsumption
                );

                var driver = new Driver(
                    cols[6], // DriverFullName
                    cols[5], // DriverInitials
                    ParseInt(cols[7]) // DriverYears
                );

                var carClass = ParseCarClass(cols[8]);

                items.Add(new FleetItem(vehicle, driver, carClass));
            }
            return items;
        }

        public static void SaveToCsv(string path, IEnumerable<FleetItem> items)
        {
            var lines = new List<string> { CsvHeader };
            foreach (var it in items)
            {
                lines.Add(string.Join(",",
                    Escape(it.Vehicle.RegNumber),
                    Escape(it.Vehicle.Make),
                    Escape(it.Vehicle.Condition),
                    it.Vehicle.AvgSpeed.ToString(CultureInfo.InvariantCulture),
                    it.Vehicle.FuelConsumption.ToString(CultureInfo.InvariantCulture),
                    Escape(it.Driver.Initials),
                    Escape(it.Driver.FullName),
                    it.Driver.YearsExperience.ToString(),
                    it.CarClass.ToString()
                ));
            }
            File.WriteAllLines(path, lines);
        }

        // Вспомогатели
        private static string[] SplitCsvLine(string line)
        {
            // Для простоты используем простой разбор без кавычек; если ваши данные могут содержать запятые, используйте более сложный парсер.
            return line.Split(',');
        }

        private static string Escape(string s) => s?.Replace(",", "\\,") ?? "";

        private static double ParseDouble(string s) => double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0;
        private static int ParseInt(string s) => int.TryParse(s, out var v) ? v : 0;

        private static CarClass ParseCarClass(string s)
        {
            return Enum.TryParse<CarClass>(s, true, out var cc) ? cc : CarClass.Economy;
        }

        // Опционально: генератор демонстрационных данных
        public static List<FleetItem> GenerateSample()
        {
            var v1 = new Vehicle("С 777 ТУ", "Lexus LS", "Нормальное", 120, 8.5);
            var d1 = new Driver("Иванов Иван Иванович", "И.И.", 5);
            var v2 = new Vehicle("Р 123 ОБ", "Toyota Camry", "Отличное", 110, 6.8);
            var d2 = new Driver("Петрова Анна Сергеевна", "П.А.", 7);
            return new List<FleetItem>
            {
                new FleetItem(v1, d1, CarClass.Business),
                new FleetItem(v2, d2, CarClass.Economy)
            };
        }
    }

    // Пример класса-менеджера для коллекции и графиков
    public class FleetManager
    {
        public List<FleetItem> Items { get; private set; } = new List<FleetItem>();

        public FleetManager() { }

        public FleetManager(IEnumerable<FleetItem> items)
        {
            Items.AddRange(items);
        }

        // Поиск водителя по инициалам (частичный поиск)
        public IEnumerable<Driver> FindDriversByInitials(string initialsQuery)
        {
            if (string.IsNullOrWhiteSpace(initialsQuery))
                return Enumerable.Empty<Driver>();

            var q = initialsQuery.Trim().ToLowerInvariant();
            return Items.Select(i => i.Driver)
                        .Where(d => d.Initials?.ToLowerInvariant().Contains(q) == true)
                        .GroupBy(d => d.Initials)
                        .Select(g => g.First());
        }

        // Фильтрация по стажу (минумум years)
        public IEnumerable<Driver> FilterDriversByExperience(int minYears)
        {
            return Items.Select(i => i.Driver)
                        .Where(d => d.YearsExperience >= minYears)
                        .GroupBy(d => d.Initials)
                        .Select(g => g.First());
        }

        // График по классам: подсчитать количество автомобилей в каждом классе
        public Dictionary<CarClass, int> GetCountsByClass()
        {
            return Items.GroupBy(i => i.CarClass)
                        .ToDictionary(g => g.Key, g => g.Count());
        }

        // Пример: получить подмножество элементов по классу
        public IEnumerable<FleetItem> GetItemsByClass(CarClass c)
        {
            return Items.Where(i => i.CarClass == c);
        }

        // Загрузка/сохранение
        public void LoadFromCsv(string path)
        {
            Items = CsvHelper.LoadFromCsv(path);
        }

        public void SaveToCsv(string path)
        {
            CsvHelper.SaveToCsv(path, Items);
        }

        // Добавление элемента
        public void AddFleetItem(FleetItem item)
        {
            Items.Add(item);
        }

        // Удаление элемента по RegNumber
        public bool RemoveByReg(string reg)
        {
            var item = Items.FirstOrDefault(i => i.Vehicle.RegNumber == reg);
            if (item != null)
            {
                Items.Remove(item);
                return true;
            }
            return false;
        }
    }
}