using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class MotorizedCar : MotorizedVehicle
    {
        private const string    k_ColorTopicName = "Color";
        private const string    k_NumberOfDoorsTopicName = "Number Of Doors";
        private const float     k_MaxAirPressure = 33f;
        private const float     k_MaxFuelAmount = 46f;
        private const int       k_NumOfWheels = 5;
        private const eFuelType k_FuelType = eFuelType.Octan95;

        private eColor         m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public enum eColor
        {
            Black = 1,
            White,
            Yellow,
            Red
        }

        public enum eNumberOfDoors
        {
            Two = 1,
            Three,
            Four,
            Five
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }

            set
            {
                if (value != eNumberOfDoors.Two && value != eNumberOfDoors.Three &&
                    value != eNumberOfDoors.Four && value != eNumberOfDoors.Five)
                {
                    throw new ValueOutOfRangeException((int)eNumberOfDoors.Five, (int)eNumberOfDoors.Two,
                        $"\nInvalid Input!\n\nThe amount of doors should be between {eNumberOfDoors.Two} to {eNumberOfDoors.Five}" + k_NewLines);
                }

                m_NumberOfDoors = value;
            }
        }

        public eColor Color
        {
            get { return m_Color; }

            set
            {
                if (value != eColor.Red && value != eColor.Black &&
                   value != eColor.White && value != eColor.Yellow)
                {
                    throw new Exception($"\nInvalid Input!\n\nThe color of the car should be one of the following colors: " +
                        $"{eColor.Red} , {eColor.Black} , {eColor.White} , {eColor.Yellow}" + k_NewLines);
                }

                m_Color = value;
            }
        }

        
        public MotorizedCar()
        {
            SpecificQuestionForVehicle specificQuestionForMotorizedCar1 = new SpecificQuestionForVehicle();
            SpecificQuestionForVehicle specificQuestionForMotorizedCar2 = new SpecificQuestionForVehicle();

            specificQuestionForMotorizedCar1.Question = string.Format(@"Enter the one of the following colors: 
1. Black
2. White
3. Yellow
4. Red");
            specificQuestionForMotorizedCar1.VehicleSpecificDataMemberName = k_ColorTopicName;

            SpecificQuestions.Add(specificQuestionForMotorizedCar1);

            specificQuestionForMotorizedCar2.Question = string.Format(@"Enter the number of doors: 
1. Two
2. Three
3. Four
4. Five");
            specificQuestionForMotorizedCar2.VehicleSpecificDataMemberName = k_NumberOfDoorsTopicName;

            SpecificQuestions.Add(specificQuestionForMotorizedCar2);

            base.FuelType = k_FuelType;
            base.MaxAirPressure = k_MaxAirPressure;
            base.MaxFuelAmount = base.MaxEnergyAmount = k_MaxFuelAmount;
            base.NumOfWheels = k_NumOfWheels;
            base.IsFueled = true;

        }

        public override void CheckValidationForSpecificDetailsAndSetIfValid(SpecificAnswerForVehicle i_SpecificAnswer)
        {
            if (i_SpecificAnswer.VehicleSpecificDataMemberName == k_ColorTopicName)
            {
                CheckValidationForColorAndSetIfValid(i_SpecificAnswer.Answer);
            }

            else if (i_SpecificAnswer.VehicleSpecificDataMemberName == k_NumberOfDoorsTopicName)
            {
                CheckValidationForNumberOfDoorsAndSetIfValid(i_SpecificAnswer.Answer);
            }
        }

        public void CheckValidationForColorAndSetIfValid(string i_Answer)
        {

            int answer = 0;

            if (!(int.TryParse(i_Answer, out answer)))
            {
                throw new FormatException(k_InvalidInputMessage + k_NewLines);
            }
            else
            {
                Color = (eColor)answer;
            }
        }

        public void CheckValidationForNumberOfDoorsAndSetIfValid(string i_Answer)
        {
            int answer = 0;

            if (!(int.TryParse(i_Answer, out answer)))
            {
                throw new FormatException(k_InvalidInputMessage + k_NewLines);
            }

            else
            {
                NumberOfDoors = (eNumberOfDoors)answer;
            }
        }

        public override string ToString()
        {
            string message = string.Format("--------Motorized Car--------\n\n" + base.ToString() + "Color: {0}\nNumber Of Doors: {1}\n\n", m_Color, m_NumberOfDoors);
            return message;
        }
    }
}
