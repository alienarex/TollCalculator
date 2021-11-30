using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator.Models.VehicleModels
{
    public class Tractor : Vehicle
    {
        public Tractor()
        {
            this.VehicleType = "Tractor";
            this.IsTollFreeVehicle = true;
        }
    }
}
