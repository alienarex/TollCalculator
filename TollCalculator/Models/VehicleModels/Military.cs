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
