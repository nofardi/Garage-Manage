using System;

namespace Ex03.GarageLogic
{
    public class ParameterValidator
    {
        private string m_InputParameter;

        public ParameterValidator()
        {
        }

        public enum eValidityTypes
        {
            All, 
            NumberOnly,
            LettersOnly
        }

        public static void CheckInputParameterValid(string i_InputString, eValidityTypes i_ValidityType)
        {
            switch(i_ValidityType)
            {
                case eValidityTypes.All:
                    break;
                case eValidityTypes.LettersOnly:
                    checkStringConsistsOnlyLetters(i_InputString);
                    break;
                case eValidityTypes.NumberOnly:
                    checkStringConsistsOnlyNumbers(i_InputString);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i_ValidityType), i_ValidityType, null);
            }
        }

        private static bool checkStringConsistsOnlyLetters(string i_InputString)
        {
            return true;
        }

        private static bool checkStringConsistsOnlyNumbers(string i_InputString)
        {
            return true;
        }

    }
}
