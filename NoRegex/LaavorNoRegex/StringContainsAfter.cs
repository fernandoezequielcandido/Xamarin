namespace LaavorNoRegex
{
    public class StringContainsAfter: StringContains
    {
        public string ValueAfter { get; set; }
        private int? repeatValueAfterAtMaximum;
        public int? RepeatValueAfterAtMaximum
        {
            get
            {
                return repeatValueAfterAtMaximum;
            }
            set
            {
                if(value < 0)
                {
                    value = value * (-1);
                }

                repeatValueAfterAtMaximum = value;
            }
        }
    }
}
