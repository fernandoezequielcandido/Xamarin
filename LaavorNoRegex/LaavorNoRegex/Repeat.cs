namespace LaavorNoRegex
{
    public class Repeat
    {
        private int? amount { get; set; }
        public int? Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value < 0)
                {
                    value = value * (-1);
                }

                amount = value;
            }
        }

        public string Value { get; set; }
        public bool? IgnoreCase  { get; set; }
    }
}
