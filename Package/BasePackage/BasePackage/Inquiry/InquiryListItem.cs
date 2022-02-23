using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {

        /// <summary>
        /// Class DoubleListItem
        /// </summary>
        public class InquiryListItem : View
        {
            /// <summary>
            /// Enter the Text, only when using list.
            /// </summary>
            public static readonly BindableProperty TextProperty = BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(InquiryListItem),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the Text, only when using list.
            /// </summary>
            public string Text
            {
                get
                {
                    return (string)GetValue(TextProperty);
                }
                set
                {
                    SetValue(TextProperty, value);
                }
            }

            /// <summary>
            /// Enter the Value, only when using list.
            /// </summary>
            public static readonly BindableProperty ValueProperty = BindableProperty.Create(
                propertyName: nameof(Value),
                returnType: typeof(string),
                declaringType: typeof(InquiryListItem),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the Value, only when using list.
            /// </summary>
            public string Value
            {
                get
                {
                    return (string)GetValue(ValueProperty);
                }
                set
                {
                    SetValue(ValueProperty, value);
                }
            }
        }

    }
}
