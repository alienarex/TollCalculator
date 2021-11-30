using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollFeeCalculator.Models;
using TollFeeCalculator.TollFeeCalculatorNET;
using Xunit;

namespace TollFeeCalculatorTest
{
    public class TollDayTest
    {
        List<DateTime> listOfDates = new()
        {
            new DateTime(2021, 11, 29, 07, 00, 00), // 22
            new DateTime(2021, 11, 29, 07, 15, 00), // 22
            //new DateTime(2021, 11, 29, 11, 15, 11), // 9
            //new DateTime(2021, 11, 29, 15, 03, 11), // 16
            //new DateTime(2021, 11, 29, 17, 03, 11) // 16
        };

        [Fact]
        public void SetFee_ShouldReturnMaxFee()
        {
            int expectedReturnValue = 60;

            TollDay tollDayTest = new(DateTime.Now);
            List<Passage> listOfPassagesTest = new()
            {
                new Passage(new DateTime(2021, 11, 29, 07, 00, 00)), // 22
                new Passage(new DateTime(2021, 11, 29, 09, 00, 00)), // 9
                new Passage(new DateTime(2021, 11, 29, 11, 15, 11)), // 9
                new Passage(new DateTime(2021, 11, 29, 15, 03, 11)), // 16
                new Passage(new DateTime(2021, 11, 29, 17, 03, 11)) // 16
            };
            foreach (var passage in listOfPassagesTest)
            {
                tollDayTest.Passages.Add(passage);
                TollCalculator.SetFee(tollDayTest);
            }

            Assert.Equal(expectedReturnValue, tollDayTest.TotalFee);
        }

        [Fact]
        public void GetTotalFeeWhenPassesLessThenOneHour_ShouldReturn22()
        {
            DateTime today = new(2021, 11, 29);
            TollDay tollDayTest = new(today);
            int expectedReturnValue = 22;

            foreach (var date in listOfDates)
            {
                tollDayTest.Passages.Add(new Passage(date));
                TollCalculator.SetFee(tollDayTest);
            }
            Assert.Equal(expectedReturnValue, tollDayTest.TotalFee);
        }
    }
}