using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorRatingSwap
{
    /// <summary>
    /// Class RatingLetterConception
    /// </summary>
    public class RatingLetterConception: StackLayout
    {
        /// <summary>
        /// Returns the value Selected starting in 1
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Returns the Letter selected rating.
        /// </summary>
        public Letters Letter { get; private set; }

        /// <summary>
        /// Returns the value of Index Voted starting in 0 
        /// </summary>
        public int IndexVoted { get; private set; }

        private bool copyBlockSelect;

        private Vivacity currentVivacity = Vivacity.Increase;
        private VivacityMode currentVivacityMode = VivacityMode.All;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;
        private Depth currentDepth = Depth.Medium;

        private List<LetterImage> listLettersToAnimate;
        
        private ColorUI currentColorUI = ColorUI.Blue;

        /// <summary>
        /// Event called when is Voted
        /// </summary>
        public event EventHandler Voted;

        /// <summary>
        /// Constructor of RatingLetterConception
        /// </summary>
        public RatingLetterConception() : base()
        {
            Value = 0;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Spacing = 0;
            
            Orientation = StackOrientation.Horizontal;
            InitAll();

            this.HorizontalOptions = LayoutOptions.Center;
        }

        private void InitAll()
        {
            listLettersToAnimate = new List<LetterImage>();

            if (Value == 0)
            {
                Value = InitialValue;
            }

            if (InitialValue > ItemsNumber)
            {
                InitialValue = ItemsNumber;
            }

            Children.Clear();

            for (int iLetter = 1; iLetter <= ItemsNumber; iLetter++)
            {
                bool isVoted = (iLetter <= InitialValue);
                LetterImage letter = new LetterImage("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", iLetter, (iLetter - 1), isVoted, currentColorUI);

                letter.WidthRequest = LetterWidth;
                letter.HeightRequest = LetterHeight;
                letter.MinimumWidthRequest = LetterWidth;
                letter.MinimumHeightRequest = LetterHeight;

                if (!IsReadOnly)
                {
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += Image_Clicked;
                    letter.GestureRecognizers.Add(tapGestureRecognizer);
                }

                letter.Margin = SpaceBetween;

                listLettersToAnimate.Add(letter);

                Children.Add(letter);
            }

            if (!IsReadOnly)
            {
                for (int index = 0; index < listLettersToAnimate.Count; index++)
                {
                    LetterImage image = listLettersToAnimate[index];
                    if (currentVivacity != Vivacity.None)
                    {
                        image.GestureRecognizers.Add(GetVivacity(index));
                    }
                }
            }

            copyBlockSelect = false;

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
                for (int index = 0; index < listLettersToAnimate.Count; index++)
                {
                    LetterImage image = listLettersToAnimate[index];
                    image.GestureRecognizers.Clear();

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += Image_Clicked;
                    image.GestureRecognizers.Add(tapGestureRecognizer);

                    if (currentVivacity != Vivacity.None)
                    {
                        image.GestureRecognizers.Add(GetVivacity(index));
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
                VivacityModePropertyChanged();
            }
        }

        private void VivacityModePropertyChanged()
        {
            if (!IsReadOnly)
            {
                for (int index = 0; index < listLettersToAnimate.Count; index++)
                {
                    LetterImage image = listLettersToAnimate[index];
                    image.GestureRecognizers.Clear();

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += Image_Clicked;
                    image.GestureRecognizers.Add(tapGestureRecognizer);

                    if (currentVivacity != Vivacity.None)
                    {
                        image.GestureRecognizers.Add(GetVivacity(index));
                    }
                }
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
                for (int index = 0; index < listLettersToAnimate.Count; index++)
                {
                    LetterImage image = listLettersToAnimate[index];
                    image.GestureRecognizers.Clear();

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += Image_Clicked;
                    image.GestureRecognizers.Add(tapGestureRecognizer);

                    if (currentVivacity != Vivacity.None)
                    {
                        image.GestureRecognizers.Add(GetVivacity(index));
                    }
                }
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
            for (int index = 0; index < listLettersToAnimate.Count; index++)
            {
                LetterImage image = listLettersToAnimate[index];
                image.ChangeColor("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentColorUI);
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
        /// Property to report if rating is for display only.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(RatingLetterConception),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: OnIsReadOnlyPropertyChanged);

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

        private static void OnIsReadOnlyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RatingLetterConception rating = (RatingLetterConception)bindable;
            bool copyIsReadOnly = (bool)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LetterImage image = (LetterImage)rating.Children[iItem];

                if (copyIsReadOnly)
                {
                    image.GestureRecognizers.Clear();
                }
                else
                {
                    image.GestureRecognizers.Clear();

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += rating.Image_Clicked;
                    image.GestureRecognizers.Add(tapGestureRecognizer);

                    if (rating.currentVivacity != Vivacity.None)
                    {
                        image.GestureRecognizers.Add(rating.GetVivacity(iItem));
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
        /// Property to inform if leave the rating unedited sfter first select.
        /// </summary>
        public static readonly BindableProperty BlockSelectProperty = BindableProperty.Create(
                propertyName: nameof(BlockSelect),
                returnType: typeof(bool),
                declaringType: typeof(RatingLetterConception),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Property to inform if leave the rating unedited sfter first select.
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
                 declaringType: typeof(RatingLetterConception),
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
            RatingLetterConception rating = (RatingLetterConception)bindable;
            int copyInitialValue = (int)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LetterImage image = (LetterImage)rating.Children[iItem];

                if (copyInitialValue == 0 || (iItem + 1) > rating.InitialValue)
                {
                    image.ChangeVoted("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", false);
                }
                else if ((iItem + 1) <= copyInitialValue)
                {
                    image.ChangeVoted("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", true);
                }
            }

            rating.IndexVoted = copyInitialValue - 1;
        }

        /// <summary>
        /// Property to inform SpaceBetween images rating
        /// </summary>
        public static readonly BindableProperty SpaceBetweenProperty = BindableProperty.Create(
                 propertyName: nameof(SpaceBetween),
                 returnType: typeof(int),
                 declaringType: typeof(RatingLetterConception),
                 defaultValue: 2,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: SpaceBetweenPropertyChanged);

        /// <summary>
        /// Property to inform SpaceBetween images rating
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
            RatingLetterConception rating = (RatingLetterConception)bindable;
            int copyMargin = (int)newValue;

            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LetterImage image = (LetterImage)rating.Children[iItem];
                image.Margin = copyMargin;
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
        /// Enter the number of  images you want show in rating.
        /// </summary>
        public static readonly BindableProperty ItemsNumberProperty = BindableProperty.Create(
            propertyName: nameof(ItemsNumber),
            returnType: typeof(int),
            declaringType: typeof(RatingLetterConception),
            defaultValue: 5,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ItemsNumberPropertyChanged);

        /// <summary>
        /// Enter the number of  images you want show in rating.
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
            RatingLetterConception rating = (RatingLetterConception)bindable;
            rating.InitAll();
        }

        /// <summary>
        /// Enter the Letter height, represents only one Letter.
        /// </summary>
        public static readonly BindableProperty LetterHeightProperty = BindableProperty.Create(
            propertyName: nameof(LetterHeight),
            returnType: typeof(double),
            declaringType: typeof(RatingLetterConception),
            defaultValue: 20.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: LetterHeightPropertyChanged);

        /// <summary>
        /// Enter the Letter height, represents only one Letter.
        /// </summary>
        public double LetterHeight
        {
            get
            {
                return (double)GetValue(LetterHeightProperty);
            }
            set
            {
                SetValue(LetterHeightProperty, value);
            }
        }

        private static void LetterHeightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingLetterConception rating = (RatingLetterConception)bindable;
            double imageHeight = (double)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LetterImage image = (LetterImage)rating.Children[iItem];
                image.HeightRequest = imageHeight;
                image.MinimumHeightRequest = imageHeight;
            }
        }

        /// <summary>
        /// Enter the Letter width, represents only one Letter.
        /// </summary>
        public static readonly BindableProperty LetterWidthProperty = BindableProperty.Create(
            propertyName: nameof(LetterWidth),
            returnType: typeof(double),
            declaringType: typeof(RatingLetterConception),
            defaultValue: 20.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: LetterWidthPropertyChanged);

        /// <summary>
        /// Enter the Letter width, represents only one Letter.
        /// </summary>
        public double LetterWidth
        {
            get
            {
                return (double)GetValue(LetterWidthProperty);
            }
            set
            {
                SetValue(LetterWidthProperty, value);
            }
        }

        private static void LetterWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingLetterConception rating = (RatingLetterConception)bindable;
            double imageWidth = (double)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LetterImage image = (LetterImage)rating.Children[iItem];
                image.WidthRequest = imageWidth;
                image.MinimumWidthRequest = imageWidth;
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() != typeof(LetterImage))
            {
                Children.RemoveAt(Children.Count - 1);
            }
        }

        private void Image_Clicked(object sender, EventArgs e)
        {
            var imageSender = (LetterImage)sender;

            if (IsReadOnly)
            {
                return;
            }

            if (!copyBlockSelect)
            {
                if (!imageSender.Voted)
                {
                    for (int iNumber = imageSender.Number; iNumber >= 1; iNumber--)
                    {
                        (Children[iNumber - 1] as LetterImage).ChangeVoted("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", true);
                    }

                    Value = imageSender.Number;
                    IndexVoted = Value - 1;
                    Letter = (Letters)IndexVoted;
                }
                else
                {
                    for (int iNumber = imageSender.Number; iNumber <= ItemsNumber; iNumber++)
                    {
                        (Children[iNumber - 1] as LetterImage).ChangeVoted("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", false);
                    }

                    Value = imageSender.Number - 1;
                    IndexVoted = Value - 1;
                    Letter = (Letters)IndexVoted;
                }

                if (BlockSelect)
                {
                    copyBlockSelect = BlockSelect;

                    for (int iItem = 0; iItem < Children.Count; iItem++)
                    {
                        LaavorImage image = (LaavorImage)Children[iItem];
                        image.GestureRecognizers.Clear();
                    }
                }
            }

            Voted?.Invoke(this, e);
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
                        for (int indexImage = 0; indexImage <= maxIndex; indexImage++)
                        {
                            LetterImage image = listLettersToAnimate[indexImage];

                            if (image.Voted)
                            {
                                await image.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LetterImage image = listLettersToAnimate[maxIndex];
                        await image.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexImage = 0; indexImage <= maxIndex; indexImage++)
                        {
                            LetterImage image = listLettersToAnimate[indexImage];
                            if (image.Voted)
                            {
                                await image.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LetterImage image = listLettersToAnimate[maxIndex];
                        await image.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexImage = 0; indexImage <= maxIndex; indexImage++)
                        {
                            LetterImage image = listLettersToAnimate[indexImage];

                            if (image.Voted)
                            {
                                await image.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LetterImage image = listLettersToAnimate[maxIndex];
                        await image.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await image.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexImage = 0; indexImage <= maxIndex; indexImage++)
                        {
                            LetterImage image = listLettersToAnimate[indexImage];

                            if (image.Voted)
                            {
                                await image.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LetterImage image = listLettersToAnimate[maxIndex];
                        await image.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexImage = 0; indexImage <= maxIndex; indexImage++)
                        {
                            LetterImage image = listLettersToAnimate[indexImage];

                            if (image.Voted)
                            {
                                await image.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LetterImage image = listLettersToAnimate[maxIndex];
                        await image.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                        await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexImage = 0; indexImage <= maxIndex; indexImage++)
                        {
                            LetterImage image = listLettersToAnimate[indexImage];

                            if (image.Voted)
                            {
                                await image.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                                await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LetterImage image = listLettersToAnimate[maxIndex];
                        await image.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                        for (int indexImage = 0; indexImage <= maxIndex; indexImage++)
                        {
                            LetterImage image = listLettersToAnimate[indexImage];

                            if (image.Voted)
                            {
                                await image.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                                await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LetterImage image = listLettersToAnimate[maxIndex];
                        await image.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                        await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
