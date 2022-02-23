using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorInputWithLabel
{
    /// <summary>
    /// Class InputWithLabel
    /// </summary>
    public class InputWithLabel : StackLayout
    {
        private InputLabelImage imageBackLeft;
        private InputLabelImage imageBackRight;
        private Label labelLeft;
        private Label labelRight;
        private Entry entry;

        private StackLayout dataItems;
        private StackLayout stackLeft;
        private StackLayout stackCenter;
        private StackLayout stackRight;
        private AbsoluteLayout absoluteLeft;
        private AbsoluteLayout absoluteRight;

        private Frame frame = new Frame();

        private ColorUI colorUILeft = ColorUI.Gray;
        private ColorUI colorUIRight = ColorUI.Gray;
        private DesignType designTypeLeft = DesignType.Filled;
        private DesignType designTypeRight = DesignType.Filled;

        private FontAttributes fontTypeLeft = FontAttributes.None;
        private FontAttributes fontTypeRight = FontAttributes.None;
        private FontAttributes fontTypeInput = FontAttributes.None;

        private Vivacity currentVivacity = Vivacity.Decrease;
        private Depth currentDepth = Depth.Medium;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;

        /// <summary>
        /// Event call when LeftLabel is Touched
        /// </summary>
        public event EventHandler TouchedLeft;

        /// <summary>
        /// Event call when RightLabel is Touched
        /// </summary>
        public event EventHandler TouchedRight;

        /// <summary>
        /// Constructor of InputWithLabel
        /// </summary>
        public InputWithLabel() : base()
        {
            InitAll();
        }

        private void InitAll()
        {
            this.Margin = new Thickness(5, 5, 5, 5);
            this.Spacing = 0;

            dataItems = new StackLayout();
            this.Orientation = StackOrientation.Vertical;
            dataItems.Orientation = StackOrientation.Horizontal;
            dataItems.Spacing = 0;
            dataItems.HeightRequest = Height;
            



            imageBackLeft = new InputLabelImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", designTypeLeft, colorUILeft);
            imageBackLeft.VerticalOptions = LayoutOptions.Center;
            imageBackLeft.Aspect = Aspect.Fill;
            imageBackLeft.HeightRequest = Height;
            imageBackLeft.WidthRequest = WidthLeft;
            imageBackLeft.HeightRequest = Height;

            if (String.IsNullOrEmpty(TextLeft))
            {
                imageBackLeft.IsVisible = false;
            }

            imageBackLeft.GestureRecognizers.Add(GetTouchLeft());
            imageBackLeft.GestureRecognizers.Add(GetVivacityLeft());

            labelLeft = new Label();
            labelLeft.Text = TextLeft;

            labelLeft.GestureRecognizers.Add(GetTouchLeft());
            labelLeft.GestureRecognizers.Add(GetVivacityLeft());

            absoluteLeft = new AbsoluteLayout();

            AbsoluteLayout.SetLayoutFlags(labelLeft, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labelLeft, new Rectangle(0.5, 0.5, -1, -1));

            absoluteLeft.Children.Add(imageBackLeft);
            absoluteLeft.Children.Add(labelLeft);

            stackLeft = new StackLayout();
            stackLeft.Spacing = 0;
            stackLeft.HorizontalOptions = LayoutOptions.Center;
            stackLeft.Orientation = StackOrientation.Vertical;
            stackLeft.Children.Add(absoluteLeft);

            if (String.IsNullOrEmpty(TextLeft))
            {
                stackLeft.IsVisible = false;
            }


            entry = new Entry();
            entry.VerticalOptions = LayoutOptions.Center;
            entry.WidthRequest = WidthInput;
            entry.FontSize = FontSizeInput;
            entry.Margin = new Thickness(-10, -20, -10, -20);

            frame = new Frame();
            frame.BorderColor = Color.Gray;
            frame.VerticalOptions = LayoutOptions.Start;
            frame.BackgroundColor = Color.Transparent;
            frame.HeightRequest = Height;

            frame.Content = entry;

            stackCenter = new StackLayout();
            stackCenter.Spacing = 0;
            stackCenter.Margin = new Thickness(0.0, 0, 0.0, 0);
            stackCenter.HorizontalOptions = LayoutOptions.Center;
            stackCenter.Orientation = StackOrientation.Vertical;
            stackCenter.Children.Add(frame);





            imageBackRight = new InputLabelImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", designTypeRight, colorUIRight);
            imageBackRight.Aspect = Aspect.Fill;
            imageBackRight.VerticalOptions = LayoutOptions.Center;
            imageBackRight.HeightRequest = Height;
            imageBackRight.WidthRequest = WidthRight;
            imageBackRight.HeightRequest = Height;
            
            if (string.IsNullOrEmpty(TextRight))
            {
                imageBackRight.IsVisible = false;
            }

            imageBackRight.GestureRecognizers.Add(GetTouchRight());
            imageBackRight.GestureRecognizers.Add(GetVivacityRight());

            labelRight = new Label();
            labelRight.Text = TextRight;
            labelRight.GestureRecognizers.Add(GetTouchRight());
            labelRight.GestureRecognizers.Add(GetVivacityRight());

            absoluteRight = new AbsoluteLayout();

            AbsoluteLayout.SetLayoutFlags(labelRight, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labelRight, new Rectangle(0.5, 0.5, -1, -1));

            absoluteRight.Children.Add(imageBackRight);
            absoluteRight.Children.Add(labelRight);

            stackRight = new StackLayout();
            stackRight.Spacing = 0;
            stackRight.VerticalOptions = LayoutOptions.Center;
            stackRight.HorizontalOptions = LayoutOptions.Center;
            stackRight.Children.Add(absoluteRight);

            if (string.IsNullOrEmpty(TextRight))
            {
                stackRight.IsVisible = false;
            }
            
            dataItems.Children.Add(stackLeft);
            dataItems.Children.Add(stackCenter);
            dataItems.Children.Add(stackRight);

            this.Children.Add(dataItems);
        }

        private void Touch_Left(object sender, EventArgs e)
        {
            TouchedLeft?.Invoke(this, EventArgs.Empty);
        }

        private TapGestureRecognizer GetTouchLeft()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += Touch_Left;
            return touch;
        }

        private void Touch_Right(object sender, EventArgs e)
        {
            TouchedRight?.Invoke(this, EventArgs.Empty);
        }

        private TapGestureRecognizer GetTouchRight()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += Touch_Right;
            return touch;
        }

        /// <summary>
        /// Enter the Width Left.
        /// </summary>
        public static readonly BindableProperty WidthLeftProperty = BindableProperty.Create(
            propertyName: nameof(WidthLeft),
            returnType: typeof(double),
            declaringType: typeof(InputWithLabel),
            defaultValue: 55.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthLeftPropertyChanged);

        /// <summary>
        /// Enter the Width Left.
        /// </summary>
        public double WidthLeft
        {
            get
            {
                return (double)GetValue(WidthLeftProperty);
            }
            set
            {
                SetValue(WidthLeftProperty, value);
            }
        }

        private static void WidthLeftPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            double copyWidth = (double)newValue;

            if (inputWithLabel.imageBackLeft != null && copyWidth > 55)
            {
                inputWithLabel.imageBackLeft.WidthRequest = copyWidth;
            }
        }

        /// <summary>
        /// Enter the Width Right.
        /// </summary>
        public static readonly BindableProperty WidthRightProperty = BindableProperty.Create(
            propertyName: nameof(WidthRight),
            returnType: typeof(double),
            declaringType: typeof(InputWithLabel),
            defaultValue: 55.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthRightPropertyChanged);

        /// <summary>
        /// Enter the Width Right.
        /// </summary>
        public double WidthRight
        {
            get
            {
                return (double)GetValue(WidthRightProperty);
            }
            set
            {
                SetValue(WidthLeftProperty, value);
            }
        }

        private static void WidthRightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            double copyWidth = (double)newValue;

            if (inputWithLabel.imageBackRight != null && copyWidth > 55)
            {
                inputWithLabel.imageBackRight.WidthRequest = copyWidth;
            }
        }

        /// <summary>
        /// Enter the Width Input.
        /// </summary>
        public static readonly BindableProperty WidthInputProperty = BindableProperty.Create(
            propertyName: nameof(WidthInput),
            returnType: typeof(double),
            declaringType: typeof(InputWithLabel),
            defaultValue: 190.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthInputPropertyChanged);

        /// <summary>
        /// Enter the Width Input.
        /// </summary>
        public double WidthInput
        {
            get
            {
                return (double)GetValue(WidthInputProperty);
            }
            set
            {
                SetValue(WidthInputProperty, value);
            }
        }

        private static void WidthInputPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            double copyWidth = (double)newValue;

            if (inputWithLabel.entry != null)
            {
                inputWithLabel.entry.WidthRequest = copyWidth;
            }
        }

        /// <summary>
        /// Enter the font size Left Label.
        /// </summary>
        public static readonly BindableProperty FontSizeLeftProperty = BindableProperty.Create(
            propertyName: nameof(FontSizeLeft),
            returnType: typeof(double),
            declaringType: typeof(InputWithLabel),
            defaultValue: 15.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizeLeftPropertyChanged);

        /// <summary>
        /// Enter the font size Left Label.
        /// </summary>
        public double FontSizeLeft
        {
            get
            {
                return (double)GetValue(FontSizeLeftProperty);
            }
            set
            {
                SetValue(FontSizeLeftProperty, value);
            }
        }

        private static void FontSizeLeftPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            double copyFontSize = (double)newValue;

            if (inputWithLabel.labelLeft != null && inputWithLabel.imageBackLeft != null)
            {
                inputWithLabel.labelLeft.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Enter the font size Right Label.
        /// </summary>
        public static readonly BindableProperty FontSizeRightProperty = BindableProperty.Create(
            propertyName: nameof(FontSizeRight),
            returnType: typeof(double),
            declaringType: typeof(InputWithLabel),
            defaultValue: 15.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizeRightPropertyChanged);

        /// <summary>
        /// Enter the font size Right Label.
        /// </summary>
        public double FontSizeRight
        {
            get
            {
                return (double)GetValue(FontSizeRightProperty);
            }
            set
            {
                SetValue(FontSizeRightProperty, value);
            }
        }

        private static void FontSizeRightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            double copyFontSize = (double)newValue;

            if (inputWithLabel.labelRight != null && inputWithLabel.imageBackRight != null)
            {
                inputWithLabel.labelRight.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Enter the Height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(InputWithLabel),
            defaultValue: 55.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightPropertyChanged);

        /// <summary>
        /// Enter the Height.
        /// </summary>
        public new double Height
        {
            get
            {
                return (double)GetValue(HeightProperty);
            }
            set
            {
                SetValue(HeightProperty, value);
            }
        }

        private static void HeightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            double copyHeight = (double)newValue;

            if (inputWithLabel.entry != null)
            {
                inputWithLabel.frame.HeightRequest = copyHeight;
                inputWithLabel.imageBackLeft.HeightRequest = copyHeight;
                inputWithLabel.imageBackRight.HeightRequest = copyHeight;
                inputWithLabel.dataItems.HeightRequest = copyHeight;
            }
        }

        /// <summary>
        /// Enter the font size Input.
        /// </summary>
        public static readonly BindableProperty FontSizeInputProperty = BindableProperty.Create(
            propertyName: nameof(FontSizeInput),
            returnType: typeof(double),
            declaringType: typeof(InputWithLabel),
            defaultValue: 20.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizeInputPropertyChanged);

        /// <summary>
        /// Enter the font size Input.
        /// </summary>
        public double FontSizeInput
        {
            get
            {
                return (double)GetValue(FontSizeInputProperty);
            }
            set
            {
                SetValue(FontSizeInputProperty, value);
            }
        }

        private static void FontSizeInputPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            double copyFontSize = (double)newValue;

            if (inputWithLabel.entry != null)
            {
                inputWithLabel.entry.FontSize = copyFontSize;
                inputWithLabel.frame.HeightRequest = inputWithLabel.Height;
                inputWithLabel.imageBackLeft.HeightRequest = inputWithLabel.Height;
                inputWithLabel.imageBackRight.HeightRequest = inputWithLabel.Height;
                inputWithLabel.dataItems.HeightRequest = inputWithLabel.Height;
            }
        }

        /// <summary>
        /// Enter the title textcolor Left.
        /// </summary>
        public static readonly BindableProperty TextColorLeftProperty = BindableProperty.Create(
            propertyName: nameof(TextColorLeft),
            returnType: typeof(ColorUI),
            declaringType: typeof(InputWithLabel),
            defaultValue: ColorUI.Black,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextColorLeftPropertyChanged);

        /// <summary>
        /// Enter the title textcolor Left.
        /// </summary>
        public ColorUI TextColorLeft
        {
            get
            {
                return (ColorUI)GetValue(TextColorLeftProperty);
            }
            set
            {
                SetValue(TextColorLeftProperty, value);
            }
        }

        private static void TextColorLeftPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            ColorUI copyColor = (ColorUI)newValue;

            if (inputWithLabel.labelLeft != null)
            {
                inputWithLabel.labelLeft.TextColor = Colors.Get(copyColor);
            }
        }

        /// <summary>
        /// Enter the title textcolor Right.
        /// </summary>
        public static readonly BindableProperty TextColorRightProperty = BindableProperty.Create(
            propertyName: nameof(TextColorRight),
            returnType: typeof(ColorUI),
            declaringType: typeof(InputWithLabel),
            defaultValue: ColorUI.Black,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextColorRightPropertyChanged);

        /// <summary>
        /// Enter the title textcolor Right.
        /// </summary>
        public ColorUI TextColorRight
        {
            get
            {
                return (ColorUI)GetValue(TextColorRightProperty);
            }
            set
            {
                SetValue(TextColorRightProperty, value);
            }
        }

        private static void TextColorRightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            ColorUI copyColor = (ColorUI)newValue;

            if (inputWithLabel.labelRight != null)
            {
                inputWithLabel.labelRight.TextColor = Colors.Get(copyColor);
            }
        }

        /// <summary>
        /// Enter the ColorUI Input.
        /// </summary>
        public static readonly BindableProperty ColorUIInputProperty = BindableProperty.Create(
            propertyName: nameof(ColorUIInput),
            returnType: typeof(ColorUI),
            declaringType: typeof(InputWithLabel),
            defaultValue: ColorUI.Transparent,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ColorUIInputPropertyChanged);

        /// <summary>
        /// Enter the ColorUI Input.
        /// </summary>
        public ColorUI ColorUIInput
        {
            get
            {
                return (ColorUI)GetValue(ColorUIInputProperty);
            }
            set
            {
                SetValue(ColorUIInputProperty, value);
            }
        }

        private static void ColorUIInputPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            ColorUI copyColor = (ColorUI)newValue;

            if (inputWithLabel.frame != null)
            {
                inputWithLabel.frame.BackgroundColor = Colors.Get(copyColor);
            }
        }

        /// <summary>
        /// Enter the title textcolor Input.
        /// </summary>
        public static readonly BindableProperty TextColorInputProperty = BindableProperty.Create(
            propertyName: nameof(TextColorInput),
            returnType: typeof(ColorUI),
            declaringType: typeof(InputWithLabel),
            defaultValue: ColorUI.Black,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextColorInputPropertyChanged);

        /// <summary>
        /// Enter the title textcolor Input.
        /// </summary>
        public ColorUI TextColorInput
        {
            get
            {
                return (ColorUI)GetValue(TextColorInputProperty);
            }
            set
            {
                SetValue(TextColorInputProperty, value);
            }
        }

        private static void TextColorInputPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            ColorUI copyColor = (ColorUI)newValue;

            if (inputWithLabel.entry != null)
            {
                inputWithLabel.entry.TextColor = Colors.Get(copyColor);
            }
        }

        /// <summary>
        /// Enter the font family Left.
        /// </summary>
        public static readonly BindableProperty FontFamilyLeftProperty = BindableProperty.Create(
            propertyName: nameof(FontFamilyLeft),
            returnType: typeof(string),
            declaringType: typeof(InputWithLabel),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontFamilyLeftPropertyChanged);

        /// <summary>
        /// Enter the font family Left.
        /// </summary>
        public string FontFamilyLeft
        {
            get
            {
                return (string)GetValue(FontFamilyLeftProperty);
            }
            set
            {
                SetValue(FontFamilyLeftProperty, value);
            }
        }

        private static void FontFamilyLeftPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            string copyFontFamily = (string)newValue;

            if (inputWithLabel.labelLeft != null)
            {
                inputWithLabel.labelLeft.FontFamily = copyFontFamily;
            }
        }

        /// <summary>
        /// Enter the font family Right.
        /// </summary>
        public static readonly BindableProperty FontFamilyRightProperty = BindableProperty.Create(
            propertyName: nameof(FontFamilyRight),
            returnType: typeof(string),
            declaringType: typeof(InputWithLabel),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontFamilyRightPropertyChanged);

        /// <summary>
        /// Enter the font family Right.
        /// </summary>
        public string FontFamilyRight
        {
            get
            {
                return (string)GetValue(FontFamilyRightProperty);
            }
            set
            {
                SetValue(FontFamilyRightProperty, value);
            }
        }

        private static void FontFamilyRightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            string copyFontFamily = (string)newValue;

            if (inputWithLabel.labelRight != null)
            {
                inputWithLabel.labelRight.FontFamily = copyFontFamily;
            }
        }

        /// <summary>
        /// Enter the font family Input.
        /// </summary>
        public static readonly BindableProperty FontFamilyInputProperty = BindableProperty.Create(
            propertyName: nameof(FontFamilyInput),
            returnType: typeof(string),
            declaringType: typeof(InputWithLabel),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontFamilyInputPropertyChanged);

        /// <summary>
        /// Enter the font family Input.
        /// </summary>
        public string FontFamilyInput
        {
            get
            {
                return (string)GetValue(FontFamilyInputProperty);
            }
            set
            {
                SetValue(FontFamilyRightProperty, value);
            }
        }

        private static void FontFamilyInputPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            string copyFontFamily = (string)newValue;

            if (inputWithLabel.entry != null)
            {
                inputWithLabel.entry.FontFamily = copyFontFamily;
            }
        }

        /// <summary>
        /// Enter the fonttype Left (None, Bold, Italic).
        /// </summary>
        [Bindable(true)]
        public FontAttributes FontTypeLeft
        {
            get
            {
                return fontTypeLeft;
            }
            set
            {
                FontTypeLeftPropertyChanged(this, fontTypeLeft, value);
                fontTypeLeft = value;
            }
        }

        private static void FontTypeLeftPropertyChanged(object bindable, FontAttributes oldValue, FontAttributes newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            FontAttributes copyFontType = newValue;
            if (inputWithLabel.labelLeft != null)
            {
                inputWithLabel.labelLeft.FontAttributes = copyFontType;
            }
        }

        /// <summary>
        /// Enter the fonttype Right (None, Bold, Italic).
        /// </summary>
        [Bindable(true)]
        public FontAttributes FontTypeRight
        {
            get
            {
                return fontTypeRight;
            }
            set
            {
                FontTypeRightPropertyChanged(this, fontTypeRight, value);
                fontTypeRight = value;
            }
        }

        private static void FontTypeRightPropertyChanged(object bindable, FontAttributes oldValue, FontAttributes newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            FontAttributes copyFontType = newValue;
            if (inputWithLabel.labelRight != null)
            {
                inputWithLabel.labelRight.FontAttributes = copyFontType;
            }
        }

        /// <summary>
        /// Enter the fonttype Input (None, Bold, Italic).
        /// </summary>
        [Bindable(true)]
        public FontAttributes FontTypeInput
        {
            get
            {
                return fontTypeInput;
            }
            set
            {
                FontTypeInputPropertyChanged(this, fontTypeInput, value);
                fontTypeInput = value;
            }
        }

        private static void FontTypeInputPropertyChanged(object bindable, FontAttributes oldValue, FontAttributes newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            FontAttributes copyFontType = newValue;
            if (inputWithLabel.entry != null)
            {
                inputWithLabel.entry.FontAttributes = copyFontType;
            }
        }

        /// <summary>
        /// Set if is ColorUILeft
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUILeft
        {
            get
            {
                return colorUILeft;
            }
            set
            {
                colorUILeft = value;
                ColorUILeftPropertyChanged();
            }
        }

        private void ColorUILeftPropertyChanged()
        {
            if (imageBackLeft != null)
            {
                imageBackLeft.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", colorUILeft);
            }
        }

        /// <summary>
        /// Set if is ColorUIRight
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUIRight
        {
            get
            {
                return colorUIRight;
            }
            set
            {
                colorUIRight = value;
                ColorUIRightPropertyChanged();
            }
        }

        private void ColorUIRightPropertyChanged()
        {
            if (imageBackRight != null)
            {
                imageBackRight.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", colorUIRight);
            }
        }

        /// <summary>
        /// Enter the placeholder color.
        /// </summary>
        public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
            propertyName: nameof(PlaceholderColor),
            returnType: typeof(ColorUI),
            declaringType: typeof(InputWithLabel),
            defaultValue: ColorUI.Gray,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: PlaceholderColorPropertyChanged);

        /// <summary>
        /// Enter the placeholder color.
        /// </summary>
        public ColorUI PlaceholderColor
        {
            get
            {
                return (ColorUI)GetValue(PlaceholderColorProperty);
            }
            set
            {
                SetValue(PlaceholderColorProperty, value);
            }
        }

        private static void PlaceholderColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            ColorUI copyPlaceholderColor = (ColorUI)newValue;

            if (inputWithLabel.entry != null)
            {
                inputWithLabel.entry.PlaceholderColor = Colors.Get(copyPlaceholderColor);
            }
        }

        /// <summary>
        /// Enter the Text Left.
        /// </summary>
        public static readonly BindableProperty TextLeftProperty = BindableProperty.Create(
            propertyName: nameof(TextLeft),
            returnType: typeof(string),
            declaringType: typeof(InputWithLabel),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextLeftPropertyChanged);

        /// <summary>
        /// Enter the Text Left.
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
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            string textLeft = (string)newValue;

            if (String.IsNullOrEmpty(textLeft))
            {
                inputWithLabel.stackLeft.IsVisible = false;
                inputWithLabel.imageBackLeft.IsVisible = false;
            }
            else
            {
                inputWithLabel.stackLeft.IsVisible = true;
                inputWithLabel.imageBackLeft.IsVisible = true;
            }

            inputWithLabel.labelLeft.Text = textLeft;
        }

        /// <summary>
        /// Enter the Text Right.
        /// </summary>
        public static readonly BindableProperty TextRightProperty = BindableProperty.Create(
            propertyName: nameof(TextRight),
            returnType: typeof(string),
            declaringType: typeof(InputWithLabel),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextRightPropertyChanged);

        /// <summary>
        /// Enter the Text Right.
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
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            string textRight = (string)newValue;

            if (String.IsNullOrEmpty(textRight))
            {
                inputWithLabel.stackRight.IsVisible = false;
                inputWithLabel.imageBackRight.IsVisible = false;
            }
            else
            {
                inputWithLabel.stackRight.IsVisible = true;
                inputWithLabel.imageBackRight.IsVisible = true;
            }

            inputWithLabel.labelRight.Text = textRight;
        }

        /// <summary>
        /// Placeholder
        /// </summary>
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            propertyName: nameof(Placeholder),
            returnType: typeof(string),
            declaringType: typeof(InputWithLabel),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: PlaceholderPropertyChanged);

        /// <summary>
        /// Placeholder
        /// </summary>
        public string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }

        private static void PlaceholderPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            string copyPlaceholder = (string)newValue;

            if (inputWithLabel.entry != null)
            {
                inputWithLabel.entry.Placeholder = copyPlaceholder;
            }
        }

        /// <summary>
        /// Set DesignType Left
        /// </summary>
        [Bindable(true)]
        public DesignType DesignTypeLeft
        {
            get
            {
                return designTypeLeft;
            }
            set
            {
                designTypeLeft = value;
                DesignTypeLeftPropertyChanged();
            }
        }

        private void DesignTypeLeftPropertyChanged()
        {
            if (imageBackLeft != null)
            {
                imageBackLeft.ChangeDesignType("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", designTypeLeft);
            }
        }

        /// <summary>
        /// Set DesignType Right
        /// </summary>
        [Bindable(true)]
        public DesignType DesignTypeRight
        {
            get
            {
                return designTypeRight;
            }
            set
            {
                designTypeRight = value;
                DesignTypeRightPropertyChanged();
            }
        }

        private void DesignTypeRightPropertyChanged()
        {
            if (imageBackRight != null)
            {
                imageBackRight.ChangeDesignType("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", designTypeRight);
            }
        }

        /// <summary>
        /// Enter the Border color input.
        /// </summary>
        public static readonly BindableProperty BorderColorInputProperty = BindableProperty.Create(
            propertyName: nameof(BorderColorInput),
            returnType: typeof(ColorUI),
            declaringType: typeof(InputWithLabel),
            defaultValue: ColorUI.Black,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BorderColorInputPropertyChanged);

        /// <summary>
        /// Enter the Border color input.
        /// </summary>
        public ColorUI BorderColorInput
        {
            get
            {
                return (ColorUI)GetValue(BorderColorInputProperty);
            }
            set
            {
                SetValue(BorderColorInputProperty, value);
            }
        }

        private static void BorderColorInputPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputWithLabel inputWithLabel = (InputWithLabel)bindable;
            ColorUI copyBorderColor = (ColorUI)newValue;

            if (inputWithLabel.frame != null)
            {
                inputWithLabel.frame.BorderColor = Colors.Get(copyBorderColor);
            }
        }

        private TapGestureRecognizer GetVivacityLeft()
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacityLeft" + currentVivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
            TapGestureRecognizer touchVivavicity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
            return touchVivavicity;
        }

        private TapGestureRecognizer GetVivacityRight()
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacityRight" + currentVivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
            TapGestureRecognizer touchVivavicity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
            return touchVivavicity;
        }

        private TapGestureRecognizer GetVivacityLeftDecrease()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedLeft != null)
                    {
                        await imageBackLeft.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackLeft.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };

            return animationTap;
        }

        private TapGestureRecognizer GetVivacityRightDecrease()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedRight != null)
                    {
                        await imageBackRight.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackRight.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };

            return animationTap;
        }

        private double GetDepthDecrease(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 0.88;
            }
            else if (depth == Depth.LessMedium)
            {
                return 0.95;
            }
            else if (depth == Depth.Medium)
            {
                return 0.90;
            }
            else
            {
                return 0.75;
            }
        }

        private TapGestureRecognizer GetVivacityLeftIncrease()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedLeft != null)
                    {
                        await imageBackLeft.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackLeft.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };

            return vivacityTap;
        }

        private TapGestureRecognizer GetVivacityRightIncrease()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedRight != null)
                    {
                        await imageBackRight.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackRight.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };

            return vivacityTap;
        }

        private double GetDepthIncrease(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 1.01;
            }
            else if (depth == Depth.LessMedium)
            {
                return 1.07;
            }
            else if (depth == Depth.Medium)
            {
                return 1.11;
            }
            else
            {
                return 1.15;
            }
        }

        private TapGestureRecognizer GetVivacityLeftRotation()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedLeft != null)
                    {
                        await imageBackLeft.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackLeft.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return vivacityTap;
        }

        private TapGestureRecognizer GetVivacityRightRotation()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedRight != null)
                    {
                        await imageBackRight.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackRight.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return vivacityTap;
        }

        private int GetDepthRotation(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 200;
            }
            else if (depth == Depth.LessMedium)
            {
                return 250;
            }
            else if (depth == Depth.Medium)
            {
                return 300;
            }
            else
            {
                return 360;
            }
        }

        private TapGestureRecognizer GetVivacityLeftJump()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedLeft != null)
                    {
                        await imageBackLeft.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackLeft.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return animationTap;
        }

        private TapGestureRecognizer GetVivacityRightJump()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedRight != null)
                    {
                        await imageBackRight.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackRight.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return animationTap;
        }

        private double GetDepthJump(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return -1.5;
            }
            else if (depth == Depth.LessMedium)
            {
                return -2.0;
            }
            else if (depth == Depth.Medium)
            {
                return -2.7;
            }
            else
            {
                return -3.4;
            }
        }

        private TapGestureRecognizer GetVivacityLeftDown()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedLeft != null)
                    {
                        await imageBackLeft.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackLeft.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return animationTap;
        }

        private TapGestureRecognizer GetVivacityRightDown()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedRight != null)
                    {
                        await imageBackRight.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackRight.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return animationTap;
        }

        private double GetDepthDown(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 1.5;
            }
            else if (depth == Depth.LessMedium)
            {
                return 2.0;
            }
            else if (depth == Depth.Medium)
            {
                return 2.7;
            }
            else
            {
                return 3.4;
            }
        }

        private TapGestureRecognizer GetVivacityLeftLeft()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedLeft != null)
                    {
                        await imageBackLeft.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackLeft.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelLeft.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return animationTap;
        }

        private TapGestureRecognizer GetVivacityRightLeft()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (TouchedRight != null)
                    {
                        await imageBackRight.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await imageBackRight.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await labelRight.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return animationTap;
        }

        private double GetDepthLeft(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return -2.00;
            }
            else if (depth == Depth.LessMedium)
            {
                return -3.0;
            }
            else if (depth == Depth.Medium)
            {
                return -5.0;
            }
            else
            {
                return -10.0;
            }
        }
    }
}
