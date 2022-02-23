using Xamarin.Forms;

namespace Laavor
{
    namespace Validate
    {
        /// <summary>
        /// Class ValidateBase
        /// </summary>
        public class ValidateBase : StackLayout, IValidateBase
        {
            /// <summary>
            /// Returns if field value is valid.
            /// </summary>
            public bool IsValid { get; set; }

            /// <summary>
            /// Property if is IsReadOnly
            /// </summary>
            public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                     propertyName: nameof(IsReadOnly),
                     returnType: typeof(bool),
                     declaringType: typeof(ValidateBase),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Property if is IsReadOnly
            /// </summary>
            public bool IsReadOnly
            {
                get
                {
                    return (bool)GetValue(IsReadOnlyProperty);
                }
                set
                {
                    SetValue(IsReadOnlyProperty, value);
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
}
