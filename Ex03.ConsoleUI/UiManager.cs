using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UiManager
    {
        private bool clearScreen;
        GarageManager m_GarageManager = new GarageManager();

        public void Run()
        {
            bool quitGarage = false;
            printUserMenu();
            while (!quitGarage)
            {
                try
                {
                  getUserInput(ref quitGarage);
                }

                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                    Console.WriteLine("Try again:");
                }
            }
        }

        private Enum getUserInput(ref bool io_quitGarage)
        {
            eUserChoice userInput = eUserChoice.ChangeVehicleStatus;
            if (Enum.TryParse(Console.ReadLine(), out userInput)
                   && Enum.IsDefined(typeof(eUserChoice), userInput))
            {
                switch (userInput)
                {
                    case eUserChoice.EnterNewVehicle:
                        enterNewVehicle();
                        break;
                    case eUserChoice.ShowLicenseNumbers:
                        printGarageVehiclesLicense();
                        break;
                    case eUserChoice.ChangeVehicleStatus:
                        changeVehicleStatus();
                        break;
                    case eUserChoice.InflateTiresToMax:
                        inflateVehicleTiresToMax();
                        break;
                    case eUserChoice.FuelVehicle:
                        fillFuelVehicle();
                        break;
                    case eUserChoice.ChargeVehicle:
                        fillElectricSource();
                        break;
                    case eUserChoice.ShowFullDetails:
                        showCarFullDetails();
                        clearScreen = false;
                        break;
                    case eUserChoice.Exit:
                        Console.WriteLine("Thank you for visit Nofar&Erez Garage - Good bye!");
                        io_quitGarage = true;
                        break;                   
                }
            }
            else
            {
                throw new ValueOutOfRangeException(1,8);
            }
         
            return userInput;
        }

        private void fillElectricSource()
        {
            throw new NotImplementedException();
        }

        private void fillFuelVehicle()
        {
            throw new NotImplementedException();
        }

        private void changeVehicleStatus()
        {
            throw new NotImplementedException();
        }

        private void inflateVehicleTiresToMax()
        {
            throw new NotImplementedException();
        }

        private void showCarFullDetails()
        {
            throw new NotImplementedException();
        }

        private void printGarageVehiclesLicense()
        {
            int i = 1;
            Console.WriteLine("please decide which status of vehicle you want to see:");
            foreach (var value in Enum.GetValues(typeof(eVehicleRepairStatus)))
            {
                Console.WriteLine("{0}. {1}", i, value);
                i++;
            }
            Console.WriteLine("{0} All", i);
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out i))
            {
                if (i == 4)
                {
                    printAll();
                }
                else
                {
                    eVehicleRepairStatus status;
                    if (Enum.TryParse(input, out status))
                    {
                        printByStatus(status);
                    }
                    else
                    {
                        Console.WriteLine("invalid decision, please try again");
                        printGarageVehiclesLicense();
                    }
                }
            }
        }
        private void printByStatus(eVehicleRepairStatus i_Status)
        {
            string[] vehiclesToPrint = m_GarageManager.ReturnAllGarageVehicles();

            if (vehiclesToPrint == null)
            {
                Console.WriteLine("There are no vehicles of this status in the garage");
            }
            else
            {
                foreach (string var in vehiclesToPrint)
                {
                    Console.WriteLine(var);
                }              
            }
        }

        private void printAll()
        {
            string[] vehicleKeys = m_GarageManager.ReturnAllGarageVehicles();
            if (vehicleKeys == null)
            {
                Console.WriteLine("There are no vehicles in the garage");             
            }
            else
            {
                foreach (string var in vehicleKeys)
                {
                    Console.WriteLine(var);
                }             
            }
        }

        private void enterNewVehicle()
        {
            try
            {
                //GarageManager.CreatingVehicle(i_VehicleType, i_LicenseNumber);
                
            }
            catch
            {
                Console.WriteLine("Invalid Input Please start over!");
            }
        }

        private void printUserMenu()
        {
            Console.Write(
                @"Welcome to Nofar & Erez garage!
----------------------
Please choose one of the following options:

1. Add a new vehicle to the garage.
2. Show All the licenses numbers.
3. Change a car status.
4. Inflate a vehicle's tires to maximum.
5. Fuel a vehicle.
6. Charge a vehicle's battery.
7. Show a vehicle's full information.
8. Exit.

----------------------
Your choice: ");
        }

        private Dictionary<eVehicleInfoParams, string> getVehicleInfoFromUser()
        {
            return null;
        }

    }
}
