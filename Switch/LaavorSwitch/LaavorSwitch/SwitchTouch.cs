using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorSwitch
{
    /// <summary>
    /// Class Switch
    /// </summary>
    public class SwitchTouch : StackLayout
    {
        /// <summary>
        /// Inform switch state 
        /// </summary>
        public State State { get; private set; }

        /// <summary>
        /// Event call when Switch is changed to on or off
        /// </summary>
        public event EventHandler ChangeState;

        private SwitchImage switchImageReference;
        private Label labelTextReference;

        private ColorUI currentColorUI = ColorUI.Blue;
        private DesignType currentDesignType = DesignType.Standard;

        private State currentInitialState =  State.Off;

        /// <summary>
        /// Constructor of Switch
        /// </summary>
        public SwitchTouch() : base()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            labelTextReference = null;

            Orientation = StackOrientation.Horizontal;

            InitAll();
        }

        private void InitAll()
        {
            Children.Clear();
            this.State = currentInitialState;

            switchImageReference = new SwitchImage("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentColorUI, this.State);
            switchImageReference.WidthRequest = Width;
            switchImageReference.HeightRequest = Height;

            switchImageReference.GestureRecognizers.Add(GetSwitchClick());
            
            Children.Add(switchImageReference);

            if (!string.IsNullOrEmpty(Text))
            {
                labelTextReference = new Label();
                labelTextReference.Text = Text;
                labelTextReference.FontSize = FontSize;
                labelTextReference.FontFamily = FontFamily;
                labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                labelTextReference.TextColor = TextColor;
                Children.Add(labelTextReference);
            }
        }

        private TapGestureRecognizer GetSwitchClick()
        {
            var switchItem = new TapGestureRecognizer();
            switchItem.Tapped += OnChangeState_Item;
            return switchItem;
        }

        private void OnChangeState_Item(object sender, EventArgs e)
        {
            SwitchImage switchImage = (SwitchImage)sender;

            if (switchImage.State == State.Off)
            {
                if (labelTextReference != null && !string.IsNullOrEmpty(Text))
                {
                    labelTextReference.Text = Text;
                }

                switchImage.ChangeState("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", State.On);
                State = State.On;
            }
            else
            {
                if (labelTextReference != null && !string.IsNullOrEmpty(TextOn))
                {
                    labelTextReference.Text = TextOn;
                }

                switchImage.ChangeState("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", State.Off);
                State = State.Off;
            }

            ChangeState?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Property to report if Switch is readonly.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(SwitchTouch),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: IsReadOnlyPropertyChanged);

        /// <summary>
        /// Property to report if Switch is readonly.
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
            SwitchTouch switchTouch = (SwitchTouch)bindable;
            bool copyIsReadOnly = (bool)newValue;
            if (copyIsReadOnly)
            {
                switchTouch.switchImageReference.GestureRecognizers.Clear();
                switchTouch.switchImageReference.Opacity = 0.25;
            }
            else
            {
                switchTouch.switchImageReference.GestureRecognizers.Add(switchTouch.GetSwitchClick());
                switchTouch.switchImageReference.Opacity = 1.0;
            }
        }

        /// <summary>
        /// Set InitialState
        /// </summary>
        [Bindable(true)]
        public State InitialState
        {
            get
            {
                return currentInitialState;
            }
            set
            {
                currentInitialState = value;
                InitAll();
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
            if (switchImageReference != null)
            {
                switchImageReference.ChangeColor("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentColorUI);
            }
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
                currentDesignType = value;
                DesignTypePropertyChanged();
            }
        }

        private void DesignTypePropertyChanged()
        {
            switchImageReference.ChangeDesignType("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentDesignType);
        }

        /// <summary>
        /// Enter the height Switch.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(SwitchTouch),
            defaultValue: 50.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightPropertyChanged);

        /// <summary>
        /// Enter the height Switch.
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
            SwitchTouch switchTouch = (SwitchTouch)bindable;
            double switchHeight = (double)newValue;
            for (int iCh = 0; iCh < switchTouch.Children.Count; iCh++)
            {
                if (switchTouch.Children[iCh].GetType() == typeof(SwitchImage))
                {
                    SwitchImage switchImage = (SwitchImage)switchTouch.Children[iCh];
                    switchTouch.HeightRequest = switchHeight;
                }
            }
        }

        /// <summary>
        /// Enter the width SwitchTouch.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(SwitchTouch),
            defaultValue: 80.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter the width SwitchTouch.
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
            SwitchTouch switchTouch = (SwitchTouch)bindable;
            double switchWidth = (double)newValue;
            for (int iCh = 0; iCh < switchTouch.Children.Count; iCh++)
            {
                if (switchTouch.Children[iCh].GetType() == typeof(SwitchImage))
                {
                    SwitchImage switchImage = (SwitchImage)switchTouch.Children[iCh];
                    switchImage.WidthRequest = switchWidth;
                }
            }
        }

        /// <summary>
        /// Enter the text
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(SwitchTouch),
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
            SwitchTouch switchTouch = (SwitchTouch)bindable;
            string swiText = (string)newValue;

            if (switchTouch.State != State.On)
            {
                if (switchTouch.labelTextReference == null)
                {
                    switchTouch.labelTextReference = new Label();
                }

                if (!string.IsNullOrEmpty(swiText))
                {
                    switchTouch.labelTextReference.Text = swiText;
                    switchTouch.labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                    switchTouch.labelTextReference.FontSize = switchTouch.FontSize;
                    switchTouch.labelTextReference.FontFamily = switchTouch.FontFamily;
                    switchTouch.labelTextReference.TextColor = switchTouch.TextColor;

                    if (switchTouch.Children.Count <= 2)
                    {
                        switchTouch.Children.Add(switchTouch.labelTextReference);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the text default -- (Is Optional  you can add your Label)
        /// </summary>
        public static readonly BindableProperty TextOnProperty = BindableProperty.Create(
            propertyName: nameof(TextOn),
            returnType: typeof(string),
            declaringType: typeof(SwitchTouch),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextOnPropertyChanged);

        /// <summary>
        /// Enter the TextOn -- (Is Optional you can add your Label)
        /// </summary>
        public string TextOn
        {
            get
            {
                return (string)GetValue(TextOnProperty);
            }
            set
            {
                SetValue(TextOnProperty, value);
            }
        }

        private static void TextOnPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwitchTouch switchTouch = (SwitchTouch)bindable;
            string onText = (string)newValue;

            if (switchTouch.State != State.Off)
            {
                if (switchTouch.labelTextReference == null)
                {
                    switchTouch.labelTextReference = new Label();
                }

                if (!string.IsNullOrEmpty(onText))
                {
                    switchTouch.labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                    switchTouch.labelTextReference.FontSize = switchTouch.FontSize;
                    switchTouch.labelTextReference.FontFamily = switchTouch.FontFamily;
                    switchTouch.labelTextReference.TextColor = switchTouch.TextColor;

                    if (switchTouch.Children.Count <= 2)
                    {
                        switchTouch.Children.Add(switchTouch.labelTextReference);
                    }

                    switchTouch.labelTextReference.Text = onText;
                }
            }
        }

        /// <summary>
        /// Enter the font size of text.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(SwitchTouch),
            defaultValue: 25.0,
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
            SwitchTouch switchTouch = (SwitchTouch)bindable;
            double copyFontSize = (double)newValue;

            if (switchTouch.labelTextReference == null)
            {
                switchTouch.labelTextReference = new Label();
                switchTouch.labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                switchTouch.labelTextReference.FontFamily = switchTouch.FontFamily;
                switchTouch.labelTextReference.TextColor = switchTouch.TextColor;

                if (switchTouch.Children.Count <= 2)
                {
                    switchTouch.Children.Add(switchTouch.labelTextReference);
                }
            }

            switchTouch.labelTextReference.FontSize = copyFontSize;
        }

        /// <summary>
        /// Enter the text color.
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
         propertyName: nameof(TextColor),
         returnType: typeof(Color),
         declaringType: typeof(SwitchTouch),
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
            SwitchTouch switchTouch = (SwitchTouch)bindable;
            Color copyTextColor = (Color)newValue;

            if (switchTouch.labelTextReference == null)
            {
                switchTouch.labelTextReference = new Label();
                switchTouch.labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                switchTouch.labelTextReference.FontSize = switchTouch.FontSize;
                switchTouch.labelTextReference.FontFamily = switchTouch.FontFamily;
                switchTouch.labelTextReference.TextColor = copyTextColor;

                if (switchTouch.Children.Count <= 2)
                {
                    switchTouch.Children.Add(switchTouch.labelTextReference);
                }
            }
            else
            {
                switchTouch.labelTextReference.TextColor = copyTextColor;
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(SwitchTouch),
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
            SwitchTouch switchTouch = (SwitchTouch)bindable;
            string copyFontFamily = (string)newValue;

            if (switchTouch.labelTextReference == null)
            {
                switchTouch.labelTextReference = new Label();
                switchTouch.labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                switchTouch.labelTextReference.FontSize = switchTouch.FontSize;
                switchTouch.labelTextReference.TextColor = switchTouch.TextColor;

                if (switchTouch.Children.Count <= 2)
                {
                    switchTouch.Children.Add(switchTouch.labelTextReference);
                }
            }
            switchTouch.labelTextReference.FontFamily = copyFontFamily;
        }

    }
}
