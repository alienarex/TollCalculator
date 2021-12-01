using System;
using System.Collections.Generic;
using static TollCalculator.Models.Calander;

namespace TollCalculator.Models
{
    public class TollDay
    {
        public TollDay(DateTime date)
        {
            Passages = new List<Passage>();
            TodayDate = date;
            TollFreeDay = IsTodayATollFreeDay();
            MaxFeeADay = 60; // Current max fee a day
        }

        public TollDay()
        {
            Passages = new List<Passage>();
            TodayDate = DateTime.Today;
            TollFreeDay = IsTodayATollFreeDay();
            MaxFeeADay = 60; // Current max fee a day
        }

        private DateTime todayDate;

        #region Start properties

        public bool TollFreeDay { get; private set; }

        /// <summary>
        /// Max fee a day. Assigned in constructor.
        /// ref: https://www.transportstyrelsen.se/sv/vagtrafik/Trangselskatt/Trangselskatt-i-goteborg/Tider-och-belopp-i-Goteborg/
        /// </summary>
        public static int MaxFeeADay { get; private set; }

        public int TotalFee { get; set; }

        public List<Passage> Passages { get; private set; }

        public DateTime TodayDate
        {
            get { return todayDate; }
            set { todayDate = value; }
        }

        #endregion End properties

        /// <summary>
        /// Checks if TodayDate is a weekend, holiday or day before a valid holiday
        /// </summary>
        /// <returns>true if today is a tollfree day</returns>
        bool IsTodayATollFreeDay()
        {
            if (IsDateAWeekend(TodayDate)) return true;

            if (IsDateADayBeforeAValidHoliday(TodayDate)) return true; // Checks if today is a day before a valid holiday
            if (IsDateAHoliday(TodayDate)) return true;

            else
                return false;
        }


    }
}
