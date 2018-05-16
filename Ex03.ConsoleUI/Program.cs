using Ex03.GarageLogic; // for the test - DELETE It Before Serve

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            UiManager uiManager = new UiManager();
            /////////////////////////  test
            Wheel wheels1 = new Wheel("rwewr", 20, 40);
            Wheel wheels2 = new Wheel("rwewr", 20, 40);
            Wheel wheels3 = new Wheel("rwewr", 20, 40);
            Wheel wheels4 = new Wheel("rwewr", 20, 40);
            Wheel[] wheels = { wheels1, wheels2, wheels3, wheels4 };
            Engine gas = new GasEngine(eGasType.Octan96, 30, 40);
            Engine electric = new ElectricEngine(50, 33);

            Motor motor = new Motor(eLicenseType.A, 50, "fsdf", "345", 432, wheels, gas, "rewr", 53, 432);
            Car car = new Car(eCarColors.BLACK, eCarDoors.FOUR, "rerete", "123", 20, wheels, gas, "erew", 40, 70);
            Car car2 = new Car(eCarColors.BLUE, eCarDoors.FIVE, "baa", "567", 30, wheels, electric, "rer", 42, 50);
            Truck truck = new Truck(true, 54, "rwe", "789", 25, wheels, gas, "gdds", 30, 50);

            VehicleInGarage vehicleInGarageMotor = new VehicleInGarage("Erez", "052482542", eVehicleRepairStatus.IN_PROGRESS, motor);
            VehicleInGarage vehicleInGarageCar = new VehicleInGarage("nofar", "05244324", eVehicleRepairStatus.IN_PROGRESS, car);
            VehicleInGarage vehicleInGarageCar2 = new VehicleInGarage("C#", "052442134222", eVehicleRepairStatus.IN_PROGRESS, car2);
            VehicleInGarage vehicleInGaragetruck = new VehicleInGarage("Netta barzilai", "0524461111", eVehicleRepairStatus.IN_PROGRESS, truck);

            uiManager.m_GarageManager.CurrentVehiclesInGarage.Add("345", vehicleInGarageMotor);
            uiManager.m_GarageManager.CurrentVehiclesInGarage.Add("123", vehicleInGarageCar);
            uiManager.m_GarageManager.CurrentVehiclesInGarage.Add("567", vehicleInGarageCar2);
            uiManager.m_GarageManager.CurrentVehiclesInGarage.Add("789", vehicleInGaragetruck);
            ////////////////////////// test
            uiManager.Run();                            
        }
    }
}