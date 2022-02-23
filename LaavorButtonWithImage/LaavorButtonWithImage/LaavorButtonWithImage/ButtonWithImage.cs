
using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorButtonWithImage
{
    /// <summary>
    /// Class ButtonWithImage
    /// </summary>
    public class ButtonWithImage : StackLayout
    {
        /// <summary>
        /// Event call when button is Touched
        /// </summary>
        public event EventHandler Touched;

        private Image imageInside;
        private Label labelTextReference;
        private ButtonWithImage_Image imageButtonWithImage_Image;

        private Depth currentDepth = Depth.Small;
        private Vivacity currentVivacity = Vivacity.Decrease;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Fast;

        private ColorUI currentColorUI = ColorUI.Gray;
        private DesignType currentDesignType = DesignType.Shinning;
        private FontAttributes currentFontType = FontAttributes.Bold;

        private ColorUI currentTextColor = ColorUI.Black;

        private AbsoluteLayout absolute;
        private StackLayout stackInternalBase;
        private StackLayout stackLabelAndImage;
        
        /// <summary>
        /// Constructor of Button With Image
        /// </summary>
        public ButtonWithImage()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            InitAll();
        }

        private void InitAll()
        {
            absolute = new AbsoluteLayout();
            absolute.HorizontalOptions = LayoutOptions.Center;

            stackInternalBase = new StackLayout();

            stackLabelAndImage = new StackLayout();
            stackLabelAndImage.Orientation = StackOrientation.Horizontal;
            stackLabelAndImage.VerticalOptions = LayoutOptions.CenterAndExpand;
            stackLabelAndImage.HorizontalOptions = LayoutOptions.CenterAndExpand;

            CreateButton();

            absolute.Children.Add(imageButtonWithImage_Image);
            absolute.Children.Add(stackInternalBase);

            this.Children.Add(absolute);
        }

        private void CreateButton()
        {
            imageButtonWithImage_Image = new ButtonWithImage_Image("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentDesignType, currentColorUI);
            imageButtonWithImage_Image.WidthRequest = Width;
            imageButtonWithImage_Image.MinimumWidthRequest = Width;
            imageButtonWithImage_Image.HeightRequest = Height;
            imageButtonWithImage_Image.MinimumHeightRequest = Height;

            imageInside = new Image();
            imageInside.Margin = new Thickness(0, 0, 5, 0);
            imageInside.WidthRequest = ImageInsideWidth;
            imageInside.MinimumWidthRequest = ImageInsideWidth;
            imageInside.HeightRequest = ImageInsideHeight;
            imageInside.MinimumHeightRequest = ImageInsideHeight;
            imageInside.VerticalOptions = LayoutOptions.Center;

            labelTextReference = new Label();
            labelTextReference.Text = Text;
            labelTextReference.TextColor = GetColorFromColorUI(currentTextColor);
            labelTextReference.FontAttributes = currentFontType;
            labelTextReference.BackgroundColor = Color.Transparent;
            labelTextReference.FontFamily = FontFamily;
            labelTextReference.HorizontalOptions = LayoutOptions.Center;
            labelTextReference.VerticalOptions = LayoutOptions.Center;

            stackLabelAndImage.Children.Add(imageInside);
            stackLabelAndImage.Children.Add(labelTextReference);

            stackInternalBase.Children.Add(stackLabelAndImage);

            AbsoluteLayout.SetLayoutFlags(stackInternalBase, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(stackInternalBase, new Rectangle(0.5, 0.5, 1.0, 1.0));

            imageInside.GestureRecognizers.Add(GetVivacity(currentVivacity));
            imageButtonWithImage_Image.GestureRecognizers.Add(GetVivacity(currentVivacity));
            labelTextReference.GestureRecognizers.Add(GetVivacity(currentVivacity));
            stackInternalBase.GestureRecognizers.Add(GetVivacity(currentVivacity));

            imageInside.GestureRecognizers.Add(GetTouch());
            imageButtonWithImage_Image.GestureRecognizers.Add(GetTouch());
            labelTextReference.GestureRecognizers.Add(GetTouch());
            stackInternalBase.GestureRecognizers.Add(GetTouch());
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
                imageInside.GestureRecognizers.Clear();
                imageButtonWithImage_Image.GestureRecognizers.Clear();
                labelTextReference.GestureRecognizers.Clear();
                stackInternalBase.GestureRecognizers.Clear();

                imageInside.GestureRecognizers.Add(GetVivacity(currentVivacity));
                imageButtonWithImage_Image.GestureRecognizers.Add(GetVivacity(currentVivacity));
                labelTextReference.GestureRecognizers.Add(GetVivacity(currentVivacity));
                stackInternalBase.GestureRecognizers.Add(GetVivacity(currentVivacity));

                imageInside.GestureRecognizers.Add(GetTouch());
                imageButtonWithImage_Image.GestureRecognizers.Add(GetTouch());
                labelTextReference.GestureRecognizers.Add(GetTouch());
                stackInternalBase.GestureRecognizers.Add(GetTouch());

                imageInside.Opacity = 1.0;
                imageButtonWithImage_Image.Opacity = 1.0;
                labelTextReference.Opacity = 1.0;
                stackInternalBase.Opacity = 1.0;
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
                VivacityPropertyChanged();
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
        /// Enter the Image.
        /// </summary>
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            propertyName: nameof(Image),
            returnType: typeof(string),
            declaringType: typeof(ButtonWithImage),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImagePropertyChanged);

        /// <summary>
        /// Enter the Image.
        /// </summary>
        public string Image
        {
            get
            {
                return (string)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
            }
        }

        private static void ImagePropertyChanged(object bindable, object oldValue, object newValue)
        {
            ButtonWithImage button = (ButtonWithImage)bindable;
            string image = (string)newValue;

            button.imageInside.Source = image;
        }

        /// <summary>
        /// Enter the image inside height.
        /// </summary>
        public static readonly BindableProperty ImageInsideHeightProperty = BindableProperty.Create(
            propertyName: nameof(ImageInsideHeight),
            returnType: typeof(double),
            declaringType: typeof(ButtonWithImage),
            defaultValue: 22.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImageInsideHeightPropertyChanged);

        /// <summary>
        /// Enter the image inside height.
        /// </summary>
        public double ImageInsideHeight
        {
            get
            {
                return (double)GetValue(ImageInsideHeightProperty);
            }
            set
            {
                SetValue(ImageInsideHeightProperty, value);
            }
        }

        private static void ImageInsideHeightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ButtonWithImage button = (ButtonWithImage)bindable;
            double height = (double)newValue;

            button.imageInside.HeightRequest = height;
        }

        /// <summary>
        /// Enter the image inside width.
        /// </summary>
        public static readonly BindableProperty ImageInsideWidthProperty = BindableProperty.Create(
            propertyName: nameof(ImageInsideWidth),
            returnType: typeof(double),
            declaringType: typeof(ButtonWithImage),
            defaultValue: 22.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImageInsideWidthPropertyChanged);

        /// <summary>
        /// Enter the image inside width.
        /// </summary>
        public double ImageInsideWidth
        {
            get
            {
                return (double)GetValue(ImageInsideWidthProperty);
            }
            set
            {
                SetValue(ImageInsideWidthProperty, value);
            }
        }

        private static void ImageInsideWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ButtonWithImage button = (ButtonWithImage)bindable;
            double width = (double)newValue;

            button.imageInside.WidthRequest = width;
        }

        /// <summary>
        /// Property to report if button is readonly.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(ButtonWithImage),
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
            ButtonWithImage button = (ButtonWithImage)bindable;
            bool copyIsReadOnly = (bool)newValue;
            if (copyIsReadOnly)
            {
                button.imageInside.GestureRecognizers.Clear();
                button.imageButtonWithImage_Image.GestureRecognizers.Clear();
                button.labelTextReference.GestureRecognizers.Clear();

                button.imageInside.Opacity = 0.3;
                button.imageButtonWithImage_Image.Opacity = 0.3;
                button.labelTextReference.Opacity = 0.3;
            }
            else
            {
                button.imageInside.GestureRecognizers.Add(button.GetVivacity(button.currentVivacity));
                button.imageButtonWithImage_Image.GestureRecognizers.Add(button.GetVivacity(button.currentVivacity));
                button.labelTextReference.GestureRecognizers.Add(button.GetVivacity(button.currentVivacity));
                button.stackInternalBase.GestureRecognizers.Add(button.GetVivacity(button.currentVivacity));

                button.imageInside.GestureRecognizers.Add(button.GetTouch());
                button.imageButtonWithImage_Image.GestureRecognizers.Add(button.GetTouch());
                button.labelTextReference.GestureRecognizers.Add(button.GetTouch());
                button.stackInternalBase.GestureRecognizers.Add(button.GetTouch());

                button.imageInside.Opacity = 1.0;
                button.imageButtonWithImage_Image.Opacity = 1.0;
                button.labelTextReference.Opacity = 1.0;
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
            if(imageButtonWithImage_Image != null)
            {
                imageButtonWithImage_Image.ChangeColor("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentColorUI);
            }
        }

        /// <summary>
        /// Enter the height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(ButtonWithImage),
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
            ButtonWithImage button = (ButtonWithImage)bindable;
            double buttonHeight = (double)newValue;

            if (button.imageButtonWithImage_Image != null)
            {
                button.imageButtonWithImage_Image.HeightRequest = buttonHeight;
                button.imageButtonWithImage_Image.MinimumHeightRequest = buttonHeight;
            }
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty HeightRequestProperty = BindableProperty.Create(
            propertyName: nameof(HeightRequest),
            returnType: typeof(double),
            declaringType: typeof(ButtonWithImage),
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
            declaringType: typeof(ButtonWithImage),
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
            ButtonWithImage button = (ButtonWithImage)bindable;
            double buttonWidth = (double)newValue;

            if (button.imageButtonWithImage_Image != null)
            {
                button.imageButtonWithImage_Image.WidthRequest = buttonWidth;
                button.imageButtonWithImage_Image.MinimumWidthRequest = buttonWidth;
            }
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty WidthRequestProperty = BindableProperty.Create(
            propertyName: nameof(WidthRequest),
            returnType: typeof(double),
            declaringType: typeof(ButtonWithImage),
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
            declaringType: typeof(ButtonWithImage),
            defaultValue: "",
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
            ButtonWithImage button = (ButtonWithImage)bindable;
            string buttonText = (string)newValue;
            button.labelTextReference.Text = buttonText;
        }

        /// <summary>
        /// Enter the font size of text button.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(ButtonWithImage),
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
            ButtonWithImage button = (ButtonWithImage)bindable;
            double copyFontSize = (double)newValue;
            button.labelTextReference.FontSize = copyFontSize;
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
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(ButtonWithImage),
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
            ButtonWithImage button = (ButtonWithImage)bindable;
            string copyFontFamily = (string)newValue;
            button.labelTextReference.FontFamily = copyFontFamily;
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

        private static void FontTypePropertyChanged(object bindable, FontAttributes oldValue, FontAttributes newValue)
        {
            ButtonWithImage button = (ButtonWithImage)bindable;
            FontAttributes copyFontType = newValue;
            button.labelTextReference.FontAttributes = copyFontType;
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

        private static void DesignTypePropertyChanged(object bindable, object oldValue, object newValue)
        {
            ButtonWithImage button = (ButtonWithImage)bindable;
            DesignType copyDesignType = (DesignType)newValue;

            if(button.imageButtonWithImage_Image != null)
            {
                button.imageButtonWithImage_Image.ChangeDesignType("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", copyDesignType);
            }
        }
 
        private TapGestureRecognizer GetVivacity(Vivacity vivacity)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
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
                    await imageInside.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);

                    await imageInside.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageInside.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);

                    await imageInside.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityJump()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageInside.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);

                    await imageInside.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityRotation()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {                   
                    await imageInside.RotateTo(GetDepthRotation(currentDepth), 100, Easing.Linear);
                    await imageButtonWithImage_Image.RotateTo(GetDepthRotation(currentDepth), 100, Easing.Linear);
                    await labelTextReference.RotateTo(GetDepthRotation(currentDepth), 100, Easing.Linear);
                    await stackInternalBase.RotateTo(GetDepthRotation(currentDepth), 100, Easing.Linear);

                    await imageInside.RotateTo(0, 100, Easing.Linear);
                    await imageButtonWithImage_Image.RotateTo(0, 100, Easing.Linear);
                    await labelTextReference.RotateTo(0, 100, Easing.Linear);
                    await stackInternalBase.RotateTo(0, 100, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityDown()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageInside.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);

                    await imageInside.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageInside.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);

                    await imageInside.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageInside.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);

                    await imageInside.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButtonWithImage_Image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await stackInternalBase.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
