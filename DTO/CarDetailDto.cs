using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentACarSimulation.DTO
{
    public record CarDetailDto 
        (
        int Id,
        string FuelName,    
        string TransmissionName,
        string ColorName,
        string CarState,
        int KiloMeter,
        int ModelYear,
        string Plate,
        string BrandName,
        string ModelName,
        double DailyPrice

        )
    {
        //public int Id { get; set; }
        //public string? FuelName { get; set; }
        //public string? TransmissionName { get; set; }
        //public string? ColorName { get; set; }
        //public string CarState { get; set; }
        //public int? KiloMeter { get; set; }
        //public short? ModelYear { get; set; }
        //public string? Plate { get; set; }
        //public string? BrandName { get; set; }
        //public string? ModelName { get; set; }
        //public double? DailyPrice { get; set; }

    }
}
