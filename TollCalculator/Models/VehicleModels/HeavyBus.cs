using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator.Models.VehicleModels
{
    public class HeavyBus : Vehicle
    {
        public HeavyBus()
        {
            this.VehicleType = "HeavyBus";
            this.IsTollFreeVehicle = true;
        }
    }
}
