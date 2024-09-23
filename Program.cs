using rentACarSimulation.Models;
using rentACarSimulation.Repository;
using rentACarSimulation.Service;
namespace rentACarSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarRepository carRepository = new CarRepository();
            CarService carService = new CarService();
            carService.GetByID(1);


            //(1, 1, 1, 1, "New", 0, 2024, "34ETK789", "TOGG", "T10X", 1800000),
            var updatedCarData = new Car { Id = 1, ColorId = 1, TransmissionId = 2, FuelId = 3, CarState = "OLD", KiloMeter = 120000, ModelYear = 2022, Plate = "07UKG07", ModelName = "Porsche", BrandName = "Taycan", DailyPrice = 18000000  };

            // Aracı güncelle
            Car updatedCar = carService.UpdateCar(1, updatedCarData);

            if (updatedCar != null)
            {
                Console.WriteLine($"Updated Car: {updatedCar.Id} {updatedCar.ModelName} ({updatedCar.ModelYear})");
            }
            else
            {
                Console.WriteLine("Car not found.");
            }

            // Tüm araçları listele
            Console.WriteLine("\nCurrent Cars:");
            carService.GetAll();
        }
    }
}
