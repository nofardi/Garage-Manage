using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{ 
        public class ValueOutOfRangeException : Exception
        {
            private float m_MaxValue = 0;
            private float m_MinValue = 0;

            public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
                : base(string.Format("An error occured while using a value out of the range {0} - {1}", i_MinValue, i_MaxValue))
            {
                m_MaxValue = i_MaxValue;
                m_MinValue = i_MinValue;
            }
        }
    
}
