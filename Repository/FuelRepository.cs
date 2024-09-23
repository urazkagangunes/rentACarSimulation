using rentACarSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentACarSimulation.Repository
{
    public class FuelRepository
    {
        List<Fuel> fuel = new List<Fuel>()
        {
            new Fuel(1, "Benzin"),
            new Fuel(2, "Dizel"),
            new Fuel(3, "Gaz"),
            new Fuel(4, "Elektrik")
        };

        public List<Fuel> GetAll()
        {
            return fuel;
        }

        public Fuel? GetByID(int id)
        {
            Fuel? fuels = null;

            foreach(Fuel fuelios in fuel)
            {
                if(fuelios.Id == id)
                {
                    fuels = fuelios;
                }
            }
            if(fuels != null)
            {
                return null;
            }
            return fuels;
        }

        public Fuel Add(Fuel fuelAdded)
        {
            fuel.Add(fuelAdded);
            return fuelAdded;
        }

        public Fuel? Remove(int id)
        {
            Fuel? deletedFuel = GetByID(id);

            if(deletedFuel == null)
            {
                return null;
            }

            fuel.Remove(deletedFuel);
            return deletedFuel;
        }

        public Fuel? Update(int id)
        {
            Fuel fuelUpdated = GetByID(id);
            if(fuelUpdated == null)
            {
                return null;
            }
            return fuelUpdated;
        }
    }
}
