using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private const string  k_NewLines = "\n\n";

        private Vehicle       m_Vehicle = null;
        private eVehicleState m_VehicleState;
        private string        m_OwnerName;
        private string        m_OwnerPhone;

        public enum eVehicleState
        {
            UnderRepair = 1,
            Repaired,
            Paid
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }

            set
            {
                if ((value.ToString())[0] == ' ')
                {
                    throw new Exception("Invalid Name!" + k_NewLines);
                }

                m_OwnerName = value;
            }
        }

        public string OwnerPhone
        {
            get { return m_OwnerPhone; }

            set
            {
                if ((value.ToString())[0] == ' ')
                {
                    throw new Exception("Invalid Phone!" + k_NewLines);
                }

                m_OwnerPhone = value;
            }
        }

        public eVehicleState VehicleState
        {
            get { return m_VehicleState; }

            set
            {
                if (value != eVehicleState.UnderRepair && value != eVehicleState.Repaired && value != eVehicleState.Paid)
                {
                    throw new Exception("The vehicle state should be one of the following vehicle states: " +
                        $"{eVehicleState.Paid},  {eVehicleState.UnderRepair}, {eVehicleState.Repaired}" + k_NewLines);
                }

                m_VehicleState = value;
            }
        }

       
        public VehicleInGarage() { }

        public VehicleInGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone, eVehicleState i_State)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_VehicleState = i_State;
        }

        public override string ToString()
        {
            string message = string.Format("**** Vheicle & Owner Details ****\n\nOwner Details:\n\nOwner Name: {0}\nOwner Phone: {1}\nVehicle State: {2}\n\n", m_OwnerName, m_OwnerPhone, m_VehicleState);
            return message;
        }
    }
}
