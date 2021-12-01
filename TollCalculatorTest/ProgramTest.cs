using System;
using System.Collections.Generic;
using System.Linq;
using TollCalculator;
using TollCalculator.Models;
using TollCalculator.Models.VehicleModels;
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
        readonly IEnumerable<IVehicle> tollFreeVehicles = new List<Vehicle>
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
            IVehicle vehicle = new Vehicle(TollCalculator.Enums.VehicleType.Motorbike);
            int expectedFee = 0;
            DateTime date = new DateTime(2021, 11, 26, 06, 15, 00);
            Program.GetCalculation(vehicle, date);

            Assert.Equal(expectedFee, vehicle.GetCurrentTollDay().Passages[0].Fee);
        }

        [Fact]
        public void GetFeeFromFirstPassageTollDayCar_ShouldReturn9()
        {
            IVehicle vehicle = new Vehicle(TollCalculator.Enums.VehicleType.Car);
            int expectedFee = 9;
            DateTime date = new DateTime(2021, 11, 26, 06, 15, 00);
            Program.GetCalculation(vehicle, date);

            Assert.Equal(expectedFee, vehicle.GetCurrentTollDay().Passages[0].Fee);
        }

        [Fact]
        public void GetTotalFeeFromCar_ShouldReturn60()
        {
            IVehicle vehicle = new Vehicle(TollCalculator.Enums.VehicleType.Car);
            int expectedFee = 60;

            for (int i = 0; i < listOfDates.Count; i++)
            {
                Program.GetCalculation(vehicle, listOfDates[i]);
            }
            Assert.Equal(expectedFee, vehicle.GetCurrentTollDay().TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromMotorbike_ShouldReturn0()
        {
            IVehicle vehicle = new Vehicle(TollCalculator.Enums.VehicleType.Motorbike);
            int expectedFee = 0;

            for (int i = 0; i < listOfDates.Count; i++)
            {
                Program.GetCalculation(vehicle, listOfDates[i]);
            }
            Assert.Equal(expectedFee, vehicle.GetCurrentTollDay().TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromCar_ShouldReturn22()
        {
            IVehicle vehicle = new Vehicle(TollCalculator.Enums.VehicleType.Car);

            int expectedFee = 22;
            Program.GetCalculation(vehicle, listOfDates[0]);
            Program.GetCalculation(vehicle, listOfDates[1]);

            Assert.Equal(expectedFee, vehicle.GetCurrentTollDay().TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromCarOnSaturday_ShouldReturn0()
        {
            IVehicle vehicle = new Vehicle(TollCalculator.Enums.VehicleType.Car) { CurrentTollDay = new TollDay(new DateTime(2021, 11, 20)) };
            int expectedFee = 0;

            Program.GetCalculation(vehicle, new DateTime(2021, 11, 20, 07, 00, 00));
            Program.GetCalculation(vehicle, new DateTime(2021, 11, 20, 07, 15, 00));
            Program.GetCalculation(vehicle, new DateTime(2021, 11, 20, 11, 15, 00));
            Program.GetCalculation(vehicle, new DateTime(2021, 11, 20, 15, 03, 11));
            Program.GetCalculation(vehicle, new DateTime(2021, 11, 20, 17, 03, 05));

            Assert.Equal(expectedFee, vehicle.GetCurrentTollDay().TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromMilitaryOnSaturday_ShouldReturn0()
        {
            IVehicle vehicle = new Vehicle(TollCalculator.Enums.VehicleType.Military);
            int expectedFee = 0;

            Program.GetCalculation(vehicle, listOfDates[0]);
            Program.GetCalculation(vehicle, listOfDates[1]);

            Assert.Equal(expectedFee, vehicle.GetCurrentTollDay().TotalFee);
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
                    Program.GetCalculation(veh, listOfDates[i]);
                }
                actualFee += veh.GetCurrentTollDay().TotalFee;
            }

            Assert.Equal(expectedFee, actualFee);
        }
    }
}
