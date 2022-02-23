using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorRatingSwap
{
    /// <summary>
    /// Class RattingLetter
    /// </summary>
    public class RatingLetter : StackLayout
    {
        /// <summary>
        /// Returns the value of the selected rating, being numeric starting at 0.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Returns the Letter selected rating.
        /// </summary>
        public string Letter { get; private set; }

        /// <summary>
        /// Returns the value of Index Voted starting in 0 
        /// </summary>
        public int IndexSelected { get; private set; }

        /// <summary>
        /// Returns the value of Index Voted starting in 0 
        /// </summary>
        public int IndexVoted { get; private set; }

        private FontAttributes currentFontType = FontAttributes.None;

        private Vivacity currentVivacity = Vivacity.Increase;
        private VivacityMode currentVivacityMode = VivacityMode.All;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;
        private Depth currentDepth = Depth.Medium;

        private ColorUI currentTextColorVoted = ColorUI.Black;
        private ColorUI currentTextColorUnVoted = ColorUI.YellowDark;

        private ColorUI currentColorUIVoted = ColorUI.YellowDark;
        private ColorUI currentColorUIUnVoted = ColorUI.Black;

        private List<LaavorLabel> listLabelsToAnimate;
        private bool copyBlockSelect;

        /// <summary>
        /// Event called when is Voted
        /// </summary>
        public event EventHandler Voted;

        /// <summary>
        /// Event called when Voted any rating
        /// </summary>
        public event EventHandler OnSelect;

        /// <summary>
        /// Constructor of RatingLetter
        /// </summary>
        public RatingLetter() : base()
        {
            Value = 0;
            Letter = "";
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            Orientation = StackOrientation.Horizontal;
            InitAll();
            this.HorizontalOptions = LayoutOptions.Center;
        }

        private void InitAll()
        {
            listLabelsToAnimate = new List<LaavorLabel>();
            IndexVoted = -1;
            
            if (Value == 0)
            {
                Value = InitialValue;
            }

            if (InitialValue > ItemsNumber)
            {
                InitialValue = ItemsNumber;
            }

            Children.Clear();

            for (int iItem = 1; iItem <= ItemsNumber; iItem++)
            {
                LaavorLabel label = new LaavorLabel();
                label.Text = GetLetter(iItem);
                label.Number = iItem;
                label.WidthRequest = TextWidth;
                label.FontSize = LetterFontSize;
                label.InputTransparent = false;
                label.FontAttributes = currentFontType;
                label.FontFamily = FontFamily;
                label.HorizontalTextAlignment = TextAlignment.Center;

                if (InitialValue == 0 || iItem > InitialValue)
                {
                    label.TextColor = Colors.Get(currentTextColorUnVoted);
                    label.BackgroundColor = Colors.Get(currentColorUIUnVoted);
                    label.IsSelected = false;
                }
                else if (iItem <= InitialValue)
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
                    LaavorLabel label = listLabelsToAnimate[index];
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
                    LaavorLabel letter = listLabelsToAnimate[index];
                    letter.GestureRecognizers.Clear();

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += Label_Clicked;
                    letter.GestureRecognizers.Add(tapGestureRecognizer);

                    if (currentVivacity != Vivacity.None)
                    {
                        letter.GestureRecognizers.Add(GetVivacity(index));
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
                    LaavorLabel label = listLabelsToAnimate[index];
                    label.GestureRecognizers.Clear();

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += Label_Clicked;
                    label.GestureRecognizers.Add(tapGestureRecognizer);

                    if (currentVivacity != Vivacity.None)
                    {
                        label.GestureRecognizers.Add(GetVivacity(index));
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
                 declaringType: typeof(RatingLetter),
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
            RatingLetter rating = (RatingLetter)bindable;
            bool copyIsReadOnly = (bool)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)rating.Children[iItem];

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
        /// Property to inform SpaceBetween Letters rating
        /// </summary>
        public static readonly BindableProperty SpaceBetweenProperty = BindableProperty.Create(
                 propertyName: nameof(SpaceBetween),
                 returnType: typeof(int),
                 declaringType: typeof(RatingImage),
                 defaultValue: 0,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: SpaceBetweenPropertyChanged);

        /// <summary>
        /// Property to inform SpaceBetween Letters rating
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
            RatingLetter rating = (RatingLetter)bindable;
            int copyMargin = (int)newValue;

            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)rating.Children[iItem];
                    label.Margin = copyMargin;
                }
            }

            double padMargin = 0;

            if (rating.Margin.Left >= 0)
            {
                padMargin = rating.Margin.Left - copyMargin;

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
                declaringType: typeof(RatingLetter),
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
        /// Property to inform inital value (preselect Rating).
        /// </summary>
        public static readonly BindableProperty InitialValueProperty = BindableProperty.Create(
                 propertyName: nameof(InitialValue),
                 returnType: typeof(int),
                 declaringType: typeof(RatingLetter),
                 defaultValue: 0,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: InitialValuePropertyChanged);

        /// <summary>
        /// Property to inform inital value (preselect Rating).
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
            RatingLetter rating = (RatingLetter)bindable;
            int copyInitialValue = (int)newValue;
            rating.Letter = rating.GetLetter(copyInitialValue);
            rating.IndexVoted = copyInitialValue - 1;
            
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)rating.Children[iItem];

                    if (copyInitialValue == 0 || (iItem + 1) > rating.InitialValue)
                    {
                        label.TextColor = Colors.Get(rating.currentTextColorUnVoted);
                        label.BackgroundColor = Colors.Get(rating.currentColorUIUnVoted);
                        label.IsSelected = false;
                    }
                    else if ((iItem + 1) <= copyInitialValue)
                    {
                        label.TextColor = Colors.Get(rating.currentTextColorVoted);
                        label.BackgroundColor = Colors.Get(rating.currentColorUIVoted);
                        label.IsSelected = true;
                    }
                }
            }
        }

        /// <summary>
        /// Enter the number of letters you want show in rating.
        /// </summary>
        public static readonly BindableProperty ItemsNumberProperty = BindableProperty.Create(
            propertyName: nameof(ItemsNumber),
            returnType: typeof(int),
            declaringType: typeof(RatingLetter),
            defaultValue: 5,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ItemsNumberPropertyChanged);

        /// <summary>
        /// Enter the number of letters you want show in rating.
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
            RatingLetter rating = (RatingLetter)bindable;
            rating.InitAll();
        }

        /// <summary>
        /// Enter the number width, represents only one letter.
        /// </summary>
        public static readonly BindableProperty TextWidthProperty = BindableProperty.Create(
            propertyName: nameof(TextWidth),
            returnType: typeof(double),
            declaringType: typeof(RatingLetter),
            defaultValue: 35.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextWidthPropertyChanged);

        /// <summary>
        /// Enter the number width, represents only one letter.
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
            RatingLetter rating = (RatingLetter)bindable;
            double copyWidth = (double)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)rating.Children[iItem];
                    label.WidthRequest = copyWidth;
                }
            }
        }

        /// <summary>
        /// Enter the font size, represents only one letter.
        /// </summary>
        public static readonly BindableProperty LetterFontSizeProperty = BindableProperty.Create(
            propertyName: nameof(LetterFontSize),
            returnType: typeof(double),
            declaringType: typeof(RatingLetter),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size, represents only one letter.
        /// </summary>
        public double LetterFontSize
        {
            get
            {
                return (double)GetValue(LetterFontSizeProperty);
            }
            set
            {
                SetValue(LetterFontSizeProperty, value);
            }
        }

        private static void FontSizePropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingLetter rating = (RatingLetter)bindable;
            double copyFontSize = (double)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)rating.Children[iItem];
                    label.FontSize = copyFontSize;
                }
            }
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
                if (Children[iItem].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)Children[iItem];
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
                if (Children[iItem].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)Children[iItem];

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
                if (Children[iItem].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)Children[iItem];

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
                if (Children[iItem].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)Children[iItem];

                    if (!label.IsSelected)
                    {
                        label.BackgroundColor = Colors.Get(currentColorUIUnVoted);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(RatingLetter),
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
            RatingLetter rating = (RatingLetter)bindable;
            string copyFontFamily = (string)newValue;

            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)rating.Children[iItem];
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
            RatingLetter rating = (RatingLetter)bindable;
            FontAttributes copyFontType = newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                if (rating.Children[iItem].GetType() == typeof(LaavorLabel))
                {
                    LaavorLabel label = (LaavorLabel)rating.Children[iItem];
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

            if (IsReadOnly)
            {
                return;
            }

            if (!copyBlockSelect)
            {
                if (!labelSender.IsSelected)
                {
                    for (int iItem = labelSender.Number; iItem >= 1; iItem--)
                    {
                        if (Children[iItem - 1].GetType() == typeof(LaavorLabel))
                        {
                            (Children[iItem - 1] as LaavorLabel).TextColor = Colors.Get(currentTextColorVoted);
                            (Children[iItem - 1] as LaavorLabel).BackgroundColor = Colors.Get(currentColorUIVoted);
                            (Children[iItem - 1] as LaavorLabel).IsSelected = true;
                        }
                    }

                    Value = labelSender.Number;
                    Letter = GetLetter(Value);
                    IndexVoted = Value - 1;
                    
                }
                else
                {
                    for (int iItem = labelSender.Number; iItem <= ItemsNumber; iItem++)
                    {
                        if (Children[iItem - 1].GetType() == typeof(LaavorLabel))
                        {
                            (Children[iItem - 1] as LaavorLabel).TextColor = Colors.Get(currentTextColorUnVoted);
                            (Children[iItem - 1] as LaavorLabel).BackgroundColor = Colors.Get(currentColorUIUnVoted);
                            (Children[iItem - 1] as LaavorLabel).IsSelected = false;
                        }
                    }

                    Value = labelSender.Number - 1;
                    Letter = GetLetter(Value);
                    IndexVoted = Value - 1;
                    
                }

                if (BlockSelect)
                {
                    copyBlockSelect = BlockSelect;
                }
            }

            Voted?.Invoke(this, e);
            OnSelect?.Invoke(this, e);
        }

        private string GetLetter(int numero)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string value = "";
            if (numero >= 1)
            {
                value = "" + letters[numero - 1];
            }

            return value;
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
                        for (int indexLabel = 0; indexLabel <= maxIndex; indexLabel++)
                        {
                            LaavorLabel letter = listLabelsToAnimate[indexLabel];

                            if (letter.IsSelected)
                            {
                                await letter.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await letter.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabel letter = listLabelsToAnimate[maxIndex];
                        await letter.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await letter.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexLabel = 0; indexLabel <= maxIndex; indexLabel++)
                        {
                            LaavorLabel letter = listLabelsToAnimate[indexLabel];
                            if (letter.IsSelected)
                            {
                                await letter.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await letter.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabel letter = listLabelsToAnimate[maxIndex];
                        await letter.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await letter.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexLabel = 0; indexLabel <= maxIndex; indexLabel++)
                        {
                            LaavorLabel letter = listLabelsToAnimate[indexLabel];

                            if (letter.IsSelected)
                            {
                                await letter.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await letter.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabel letter = listLabelsToAnimate[maxIndex];
                        await letter.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await letter.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexLabel = 0; indexLabel <= maxIndex; indexLabel++)
                        {
                            LaavorLabel letter = listLabelsToAnimate[indexLabel];

                            if (letter.IsSelected)
                            {
                                await letter.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await letter.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabel letter = listLabelsToAnimate[maxIndex];
                        await letter.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await letter.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexLabel = 0; indexLabel <= maxIndex; indexLabel++)
                        {
                            LaavorLabel letter = listLabelsToAnimate[indexLabel];

                            if (letter.IsSelected)
                            {
                                await letter.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await letter.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabel letter = listLabelsToAnimate[maxIndex];
                        await letter.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await letter.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexLabel = 0; indexLabel <= maxIndex; indexLabel++)
                        {
                            LaavorLabel letter = listLabelsToAnimate[indexLabel];

                            if (letter.IsSelected)
                            {
                                await letter.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                                await letter.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabel letter = listLabelsToAnimate[maxIndex];
                        await letter.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await letter.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexLabel = 0; indexLabel <= maxIndex; indexLabel++)
                        {
                            LaavorLabel letter = listLabelsToAnimate[indexLabel];

                            if (letter.IsSelected)
                            {
                                await letter.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                                await letter.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorLabel letter = listLabelsToAnimate[maxIndex];
                        await letter.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await letter.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
