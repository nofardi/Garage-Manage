using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        internal const int k_NumOfWheels = 4;
        internal const float k_MaxAirPressure = 32f;
        internal const eGasType k_GasType = eGasType.Octan98;
        internal const float k_MaxLiterGas = 45f;
        internal const float k_MaxBatteryTime = 3.2f;

        private eCarColors m_CarColor;
        private eCarDoors m_AmountOfDoors;

        public Car(eCarColors i_CarsColor, eCarDoors i_AmountOfDoors, string i_ModelName, string i_LicensingNumber, float i_LeftEnergy, Wheel[] i_Wheels, Engine i_Engine, string i_ManufacturerName, float i_CurrAirPressure, float i_MaxAirPressure)
            : base(i_ModelName, i_LicensingNumber, i_LeftEnergy, i_Wheels, i_Engine, i_ManufacturerName, i_CurrAirPressure, i_MaxAirPressure)
        {
            m_CarColor = i_CarsColor;
            m_AmountOfDoors = i_AmountOfDoors;
        }

        public static Dictionary<eVehicleInfoParams, ParameterValidator> BuildExtraParameters()
        {
            StringBuilder strToPrint = new StringBuilder();
            eCarColors carColor = eCarColors.BLACK;
            eCarDoors carDoors = eCarDoors.FIVE;
            Dictionary<eVehicleInfoParams, ParameterValidator> keyValues = new Dictionary<eVehicleInfoParams, ParameterValidator>();
            strToPrint.AppendLine("Please enter your car color: ");
            strToPrint.Append(StringUtils.GetEnumListAsString(carColor));
            keyValues.Add(eVehicleInfoParams.carColor, new ParameterValidator(strToPrint.ToString(), ParameterValidator.eValidityTypes.CarColor));
            strToPrint.Clear();
            strToPrint.AppendLine("Please enter your number of doors: ");
            strToPrint.Append(StringUtils.GetEnumListAsString(carDoors));
            keyValues.Add(eVehicleInfoParams.carDoors, new ParameterValidator(strToPrint.ToString(), ParameterValidator.eValidityTypes.DoorNumber));

            return keyValues;
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
