using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator.Models.VehicleModels
{
    public class Military : Vehicle
    {
        public Military()
        {
            this.VehicleType = "Military";
            this.IsTollFreeVehicle = true;
        }

    }
}
