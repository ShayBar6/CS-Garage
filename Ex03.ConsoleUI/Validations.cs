using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class Validations
    {
        private const string k_NewLines = "\n\n";
        private const string k_InvalidInputMessage = "Invalid Input!";
        private const string k_InvalidPhoneNumberMessage = "Invalid Phone Number!";
        private const string k_InvalidLicenseNumberMessage = "Invalid License Number!";
        private const string k_InvalidNameMessage = "Invalid Name!";

        public static int GetVehicleType(List<string> i_VehiclesTypeNames)
        {
            int counter = 1, vehicleType = 0;

            Console.WriteLine("Enter your vehicle type, please choose one of the following options:");

            foreach (string vehicleTypeName in i_VehiclesTypeNames)
            {
                Console.WriteLine(counter++ + ". " + vehicleTypeName);
            }

            if (!(int.TryParse(Console.ReadLine(), out vehicleType)))
            {
                Console.WriteLine();
                throw new FormatException(k_InvalidInputMessage + k_NewLines);
            }

            else if (vehicleType < 1 || vehicleType > i_VehiclesTypeNames.Count)
            {
                Console.WriteLine();
                throw new Exception(k_InvalidInputMessage + k_NewLines);
            }

            Console.WriteLine();

            return vehicleType;
        }

        public static float GetCurrentEnergyAmount(bool i_IsFueled, float i_MaxVehicleEnergyAmount)
        {

            float currentEnergyAmount = 0;

            Console.WriteLine(String.Format("Please enter the current {0} amount (Maximum: {1}):",
                    i_IsFueled == true ? "fuel" : "battery", i_MaxVehicleEnergyAmount));

            if (!(float.TryParse(Console.ReadLine(), out currentEnergyAmount)))
            {
                Console.WriteLine();
                throw new FormatException(k_InvalidInputMessage + k_NewLines);
            }

            else
            {
                Console.WriteLine();
                return currentEnergyAmount;
            }
        }

        public static void GetWheelsDetails(ref string io_ManufacturerName, ref float io_CurrentAirPressure, float i_MaxAirPressure)
        {

            Console.WriteLine("Please enter wheel's manufacturer name:");
            io_ManufacturerName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine($"Enter the current air pressure: (Maximum: {i_MaxAirPressure})");

            if (!(float.TryParse(Console.ReadLine(), out io_CurrentAirPressure)))
            {
                Console.WriteLine();
                throw new FormatException(k_InvalidInputMessage + k_NewLines);
            }

            Console.WriteLine();
        }

        public static void GetOwnerDetails(ref string io_OwnerName, ref string io_OwnerPhone)
        {
            Console.WriteLine("Please enter the owner's name:");
            io_OwnerName = Console.ReadLine();
            Console.WriteLine();

            CheckOwnerNameValidation(io_OwnerName);

            Console.WriteLine("Please enter the owner's phone number:");
            io_OwnerPhone = Console.ReadLine();
            Console.WriteLine();

            CheckPhoneNumberValidation(io_OwnerPhone);
        }

        public static bool AskIfDisplayByState()
        {
            int input = 0;
            bool answer = false;
            Console.WriteLine(@"Do you want to display vehicle by their state?
1. Yes
2. No");
            if (!(int.TryParse(Console.ReadLine(), out input)))
            {
                Console.WriteLine();
                throw new FormatException(k_InvalidInputMessage + k_NewLines);
            }

            else if (input != 1 && input != 2)
            {
                Console.WriteLine();
                throw new Exception(k_InvalidInputMessage + k_NewLines);
            }

            else if (input == 1)
            {
                Console.WriteLine();
                answer = true;
            }

            Console.WriteLine();

            return answer;

        }

        public static int GetVehicleState()
        {
            int state = 0;
            Console.WriteLine(@"Please enter the vehicle state, choose one of the following states: 
1. Under Repair
2. Repaired
3. Paid");

            if (!(int.TryParse(Console.ReadLine(), out state)))
            {
                Console.WriteLine();
                throw new FormatException(k_InvalidInputMessage + k_NewLines);
            }

            else if (state > 3 || state < 1)
            {
                Console.WriteLine();
                throw new Exception(k_InvalidInputMessage + k_NewLines);
            }

            else
            {
                Console.WriteLine();
                return state;
            }
        }

        public static void CheckPhoneNumberValidation(string i_PhoneNumber)
        {
            string digitsOnly = new string(i_PhoneNumber.Where(char.IsDigit).ToArray());

            if (digitsOnly.Length == i_PhoneNumber.Length)
            {
                if (digitsOnly.Length == 10)
                {
                    if (digitsOnly[0] != '0')
                    {
                        throw new FormatException(k_InvalidPhoneNumberMessage + k_NewLines);
                    }
                }
                else
                {
                    throw new FormatException(k_InvalidPhoneNumberMessage + k_NewLines);
                }
            }

            else if (digitsOnly.Length == i_PhoneNumber.Length - 1)
            {
                if (digitsOnly.Length != 10 || digitsOnly[0] != '0' || i_PhoneNumber[3] != '-')
                {
                    throw new FormatException(k_InvalidPhoneNumberMessage + k_NewLines);
                }
            }

            else
            {
                throw new FormatException(k_InvalidPhoneNumberMessage + k_NewLines);
            }
        }

        public static void CheckOwnerNameValidation(string i_Name)
        {
            foreach (char c in i_Name)
            {
                if ((!char.IsLetter(c)) && c != ' ')
                {
                    throw new FormatException(k_InvalidNameMessage + k_NewLines);
                }
            }
        }

        public static void CheckLicenseNumberValidation(string i_LicenseNumber)
        {
            string digitsOnly = new string(i_LicenseNumber.Where(char.IsDigit).ToArray());

            if (digitsOnly.Length == i_LicenseNumber.Length)
            {
                if (digitsOnly.Length != 7 && digitsOnly.Length != 8)
                {
                    throw new FormatException(k_InvalidLicenseNumberMessage + k_NewLines);
                }
            }

            else
            {
                throw new FormatException(k_InvalidLicenseNumberMessage + k_NewLines);
            }
        }
    }
}
