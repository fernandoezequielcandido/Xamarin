using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorButtonItalic
{
    /// <summary>
    /// Class Button Italic
    /// </summary>
    public class ButtonItalic : StackLayout
    {
        /// <summary>
        /// Call when Button Italic is Touched
        /// </summary>
        public event EventHandler Touched;

        private Frame frameReference;
        private Label labelTextReference;

        private StackLayout stackLabel;

        private StackLayout stackAll;

        private ColorUI currentColorUI = ColorUI.White;
        private ColorUI currentBorderColor = ColorUI.Black;
        private ColorUI currentTextColor = ColorUI.Black;
               
        private Vivacity vivacity = Vivacity.Decrease;
        private Depth depth = Depth.Medium;
        private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

        /// <summary>
        /// Class ButtonItalic
        /// </summary>
        public ButtonItalic()
        {
            InitAll();
        }

        private void InitAll()
        {
            Children.Clear();

            this.Spacing = 0;

            labelTextReference = new Label();
            labelTextReference.VerticalOptions = LayoutOptions.Start;
            labelTextReference.HorizontalTextAlignment = TextAlignment.Center;
            labelTextReference.HorizontalOptions = LayoutOptions.Center;
            labelTextReference.FontSize = FontSize;
            labelTextReference.Margin = new Thickness(0, -15, 0, -15);
            labelTextReference.InputTransparent = InputTransparent;
            labelTextReference.WidthRequest = Width;
            labelTextReference.TextColor = GetColorFromColorUI(currentTextColor);
            labelTextReference.BackgroundColor = Color.Transparent;
            labelTextReference.Text = Text;
            labelTextReference.GestureRecognizers.Add(GetVivacity(vivacity));
            labelTextReference.GestureRecognizers.Add(GetTouch());

            frameReference = new Frame();
            frameReference.BorderColor = Color.Black;
            frameReference.VerticalOptions = LayoutOptions.CenterAndExpand;
            frameReference.HorizontalOptions = LayoutOptions.CenterAndExpand;
            frameReference.BackgroundColor = GetColorFromColorUI(ColorUI);
            frameReference.GestureRecognizers.Add(GetVivacity(vivacity));
            frameReference.GestureRecognizers.Add(GetTouch());
            frameReference.BackgroundColor = GetColorFromColorUI(currentColorUI);
            frameReference.BorderColor = GetColorFromColorUI(currentBorderColor);
            frameReference.HasShadow = false;

            stackLabel = new StackLayout();
            stackLabel.Orientation = StackOrientation.Horizontal;

  
            frameReference.Content = labelTextReference;

            stackLabel.Children.Add(frameReference);

            stackLabel.Spacing = 0;

            stackAll = new StackLayout();
            stackAll.Spacing = 0;
            stackAll.Orientation = StackOrientation.Vertical;
 

            stackAll.Children.Add(stackLabel);

            Children.Add(stackAll);
        }

        /// <summary>
        /// Property to report if Button Italic is readonly.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(ButtonItalic),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: IsReadOnlyPropertyChanged);

        /// <summary>
        /// Property to report if Button Italic is readonly.
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
            ButtonItalic button = (ButtonItalic)bindable;
            bool copyIsReadOnly = (bool)newValue;
            if (copyIsReadOnly)
            {
                button.frameReference.GestureRecognizers.Clear();
                button.labelTextReference.GestureRecognizers.Clear();

                button.frameReference.Opacity = 0.3;
                button.labelTextReference.Opacity = 0.3;
            }
            else
            {
                button.frameReference.GestureRecognizers.Clear();
                button.labelTextReference.GestureRecognizers.Clear();

                button.frameReference.GestureRecognizers.Add(button.GetVivacity(button.vivacity));
                button.labelTextReference.GestureRecognizers.Add(button.GetVivacity(button.vivacity));

                button.frameReference.GestureRecognizers.Add(button.GetTouch());
                button.labelTextReference.GestureRecognizers.Add(button.GetTouch());

                button.frameReference.Opacity = 1.0;
                button.labelTextReference.Opacity = 1.0;
            }
        }

        /// <summary>
        /// Enter the text
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(ButtonItalic),
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
            ButtonItalic buttonItalic = (ButtonItalic)bindable;
            string buttonText = (string)newValue;
            if (buttonItalic != null)
            {
                buttonItalic.labelTextReference.Text = buttonText;
            }
        }

        /// <summary>
        /// Enter the font size of text Button Italic.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(ButtonItalic),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size of text Button Italic.
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
            ButtonItalic buttonItalic = (ButtonItalic)bindable;
            double copyFontSize = (double)newValue;
            if (buttonItalic.labelTextReference != null)
            {
                buttonItalic.labelTextReference.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Set ColorUI
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
                ColorUIPropertyChanged(value);
            }
        }

        private void ColorUIPropertyChanged(ColorUI newValue)
        {
            if (frameReference != null)
            {
                frameReference.BackgroundColor = GetColorFromColorUI(newValue);
            }
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
                TextColorPropertyChanged(value);
            }
        }

        private void TextColorPropertyChanged(ColorUI newValue)
        {
            if (labelTextReference != null)
            {
                labelTextReference.TextColor = GetColorFromColorUI(newValue);
            }
        }

        /// <summary>
        /// Set BorderColor
        /// </summary>
        [Bindable(true)]
        public ColorUI BorderColor
        {
            get
            {
                return currentBorderColor;
            }
            set
            {
                currentBorderColor = value;
                BorderColorPropertyChanged(value);
            }
        }

        private void BorderColorPropertyChanged(ColorUI newValue)
        {
            if (frameReference != null)
            {
                frameReference.BorderColor = GetColorFromColorUI(newValue);
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
                return vivacity;
            }
            set
            {
                vivacity = value;
                VivacityPropertyChanged();
            }
        }

        private void VivacityPropertyChanged()
        {
            if (!IsReadOnly)
            {
                frameReference.GestureRecognizers.Clear();
                labelTextReference.GestureRecognizers.Clear();

                frameReference.GestureRecognizers.Add(GetVivacity(vivacity));
                labelTextReference.GestureRecognizers.Add(GetVivacity(vivacity));

                frameReference.GestureRecognizers.Add(GetTouch());
                labelTextReference.GestureRecognizers.Add(GetTouch());

                frameReference.Opacity = 1.0;
                labelTextReference.Opacity = 1.0;
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
                return depth;
            }
            set
            {
                depth = value;
                DepthPropertyChanged();
            }
        }

        private void DepthPropertyChanged()
        {
            if (!IsReadOnly)
            {
                frameReference.GestureRecognizers.Clear();
                labelTextReference.GestureRecognizers.Clear();

                frameReference.GestureRecognizers.Add(GetVivacity(vivacity));
                labelTextReference.GestureRecognizers.Add(GetVivacity(vivacity));

                frameReference.GestureRecognizers.Add(GetTouch());
                labelTextReference.GestureRecognizers.Add(GetTouch());

                frameReference.Opacity = 1.0;
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
                return vivacitySpeed;
            }
            set
            {
                vivacitySpeed = value;
                VivacityPropertyChanged();
            }
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
                    await frameReference.ScaleTo(GetDepthDecrease(depth), 100, Easing.Linear);
                    await labelTextReference.ScaleTo(GetDepthDecrease(depth), 100, Easing.Linear);

                    await frameReference.ScaleTo(1, 100, Easing.Linear);
                    await labelTextReference.ScaleTo(1, 100, Easing.Linear);        
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
                    await frameReference.ScaleTo(GetDepthIncrease(depth), 100, Easing.Linear);
                    await labelTextReference.ScaleTo(GetDepthIncrease(depth), 100, Easing.Linear);

                    await frameReference.ScaleTo(1, 100, Easing.Linear);
                    await labelTextReference.ScaleTo(1, 100, Easing.Linear);
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
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await frameReference.TranslateTo(0, GetDepthJump(depth), 100, Easing.Linear);
                    await labelTextReference.TranslateTo(0, GetDepthJump(depth), 100, Easing.Linear);

                    await frameReference.TranslateTo(0, 0, 100, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, 100, Easing.Linear);
                }
                catch { }
            };
            return vivacityTap;
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
                    await frameReference.RotateTo(GetDepthRotation(depth), 100, Easing.Linear);
                    await labelTextReference.RotateTo(GetDepthRotation(depth), 100, Easing.Linear);

                    await frameReference.RotateTo(0, 100, Easing.Linear);
                    await labelTextReference.RotateTo(0, 100, Easing.Linear);
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
                    await frameReference.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);

                    await frameReference.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                    await frameReference.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);

                    await frameReference.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                    await frameReference.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);

                    await frameReference.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
