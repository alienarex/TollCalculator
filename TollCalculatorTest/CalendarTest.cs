using System;
using Xunit;

namespace TollFeeCalculatorTest
{
    public class CalendarTest
    {

        [Fact]
        public void IsDateAHoliday_ShouldReturnFalse()
        {
            DateTime testDate = new DateTime(2021, 04, 03, 08, 11, 00);
            bool isDayAWeekend = TollCalculator.Models.Calander.IsDateAHoliday(testDate);

            Assert.False(isDayAWeekend);
        }

        [Fact]
        public void IsDayAHoliday_ShouldReturnTrue()
        {
            DateTime testDate = new DateTime(2020, 12, 25);
            bool isDayAWeekend = TollCalculator.Models.Calander.IsDateAHoliday(testDate);

            Assert.True(isDayAWeekend);
        }

        [Fact]
        public void IsDayAWeekend_ShouldReturnFalse()
        {
            DateTime testDate = new DateTime(2021, 11, 26, 08, 11, 00);
            bool isDayAWeekend = TollCalculator.Models.Calander.IsDateAWeekend(testDate);

            Assert.False(isDayAWeekend);
        }

        [Fact]
        public void IsDayAWeekend_ShouldReturnTrue()
        {
            DateTime testDate = new DateTime(2021, 11, 20, 08, 11, 00);
            bool isDayAWeekend = TollCalculator.Models.Calander.IsDateAWeekend(testDate);

            Assert.True(isDayAWeekend);
        }

        [Fact]
        public void IsDateADayBeforeValidHoliday_ShouldReturnTrue()
        {
            DateTime testDate = new DateTime(2021, 06, 24);
            bool isDayBefforeValidDay = TollCalculator.Models.Calander.IsDateADayBeforeAValidHoliday(testDate);

            Assert.True(isDayBefforeValidDay);
        }

        [Fact]
        public void IsDateADayBeforeValidHoliday_ShouldReturnFalse()
        {
            DateTime testDate = new DateTime(2021, 12, 23, 08, 11, 00);
            bool isDayBefforeValidDay = TollCalculator.Models.Calander.IsDateADayBeforeAValidHoliday(testDate);

            Assert.False(isDayBefforeValidDay);
        }
    }
}
