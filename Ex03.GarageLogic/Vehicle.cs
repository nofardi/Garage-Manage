namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private static Wheel[] m_Wheels;
        private string m_ModelName;
        private string m_LicensingNumber;
        private float m_LeftEnergy;       
        private Engine m_Engine;

        public Vehicle(string i_ModelName, string i_LicensingNumber, float i_LeftEnergy, Wheel[] i_Wheels, Engine i_Engine, string i_ManufacturerName, float i_CurrAirpressure, float i_MaxAirPressure)
        {
            m_ModelName = i_ModelName;
            m_LicensingNumber = i_LicensingNumber;
            m_LeftEnergy = i_LeftEnergy;
            m_Engine = i_Engine;
            m_Wheels = i_Wheels;

            for (int currWheel = 0; currWheel < i_Wheels.Length; currWheel++)
            {
                m_Wheels[currWheel] = new Wheel(i_ManufacturerName, i_CurrAirpressure, i_MaxAirPressure);
            }
        }

        public string ModelName => m_ModelName;

        public string LicensingNum => m_LicensingNumber;

        public float LeftEnergy => m_LeftEnergy;

        public Wheel[] Wheels => m_Wheels;

        public Engine Engine => m_Engine;

        public static float GetMaxAirPressure(VehicleFactory.eVehicleType i_VehicleType)
        {
            float maxAirPressure;
            switch (i_VehicleType)
            {
                case VehicleFactory.eVehicleType.Motor:
                case VehicleFactory.eVehicleType.ElectricMotor:
                    maxAirPressure = Motor.k_MaxAirPressure;
                    break;
                case VehicleFactory.eVehicleType.Car:
                case VehicleFactory.eVehicleType.ElectricCar:
                    maxAirPressure = Car.k_MaxAirPressure;
                    break;
                case VehicleFactory.eVehicleType.Truck:
                    maxAirPressure = Truck.k_MaxAirPressure;
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(i_VehicleType), i_VehicleType, null);
            }

            return maxAirPressure;
        }

        public override string ToString()
        {
            return $@"Model name: {m_ModelName}
License number: {m_LicensingNumber}
Wheels' manufacture name: {m_Wheels[0].ManufacturerName}
Wheels' air pressure: {m_Wheels[0].CurrAirpressure}
{m_Engine.ToString()}
Energy percentage left: {m_LeftEnergy}%";
        }    
    }
}
