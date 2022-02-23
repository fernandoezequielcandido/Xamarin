using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorRatingSwap
{
    /// <summary>
    /// Class SwapLabelSimple
    /// </summary>
    public class SwapLabelSimple: StackLayout
    {
        /// <summary>
        /// Returns if first label is selected.
        /// </summary>
        public bool FirstIsSelected { get; private set; }

        private bool copyBlockSwap;

        /// <summary>
        /// Event called when selected any swap
        /// </summary>
        public event EventHandler OnSelect;

        private FontAttributes currentFontType = FontAttributes.None;
        private SwapAnimation currentSwapAnimation = SwapAnimation.None;

        private LaavorLabel labelReference = new LaavorLabel();

        /// <summary>
        /// Constructor of SwapLabelSimple
        /// </summary>
        public SwapLabelSimple() : base()
        {
            FirstIsSelected = true;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            Orientation = StackOrientation.Horizontal;
            InitAll();
        }

        private void InitAll()
        {
            Children.Clear();

            labelReference = new LaavorLabel();

            labelReference.Text = FirstText;
            labelReference.Number = 1;
            labelReference.FontAttributes = FontAttributes.Bold;
            labelReference.FontSize = SwapFontSize;
            labelReference.TextColor = FirstTextColor;
            labelReference.InputTransparent = false;
            labelReference.HorizontalTextAlignment = TextAlignment.Center;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Label_Clicked;
            labelReference.GestureRecognizers.Add(tapGestureRecognizer);
            labelReference.IsSelected = true;

            labelReference.FontAttributes = currentFontType;

            Children.Add(labelReference);

            copyBlockSwap = false;
        }

        /// <summary>
        /// Clears the swap value and shows everything in its initial state.
        /// </summary>
        public void ResetAll()
        {
            InitAll();
        }

        private TapGestureRecognizer GetClickAnimationDecreaseMedium(SwapAnimation swapAnimation)
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (swapAnimation == SwapAnimation.Default)
                    {
                        await labelReference.ScaleTo(0.77, 100, Easing.Linear);
                        await labelReference.ScaleTo(1, 100, Easing.Linear);
                    }
                }
                catch { }
            };

            return animationTap;
        }

        /// <summary>
        /// Set SwapAnimation(Default, None)
        /// </summary>
        [Bindable(true)]
        public SwapAnimation SwapAnimation
        {
            get
            {
                return currentSwapAnimation;
            }
            set
            {
                SwapAnimationPropertyChanged(currentSwapAnimation, value);
                currentSwapAnimation = value;
            }
        }

        private void SwapAnimationPropertyChanged(SwapAnimation oldValue, SwapAnimation newValue)
        {
            SwapAnimation swapAnimation = (SwapAnimation)newValue;
            labelReference.GestureRecognizers.Clear();

            labelReference.GestureRecognizers.Add(GetClickAnimationDecreaseMedium(newValue));

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Label_Clicked;
            labelReference.GestureRecognizers.Add(tapGestureRecognizer); 
        }


        /// <summary>
        /// Property to inform if block swap, also leave the swap unedited.
        /// </summary>
        public static readonly BindableProperty BlockSwapProperty = BindableProperty.Create(
                propertyName: nameof(BlockSwap),
                returnType: typeof(bool),
                declaringType: typeof(SwapLabelSimple),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Property to inform if block swap, also leave the swap unedited.
        /// </summary>
        public bool BlockSwap
        {
            get
            {
                return (bool)GetValue(BlockSwapProperty);
            }
            set
            {
                SetValue(BlockSwapProperty, value);
            }
        }

        /// <summary>
        /// Enter the text of first label.
        /// </summary>
        public static readonly BindableProperty FirstTextProperty = BindableProperty.Create(
            propertyName: nameof(FirstText),
            returnType: typeof(string),
            declaringType: typeof(SwapLabelSimple),
            defaultValue: "Insert first text",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FirstTextPropertyChanged);

        /// <summary>
        /// Enter the text of first label.
        /// </summary>
        public string FirstText
        {
            get
            {
                return (string)GetValue(FirstTextProperty);
            }
            set
            {
                SetValue(FirstTextProperty, value);
            }
        }

        private static void FirstTextPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabelSimple swap = (SwapLabelSimple)bindable;
            string copyFirstText = (string)newValue;

            if (swap.FirstIsSelected)
            {
                for (int iCh = 0; iCh < swap.Children.Count; iCh++)
                {
                    LaavorLabel label = (LaavorLabel)swap.Children[iCh];
                    label.Text = copyFirstText;
                }
            }
        }

        /// <summary>
        /// Enter the text of second label.
        /// </summary>
        public static readonly BindableProperty SecondTextProperty = BindableProperty.Create(
            propertyName: nameof(SecondText),
            returnType: typeof(string),
            declaringType: typeof(SwapLabelSimple),
            defaultValue: "Insert second text",
            defaultBindingMode: BindingMode.OneWay, 
            propertyChanged: SecondTextPropertyChanged);

        /// <summary>
        /// Enter the text of second label.
        /// </summary>
        public string SecondText
        {
            get
            {
                return (string)GetValue(SecondTextProperty);
            }
            set
            {
                SetValue(SecondTextProperty, value);
            }
        }

        private static void SecondTextPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabelSimple swap = (SwapLabelSimple)bindable;
            string copySecondText = (string)newValue;

            if (!swap.FirstIsSelected)
            {
                for (int iCh = 0; iCh < swap.Children.Count; iCh++)
                {
                    LaavorLabel label = (LaavorLabel)swap.Children[iCh];
                    label.Text = copySecondText;
                }
            }
        }

        /// <summary>
        /// Enter the font size, represents only one number.
        /// </summary>
        public static readonly BindableProperty SwapFontSizeProperty = BindableProperty.Create(
            propertyName: nameof(SwapFontSize),
            returnType: typeof(double),
            declaringType: typeof(SwapLabelSimple),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size, represents only one number.
        /// </summary>
        public double SwapFontSize
        {
            get
            {
                return (double)GetValue(SwapFontSizeProperty);
            }
            set
            {
                SetValue(SwapFontSizeProperty, value);
            }
        }

        private static void FontSizePropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabelSimple swap = (SwapLabelSimple)bindable;
            double copyFontSize = (double)newValue;
            for (int iCh = 0; iCh < swap.Children.Count; iCh++)
            {
                LaavorLabel label = (LaavorLabel)swap.Children[iCh];
                label.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Enter the first label text number color.
        /// </summary>
        public static readonly BindableProperty FirstTextColorProperty = BindableProperty.Create(
            propertyName: nameof(FirstTextColor),
            returnType: typeof(Color),
            declaringType: typeof(SwapLabelSimple),
            defaultValue: Color.Gold,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FirstTextColorPropertyChanged);

        /// <summary>
        /// Enter the first label text number color.
        /// </summary>
        public Color FirstTextColor
        {
            get
            {
                return (Color)GetValue(FirstTextColorProperty);
            }
            set
            {
                SetValue(FirstTextColorProperty, value);
            }
        }

        private static void FirstTextColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabelSimple swap = (SwapLabelSimple)bindable;
            Color copyColor = (Color)newValue;

            if (swap.FirstIsSelected)
            {
                for (int iCh = 0; iCh < swap.Children.Count; iCh++)
                {
                    LaavorLabel label = (LaavorLabel)swap.Children[iCh];
                    label.TextColor = copyColor;
                }
            }
        }

        /// <summary>
        /// Enter the second text number color.
        /// </summary>
        public static readonly BindableProperty SecondTextColorProperty = BindableProperty.Create(
          propertyName: nameof(SecondTextColor),
          returnType: typeof(Color),
          declaringType: typeof(SwapLabelSimple),
          defaultValue: Color.Black,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: SecondTextColorPropertyChanged);

        /// <summary>
        /// Enter the second text number color.
        /// </summary>
        public Color SecondTextColor
        {
            get
            {
                return (Color)GetValue(SecondTextColorProperty);
            }
            set
            {
                SetValue(SecondTextColorProperty, value);
            }
        }

        private static void SecondTextColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabelSimple swap = (SwapLabelSimple)bindable;
            Color copyColor = (Color)newValue;

            if (!swap.FirstIsSelected)
            {
                for (int iCh = 0; iCh < swap.Children.Count; iCh++)
                {
                    LaavorLabel label = (LaavorLabel)swap.Children[iCh];
                    label.TextColor = copyColor;
                }
            }
        }

        /// <summary>
        /// Enter the first background text number color.
        /// </summary>
        public static readonly BindableProperty FirstBackgroundColorProperty = BindableProperty.Create(
            propertyName: nameof(FirstBackgroundColor),
            returnType: typeof(Color),
            declaringType: typeof(SwapLabelSimple),
            defaultValue: Color.Transparent,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FirstBackgroundColorPropertyChanged);

        /// <summary>
        /// Enter the first background text number color.
        /// </summary>
        public Color FirstBackgroundColor
        {
            get
            {
                return (Color)GetValue(FirstBackgroundColorProperty);
            }
            set
            {
                SetValue(FirstBackgroundColorProperty, value);
            }
        }

        private static void FirstBackgroundColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabelSimple swap = (SwapLabelSimple)bindable;
            Color copyColor = (Color)newValue;

            if (swap.FirstIsSelected)
            {
                for (int iCh = 0; iCh < swap.Children.Count; iCh++)
                {
                    LaavorLabel label = (LaavorLabel)swap.Children[iCh];
                    label.BackgroundColor = copyColor;
                }
            }
        }

        /// <summary>
        /// Enter the second background text color.
        /// </summary>
        public static readonly BindableProperty SecondBackgroundColorProperty = BindableProperty.Create(
         propertyName: nameof(SecondBackgroundColor),
         returnType: typeof(Color),
         declaringType: typeof(SwapLabelSimple),
         defaultValue: Color.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: SecondBackgroundColorPropertyChanged);

        /// <summary>
        /// Enter the second background text number color.
        /// </summary>
        public Color SecondBackgroundColor
        {
            get
            {
                return (Color)GetValue(SecondBackgroundColorProperty);
            }
            set
            {
                SetValue(SecondBackgroundColorProperty, value);
            }
        }

        private static void SecondBackgroundColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabelSimple swap = (SwapLabelSimple)bindable;
            Color copyColor = (Color)newValue;

            if (!swap.FirstIsSelected)
            {
                for (int iCh = 0; iCh < swap.Children.Count; iCh++)
                {
                    LaavorLabel label = (LaavorLabel)swap.Children[iCh];
                    label.BackgroundColor = copyColor;
                }
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(SwapLabelSimple),
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
            SwapLabelSimple swap = (SwapLabelSimple)bindable;
            string copyFontFamily = (string)newValue;

            for (int iCh = 0; iCh < swap.Children.Count; iCh++)
            {
                if (swap.Children[iCh].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)swap.Children[iCh];
                    label.FontFamily = copyFontFamily;
                }
            }
        }

        /// <summary>
        /// Enter the fonttype title (None, Bold, Italic).
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
            SwapLabelSimple swap = (SwapLabelSimple)bindable;
            FontAttributes copyFontType = newValue;
            for (int iCh = 0; iCh < swap.Children.Count; iCh++)
            {
                if (swap.Children[iCh].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)swap.Children[iCh];
                    label.FontAttributes = copyFontType;
                }
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() != typeof(LaavorLabel))
            {
                Children.RemoveAt(Children.Count - 1);
            }
        }

        private void Label_Clicked(object sender, EventArgs e)
        {
            var labelSender = (LaavorLabel)sender;

            if (!copyBlockSwap)
            {
                if (FirstIsSelected)
                {
                    labelSender.TextColor = SecondTextColor;
                    labelSender.BackgroundColor = SecondBackgroundColor;
                    labelSender.Text = SecondText;
                    FirstIsSelected = false;
                }
                else
                {
                    labelSender.TextColor = FirstTextColor;
                    labelSender.BackgroundColor = FirstBackgroundColor;
                    labelSender.Text = FirstText;
                    FirstIsSelected = true;
                }

                if (BlockSwap)
                {
                    copyBlockSwap = BlockSwap;
                }
            }

            OnSelect?.Invoke(sender, e);
        }
    }
}
