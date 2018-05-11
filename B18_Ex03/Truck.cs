using System;
namespace B18_Ex03.GarageLogic
{
    public class Truck :Vehicle
    {
        bool m_IsTrunckCooled;
        float m_TrunckCapacity;

        public Truck(bool i_IsTrunckCooled, float i_TrunckCapacity)
        {
            m_IsTrunckCooled = i_IsTrunckCooled;
            m_TrunckCapacity = i_TrunckCapacity;
        }
    }
}
