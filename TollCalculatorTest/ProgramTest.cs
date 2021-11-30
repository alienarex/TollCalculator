using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollFeeCalculator;
using TollFeeCalculator.Models;
using TollFeeCalculator.Models.VehicleModels;
using TollFeeCalculator.TollFeeCalculatorNET;
using Xunit;

namespace TollFeeCalculatorTest
{
    public class ProgramTest
    {
        readonly List<Vehicle> vehicles = new()
        {
            new Car() { RegistrationNumber = "1" },
            new Motorbike() { RegistrationNumber = "2" },
            new HeavyBus() { RegistrationNumber = "3" },
            new Military() { RegistrationNumber = "4" },
            new Tractor() { RegistrationNumber = "5" },
            new Emergency() { RegistrationNumber = "6" },
            new Car() { RegistrationNumber = "7" },
            new Diplomat() { RegistrationNumber = "8" },
            new Car() { RegistrationNumber = "9" }
        };
        readonly List<DateTime> listOfDates = new()
        {
            new DateTime(2021, 11, 29, 07, 00, 00), // 22
            new DateTime(2021, 11, 29, 07, 15, 00), // 22
            new DateTime(2021, 11, 29, 11, 15, 11), // 9
            new DateTime(2021, 11, 29, 15, 03, 11), // 16
            new DateTime(2021, 11, 29, 17, 03, 11) // 16
        };

        [Fact]
        public void GetFeeFromFirstPassageTollDayMotorbike_ShouldReturn0()
        {
            IVehicle vehicle = new Motorbike();
            int expectedFee = 0;
            DateTime date = new DateTime(2021, 11, 26, 06, 15, 00);
            Program.GetCalculation(vehicle, date);

            Assert.Equal(expectedFee, vehicle.GetCurrentTollDay().Passages[0].Fee);
        }

        [Fact]
        public void GetFeeFromFirstPassageTollDayCar_ShouldReturn9()
        {
            IVehicle vehicle = new Car();
            int expectedFee = 9;
            DateTime date = new DateTime(2021, 11, 26, 06, 15, 00);
            Program.GetCalculation(vehicle, date);

            Assert.Equal(expectedFee, vehicle.GetCurrentTollDay().Passages[0].Fee);
        }

        [Fact]
        public void GetTotalFeeFromFirstCarInList_ShouldReturn60()
        {
            int expectedFee = 60;
            for (int i = 0; i < listOfDates.Count; i++)
            {
                foreach (var veh in vehicles)
                {
                    Program.GetCalculation(veh, listOfDates[i]);
                }
            }
            var vehic = vehicles.Select(x => x).Where(veh => veh.GetVehicleType() == "Car").First();
            Assert.Equal(expectedFee, vehic.GetCurrentTollDay().TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromFirstMotorbikeInList_ShouldReturn0()
        {
            int expectedFee = 0;
            for (int i = 0; i < listOfDates.Count; i++)
            {
                foreach (var veh in vehicles)
                {
                    Program.GetCalculation(veh, listOfDates[i]);
                }
            }
            var vehic = vehicles.Select(x => x).Where(veh => veh.GetVehicleType() == "Motorbike").First();
            Assert.Equal(expectedFee, vehic.GetCurrentTollDay().TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromCar_ShouldReturn22()
        {
            int expectedFee = 22;
            var vehic = vehicles.Select(x => x).Where(veh => veh.GetVehicleType() == "Car").First();
            Program.GetCalculation(vehic, listOfDates[0]);
            Program.GetCalculation(vehic, listOfDates[1]);

            Assert.Equal(expectedFee, vehic.GetCurrentTollDay().TotalFee);
        }

        [Fact]
        public void GetTotalFeeFromCarOnSaturday_ShouldReturn0()
        {
            int expectedFee = 0;
            var vehic = vehicles.Select(x => x).Where(veh => veh.GetVehicleType() == "Car").First();
            vehic.CurrentTollDay = new TollDay(new DateTime(2021, 11, 20));

            Program.GetCalculation(vehic, new DateTime(2021, 11, 20, 07, 00, 00));
            Program.GetCalculation(vehic, new DateTime(2021, 11, 20, 07, 15, 00));
            Program.GetCalculation(vehic, new DateTime(2021, 11, 20, 11, 15, 00));
            Program.GetCalculation(vehic, new DateTime(2021, 11, 20, 15, 03, 11));
            Program.GetCalculation(vehic, new DateTime(2021, 11, 20, 17, 03, 05));

            Assert.Equal(expectedFee, vehic.GetCurrentTollDay().TotalFee);
        }
    }
}
