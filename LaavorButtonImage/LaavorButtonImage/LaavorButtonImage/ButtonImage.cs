using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorButtonImage
{
    /// <summary>
    /// Class ButtonImage
    /// </summary>
    public class ButtonImage : StackLayout
    {
        /// <summary>
        /// Call when button is Touched
        /// </summary>
        public event EventHandler Touched;

        private AbsoluteLayout absoluteReference;
        private Image imageButton;
        private Label labelText;
        private FontAttributes currentFontType = FontAttributes.Bold;

        private Vivacity currentVivacity = Vivacity.Decrease;
        private Depth currentDepth = Depth.Medium;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;

        private ColorUI currentTextColor = ColorUI.Black;

        /// <summary>
        /// Constructor ButtonImage
        /// </summary>
        public ButtonImage()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            InitAll();
        }

        private void InitAll()
        {
            absoluteReference = new AbsoluteLayout();
            absoluteReference.HorizontalOptions = LayoutOptions.Center;

            CreateButton();

            absoluteReference.Children.Add(imageButton);
            absoluteReference.Children.Add(labelText);

            this.Children.Add(absoluteReference);
        }

        private void CreateButton()
        {
            imageButton = new Image();
            imageButton.HorizontalOptions = LayoutOptions.Center;
            imageButton.WidthRequest = Width;
            imageButton.HeightRequest = Height;
            imageButton.Aspect = Aspect.Fill;
            imageButton.Source = Image;

            labelText = new Label();
            labelText.Text = Text;
            labelText.TextColor = Colors.Get(currentTextColor);
            labelText.FontAttributes = currentFontType;
            labelText.BackgroundColor = Color.Transparent;
            labelText.FontFamily = FontFamily;
            labelText.HorizontalOptions = LayoutOptions.Center;
            AbsoluteLayout.SetLayoutFlags(labelText, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labelText, new Rectangle(0.5, 0.5, -1, -1));

            if (!IsReadOnly)
            {
                imageButton.GestureRecognizers.Add(GetVivacity(currentVivacity));
                labelText.GestureRecognizers.Add(GetVivacity(currentVivacity));

                imageButton.GestureRecognizers.Add(GetTouch());
                labelText.GestureRecognizers.Add(GetTouch());
            }
            else
            {
                imageButton.Opacity = 0.3;
                labelText.Opacity = 0.3;
            }
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
        /// Property to report if button is readonly.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(ButtonImage),
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
            ButtonImage button = (ButtonImage)bindable;
            bool copyIsReadOnly = (bool)newValue;

            if (button.imageButton == null || button.labelText == null)
            {
                return;
            }

            if (copyIsReadOnly)
            {
                button.imageButton.GestureRecognizers.Clear();
                button.labelText.GestureRecognizers.Clear();

                button.imageButton.Opacity = 0.3;
                button.labelText.Opacity = 0.3;
            }
            else
            {
                button.imageButton.GestureRecognizers.Add(button.GetVivacity(button.currentVivacity));
                button.labelText.GestureRecognizers.Add(button.GetVivacity(button.currentVivacity));

                button.imageButton.GestureRecognizers.Add(button.GetTouch());
                button.labelText.GestureRecognizers.Add(button.GetTouch());

                button.imageButton.Opacity = 1.0;
                button.labelText.Opacity = 1.0;
            }
        }

        /// <summary>
        /// Enter the Image Source of button.
        /// </summary>
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            propertyName: nameof(Image),
            returnType: typeof(string),
            declaringType: typeof(ButtonImage),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImagePropertyChanged);

        /// <summary>
        /// Enter the Image Source od button.
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
            ButtonImage buttonImage = (ButtonImage)bindable;
            string copyImage = (string)newValue;
            buttonImage.imageButton.Source = copyImage;
        }

        /// <summary>
        /// Enter the height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(ButtonImage),
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
            ButtonImage buttonImage = (ButtonImage)bindable;
            double buttonHeight = (double)newValue;
            buttonImage.imageButton.HeightRequest = buttonHeight;
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty HeightRequestProperty = BindableProperty.Create(
            propertyName: nameof(HeightRequest),
            returnType: typeof(double),
            declaringType: typeof(ButtonImage),
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
            declaringType: typeof(ButtonImage),
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
            ButtonImage buttonImage = (ButtonImage)bindable;
            double buttonWidth = (double)newValue;
            buttonImage.imageButton.WidthRequest = buttonWidth;
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty WidthRequestProperty = BindableProperty.Create(
            propertyName: nameof(WidthRequest),
            returnType: typeof(double),
            declaringType: typeof(ButtonImage),
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
            declaringType: typeof(ButtonImage),
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
            ButtonImage buttonImage = (ButtonImage)bindable;
            string buttonText = (string)newValue;
            if (!string.IsNullOrEmpty(buttonText))
            {
                buttonImage.labelText.Text = buttonText;
            }
        }

        /// <summary>
        /// Enter the font size of text button.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(ButtonImage),
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
            ButtonImage buttonImage = (ButtonImage)bindable;
            double copyFontSize = (double)newValue;
            buttonImage.labelText.FontSize = copyFontSize;
        }

        /// <summary>
        /// Set TextColor
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
            if (labelText != null && labelText != null)
            {
                labelText.TextColor = Colors.Get(currentTextColor);
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(ButtonImage),
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
            ButtonImage buttonImage = (ButtonImage)bindable;
            string copyFontFamily = (string)newValue;
            buttonImage.labelText.FontFamily = copyFontFamily;
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
            ButtonImage buttonImage = (ButtonImage)bindable;
            FontAttributes copyFontType = newValue;
            buttonImage.labelText.FontAttributes = copyFontType;
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
                imageButton.GestureRecognizers.Clear();
                labelText.GestureRecognizers.Clear();

                imageButton.GestureRecognizers.Add(GetVivacity(currentVivacity));
                labelText.GestureRecognizers.Add(GetVivacity(currentVivacity));

                imageButton.GestureRecognizers.Add(GetTouch());
                labelText.GestureRecognizers.Add(GetTouch());

                imageButton.Opacity = 1.0;
                labelText.Opacity = 1.0;
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
                imageButton.GestureRecognizers.Clear();
                labelText.GestureRecognizers.Clear();

                imageButton.GestureRecognizers.Add(GetVivacity(currentVivacity));
                labelText.GestureRecognizers.Add(GetVivacity(currentVivacity));

                imageButton.GestureRecognizers.Add(GetTouch());
                labelText.GestureRecognizers.Add(GetTouch());

                imageButton.Opacity = 1.0;
                labelText.Opacity = 1.0;
            }
        }

        private TapGestureRecognizer GetVivacity(Vivacity vivacity)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
            TapGestureRecognizer touchAnimation = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
            return touchAnimation;
        }

        private TapGestureRecognizer GetVivacityDecrease()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageButton.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await labelText.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
