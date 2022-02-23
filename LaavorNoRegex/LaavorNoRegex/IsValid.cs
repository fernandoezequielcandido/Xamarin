using System;
using System.Collections.Generic;
using System.Globalization;

namespace LaavorNoRegex
{
    public class IsValid
    {
        private static Dictionary<short, short> dicNumber;

        private static void InsertDataNumbers()
        {
            dicNumber = new Dictionary<short, short>();
            dicNumber.Add(48, 48);
            dicNumber.Add(49, 49);
            dicNumber.Add(50, 50);
            dicNumber.Add(51, 51);
            dicNumber.Add(52, 52);
            dicNumber.Add(53, 53);
            dicNumber.Add(54, 54);
            dicNumber.Add(55, 55);
            dicNumber.Add(56, 56);
            dicNumber.Add(57, 57);
        }

        public static bool Email(string email)
        {
            NoRegex noRegexEmailPartArroba = new NoRegex();
            noRegexEmailPartArroba.RepeatAtMaximum.Value = "@";
            noRegexEmailPartArroba.RepeatAtMaximum.IgnoreCase = true;
            noRegexEmailPartArroba.RepeatAtMaximum.Amount = 1;

            noRegexEmailPartArroba.ContainsBefore.Value = "@";
            noRegexEmailPartArroba.ContainsBefore.CompellingLetters = true;
            noRegexEmailPartArroba.ContainsBefore.AmountCharacters = 1;
            noRegexEmailPartArroba.ContainsBefore.IgnoreCase = true;

            noRegexEmailPartArroba.ContainsAfter.Value = "@";
            noRegexEmailPartArroba.ContainsAfter.CompellingLetters = true;
            noRegexEmailPartArroba.ContainsAfter.IgnoreCase = true;
            noRegexEmailPartArroba.ContainsAfter.AmountCharacters = 6;
            noRegexEmailPartArroba.ContainsAfter.ValueAfter = ".";
            noRegexEmailPartArroba.ContainsAfter.RepeatValueAfterAtMaximum = 1;

            noRegexEmailPartArroba.DoesNotContain.Value = "..";
            noRegexEmailPartArroba.DoesNotContain.IgnoreCase = true;

            bool isValidEmail = noRegexEmailPartArroba.Validate(email);

            if (isValidEmail)
            {
                string second = email.Split('@')[1];
                NoRegex noRegexEmailPartDot = new NoRegex();

                noRegexEmailPartDot.ContainsBefore.Value = ".";
                noRegexEmailPartDot.ContainsBefore.CompellingLetters = true;
                noRegexEmailPartDot.ContainsBefore.AmountCharacters = 2;
                noRegexEmailPartDot.ContainsBefore.IgnoreCase = true;

                noRegexEmailPartDot.ContainsAfter.Value = ".";
                noRegexEmailPartDot.ContainsAfter.CompellingLetters = true;
                noRegexEmailPartDot.ContainsAfter.AmountCharacters = 2;
                noRegexEmailPartDot.ContainsAfter.IgnoreCase = true;

                isValidEmail = noRegexEmailPartDot.Validate(second);
            }

            return isValidEmail;
        }

        private static bool isIntegerBase(string value)
        {
            if (value == "-")
            {
                return false;
            }

            bool isValid = true;

            InsertDataNumbers();

            List<short> listAscChars = new List<short>();

            string absValue = value;
            if ((short)value[0] == 45)
            {
                absValue = value.Substring(1, value.Length - 1);
            }

            int lenghtASC = absValue.Length;
            for (int iChar = 0; iChar < lenghtASC; iChar++)
            {
                listAscChars.Add((short)absValue[iChar]);
            }

            for (int iAsc = 0; iAsc < lenghtASC; iAsc++)
            {
                if (!dicNumber.ContainsKey(listAscChars[iAsc]))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Validate Integer
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Integer(string value)
        {
            return isIntegerBase(value);
        }

        /// <summary>
        /// Validate Integer With Minimum and Maximum Value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static bool Integer(string value, int minimum, int maximum)
        {
            bool isValid = isIntegerBase(value);

            if (!isValid)
            {
                return isValid;
            }

            int intValue = int.Parse(value);

            if (intValue < minimum)
            {
                return false;
            }

            if(intValue > maximum)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate Integer and ConverterValue(return) with reference
        /// </summary>
        /// <param name="value"></param>
        /// <param name="returnValue">Convert num if is valid(Reference)</param>
        /// <returns></returns>
        public static bool Integer(string value, ref int returnValue)
        {
            bool isValid = isIntegerBase(value);

            if (!isValid)
            {
                return isValid;
            }

            returnValue = int.Parse(value);
                       
            return true;
        }

        /// <summary>
        /// Validate Integer With Minimum and Maximum Value and ConverterValue(return)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="returnValue">Convert num if is valid(Reference)</param>
        public static bool Integer(string value, int minimum, int maximum, ref int returnValue)
        {
            bool isValid = isIntegerBase(value);

            if (!isValid)
            {
                return isValid;
            }

            int intValue = int.Parse(value);

            if (intValue < minimum)
            {
                return false;
            }

            if (intValue > maximum)
            {
                return false;
            }

            returnValue = int.Parse(value);

            return true;
        }

        /// <summary>
        /// Validate Double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Double(string value)
        {
            return isDoubleBase(value);
        }

        /// <summary>
        /// Validate Double With Minimum and Maximum Value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static bool Double(string value, double minimum, double maximum)
        {
            bool isValid = isDoubleBase(value);

            if (!isValid)
            {
                return isValid;
            }

            double doubleValue = double.Parse(value, CultureInfo.InvariantCulture);

            if (doubleValue < minimum)
            {
                return false;
            }

            if (doubleValue > maximum)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate Double With Minimum and Maximum Value and ConverterValue(return)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="returnValue">Convert num if is valid(Reference)</param>
        /// <returns></returns>
        public static bool Double(string value, double minimum, double maximum, ref double returnValue)
        {
            bool isValid = isDoubleBase(value);

            if (!isValid)
            {
                return isValid;
            }

            double doubleValue = double.Parse(value, CultureInfo.InvariantCulture);

            if (doubleValue < minimum)
            {
                return false;
            }

            if (doubleValue > maximum)
            {
                return false;
            }

            returnValue = double.Parse(value);

            return true;
        }

        private static bool isDoubleBase(string value)
        {
            if (value == "-")
            {
                return false;
            }

            bool isValid = true;

            InsertDataNumbers();

            List<short> listAscChars = new List<short>();

            string absValue = value;
            if ((short)value[0] == 45)
            {
                absValue = value.Substring(1, value.Length - 1);
            }

            int lenghtASC = absValue.Length;
            for (int iChar = 0; iChar < lenghtASC; iChar++)
            {
                if ((short)absValue[iChar] != 46)
                {
                    listAscChars.Add((short)absValue[iChar]);
                }
            }

            for (int iAsc = 0; iAsc < listAscChars.Count; iAsc++)
            {
                if (!dicNumber.ContainsKey(listAscChars[iAsc]))
                {
                    isValid = false;
                    return isValid;
                }
            }

            int countDot = 0;
            for (int iAsc = 0; iAsc < lenghtASC; iAsc++)
            {
                if ((short)value[iAsc] == 46)
                {
                    countDot++;
                }
            }

            if (countDot > 1)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
