using System.Collections.Generic;
using System;
namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public enum eVehicleType
        {
            Motor = 1,
            ElectricMotor = 2,
            Car = 3,
            ElectricCar = 4,
            Truck = 5
        }

        public static Vehicle CreateVehicle(string i_VehicleTypeString, Dictionary<eVehicleInfoParams, string> i_VehicleParameters)
        {
            Vehicle vehicle;
            eVehicleType vehicleType = GetVehicleTypeFromStr(i_VehicleTypeString);
            switch (vehicleType)
            {
                case eVehicleType.Motor:
                    vehicle = createMotor(createFuelEngine(Motor.k_GasType, Motor.k_MaxLiterGas), i_VehicleParameters);
                    break;
                case eVehicleType.ElectricMotor:
                    vehicle = createMotor(createElectricEngine(Motor.k_MaxBatteryTime), i_VehicleParameters);
                    break;
                case eVehicleType.Car:
                    vehicle = createCar(createFuelEngine(Car.k_GasType, Car.k_MaxLiterGas), i_VehicleParameters);
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = createCar(createElectricEngine(Car.k_MaxBatteryTime), i_VehicleParameters);
                    break;
                case eVehicleType.Truck:
                    vehicle = createTruck(createFuelEngine(Truck.k_GasType, Truck.k_MaxLiterGas),i_VehicleParameters);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

           // setCurrentEnergyQuantity(vehicle);
            return vehicle;
        }

        public static eVehicleType GetVehicleTypeFromStr(string i_VehicleTypeString)
        {
            eVehicleType vehicleType;
            if (!Enum.TryParse(i_VehicleTypeString, out vehicleType)
                || !Enum.IsDefined(typeof(eVehicleType), vehicleType))
            {
                throw new ArgumentException(GarageManager.k_InvalidEnumExceptionString);
            }

            return vehicleType;
        }

        private static Vehicle createMotor(Engine i_Engine, Dictionary<eVehicleInfoParams ,string> i_VehicleParameters)
        {
            string modelName;
            string licenseNumber;
            float energyPercentageLeft;
            string wheelManufactureName;
            float wheelCurrentAirPressure;
            int engineVolume;

            eLicenseType licenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_VehicleParameters[eVehicleInfoParams.licenseType]);
            engineVolume = int.Parse(i_VehicleParameters[eVehicleInfoParams.engineVolume]);

            getVehicleParameters(
                i_VehicleParameters,
                out modelName,
                out licenseNumber,
                out energyPercentageLeft,
                out wheelManufactureName,
                out wheelCurrentAirPressure);
            

            Motor motor = new Motor(licenseType, engineVolume, modelName, licenseNumber, energyPercentageLeft, new Wheel[Motor.k_NumOfWheels],
                                    i_Engine, wheelManufactureName, wheelCurrentAirPressure, Motor.k_MaxAirPressue);
                
            return motor;
        }

        private static Vehicle createCar(Engine i_Engine, Dictionary<eVehicleInfoParams, string> i_VehicleParameters)
        {
            string modelName;
            string licenseNumber;
            float energyPercentageLeft;
            string wheelManufactureName;
            float wheelCurrentAirPressure;

            eCarColors carColor = (eCarColors)Enum.Parse(typeof(eCarColors), i_VehicleParameters[eVehicleInfoParams.carColor]);
            eCarDoors carDoors = (eCarDoors)Enum.Parse(typeof(eCarDoors), i_VehicleParameters[eVehicleInfoParams.carDoors]);

            getVehicleParameters(
                i_VehicleParameters,
                out modelName,
                out licenseNumber,
                out energyPercentageLeft,
                out wheelManufactureName,
                out wheelCurrentAirPressure);

            Car car = new Car(carColor, carDoors, modelName, licenseNumber, energyPercentageLeft, new Wheel[Car.k_NumOfWheels],
                              i_Engine, wheelManufactureName, wheelCurrentAirPressure, Car.k_MaxAirPressue);
            return car;
        }

        private static Vehicle createTruck(Engine i_Engine ,Dictionary<eVehicleInfoParams, string> i_VehicleParameters)
        {
            string modelName;
            string licenseNumber;
            float energyPercentageLeft;
            string wheelManufactureName;
            float wheelCurrentAirPressure;

            bool isTrunkCooled = Boolean.Parse(i_VehicleParameters[eVehicleInfoParams.isTrunkCooled]);
            float trunkCapacity = Single.Parse(i_VehicleParameters[eVehicleInfoParams.trunkCapacity]);

            getVehicleParameters(
                i_VehicleParameters,
                out modelName,
                out licenseNumber,
                out energyPercentageLeft,
                out wheelManufactureName,
                out wheelCurrentAirPressure);

            Truck truck = new Truck(isTrunkCooled, trunkCapacity, modelName, licenseNumber, energyPercentageLeft, new Wheel[Truck.k_NumOfWheels],
                                    i_Engine ,wheelManufactureName, wheelCurrentAirPressure, Truck.k_MaxAirPressue);
            return truck;
        }

        private static Engine createFuelEngine(eGasType i_GasType, float i_MaxTankCapacity)
        {
            return new GasEngine(i_GasType, i_MaxTankCapacity, i_MaxTankCapacity);
        }

        private static Engine createElectricEngine(float i_MaxBatteryHours)
        {
            return new ElectricEngine(i_MaxBatteryHours, i_MaxBatteryHours);
        }

        private static void getVehicleParameters(Dictionary<eVehicleInfoParams, string> i_VehicleParametersStrings, out string o_ModelName, out string o_LicenseNumber,
                                                out float o_EnergyPercentageLeft, out string o_WheelManufactureName, out float o_WheelCurrentAirPressure)
        {
            o_ModelName = i_VehicleParametersStrings[eVehicleInfoParams.modelName];
            o_LicenseNumber = i_VehicleParametersStrings[eVehicleInfoParams.licenseNumber];
            o_EnergyPercentageLeft = Single.Parse(i_VehicleParametersStrings[eVehicleInfoParams.energyPercentageLeft]);
            o_WheelManufactureName = i_VehicleParametersStrings[eVehicleInfoParams.wheelManufactureName];
            o_WheelCurrentAirPressure = Single.Parse(i_VehicleParametersStrings[eVehicleInfoParams.wheelCurrentAirPressure]);
        }


    }
}
