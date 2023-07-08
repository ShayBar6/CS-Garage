using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.ElectricCar;
using static Ex03.GarageLogic.MotorizedCar;

namespace Ex03.GarageLogic
{
    public abstract class MotorizedVehicle : Vehicle
    {

        private float     m_CurrentFuelAmount;
        private float     m_MaxFuelAmount;
        private eFuelType m_FuelType;

        public enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

        public float CurrentFuelAmount
        {
            get { return m_CurrentFuelAmount; }

            set { m_CurrentFuelAmount = value;}
        }
        
        public float MaxFuelAmount
        {
            get { return m_MaxFuelAmount; }

            set
            {
                if (value <= 0)
                {
                    throw new ValueOutOfRangeException(int.MaxValue, 0, "Invalid fuel amount. The fuel amount must be positive." + k_NewLines);
                }

                m_MaxFuelAmount = value;
            }
        }

        public eFuelType FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }


        public override void SetVehicleData(string i_ModelName, string i_LicenseNumber, string i_WheelsManuFacturerName, float i_CurrentWheelsAirPressure)
        {
            base.SetVehicleData(i_ModelName, i_LicenseNumber, i_WheelsManuFacturerName, i_CurrentWheelsAirPressure);
            CurrentFuelAmount = (base.EnergyPercentage / 100) * MaxFuelAmount;
        }

        public void Refuel(float i_Amount, eFuelType i_FuelType)
        {
            if (i_FuelType != FuelType)
            {
                throw new Exception($"Invalid type: {i_FuelType}. This vehicle requires {FuelType} fuel." + k_NewLines);
            }

            if (i_Amount <= 0)
            {
                throw new ValueOutOfRangeException(MaxFuelAmount, 0, "Invalid fuel amount. The amount to refuel must be positive." + k_NewLines);
            }

            if (CurrentFuelAmount + i_Amount > MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(MaxFuelAmount, 0, $"Cannot refuel more than {MaxFuelAmount - CurrentFuelAmount} liters of fuel." + k_NewLines);
            }

            CurrentFuelAmount += i_Amount;
        }

        public override string ToString()
        {
            string message = string.Format(base.ToString() + "General Details:\n\nCurrent Fuel Amount: {0}\nMax Fuel Amout: {1}\nFuel Type: {2}\n", m_CurrentFuelAmount, m_MaxFuelAmount, m_FuelType);
            return message;
        }
    }
}
