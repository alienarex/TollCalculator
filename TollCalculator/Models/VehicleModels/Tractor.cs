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
