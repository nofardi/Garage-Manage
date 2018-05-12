using System;
namespace Ex03.GarageLogic
{
    public abstract class GasVehicle
    {
        eGasType m_GasType;
        float m_CurrGasLiter;
        float m_MaxGasLiter;

        public GasVehicle(eGasType i_GasType, float i_CurrGasLiter, float i_MaxGasLiter)
        {
            m_GasType = i_GasType;
            m_CurrGasLiter = i_CurrGasLiter;
            m_MaxGasLiter = i_MaxGasLiter;
        }

        //TODO: throw out of range excaption
        public void AddGas(float i_AmountToAdd)
        {
            if (m_CurrGasLiter + i_AmountToAdd > m_MaxGasLiter)
            {
                m_CurrGasLiter = m_MaxGasLiter;
            }
            else
            {
                m_CurrGasLiter += i_AmountToAdd;
            }
        }
    }
}
