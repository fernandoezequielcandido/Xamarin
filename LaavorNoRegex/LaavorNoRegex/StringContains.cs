namespace LaavorNoRegex
{
    public class StringContains
    {
        public string Value { get; set; }
        public bool? IgnoreCase { get; set; }
        public bool? BlockSpecialCharacters { get; set; }
        public bool? CompellingLetters { get; set; }
        private int? amountCharacters;
        public int? AmountCharacters
        {
            get
            {
                return amountCharacters;
            }
            set
            {
                if (value < 0)
                {
                    value = value * (-1);
                }
                amountCharacters = value;
            }
        }
    }
}
