namespace Ex03.GarageLogic
{
    public class CarInGarage
    {
        string m_OwnerName;
        string m_OwnerPhone;
        eVehicleRepairStatus m_RepairStatus;
        Vehicle m_Car;

        public CarInGarage(string i_OwnerName, string i_OwnerPhone, Vehicle i_Car)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_RepairStatus = eVehicleRepairStatus.IN_PROGRESS;
           // m_Car = new Vehicle(i_Car);
        }
    }
}
