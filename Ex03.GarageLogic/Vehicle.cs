using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicensingNumber;
        private float m_LeftEnergy;
        private Wheel[] m_Wheels;
        private Engine m_Engine;

        public Vehicle(string i_ModelName, string i_LicensingNumber, float i_LeftEnergy, Wheel[] i_Wheels, Engine i_Engine, string i_ManufacturerName, float i_CurrAirpressure, float i_MaxAirPressure)
        {
            m_ModelName = i_ModelName;
            m_LicensingNumber = i_LicensingNumber;
            m_LeftEnergy = i_LeftEnergy;
            m_Engine = i_Engine;

            for (int currWheel = 0; currWheel < i_Wheels.Length; currWheel++)
            {
                m_Wheels[currWheel] = new Wheel(i_ManufacturerName, i_CurrAirpressure, i_MaxAirPressure);   
            }
        }

        public string ModelName => m_ModelName;
        public string LicensingNum => m_LicensingNumber;
        public float LeftEnergy => m_LeftEnergy;
        public Wheel[] Wheels => m_Wheels;
        public Engine Engine => m_Engine;

        public override string ToString()
        {
            return $@"Model name: {m_ModelName}
License number: {m_LicensingNumber}
Tires manufacture name: {m_Wheels[0].ManufacturerName}
Tires air pressure: {m_Wheels[0].CurrAirpressure}
{m_Engine}
Energy percentage left: {m_LeftEnergy}%";
        }

        // fix to string Format - Erez // Owner problem // overide by car, track and moto
        public virtual List<string> GetVehicleDetails()
        {
            List<string> details = new List<string>();

            details.Add("License number: " + LicensingNum.ToString());
            details.Add("Name of model: " + ModelName.ToString());
            details.Add("Wheels current air pressure: " + Wheels[0].CurrAirpressure.ToString());
            details.Add("Name of Wheels manufactur: " + Wheels[0].ManufacturerName);
            if (Engine.GetType() == typeof(GasEngine))
            {
                details.Add("Fuel Engine - Fuel Type: " + (Engine as GasEngine).GasType.ToString());
                details.Add("fuel remaining presentage: " + LeftEnergy.ToString());
            }
            else
            {
                details.Add("Electronic engine -Baterry remaining presentage: " + LeftEnergy.ToString());
            }

            return details;
        }
    }
}
