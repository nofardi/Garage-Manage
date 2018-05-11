using System;
namespace B18_Ex03.GarageLogic
{
    public class Wheel
    {
        string m_ManufacturerName;
        float m_CurrAirpressure;
        float m_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrAirpressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrAirpressure = i_CurrAirpressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        //TODO: throw out of range excaption
        public void addAirToWheel(float i_AirToAdd)
        {
            if(m_CurrAirpressure + i_AirToAdd > m_MaxAirPressure)
            {
                m_CurrAirpressure = m_MaxAirPressure;
            }
            else
            {
                m_CurrAirpressure += i_AirToAdd;
            }
        }
    }
}
