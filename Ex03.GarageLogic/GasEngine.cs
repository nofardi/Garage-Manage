namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        private eGasType m_GasType;

        public GasEngine(eGasType i_GasType, float i_CurrGasLiter, float i_MaxGasLiter)
            : base(i_MaxGasLiter, i_CurrGasLiter)
        {
            m_GasType = i_GasType;
        }

        public eGasType GasType { get => m_GasType; set => m_GasType = value; }

		public override string ToString()
		{
            string engineTypeString = "fuel quantity (in liters)";
            return $@"Maximum ${engineTypeString}: {r_MaxEnergyAmount}
Current {engineTypeString} left: {m_CurrentEnergyAmount:F}";
		}
	}
}
