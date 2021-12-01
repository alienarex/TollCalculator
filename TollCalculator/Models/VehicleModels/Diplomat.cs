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
