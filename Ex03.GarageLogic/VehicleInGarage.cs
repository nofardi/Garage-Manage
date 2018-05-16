using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleRepairStatus m_VehicleRepairStatus;
        private Vehicle m_Vehicle;

        public string OwnerName
        {
            get => m_OwnerName;
            set => m_OwnerName = value;
        }

        public string OwnerPhoneNumber
        {
            get => m_OwnerPhoneNumber;
            set => m_OwnerPhoneNumber = value;
        }

        public eVehicleRepairStatus VehicleRepairStatus
        {
            get => m_VehicleRepairStatus;
            set => m_VehicleRepairStatus = value;
        }

        public Vehicle Vehicle
        {
            get => m_Vehicle;
            set => m_Vehicle = value;
        }

        public VehicleInGarage(string i_OwnerName, string i_OwnerPhoneNumber, eVehicleRepairStatus i_VehicleStatus, Vehicle i_Vehicle)
        {
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleRepairStatus = i_VehicleStatus;
            m_Vehicle = i_Vehicle;
        }

        public override string ToString()
        {
            return $@"Owner's name: {m_OwnerName}
Owner's phone number: {m_OwnerPhoneNumber}
Vehicle status: {m_VehicleRepairStatus}
Vehicle type: {m_Vehicle}
 
";
        }

    }
}
