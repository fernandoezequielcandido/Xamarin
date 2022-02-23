using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorRatingSwap
{
    /// <summary>
    /// Class RatingImage
    /// </summary>
    public class RatingImage : StackLayout
    {
        /// <summary>
        /// Returns the value Selected starting in 1
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Returns the value of Index Voted starting in 0 
        /// </summary>
        public int IndexSelected { get; private set; }

        /// <summary>
        /// Returns the value of Index Voted starting in 0 
        /// </summary>
        public int IndexVoted { get; private set; }

        private bool copyBlockSelect;

        private Vivacity currentVivacity = Vivacity.Increase;
        private VivacityMode currentVivacityMode = VivacityMode.All;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;
        private Depth currentDepth = Depth.Medium;

        private List<LaavorImage> listImagesToAnimate;

        /// <summary>
        /// Event called when is Voted
        /// </summary>
        public event EventHandler Voted;

        /// <summary>
        /// Event called when selected any rating
        /// </summary>
        public event EventHandler OnSelect;

        /// <summary>
        /// Constructor of RatingImage
        /// </summary>
        public RatingImage() : base()
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
            listImagesToAnimate = new List<LaavorImage>();

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
                LaavorImage image = new LaavorImage();

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
                    image.Source = ImageDeselect;
                    image.IsSelected = false;
                }
                else if (iImage <= InitialValue)
                {
                    image.Source = ImageSelect;
                    image.IsSelected = true;
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
                    LaavorImage image = listImagesToAnimate[index];
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
                for (int index = 0; index < listImagesToAnimate.Count; index++)
                {
                    LaavorImage image = listImagesToAnimate[index];
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
                    LaavorImage image = listImagesToAnimate[index];
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
                for (int index = 0; index < listImagesToAnimate.Count; index++)
                {
                    LaavorImage image = listImagesToAnimate[index];
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
        /// Property to report if rating is for display only.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(RatingImage),
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
            RatingImage rating = (RatingImage)bindable;
            bool copyIsReadOnly = (bool)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LaavorImage image = (LaavorImage)rating.Children[iItem];

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
                declaringType: typeof(RatingImage),
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
                 declaringType: typeof(RatingImage),
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
            RatingImage rating = (RatingImage)bindable;
            int copyInitialValue = (int)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LaavorImage image = (LaavorImage)rating.Children[iItem];

                if (copyInitialValue == 0 || (iItem + 1) > rating.InitialValue)
                {
                    image.Source = rating.ImageDeselect;
                    image.IsSelected = false;
                }
                else if ((iItem + 1) <= copyInitialValue)
                {
                    image.Source = rating.ImageSelect;
                    image.IsSelected = true;
                }
            }

            rating.IndexVoted = copyInitialValue - 1;
            rating.IndexSelected = copyInitialValue - 1;
        }

        /// <summary>
        /// Property to inform SpaceBetween images rating
        /// </summary>
        public static readonly BindableProperty SpaceBetweenProperty = BindableProperty.Create(
                 propertyName: nameof(SpaceBetween),
                 returnType: typeof(int),
                 declaringType: typeof(RatingImage),
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
            RatingImage rating = (RatingImage)bindable;
            int copyMargin = (int)newValue;

            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LaavorImage image = (LaavorImage)rating.Children[iItem];
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
            declaringType: typeof(RatingImage),
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
            RatingImage rating = (RatingImage)bindable;
            rating.InitAll();
        }

        /// <summary>
        /// Enter the image you want to use when Rating is selected.
        /// </summary>
        public static readonly BindableProperty ImageSelectProperty = BindableProperty.Create(
            propertyName: nameof(ImageSelect),
            returnType: typeof(string),
            declaringType: typeof(RatingImage),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImageSelectPropertyChanged);

        /// <summary>
        /// Enter the image you want to use when Rating is selected.
        /// </summary>
        public string ImageSelect
        {
            get
            {
                return (string)GetValue(ImageSelectProperty);
            }
            set
            {
                SetValue(ImageSelectProperty, value);
            }
        }

        private static void ImageSelectPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingImage rating = (RatingImage)bindable;
            string imageSelect = (string)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LaavorImage image = (LaavorImage)rating.Children[iItem];
                if (image.IsSelected)
                {
                    image.Source = imageSelect;
                    image.Margin = rating.SpaceBetween;
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
        /// Enter the image you want to use when Rating is deselect.
        /// </summary>
        public static readonly BindableProperty ImageDeselectProperty = BindableProperty.Create(
            propertyName: nameof(ImageDeselect),
            returnType: typeof(string),
            declaringType: typeof(RatingImage),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImageDeselectPropertyChanged);

        /// <summary>
        /// Enter the image you want to use when Rating is deselect.
        /// </summary>
        public string ImageDeselect
        {
            get
            {
                return (string)GetValue(ImageDeselectProperty);
            }
            set
            {
                SetValue(ImageDeselectProperty, value);
            }
        }

        private static void ImageDeselectPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RatingImage rating = (RatingImage)bindable;
            string imageDeselect = (string)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LaavorImage image = (LaavorImage)rating.Children[iItem];
                if (!image.IsSelected)
                {
                    image.Source = imageDeselect;
                    image.Margin = rating.SpaceBetween;
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
        /// Enter the image height, represents only one image.
        /// </summary>
        public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create(
            propertyName: nameof(ImageHeight),
            returnType: typeof(double),
            declaringType: typeof(RatingImage),
            defaultValue: 20.0,
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
            RatingImage rating = (RatingImage)bindable;
            double imageHeight = (double)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LaavorImage image = (LaavorImage)rating.Children[iItem];
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
            declaringType: typeof(RatingImage),
            defaultValue: 20.0,
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
            RatingImage rating = (RatingImage)bindable;
            double imageWidth = (double)newValue;
            for (int iItem = 0; iItem < rating.Children.Count; iItem++)
            {
                LaavorImage image = (LaavorImage)rating.Children[iItem];
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

            if (child.GetType() != typeof(LaavorImage))
            {
                Children.RemoveAt(Children.Count - 1);
            }
        }

        private void Image_Clicked(object sender, EventArgs e)
        {
            var imageSender = (LaavorImage)sender;

            if (IsReadOnly)
            {
                return;
            }

            if (!copyBlockSelect)
            {
                if (!imageSender.IsSelected)
                {
                    for (int iNumber = imageSender.Number; iNumber >= 1; iNumber--)
                    {
                        (Children[iNumber - 1] as LaavorImage).Source = ImageSelect;
                        (Children[iNumber - 1] as LaavorImage).IsSelected = true;
                    }

                    Value = imageSender.Number;
                    IndexSelected = Value - 1;
                    IndexVoted = Value - 1;
                }
                else
                {
                    for (int iNumber = imageSender.Number; iNumber <= ItemsNumber; iNumber++)
                    {
                        (Children[iNumber - 1] as LaavorImage).Source = ImageDeselect;
                        (Children[iNumber - 1] as LaavorImage).IsSelected = false;
                    }

                    Value = imageSender.Number - 1;
                    IndexSelected = Value - 1;
                    IndexVoted = Value - 1;

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
                        for (int indexImage = 0; indexImage <= maxIndex; indexImage++)
                        {
                            LaavorImage image = listImagesToAnimate[indexImage];

                            if (image.IsSelected)
                            {
                                await image.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorImage image = listImagesToAnimate[maxIndex];
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
                            LaavorImage image = listImagesToAnimate[indexImage];
                            if (image.IsSelected)
                            {
                                await image.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorImage image = listImagesToAnimate[maxIndex];
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
                                LaavorImage image = listImagesToAnimate[indexImage];

                                if (image.IsSelected)
                                {
                                    await image.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                    await image.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                                }
                            }
                        }
                        else if (currentVivacityMode == VivacityMode.Single)
                        {
                            LaavorImage image = listImagesToAnimate[maxIndex];
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
                            LaavorImage image = listImagesToAnimate[indexImage];

                            if (image.IsSelected)
                            {
                                await image.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorImage image = listImagesToAnimate[maxIndex];
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
                            LaavorImage image = listImagesToAnimate[indexImage];

                            if (image.IsSelected)
                            {
                                await image.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                                await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorImage image = listImagesToAnimate[maxIndex];
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
                            LaavorImage image = listImagesToAnimate[indexImage];

                            if (image.IsSelected)
                            {
                                await image.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                                await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorImage image = listImagesToAnimate[maxIndex];
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
                            LaavorImage image = listImagesToAnimate[indexImage];

                            if (image.IsSelected)
                            {
                                await image.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                                await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                            }
                        }
                    }
                    else if (currentVivacityMode == VivacityMode.Single)
                    {
                        LaavorImage image = listImagesToAnimate[maxIndex];
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
