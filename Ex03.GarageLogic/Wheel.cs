namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrAirpressure;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrAirpressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrAirpressure = i_CurrAirpressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName => m_ManufacturerName;

        public float CurrAirpressure => m_CurrAirpressure;

        public float MaxAirPressure => m_MaxAirPressure;

        public void addAirToWheel(float i_AirToAdd)
        {
            if (m_CurrAirpressure + i_AirToAdd > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressure - m_CurrAirpressure);
            }
            else
            {
                m_CurrAirpressure += i_AirToAdd;
            }
        }
    }
}
