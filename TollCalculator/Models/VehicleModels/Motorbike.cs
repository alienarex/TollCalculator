using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator.Models.VehicleModels
{
    public class Motorbike : Vehicle
    {
        public Motorbike()
        {
            this.VehicleType = "Motorbike";
            this.IsTollFreeVehicle = true;
        }
    }
}
