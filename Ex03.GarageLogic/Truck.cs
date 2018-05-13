using System.Text;
namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        internal const int k_NumOfWheels = 12;
        internal const float k_MaxAirPressue = 28f;
        internal const eGasType k_GasType = eGasType.Soler;
        internal const float k_MaxLiterGas = 115f;

        bool m_IsTrunkCooled;
        float m_TrunkCapacity;

        public Truck(bool i_IsTrunkCooled, float i_TrunkCapacity, string i_ModelName, string i_LicensingNumber, float i_LeftEnergy, Wheel[] i_Wheels, Engine i_Engine, 
                     string i_ManufacturerName, float i_CurrAirpressure, float i_MaxAirPressure)
            :base(i_ModelName, i_LicensingNumber, i_LeftEnergy, i_Wheels, i_Engine, i_ManufacturerName, i_CurrAirpressure, i_MaxAirPressure)
        {
            m_IsTrunkCooled = i_IsTrunkCooled;
            m_TrunkCapacity = i_TrunkCapacity;
        }

        public bool IsTrunkCooled => m_IsTrunkCooled;
        public float TrunkCapacity => m_TrunkCapacity;

        public override string ToString()
        {
            return $@"Truck
{base.ToString()}
Maximum trunk capacity: {m_TrunkCapacity}
Is trunk cooled: {m_IsTrunkCooled}";
        }
    }
}
