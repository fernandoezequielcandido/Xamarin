using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorFlyingIcon
{
    /// <summary>
    /// FlyingIcon
    /// </summary>
    public class FlyingIcon : StackLayout
    {
        /// <summary>
        /// Call when FlyingIcon is Touched
        /// </summary>
        public event EventHandler Touched;

        /// <summary>
        /// Inform if IsFlying
        /// </summary>
        public bool IsFlying { get; private set; }

        private IconImage iconImage;

        private IconType currentIconType = IconType.Like;
        private ColorUI currentColorUI = ColorUI.Black;
        private NumericPosition numericCol = NumericPosition.__10;
        private NumericPosition numericRow = NumericPosition.__10;

        private Depth currentDepth = Depth.Medium;
        private Vivacity currentVivacity = Vivacity.Decrease;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;

        private StackLayout dataItems;
        private StackLayout stackImage;
        private AbsoluteLayout abs = new AbsoluteLayout();

        private int count;

        /// <summary>
        /// Constructor of FlyingIcon
        /// </summary>
        public FlyingIcon()
        {
            count = 0;
            InitAll();
        }

        private void InitAll()
        {
            Orientation = StackOrientation.Vertical;
            HorizontalOptions = LayoutOptions.Center;

            dataItems = new StackLayout();
            dataItems.Spacing = 0;

            stackImage = new StackLayout();
            stackImage.Spacing = 0;

            iconImage = new IconImage("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", IconType.Like, ColorUI.Black);
            iconImage.HorizontalOptions = LayoutOptions.Center;
            iconImage.VerticalOptions = LayoutOptions.Start;
            iconImage.Aspect = Aspect.AspectFit;

            if (currentVivacity != Vivacity.None)
            {
                iconImage.GestureRecognizers.Add(GetVivacity());
            }

            iconImage.GestureRecognizers.Add(GetTouch());

            stackImage.Children.Add(iconImage);

            AbsoluteLayout.SetLayoutFlags(stackImage, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(stackImage, new Rectangle(GetXY(numericCol), GetXY(numericRow), 0.2, 0.1));

            abs.VerticalOptions = LayoutOptions.Start;

            abs.Children.Add(dataItems);
            abs.Children.Add(stackImage);

            this.Children.Add(abs);

            stackImage.IsVisible = FlyingInitially;
            IsFlying = FlyingInitially;
        }

        private double GetXY(NumericPosition numeric)
        {
            if (numeric == NumericPosition._1)
            {
                return 0.01;
            }
            else if (numeric == NumericPosition._2)
            {
                return 0.11;
            }
            else if (numeric == NumericPosition._3)
            {
                return 0.21;
            }
            else if (numeric == NumericPosition._4)
            {
                return 0.31;
            }
            else if (numeric == NumericPosition._5)
            {
                return 0.41;
            }
            else if (numeric == NumericPosition._6)
            {
                return 0.51;
            }
            else if (numeric == NumericPosition._7)
            {
                return 0.61;
            }
            else if (numeric == NumericPosition._8)
            {
                return 0.71;
            }
            else if (numeric == NumericPosition._9)
            {
                return 0.81;
            }
            else if (numeric == NumericPosition.__10)
            {
                return 0.91;
            }
            else
            {
                return 0.91;
            }
        }

        /// <summary>
        /// Show Icon
        /// </summary>
        public void ShowIcon()
        {
            stackImage.IsVisible = true;
            IsFlying = true;
        }

        /// <summary>
        /// Hide Icon
        /// </summary>
        public void HideIcon()
        {
            stackImage.IsVisible = false;
            IsFlying = false;
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
        /// Set NumericCol
        /// </summary>
        [Bindable(true)]
        public NumericPosition NumericCol
        {
            get
            {
                return numericCol;
            }
            set
            {
                numericCol = value;
                NumericColPropertyChanged();
            }
        }

        private void NumericColPropertyChanged()
        {
            if (stackImage != null)
            {
                AbsoluteLayout.SetLayoutBounds(stackImage, new Rectangle(GetXY(numericCol), GetXY(numericRow), 0.2, 0.1));
            }
        }

        /// <summary>
        /// Set NumericRow
        /// </summary>
        [Bindable(true)]
        public NumericPosition NumericRow
        {
            get
            {
                return numericRow;
            }
            set
            {
                numericRow = value;
                NumericRowPropertyChanged();
            }
        }

        private void NumericRowPropertyChanged()
        {
            if (stackImage != null)
            {
                AbsoluteLayout.SetLayoutBounds(stackImage, new Rectangle(GetXY(numericCol), GetXY(numericRow), 0.2, 0.1));
            }
        }

        /// <summary>
        /// Set IconType
        /// </summary>
        [Bindable(true)]
        public IconType IconType
        {
            get
            {
                return currentIconType;
            }
            set
            {
                currentIconType = value;
                IconTypePropertyChanged();
            }
        }

        private void IconTypePropertyChanged()
        {
            if (iconImage != null)
            {
                iconImage.ChangeIconType("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentIconType);
            }
        }

        /// <summary>
        /// Set Color of Icon
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
            if (iconImage != null)
            {
                iconImage.ChangeColor("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentColorUI);
            }
        }

        /// <summary>
        /// Enter the Flying Initially (bool is Flying(Visible) or Not).
        /// </summary>
        public static readonly BindableProperty FlyingInitiallyProperty = BindableProperty.Create(
            propertyName: nameof(FlyingInitially),
            returnType: typeof(bool),
            declaringType: typeof(FlyingIcon),
            defaultValue: true,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FlyingInitiallyPropertyChanged);

        /// <summary>
        /// Enter the Flying Initially (bool is Flying(Visible) or Not).
        /// </summary>
        public bool FlyingInitially
        {
            get
            {
                return (bool)GetValue(FlyingInitiallyProperty);
            }
            set
            {
                SetValue(FlyingInitiallyProperty, value);
            }
        }

        private static void FlyingInitiallyPropertyChanged(object bindable, object oldValue, object newValue)
        {
            FlyingIcon flyingIcon = (FlyingIcon)bindable;
            bool isFlying = (bool)newValue;

            if (flyingIcon.stackImage != null)
            {
                flyingIcon.stackImage.IsVisible = isFlying;
                flyingIcon.IsFlying = isFlying;
            }
        }

        /// <summary>
        /// Enter the Height Icon.
        /// </summary>
        public static readonly BindableProperty IconHeightProperty = BindableProperty.Create(
            propertyName: nameof(IconHeight),
            returnType: typeof(double),
            declaringType: typeof(FlyingIcon),
            defaultValue: 42.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: IconHeightPropertyChanged);

        /// <summary>
        /// Enter the Icon Height.
        /// </summary>
        public double IconHeight
        {
            get
            {
                return (double)GetValue(IconHeightProperty);
            }
            set
            {
                SetValue(IconHeightProperty, value);
            }
        }

        private static void IconHeightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            FlyingIcon flyingIcon = (FlyingIcon)bindable;
            double height = (double)newValue;

            if (flyingIcon.iconImage != null)
            {
                flyingIcon.iconImage.HeightRequest = height;
            }
        }

        /// <summary>
        /// Enter the Icon width.
        /// </summary>
        public static readonly BindableProperty IconWidthProperty = BindableProperty.Create(
            propertyName: nameof(IconWidth),
            returnType: typeof(double),
            declaringType: typeof(FlyingIcon),
            defaultValue: 42.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: IconWidthPropertyChanged);

        /// <summary>
        /// Enter the Icon width.
        /// </summary>
        public double IconWidth
        {
            get
            {
                return (double)GetValue(IconWidthProperty);
            }
            set
            {
                SetValue(IconWidthProperty, value);
            }
        }

        private static void IconWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            FlyingIcon flyingIcon = (FlyingIcon)bindable;
            double width = (double)newValue;

            if (flyingIcon.iconImage != null)
            {
                flyingIcon.iconImage.WidthRequest = width;
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
            iconImage.GestureRecognizers.Clear();

            if (currentVivacity != Vivacity.None)
            {
                iconImage.GestureRecognizers.Add(GetVivacity());
            }

            iconImage.GestureRecognizers.Add(GetTouch());
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
        /// Set Depth of vivacity
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
                VivacityPropertyChanged();
            }
        }

        private TapGestureRecognizer GetVivacity()
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + currentVivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
            TapGestureRecognizer touchVivavicity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
            return touchVivavicity;
        }

        private TapGestureRecognizer GetVivacityDecrease()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await iconImage.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await iconImage.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await iconImage.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await iconImage.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await iconImage.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await iconImage.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await iconImage.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await iconImage.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await iconImage.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await iconImage.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await iconImage.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await iconImage.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="child"></param>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(FlyingIconContent))
            {
                if (count > 1)
                {
                    (child as FlyingIconContent).IsVisible = false;
                }
                else
                {
                    StackLayout userContentBox = (StackLayout)child;
                    for (int iS = 0; iS < userContentBox.Children.Count; iS++)
                    {
                        dataItems.Children.Add(userContentBox.Children[iS]);
                    }
                }

                count++;
            }
        }
    }
}
