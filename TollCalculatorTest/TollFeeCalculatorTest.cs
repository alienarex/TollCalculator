using System;
using TollFeeCalculator.Models;
using TollFeeCalculator.TollFeeCalculatorNET;
using Xunit;

namespace TollFeeCalculatorTest
{
    public class TollFeeCalculatorTest
    {
        [Fact]
        public void GetFeeForTimeElevenPastEightOnWeekday_ShouldReturn16()
        {
            int expectedFee = 16;
            DateTime date = new DateTime(2021, 11, 26, 08, 11, 00);
            TollDay tollDayTest = new TollDay(date);
            tollDayTest.Passages.Add(new Passage(date));
            TollCalculator.SetFee(tollDayTest);

            Assert.Equal(expectedFee, tollDayTest.TotalFee);
        }

        [Fact]
        public void GetFeeForTime15MinutesPastSixOnWeekday_ShouldReturn9()
        {
            int expectedFee = 9;
            DateTime date = new DateTime(2021, 11, 26, 06, 15, 00);
            TollDay tollDayTest = new TollDay(date);
            tollDayTest.Passages.Add(new Passage(date));
            TollCalculator.SetFee(tollDayTest);

            Assert.Equal(expectedFee, tollDayTest.Passages[0].Fee);
        }

      
    }
}
