namespace TollFeeCalculator.Models.VehicleModels
{
    public class Motorbike : Vehicle
    {
        public Motorbike()
        {
            this.VehicleType = "Motorbike";
            this.IsTollFreeVehicle = true;
        }
    }
}
