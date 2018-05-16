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

        private Dictionary<string, VehicleInGarage> m_CurrentVehiclesInGarage;

        public Dictionary<string, VehicleInGarage> CurrentVehiclesInGarage
        {
            get => m_CurrentVehiclesInGarage;
            set => m_CurrentVehiclesInGarage = value;
        }

        public string[] ReturnAllGarageVehicles()
        {
            string[] vehicles = null;

            if (CurrentVehiclesInGarage.Count != 0)
            {
                vehicles = CurrentVehiclesInGarage.Keys.ToArray();
            }

            return vehicles;
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

        public void setNewStatus(string i_clientlicenseNumber, eVehicleRepairStatus i_newStatus)
        {
            m_CurrentVehiclesInGarage[i_clientlicenseNumber].VehicleRepairStatus = i_newStatus;
        }

        public void FillWheelsAirPressureToMax(string i_LicenseNumber)
        {
            Vehicle vehicleToAddPressureToWheels = m_CurrentVehiclesInGarage[i_LicenseNumber].Vehicle;
            foreach (Wheel currentWheel in vehicleToAddPressureToWheels.Wheels)
            {                               
               currentWheel.addAirToWheel(currentWheel.MaxAirPressure - currentWheel.CurrAirpressure);            
            }
        }

        public List<string> GetVehicleDetails(string i_LicenseNumber)
        {
            return m_CurrentVehiclesInGarage[i_LicenseNumber].Vehicle.GetVehicleDetails();
        }

        public string[] returnVehiclesByStatus(eVehicleRepairStatus i_Status)
        {
            int count = 0;
            string[] vehiclesToPrint = null;

            foreach (KeyValuePair<string, VehicleInGarage> pair in m_CurrentVehiclesInGarage)
            {
                if (pair.Value.VehicleRepairStatus == i_Status)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                vehiclesToPrint = new string[count];
                count = 0;
                foreach (KeyValuePair<string, VehicleInGarage> pair in m_CurrentVehiclesInGarage)
                {
                    if (pair.Value.VehicleRepairStatus == i_Status)
                    {
                        vehiclesToPrint[count] = pair.Key;
                        count++;
                    }
                }
            }

            return vehiclesToPrint;
        }

        public void fillgasVeicle(ref string i_clientlicenseNumber, eGasType i_gasTypeUserInput, float i_amountTofil)
        {
            if (m_CurrentVehiclesInGarage[i_clientlicenseNumber].Vehicle.Engine is ElectricEngine)
            {
                throw new FormatException();
            }

            GasEngine gasEngine = (GasEngine)m_CurrentVehiclesInGarage[i_clientlicenseNumber].Vehicle.Engine;

            if (gasEngine.GasType != i_gasTypeUserInput)
            {
                throw new FormatException();
            }

            else
            {
                m_CurrentVehiclesInGarage[i_clientlicenseNumber].Vehicle.Engine.AddEnergyAmount(i_amountTofil);
            }
        }
            
    }   
}
