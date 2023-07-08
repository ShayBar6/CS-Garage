using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : MotorizedVehicle
    {

        private const string    k_CarriesHazardousMaterialsTopicName = "Is Carries Hazardous Materials";
        private const string    k_CargoVolumeTopicName = "Cargo Volume";
        private const float     k_MaxFuelAmount = 135f;
        private const float     k_MaxAirPressure = 26f;
        private const int       k_NumOfWheels = 14;
        private const eFuelType k_FuelType = eFuelType.Soler;
        
        private bool            m_CarriesHazardousMaterials;
        private float           m_CargoVolume;

        public bool CarriesHazardousMaterials
        {
            get { return m_CarriesHazardousMaterials; }
            set { m_CarriesHazardousMaterials = value; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set
            {
                if (value < 0)
                {
                    throw new ValueOutOfRangeException(int.MaxValue, 0, "\nInvalid Input!\n\nThe cargo volume must be positive." + k_NewLines);
                }

                m_CargoVolume = value;
            }
        }
      
        public Truck()
        {
            SpecificQuestionForVehicle specificQuestionForTruck1 = new SpecificQuestionForVehicle();
            SpecificQuestionForVehicle specificQuestionForTruck2 = new SpecificQuestionForVehicle();

            specificQuestionForTruck1.Question = string.Format("Enter the cargo volume of the truck: ");
            specificQuestionForTruck1.VehicleSpecificDataMemberName = k_CargoVolumeTopicName;

            SpecificQuestions.Add(specificQuestionForTruck1);

            specificQuestionForTruck2.Question = string.Format(@"Is the truck transporting hazardous materials?
1. Yes
2. No");
            specificQuestionForTruck2.VehicleSpecificDataMemberName = k_CarriesHazardousMaterialsTopicName;

            SpecificQuestions.Add(specificQuestionForTruck2);

            base.FuelType = k_FuelType;
            base.MaxAirPressure = k_MaxAirPressure;
            base.MaxFuelAmount = base.MaxEnergyAmount = k_MaxFuelAmount;
            base.NumOfWheels = k_NumOfWheels;
            IsFueled = true;
        }

        public override void CheckValidationForSpecificDetailsAndSetIfValid(SpecificAnswerForVehicle i_SpecificAnswer)
        {
            if (i_SpecificAnswer.VehicleSpecificDataMemberName == k_CargoVolumeTopicName)
            {
                CheckValidationForCargoVolumeAndSetIfValid(i_SpecificAnswer.Answer);
            }

            else if (i_SpecificAnswer.VehicleSpecificDataMemberName == k_CarriesHazardousMaterialsTopicName)
            {
                CheckValidationForHazardousMaterialsAndSetIfValid(i_SpecificAnswer.Answer);
            }
        }

        public void CheckValidationForHazardousMaterialsAndSetIfValid(string i_Answer)
        {
            int answer = 0;

            if (!(int.TryParse(i_Answer, out answer)))
            {
                throw new FormatException("\n" + k_InvalidInputMessage + k_NewLines);
            }
            else if (answer < 1 || answer > 2)
            {
                throw new Exception("\n" + k_InvalidInputMessage + k_NewLines);
            }

            else if (answer == 1)
            {
                CarriesHazardousMaterials = true;
            }

        }

        public void CheckValidationForCargoVolumeAndSetIfValid(string i_Answer)
        {
            float answer = 0;

            if (!(float.TryParse(i_Answer, out answer)))
            {
                throw new FormatException("\n" + k_InvalidInputMessage + k_NewLines);
            }

            else
            {
                CargoVolume = answer;
            }
        }

        public override string ToString()
        {
            string message = string.Format("--------Truck--------\n\n" + base.ToString() + "Carries Hazardous Materials: {0}\nCargo Volume: {1}\n\n", m_CarriesHazardousMaterials.ToString(), m_CargoVolume);
            return message;
        }
    }
}
