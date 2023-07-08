using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        
        protected const string                            k_NewLines = "\n\n";
        protected const string                            k_InvalidInputMessage = "Invalid Input!";

        private readonly List<SpecificQuestionForVehicle> r_SpecificQuestions = new List<SpecificQuestionForVehicle>();
        
        private SpecificAnswerForVehicle                  m_SpecificAnswer = new SpecificAnswerForVehicle();
        private float                                     m_MaxEnergyAmount;
        private float                                     m_MaxAirPressure;
        private int                                       m_NumOfWheels;
        private string                                    m_ModelName;
        private string                                    m_LicenseNumber;
        private float                                     m_EnergyPercentage;
        private List<Wheel>                               m_Wheels = new List<Wheel>();
        private bool                                      m_IsFueled;

        public List<SpecificQuestionForVehicle> SpecificQuestions
        {
            get { return r_SpecificQuestions; }
        }

        public SpecificAnswerForVehicle SpecificAnswer
        {
            get { return m_SpecificAnswer; }
        }

        public float MaxEnergyAmount
        {
            get { return m_MaxEnergyAmount; }
            set { m_MaxEnergyAmount = value; }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }

        public int NumOfWheels
        {
            get
            {
                return m_NumOfWheels;
            }
            set
            {
                m_NumOfWheels = value;
            }
        }

        public string ModelName
        {
            get { return m_ModelName; }

            set
            {
                if ((value.ToString())[0] == ' ')
                {
                    throw new Exception("Invalid Name!" + k_NewLines);
                }

                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }

            set
            {
                if ((value.ToString())[0] == ' ')
                {
                    throw new Exception("Invalid Name!" + k_NewLines);
                }

                m_LicenseNumber = value;
            }
        }

        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }

            set
            {
                if (value < 0)
                {
                    throw new ValueOutOfRangeException(100, 0, $"Energy percentage should be positive" + k_NewLines);
                }
                
                if (value > 100)
                {
                    throw new ValueOutOfRangeException(100, 0, String.Format("Can not exceed {0} {1}",MaxEnergyAmount, m_IsFueled == true ? "litters.\n\n" : "hours.\n\n"));
                }

                m_EnergyPercentage = value;
            }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public bool IsFueled
        {
            get { return m_IsFueled; }
            set { m_IsFueled = value; }
        }


        public abstract void CheckValidationForSpecificDetailsAndSetIfValid(SpecificAnswerForVehicle i_SpecificAnswer);

        public virtual void SetVehicleData(string i_ModelName, string i_LicenseNumber,
                             string i_WheelsManuFacturerName, float i_CurrentWheelsAirPressure)
        {
            ModelName = i_ModelName;
            LicenseNumber = i_LicenseNumber;
            AddWheels(i_WheelsManuFacturerName, i_CurrentWheelsAirPressure);
        }

        protected void AddWheels(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            for (int i = 0; i < NumOfWheels; ++i)
            {
                Wheel wheel = new Wheel(i_ManufacturerName, i_CurrentAirPressure, m_MaxAirPressure);
                Wheels.Add(wheel);
            }
        }

        public override string ToString()
        {
            string message = string.Format("Model Name: {0}\nLicense Number: {1}\nEnergy Percentage: {2:F2}%\n\nWheels Details:\n\n{3}", m_ModelName, m_LicenseNumber, m_EnergyPercentage, m_Wheels[0].ToString());
            return message;
        }
    }
}

