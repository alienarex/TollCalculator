namespace TollFeeCalculator.Models.VehicleModels
{
    public class Emergency : Vehicle
    {
        public Emergency()
        {
            this.VehicleType = "Emergency";
            this.IsTollFreeVehicle = true;
        }
    }
}
