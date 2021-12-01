using TollCalculator.Models;

namespace TollCalculator
{
    public interface IVehicle
    {
        TollDay GetCurrentTollDay();
        bool IsVehicleTollFree();

    }
}