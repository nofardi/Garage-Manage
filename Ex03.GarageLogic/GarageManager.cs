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
        private static Dictionary<string, Vehicle> m_CurrentVehiclesInGarage = new Dictionary<string, Vehicle>();
    }
}
