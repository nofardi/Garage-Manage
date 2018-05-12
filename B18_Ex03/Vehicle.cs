using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_ModelName;
        string m_LicensingNumber;
        float m_LeftEnergy;
        List<Wheel> m_Wheels;

        public Vehicle()
        {
        }
    }
}
