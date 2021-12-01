using System;
using TollCalculator.Models;
using TollCalculator.Models.VehicleModels;
using static TollCalculator.TollFeeCalculatorNET.TollFeeCalculator;

namespace TollCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            IVehicle vehicle = new Vehicle(Enums.VehicleType.Car);
            DateTime date = DateTime.Now; // this should come from other system
            GetCalculation(vehicle, date);
            Console.ReadLine();
        }

        public static void GetCalculation(IVehicle vehicle, DateTime date)
        {
            vehicle.GetCurrentTollDay().Passages.Add(new Passage(date));
            if (!vehicle.IsVehicleTollFree() && !vehicle.GetCurrentTollDay().TollFreeDay)
            {
                SetFee(vehicle.GetCurrentTollDay());
            }
        }
    }
}
