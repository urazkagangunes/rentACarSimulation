using rentACarSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace rentACarSimulation.Repository
{
    public class TransmissionRepository
    {
        List<Transmission> transmissions = new List<Transmission>()
        {
            new Transmission(1, "Manuel"),
            new Transmission(2, "Otomatik"),
            new Transmission(3, "Yarı Otomatik")
        };

        public List<Transmission> GetAll()
        {
            return transmissions; 
        }

        public Transmission Add(Transmission added)
        {
            transmissions.Add(added);   
            return added;
        }

        public Transmission GetByID(int id)
        {
            Transmission transmission1  = null;
            foreach (Transmission item in transmissions)
            {
                if(item.Id == id)
                {
                    transmission1 = item;
                }
            }
            if(transmission1 == null)
            {
                return null;
            }
            return transmission1;
        }

        public Transmission? UpdatedByID(int id)
        {
            Transmission? updatedTransmission = GetByID(id);

            if(updatedTransmission == null)
            {
                return null;
            }
            return updatedTransmission;
        }

        public Transmission Remove(int id)
        {
            Transmission? deletedTransmission = GetByID(id);

            if (deletedTransmission is not null)
            {
                return null;
            }
            transmissions.Remove(deletedTransmission);

            return deletedTransmission;

        }

    }
}
