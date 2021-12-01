using System;
using TollCalculator.Models;
using TollCalculator.Models.VehicleModels;
using static TollCalculator.TollFeeCalculatorNET.TollFeeCalculator;

namespace TollCalculator
{
    public class Program
    {
        static readonly TollDay tollDay = new(new DateTime(2021, 12, 01));

        static void Main(string[] args)
        {
            Vehicle vehicle = new(Enums.VehicleType.Car) { CurrentTollDay = tollDay };
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
                Console.WriteLine($"The vehicle is a {vehicle.VehicleType} and the fee is {vehicle.CurrentTollDay.TotalFee}");
            }
        }
    }
}
