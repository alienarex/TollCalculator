using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator.Models.VehicleModels
{
    public class Diplomat : Vehicle
    {
        public Diplomat()
        {
            this.VehicleType = "Diplomat";
            this.IsTollFreeVehicle = true;
        }
    }
}
