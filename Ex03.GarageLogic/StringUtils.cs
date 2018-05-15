using System;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class StringUtils
    {
        public static void CheckStringConsistsOnlyLetters(string i_InputString)
        {
            if (!i_InputString.All(inputChar => char.IsSeparator(inputChar) || char.IsLetter(inputChar)))
            {
                throw new FormatException("Parameter should contain letters only.");
            }
        }

        public static void CheckStringConsistsOnlyNumbers(string i_InputString)
        {
            if (!i_InputString.All(char.IsDigit))
            {
                throw new FormatException("Parameter should contain digits only.");
            }
        }

        public static void CheckInputIsInRange(string i_InputString, float i_MinValue, float i_MaxValue)
        {
            float result;
            if (!float.TryParse(i_InputString, out result))
            {
                throw new FormatException("Parameter should be a number.");
            }

            if(!(result >= i_MinValue && result <= i_MaxValue))
            {
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue);
            }
        }

        public static void CheckStringRepresentBool(string i_InputString)
        {
            if(!(i_InputString == "true" || i_InputString == "false"))
            {
                throw new FormatException("Parameter should be true or false.");
            }
        }

        public static void CheckStringIsInEnum(string i_InputString, Enum i_EnumToCheck)
        {
            if(!Enum.IsDefined(i_EnumToCheck.GetType(), i_InputString))
            {
                throw new FormatException("Parameter isn't legal.");
            }
        }
    }
}
