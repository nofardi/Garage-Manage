using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public const string k_InvalidEnumExceptionString = "The input you've entered isn't one of the valid options";
        public const int k_MinPrecentageValue = 0;
        public const int k_MaxPrecentageValue = 100;
        public const int k_MinutesInHour = 60;

        private Dictionary<string, VehicleInGarage> m_CurrentVehiclesInGarage;

        public Dictionary<string, VehicleInGarage> CurrentVehiclesInGarage
        {
            get => m_CurrentVehiclesInGarage;
            set => m_CurrentVehiclesInGarage = value;
        }

        public string[] GetAllGarageLicenses()
        {
            string[] licenses = null;

            if (CurrentVehiclesInGarage.Count != 0)
            {
                licenses = CurrentVehiclesInGarage.Keys.ToArray();
            }

            return licenses;
        }

        public GarageManager()
        {
            m_CurrentVehiclesInGarage = new Dictionary<string, VehicleInGarage>();
        }

        public void AddVehicle(string i_OwnerName, string i_OwnerPhoneNumber, Dictionary<eVehicleInfoParams, string> i_VehicleParametersList)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle(i_VehicleParametersList[eVehicleInfoParams.vehicleType], i_VehicleParametersList);
            VehicleInGarage vehicleInGarage = new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, eVehicleRepairStatus.IN_PROGRESS, vehicle);
            m_CurrentVehiclesInGarage.Add(vehicle.LicensingNum, vehicleInGarage);
        }

        public bool IsVehicleInGarage(string i_LicenseNum)
        {
            return m_CurrentVehiclesInGarage.ContainsKey(i_LicenseNum);      
        }

        public VehicleInGarage GetVehicleByLicense(string i_LicenseNum)
        {
            return m_CurrentVehiclesInGarage[i_LicenseNum];
        }

        public void SetNewStatus(string i_ClientLicenseNumber, eVehicleRepairStatus i_NewStatus)
        {
            m_CurrentVehiclesInGarage[i_ClientLicenseNumber].VehicleRepairStatus = i_NewStatus;
        }

        public void FillWheelsAirPressureToMax(string i_LicenseNumber)
        {
            Vehicle vehicleToAddPressureToWheels = m_CurrentVehiclesInGarage[i_LicenseNumber].Vehicle;
            foreach (Wheel currentWheel in vehicleToAddPressureToWheels.Wheels)
            {                               
               currentWheel.addAirToWheel(currentWheel.MaxAirPressure - currentWheel.CurrAirpressure);            
            }
        }

        public string[] GetLicensesByStatus(eVehicleRepairStatus i_Status)
        {
            int countVehicleWithStat = 0;
            int vehicleIndex = 0;
            string[] licenseToPrint = null;

            foreach (KeyValuePair<string, VehicleInGarage> pair in m_CurrentVehiclesInGarage)
            {
                if (pair.Value.VehicleRepairStatus == i_Status)
                {
                    countVehicleWithStat++;
                }
            }

            if (countVehicleWithStat != 0)
            {
                licenseToPrint = new string[countVehicleWithStat];
                foreach (KeyValuePair<string, VehicleInGarage> pair in m_CurrentVehiclesInGarage)
                {
                    if (pair.Value.VehicleRepairStatus == i_Status)
                    {
                        licenseToPrint[vehicleIndex] = pair.Key;
                        vehicleIndex++;
                    }
                }
            }

            return licenseToPrint;
        }

        public void FillGasVeicle(ref string i_ClientlicenseNumber, eGasType i_gasTypeUserInput, float i_AmountTofil)
        {
            if (m_CurrentVehiclesInGarage[i_ClientlicenseNumber].Vehicle.Engine is ElectricEngine)
            {
                throw new FormatException("Invalid type of Engine to fill - this is not an gas engine");
            }

            GasEngine gasEngine = (GasEngine)m_CurrentVehiclesInGarage[i_ClientlicenseNumber].Vehicle.Engine;

            if (gasEngine.GasType != i_gasTypeUserInput)
            {
                throw new FormatException("Invalid type of gas");
            }
            else
            {
                m_CurrentVehiclesInGarage[i_ClientlicenseNumber].Vehicle.Engine.AddEnergyAmount(i_AmountTofil);
            }
        }

        public void FillElectricVeicle(ref string i_ClientLicenseNumber, float i_AmountTofil)
        {
            if (m_CurrentVehiclesInGarage[i_ClientLicenseNumber].Vehicle.Engine is GasEngine)
            {
                throw new FormatException("Invalid type of Engine to fill - this is not an electric engine");
            }
            else
            {
                int amountTofilInHours = (int)i_AmountTofil / k_MinutesInHour;
                float amountTofilIMinuets = i_AmountTofil % k_MinutesInHour;
                string number = amountTofilInHours + "." + amountTofilIMinuets;
                float amountToAdd = float.Parse(number);

                m_CurrentVehiclesInGarage[i_ClientLicenseNumber].Vehicle.Engine.AddEnergyAmount(amountToAdd);
            }
        }
    }   
}
