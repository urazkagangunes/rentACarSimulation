using rentACarSimulation.DTO;
using rentACarSimulation.Models;
using rentACarSimulation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentACarSimulation.Service
{
    public class CarService
    {
        CarRepository carRepository = new CarRepository();

        public void GetAll()
        {
            List<Car> cars = carRepository.GetAll();

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        public void GetByID(int id)
        {
            Car? car = carRepository.GetByID(id);
            if (car == null)
            {
                Console.WriteLine($"Aradığınız id ye göre araba bulunamadı: {id}");
                return;
            }

            Console.WriteLine(car);
        }

        public void Add(Car car)
        {
            CarIdBusinessRules(car.Id);
            Car added = carRepository.Add(car);
            Console.WriteLine($"Araba eklendi: {added}");
        }

        public void Remove(int id)
        {
            Car? deletedCar = carRepository.Remove(id);
            if (deletedCar == null)
            {
                Console.WriteLine("Aradığınız araba bulunamadı.");
                return;
            }
            Console.WriteLine(deletedCar);
        }

        public Car UpdateCar(int id, Car updatedCar)
        {
            Car? car = carRepository.GetByID(id);
            if (car == null)
            {
                // You can return a custom error or null if the car doesn't exist
                return null;
            }

            // Update the car using the repository
            return carRepository.Update(id, updatedCar);
        }

        private void CarIdBusinessRules(int id)
        {
            Car? getByIdCar = carRepository.GetByID(id);
            if (getByIdCar != null)
            {
                Console.WriteLine($"Girmiş olduğunuz arabanın id alanı BENZERSİZ olmalıdır: {id}");
                return;
            }
        }

        public void GetAllDetails()
        {
            List<CarDetailDto> cars = carRepository.GetAllDetails();
            foreach (CarDetailDto carDetail in cars)
            {
                Console.WriteLine(carDetail);
            }
        }

        public void GetAllDetailsByFuelID(int fuelID)
        {
            List<CarDetailDto> cars = carRepository.GetAllDetailsByFuelId(fuelID);
            foreach (CarDetailDto carDetail in cars)
            {
                Console.WriteLine(carDetail); 
            }
        }

        public void GetAllDetailsByColorID(int colorID)
        {
            List<CarDetailDto> cars = carRepository.GetAllDetailsByColorID(colorID);
            foreach(CarDetailDto carDetail in cars)
            {
                Console.WriteLine(carDetail);
            }
        }
        
        public void GetAllDetailsByPriceRange(int min, int max)
        {
            List<CarDetailDto> cars = carRepository.GetAllDetailsByPriceRange(min, max);
            foreach (CarDetailDto carDetail in cars)
            {
                Console.WriteLine(carDetail);
            }
        }

        public void GetAllDetailsByBrandNameContains(string text)
        {
            List<CarDetailDto> cars = carRepository.GetAllDetailsByBrandNameContains(text);
            foreach(CarDetailDto carDetail in cars)
            {
                Console.WriteLine(carDetail);
            }
        }

        public void GetAllDetailsByModelNameContains(string text)
        {
            List<CarDetailDto> cars = carRepository.GetAllDetailsByModelNameContains(text);

            foreach (CarDetailDto carDetail in cars)
            {
                Console.WriteLine(carDetail);
            }
        }

        public void GetAllDetailsByKilometerRange(int min, int max)
        {
            List<CarDetailDto> cars = carRepository.GetAllDetailsByKilometerRange(min, max);
            foreach (CarDetailDto carDetail in cars)
            {
                Console.WriteLine(carDetail);
            }
        }
    }
}
