using System;
using System.Collections.Generic;
using TollCalculator;
using TollCalculator.Models;
using Xunit;

namespace TollFeeCalculatorTest
{
    public class ProgramTest
    {

        readonly List<DateTime> listOfDates = new()
        {
            new DateTime(2021, 11, 29, 07, 00, 00), // 22
            new DateTime(2021, 11, 29, 07, 15, 00), // 22
            new DateTime(2021, 11, 29, 11, 15, 11), // 9
            new DateTime(2021, 11, 29, 15, 03, 11), // 16
            new DateTime(2021, 11, 29, 17, 03, 11) // 16
        };
        readonly IEnumerable<Vehicle> tollFreeVehicles = new List<Vehicle>
            {
                new Vehicle(TollCalculator.Enums.VehicleType.Military),
                new Vehicle(TollCalculator.Enums.VehicleType.Motorbike),
                new Vehicle(TollCalculator.Enums.VehicleType.Emergency),
                new Vehicle(TollCalculator.Enums.VehicleType.Diplomat),
                new Vehicle(TollCalculator.Enums.VehicleType.HeavyBus),
                new Vehicle(TollCalculator.Enums.VehicleType.Tractor)
            };

        [Fact]
        public void GetFeeFromFirstPassageTollDayMotorbike_ShouldReturn0()
        {
            int expectedFee = 0;
            DateTime passDate = new(2021, 11, 26, 06, 15, 00);
            Vehicle vehicle =
                new(TollCalculator.Enums.VehicleType.Motorbike)
                {
                    CurrentTollDay = new TollDay(listOfDates[0])
                };
            Program.GetCalculation(vehicle, passDate);

            Assert.Equal(expectedFee, vehicle.CurrentTollDay.Passages[0].Fee);
        }

        [Fact]
        public void GetFeeFromFirstPassageTollDayCar_ShouldReturn9()
        {
            Vehicle vehicle =
                new(TollCalculator.Enums.VehicleType.Car)
                {
                    CurrentTollDay = new TollDay(listOfDates[0])
                };

            int expectedFee = 9;
            DateTime date = new DateTime(2021, 11, 26, 06, 15, 00);
            Program.GetCalculation(vehicle, date);

            Assert.Equal(expectedFee, vehicle.CurrentTollDay.Passages[0].Fee);
        }

        [Fact]
        public void GetTotalFeeFromCar_ShouldReturn60()
        {
            int expectedFee = 60;
            Vehicle vehicle =
                     new(TollCalculator.Enums.VehicleType.Car)
                     {
                         CurrentTollDay = new TollDay(listOfDates[0])
                     };

            for (int i = 0; i < listOfDates.Count; i++)
            {
                Program.GetCalculation(vehicle, listOfDates[i]);
            }
            Assert.Equal(expectedFee, vehicle.CurrentTollDay.TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromMotorbike_ShouldReturn0()
        {
            int expectedFee = 0;
            Vehicle vehicle =
                  new(TollCalculator.Enums.VehicleType.Motorbike)
                  {
                      CurrentTollDay = new TollDay(listOfDates[0])
                  };

            for (int i = 0; i < listOfDates.Count; i++)
            {
                Program.GetCalculation(vehicle, listOfDates[i]);
            }
            Assert.Equal(expectedFee, vehicle.CurrentTollDay.TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromCar_ShouldReturn22()
        {
            int expectedFee = 22;
            Vehicle vehicle =
                  new(TollCalculator.Enums.VehicleType.Car)
                  {
                      CurrentTollDay = new TollDay(listOfDates[0])
                  };

            Program.GetCalculation(vehicle, listOfDates[0]);
            Program.GetCalculation(vehicle, listOfDates[1]);

            Assert.Equal(expectedFee, vehicle.CurrentTollDay.TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromCarOnSaturday_ShouldReturn0()
        {
            int expectedFee = 0;
            Vehicle vehicle =
                new(TollCalculator.Enums.VehicleType.Car)
                {
                    CurrentTollDay = new TollDay(new DateTime(2021, 11, 20)) // dare is a saturday
                };

            Program.GetCalculation(vehicle, new DateTime(2021, 11, 20, 07, 00, 00));
            Program.GetCalculation(vehicle, new DateTime(2021, 11, 20, 07, 15, 00));
            Program.GetCalculation(vehicle, new DateTime(2021, 11, 20, 11, 15, 00));
            Program.GetCalculation(vehicle, new DateTime(2021, 11, 20, 15, 03, 11));
            Program.GetCalculation(vehicle, new DateTime(2021, 11, 20, 17, 03, 05));

            Assert.Equal(expectedFee, vehicle.CurrentTollDay.TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromMilitaryOnSaturday_ShouldReturn0()
        {
            int expectedFee = 0;
            Vehicle vehicle =
                  new(TollCalculator.Enums.VehicleType.Military)
                  {
                      CurrentTollDay = new TollDay(new DateTime(2021, 11, 20)) // dare is a saturday
                  };

            Program.GetCalculation(vehicle, listOfDates[0]);
            Program.GetCalculation(vehicle, listOfDates[1]);

            Assert.Equal(expectedFee, vehicle.CurrentTollDay.TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromAllTollFreeVehicles_ShouldReturn0()
        {

            int expectedFee = 0;
            int actualFee = 0;

            foreach (var veh in tollFreeVehicles)
            {
                for (int i = 0; i < listOfDates.Count; i++)
                {
                    veh.CurrentTollDay = new TollDay(listOfDates[0]);
                    Program.GetCalculation(veh, listOfDates[i]);
                }
                actualFee += veh.CurrentTollDay.TotalFee;
            }

            Assert.Equal(expectedFee, actualFee);
        }
    }
}
