using System.Text;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        internal const int k_NumOfWheels = 12;
        internal const float k_MaxAirPressue = 28f;
        internal const eGasType k_GasType = eGasType.Soler;
        internal const float k_MaxLiterGas = 115f;

        private bool m_IsTrunkCooled;
        private float m_TrunkCapacity;

        public Truck(bool i_IsTrunkCooled, float i_TrunkCapacity, string i_ModelName, string i_LicensingNumber, float i_LeftEnergy, Wheel[] i_Wheels, Engine i_Engine, string i_ManufacturerName, float i_CurrAirpressure, float i_MaxAirPressure)
            : base(i_ModelName, i_LicensingNumber, i_LeftEnergy, i_Wheels, i_Engine, i_ManufacturerName, i_CurrAirpressure, i_MaxAirPressure)
        {
            m_IsTrunkCooled = i_IsTrunkCooled;
            m_TrunkCapacity = i_TrunkCapacity;
        }

        public static Dictionary<eVehicleInfoParams, ParameterValidator> BuildExtraParameters()
        {
            Dictionary<eVehicleInfoParams, ParameterValidator> keyValues = new Dictionary<eVehicleInfoParams, ParameterValidator>();
            keyValues.Add(eVehicleInfoParams.isTrunkCooled, new ParameterValidator("Please enter if trunk is cooled:", ParameterValidator.eValidityTypes.Boolean));
            keyValues.Add(eVehicleInfoParams.trunkCapacity, new ParameterValidator("Please enter your trunk capacity", ParameterValidator.eValidityTypes.NumberOnly));

            return keyValues;
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
