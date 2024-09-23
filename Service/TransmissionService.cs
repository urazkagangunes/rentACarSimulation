using rentACarSimulation.Models;
using rentACarSimulation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentACarSimulation.Service
{
    public class TransmissionService
    {
        TransmissionRepository transmissionRepository = new TransmissionRepository();

        public void GetAll()
        {
            List<Transmission> transmissions = transmissionRepository.GetAll();

            foreach (Transmission item in transmissions)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void GetByID(int id)
        {
            Transmission? transmissions = transmissionRepository.GetByID(id);
            if (transmissions == null)
            {
                Console.WriteLine($"Aradığınız id ye göre transmision bulunamadı: {id}");
                return;
            }

            Console.WriteLine(transmissions);
        }

        public void Add(Transmission transmission)
        {
            TransmissionIdBusinessRules(transmission.Id);
            Transmission addedTransmissions = transmissionRepository.Add(transmission);
            Console.WriteLine($"Transmission eklendi: {addedTransmissions}");
        }

        public void Remove(int id)
        {
            Transmission? deletedTransmissions = transmissionRepository.Remove(id);
            if (deletedTransmissions == null)
            {
                Console.WriteLine("Aradığınız Transmissons bulunamadı.");
                return;
            }
            Console.WriteLine(deletedTransmissions);
        }

        private void TransmissionIdBusinessRules(int id)
        {
            Transmission? getByIdTransmissions = transmissionRepository.GetByID(id);
            if (getByIdTransmissions != null)
            {
                Console.WriteLine($"Girmiş olduğunuz transmission id alanı BENZERSİZ olmalıdır: {id}");
                return;
            }
        }
    }
}
