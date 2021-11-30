using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollFeeCalculator.Models;

namespace TollFeeCalculator
{
    public interface IVehicle
    {
        string VehicleType { get; set; }
        string GetVehicleType();
        TollDay GetCurrentTollDay();
        bool IsVehicleTollFree();

    }
}