using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motor : Vehicle
    {
        internal const int k_NumOfWheels = 2;
        internal const float k_MaxAirPressue = 30f;
        internal const eGasType k_GasType = eGasType.Octan96;
        internal const float k_MaxLiterGas = 6f;
        internal const float k_MaxBatteryTime = 1.8f;

        private eLicenseType m_LicenseType;

        private int m_EngineVolume;

        public Motor(eLicenseType i_LicenseType, int i_EngineVolume, string i_ModelName, string i_LicensingNumber, float i_LeftEnergy, Wheel[] i_Wheels, Engine i_Engine, string i_ManufacturerName, float i_CurrAirpressure, float i_MaxAirPressure)
            : base(i_ModelName, i_LicensingNumber, i_LeftEnergy, i_Wheels, i_Engine, i_ManufacturerName, i_CurrAirpressure, i_MaxAirPressure)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }

        public static Dictionary<eVehicleInfoParams, ParameterValidator> BuildExtraParameters()
        {
            Dictionary<eVehicleInfoParams, ParameterValidator> keyValues = new Dictionary<eVehicleInfoParams, ParameterValidator>();
            keyValues.Add(eVehicleInfoParams.licenseType, new ParameterValidator("Please enter your license type:", ParameterValidator.eValidityTypes.LicenseType));
            keyValues.Add(eVehicleInfoParams.engineVolume, new ParameterValidator("Please enter your engine volume", ParameterValidator.eValidityTypes.NumberOnly));

            return keyValues;
        }

        public override string ToString()
        {
            return $@"Motor
{base.ToString()}
License type: {m_LicenseType}
Engine volume: {m_EngineVolume}";
        }       
    }
}
