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

        public void AddVehicle(string i_OwnerName, string i_OwnerPhoneNumber, Dictionary<eVehicleInfoParams ,string> i_VehicleParametersList)
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
    }

    
}
