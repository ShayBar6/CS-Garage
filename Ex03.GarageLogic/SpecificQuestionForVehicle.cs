using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class SpecificQuestionForVehicle
    {
        
        private string m_Question;
        private string m_VehicleSpecificDataMemberName;

        public string Question
        {
            get { return m_Question; }
            set { m_Question = value; }
        }

        public string VehicleSpecificDataMemberName
        {
            get { return m_VehicleSpecificDataMemberName; }
            set { m_VehicleSpecificDataMemberName = value; }
        }


        public SpecificQuestionForVehicle() { }

        public SpecificQuestionForVehicle(string i_Question, string i_VehicleSpecificDataMemberName)
        {
            m_Question = i_Question;
            m_VehicleSpecificDataMemberName = i_VehicleSpecificDataMemberName;
        }
    }
}
