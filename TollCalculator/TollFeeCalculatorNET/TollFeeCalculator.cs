using System;
using TollCalculator.Models;

namespace TollCalculator.TollFeeCalculatorNET
{
    public static class TollFeeCalculator
    {

        /// <summary>
        /// Calulates time between last and current passage
        /// </summary>
        /// <param name="currentPassage"></param>
        static double GetTimeDifferences(DateTime lastPassage, DateTime currentPassage)
        {
            return currentPassage.Subtract(lastPassage).TotalSeconds;
        }

        /// <summary>
        /// Sets fee after controlling time differences and
        /// </summary>
        public static void SetFee(TollDay currentTollDay)
        {
            if (currentTollDay.TotalFee != TollDay.MaxFeeADay) // continue only if necessary
            {
                var currentPass = currentTollDay.Passages[^1];
                currentPass.Fee = GetTollFee(currentPass.TimeOfPassage);
                double oneHourInSeconds = 3600;

                if (currentTollDay.Passages.Count > 1)
                {
                    var secondToLastPass = currentTollDay.Passages[^2];
                    var diff = GetTimeDifferences(secondToLastPass.TimeOfPassage, currentPass.TimeOfPassage);

                    if (diff < oneHourInSeconds && currentPass.Fee >= secondToLastPass.Fee)
                    {
                        currentTollDay.TotalFee -= secondToLastPass.Fee;
                    }
                }

                currentTollDay.TotalFee += currentPass.Fee;
                if (currentTollDay.TotalFee >= TollDay.MaxFeeADay)
                {
                    currentTollDay.TotalFee = TollDay.MaxFeeADay;
                }
            }
        }

        /// <summary>
        /// Calculate the toll for the current time and date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Cost for that passage</returns>
        private static int GetTollFee(DateTime date)
        {
            int hour = date.Hour;
            int minute = date.Minute;

            if (hour == 6 && minute < 30) return 9;

            else if (hour == 6 && minute > 29) return 16;

            else if (hour == 7) return 22;

            else if (hour == 8 && minute < 30) return 16;

            else if (hour >= 8 && hour <= 14) return 9;

            else if (hour == 15 && minute < 30) return 16;

            else if (hour >= 15 && hour < 17) return 22;

            else if (hour == 17) return 16;

            else if (hour == 18 && minute < 30) return 9;

            else return 0;
        }
    }
}