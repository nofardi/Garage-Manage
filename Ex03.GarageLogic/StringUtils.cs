using System;
using System.Linq;
using System.Text;

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

        public static string GetEnumListAsString(Enum i_EnumType)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] enumNamesArray = Enum.GetNames(i_EnumType.GetType());
            byte enumIndex = 1;

            foreach (string name in enumNamesArray)
            {
                stringBuilder.AppendLine(($"{enumIndex}. {name}"));
                enumIndex++;
            }
            return stringBuilder.ToString();
        }
    }
}
