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
            Vehicle vehicle = new(Enums.VehicleType.Car);
            DateTime date = DateTime.Now; // this should come from other system
            GetCalculation(vehicle, date);
            Console.ReadLine();
        }

        public static void GetCalculation(Vehicle vehicle, DateTime date)
        {
            vehicle.CurrentTollDay.Passages.Add(new Passage(date));
            if (!vehicle.IsTollFreeVehicle && !vehicle.CurrentTollDay.TollFreeDay)
            {
                SetFee(vehicle.CurrentTollDay);
            }
        }
    }
}
