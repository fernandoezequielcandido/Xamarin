using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorSwap
{
    /// <summary>
    /// SwapLabelItem
    /// </summary>
    public class SwapLabelItem : View
    {
        /// <summary>
        /// Index of SwapLabelItem
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Internal
        /// </summary>
        public bool UseSpecificTextColor { get; private set; } = false;
        /// <summary>
        /// Internal
        /// </summary>
        public bool UseSpecificBackgroundColor { get; private set; } = false;
        /// <summary>
        /// Internal
        /// </summary>
        public bool UseSpecificBorderColor { get; private set; } = false;

        /// <summary>
        /// Constructor of SwapLabelItem
        /// </summary>
        public SwapLabelItem() : base()
        {
            
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="key"></param>
        /// <param name="index"></param>
        public void setIndex(string key, int index)
        {
            if(key == "wertyafff7777_____784")
            {
                Index = index;
            }
        }

        /// <summary>
        /// Enter the TextColor.
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
          propertyName: nameof(TextColor),
          returnType: typeof(Color),
          declaringType: typeof(SwapLabelItem),
          defaultValue: Color.Transparent,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: TextColorPropertyChanged);

        /// <summary>
        /// Enter the TextColor.
        /// </summary>
        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        private static void TextColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabelItem swapLabelItem = (SwapLabelItem)bindable;
            swapLabelItem.UseSpecificTextColor = true;
        }

        /// <summary>
        /// Enter the backgroundcolor.
        /// </summary>
        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
            propertyName: nameof(BackgroundColor),
            returnType: typeof(Color),
            declaringType: typeof(SwapLabelItem),
            defaultValue: Color.Transparent,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BackgroundColorPropertyChanged);

        /// <summary>
        /// Enter the backgroundcolor.
        /// </summary>
        public new Color BackgroundColor
        {
            get
            {
                return (Color)GetValue(BackgroundColorProperty);
            }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }

        private static void BackgroundColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabelItem swapLabelItem = (SwapLabelItem)bindable;
            swapLabelItem.UseSpecificBackgroundColor = true;
        }

        /// <summary>
        /// Enter the BorderColor.
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
          propertyName: nameof(BorderColor),
          returnType: typeof(Color),
          declaringType: typeof(SwapLabelItem),
          defaultValue: Color.Black,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: BorderColorPropertyChanged);

        /// <summary>
        /// Enter the BorderColor.
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        private static void BorderColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabelItem swapLabelItem = (SwapLabelItem)bindable;
            swapLabelItem.UseSpecificBorderColor = true;
        }


        /// <summary>
        /// Enter the Text.
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
          propertyName: nameof(Text),
          returnType: typeof(string),
          declaringType: typeof(SwapLabelItem),
          defaultValue: "",
          defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Text.
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


  
    }
}
