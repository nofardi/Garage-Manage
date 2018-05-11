using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UiManager
    {
        private bool clearScreen;

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
                        showVehiclesInGarageByLicensesNumber();
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

        private void showVehiclesInGarageByLicensesNumber()
        {
            throw new NotImplementedException();
        }

        private void enterNewVehicle()
        {
            throw new NotImplementedException();
        }

        private void printUserMenu()
        {
            Console.Write(
                @"Welcome to our garage!
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

    }
}
