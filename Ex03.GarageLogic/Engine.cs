namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected readonly float r_MaxEnergyAmount;
        protected float m_CurrentEnergyAmount;

        protected Engine(float i_MaxEnergyAmount, float i_CurrentEnergyAmount)
        {
            r_MaxEnergyAmount = i_MaxEnergyAmount;
            m_CurrentEnergyAmount = i_CurrentEnergyAmount;
        }

        public float MaxEnergyAmount => r_MaxEnergyAmount;

        public float CurrentEnergyAmount { get => m_CurrentEnergyAmount; set => m_CurrentEnergyAmount = value; }

        protected void AddEnergyAmount(float i_EnergySourceToAdd)
        {
            if (m_CurrentEnergyAmount + i_EnergySourceToAdd > r_MaxEnergyAmount)
            {
                throw new ValueOutOfRangeException(0, r_MaxEnergyAmount - m_CurrentEnergyAmount);
            }
            else
            {
                m_CurrentEnergyAmount += i_EnergySourceToAdd;
            }
        }

        public abstract string ToString();
    }
}