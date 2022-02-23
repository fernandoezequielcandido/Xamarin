using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{
    /// <summary>
    /// Class LaavorLabel
    /// </summary>
    public class LaavorLabel: Label
    {
        /// <summary>
        /// Constructor of LaavorLabel
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="index"></param>
        public LaavorLabel(string hash, int index)
        {
            if (hash == "HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122")
            {
                this.Index = index;
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="index"></param>
        public void ChangeIndex(string hash, int index)
        {
            if (hash == "HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122")
            {
                this.Index = index;
            }
        }

        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; private set; }
    }
}
