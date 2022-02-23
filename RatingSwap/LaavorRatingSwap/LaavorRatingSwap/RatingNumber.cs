using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorRatingSwap
{
    /// <summary>
    /// Class RatingNumber
    /// </summary>
    public class RatingNumber: StackLayout
    {
        /// <summary>
        /// Returns the value of the voted rating
        /// </summary>
        public double Value { get; private set; }

        /// <summary>
        /// Returns the value of Index Selected starting in 0 
        /// </summary>
         public int IndexSelected { get; private set; }

        /// <summary>
        /// Returns the value of Index Voted starting in 0 
        /// </summary>
        public int IndexVoted { get; private set; }

        private List<double> indexesValues;

        private bool isIntegerType = true;

        private bool copyBlockSelect;

        private bool changeDefaultWidth = false;

        private string formatDouble;

        private FontAttributes currentFontType = FontAttributes.None;

        private Vivacity currentVivacity = Vivacity.Increase;
        private VivacityMode currentVivacityMode = VivacityMode.All;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;
        private Depth currentDepth = Depth.Medium;

        private ColorUI currentTextColorVoted = ColorUI.Black;
        private ColorUI currentTextColorUnVoted = ColorUI.Yellow;

        private ColorUI currentColorUIVoted = ColorUI.Yellow;
        private ColorUI currentColorUIUnVoted = ColorUI.Black;

        private List<LaavorLabelNumber> listLabelsToAnimate;

        /// <summary>
        /// Event called when selected any rating
        /// </summary>
        public event EventHandler OnSelect;

        /// <summary>
        /// Event called when is Voted
        /// </summary>
        public event EventHandler Voted;

        /// <summary>
        /// Constructor of RatingNumber
        /// </summary>
        public RatingNumber() : base()
        {
            Value = 0;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            Orientation = StackOrientation.Horizontal;
            InitAll();
            this.HorizontalOptions = LayoutOptions.Center;
        }

        private void CreateIndexValues()
        {
            indexesValues = new List<double>();
            indexesValues.Insert(0, 0);

            double currentValue = InitialNumber;
            for (int iItem = 1; iItem <= ItemsNumber; iItem++)
            {
                indexesValues.Insert(iItem, currentValue);
                currentValue += Step;
            }

            if(Step > 1)
            {
                if((Step % 2) != 0)
                {
                    isIntegerType = false;
                }
            }
            else if(Step < 1)
            {
                isIntegerType = false;
            }

            if (InitialValue > 1)
            {
                if ((InitialValue % 2) != 0)
                {
                    isIntegerType = false;
                }
            }
            else if (InitialValue < 1 && InitialValue != 0)
            {
                isIntegerType = false;
            }

            if(!isIntegerType)
            {
                string baseMask = "{0:0.";
                string[] dec = Step.ToString().Split(',');
                if(dec.Length > 1)
                {
                    for (int ibm = 0; ibm < dec[1].Length; ibm++)
                    {
                        baseMask += "0";
                    }
                }
                else
                {
                    dec = Step.ToString().Split('.');
                    if (dec.Length > 1)
                    {
                        for (int ibm = 0; ibm < dec[1].Length; ibm++)
                        {
                            baseMask += "0";
                        }
                    }
                    else
                    {
                        baseMask = "";
                    }
                }

                if(!string.IsNullOrEmpty(baseMask))
                {
                    baseMask += "}";
                }
                
                formatDouble = baseMask;
            }

        }

        private void InitAll()
        {
            listLabelsToAnimate = new List<LaavorLabelNumber>();
            IndexVoted = -1;

            if (Value == 0)
            {
                Value = InitialValue;
            }

            if (InitialValue > ItemsNumber)
            {
                InitialValue = ItemsNumber;
            }

            CreateIndexValues();

            Children.Clear();

            for (int index = 1; index < indexesValues.Count; index++)
            {
                LaavorLabelNumber label = new LaavorLabelNumber();

                if (isIntegerType)
                {
                    label.Text = ((int)indexesValues[index]).ToString();

                    if (!changeDefaultWidth)
                    {
                        label.WidthRequest = 35;
                    }
                }
                else
                {
                    if(!string.IsNullOrEmpty(formatDouble))
                    {
                        label.Text = String.Format(CultureInfo.CurrentCulture, formatDouble, indexesValues[index]);

                        if (!changeDefaultWidth)
                        {
                            label.WidthRequest = 60;
                        }
                    }
                    else
                    {
                        label.Text = ((int)indexesValues[index]).ToString();

                        if (!changeDefaultWidth)
                        {
                            label.WidthRequest = 35;
                        }
                    }
                }

                label.Number = indexesValues[index];
                label.index = index;
                if (changeDefaultWidth)
                {
                    label.WidthRequest = Width;
                }
                label.FontSize = NumberFontSize;
                label.InputTransparent = false;
                label.HorizontalTextAlignment = TextAlignment.Center;
                label.FontAttributes = currentFontType;
                label.FontFamily = FontFamily;

                if (InitialValue == 0 || index > InitialValue)
                {
                    label.TextColor = Colors.Get(currentTextColorUnVoted);
                    label.BackgroundColor = Colors.Get(currentColorUIUnVoted);
                    label.IsSelected = false;
                }
                else if (index <= InitialValue)
                {
                    label.TextColor = Colors.Get(currentTextColorVoted);
                    label.BackgroundColor = Colors.Get(currentColorUIVoted);
                    label.IsSelected = true;
                }

                if (!IsReadOnly)
                {
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += Label_Clicked;
                    label.GestureRecognizers.Add(tapGestureRecognizer);
                }

                listLabelsToAnimate.Add(label);

                label.Margin = SpaceBetween;

                Children.Add(label);

                copyBlockSelect = false;
            }

            if (!IsReadOnly)
            {
                for (int index = 0; index < listLabelsToAnimate.Count; index++)
                {
                    LaavorLabelNumber label = listLabelsToAnimate[index];
                    if (currentVivacity != Vivacity.None)
                    {
                        label.GestureRecognizers.Add(GetVivacity(index));
                    }
                }
            }

            double padMargin = 0;

            if (Margin.Left >= 0)
            {
                padMargin = Margin.Left - SpaceBetween;

                if (padMargin < 0)
                {
                    padMargin = 0;
                }
            }
            else
            {
                padMargin = Margin.Left;
            }

            Margin = new Thickness(padMargin, Margin.Top, Margin.Right, Margin.Bottom);
        }

        /// <summary>
        /// Clears the rating value and shows everything in its initial state.
        /// </summary>
        public void ResetAll()
        {
            IsReadOnly = false;
            InitAll();
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
                for (int index = 0; index < listLabelsToAnimate.Count; index++)
                {
                    LaavorLabelNumber number = listLabelsToAnimate[index];
                    number.GestureRecognizers.Clear();

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += Label_Clicked;
                    number.GestureRecognizers.Add(tapGestureRecognizer);

                    if (currentVivacity != Vivacity.None)
                    {
                        number.GestureRecognizers.Add(GetVivacity(index));
                    }
                }
            }
        }

        /// <summary>
        /// Set VivacityMode(Single, All)
        /// </summary>
        [Bindable(true)]
        public VivacityMode VivacityMode
        {
            get
            {
                return currentVivacityMode;
            }
            set
            {
                currentVivacityMode = value;
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
                VivacitySpeedPropertyChanged();
            }
        }

        private void VivacitySpeedPropertyChanged()
        {
            if (!IsReadOnly)
            {
                for (int index = 0; index < listLabelsToAnimate.Count; index++)
                {
                    LaavorLabelNumber number = listLabelsToAnimate[index];
                    number.GestureRecognizers.Clear();

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += Label_Clicked;
                    number.GestureRecognizers.Add(tapGestureRecognizer);

                    if (currentVivacity != Vivacity.None)
                    {
                        number.GestureRecognizers.Add(GetVivacity(index));
                    }
                }
            }
        }

        /// <summary>
        /// Property to report if rating is for display only.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(RatingNumber),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: IsReadOnlyPropertyChanged);

        /// <summary>
        /// Property to report if rating is for display only.
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
            RatingNumber rating = (RatingNumber)bindable;
            bool copyIsReadOnly = (bool)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber label = (LaavorLabelNumber)rating.Children[iItem];

                    if (copyIsReadOnly)
                    {
                        label.GestureRecognizers.Clear();
                    }
                    else
                    {
                        var tapGestureRecognizer = new TapGestureRecognizer();
                        tapGestureRecognizer.Tapped += rating.Label_Clicked;
                        label.GestureRecognizers.Add(tapGestureRecognizer);
                        label.Margin = rating.SpaceBetween;
                        if (rating.currentVivacity != Vivacity.None)
                        {
                            label.GestureRecognizers.Add(rating.GetVivacity(iItem));
                        }
                    }
                }
            }

            double padMargin = 0;

            if (rating.Margin.Left >= 0)
            {
                padMargin = rating.Margin.Left - rating.SpaceBetween;

                if (padMargin < 0)
                {
                    padMargin = 0;
                }
            }
            else
            {
                padMargin = rating.Margin.Left;
            }

            rating.Margin = new Thickness(padMargin, rating.Margin.Top, rating.Margin.Right, rating.Margin.Bottom);
        }

        /// <summary>
        /// Property to inform SpaceBetween Number rating
        /// </summary>
        public static readonly BindableProperty SpaceBetweenProperty = BindableProperty.Create(
                 propertyName: nameof(SpaceBetween),
                 returnType: typeof(int),
                 declaringType: typeof(RatingImage),
                 defaultValue: 0,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: SpaceBetweenPropertyChanged);

        /// <summary>
        /// Property to inform SpaceBetween Number rating
        /// </summary>
        public int SpaceBetween
        {
            get
            {
                return (int)GetValue(SpaceBetweenProperty);
            }
            set
            {
                SetValue(SpaceBetweenProperty, value);
            }
        }

        private static void SpaceBetweenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingNumber rating = (RatingNumber)bindable;
            int copyMargin = (int)newValue;

            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber label = (LaavorLabelNumber)rating.Children[iItem];
                    label.Margin = copyMargin;
                }
            }

            double padMargin = 0;

            if (rating.Margin.Left >= 0)
            {
                padMargin = rating.Margin.Left - rating.SpaceBetween;

                if (padMargin < 0)
                {
                    padMargin = 0;
                }
            }
            else
            {
                padMargin = rating.Margin.Left;
            }

            rating.Margin = new Thickness(padMargin, rating.Margin.Top, rating.Margin.Right, rating.Margin.Bottom);
        }

        /// <summary>
        /// Property to inform if unselected ratings will hide, also leave the rating unedited.
        /// </summary>
        public static readonly BindableProperty BlockSelectProperty = BindableProperty.Create(
                propertyName: nameof(BlockSelect),
                returnType: typeof(bool),
                declaringType: typeof(RatingNumber),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Property to inform if unselected ratings will hide, also leave the rating unedited.
        /// </summary>
        public bool BlockSelect
        {
            get
            {
                return (bool)GetValue(BlockSelectProperty);
            }
            set
            {
                SetValue(BlockSelectProperty, value);
            }
        }

        /// <summary>
        /// Property to inform inital value (Index Selected) (preselect Index Rating).
        /// </summary>
        public static readonly BindableProperty InitialValueProperty = BindableProperty.Create(
                 propertyName: nameof(InitialValue),
                 returnType: typeof(int),
                 declaringType: typeof(RatingNumber),
                 defaultValue: 0,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: InitialValuePropertyChanged);

        /// <summary>
        /// Property to inform inital value (Index Selected) (preselect Index Rating).
        /// </summary>
        public int InitialValue
        {
            get
            {
                return (int)GetValue(InitialValueProperty);
            }
            set
            {
                SetValue(InitialValueProperty, value);
            }
        }

        private static void InitialValuePropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingNumber rating = (RatingNumber)bindable;
            int copyInitialValue = (int)newValue;
            rating.IndexVoted = copyInitialValue - 1;
            
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber number = (LaavorLabelNumber)rating.Children[iItem];

                    if (copyInitialValue == 0 || (iItem + 1) > rating.InitialValue)
                    {
                        number.TextColor = Colors.Get(rating.currentTextColorUnVoted);
                        number.BackgroundColor = Colors.Get(rating.currentColorUIUnVoted);
                        number.IsSelected = false;
                    }
                    else if ((iItem + 1) <= copyInitialValue)
                    {
                        number.TextColor = Colors.Get(rating.currentTextColorVoted);
                        number.BackgroundColor = Colors.Get(rating.currentColorUIVoted);
                        number.IsSelected = true;
                    }
                }
            }
        }

        /// <summary>
        /// Enter the number of numbers you want show in rating.
        /// </summary>
        public static readonly BindableProperty ItemsNumberProperty = BindableProperty.Create(
            propertyName: nameof(ItemsNumber),
            returnType: typeof(int),
            declaringType: typeof(RatingNumber),
            defaultValue: 5,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ItemsNumberPropertyChanged);

        /// <summary>
        /// Enter the number of numbers you want show in rating.
        /// </summary>
        public int ItemsNumber
        {
            get
            {
                return (int)GetValue(ItemsNumberProperty);
            }
            set
            {
                SetValue(ItemsNumberProperty, value);
            }
        }

        private static void ItemsNumberPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingNumber rating = (RatingNumber)bindable;
            rating.InitAll();
        }

        /// <summary>
        /// Enter the initial number, starter in in rating.
        /// </summary>
        public static readonly BindableProperty InitialNumberProperty = BindableProperty.Create(
            propertyName: nameof(InitialNumber),
            returnType: typeof(double),
            declaringType: typeof(RatingNumber),
            defaultValue: 1.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ItemsNumberPropertyChanged);

        /// <summary>
        /// Enter the initial number, starter in in rating.
        /// </summary>
        public double InitialNumber
        {
            get
            {
                return (double)GetValue(InitialNumberProperty);
            }
            set
            {
                SetValue(InitialNumberProperty, value);
            }
        }

        private static void InitialNumberPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingNumber rating = (RatingNumber)bindable;
            rating.InitAll();
        }

        /// <summary>
        /// Enter the number width, represents only one number.
        /// </summary>
        public static readonly BindableProperty TextWidthProperty = BindableProperty.Create(
            propertyName: nameof(TextWidth),
            returnType: typeof(double),
            declaringType: typeof(RatingNumber),
            defaultValue: 20.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextWidthPropertyChanged);

        /// <summary>
        /// Enter the number width, represents only one number.
        /// </summary>
        public double TextWidth
        {
            get
            {
                return (double)GetValue(TextWidthProperty);
            }
            set
            {
                SetValue(TextWidthProperty, value);
            }
        }

        private static void TextWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingNumber rating = (RatingNumber)bindable;
            double copyWidth = (double)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber label = (LaavorLabelNumber)rating.Children[iItem];
                    label.WidthRequest = copyWidth;
                }
            }
        }

        /// <summary>
        /// Enter the font size, represents only one number.
        /// </summary>
        public static readonly BindableProperty NumberFontSizeProperty = BindableProperty.Create(
            propertyName: nameof(NumberFontSize),
            returnType: typeof(double),
            declaringType: typeof(RatingNumber),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size, represents only one number.
        /// </summary>
        public double NumberFontSize
        {
            get
            {
                return (double)GetValue(NumberFontSizeProperty);
            }
            set
            {
                SetValue(NumberFontSizeProperty, value);
            }
        }

        private static void FontSizePropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingNumber rating = (RatingNumber)bindable;
            double copyFontSize = (double)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber number = (LaavorLabelNumber)rating.Children[iItem];
                    number.FontSize = copyFontSize;
                }
            }
        }

        /// <summary>
        /// Enter the Step
        /// </summary>
        public static readonly BindableProperty StepProperty = BindableProperty.Create(
            propertyName: nameof(Step),
            returnType: typeof(double),
            declaringType: typeof(RatingNumber),
            defaultValue: 1.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: StepPropertyChanged);

        /// <summary>
        /// Enter the step
        /// </summary>
        public double Step
        {
            get
            {
                return (double)GetValue(StepProperty);
            }
            set
            {
                SetValue(StepProperty, value);
            }
        }

        private static void StepPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingNumber rating = (RatingNumber)bindable;
            rating.InitAll();
        }

        /// <summary>
        /// Enter the Voted text letter color.
        /// </summary>
        [Bindable(true)]
        public ColorUI TextColorVoted
        {
            get
            {
                return currentTextColorVoted;
            }
            set
            {
                currentTextColorVoted = value;
                TextColorVotedPropertyChanged();
            }
        }

        private void TextColorVotedPropertyChanged()
        {
            for (int iItem = 0; iItem < Children.Count; iItem++)
            {
                if (Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber label = (LaavorLabelNumber)Children[iItem];
                    if (label.IsSelected)
                    {
                        label.TextColor = Colors.Get(currentTextColorVoted);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the UnVoted text letter color.
        /// </summary>
        [Bindable(true)]
        public ColorUI TextColorUnVoted
        {
            get
            {
                return currentTextColorUnVoted;
            }
            set
            {
                currentTextColorUnVoted = value;
                TextColorUnVotedPropertyChanged();
            }
        }

        private void TextColorUnVotedPropertyChanged()
        {
            for (int iItem = 0; iItem < Children.Count; iItem++)
            {
                if (Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber label = (LaavorLabelNumber)Children[iItem];

                    if (!label.IsSelected)
                    {
                        label.TextColor = Colors.Get(currentTextColorUnVoted);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the select ColorUIVoted (background) color letter.
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUIVoted
        {
            get
            {
                return currentColorUIVoted;
            }
            set
            {
                currentColorUIVoted = value;
                ColorUIVotedPropertyChanged();
            }
        }

        private void ColorUIVotedPropertyChanged()
        {
            for (int iItem = 0; iItem < Children.Count; iItem++)
            {
                if (Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber label = (LaavorLabelNumber)Children[iItem];

                    if (label.IsSelected)
                    {
                        label.BackgroundColor = Colors.Get(currentColorUIVoted);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the select ColorUIUnVoted (background) color letter.
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUIUnVoted
        {
            get
            {
                return currentColorUIUnVoted;
            }
            set
            {
                currentColorUIUnVoted = value;
                ColorUIUnVotedPropertyChanged();
            }
        }

        private void ColorUIUnVotedPropertyChanged()
        {
            for (int iItem = 0; iItem < Children.Count; iItem++)
            {
                if (Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber label = (LaavorLabelNumber)Children[iItem];

                    if (!label.IsSelected)
                    {
                        label.BackgroundColor = Colors.Get(currentColorUIUnVoted);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the width, represents only one number.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(RatingNumber),
            defaultValue: 35.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter the width, represents only one number.
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
            RatingNumber rating = (RatingNumber)bindable;
            double numberWidth = (double)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber number = (LaavorLabelNumber)rating.Children[iItem];
                    number.WidthRequest = numberWidth;
                }
            }
            rating.changeDefaultWidth = true;
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(RatingNumber),
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
            RatingNumber rating = (RatingNumber)bindable;
            string copyFontFamily = (string)newValue;

            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber number = (LaavorLabelNumber)rating.Children[iItem];
                    number.FontFamily = copyFontFamily;
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
                currentFontType = value;
                FontTypePropertyChanged(value);
            }
        }

        private void FontTypePropertyChanged(FontAttributes newValue)
        {
            for (int iItem = 0; iItem < Children.Count; iItem++)
            {
                if (Children[iItem].GetType() == typeof(LaavorLabelNumber))
                {
                    LaavorLabelNumber number = (LaavorLabelNumber)Children[iItem];
                    number.FontAttributes = newValue;
                }
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() != typeof(LaavorLabelNumber))
            {
                Children.RemoveAt(Children.Count - 1);
            }
        }

        private void Label_Clicked(object sender, EventArgs e)
        {
            var labelSender = (LaavorLabelNumber)sender;
            
            if (IsReadOnly)
            {
                return;
            }

            if (!copyBlockSelect)
            {
                if (!labelSender.IsSelected)
                {
                    for (int iItem = labelSender.index; iItem >= 1; iItem--)
                    {
                        if (Children[iItem - 1].GetType() == typeof(LaavorLabelNumber))
                        {
                            (Children[iItem - 1] as LaavorLabelNumber).TextColor = Colors.Get(currentTextColorVoted);
                            (Children[iItem - 1] as LaavorLabelNumber).BackgroundColor = Colors.Get(currentColorUIVoted);
                            (Children[iItem - 1] as LaavorLabelNumber).IsSelected = true;
                        }
                    }

                    IndexVoted = labelSender.index - 1;

                    if (IndexVoted >= 0)
                    {
                        if (Children[IndexVoted].GetType() == typeof(LaavorLabelNumber))
                        {
                            Value = (Children[IndexVoted] as LaavorLabelNumber).Number;
                        }
                    }
                    else
                    {
                        Value = 0;
                    }
                }
                else
                {
                    for (int iItem = labelSender.index; iItem <= ItemsNumber; iItem++)
                    {
                        if (Children[iItem - 1].GetType() == typeof(LaavorLabelNumber))
                        {
                            (Children[iItem - 1] as LaavorLabelNumber).TextColor = Colors.Get(currentTextColorUnVoted);
                            (Children[iItem - 1] as LaavorLabelNumber).BackgroundColor = Colors.Get(currentColorUIUnVoted);
                            (Children[iItem - 1] as LaavorLabelNumber).IsSelected = false;
                        }
                    }

                    IndexVoted = labelSender.index - 2;

                    if (IndexVoted >= 0)
                    {
                        Value = (Children[IndexVoted] as LaavorLabelNumber).Number;
                    }
                    else
                    {
                        Value = 0;
                    }
                }

                if (BlockSelect)
                {
                    copyBlockSelect = BlockSelect;
                }
            }

            Voted?.Invoke(this, e);
            OnSelect?.Invoke(this, e);
        }


        private TapGestureRecognizer GetVivacity(int maxInt)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + currentVivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            object[] parametersInvoke = { maxInt };
            TapGestureRecognizer touchAnimation = (TapGestureRecognizer)methodToInvoke.Invoke(this, parametersInvoke);

            return touchAnimation;
        }

        private TapGestureRecognizer GetVivacityDecrease(int maxIndex)
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (currentVivacityMode == VivacityMode.All)
                    {
                        for (int indexNumber = 0; indexNumber <= maxIndex; indexNumber++)
                        {
                            LaavorLabelNumber number = listLabelsToAnimate[indexNumber];

                            if (number.IsSelected)
                            {
                                await number.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await number.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabelNumber number = listLabelsToAnimate[maxIndex];
                        await number.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await number.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };

            return vivacityTap;
        }

        private double GetDepthDecrease(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 0.92;
            }
            else if (depth == Depth.LessMedium)
            {
                return 0.87;
            }
            else if (depth == Depth.Medium)
            {
                return 0.77;
            }
            else
            {
                return 0.67;
            }
        }

        private TapGestureRecognizer GetVivacityIncrease(int maxIndex)
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (currentVivacityMode == VivacityMode.All)
                    {
                        for (int indexNumber = 0; indexNumber <= maxIndex; indexNumber++)
                        {
                            LaavorLabelNumber number = listLabelsToAnimate[indexNumber];
                            if (number.IsSelected)
                            {
                                await number.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await number.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabelNumber number = listLabelsToAnimate[maxIndex];
                        await number.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await number.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                return 1.02;
            }
            else if (depth == Depth.LessMedium)
            {
                return 1.05;
            }
            else if (depth == Depth.Medium)
            {
                return 1.11;
            }
            else
            {
                return 1.19;
            }
        }

        private TapGestureRecognizer GetVivacityRotation(int maxIndex)
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (currentVivacityMode == VivacityMode.All)
                    {
                        for (int indexNumber = 0; indexNumber <= maxIndex; indexNumber++)
                        {
                            LaavorLabelNumber number = listLabelsToAnimate[indexNumber];

                            if (number.IsSelected)
                            {
                                await number.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await number.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabelNumber number = listLabelsToAnimate[maxIndex];
                        await number.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await number.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityJump(int maxIndex)
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (currentVivacityMode == VivacityMode.All)
                    {
                        for (int indexNumber = 0; indexNumber <= maxIndex; indexNumber++)
                        {
                            LaavorLabelNumber number = listLabelsToAnimate[indexNumber];

                            if (number.IsSelected)
                            {
                                await number.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await number.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabelNumber number = listLabelsToAnimate[maxIndex];
                        await number.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await number.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return vivacityTap;
        }

        private double GetDepthJump(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return -0.7;
            }
            else if (depth == Depth.LessMedium)
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

        private TapGestureRecognizer GetVivacityDown(int maxIndex)
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (currentVivacityMode == VivacityMode.All)
                    {
                        for (int indexNumber = 0; indexNumber <= maxIndex; indexNumber++)
                        {
                            LaavorLabelNumber number = listLabelsToAnimate[indexNumber];

                            if (number.IsSelected)
                            {
                                await number.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await number.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabelNumber number = listLabelsToAnimate[maxIndex];
                        await number.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await number.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityRight(int maxIndex)
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (currentVivacityMode == VivacityMode.All)
                    {
                        for (int indexNumber = 0; indexNumber <= maxIndex; indexNumber++)
                        {
                            LaavorLabelNumber number = listLabelsToAnimate[indexNumber];

                            if (number.IsSelected)
                            {
                                await number.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                                await number.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabelNumber number = listLabelsToAnimate[maxIndex];
                        await number.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await number.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                    }
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

        private TapGestureRecognizer GetVivacityLeft(int maxIndex)
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (currentVivacityMode == VivacityMode.All)
                    {
                        for (int indexNumber = 0; indexNumber <= maxIndex; indexNumber++)
                        {
                            LaavorLabelNumber number = listLabelsToAnimate[indexNumber];

                            if (number.IsSelected)
                            {
                                await number.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                                await number.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabelNumber number = listLabelsToAnimate[maxIndex];
                        await number.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await number.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
