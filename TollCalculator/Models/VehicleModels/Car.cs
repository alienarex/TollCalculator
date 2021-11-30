using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator.Models.VehicleModels
{
    public class Car : Vehicle
    {
        public Car()
        {
            this.VehicleType = "Car";
            this.IsTollFreeVehicle = false;
        }

    }
}