using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorButtonConception
{
    /// <summary>
    /// Class ButtonConception
    /// </summary>
    public class ButtonConception : StackLayout
    {
         /// <summary>
        /// Event call when button is Touched
        /// </summary>
        public event EventHandler Touched;

        private Label labelTextReference;
        private ButtonConceptionImage imageButtonReference;

        private ColorUI currentColorUI = ColorUI.Gray;
        private DesignType currentDesignType = DesignType.Shinning;
        private FontAttributes currentFontType = FontAttributes.Bold;
        private ColorUI currentTextColor = ColorUI.Orange;

        private Vivacity currentVivacity = Vivacity.Decrease;
        private Depth currentDepth = Depth.Medium;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;

        /// <summary>
        /// Constructor of Button Conception
        /// </summary>
        public ButtonConception()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            InitAll();
        }

        private void InitAll()
        {
            AbsoluteLayout abs = new AbsoluteLayout();
            abs.HorizontalOptions = LayoutOptions.Center;
            
            CreateButton();

            abs.Children.Add(imageButtonReference);
            abs.Children.Add(labelTextReference);

            this.Children.Add(abs);
        }

        private void CreateButton()
        {
            imageButtonReference = new ButtonConceptionImage("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentDesignType, currentColorUI);
            imageButtonReference.WidthRequest = Width;
            imageButtonReference.MinimumHeightRequest = Width;
            imageButtonReference.HeightRequest = Height;
            imageButtonReference.MinimumHeightRequest = Height;
            
            labelTextReference = new Label();
            labelTextReference.Text = Text;
            labelTextReference.TextColor = GetColorFromColorUI(currentTextColor);
            labelTextReference.FontAttributes = currentFontType;
            labelTextReference.BackgroundColor = Color.Transparent;
            labelTextReference.FontFamily = FontFamily;
            labelTextReference.HorizontalOptions = LayoutOptions.Center;
            AbsoluteLayout.SetLayoutFlags(labelTextReference, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labelTextReference, new Rectangle(0.5, 0.5, -1, -1));
            //labelTextReference.TextColor = Color.Orange;
            imageButtonReference.GestureRecognizers.Add(GetVivacity());
            labelTextReference.GestureRecognizers.Add(GetVivacity());

            imageButtonReference.GestureRecognizers.Add(GetTouch());
            labelTextReference.GestureRecognizers.Add(GetTouch());
        }

        private void Touch_Tapped(object sender, EventArgs e)
        {
            Touched?.Invoke(this, EventArgs.Empty);
        }

        private TapGestureRecognizer GetTouch()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += Touch_Tapped;
            return touch;
        }

        /// <summary>
        /// Set Vivacity
        /// </summary>
        [Bindable(true)]
        public Vivacity Vivacity
        {
            get
            {
                return currentVivacity;
            }
            set
            {
                currentVivacity = value;
                VivacityPropertyChanged();
            }
        }

        private void VivacityPropertyChanged()
        {
            if (!IsReadOnly)
            {
                imageButtonReference.GestureRecognizers.Clear();
                labelTextReference.GestureRecognizers.Clear();

                imageButtonReference.GestureRecognizers.Add(GetVivacity());
                labelTextReference.GestureRecognizers.Add(GetVivacity());

                imageButtonReference.GestureRecognizers.Add(GetTouch());
                labelTextReference.GestureRecognizers.Add(GetTouch());

                imageButtonReference.Opacity = 1.0;
                labelTextReference.Opacity = 1.0;
            }
        }

        /// <summary>
        /// VivacitySpeed changes animation speed when selecting an item. 
        /// </summary>
        [Bindable(true)]
        public VivacitySpeed VivacitySpeed
        {
            get
            {
                return currentVivacitySpeed;
            }
            set
            {
                currentVivacitySpeed = value;
                VivacityPropertyChanged();
            }
        }


        /// <summary>
        /// Set Vivacity
        /// </summary>
        [Bindable(true)]
        public Depth Depth
        {
            get
            {
                return currentDepth;
            }
            set
            {
                currentDepth = value;
                DepthPropertyChanged();
            }
        }

        private void DepthPropertyChanged()
        {
            if (!IsReadOnly)
            {
                imageButtonReference.GestureRecognizers.Clear();
                labelTextReference.GestureRecognizers.Clear();

                imageButtonReference.GestureRecognizers.Add(GetVivacity());
                labelTextReference.GestureRecognizers.Add(GetVivacity());

                imageButtonReference.GestureRecognizers.Add(GetTouch());
                labelTextReference.GestureRecognizers.Add(GetTouch());

                imageButtonReference.Opacity = 1.0;
                labelTextReference.Opacity = 1.0;
            }
        }

        /// <summary>
        /// Property to report if button is readonly.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(ButtonConception),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: IsReadOnlyPropertyChanged);

        /// <summary>
        /// Property to report if button is readonly.
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

        private static void IsReadOnlyPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ButtonConception button = (ButtonConception)bindable;
            bool copyIsReadOnly = (bool)newValue;

            if (button.imageButtonReference != null && button.labelTextReference != null)
            {
                if (copyIsReadOnly)
                {
                    button.imageButtonReference.GestureRecognizers.Clear();
                    button.labelTextReference.GestureRecognizers.Clear();

                    button.imageButtonReference.Opacity = 0.3;
                    button.labelTextReference.Opacity = 0.3;
                }
                else
                {
                    button.imageButtonReference.GestureRecognizers.Add(button.GetVivacity());
                    button.labelTextReference.GestureRecognizers.Add(button.GetVivacity());

                    button.imageButtonReference.GestureRecognizers.Add(button.GetTouch());
                    button.labelTextReference.GestureRecognizers.Add(button.GetTouch());

                    button.imageButtonReference.Opacity = 1.0;
                    button.labelTextReference.Opacity = 1.0;
                }
            }
        }

        /// <summary>
        /// Set if is TextColor
        /// </summary>
        [Bindable(true)]
        public ColorUI TextColor
        {
            get
            {
                return currentTextColor;
            }
            set
            {
                currentTextColor = value;
                TextColorPropertyChanged();
            }
        }

        private void TextColorPropertyChanged()
        {
            if (labelTextReference != null)
            {
                labelTextReference.TextColor = GetColorFromColorUI(currentTextColor);
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
                ColorUIPropertyChanged(this, currentColorUI, value);
                currentColorUI = value;
            }
        }

        private void ColorUIPropertyChanged(object bindable, ColorUI oldValue, ColorUI newValue)
        {
            if (imageButtonReference != null)
            {
                imageButtonReference.ChangeColor("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", newValue);
            }
        }

        /// <summary>
        /// Enter the height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(ButtonConception),
            defaultValue: 40.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightPropertyChanged);

        /// <summary>
        /// Enter the height.
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
            ButtonConception buttonConception = (ButtonConception)bindable;
            double buttonHeight = (double)newValue;
            if (buttonConception.imageButtonReference != null)
            {
                buttonConception.imageButtonReference.HeightRequest = buttonHeight;
                buttonConception.imageButtonReference.MinimumHeightRequest = buttonHeight;
            }
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty HeightRequestProperty = BindableProperty.Create(
            propertyName: nameof(HeightRequest),
            returnType: typeof(double),
            declaringType: typeof(ButtonConception),
            defaultValue: 70.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Deprecate.
        /// </summary>
        [Obsolete]
        public new double HeightRequest
        {
            get
            {
                return (double)GetValue(HeightRequestProperty);
            }
            set { }
        }


        /// <summary>
        /// Enter the width.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(ButtonConception),
            defaultValue: 250.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter the width.
        /// </summary>
        public new double Width
        {
            get
            {
                return (double)GetValue(WidthProperty);
            }
            set
            {
                SetValue(WidthProperty, value);
            }
        }

        private static void WidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ButtonConception buttonConception = (ButtonConception)bindable;
            double buttonWidth = (double)newValue;

            if (buttonConception.imageButtonReference != null)
            {
                buttonConception.imageButtonReference.WidthRequest = buttonWidth;
                buttonConception.imageButtonReference.MinimumWidthRequest = buttonWidth;
            }
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty WidthRequestProperty = BindableProperty.Create(
            propertyName: nameof(WidthRequest),
            returnType: typeof(double),
            declaringType: typeof(ButtonConception),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Deprecate.
        /// </summary>
        [Obsolete]
        public new double WidthRequest
        {
            get
            {
                return (double)GetValue(WidthRequestProperty);
            }
            set { }
        }

        /// <summary>
        /// Enter the text
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(ButtonConception),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextPropertyChanged);

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

        private static void TextPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ButtonConception buttonConception = (ButtonConception)bindable;
            string buttonText = (string)newValue;
            buttonConception.labelTextReference.Text = buttonText;
        }

        /// <summary>
        /// Enter the font size of text button.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(ButtonConception),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size of text button.
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
            ButtonConception buttonConception = (ButtonConception)bindable;
            double copyFontSize = (double)newValue;
            buttonConception.labelTextReference.FontSize = copyFontSize;
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(ButtonConception),
            defaultValue: string.Empty,
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
            ButtonConception buttonConception = (ButtonConception)bindable;
            string copyFontFamily = (string)newValue;
            buttonConception.labelTextReference.FontFamily = copyFontFamily;
        }

        private Color GetColorFromColorUI(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Color.FromRgb(0, 0, 0);
                case ColorUI.Blue:
                    return Color.FromRgb(0, 0, 255);
                case ColorUI.Gray:
                    return Color.FromRgb(128, 128, 128);
                case ColorUI.Green:
                    return Color.FromRgb(0, 128, 0);
                case ColorUI.Red:
                    return Color.FromRgb(255, 0, 0);
                case ColorUI.Yellow:
                    return Color.FromRgb(255, 255, 0);
                case ColorUI.BlueLight:
                    return Color.FromRgb(170, 204, 255);
                case ColorUI.GreenLight:
                    return Color.FromRgb(0, 255, 0);
                case ColorUI.YellowLight:
                    return Color.FromRgb(255, 238, 170);
                case ColorUI.White:
                    return Color.FromRgb(255, 255, 255);
                case ColorUI.Pink:
                    return Color.FromRgb(255, 0, 255);
                case ColorUI.Orange:
                    return Color.FromRgb(255, 102, 0);
                case ColorUI.Brown:
                    return Color.FromRgb(128, 51, 0);
                case ColorUI.Purple:
                    return Color.FromRgb(128, 0, 128);
                case ColorUI.Turquoise:
                    return Color.FromRgb(0, 128, 128);
                case ColorUI.PinkLight:
                    return Color.FromRgb(255, 170, 204);
                case ColorUI.BlueSky:
                    return Color.FromRgb(85, 153, 255);
                case ColorUI.GrayLight:
                    return Color.FromRgb(204, 204, 204);
                case ColorUI.RedLight:
                    return Color.FromRgb(255, 128, 128);
                case ColorUI.OrangeLight:
                    return Color.FromRgb(255, 179, 128);
                case ColorUI.YellowDark:
                    return Color.FromRgb(255, 204, 0);
                case ColorUI.GreenDark:
                    return Color.FromRgb(34, 85, 0);
                case ColorUI.BlueDark:
                    return Color.FromRgb(0, 34, 85);
                case ColorUI.Aqua:
                    return Color.FromRgb(0, 255, 255);
                case ColorUI.Tan:
                    return Color.FromRgb(172, 157, 147);
                case ColorUI.GreenDarkness:
                    return Color.FromRgb(0, 34, 0);
                case ColorUI.BlueViolet:
                    return Color.FromRgb(138, 43, 226);
                default:
                    return Color.FromRgb(204, 204, 204);

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
                FontTypePropertyChanged(this, currentFontType, value);
                currentFontType = value;
            }
        }

        private void FontTypePropertyChanged(object bindable, FontAttributes oldValue, FontAttributes newValue)
        {
            labelTextReference.FontAttributes = newValue;
        }

        /// <summary>
        /// Set DesignType
        /// </summary>
        [Bindable(true)]
        public DesignType DesignType
        {
            get
            {
                return currentDesignType;
            }
            set
            {
                DesignTypePropertyChanged(this, currentDesignType, value);
                currentDesignType = value;
            }
        }

        private void DesignTypePropertyChanged(object bindable, DesignType oldValue, DesignType newValue)
        {
            if(imageButtonReference != null)
            {
                imageButtonReference.ChangeDesignType("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", newValue);
            }
        }

        private TapGestureRecognizer GetVivacity()
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + currentVivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
            TapGestureRecognizer touchVivavicity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
            return touchVivavicity;
        }

        private TapGestureRecognizer GetVivacityDecrease()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageButtonReference.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonReference.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityIncrease()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageButtonReference.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonReference.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityRotation()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageButtonReference.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonReference.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityJump()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageButtonReference.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityDown()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageButtonReference.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityLeft()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageButtonReference.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityRight()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageButtonReference.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                }
                catch { }
            };
            return animationTap;
        }

        private double GetDepthRight(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 2.00;
            }
            else if (depth == Depth.LessMedium)
            {
                return 3.0;
            }
            else if (depth == Depth.Medium)
            {
                return 5.0;
            }
            else
            {
                return 10.0;
            }
        }
    }
}
