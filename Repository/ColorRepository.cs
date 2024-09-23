using rentACarSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace rentACarSimulation.Repository
{
    public class ColorRepository
    {
        List<Color> color = new List<Color>()
        {
            new Color(1, "Siyah"),
            new Color(2, "Beyaz"),
            new Color(3, "Kırmızı"),
            new Color(4, "Turkuaz")
        };

        public List<Color> GetAll()
        {
            return color;
        }

        public Color? GetByID(int id)
        {
            Color? colors = null;
            foreach(Color item in color)
            {
                if(item.Id == id)
                {
                    colors = item;
                }
            }
            if(colors == null)
            {
                return null;
            }
            return colors;
        }

        public Color Add(Color added)
        {
            color.Add(added);
            return added;
        }

        public Color? Remove(int id)
        {
            Color? deletedColor = GetByID(id);
            if (deletedColor != null)
            {
                return null;
            }
            color.Remove(deletedColor);
            return deletedColor;
        }

        public Color Update(int id)
        {
            Color updatedColor = GetByID(id);
            if (updatedColor != null)
            {
                return null;
            }
            return updatedColor;
        }
    }

    
}
