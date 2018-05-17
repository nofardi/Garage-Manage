using System;
using System.Collections.Generic;
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
                    Console.Write("Try again!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void printEnumList(Enum i_EnumType)
        {
            string strToPrint = StringUtils.GetEnumListAsString(i_EnumType);
            Console.WriteLine(strToPrint);
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
                        Console.WriteLine("Thank you for visiting Nofar & Erez Garage - Good-bye!");
                        io_quitGarage = true;
                        break;                   
                }
            }
            else
            {
                throw new ValueOutOfRangeException(1, 8);              
            }
         
            return userInput;
        }

        private void fillElectricSource()
        {
            string clientlicenseNumber = string.Empty;
            if (findVehicleByLicenseNumber(ref clientlicenseNumber))
            {
                Console.WriteLine("Please enter amount of minutes to charge:");
            }

            float amountTofil;
            if (float.TryParse(Console.ReadLine(), out amountTofil))
            {
                try
                {
                    m_GarageManager.FillElectricVeicle(ref clientlicenseNumber, amountTofil);
                    Console.WriteLine("Battery charged successfully");
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    return;
                }
                catch (ValueOutOfRangeException valueOutOfRangeeEx)
                {
                    Console.WriteLine(valueOutOfRangeeEx.Message);
                    return;
                }
            }
            else
            {
                Console.WriteLine("Not a valid Number to fill");                
                return;
            }
        }

        private void fillFuelVehicle()
        {
            string clientlicenseNumber = string.Empty;
            eGasType gsTypeUserInput = eGasType.Octan95;
            if (findVehicleByLicenseNumber(ref clientlicenseNumber))
            {          
                Console.WriteLine("Please enter the Gas Type to fill:");
                printEnumList(gsTypeUserInput);

                if (Enum.TryParse(Console.ReadLine(), out gsTypeUserInput) && Enum.IsDefined(typeof(eGasType), gsTypeUserInput))
                {
                    Console.WriteLine("Please enter the Amount of gas you want to fill:");
                    float amountTofil;
                    if (float.TryParse(Console.ReadLine(), out amountTofil))
                    {
                        try
                        {
                            m_GarageManager.FillGasVeicle(ref clientlicenseNumber, gsTypeUserInput, amountTofil);
                            Console.WriteLine("Gas filled successfully");
                        }
                        catch (FormatException fe)
                        {
                            Console.WriteLine(fe.Message);
                            Thread.Sleep(1500);
                            return;
                        }
                        catch (ValueOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not a valid Number to fill");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect gas type");
                    Thread.Sleep(1500);
                    return;
                }
            }
            else
            {
                Console.WriteLine("License number is incorrect, going back to main menu");              
                return;
            }
        }

        private void changeVehicleStatus()
        {
            string clientlicenseNumber = string.Empty;
            if (findVehicleByLicenseNumber(ref clientlicenseNumber))
            {
                changeStatus(clientlicenseNumber);
                Console.WriteLine("Changed Status successfully");
            }
            else
            {
                Console.WriteLine("License number is inncorrect, going back to main menu");               
                return;
            }
        }

        private void changeStatus(string i_ClientLicenseNumber)
        {
            eVehicleRepairStatus newStatus = eVehicleRepairStatus.COMPLETE; // initial value
            Console.WriteLine("Please enter the new status from the menu below:");

            printEnumList(newStatus);

            if (Enum.TryParse(Console.ReadLine(), out newStatus) && Enum.IsDefined(typeof(eVehicleRepairStatus), newStatus))
            {               
                m_GarageManager.SetNewStatus(i_ClientLicenseNumber, newStatus);                       
            }
            else
            {
                Console.WriteLine("The status you've entered is invalid.");
                return;
            }
        }

        private void inflateVehicleTiresToMax()
        {
            string clientlicenseNumber = string.Empty;
            if (findVehicleByLicenseNumber(ref clientlicenseNumber))
            {
                m_GarageManager.FillWheelsAirPressureToMax(clientlicenseNumber);
                Console.WriteLine("Vehicle Tires are set To Maximum!");
            }
            else
            {
                Console.WriteLine("License number is incorrect, going back to main menu");
                return;
            }
        }

        private void showVehicleFullDetails()
        {
            string license = string.Empty;
            if (findVehicleByLicenseNumber(ref license))
            {
                VehicleInGarage vehicle = m_GarageManager.GetVehicleByLicense(license);
                Console.WriteLine(vehicle.ToString());
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("License number is incorrect, going back to main menu");
                return;
            }
        }

        private void printGarageVehiclesLicense()
        {
            eVehicleRepairStatus enumToPrint = eVehicleRepairStatus.COMPLETE;
            Console.WriteLine("Please decide which status of vehicle you want to see:");
            printEnumList(enumToPrint);

            string input = Console.ReadLine();
            try
            {
                StringUtils.CheckStringConsistsOnlyNumbers(input);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);              
                return;
            }

            int printAllVehicle = 4;

            if (int.Parse(input) == printAllVehicle)
            {
                printAllVehicles();
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
                    return;
                }
            }     
        }

        private void printByStatus(eVehicleRepairStatus i_Status)
        {
            string[] licensesToPrint = m_GarageManager.GetLicensesByStatus(i_Status);
            printLicenses(licensesToPrint, "There are no vehicles of this status in the garage");
        }

        private void printAllVehicles()
        {
            string[] vehicleLicenses = m_GarageManager.GetAllGarageLicenses();
            printLicenses(vehicleLicenses, "There are no vehicles in the garage");
        }

        private void printLicenses(string[] i_Licenses, string i_Message)
        {
            if (i_Licenses == null)
            {
                Console.WriteLine(i_Message);
                Thread.Sleep(1500);
                return;
            }
            else
            {
                foreach (string license in i_Licenses)
                {
                    Console.WriteLine(license);
                }
            }
        }

        private void enterNewVehicle()
        {
            try
            {
                string vehicleLicenseNumber = getParameterDetailFromUser("Please enter your vehicle's license", ParameterValidator.eValidityTypes.All);
                if (!m_GarageManager.IsVehicleInGarage(vehicleLicenseNumber))
                {
                    addClientsVehicleToGarage(vehicleLicenseNumber);
                    Console.WriteLine("Client's vehicle was added successfully!");
                }
                else
                {
                    Console.WriteLine("Vehicle is already in the garage.");
                    m_GarageManager.CurrentVehiclesInGarage[vehicleLicenseNumber].VehicleRepairStatus = eVehicleRepairStatus.IN_PROGRESS;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private void printUserMenu()
        {
            Console.Write(
                @"Welcome to Nofar & Erez garage!
----------------------
Please choose one of the following options:

1. Add a new vehicle to the garage.
2. Show vehicle's licenses numbers.
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
            string ownerName = getParameterDetailFromUser("Please enter the owner's name: ", ParameterValidator.eValidityTypes.LettersOnly);
            string ownerPhoneNumber = getParameterDetailFromUser("Please enter the owner's phone number: ", ParameterValidator.eValidityTypes.NumberOnly);

            vehicleParams = getVehicleInfoFromUser(i_LicenseNumber);
            m_GarageManager.AddVehicle(ownerName, ownerPhoneNumber, vehicleParams);
        }

        private Dictionary<eVehicleInfoParams, string> getVehicleInfoFromUser(string i_LicenseNumber)
        {
            VehicleFactory.eVehicleType vehicleType = this.getVehicleTypeFromUser();
            Dictionary<eVehicleInfoParams, string> vehicleParameters = new Dictionary<eVehicleInfoParams, string>
            {
                { eVehicleInfoParams.vehicleType, vehicleType.ToString() },
                { eVehicleInfoParams.modelName, getParameterDetailFromUser(@"Please enter the vehicle's model name: ", ParameterValidator.eValidityTypes.All) },
                { eVehicleInfoParams.licenseNumber, i_LicenseNumber },
                { eVehicleInfoParams.energyPercentageLeft, getParametersAndCheckRange(@"Please insert how much energy \ fuel left (0 to 100%) in the vehicle: ", GarageManager.k_MinPrecentageValue, GarageManager.k_MaxPrecentageValue) },
                { eVehicleInfoParams.wheelManufactureName, getParameterDetailFromUser("Please enter the wheels' manufacture name: ", ParameterValidator.eValidityTypes.All) },
                { eVehicleInfoParams.wheelCurrentAirPressure, getParametersAndCheckRange(@"Please enter the vehicle's current tire's air pressure: ", GarageManager.k_MinPrecentageValue, Vehicle.GetMaxAirPressure(vehicleType)) }
            };

            Dictionary<eVehicleInfoParams, ParameterValidator> extraParameterInfo = VehicleFactory.GetSpecificTypeParamsList(vehicleType);

            setExtraVehicleInfo(vehicleParameters, extraParameterInfo);

            return vehicleParameters;
        }

        private void setExtraVehicleInfo(Dictionary<eVehicleInfoParams, string> io_VehicleParameters, Dictionary<eVehicleInfoParams, ParameterValidator> i_InfoToAsk)
        {
            string inputString;
            foreach(KeyValuePair<eVehicleInfoParams, ParameterValidator> query in i_InfoToAsk)
            {
                inputString = getParameterDetailFromUser(query.Value.InputQuery, query.Value.eValidityType);
                io_VehicleParameters.Add(query.Key, inputString);
            }
        }

        private VehicleFactory.eVehicleType getVehicleTypeFromUser()
        {
            Console.WriteLine("Please choose vehicle type from the menu below: ");
            printEnumList(new VehicleFactory.eVehicleType());
            string vehicleTypeString = Console.ReadLine();
            VehicleFactory.eVehicleType vehicleType = VehicleFactory.GetVehicleTypeFromStr(vehicleTypeString);
            return vehicleType;
        }
     
        private bool findVehicleByLicenseNumber(ref string io_ClientLicenseNumber)
        { 
            bool isLicenseFound = false;

            Console.WriteLine("Enter the license number of the vehicle you want to work with: ");
            io_ClientLicenseNumber = Console.ReadLine();
            isLicenseFound = m_GarageManager.IsVehicleInGarage(io_ClientLicenseNumber);

            return isLicenseFound;
        }
    }
}