using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UiManager
    {
        private bool clearScreen;
        private bool quitGarage = false;
        private GarageManager m_GarageManager = new GarageManager();

        public void Run()
        {         
            while (!quitGarage)
            {
                printUserMenu();
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
                        showVehicleFullDetails();
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
            string clientlicenseNumber = string.Empty;
            if (findVehicleBylicenseNumber(ref clientlicenseNumber))
            {
                changeStatus(clientlicenseNumber);
            }
            else
            {
                Console.WriteLine("License number is inncorrect, going back to main menu");
                getUserInput(ref quitGarage);
            }
        }

        private void changeStatus(string clientlicenseNumber)
        {
            eVehicleRepairStatus newStatus;
            Console.WriteLine("Please enter the new status:");
            int menuIndex = 1;

            foreach (var value in Enum.GetValues(typeof(eVehicleRepairStatus)))
            {
                Console.WriteLine("{0}. {1}", menuIndex, value);
                menuIndex++;
            }

            if (Enum.TryParse(Console.ReadLine(), out newStatus))
            {
                try
                {
                    m_GarageManager.setNewStatus(clientlicenseNumber, newStatus);
                }
                catch
                {
                    Console.WriteLine(@"The status you've enterd is invalid.");
                    changeStatus(clientlicenseNumber);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private void inflateVehicleTiresToMax()
        {
            string clientlicenseNumber = string.Empty;
            if (findVehicleBylicenseNumber(ref clientlicenseNumber))
            {
                m_GarageManager.FillWheelsAirPressureToMax(clientlicenseNumber);
            }
            else
            {
                Console.WriteLine("License number is inncorrect, going back to main menu");
                getUserInput(ref quitGarage);
            }
        }

        private void showVehicleFullDetails()
        {
            string license = string.Empty;
            if (findVehicleBylicenseNumber(ref license))
            {
                List<string> details = m_GarageManager.GetVehicleDetails(license);
                foreach (string var in details)
                {
                    Console.WriteLine(var);
                }
            }
        }

        private void printGarageVehiclesLicense()
        {
            int i = 1;
            Console.WriteLine("Please decide which status of vehicle you want to see:");
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
                        Console.WriteLine("Invalid decision, please try again");
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
            //TODO: change the try catch here
            try
            {
                string vehicleLicenseNumber = getParameterDetailFromUser("Please enter your vehicle's license", ParameterValidator.eValidityTypes.All);
                if (!m_GarageManager.IsVehicleInGarage(vehicleLicenseNumber))
                {
                    this.addClientsVehicleToGarage(vehicleLicenseNumber);
                    Console.WriteLine("Client's vehicle was added successfully!");
                }
                else
                {
                    Console.WriteLine("Vehicle is already in the garage.");
                    m_GarageManager.CurrentVehiclesInGarage[vehicleLicenseNumber].VehicleRepairStatus = eVehicleRepairStatus.IN_PROGRESS;
                }
            }
            catch
            {
                Console.WriteLine("Invalid input Please start over!");
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

        private string getParameterDetailFromUser(string i_DetailToAskString, ParameterValidator.eValidityTypes i_ValidiatyToCheck)
        {
            string inputDetails;
            Console.WriteLine(i_DetailToAskString);

            inputDetails = Console.ReadLine();
            ParameterValidator.CheckInputParameterValid(inputDetails, i_ValidiatyToCheck);
            return inputDetails;
        }

        private string getParametersAndCheckRange(string i_DetailToAskString, float i_MinValue, float i_MaxValue)
        {
            string inputDetails;
            Console.WriteLine(i_DetailToAskString);

            inputDetails = Console.ReadLine();
            StringUtils.CheckInputIsInRange(inputDetails, i_MinValue, i_MaxValue);   

            return inputDetails;
        }

        private void addClientsVehicleToGarage(string i_LicenseNumber)
        {
            Dictionary<eVehicleInfoParams, string> vehicleParams;
            string ownerName = getParameterDetailFromUser("Please enter the owner's name:", ParameterValidator.eValidityTypes.LettersOnly);
            string ownerPhoneNumber = getParameterDetailFromUser("Please enter the owner's phone number:", ParameterValidator.eValidityTypes.NumberOnly);

            vehicleParams = getVehicleInfoFromUser(i_LicenseNumber);
            m_GarageManager.AddVehicle(ownerName, ownerPhoneNumber, vehicleParams);
        }

        private Dictionary<eVehicleInfoParams, string> getVehicleInfoFromUser(string i_LicenseNumber)
        {
            VehicleFactory.eVehicleType vehicleType = this.getVehicleTypeFromUser();
            Dictionary<eVehicleInfoParams, string> vehicleParameters = new Dictionary<eVehicleInfoParams, string>
            {
                {eVehicleInfoParams.vehicleType, vehicleType.ToString()},
                {eVehicleInfoParams.modelName, getParameterDetailFromUser(@"Please enter the vehicle's model name:", ParameterValidator.eValidityTypes.All)},
                {eVehicleInfoParams.licenseNumber, i_LicenseNumber},
                {eVehicleInfoParams.energyPercentageLeft, getParametersAndCheckRange(@"Please insert how much energy \ fuel left (0 to 100%) in the vehicle.", GarageManager.k_MinPrecentageValue, GarageManager.k_MaxPrecentageValue)},
                {eVehicleInfoParams.wheelManufactureName, getParameterDetailFromUser("Please enter the wheels' manufacture name:", ParameterValidator.eValidityTypes.All)},
                {eVehicleInfoParams.wheelCurrentAirPressure, getParametersAndCheckRange(@"Please enter the vehicle's current tire's air pressure.", GarageManager.k_MinPrecentageValue, Vehicle.GetMaxAirPressure(vehicleType))}
            };
            Dictionary<eVehicleInfoParams ,ParameterValidator> extraParameterInfo = VehicleFactory.GetSpecificTypeParamsList(vehicleType);

            setExtraVehicleInfo(vehicleParameters, extraParameterInfo);

            return vehicleParameters;
        }

        private void setExtraVehicleInfo(Dictionary<eVehicleInfoParams, string> vehicleParameters, Dictionary<eVehicleInfoParams, ParameterValidator> i_InfoToAsk)
        {
            string inputString;
            foreach(KeyValuePair<eVehicleInfoParams, ParameterValidator> query in i_InfoToAsk)
            {
                inputString = getParameterDetailFromUser(query.Value.InputQuery, query.Value.eValidityType);
                vehicleParameters.Add(query.Key, inputString);
            }
        }

        private VehicleFactory.eVehicleType getVehicleTypeFromUser()
        {
            Console.WriteLine("Please choose vehicle type.");
            printEnumList(new VehicleFactory.eVehicleType());
            string vehicleTypeString = Console.ReadLine();
            VehicleFactory.eVehicleType vehicleType = VehicleFactory.GetVehicleTypeFromStr(vehicleTypeString);
            return vehicleType;
        }

        private static void printEnumList(Enum i_EnumType)
        {
            string[] enumNamesArray = Enum.GetNames(i_EnumType.GetType());
            byte enumIndex = 1;

            foreach (string name in enumNamesArray)
            {
                Console.WriteLine($"{enumIndex}. {name}");
                enumIndex++;
            }
        }

        private bool findVehicleBylicenseNumber(ref string clientlicenseNumber)
        { 
            bool foundLicense = false;
            string[] allVehicleInGarageLicenses = m_GarageManager.ReturnAllGarageVehicles();

            Console.WriteLine("Enter the license number of the vehicle you want to change its status:");
            clientlicenseNumber = Console.ReadLine();
            foreach (string currentlicenseNumber in allVehicleInGarageLicenses)
            {
                if (currentlicenseNumber == clientlicenseNumber)
                {
                    foundLicense = true;
                    break;
                }
            }

            return foundLicense;
        }
    }
}
