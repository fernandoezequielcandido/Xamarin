using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{
    /// <summary>
    /// Class Submit
    /// </summary>
    public class Submit: StackLayout
    {
        /// <summary>
        /// Call when Button Submit is Touched
        /// </summary>
        public event EventHandler Touched;

        private Frame frameReference;
        private Label labelTextReference;

        private ColorUI currentColorUI = ColorUI.White;
        private ColorUI currentBorderColor = ColorUI.Black;
        private ColorUI currentTextColor = ColorUI.Black;
        
        private Vivacity currentVivacity = Vivacity.Decrease;
        private Depth currentDepth = Depth.Medium;

        private bool isInternalForm = false;

        /// <summary>
        /// Constructor of InitAll
        /// </summary>
        public Submit()
        {
            InitAll();
        }

        private void InitAll()
        {
            Children.Clear();

            labelTextReference = new Label();
            labelTextReference.VerticalOptions = LayoutOptions.Start;
            labelTextReference.HorizontalTextAlignment = TextAlignment.Center;
            labelTextReference.HorizontalOptions = LayoutOptions.Center;
            labelTextReference.FontSize = FontSize;
            labelTextReference.Margin = new Thickness(0, -10, 0, -10);
            labelTextReference.InputTransparent = InputTransparent;
            labelTextReference.TextColor = Colors.Get(currentTextColor);
            labelTextReference.BackgroundColor = Color.Transparent;
            labelTextReference.Text = Text;
            labelTextReference.GestureRecognizers.Add(GetVivacity(currentVivacity));
            labelTextReference.GestureRecognizers.Add(GetTouch());

            frameReference = new Frame();
            frameReference.BorderColor = Color.Black;
            frameReference.VerticalOptions = LayoutOptions.Center;
            frameReference.HorizontalOptions = LayoutOptions.Center;
            frameReference.BackgroundColor = Colors.Get(ColorUI);
            frameReference.GestureRecognizers.Add(GetVivacity(currentVivacity));
            frameReference.GestureRecognizers.Add(GetTouch());
            frameReference.BackgroundColor = Colors.Get(currentColorUI);
            frameReference.BorderColor = Colors.Get(currentBorderColor);
            frameReference.HasShadow = true;

            frameReference.Content = labelTextReference;

            Children.Add(frameReference);
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetIsForm(string key, bool value)
        {
            if(key == "ezequiel77_il_li_*+---////1")
            {
                isInternalForm = value;
            }
        }

        /// <summary>
        /// Property to report if Submit is IsReadOnly
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(Submit),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: IsReadOnlyPropertyChanged);

        /// <summary>
        /// Property to report if Submit is for display only.
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
            Submit submit = (Submit)bindable;
            bool copyIsReadOnly = (bool)newValue;

            if (copyIsReadOnly)
            {
                submit.frameReference.GestureRecognizers.Clear();
                submit.labelTextReference.GestureRecognizers.Clear();

                submit.frameReference.Opacity = 0.3;
                submit.labelTextReference.Opacity = 0.3;

                if(submit.isInternalForm)
                {
                    submit.labelTextReference.Text = submit.TextReadOnly;
                }
            }
            else
            {
                submit.frameReference.GestureRecognizers.Clear();
                submit.labelTextReference.GestureRecognizers.Clear();

                submit.frameReference.GestureRecognizers.Add(submit.GetVivacity(submit.currentVivacity));
                submit.labelTextReference.GestureRecognizers.Add(submit.GetVivacity(submit.currentVivacity));

                submit.frameReference.GestureRecognizers.Add(submit.GetTouch());
                submit.labelTextReference.GestureRecognizers.Add(submit.GetTouch());

                submit.frameReference.Opacity = 1.0;
                submit.labelTextReference.Opacity = 1.0;

                submit.labelTextReference.Text = submit.Text;
            }
        }
     
        /// <summary>
        /// Text 
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
                 propertyName: nameof(Text),
                 returnType: typeof(string),
                 declaringType: typeof(Submit),
                 defaultValue: "Submit",
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: TextPropertyChanged);

        /// <summary>
        /// Text
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
            Submit submit = (Submit)bindable;
            if (!submit.IsReadOnly && submit.labelTextReference != null)
            {
                submit.labelTextReference.Text = (string)newValue;
            }
        }

        /// <summary>
        /// Text ReadOnly
        /// </summary>
        public static readonly BindableProperty TextReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(TextReadOnly),
                 returnType: typeof(string),
                 declaringType: typeof(Submit),
                 defaultValue: "",
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: TextReadOnlyPropertyChanged);

        /// <summary>
        /// Text ReadOnly
        /// </summary>
        public string TextReadOnly
        {
            get
            {
                return (string)GetValue(TextReadOnlyProperty);
            }
            set
            {
                SetValue(TextReadOnlyProperty, value);
            }
        }

        private static void TextReadOnlyPropertyChanged(object bindable, object oldValue, object newValue)
        {
            Submit submit = (Submit)bindable;
            if (submit.IsReadOnly && submit.labelTextReference != null)
            {
                submit.labelTextReference.Text = (string)newValue;
            }
        }

        /// <summary>
        /// Enter the font size of text.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(Submit),
            defaultValue: 20.0,
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
            Submit submit = (Submit)bindable;
            double copyFontSize = (double)newValue;
            if (submit.labelTextReference != null && submit.labelTextReference != null)
            {
                submit.labelTextReference.FontSize = copyFontSize;
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
                labelTextReference.TextColor = Colors.Get(newValue);
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
                frameReference.BackgroundColor = Colors.Get(newValue);
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
                frameReference.BorderColor = Colors.Get(newValue);
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
                VivacityPropertyChanged(value);
            }
        }

        private void VivacityPropertyChanged(Vivacity newValue)
        {
            if (!IsReadOnly)
            {
                frameReference.GestureRecognizers.Clear();
                labelTextReference.GestureRecognizers.Clear();

                frameReference.GestureRecognizers.Add(GetVivacity(newValue));
                labelTextReference.GestureRecognizers.Add(GetVivacity(newValue));

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
                frameReference.GestureRecognizers.Clear();
                labelTextReference.GestureRecognizers.Clear();

                frameReference.GestureRecognizers.Add(GetVivacity(currentVivacity));
                labelTextReference.GestureRecognizers.Add(GetVivacity(currentVivacity));

                frameReference.GestureRecognizers.Add(GetTouch());
                labelTextReference.GestureRecognizers.Add(GetTouch());

                frameReference.Opacity = 1.0;
                labelTextReference.Opacity = 1.0;
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
                    await frameReference.ScaleTo(GetDepthDecrease(currentDepth), 100, Easing.Linear);
                    await labelTextReference.ScaleTo(GetDepthDecrease(currentDepth), 100, Easing.Linear);
                    await frameReference.ScaleTo(1, 100, Easing.Linear);
                    await labelTextReference.ScaleTo(1, 100, Easing.Linear);
                }
                catch { }
            };

            return animationTap;
        }

        private double GetDepthDecrease(Depth depth)
        {
            if (depth == Depth.LessMedium)
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
                    await frameReference.ScaleTo(GetDepthIncrease(currentDepth), 100, Easing.Linear);
                    await labelTextReference.ScaleTo(GetDepthIncrease(currentDepth), 100, Easing.Linear);
                    await frameReference.ScaleTo(1, 100, Easing.Linear);
                    await labelTextReference.ScaleTo(1, 100, Easing.Linear);
                }
                catch { }
            };

            return vivacityTap;
        }

        private double GetDepthIncrease(Depth depth)
        {
            if (depth == Depth.LessMedium)
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
                    await frameReference.TranslateTo(0, GetDepthJump(currentDepth), 100, Easing.Linear);
                    await labelTextReference.TranslateTo(0, GetDepthJump(currentDepth), 100, Easing.Linear);
                    await frameReference.TranslateTo(0, 0, 100, Easing.Linear);
                    await labelTextReference.TranslateTo(0, 0, 100, Easing.Linear);
                }
                catch { }
            };
            return vivacityTap;
        }

        private double GetDepthJump(Depth depth)
        {
            if (depth == Depth.LessMedium)
            {
                return -0.9;
            }
            else if (depth == Depth.Medium)
            {
                return -1.1;
            }
            else
            {
                return -1.3;
            }
        }

    }
}
