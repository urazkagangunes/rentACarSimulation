using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentACarSimulation.Models
{
    public class Car
    {
        public Car()
        {

        }

        public Car(int id, int colorId, int fuelId, int transmissionId, string carState, int kiloMeter, int modelYear, string plate, string brandName, string modelName, double dailyPrice)
        {
            Id = id;
            ColorId = colorId;
            FuelId = fuelId;
            TransmissionId = transmissionId;
            CarState = carState;
            KiloMeter = kiloMeter;
            ModelYear = modelYear;
            Plate = plate;
            BrandName = brandName;
            ModelName = modelName;
            DailyPrice = dailyPrice;
        }

        public int Id { get; set; }
        public int ColorId { get; set; }
        public int FuelId { get; set; }
        public int TransmissionId { get; set; }
        public string CarState { get; set; }
        public int KiloMeter { get; set; }
        public int ModelYear { get; set; }
        public string Plate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public double DailyPrice { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, ColorID: {ColorId}, FuelID: {FuelId}, TransmissionID: {TransmissionId}, CarState: {CarState}, KiloMeter: {KiloMeter}, ModelYear: {ModelYear}, Plate: {Plate}, BrandName: {BrandName}, ModelName: {ModelName}, DailyPrice: {DailyPrice}";
        }
    }
}
