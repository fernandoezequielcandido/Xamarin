using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaavorNoRegex
{
    public class Between
    {
        public string Left { get; set; }
        public string Right { get; set; }
        public string Center { get; set; }
        public bool? IgnoreCase { get; set; }

        public Between()
        {
            IgnoreCase = true;
        }
    }
}
