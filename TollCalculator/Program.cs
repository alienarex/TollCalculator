using System;
using TollFeeCalculator.Models;
using TollFeeCalculator.Models.VehicleModels;
using TollFeeCalculator.TollFeeCalculatorNET;

namespace TollFeeCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            IVehicle vehicle = new Car();
            DateTime date = DateTime.Now; // this should come from other system
            GetCalculation(vehicle, date);
            Console.ReadLine();
        }

        public static void GetCalculation(IVehicle vehicle, DateTime date)
        {
            vehicle.GetCurrentTollDay().Passages.Add(new Passage(date));
            if (!vehicle.IsVehicleTollFree() && !vehicle.GetCurrentTollDay().TollFreeDay)
            {
                TollCalculator.SetFee(vehicle.GetCurrentTollDay());
            }
        }
    }
}
