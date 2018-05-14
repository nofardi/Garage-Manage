namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        internal const int k_NumOfWheels = 4;
        internal const float k_MaxAirPressue = 32f;
        internal const eGasType k_GasType = eGasType.Octan98;
        internal const float k_MaxLiterGas = 45f;
        internal const float k_MaxBatteryTime = 3.2f;  

        eCarColors m_CarColor;
        eCarDoors m_AmountOfDoors;
        public Car(eCarColors i_CarsColor, eCarDoors i_AmountOfDoors, string i_ModelName, string i_LicensingNumber, float i_LeftEnergy, Wheel[] i_Wheels, Engine i_Engine,
                   string i_ManufacturerName, float i_CurrAirpressure, float i_MaxAirPressure)
            :base(i_ModelName, i_LicensingNumber, i_LeftEnergy, i_Wheels, i_Engine, i_ManufacturerName, i_CurrAirpressure, i_MaxAirPressure)
        {
            m_CarColor = i_CarsColor;
            m_AmountOfDoors = i_AmountOfDoors;
        }

        public eCarDoors CarDoors => m_AmountOfDoors;
        public eCarColors CarColor => m_CarColor;

        public override string ToString()
        {
            return $@"Car
{base.ToString()}
Car color: {m_CarColor}
Number of doors: {m_AmountOfDoors}";
        }
    }
}
