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

        public List<string> GetVehicleDetails(string i_LicenseNumber)
        {
            List<string> details = new List<string>();

            details.Add(string.Format("License number:{0} ", Vehicle.LicensingNum.ToString()));
            details.Add(string.Format("Name of model:{0} ", Vehicle.ModelName.ToString()));         
            details.Add(string.Format("Owners name:{0} ",OwnerName.ToString()));
            details.Add(string.Format("Owners phone:{0} ", OwnerPhoneNumber.ToString()));
            details.Add(string.Format("Wheels current air pressure:{0}", Vehicle.Wheels[0].CurrAirpressure.ToString()));
            details.Add(string.Format("Name of Wheels manufactur:{0}", Vehicle.Wheels[0].ManufacturerName.ToString()));
            details.Add(string.Format("Status in Garage:{0}", VehicleRepairStatus.ToString()));

            if (Vehicle.Engine.GetType() == typeof(GasEngine))
            {
                details.Add(string.Format("Fuel Engine - Fuel Type:{0}", (Vehicle.Engine as GasEngine).GasType.ToString()));
                details.Add(string.Format("fuel remaining:{0} ", Vehicle.LeftEnergy.ToString()));
            }
            else
            {
                details.Add(string.Format("Electronic engine -Baterry remaining:{0}", Vehicle.LeftEnergy.ToString()));
            }

            if (Vehicle.GetType() == typeof(Car))
            {
                details.Add(string.Format("Car doors color:{0}", (Vehicle as Car).CarColor.ToString()));
                details.Add(string.Format("Car doors number:{0}", (Vehicle as Car).CarDoors.ToString()));
            }
            else if (Vehicle.GetType() == typeof(Motor))
            {
                details.Add(string.Format("Motor License type:{0}", (Vehicle as Motor).LicenseType.ToString()));
                details.Add(string.Format("Motor Engine Volume:{0}", (Vehicle as Motor).EngineVolume.ToString()));
            }
            else if (Vehicle.GetType() == typeof(Truck))
            {
                details.Add(string.Format("Is Trunk Cooled:{0}", (Vehicle as Truck).IsTrunkCooled.ToString()));
                details.Add(string.Format("Trunk Capacity:{0}", (Vehicle as Truck).TrunkCapacity.ToString()));
            }

            return details;
        }
    }
}
