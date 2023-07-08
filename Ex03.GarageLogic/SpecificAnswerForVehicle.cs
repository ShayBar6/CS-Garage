using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class SpecificAnswerForVehicle
    {
       
        string m_Answer;
        string m_VehicleSpecificDataMemberName;

        public string Answer
        {
            get { return m_Answer; }
            set { m_Answer = value; }
        }

        public string VehicleSpecificDataMemberName
        {
            get { return m_VehicleSpecificDataMemberName; }
            set { m_VehicleSpecificDataMemberName = value; }
        }

    
        public SpecificAnswerForVehicle() { }

        public SpecificAnswerForVehicle(string i_Answer, string i_VehicleSpecificDataMemberName)
        {
            m_Answer = i_Answer;
            m_VehicleSpecificDataMemberName = i_VehicleSpecificDataMemberName;
        }
    }
}
