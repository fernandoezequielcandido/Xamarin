using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaavorNoRegex
{
    public class NoRegex
    {
        private Dictionary<short, short> dicSpecialCharactersNumbers;
        private Dictionary<short, short> dicCapitalLetters;
        private Dictionary<short, short> dicLowercaseLetters;
        private Dictionary<short, short> dicNumberLetters;

        public NoRegex()
        {
            dicSpecialCharactersNumbers = new Dictionary<short, short>();
            dicSpecialCharactersNumbers.Add(33, 33);
            dicSpecialCharactersNumbers.Add(34, 34);
            dicSpecialCharactersNumbers.Add(35, 35);
            dicSpecialCharactersNumbers.Add(36, 36);
            dicSpecialCharactersNumbers.Add(37, 37);
            dicSpecialCharactersNumbers.Add(38, 38);
            dicSpecialCharactersNumbers.Add(39, 39);
            dicSpecialCharactersNumbers.Add(40, 40);
            dicSpecialCharactersNumbers.Add(41, 41);
            dicSpecialCharactersNumbers.Add(42, 42);
            dicSpecialCharactersNumbers.Add(43, 43);
            dicSpecialCharactersNumbers.Add(44, 44);
            dicSpecialCharactersNumbers.Add(45, 45);
            dicSpecialCharactersNumbers.Add(46, 46);
            dicSpecialCharactersNumbers.Add(47, 47);
            dicSpecialCharactersNumbers.Add(58, 58);
            dicSpecialCharactersNumbers.Add(59, 59);
            dicSpecialCharactersNumbers.Add(60, 60);
            dicSpecialCharactersNumbers.Add(61, 61);
            dicSpecialCharactersNumbers.Add(62, 62);
            dicSpecialCharactersNumbers.Add(63, 63);
            dicSpecialCharactersNumbers.Add(64, 64);
            dicSpecialCharactersNumbers.Add(91, 91);
            dicSpecialCharactersNumbers.Add(92, 92);
            dicSpecialCharactersNumbers.Add(93, 93);
            dicSpecialCharactersNumbers.Add(94, 94);
            dicSpecialCharactersNumbers.Add(95, 95);
            dicSpecialCharactersNumbers.Add(96, 96);
            dicSpecialCharactersNumbers.Add(123, 123);
            dicSpecialCharactersNumbers.Add(124, 124);
            dicSpecialCharactersNumbers.Add(125, 125);
            dicSpecialCharactersNumbers.Add(126, 126);
            dicSpecialCharactersNumbers.Add(127, 127);
            dicSpecialCharactersNumbers.Add(155, 155);
            dicSpecialCharactersNumbers.Add(156, 156);
            dicSpecialCharactersNumbers.Add(157, 157);
            dicSpecialCharactersNumbers.Add(158, 158);
            dicSpecialCharactersNumbers.Add(159, 159);
            dicSpecialCharactersNumbers.Add(166, 166);
            dicSpecialCharactersNumbers.Add(167, 167);
            dicSpecialCharactersNumbers.Add(168, 168);
            dicSpecialCharactersNumbers.Add(169, 169);
            dicSpecialCharactersNumbers.Add(170, 170);
            dicSpecialCharactersNumbers.Add(171, 171);
            dicSpecialCharactersNumbers.Add(172, 172);
            dicSpecialCharactersNumbers.Add(173, 173);
            dicSpecialCharactersNumbers.Add(174, 174);
            dicSpecialCharactersNumbers.Add(175, 175);

            dicCapitalLetters = new Dictionary<short, short>();
            dicCapitalLetters.Add(65, 65);
            dicCapitalLetters.Add(66, 66);
            dicCapitalLetters.Add(67, 67);
            dicCapitalLetters.Add(68, 68);
            dicCapitalLetters.Add(69, 69);
            dicCapitalLetters.Add(70, 70);
            dicCapitalLetters.Add(71, 71);
            dicCapitalLetters.Add(72, 72);
            dicCapitalLetters.Add(73, 73);
            dicCapitalLetters.Add(74, 74);
            dicCapitalLetters.Add(75, 75);
            dicCapitalLetters.Add(76, 76);
            dicCapitalLetters.Add(77, 77);
            dicCapitalLetters.Add(78, 78);
            dicCapitalLetters.Add(79, 79);
            dicCapitalLetters.Add(80, 80);
            dicCapitalLetters.Add(81, 81);
            dicCapitalLetters.Add(82, 82);
            dicCapitalLetters.Add(83, 83);
            dicCapitalLetters.Add(84, 84);
            dicCapitalLetters.Add(85, 85);
            dicCapitalLetters.Add(86, 86);
            dicCapitalLetters.Add(87, 87);
            dicCapitalLetters.Add(88, 88);
            dicCapitalLetters.Add(89, 89);
            dicCapitalLetters.Add(90, 90);

            dicLowercaseLetters = new Dictionary<short, short>();
            dicLowercaseLetters.Add(97, 97);
            dicLowercaseLetters.Add(98, 98);
            dicLowercaseLetters.Add(99, 99);
            dicLowercaseLetters.Add(100, 100);
            dicLowercaseLetters.Add(101, 101);
            dicLowercaseLetters.Add(102, 102);
            dicLowercaseLetters.Add(103, 103);
            dicLowercaseLetters.Add(104, 104);
            dicLowercaseLetters.Add(105, 105);
            dicLowercaseLetters.Add(106, 106);
            dicLowercaseLetters.Add(107, 107);
            dicLowercaseLetters.Add(108, 108);
            dicLowercaseLetters.Add(109, 109);
            dicLowercaseLetters.Add(110, 110);
            dicLowercaseLetters.Add(111, 111);
            dicLowercaseLetters.Add(112, 112);
            dicLowercaseLetters.Add(113, 113);
            dicLowercaseLetters.Add(114, 114);
            dicLowercaseLetters.Add(115, 115);
            dicLowercaseLetters.Add(116, 116);
            dicLowercaseLetters.Add(117, 117);
            dicLowercaseLetters.Add(118, 118);
            dicLowercaseLetters.Add(119, 119);
            dicLowercaseLetters.Add(120, 120);
            dicLowercaseLetters.Add(121, 121);
            dicLowercaseLetters.Add(122, 122);

            dicNumberLetters = new Dictionary<short, short>();
            dicNumberLetters.Add(48, 48);
            dicNumberLetters.Add(49, 49);
            dicNumberLetters.Add(50, 50);
            dicNumberLetters.Add(51, 51);
            dicNumberLetters.Add(52, 52);
            dicNumberLetters.Add(53, 53);
            dicNumberLetters.Add(54, 54);
            dicNumberLetters.Add(55, 55);
            dicNumberLetters.Add(56, 56);
            dicNumberLetters.Add(57, 57);
        }

        public bool Validate(string value)
        {
            bool isValid = true;

            if (StartWith.IgnoreCase != null && !string.IsNullOrEmpty(StartWith.Value))
            {
                StringComparison comparison = StartWith.IgnoreCase.Value ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

                isValid = value.StartsWith(StartWith.Value, comparison);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (EndsWith.IgnoreCase != null && !string.IsNullOrEmpty(EndsWith.Value))
            {
                StringComparison comparison = EndsWith.IgnoreCase.Value ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

                isValid = value.EndsWith(EndsWith.Value, comparison);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (Contains.IgnoreCase != null && !string.IsNullOrEmpty(Contains.Value))
            {
                StringComparison comparison = Contains.IgnoreCase.Value ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

                int index = value.IndexOf(Contains.Value, comparison);

                isValid = (index >= 0);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (useMinimumCharacters)
            {
                isValid = (value.Length >= minimumCharacters);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (useMaximumCharacters)
            {
                isValid = (value.Length <= maximumCharacters);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (DoesNotContain.IgnoreCase != null && !string.IsNullOrEmpty(DoesNotContain.Value))
            {
                StringComparison comparison = DoesNotContain.IgnoreCase.Value ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

                int index = value.IndexOf(DoesNotContain.Value, comparison);

                isValid = (index < 0);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (RepeatAtLeast.Amount != null && !string.IsNullOrEmpty(RepeatAtLeast.Value) && RepeatAtLeast.IgnoreCase != null)
            {
                int countRepeat = 0;
                StringComparison comparison = RepeatAtLeast.IgnoreCase.Value ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

                int firstIndex = value.IndexOf(RepeatAtLeast.Value, comparison);
                if (firstIndex >= 0)
                {
                    countRepeat++;
                    if (countRepeat < RepeatAtLeast.Amount)
                    {
                        string currentTemp = value.Remove(firstIndex, RepeatAtLeast.Value.Length);
                        while (firstIndex >= 0)
                        {
                            firstIndex = currentTemp.IndexOf(RepeatAtLeast.Value, comparison);
                            if (firstIndex < 0)
                            {
                                break;
                            }

                            countRepeat++;
                            if (countRepeat >= RepeatAtLeast.Amount)
                            {
                                break;
                            }

                            currentTemp = currentTemp.Remove(firstIndex, RepeatAtLeast.Value.Length);
                        }
                    }
                }

                isValid = (countRepeat >= RepeatAtLeast.Amount);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (RepeatAtMaximum.Amount != null && !string.IsNullOrEmpty(RepeatAtMaximum.Value) && RepeatAtMaximum.IgnoreCase != null)
            {
                int countRepeat = -1;
                StringComparison comparison = RepeatAtMaximum.IgnoreCase.Value ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

                int firstIndex = value.IndexOf(RepeatAtMaximum.Value, comparison);
                if (firstIndex >= 0)
                {
                    countRepeat = 1;
                    if (countRepeat <= RepeatAtMaximum.Amount)
                    {
                        string currentTemp = value.Remove(firstIndex, RepeatAtMaximum.Value.Length);
                        while (firstIndex >= 0)
                        {
                            firstIndex = currentTemp.IndexOf(RepeatAtMaximum.Value, comparison);
                            if (firstIndex < 0)
                            {
                                break;
                            }

                            countRepeat++;
                            if (countRepeat > RepeatAtMaximum.Amount)
                            {
                                break;
                            }

                            currentTemp = currentTemp.Remove(firstIndex, RepeatAtMaximum.Value.Length);
                        }
                    }
                }

                isValid = (countRepeat <= RepeatAtMaximum.Amount);

                if (!isValid)
                {
                    return isValid;
                }
            }

            List<short> listAscChars = new List<short>();
            int lenghtASC = value.Length;
            if (useMinimumSpecialCharacters && minimumSpecialCharacters > 0)
            {
                for (int iChar = 0; iChar < lenghtASC; iChar++)
                {
                    listAscChars.Add((short)value[iChar]);
                }

                int countSpecialC = 0;

                for (int iAsc = 0; iAsc < lenghtASC; iAsc++)
                {
                    if (dicSpecialCharactersNumbers.ContainsKey(listAscChars[iAsc]))
                    {
                        countSpecialC++;
                    }

                    if (countSpecialC >= minimumSpecialCharacters)
                    {
                        break;
                    }
                }

                isValid = (countSpecialC >= minimumSpecialCharacters);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (useMaximumSpecialCharacters)
            {
                if (listAscChars.Count == 0)
                {
                    for (int iChar = 0; iChar < lenghtASC; iChar++)
                    {
                        listAscChars.Add((short)value[iChar]);
                    }
                }

                int countSpecialC = 0;

                for (int iAsc = 0; iAsc < lenghtASC; iAsc++)
                {
                    if (dicSpecialCharactersNumbers.ContainsKey(listAscChars[iAsc]))
                    {
                        countSpecialC++;
                    }

                    if (countSpecialC > maximumSpecialCharacters)
                    {
                        break;
                    }
                }

                isValid = (countSpecialC <= maximumSpecialCharacters);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (useCompellingCaps)
            {
                if (listAscChars.Count == 0)
                {
                    for (int iChar = 0; iChar < lenghtASC; iChar++)
                    {
                        listAscChars.Add((short)value[iChar]);
                    }
                }

                int countCaps = 0;

                for (int iAsc = 0; iAsc < lenghtASC; iAsc++)
                {
                    if (dicCapitalLetters.ContainsKey(listAscChars[iAsc]))
                    {
                        countCaps++;
                        break;
                    }
                }

                isValid = (countCaps > 0);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (useCompellingLowercase)
            {
                if (listAscChars.Count == 0)
                {
                    for (int iChar = 0; iChar < lenghtASC; iChar++)
                    {
                        listAscChars.Add((short)value[iChar]);
                    }
                }

                int countLower = 0;

                for (int iAsc = 0; iAsc < lenghtASC; iAsc++)
                {
                    if (dicLowercaseLetters.ContainsKey(listAscChars[iAsc]))
                    {
                        countLower++;
                        break;
                    }
                }

                isValid = (countLower > 0);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (useCompellingNumbers)
            {
                if (listAscChars.Count == 0)
                {
                    for (int iChar = 0; iChar < lenghtASC; iChar++)
                    {
                        listAscChars.Add((short)value[iChar]);
                    }
                }

                int countNumbers = 0;

                for (int iAsc = 0; iAsc < lenghtASC; iAsc++)
                {
                    if (dicNumberLetters.ContainsKey(listAscChars[iAsc]))
                    {
                        countNumbers++;
                        break;
                    }
                }

                isValid = (countNumbers > 0);

                if (!isValid)
                {
                    return isValid;
                }
            }

            if (!string.IsNullOrEmpty(ContainsAfter.Value) && ContainsAfter.IgnoreCase != null && (!string.IsNullOrEmpty(ContainsAfter.ValueAfter) || (ContainsAfter.AmountCharacters != null)))
            {
                int index;
                StringComparison comparison = ContainsAfter.IgnoreCase.Value ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

                index = value.IndexOf(ContainsAfter.Value, comparison);

                string tempWithout = "";

                bool hasValue = true;
                if (index >= 0)
                {
                    tempWithout = value.Remove(0, (index + ContainsAfter.Value.Length));

                    if (!string.IsNullOrEmpty(ContainsAfter.ValueAfter))
                    {
                        index = tempWithout.IndexOf(ContainsAfter.ValueAfter);
                        hasValue = (index >= 0);
                    }

                    if (hasValue && ContainsAfter.AmountCharacters != null)
                    {
                        hasValue = (tempWithout.Length >= ContainsAfter.AmountCharacters.Value);
                    }
                }

                isValid = (hasValue);

                if (!isValid)
                {
                    return isValid;
                }
                else
                {
                    if (ContainsAfter.BlockSpecialCharacters != null && ContainsAfter.BlockSpecialCharacters.Value)
                    {
                        listAscChars.Clear();
                        int lenghtAtfer = tempWithout.Length;
                        for (int iChar = 0; iChar < lenghtAtfer; iChar++)
                        {
                            listAscChars.Add((short)tempWithout[iChar]);
                        }

                        int countCharacters = 0;

                        for (int iAsc = 0; iAsc < lenghtAtfer; iAsc++)
                        {
                            if (dicSpecialCharactersNumbers.ContainsKey(listAscChars[iAsc]))
                            {
                                countCharacters++;
                                break;
                            }
                        }
                        listAscChars.Clear();

                        isValid = (countCharacters <= 0);

                        if (!isValid)
                        {
                            return isValid;
                        }
                    }

                    if (ContainsAfter.CompellingLetters != null && ContainsAfter.CompellingLetters.Value)
                    {
                        listAscChars.Clear();
                        int lenghtAtfer = tempWithout.Length;
                        for (int iChar = 0; iChar < lenghtAtfer; iChar++)
                        {
                            listAscChars.Add((short)tempWithout[iChar]);
                        }

                        int countCharacters = 0;

                        for (int iAsc = 0; iAsc < lenghtAtfer; iAsc++)
                        {
                            if (dicLowercaseLetters.ContainsKey(listAscChars[iAsc]) || dicCapitalLetters.ContainsKey(listAscChars[iAsc]))
                            {
                                countCharacters++;
                                break;
                            }
                        }
                        listAscChars.Clear();

                        isValid = (countCharacters > 0);

                        if (!isValid)
                        {
                            return isValid;
                        }
                    }

                    if (ContainsAfter.RepeatValueAfterAtMaximum != null)
                    {
                        int countRepeat = -1;

                        int firstIndex = tempWithout.IndexOf(ContainsAfter.ValueAfter, comparison);
                        if (firstIndex >= 0)
                        {
                            countRepeat = 1;
                            if (countRepeat <= ContainsAfter.RepeatValueAfterAtMaximum.Value)
                            {
                                string currentTemp = tempWithout.Remove(firstIndex, ContainsAfter.ValueAfter.Length);
                                while (firstIndex >= 0)
                                {
                                    firstIndex = currentTemp.IndexOf(ContainsAfter.ValueAfter, comparison);
                                    if (firstIndex < 0)
                                    {
                                        break;
                                    }

                                    countRepeat++;
                                    if (countRepeat > ContainsAfter.RepeatValueAfterAtMaximum.Value)
                                    {
                                        break;
                                    }

                                    currentTemp = currentTemp.Remove(firstIndex, ContainsAfter.ValueAfter.Length);
                                }
                            }
                        }

                        if (countRepeat == -1)
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = (countRepeat <= ContainsAfter.RepeatValueAfterAtMaximum.Value);
                        }

                        if (!isValid)
                        {
                            return isValid;
                        }
                    }


                }
            }

            if (!string.IsNullOrEmpty(ContainsBefore.Value) && ContainsBefore.IgnoreCase != null && (!string.IsNullOrEmpty(ContainsBefore.ValueBefore) || (ContainsBefore.AmountCharacters != null)))
            {
                int index;
                StringComparison comparison = ContainsBefore.IgnoreCase.Value ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

                index = value.IndexOf(ContainsBefore.Value, comparison);

                string tempWithout = "";

                bool hasValue = true;
                if (index >= 0)
                {
                    tempWithout = value.Remove(index, value.Length - index);

                    if (!string.IsNullOrEmpty(ContainsBefore.ValueBefore))
                    {
                        index = tempWithout.IndexOf(ContainsBefore.ValueBefore);
                        hasValue = (index >= 0);
                    }

                    if (hasValue && ContainsBefore.AmountCharacters != null)
                    {
                        hasValue = (tempWithout.Length >= ContainsBefore.AmountCharacters.Value);
                    }
                }

                isValid = (hasValue);

                if (!isValid)
                {
                    return isValid;
                }
                else
                {
                    if (ContainsBefore.BlockSpecialCharacters != null && ContainsBefore.BlockSpecialCharacters.Value)
                    {
                        listAscChars.Clear();
                        int lenghtBefore = tempWithout.Length;
                        for (int iChar = 0; iChar < lenghtBefore; iChar++)
                        {
                            listAscChars.Add((short)tempWithout[iChar]);
                        }

                        int countCharacters = 0;

                        for (int iAsc = 0; iAsc < lenghtBefore; iAsc++)
                        {
                            if (dicSpecialCharactersNumbers.ContainsKey(listAscChars[iAsc]))
                            {
                                countCharacters++;
                                break;
                            }
                        }
                        listAscChars.Clear();

                        isValid = (countCharacters <= 0);

                        if (!isValid)
                        {
                            return isValid;
                        }
                    }

                    if (ContainsBefore.CompellingLetters != null && ContainsBefore.CompellingLetters.Value)
                    {
                        listAscChars.Clear();
                        int lenghtBefore = tempWithout.Length;
                        for (int iChar = 0; iChar < lenghtBefore; iChar++)
                        {
                            listAscChars.Add((short)tempWithout[iChar]);
                        }

                        int countCharacters = 0;

                        for (int iAsc = 0; iAsc < lenghtBefore; iAsc++)
                        {
                            if (dicLowercaseLetters.ContainsKey(listAscChars[iAsc]) || dicCapitalLetters.ContainsKey(listAscChars[iAsc]))
                            {
                                countCharacters++;
                                break;
                            }
                        }
                        listAscChars.Clear();

                        isValid = (countCharacters > 0);

                        if (!isValid)
                        {
                            return isValid;
                        }
                    }

                    if (ContainsBefore.RepeatValueBeforeAtMaximum != null)
                    {
                        int countRepeat = -1;

                        int firstIndex = tempWithout.IndexOf(ContainsBefore.ValueBefore, comparison);
                        if (firstIndex >= 0)
                        {
                            countRepeat = 1;
                            if (countRepeat < ContainsBefore.RepeatValueBeforeAtMaximum.Value)
                            {
                                string currentTemp = tempWithout.Remove(firstIndex, ContainsBefore.ValueBefore.Length);
                                while (firstIndex >= 0)
                                {
                                    firstIndex = currentTemp.IndexOf(ContainsBefore.ValueBefore, comparison);
                                    if (firstIndex < 0)
                                    {
                                        break;
                                    }

                                    countRepeat++;
                                    if (countRepeat > ContainsBefore.RepeatValueBeforeAtMaximum.Value)
                                    {
                                        break;
                                    }

                                    currentTemp = currentTemp.Remove(firstIndex, ContainsBefore.ValueBefore.Length);
                                }
                            }
                        }

                        if (countRepeat == -1)
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = (countRepeat <= ContainsBefore.RepeatValueBeforeAtMaximum.Value);
                        }

                        if (!isValid)
                        {
                            return isValid;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(value) && (!string.IsNullOrEmpty(Between.Left) || (Between.Left != null)) && (!string.IsNullOrEmpty(Between.Right) || (Between.Right != null)) && (!string.IsNullOrEmpty(Between.Center) || (Between.Center != null)))
            {
                int indexLeft;
                int indexRight;
                StringComparison comparison = Between.IgnoreCase.Value ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;

                indexLeft = value.IndexOf(Between.Left, comparison);
                indexRight = LastIndex(value, Between.Right, Between.IgnoreCase.Value);

                string tempCenter = "";

                bool hasValue = false;
                if (indexLeft >= 0 && indexRight >= 0 && (indexRight > indexLeft))
                {
                    int finalRemove = (indexLeft + Between.Left.Length);

                    if ((value.Length - 1) < finalRemove)
                    {
                        return false;
                    }

                    tempCenter = value.Remove(0, finalRemove);

                    indexRight = LastIndex(tempCenter, Between.Right, Between.IgnoreCase.Value);

                    finalRemove = tempCenter.Length;
                    tempCenter = tempCenter.Remove(indexRight, (finalRemove - indexRight));

                    int indexCenter;
                    indexCenter =  tempCenter.IndexOf(Between.Center, comparison);

                    hasValue = (indexCenter >= 0);
                }

                isValid = (hasValue);

                if (!isValid)
                {
                    return isValid;
                }
            }

            return isValid;
        }

        private int LastIndex (string value, string search, bool IgnoreCase)
        {
            string searchTemp = "";

            int indexSearch = search.Length - 1;
            for (int iLast = value.Length - 1; iLast >= 0; iLast--)
            {
                char charValue = value[iLast];
                char charSearch = search[indexSearch];
                               
                if (IgnoreCase)
                {
                    charValue = charValue.ToString().ToUpper()[0];
                    charSearch = charSearch.ToString().ToUpper()[0];
                }
               
                if (charValue == charSearch)
                {
                    searchTemp = value[iLast] + searchTemp;
                    if (string.Equals(search, searchTemp))
                    {
                        return iLast;
                    }

                    indexSearch--;
                    if (indexSearch < 0)
                    {
                        indexSearch = search.Length - 1;
                        searchTemp = ""; 
                    }
                }
            }

            return -1;
        }
         
               
        public StringNoRegex StartWith { get; set; } = new StringNoRegex();

        public StringNoRegex EndsWith { get; set; } = new StringNoRegex();

        public StringNoRegex Contains { get; set; } = new StringNoRegex();
       
        private bool useMinimumCharacters = false;
        private int minimumCharacters;
        public int MinimumCharacters
        {
            get
            {
                return minimumCharacters;
            }
            set
            {
                useMinimumCharacters = true;
                minimumCharacters = value;
            }
        }

        private bool useMaximumCharacters = false;
        private int maximumCharacters;
        public int MaximumCharacters
        {
            get
            {
                return maximumCharacters;
            }
            set
            {
                useMaximumCharacters = true;
                maximumCharacters = value;
            }
        }

        public StringNoRegex DoesNotContain { get; set; } = new StringNoRegex();

        public Repeat RepeatAtLeast { get; set; } = new Repeat();

        public Repeat RepeatAtMaximum { get; set; } = new Repeat();

        private bool useMinimumSpecialCharacters = false;
        private int minimumSpecialCharacters;
        public int MinimumSpecialCharacters
        {
            get
            {
                return minimumSpecialCharacters;
            }
            set
            {
                useMinimumSpecialCharacters = true;
                minimumSpecialCharacters = value;
            }
        }

        private bool useMaximumSpecialCharacters = false;
        private int maximumSpecialCharacters;
        public int MaximumSpecialCharacters
        {
            get
            {
                return maximumSpecialCharacters;
            }
            set
            {
                useMaximumSpecialCharacters = true;
                maximumSpecialCharacters = value;
            }
        }

        private bool useCompellingCaps = false;
        private bool compellingCaps;
        public bool CompellingCaps
        {
            get
            {
                return compellingCaps;
            }
            set
            {
                useCompellingCaps = true;
                compellingCaps = value;
            }
        }

        private bool useCompellingLowercase = false;
        private bool compellingLowercase;
        public bool CompellingLowercase
        {
            get
            {
                return compellingLowercase;
            }
            set
            {
                useCompellingLowercase = true;
                compellingLowercase = value;
            }
        }

        private bool useCompellingNumbers = false;
        private bool compellingNumbers;
        public bool CompellingNumbers
        {
            get
            {
                return compellingNumbers;
            }
            set
            {
                useCompellingNumbers = true;
                compellingNumbers = value;
            }
        }

        public StringContainsAfter ContainsAfter{ get; set; } = new StringContainsAfter();

        public StringContainsBefore ContainsBefore { get; set; } = new StringContainsBefore();

        public Between Between { get; set; } = new Between();
    }
}
