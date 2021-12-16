using Nager.Date;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TollCalculator.Models
{
    public static class Calander
    {
        public static bool IsDateATollFreeMonth(DateTime date)
        {
            return date.Month == 07;
        }

        /// <summary>
        /// Check if today date is a weekend in Sweden.
        /// </summary>
        /// <returns> true if today is a saturday or sunday</returns>
        public static bool IsDateAWeekend(DateTime date)
        {
            return DateSystem.IsWeekend(date, CountryCode.SE);
        }

        /// <summary>
        /// Controls if the date exist in the list of holidays that deviate from regular rules about toll fees.
        /// </summary>
        /// <param name="holidayDate"></param>
        /// <returns>true if the date deviate</returns>
        public static bool IsDeviatedHoliday(DateTime holidayDate)
        {
            DateTime[] deviatedHolidays = { new DateTime(DateTime.Now.Year, 06, 06), new DateTime(DateTime.Now.Year, 12, 24) };
            return deviatedHolidays.Contains(holidayDate);
        }

        /// <summary>
        /// Is today a holiday
        /// </summary>
        /// <returns>true if today is a holiday</returns>
        public static bool IsDateAHoliday(DateTime date)
        {
            return ReturnListOfPublicHolidaysInSweden(date).Contains(date);
        }

        /// <summary>
        /// Gets public holidays in Sweden for current year
        /// </summary>
        /// <returns>IEnumerable<DateTime> holidays</DateTime></returns>
        public static List<DateTime> ReturnListOfPublicHolidaysInSweden(DateTime date)
        {
            var publicHolidays = DateSystem.GetPublicHolidays(date.Year, CountryCode.SE.ToString());

            return publicHolidays.Select(holiday => holiday.Date).ToList();
        }

        /// <summary>
        /// Checks if the day after date exists in Swedish holidays and if the holiday deviate from toll rules.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDateADayBeforeAValidHoliday(DateTime date)
        {
            return ReturnListOfPublicHolidaysInSweden(date).Contains(date.AddDays(1)) && !IsDeviatedHoliday(date.AddDays(1)) == true;
        }
    }
}
