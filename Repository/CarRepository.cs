using rentACarSimulation.Models;
using rentACarSimulation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using System.Reflection.Metadata.Ecma335;

namespace rentACarSimulation.Repository
{
    public class CarRepository
    {
        List<Car> cars = new List<Car>() 
        {
            new Car(1, 1, 1, 1, "New", 0, 2024, "34ETK789", "TOGG", "T10X", 1800000),
            new Car(2, 2, 2, 2, "İkinci El", 12000, 2020, "34ESD123", "Tesla", "Model S", 2000000),
            new Car(3, 3, 3, 3, "İkinci El", 2333223, 2002, "40UKG077", "Anadol", "Serçe", 1000000),
            new Car(4, 4, 4, 2, "Yeni", 0, 2025, "40SG0707", "Urazol", "Uraz", 7000000)
        };

        List<Color> color = new List<Color>()
        {
            new Color(1, "Siyah"),
            new Color(2, "Beyaz"),
            new Color(3, "Kırmızı"),
            new Color(4, "Turkuaz")
        };

        List<Fuel> fuel = new List<Fuel>()
        {
            new Fuel(1, "Benzin"),
            new Fuel(2, "Dizel"),
            new Fuel(3, "Gaz"),
            new Fuel(4, "Elektrik")
        };

        List<Transmission> transmissions = new List<Transmission>()
        {
            new Transmission(1, "Manuel"),
            new Transmission(2, "Otomatik"),
            new Transmission(3, "Yarı Otomatik")
        };


        public List<Car> GetAll() 
        { 
            return cars; 
        }

        public Car Add(Car added) 
        {
            cars.Add(added);
            return added;
        }

        //public Car Update(int id)
        //{
        //    Car? updatedCar = GetByID(id);
        //    if (updatedCar == null)
        //    {
        //        return null;
        //    }
        //    return updatedCar;
        //}

        public Car Update(int id, Car updatedCar)
        {
            Car car = GetByID(id);
            if (car == null)
            {
                return null;
            }

            // Update the car properties
            car.Id = updatedCar.Id;
            car.KiloMeter = updatedCar.KiloMeter;
            car.CarState = updatedCar.CarState;
            car.Plate = updatedCar.Plate;
            car.DailyPrice = updatedCar.DailyPrice;
            car.TransmissionId = updatedCar.TransmissionId;
            car.ColorId = updatedCar.ColorId;
            car.FuelId = updatedCar.FuelId;
            car.BrandName = updatedCar.BrandName;
            car.ModelName = updatedCar.ModelName;
            car.ModelYear = updatedCar.ModelYear;

            return car;
        }

        public Car? Remove(int id)
        {
            Car? deletedCar = GetByID(id);
            if (deletedCar == null)
            {
                return null;
            }
            cars.Remove(deletedCar);
            return deletedCar;
        }
        
        public Car? GetByID(int id)
        {
            Car? car = null;
            foreach (var item in cars)
            {
                if (item.Id == id)
                {
                    car = item;
                }
            }
            if (car is null)
            {
                return null;
            }
            return car;
        }

        public List<CarDetailDto> GetAllDetails()
        {
            var carDetails = (from car in cars
                              join fuel in fuel on car.FuelId equals fuel.Id
                              join transmission in transmissions on car.TransmissionId equals transmission.Id
                              join color in color on car.ColorId equals color.Id
                              select new CarDetailDto
                              (
                                  car.Id,
                                  fuel.Name,
                                  transmission.Name,
                                  color.Name,
                                  car.CarState,
                                  car.KiloMeter,
                                  car.ModelYear,
                                  car.Plate,
                                  car.BrandName,
                                  car.ModelName,
                                  car.DailyPrice
                              )).ToList();

            return carDetails;
        }

        public List<CarDetailDto> GetAllDetailsByFuelId(int fuelId)
        {
            var carDetails = (from car in cars
                              where car.FuelId == fuelId
                              join fuel in fuel on car.FuelId equals fuel.Id
                              join transmission in transmissions on car.TransmissionId equals transmission.Id
                              join color in color on car.ColorId equals color.Id
                              select new CarDetailDto
                              (
                                  car.Id,
                                  fuel.Name,
                                  transmission.Name,
                                  color.Name,
                                  car.CarState,
                                  car.KiloMeter,
                                  car.ModelYear,
                                  car.Plate,
                                  car.BrandName,
                                  car.ModelName,
                                  car.DailyPrice
                              )).ToList();
            return carDetails;
        }

