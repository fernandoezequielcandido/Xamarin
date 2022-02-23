using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{
    /// <summary>
    /// Class LaavorBaseValidate
    /// </summary>
    public class LaavorBaseValidate: StackLayout, ILaavorBaseValidate
    {
        /// <summary>
        /// Returns if field value is valid.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Enter the ValidationType.
        /// </summary>
        [Bindable(true)]
        public ValidationType ValidationType
        {
            get
            {
                return ValidationType;
            }
            set
            {
                ValidationType = value;
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        public virtual void ForceValidate()
        {

        }
    }
}
