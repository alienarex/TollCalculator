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
