using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UiManager
    {      
        private bool quitGarage = false;
        public GarageManager m_GarageManager = new GarageManager(); // change to privte in the end of test

        public void Run()
        {         
            while (!quitGarage)
            {
                Thread.Sleep(2000);
                Console.Clear();
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
            string clientlicenseNumber = string.Empty;
            if (findVehicleBylicenseNumber(ref clientlicenseNumber))
            {
                Console.WriteLine("Please enter number of minutes to charge:");
            }

            float amountTofil;
            if (float.TryParse(Console.ReadLine(), out amountTofil))
            {
                try
                {
                    m_GarageManager.fillElectricVeicle(ref clientlicenseNumber, amountTofil);
                    Console.WriteLine("battery charge successfully");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid type of Enggine to fill - this is not electric enggine");                  
                    Run();
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);                    
                    Run();
                }
            }

            else
            {
                Console.WriteLine("Not a valid Number to fill");                
                Run();
            }
        }

        private void fillFuelVehicle()
        {
            string clientlicenseNumber = string.Empty;
            if (findVehicleBylicenseNumber(ref clientlicenseNumber))
            {          
                Console.WriteLine("Please enter the Gas Type to fill:");
                int menuIndex = 1;

                foreach (var value in Enum.GetValues(typeof(eGasType)))
                {
                    Console.WriteLine("{0}. {1}", menuIndex, value);
                    menuIndex++;
                }

                eGasType gsTypeUserInput;

                if (Enum.TryParse(Console.ReadLine(), out gsTypeUserInput) && Enum.IsDefined(typeof(eGasType), gsTypeUserInput))
                {
                    Console.WriteLine("Please enter the Amount of gas we want to fill:");
                    float amountTofil;
                    if (float.TryParse(Console.ReadLine(), out amountTofil))
                    {
                        try
                        {
                            m_GarageManager.fillgasVeicle(ref clientlicenseNumber, gsTypeUserInput, amountTofil);
                            Console.WriteLine("fill Gas successfully");
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Invalid type of gas to fill");
                            Thread.Sleep(1500);
                            Run();
                        }
                        catch (ValueOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                            
                            Run();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Not a valid Number to fill");
                        
                        Run();
                    }

                }
                else
                {
                    Console.WriteLine("incorrect GasType");
                    Thread.Sleep(1500);
                    Run();
                }

            }

            else
            {
                Console.WriteLine("License number is inncorrect, going back to main menu");              
                Run();
            }
        }

        private void changeVehicleStatus()
        {
            string clientlicenseNumber = string.Empty;
            if (findVehicleBylicenseNumber(ref clientlicenseNumber))
            {
                changeStatus(clientlicenseNumber);
                Console.WriteLine("Changed Status successfully");
            }
            else
            {
                Console.WriteLine("License number is inncorrect, going back to main menu");               
                Run();
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

            if (Enum.TryParse(Console.ReadLine(), out newStatus) && Enum.IsDefined(typeof(eVehicleRepairStatus), newStatus))
            {               
                 m_GarageManager.setNewStatus(clientlicenseNumber, newStatus);                       
            }
            else
            {
                Console.WriteLine("The status you've enterd is invalid.");
                Run();
            }
        }

        private void inflateVehicleTiresToMax()
        {
            string clientlicenseNumber = string.Empty;
            if (findVehicleBylicenseNumber(ref clientlicenseNumber))
            {
                m_GarageManager.FillWheelsAirPressureToMax(clientlicenseNumber);
                Console.WriteLine("Vehicle Tires is set To Maximum!");
            }
            else
            {
                Console.WriteLine("License number is inncorrect, going back to main menu");
                
                Run();
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

                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("License number is inncorrect, going back to main menu");
                Run();
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
            try
            {
                StringUtils.CheckStringConsistsOnlyNumbers(input);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                
                Run();

            }
            int printAllVehicle = 4;          
            if (int.Parse(input) == printAllVehicle)
            {
               printAll();
            }
            else
            {
                eVehicleRepairStatus status;
                if (Enum.TryParse(input, out status) && Enum.IsDefined(typeof(eVehicleRepairStatus), status))
                {
                    printByStatus(status);
                }
                else
                {
                    Console.WriteLine("Invalid decision, please try again");
                    
                    Run();
                }
            }     
        }

        private void printByStatus(eVehicleRepairStatus i_Status)
        {
            string[] vehiclesToPrint = m_GarageManager.returnVehiclesByStatus(i_Status);

            if (vehiclesToPrint == null)
            {
                Console.WriteLine("There are no vehicles of this status in the garage");
                Thread.Sleep(1500);
                Run();
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
                
                Run();
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
            // TODO: change the try catch here
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
                Run();
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
                { eVehicleInfoParams.vehicleType, vehicleType.ToString() },
                { eVehicleInfoParams.modelName, getParameterDetailFromUser(@"Please enter the vehicle's model name:", ParameterValidator.eValidityTypes.All) },
                { eVehicleInfoParams.licenseNumber, i_LicenseNumber },
                { eVehicleInfoParams.energyPercentageLeft, getParametersAndCheckRange(@"Please insert how much energy \ fuel left (0 to 100%) in the vehicle.", GarageManager.k_MinPrecentageValue, GarageManager.k_MaxPrecentageValue) },
                { eVehicleInfoParams.wheelManufactureName, getParameterDetailFromUser("Please enter the wheels' manufacture name:", ParameterValidator.eValidityTypes.All) },
                { eVehicleInfoParams.wheelCurrentAirPressure, getParametersAndCheckRange(@"Please enter the vehicle's current tire's air pressure.", GarageManager.k_MinPrecentageValue, Vehicle.GetMaxAirPressure(vehicleType)) }
            };

            Dictionary<eVehicleInfoParams, ParameterValidator> extraParameterInfo = VehicleFactory.GetSpecificTypeParamsList(vehicleType);

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
     
        private bool findVehicleBylicenseNumber(ref string clientlicenseNumber)
        { 
            bool foundLicense = false;
            string[] allVehicleInGarageLicenses = m_GarageManager.ReturnAllGarageVehicles();

            Console.WriteLine("Enter the license number of the vehicle you want to work with:");
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
