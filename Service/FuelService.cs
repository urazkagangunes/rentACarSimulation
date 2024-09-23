using rentACarSimulation.Models;
using rentACarSimulation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentACarSimulation.Service
{
    public class FuelService
    {
        FuelRepository fuelRepository = new FuelRepository();

        public void GetAll()
        {
            List<Fuel> fuels = fuelRepository.GetAll();

            foreach (Fuel item in fuels)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void GetByID(int id)
        {
            Fuel? fuels = fuelRepository.GetByID(id);
            if (fuels == null)
            {
                Console.WriteLine($"Aradığınız id ye göre yakıt bulunamadı: {id}");
                return;
            }

            Console.WriteLine(fuels);
        }

        public void Add(Fuel fuels)
        {
            FuelIdBusinessRules(fuels.Id);
            Fuel addedFuel = fuelRepository.Add(fuels);
            Console.WriteLine($"yakıt eklendi: {addedFuel}");
        }

        public void Remove(int id)
        {
            Fuel? deletedFuels = fuelRepository.Remove(id);
            if (deletedFuels == null)
            {
                Console.WriteLine("Aradığınız yakıt bulunamadı.");
                return;
            }
            Console.WriteLine(deletedFuels);
        }

        private void FuelIdBusinessRules(int id)
        {
            Fuel? getByIdFuel = fuelRepository.GetByID(id);
            if (getByIdFuel != null)
            {
                Console.WriteLine($"Girmiş olduğunuz yakıt id alanı BENZERSİZ olmalıdır: {id}");
                return;
            }
        }
    }
}
