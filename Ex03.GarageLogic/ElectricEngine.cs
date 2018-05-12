using System;
namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {

        public ElectricEngine(float i_MaxBatteryHours, float i_BatteryHoursLeft)
            :base(i_MaxBatteryHours, i_BatteryHoursLeft)
        {
        }

		public override string ToString()
		{
            string engineTypeString = "battery hours";
            return $@"Maximum {engineTypeString}: {r_MaxEnergyAmount}
Current {engineTypeString} left: {m_CurrentEnergyAmount:F}";
		}
	}
}
