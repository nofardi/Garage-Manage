using System;

namespace Ex03.GarageLogic
{
    public class ParameterValidator
    {
        private string m_InputString;
        private eValidityTypes m_Validity;

        public ParameterValidator()
        {
        }

        public ParameterValidator(string i_Query, eValidityTypes i_ValidityType)
        {
            m_InputString = i_Query;
            m_Validity = i_ValidityType;
        }

        public string InputQuery => m_InputString;

        public eValidityTypes eValidityType => m_Validity;

        public enum eValidityTypes
        {
            All, 
            NumberOnly,
            LettersOnly,
            LicenseType,
            Boolean,
            CarColor,
            DoorNumber
        }

        public static void CheckInputParameterValid(string i_InputString, eValidityTypes i_ValidityType)
        {
            eCarDoors carDoors = eCarDoors.FIVE;
            eCarColors carColors = eCarColors.BLACK;
            eLicenseType licenseType = eLicenseType.A;
            switch(i_ValidityType)
            {
                case eValidityTypes.All:
                    break;
                case eValidityTypes.LettersOnly:
                    StringUtils.CheckStringConsistsOnlyLetters(i_InputString);
                    break;
                case eValidityTypes.NumberOnly:
                    StringUtils.CheckStringConsistsOnlyNumbers(i_InputString);
                    break;
                case eValidityTypes.Boolean:
                    StringUtils.CheckStringRepresentBool(i_InputString);
                    break;
                case eValidityTypes.CarColor:
                    checkEnumChoiceIsValid(i_InputString, carColors);
                    break;
                case eValidityTypes.DoorNumber:
                    checkEnumChoiceIsValid(i_InputString, carDoors);
                    break;
                case eValidityTypes.LicenseType:
                    checkEnumChoiceIsValid(i_InputString, licenseType);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i_ValidityType), i_ValidityType, null);
            }
        }

        private static void checkEnumChoiceIsValid(string i_InputString, Enum i_EnumToCheck)
        {
            int result = 0;
            if(!(int.TryParse(i_InputString, out result) && Enum.IsDefined(i_EnumToCheck.GetType(), result)))
            {
                throw new FormatException("Parameter isn't legal");
            }         
        }
    }
}
