using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.UsoltsevGP.Sprint7.V8.Lib;
namespace Tyuiu.UsoltsevGP.Sprint7.V8.Test
{
    [TestClass]
    public class DataServiceTests
    {
        private DataService _dataService;
        private string _testFilePath;

        [TestInitialize]
        public void Initialize()
        {
            _dataService = new DataService();
            _testFilePath = Path.GetTempFileName() + ".csv";

            // Создаем тестовый CSV файл
            string testData = @"AA123AA,Toyota,Хорошее,75.5,15.2
BB456BB,BMW,Среднее,64.3,11.8
CC789CC,Lada,Плохое,50.1,20.0";

            File.WriteAllText(_testFilePath, testData, System.Text.Encoding.UTF8);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Удаляем тестовый файл
            if (File.Exists(_testFilePath))
                File.Delete(_testFilePath);
        }

        [TestMethod]
        public void LoadFromCSV_ValidFile_ShouldLoadCars()
        {
            // Act
            _dataService.LoadFromCSV(_testFilePath);

            // Assert
            Assert.AreEqual(3, _dataService.Cars.Count);

            var firstCar = _dataService.Cars[0];
            Assert.AreEqual("AA123AA", firstCar.LicensePlate);
            Assert.AreEqual("Toyota", firstCar.Brand);
            Assert.AreEqual("Хорошее", firstCar.Condition);
            Assert.AreEqual(75.5, firstCar.AverageSpeed);
            Assert.AreEqual(15.2, firstCar.FuelConsumption);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void LoadFromCSV_InvalidPath_ShouldThrowException()
        {
            // Act & Assert
            _dataService.LoadFromCSV("nonexistent_file.csv");
        }

        [TestMethod]
        public void AddCar_ValidCar_ShouldAddToList()
        {
            // Arrange
            var car = new Car("DD999DD", "Mercedes", "Хорошее", 90.0, 12.5);

            // Act
            _dataService.AddCar(car);

            // Assert
            Assert.AreEqual(1, _dataService.Cars.Count);
            Assert.AreEqual("DD999DD", _dataService.Cars[0].LicensePlate);
        }

        [TestMethod]
        public void SearchByBrand_ExistingBrand_ShouldReturnCars()
        {
            // Arrange
            _dataService.LoadFromCSV(_testFilePath);

            // Act
            var result = _dataService.SearchByBrand("Toyota");

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("AA123AA", result[0].LicensePlate);
        }

        [TestMethod]
        public void SearchByBrand_PartialMatch_ShouldReturnCars()
        {
            // Arrange
            _dataService.LoadFromCSV(_testFilePath);

            // Act
            var result = _dataService.SearchByBrand("Toy");

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void SearchByBrand_NonExistingBrand_ShouldReturnEmpty()
        {
            // Arrange
            _dataService.LoadFromCSV(_testFilePath);

            // Act
            var result = _dataService.SearchByBrand("Audi");

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void FilterByCondition_ShouldReturnFilteredCars()
        {
            // Arrange
            _dataService.LoadFromCSV(_testFilePath);

            // Act
            var goodCars = _dataService.FilterByCondition("Хорошее");
            var averageCars = _dataService.FilterByCondition("Среднее");
            var badCars = _dataService.FilterByCondition("Плохое");

            // Assert
            Assert.AreEqual(1, goodCars.Count);
            Assert.AreEqual(1, averageCars.Count);
            Assert.AreEqual(1, badCars.Count);
        }

        [TestMethod]
        public void FilterBySpeedRange_ShouldReturnCarsInRange()
        {
            // Arrange
            _dataService.LoadFromCSV(_testFilePath);

            // Act
            var result = _dataService.FilterBySpeedRange(60, 80);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("AA123AA", result[0].LicensePlate);
        }

        [TestMethod]
        public void FilterByFuelConsumptionRange_ShouldReturnCarsInRange()
        {
            // Arrange
            _dataService.LoadFromCSV(_testFilePath);

            // Act
            var result = _dataService.FilterByFuelConsumptionRange(10, 15);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("AA123AA", result[0].LicensePlate);
        }

        [TestMethod]
        public void GetAllBrands_ShouldReturnUniqueBrands()
        {
            // Arrange
            _dataService.LoadFromCSV(_testFilePath);

            // Act
            var brands = _dataService.GetAllBrands();

            // Assert
            Assert.AreEqual(3, brands.Count);
            CollectionAssert.Contains(brands, "Toyota");
            CollectionAssert.Contains(brands, "BMW");
            CollectionAssert.Contains(brands, "Lada");
        }

        [TestMethod]
        public void GetAllConditions_ShouldReturnUniqueConditions()
        {
            // Arrange
            _dataService.LoadFromCSV(_testFilePath);

            // Act
            var conditions = _dataService.GetAllConditions();

            // Assert
            Assert.AreEqual(3, conditions.Count);
            CollectionAssert.Contains(conditions, "Хорошее");
            CollectionAssert.Contains(conditions, "Среднее");
            CollectionAssert.Contains(conditions, "Плохое");
        }

        [TestMethod]
        public void SaveToCSV_ShouldSaveFile()
        {
            // Arrange
            _dataService.LoadFromCSV(_testFilePath);
            string savePath = Path.GetTempFileName() + ".csv";

            // Act
            _dataService.SaveToCSV(savePath);

            // Assert
            Assert.IsTrue(File.Exists(savePath));

            var savedContent = File.ReadAllText(savePath);
            Assert.IsTrue(savedContent.Contains("AA123AA"));
            Assert.IsTrue(savedContent.Contains("Toyota"));

            // Cleanup
            File.Delete(savePath);
        }

        [TestMethod]
        public void CarToString_ShouldReturnCSVFormat()
        {
            // Arrange
            var car = new Car("AA123AA", "Toyota", "Хорошее", 75.5, 15.2);

            // Act
            string result = car.ToString();

            // Assert
            Assert.AreEqual("AA123AA,Toyota,Хорошее,75,5,15,2", result);
        }

        [TestMethod]
        public void RemoveCar_ShouldRemoveFromList()
        {
            // Arrange
            _dataService.LoadFromCSV(_testFilePath);
            var carToRemove = _dataService.Cars[0];

            // Act
            _dataService.RemoveCar(carToRemove);

            // Assert
            Assert.AreEqual(2, _dataService.Cars.Count);
            Assert.IsFalse(_dataService.Cars.Contains(carToRemove));
        }
    }
}