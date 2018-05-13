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

        private Dictionary<string, Vehicle> m_CurrentVehiclesInGarage;
        private List<Client> m_CurrentClientsInGarage;

        public Dictionary<string, Vehicle> CurrentVehiclesInGarage
        {
            get => m_CurrentVehiclesInGarage;
            set => m_CurrentVehiclesInGarage = value;
        }

<<<<<<< Updated upstream
        public string[] ReturnAllGarageVehicles()
        {
            string[] vehicles = null;

            if (CurrentVehiclesInGarage.Count != 0)
            {
                vehicles = CurrentVehiclesInGarage.Keys.ToArray();
            }

            return vehicles;
=======
        public GarageManager()
        {
            m_CurrentVehiclesInGarage = new Dictionary<string, Vehicle>();
            m_CurrentClientsInGarage = new List<Client>();
        }

        public void AddVehicle(string i_OwnerName, string i_OwnerPhoneNumber, Dictionary<eVehicleInfoParams ,string> i_VehicleParametersList)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle(i_VehicleParametersList[eVehicleInfoParams.vehicleType], i_VehicleParametersList);
            Client client = new Client(i_OwnerName, i_OwnerPhoneNumber, eVehicleRepairStatus.IN_PROGRESS, vehicle);
            m_CurrentVehiclesInGarage.Add(vehicle.LicensingNum, vehicle);
            m_CurrentClientsInGarage.Add(client);
>>>>>>> Stashed changes
        }
    }

    
}
