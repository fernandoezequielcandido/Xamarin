namespace LaavorNoRegex
{
    public class StringContainsBefore: StringContains
    {
        public string ValueBefore { get; set; }
        private int? repeatValueBeforeAtMaximum;
        public int? RepeatValueBeforeAtMaximum
        {
            get
            {
                return repeatValueBeforeAtMaximum;
            }
            set
            {
                if (value < 0)
                {
                    value = value * (-1);
                }

                repeatValueBeforeAtMaximum = value;
            }
        }
    }
}
