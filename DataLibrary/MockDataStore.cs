using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonInterfaces;

namespace DataLibrary
{
    public class MockDataStore : ICarStore
    {
        public IEnumerable<CompanyCar> GetCompanyCars(int? companyCarId = null, Car.Status? filterStatus = null)
        {
            var id = 0;
            var cars = new List<CompanyCar>
                   {
                       new CompanyCar
                       {
                           Id = id,
                           Address = "Vårby alle 25",
                           City = "Huddinge",
                           Name = "ICA AB",
                           ZipCode = "121 30",
                           Cars = CreateRandomCars(id++, filterStatus)
                       },
                       new CompanyCar
                       {
                           Id = id,
                           Address = "Grusåsgränd 125",
                           City = "Stockholm",
                           Name = "Mercedez ",
                           ZipCode = "131 30",
                           Cars = CreateRandomCars(id++, filterStatus)
                       },
                       new CompanyCar
                       {
                           Id = id,
                           Address = "Täppägränd 200",
                           City = "Huddinge",
                           Name = "Tesla Org",
                           ZipCode = "151 10",
                           Cars = CreateRandomCars(id++, filterStatus)
                       },
                       new CompanyCar
                       {
                           Id = id,
                           Address = "Alvik Torg 12",
                           City = "Huddinge",
                           Name = "Ford AB",
                           ZipCode = "161 20",
                           Cars = CreateRandomCars(id++, filterStatus)
                       },
                       new CompanyCar
                       {
                           Id = id,
                           Address = "Al Torg 14",
                           City = "Huddinge",
                           Name = "F1 Cars",
                           ZipCode = "171 35",
                           Cars = CreateRandomCars(id++, filterStatus)
                       },
                       new CompanyCar
                       {
                           Id = id,
                           Address = "Buss Torg 16",
                           City = "Huddinge",
                           Name = "F10 Motors",
                           ZipCode = "171 35",
                           Cars = CreateRandomCars(id++, filterStatus)
                       },
                       new CompanyCar
                       {
                           Id = id,
                           Address = "Persongatan 12",
                           City = "Huddinge",
                           Name = "Burk AB",
                           ZipCode = "172 35",
                           Cars = CreateRandomCars(id++, filterStatus)
                       },
                       new CompanyCar
                       {
                           Id = id,
                           Address = "Burkmat Gatan 12",
                           City = "Huddinge",
                           Name = "Pump AB",
                           ZipCode = "174 35",
                           Cars = CreateRandomCars(id++, filterStatus)
                       },
                   };

            return companyCarId.HasValue ? cars.Where(c => c.Id == companyCarId.Value).OrderBy(c => c.Name) : cars.OrderBy(c => c.Name);
        }


        private static readonly Random GlobalStatusRandom = new Random();
        //Just a simple silly helper method to generate random cars.
        private static IEnumerable<Car> CreateRandomCars(int companyCarId, Car.Status? filterStatus)
        {
            var random = new Random(companyCarId);
            var cars = new List<Car>();
            cars.AddRange(Enumerable.Range(0, random.Next(1, 5)).Select(s => CreateRandomCar(companyCarId, random)));

            return filterStatus.HasValue ? cars.Where(f => f.CarStatus == filterStatus) : cars;
        }

        private static Car CreateRandomCar(int companyCarId, Random random)
        {
            return new Car
            {
                CompanyCarId = companyCarId,
                CarStatus = (Car.Status)GlobalStatusRandom.Next((int)Car.Status.Available, (int)Car.Status.Broken + 1),
                RegNumber = $"ABC123{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}",
                VinNumber = $"YS2R4X20010110{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}",
            };
        }
    }
}
