using Xamarin.Forms;

namespace LaavorChoiceWord
{
    /// <summary>
    /// Class ChoiceWordItem
    /// </summary>
    public class ChoiceWordItem: View
    {
        /// <summary>
        /// Constructor of ChoiceWordItem
        /// </summary>
        public ChoiceWordItem()
        {
            IsVisible = false;
        }

        /// <summary>
        /// Enter the text
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(ChoiceWordItem),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the text
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
        /// Enter the Value
        /// </summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            propertyName: nameof(Value),
            returnType: typeof(string),
            declaringType: typeof(ChoiceWordItem),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the value
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

        /// <summary>
        /// Enter the width choiceItem.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double?),
            declaringType: typeof(ChoiceWordItem),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the width choiceItem.
        /// </summary>
        public new double? Width
        {
            get
            {
                return (double?)GetValue(WidthProperty);
            }
            set
            {
                SetValue(WidthProperty, value);
            }
        }

        /// <summary>
        /// Enter the Height item choiceItem.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double?),
            declaringType: typeof(ChoiceWordItem),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Height item choiceItem.
        /// </summary>
        public new double? Height
        {
            get
            {
                return (double?)GetValue(HeightProperty);
            }
            set
            {
                SetValue(HeightProperty, value);
            }
        }


    }
}
