using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorRatingConception
{
    /// <summary>
    /// Class RatingConception
    /// </summary>
    public class RatingConception : StackLayout
    {
        /// <summary>
        /// Returns the value of the voted rating, being numeric starting at 1.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Returns Index of voted rating starting in 0 
        /// </summary>
        public int IndexVoted { get; private set; }

        private DrawType currentDrawType = DrawType.Star;
        private ColorUI currentColorUI = ColorUI.Blue;

        private Vivacity currentVivacity = Vivacity.Increase;
        private VivacityMode currentVivacityMode = VivacityMode.All;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;
        private Depth currentDepth = Depth.Medium;

        private bool copyBlockVote;

        /// <summary>
        /// Event called when rating is voted
        /// </summary>
        public event EventHandler Voted;

        private List<RatingItemImage> listImagesToAnimate;

        /// <summary>
        /// Constructor of RatingImage
        /// </summary>
        public RatingConception() : base()
        {
            Value = 0;
            IndexVoted = -1;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Spacing = 0;
            this.HorizontalOptions = LayoutOptions.Center;

            Orientation = StackOrientation.Horizontal;
            InitAll();
        }

        private void InitAll()
        {
            listImagesToAnimate = new List<RatingItemImage>();

            if (Value == 0)
            {
                Value = InitialValue;
            }

            if (InitialValue > ItemsNumber)
            {
                InitialValue = ItemsNumber;
            }

            Children.Clear();

            for (int iImage = 1; iImage <= ItemsNumber; iImage++)
            {
                RatingItemImage image = new RatingItemImage("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentDrawType, currentColorUI, false);

                image.Number = iImage;
                image.WidthRequest = ImageWidth;
                image.HeightRequest = ImageHeight;
                image.MinimumWidthRequest = ImageWidth;
                image.MinimumHeightRequest = ImageHeight;
                image.VerticalOptions = LayoutOptions.Center;
                image.HorizontalOptions = LayoutOptions.Center;
                image.Aspect = Aspect.Fill;

                if (InitialValue == 0 || iImage > InitialValue)
                {
                    image.ChangeVoted("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", false);
                }
                else if (iImage <= InitialValue)
                {
                    image.ChangeVoted("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", true);
                }

                if (!IsReadOnly)
                {
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += Image_Clicked;
                    image.GestureRecognizers.Add(tapGestureRecognizer);
                }

                image.Margin = SpaceBetween;

                listImagesToAnimate.Add(image);

                Children.Add(image);
            }

            if (!IsReadOnly)
            {
                for (int index = 0; index < listImagesToAnimate.Count; index++)
                {
                    RatingItemImage image = listImagesToAnimate[index];
                    image.GestureRecognizers.Add(GetVivacity(index));
                }
            }

            copyBlockVote = false;

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
        /// Property to report if rating is for display only.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(RatingConception),
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
            RatingConception rating = (RatingConception)bindable;
            bool copyIsReadOnly = (bool)newValue;
            for (int iCh = 0; iCh < rating.Children.Count; iCh++)
            {
                RatingItemImage image = (RatingItemImage)rating.Children[iCh];

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

                    image.GestureRecognizers.Add(rating.GetVivacity(iCh));
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
        /// Property to inform if leave the rating unedited sfter first vote.
        /// </summary>
        public static readonly BindableProperty BlockVoteProperty = BindableProperty.Create(
                propertyName: nameof(BlockVote),
                returnType: typeof(bool),
                declaringType: typeof(RatingConception),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Property to inform if leave the rating unedited sfter first vote.
        /// </summary>
        public bool BlockVote
        {
            get
            {
                return (bool)GetValue(BlockVoteProperty);
            }
            set
            {
                SetValue(BlockVoteProperty, value);
            }
        }

        /// <summary>
        /// Property to inform inital value (preselect Rating).
        /// </summary>
        public static readonly BindableProperty InitialValueProperty = BindableProperty.Create(
                 propertyName: nameof(InitialValue),
                 returnType: typeof(int),
                 declaringType: typeof(RatingConception),
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
            RatingConception rating = (RatingConception)bindable;
            int copyInitialValue = (int)newValue;
            for (int iCh = 0; iCh < rating.Children.Count; iCh++)
            {
                RatingItemImage image = (RatingItemImage)rating.Children[iCh];

                if (copyInitialValue == 0 || (iCh + 1) > rating.InitialValue)
                {
                    image.ChangeVoted("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", false);
                }
                else if ((iCh + 1) <= copyInitialValue)
                {
                    image.ChangeVoted("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", true);
                }
            }
        }

        /// <summary>
        /// Property to inform SpaceBetween images rating
        /// </summary>
        public static readonly BindableProperty SpaceBetweenProperty = BindableProperty.Create(
                 propertyName: nameof(SpaceBetween),
                 returnType: typeof(int),
                 declaringType: typeof(RatingConception),
                 defaultValue: 0,
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
            RatingConception rating = (RatingConception)bindable;
            int copyMargin = (int)newValue;

            for (int iCh = 0; iCh < rating.Children.Count; iCh++)
            {
                RatingItemImage image = (RatingItemImage)rating.Children[iCh];
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
            declaringType: typeof(RatingConception),
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
            RatingConception rating = (RatingConception)bindable;
            rating.InitAll();
        }

        /// <summary>
        /// Enter the image height, represents only one image.
        /// </summary>
        public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create(
            propertyName: nameof(ImageHeight),
            returnType: typeof(double),
            declaringType: typeof(RatingConception),
            defaultValue: 30.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImageHeightPropertyChanged);

        /// <summary>
        /// Enter the image height, represents only one image.
        /// </summary>
        public double ImageHeight
        {
            get
            {
                return (double)GetValue(ImageHeightProperty);
            }
            set
            {
                SetValue(ImageHeightProperty, value);
            }
        }

        private static void ImageHeightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingConception rating = (RatingConception)bindable;
            double imageHeight = (double)newValue;
            for (int iCh = 0; iCh < rating.Children.Count; iCh++)
            {
                RatingItemImage image = (RatingItemImage)rating.Children[iCh];
                image.HeightRequest = imageHeight;
                image.MinimumHeightRequest = imageHeight;
            }
        }

        /// <summary>
        /// Enter the image width, represents only one image.
        /// </summary>
        public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(
            propertyName: nameof(ImageWidth),
            returnType: typeof(double),
            declaringType: typeof(RatingConception),
            defaultValue: 30.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImageWidthPropertyChanged);

        /// <summary>
        /// Enter the image width, represents only one image.
        /// </summary>
        public double ImageWidth
        {
            get
            {
                return (double)GetValue(ImageWidthProperty);
            }
            set
            {
                SetValue(ImageWidthProperty, value);
            }
        }

        private static void ImageWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingConception rating = (RatingConception)bindable;
            double imageWidth = (double)newValue;
            for (int iCh = 0; iCh < rating.Children.Count; iCh++)
            {
                RatingItemImage image = (RatingItemImage)rating.Children[iCh];
                image.WidthRequest = imageWidth;
                image.MinimumWidthRequest = imageWidth;
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

        private static void ColorUIPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingConception rating = (RatingConception)bindable;
            ColorUI copyColorUI = (ColorUI)newValue;

            for (int iCh = 0; iCh < rating.Children.Count; iCh++)
            {
                RatingItemImage image = (RatingItemImage)rating.Children[iCh];
                image.ChangeColor("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", copyColorUI);
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
                for (int index = 0; index < listImagesToAnimate.Count; index++)
                {
                    RatingItemImage image = listImagesToAnimate[index];
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
                for (int index = 0; index < listImagesToAnimate.Count; index++)
                {
                    RatingItemImage image = listImagesToAnimate[index];
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
        /// Set DrawType
        /// </summary>
        [Bindable(true)]
        public DrawType DrawType
        {
            get
            {
                return currentDrawType;
            }
            set
            {
                currentDrawType = value;
                DrawTypePropertyChanged();
            }
        }

        private void DrawTypePropertyChanged()
        {
            for (int iCh = 0; iCh < this.Children.Count; iCh++)
            {
                RatingItemImage image = (RatingItemImage)this.Children[iCh];
                image.ChangeDrawType("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentDrawType);
                image.Margin = this.SpaceBetween;

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
                for (int index = 0; index < listImagesToAnimate.Count; index++)
                {
                    RatingItemImage image = listImagesToAnimate[index];
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
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() != typeof(RatingItemImage))
            {
                Children.RemoveAt(Children.Count - 1);
            }
        }

        private void Image_Clicked(object sender, EventArgs e)
        {
            var imageSender = (RatingItemImage)sender;
            Value = imageSender.Number;

            if (IsReadOnly)
            {
                return;
            }

            if (!copyBlockVote)
            {
                if (!imageSender.Voted)
                {
                    for (int iNumber = imageSender.Number; iNumber >= 1; iNumber--)
                    {
                        RatingItemImage image = (RatingItemImage)(Children[iNumber - 1]);
                        image.ChangeVoted("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", true);
                    }

                    IndexVoted = Value - 1;
                }
                else
                {
                    for (int iNumber = imageSender.Number; iNumber <= ItemsNumber; iNumber++)
                    {
                        RatingItemImage image = (RatingItemImage)(Children[iNumber - 1]);
                        image.ChangeVoted("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", false);
                    }

                    if (Value == 1)
                    {
                        IndexVoted = -1;
                        Value = 0;
                    }
                    else
                    {
                        IndexVoted = Value - 1;
                    }
                }

                if (BlockVote)
                {
                    copyBlockVote = BlockVote;

                    for (int iCh = 0; iCh < Children.Count; iCh++)
                    {
                        RatingItemImage image = (RatingItemImage)Children[iCh];
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
                            RatingItemImage image = listImagesToAnimate[indexImage];

                            if (image.Voted)
                            {
                                await image.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        RatingItemImage image = listImagesToAnimate[maxIndex];
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
                            RatingItemImage image = listImagesToAnimate[indexImage];
                            if (image.Voted)
                            {
                                await image.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        RatingItemImage image = listImagesToAnimate[maxIndex];
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
                return 1.0;
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
                            RatingItemImage image = listImagesToAnimate[indexImage];

                            if (image.Voted)
                            {
                                await image.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        RatingItemImage image = listImagesToAnimate[maxIndex];
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
                            RatingItemImage image = listImagesToAnimate[indexImage];

                            if (image.Voted)
                            {
                                await image.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        RatingItemImage image = listImagesToAnimate[maxIndex];
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
                            RatingItemImage image = listImagesToAnimate[indexImage];

                            if (image.Voted)
                            {
                                await image.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                                await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        RatingItemImage image = listImagesToAnimate[maxIndex];
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
                            RatingItemImage image = listImagesToAnimate[indexImage];

                            if (image.Voted)
                            {
                                await image.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                                await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        RatingItemImage image = listImagesToAnimate[maxIndex];
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
