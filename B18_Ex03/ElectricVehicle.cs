using System;
namespace B18_Ex03
{
    public class ElectricVehicle
    {
        float m_BatteryHoursLeft;
        float m_MaxBatteryHours;

        public ElectricVehicle(float i_BatteryHoursLeft, float i_MaxBatteryHours)
        {
            m_BatteryHoursLeft = i_BatteryHoursLeft;
            m_MaxBatteryHours = i_MaxBatteryHours;
        }

        //TODO: throw out of range excaption
        public void PowerBattery(float i_HoursToAdd)
        {
            if(m_BatteryHoursLeft + i_HoursToAdd > m_MaxBatteryHours)
            {
                m_BatteryHoursLeft = m_MaxBatteryHours;
            }
            else
            {
                m_BatteryHoursLeft += i_HoursToAdd;
            }
        }
    }
}
