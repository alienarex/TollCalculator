using System;

namespace TollCalculator.Models
{
    public class Passage
    {
        public Passage(DateTime newPassageTime)
        {
            TimeOfPassage = newPassageTime;
        }

        public DateTime TimeOfPassage { get; private set; }

        public int Fee { get; set; }

    }
}