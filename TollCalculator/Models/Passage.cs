using System;

namespace TollFeeCalculator.Models
{
    public class Passage
    {
        public Passage(DateTime newPassageTime)
        {
            TimeOfPassage = newPassageTime;
        }
        private DateTime timeOfPassage;

        public DateTime TimeOfPassage
        {
            get { return timeOfPassage; }
            private set { timeOfPassage = value; }
        }

        private int fee;

        public int Fee
        {
            get { return fee; }
            set { fee = value; }
        }

    }
}