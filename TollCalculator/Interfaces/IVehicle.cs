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