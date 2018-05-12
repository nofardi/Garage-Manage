namespace Ex03.GarageLogic
{
    public class CreatingNewVahicle
    {
        private static Vehicle CreateVehicle(eVehicleType i_VehicleToAdd, string i_LicenseNumber)
        {
            Vehicle newVehicle = null;
            //Engine newEngine = null;

            switch (i_VehicleToAdd)
            {


            }           
                return newVehicle;
       
        }

    
        private enum eVehicleType
        {
            FuelMotorcycle = 1,
            ElectricMotorcycle,
            FuelCar,
            ElectricCar,
            FuelTruck
        }
    }
}
