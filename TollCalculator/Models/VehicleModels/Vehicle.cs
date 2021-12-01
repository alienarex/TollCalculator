using System;
using System.Collections.Generic;
using TollCalculator.Enums;

namespace TollCalculator.Models.VehicleModels
{
    public class Vehicle
    {
        public Vehicle(VehicleType vehicleType)
        {
            VehicleType = vehicleType;
            TollDays = new List<TollDay>();
        }

        public Vehicle()
        {
            TollDays = new List<TollDay>();
        }

        #region properties
        public List<TollDay> TollDays { get; set; }

        //public string VehicleType { get; set; }
        public TollDay CurrentTollDay
        {
            get; set;
        }

        TollDay SetTollDay()
        {
            return CurrentTollDay ?? new TollDay();
        }
        public bool IsTollFreeVehicle => VehicleType switch
        {
            VehicleType.Car => false,
            VehicleType.Motorbike => true,
            VehicleType.Diplomat => true,
            VehicleType.Emergency => true,
            VehicleType.Foreign => false,
            VehicleType.HeavyBus => true,
            VehicleType.LightBus => false,
            VehicleType.Military => true,
            VehicleType.Tractor => true,
            _ => throw new ArgumentOutOfRangeException()
        };

        public VehicleType VehicleType { get; set; }

        #endregion properties

        public bool IsVehicleTollFree()
        {
            return IsTollFreeVehicle;
        }

    }
}
