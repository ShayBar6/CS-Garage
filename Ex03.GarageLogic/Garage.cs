using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using static Ex03.GarageLogic.VehicleInGarage;

namespace Ex03.GarageLogic
{
    public class Garage
    {
       
        private const string                        k_NewLines = "\n\n";

        private readonly List<string>               r_VehiclesTypeNames = new List<string> { "Motorized Car", "Motorized Motorcycle", "Truck", "Electric Car", "Electric Motorcycle" };

        private Dictionary<string, VehicleInGarage> m_Vehicles; 


        public Dictionary<string, VehicleInGarage> Vehicles
        {
            get { return m_Vehicles; }
            set { m_Vehicles = value; }
        }

        public enum eVehiclesType
        {
            MotorizedCar = 1,
            MotorizedMotorcycle,
            Truck,
            ElectricCar,
            ElectricMotorcycle,
        }

        public List<string> VehiclesTypeNames
        {
            get
            {
                return r_VehiclesTypeNames;
            }
        }

        
        public Garage()
        {
            m_Vehicles = new Dictionary<string, VehicleInGarage>();
        }

        public void RemoveVehicle(string i_LicenseNumber)
        {
            m_Vehicles.Remove(i_LicenseNumber);
        }

        public VehicleInGarage GetVehicle(string i_LicenseNumber)
        {
            if (m_Vehicles.ContainsKey(i_LicenseNumber))
            {
                return m_Vehicles[i_LicenseNumber];
            }

            return null;
        }

        public void AddNewVehicle(Vehicle i_vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            VehicleInGarage vehicleInGarage = new VehicleInGarage(i_vehicle, i_OwnerName, i_OwnerPhone, VehicleInGarage.eVehicleState.UnderRepair);

            m_Vehicles.Add(i_vehicle.LicenseNumber, vehicleInGarage);
        }

        public void UpdateVehicleState(string i_LicenseNumber, VehicleInGarage.eVehicleState i_VehicleState)
        {
            VehicleInGarage vehicle = GetVehicle(i_LicenseNumber);

            if (vehicle != null)
            {
                m_Vehicles[i_LicenseNumber].VehicleState = i_VehicleState;
            }

            else
            {
                throw new Exception("Vehicle does not exsist in the garage" + k_NewLines);
            }
        }

        public void InflateWheels(string i_LicenseNumber)
        {
            VehicleInGarage vehicle = GetVehicle(i_LicenseNumber);

            if (vehicle != null)
            {
                List<Wheel> wheels = vehicle.Vehicle.Wheels;

                float maxAirPressure = wheels[0].MaxAirPressure;
                float currentAirPressure = wheels[0].CurrentAirPressure;

                foreach (Wheel wheel in wheels)
                {
                    wheel.Inflate((float)(maxAirPressure - currentAirPressure));
                }
            }

            else
            {
                throw new Exception("Vehicle does not exsist in the garage" + k_NewLines);
            }
        }

        public void Refuel(string i_LicenseNumber, MotorizedVehicle.eFuelType i_FuelType, float i_FuelAmount)
        {
            VehicleInGarage vehicle = GetVehicle(i_LicenseNumber);

            if (vehicle != null)
            {

                MotorizedVehicle motorizedVehicle = vehicle.Vehicle as MotorizedVehicle;

                if (motorizedVehicle != null)
                {
                    motorizedVehicle.Refuel(i_FuelAmount, i_FuelType);
                }

                else
                {
                    throw new Exception("The vehicle is not motorized" + k_NewLines);
                }
            }

            else
            {
                throw new Exception("Vehicle does not exsist in the garage" + k_NewLines);
            }
        }

        public void Charge(string i_LicenseNumber, float i_BatteryTyme)
        {
            VehicleInGarage vehicle = GetVehicle(i_LicenseNumber);

            if (vehicle != null)
            {

                ElectricVehicle electricVehicle = vehicle.Vehicle as ElectricVehicle;

                if (electricVehicle != null)
                {
                    electricVehicle.Charge(i_BatteryTyme);
                }

                else
                {
                    throw new Exception("The vehicle is not electric" + k_NewLines);
                }
            }

            else
            {
                throw new Exception("Vehicle does not exsist in the garage" + k_NewLines);
            }
        }

        public Vehicle CreateNewVehicle(int i_VehicleType)
        {
            Vehicle vehicle = null;

            if (i_VehicleType == (int)eVehiclesType.MotorizedCar)
            {
                vehicle = new MotorizedCar();
            }

            else if (i_VehicleType == (int)eVehiclesType.MotorizedMotorcycle)
            {
                vehicle = new MotorizedMotorcycle();
            }

            else if (i_VehicleType == (int)eVehiclesType.Truck)
            {
                vehicle = new Truck();
            }

            else if (i_VehicleType == (int)eVehiclesType.ElectricCar)
            {
                vehicle = new ElectricCar();
            }

            else if (i_VehicleType == (int)eVehiclesType.ElectricMotorcycle)
            {
                vehicle = new ElectricMotorcycle();
            }

            return vehicle;
        }
    }
}