        public List<CarDetailDto> GetAllDetailsByColorID(int colorId)
        {
            var carDetails = (from car in cars
                              where car.ColorId == colorId
                              join fuel in fuel on car.FuelId equals fuel.Id
                              join color in color on car.ColorId equals color.Id
                              join transmission in transmissions on car.TransmissionId equals transmission.Id
                              select new CarDetailDto
                              (
                                  car.Id,
                                  fuel.Name,
                                  transmission.Name,
                                  color.Name,
                                  car.CarState,
                                  car.KiloMeter,
                                  car.ModelYear,
                                  car.Plate,
                                  car.BrandName,
                                  car.ModelName,
                                  car.DailyPrice
                              )).ToList(); 
            return carDetails;
                              
        }

        public List<CarDetailDto> GetAllDetailsByPriceRange(double min, double max)
        {
            List<Car> result = cars.FindAll(b => b.DailyPrice <= max && b.DailyPrice >= min);
            
            var carDetails = (from car in result
                              join f in fuel on car.FuelId equals f.Id
                              join t in transmissions on car.TransmissionId equals t.Id
                              join c in color on car.ColorId equals c.Id
                              select new CarDetailDto
                              (
                                  car.Id,
                                  f.Name,
                                  t.Name,
                                  c.Name,
                                  car.CarState,
                                  car.KiloMeter,
                                  car.ModelYear,
                                  car.Plate,
                                  car.BrandName,
                                  car.ModelName,
                                  car.DailyPrice
                              )).ToList();

            return carDetails;
        }

        public List<CarDetailDto> GetAllDetailsByKilometerRange(int min, int max)
        {
            List<Car> result = cars.FindAll(b => b.KiloMeter <= max && b.KiloMeter >= min);

            var carDetails = (from car in result
                              join f in fuel on car.FuelId equals f.Id
                              join t in transmissions on car.TransmissionId equals t.Id
                              join c in color on car.ColorId equals c.Id
                              select new CarDetailDto
                              (
                                  car.Id,
                                  f.Name,
                                  t.Name,
                                  c.Name,
                                  car.CarState,
                                  car.KiloMeter,
                                  car.ModelYear,
                                  car.Plate,
                                  car.BrandName,
                                  car.ModelName,
                                  car.DailyPrice
                              )).ToList();

            return carDetails;
        }

        public List<CarDetailDto> GetAllDetailsByBrandNameContains(string BrandName)
        {

            List<Car> result = cars.FindAll(x => x.BrandName.Contains(BrandName, StringComparison.InvariantCultureIgnoreCase));

            var carDetails = (from car in result
                              join f in fuel on car.FuelId equals f.Id
                              join t in transmissions on car.TransmissionId equals t.Id
                              join c in color on car.ColorId equals c.Id
                              select new CarDetailDto
                              (
                                  car.Id,
                                  f.Name,
                                  t.Name,
                                  c.Name,
                                  car.CarState,
                                  car.KiloMeter,
                                  car.ModelYear,
                                  car.Plate,
                                  car.BrandName,
                                  car.ModelName,
                                  car.DailyPrice
                              )).ToList();

            return carDetails;
        }

        public List<CarDetailDto> GetAllDetailsByModelNameContains(string modelName)
        {
            List<Car> result = cars.FindAll(x => x.ModelName.Contains(modelName, StringComparison.InvariantCultureIgnoreCase));

            var carDetails = (from car in result
                              join f in fuel on car.FuelId equals f.Id
                              join t in transmissions on car.TransmissionId equals t.Id
                              join c in color on car.ColorId equals c.Id
                              select new CarDetailDto
                              (
                                  car.Id,
                                  f.Name,
                                  t.Name,
                                  c.Name,
                                  car.CarState,
                                  car.KiloMeter,
                                  car.ModelYear,
                                  car.Plate,
                                  car.BrandName,
                                  car.ModelName,
                                  car.DailyPrice
                              )).ToList();

            return carDetails;
        }


    }

}
