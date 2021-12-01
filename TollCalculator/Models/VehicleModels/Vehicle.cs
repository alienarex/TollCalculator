using System.Collections.Generic;

namespace TollFeeCalculator.Models.VehicleModels
{
    public class Vehicle : IVehicle
    {
        public Vehicle()
        {
            TollDays = new List<TollDay>();
        }

        #region properties
        public List<TollDay> TollDays { get; set; }

        public string VehicleType { get; set; }
        public TollDay CurrentTollDay
        {
            get; set;
        }
        public string RegistrationNumber
        {
            get;
            set;
        }
        public bool IsTollFreeVehicle { get; protected set; }
        #endregion properties


        public string GetVehicleType()
        {
            return VehicleType;
        }

        public TollDay GetCurrentTollDay()
        {
            CurrentTollDay ??= new TollDay();

            return CurrentTollDay;
        }
        public bool IsVehicleTollFree()
        {
            return IsTollFreeVehicle;
        }

    }
}
