using rentACarSimulation.Models;
using rentACarSimulation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentACarSimulation.Service
{
    public class ColorService
    {
        ColorRepository colorRepository = new ColorRepository();

        public void GetAll()
        {
            List<Color> colors = colorRepository.GetAll();

            foreach (Color item in colors)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void GetByID(int id)
        {
            Color? colors = colorRepository.GetByID(id);
            if (colors == null)
            {
                Console.WriteLine($"Aradığınız id ye göre renk bulunamadı: {id}");
                return;
            }

            Console.WriteLine(colors);
        }

        public void Add(Color colors)
        {
            ColorIdBusinessRules(colors.Id);
            Color addedColor = colorRepository.Add(colors);
            Console.WriteLine($"Renk eklendi: {addedColor}");
        }

        public void Remove(int id)
        {
            Color? deletedColor = colorRepository.Remove(id);
            if (deletedColor == null)
            {
                Console.WriteLine("Aradığınız renk bulunamadı.");
                return;
            }
            Console.WriteLine(deletedColor);
        }

        private void ColorIdBusinessRules(int id)
        {
            Color? getByIdColor = colorRepository.GetByID(id);
            if (getByIdColor != null)
            {
                Console.WriteLine($"Girmiş olduğunuz rengin id alanı BENZERSİZ olmalıdır: {id}");
                return;
            }
        }
    }
}
