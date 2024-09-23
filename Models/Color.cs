using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentACarSimulation.Models
{
    public class Color
    {
        public Color() { }

        public Color(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}";
        }
    }
}
