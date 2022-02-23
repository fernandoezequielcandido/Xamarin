using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorDivider
{
    /// <summary>
    /// Class DividerSideText
    /// </summary>
    public class DividerSideText: StackLayout
    {
        private ColorUI currentColorUI = ColorUI.Black;
    
        private LineImage lineImageCenter;
        
        private Label labelLeft = null;
        private Label labelRight = null;

        private StackLayout stackRight;
        private StackLayout stackCenter;
        private StackLayout stackLeft;

        private FontAttributes currentFontType = FontAttributes.None;

        private LineSize currentLineSize = LineSize.One;
        private ColorUI currentColor = ColorUI.Black;

        /// <summary>
        /// Constructor of DividerSideText
        /// </summary>
        public DividerSideText()
        {
            Orientation = StackOrientation.Horizontal;
            HorizontalOptions = LayoutOptions.CenterAndExpand;
            this.Spacing = 0;

            InitAll();
        }

        private void InitAll()
        {
            Children.Clear();
            lineImageCenter = new LineImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColor, currentLineSize);
            lineImageCenter.HorizontalOptions = LayoutOptions.CenterAndExpand;
            lineImageCenter.WidthRequest = LineWidth;

            stackLeft = new StackLayout();
            stackLeft.HorizontalOptions = LayoutOptions.Start;
            stackLeft.IsVisible = false;
            stackLeft.Orientation = StackOrientation.Vertical;
            stackLeft.VerticalOptions = LayoutOptions.Start;
            stackLeft.Spacing = 0;

            labelLeft = new Label();
            labelLeft.Text = TextLeft;
            labelLeft.FontAttributes = FontType;
            labelLeft.FontFamily = FontFamily;
            labelLeft.FontSize = FontSize;
            labelLeft.TextColor = TextColor;
            labelLeft.HorizontalTextAlignment = TextAlignment.End;
            labelLeft.HorizontalOptions = LayoutOptions.EndAndExpand;
            labelLeft.VerticalOptions = LayoutOptions.Center;
            labelLeft.VerticalTextAlignment = TextAlignment.Center;
            stackLeft.Children.Add(labelLeft);
            stackLeft.IsVisible = true;
            stackLeft.Margin = new Thickness(0, 0, 5, 0);

            stackCenter = new StackLayout();
            stackCenter.HorizontalOptions = LayoutOptions.FillAndExpand;
            stackCenter.IsVisible = true;
            stackCenter.VerticalOptions = LayoutOptions.Center;
            stackCenter.Orientation = StackOrientation.Vertical;
            stackCenter.Children.Add(lineImageCenter);
            stackCenter.Spacing = 0;
            stackCenter.WidthRequest = 230;

            stackRight = new StackLayout();
            stackRight.HorizontalOptions = LayoutOptions.End;
            stackRight.IsVisible = false;
            stackRight.Orientation = StackOrientation.Vertical;
            stackRight.VerticalOptions = LayoutOptions.Center;
            stackRight.Spacing = 0;

            labelRight = new Label();
            labelRight.Text = TextLeft;
            labelRight.FontAttributes = FontType;
            labelRight.FontFamily = FontFamily;
            labelRight.FontSize = FontSize;
            labelRight.TextColor = TextColor;
            labelRight.LineBreakMode = LineBreakMode.NoWrap;
            labelRight.HorizontalTextAlignment = TextAlignment.Start;
            labelRight.HorizontalOptions = LayoutOptions.StartAndExpand;
            labelRight.VerticalOptions = LayoutOptions.Center;
            labelRight.VerticalTextAlignment = TextAlignment.Center;
            stackRight.Children.Add(labelRight);
            stackRight.IsVisible = true;
            stackRight.Margin = new Thickness(5, 0, 0, 0);

            Children.Add(stackLeft);
            Children.Add(stackCenter);
            Children.Add(stackRight);            
        }

        /// <summary>
        /// Enter the LineWidth.
        /// </summary>
        public static readonly BindableProperty LineWidthProperty = BindableProperty.Create(
            propertyName: nameof(LineWidth),
            returnType: typeof(double),
            declaringType: typeof(DividerSideText),
            defaultValue: 230.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: LineWidthPropertyChanged);

        /// <summary>
        /// Enter the LineWidth.
        /// </summary>
        public double LineWidth
        {
            get
            {
                return (double)GetValue(LineWidthProperty);
            }
            set
            {
                SetValue(LineWidthProperty, value);
            }
        }

        private static void LineWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DividerSideText dividerSideText = (DividerSideText)bindable;
            double copyLine = (double)newValue;

            if (dividerSideText.lineImageCenter != null)
            {
                dividerSideText.lineImageCenter.WidthRequest = copyLine;
            }
        }

        /// <summary>
        /// Enter the LeftWidth.
        /// </summary>
        public static readonly BindableProperty LeftWidthProperty = BindableProperty.Create(
            propertyName: nameof(LeftWidth),
            returnType: typeof(double),
            declaringType: typeof(DividerSideText),
            defaultValue: 230.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: LeftWidthPropertyChanged);

        /// <summary>
        /// Enter the LeftWidth.
        /// </summary>
        public double LeftWidth
        {
            get
            {
                return (double)GetValue(LeftWidthProperty);
            }
            set
            {
                SetValue(LeftWidthProperty, value);
            }
        }

        private static void LeftWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DividerSideText dividerSideText = (DividerSideText)bindable;
            double copyLine = (double)newValue;

            if (dividerSideText.stackLeft != null && dividerSideText.TextLeft != null)
            {
                dividerSideText.stackLeft.WidthRequest = copyLine;
                dividerSideText.labelLeft.WidthRequest = copyLine;
            }
        }

        /// <summary>
        /// Enter the RightWidth.
        /// </summary>
        public static readonly BindableProperty RightWidthProperty = BindableProperty.Create(
            propertyName: nameof(RightWidth),
            returnType: typeof(double),
            declaringType: typeof(DividerSideText),
            defaultValue: 230.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: RightWidthPropertyChanged);

        /// <summary>
        /// Enter the RightWidth.
        /// </summary>
        public double RightWidth
        {
            get
            {
                return (double)GetValue(RightWidthProperty);
            }
            set
            {
                SetValue(RightWidthProperty, value);
            }
        }

        private static void RightWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DividerSideText dividerSideText = (DividerSideText)bindable;
            double copyLine = (double)newValue;

            if (dividerSideText.stackRight != null && dividerSideText.TextRight != null)
            {
                dividerSideText.stackRight.WidthRequest = copyLine;
                dividerSideText.labelRight.WidthRequest = copyLine;
            }
        }

        /// <summary>
        /// Enter the TextLeft.
        /// </summary>
        public static readonly BindableProperty TextLeftProperty = BindableProperty.Create(
            propertyName: nameof(TextLeft),
            returnType: typeof(string),
            declaringType: typeof(DividerSideText),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextLeftPropertyChanged);

        /// <summary>
        /// Enter the TextLeft.
        /// </summary>
        public string TextLeft
        {
            get
            {
                return (string)GetValue(TextLeftProperty);
            }
            set
            {
                SetValue(TextLeftProperty, value);
            }
        }

        private static void TextLeftPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DividerSideText dividerSideText = (DividerSideText)bindable;
            string copyText = (string)newValue;

            if (dividerSideText.stackLeft != null)
            {
                if (!string.IsNullOrEmpty(copyText))
                {
                    dividerSideText.labelLeft.Text = copyText;
                    dividerSideText.stackLeft.Children.Add(dividerSideText.labelLeft);
                    dividerSideText.stackLeft.VerticalOptions = LayoutOptions.Start;
                    dividerSideText.stackLeft.IsVisible = true;
                    dividerSideText.labelLeft.FontAttributes = dividerSideText.currentFontType;
                    dividerSideText.labelLeft.TextColor = dividerSideText.TextColor;
                    dividerSideText.labelLeft.FontFamily = dividerSideText.FontFamily;
                    dividerSideText.labelLeft.FontSize = dividerSideText.FontSize;
                }
            }
        }

        /// <summary>
        /// Enter the TextRight.
        /// </summary>
        public static readonly BindableProperty TextRightProperty = BindableProperty.Create(
            propertyName: nameof(TextRight),
            returnType: typeof(string),
            declaringType: typeof(DividerSideText),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextRightPropertyChanged);

        /// <summary>
        /// Enter the TextRight.
        /// </summary>
        public string TextRight
        {
            get
            {
                return (string)GetValue(TextRightProperty);
            }
            set
            {
                SetValue(TextRightProperty, value);
            }
        }

        private static void TextRightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DividerSideText dividerSideText = (DividerSideText)bindable;
            string copyText = (string)newValue;

            if (dividerSideText.stackRight != null)
            {
                if (!string.IsNullOrEmpty(copyText))
                {
                    dividerSideText.labelRight.Text = copyText;
                    dividerSideText.stackRight.Children.Add(dividerSideText.labelRight);
                    dividerSideText.stackRight.VerticalOptions = LayoutOptions.Start;
                    dividerSideText.stackRight.IsVisible = true;
                    dividerSideText.labelRight.FontAttributes = dividerSideText.currentFontType;
                    dividerSideText.labelRight.TextColor = dividerSideText.TextColor;
                    dividerSideText.labelRight.FontFamily = dividerSideText.FontFamily;
                    dividerSideText.labelRight.FontSize = dividerSideText.FontSize;
                }
            }
        }

        /// <summary>
        /// Set if is ColorUI
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUI
        {
            get
            {
                return currentColorUI;
            }
            set
            {
                currentColorUI = value;
                ColorUIPropertyChanged();
            }
        }

        private void ColorUIPropertyChanged()
        {
            if (lineImageCenter != null)
            {
                lineImageCenter.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorUI);
            }
        }

        /// <summary>
        /// Enter the fonttype (None, Bold, Italic).
        /// </summary>
        [Bindable(true)]
        public FontAttributes FontType
        {
            get
            {
                return currentFontType;
            }
            set
            {
                currentFontType = value;
                FontTypePropertyChanged();
            }
        }

        private void FontTypePropertyChanged()
        {
            if (labelLeft != null)
            {
                labelLeft.FontAttributes = currentFontType;
            }
        }

        /// <summary>
        /// Enter the LineSize (One, Two, Three, Four).
        /// </summary>
        [Bindable(true)]
        public LineSize LineSize
        {
            get
            {
                return currentLineSize;
            }
            set
            {
                currentLineSize = value;
                LineSizePropertyChanged();
            }
        }

        private void LineSizePropertyChanged()
        {
            if (lineImageCenter != null)
            {
                lineImageCenter.ChangeSize("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentLineSize);
            }
        }

        /// <summary>
        /// Enter the text color.
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
         propertyName: nameof(TextColor),
         returnType: typeof(Color),
         declaringType: typeof(DividerSideText),
         defaultValue: Color.Black,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: TextColorPropertyChanged);

        /// <summary>
        /// Enter the text color.
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
            DividerSideText dividerSideText = (DividerSideText)bindable;
            Color copyColor = (Color)newValue;
            if (dividerSideText.labelLeft != null)
            {
                dividerSideText.labelLeft.TextColor = copyColor;
            }

            if (dividerSideText.labelRight != null)
            {
                dividerSideText.labelRight.TextColor = copyColor;
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(DividerSideText),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontFamilyPropertyChanged);

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public string FontFamily
        {
            get
            {
                return (string)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
            }
        }

        private static void FontFamilyPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DividerSideText dividerSide = (DividerSideText)bindable;
            string copyFontFamily = (string)newValue;

            if (dividerSide.labelLeft != null)
            {
                dividerSide.labelLeft.FontFamily = copyFontFamily;
            }

            if (dividerSide.labelRight != null)
            {
                dividerSide.labelRight.FontFamily = copyFontFamily;
            }
        }

        /// <summary>
        /// Enter the font size of text.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(DividerSideText),
            defaultValue: 15.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size of text.
        /// </summary>
        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        private static void FontSizePropertyChanged(object bindable, object oldValue, object newValue)
        {
            DividerSideText dividerSideText = (DividerSideText)bindable;
            double copyFontSize = (double)newValue;

            if (dividerSideText.labelLeft != null)
            {
                dividerSideText.labelLeft.FontSize = copyFontSize;
            }

            if (dividerSideText.labelRight != null)
            {
                dividerSideText.labelRight.FontSize = copyFontSize;
            }
        }

       
    }
}
