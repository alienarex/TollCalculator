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