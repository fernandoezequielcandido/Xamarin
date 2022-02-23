using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorIconButton
{
    /// <summary>
    /// Class IconButton
    /// </summary>
    public class IconButton : StackLayout
    {
        /// <summary>
        /// Event call when Icon is Clicked
        /// </summary>
        [Obsolete("This event has been deprecated. Use UseTouched.")]
        public event EventHandler Clicked;

        /// <summary>
        /// Event call when Icon is Touched
        /// </summary>
        public event EventHandler Touched;

        private ColorUI currentColorUI = ColorUI.Gray;
        private IconType currentIconType = IconType.Like;
        private IconButtonImage imageButton;

        private Vivacity currentVivacity = Vivacity.Decrease;
        private Depth currentDepth = Depth.Medium;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;

        /// <summary>
        /// Constructor of IconButton
        /// </summary>
        public IconButton()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            InitAll();
        }

        private void InitAll()
        {
            CreateButton();

            this.Children.Add(imageButton);
        }

        private void CreateButton()
        {
            imageButton = new IconButtonImage("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentIconType, currentColorUI);
            imageButton.WidthRequest = Width;
            imageButton.MinimumWidthRequest = Width;
            imageButton.HeightRequest = Height;
            imageButton.MinimumHeightRequest = Height;

            imageButton.GestureRecognizers.Add(GetVivacity());
            imageButton.GestureRecognizers.Add(GetTouch());
        }

        private void Touch_Tapped(object sender, EventArgs e)
        {
            Touched?.Invoke(this, EventArgs.Empty);
            Clicked?.Invoke(this, EventArgs.Empty);

        }

        private TapGestureRecognizer GetTouch()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += Touch_Tapped;
            return touch;
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
                imageButton.GestureRecognizers.Clear();
                
                imageButton.GestureRecognizers.Add(GetVivacity());
                
                imageButton.GestureRecognizers.Add(GetTouch());
                
                imageButton.Opacity = 1.0;
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
                imageButton.GestureRecognizers.Clear();

                imageButton.GestureRecognizers.Add(GetVivacity());

                imageButton.GestureRecognizers.Add(GetTouch());

                imageButton.Opacity = 1.0;
            }
        }

        /// <summary>
        /// Property to report if IconButton is readonly.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(IconButton),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: IsReadOnlyPropertyChanged);

        /// <summary>
        /// Property to report if IconButton is readonly.
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
            IconButton iconButton = (IconButton)bindable;
            bool copyIsReadOnly = (bool)newValue;
            if (copyIsReadOnly)
            {
                iconButton.imageButton.GestureRecognizers.Clear();

                iconButton.imageButton.Opacity = 0.3;
            }
            else
            {
                if (iconButton.UseClickEffect || iconButton.UseTouchEffect)
                {
                    iconButton.imageButton.GestureRecognizers.Add(iconButton.GetVivacity());
                }

                iconButton.imageButton.GestureRecognizers.Add(iconButton.GetTouch());

                iconButton.imageButton.Opacity = 1.0;
            }
        }

        /// <summary>
        /// Property to report if IconButton is readonly.
        /// </summary>
        public static readonly BindableProperty UseTouchEffectProperty = BindableProperty.Create(
                 propertyName: nameof(UseTouchEffect),
                 returnType: typeof(bool),
                 declaringType: typeof(IconButton),
                 defaultValue: true,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: UseTouchEffectChanged);

        /// <summary>
        /// Property to report if IconButton is readonly.
        /// </summary>
        public bool UseTouchEffect
        {
            get
            {
                return (bool)GetValue(UseTouchEffectProperty);
            }
            set
            {
                SetValue(UseTouchEffectProperty, value);
            }
        }

        private static void UseTouchEffectChanged(object bindable, object oldValue, object newValue)
        {
            IconButton iconButton = (IconButton)bindable;
            bool copyUseTouchEffect = (bool)newValue;

            iconButton.imageButton.GestureRecognizers.Clear();

            if (copyUseTouchEffect)
            {
                if (!iconButton.IsReadOnly)
                {
                    iconButton.imageButton.GestureRecognizers.Add(iconButton.GetTouch());
                }

                iconButton.imageButton.GestureRecognizers.Add(iconButton.GetVivacity());
            }
        }

        /// <summary>
        /// Property to report if IconButton is readonly.
        /// </summary>
        [Obsolete("This property has been deprecated. Use UseTouchEffect.")]
        public static readonly BindableProperty UseClickEffectProperty = BindableProperty.Create(
                 propertyName: nameof(UseClickEffect),
                 returnType: typeof(bool),
                 declaringType: typeof(IconButton),
                 defaultValue: true,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: UseClickEffectChanged);

        /// <summary>
        /// Property to report if IconButton is readonly.
        /// </summary>
        [Obsolete("This property has been deprecated. Use UseTouchEffect.")]
        public bool UseClickEffect
        {
            get
            {
                return (bool)GetValue(UseClickEffectProperty);
            }
            set
            {
                SetValue(UseClickEffectProperty, value);
            }
        }

        private static void UseClickEffectChanged(object bindable, object oldValue, object newValue)
        {
            IconButton iconButton = (IconButton)bindable;
            bool copyUseClickEffect = (bool)newValue;

            iconButton.imageButton.GestureRecognizers.Clear();

            if (copyUseClickEffect)
            {
                if (!iconButton.IsReadOnly)
                {
                    iconButton.imageButton.GestureRecognizers.Add(iconButton.GetTouch());
                }

                iconButton.imageButton.GestureRecognizers.Add(iconButton.GetVivacity());
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
                ColorUIPropertyChanged(currentColorUI, value);
                currentColorUI = value;
            }
        }

        private void ColorUIPropertyChanged(ColorUI oldValue, ColorUI newValue)
        {
            if (imageButton != null)
            {
                imageButton.ChangeColor("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", newValue);
            }
        }

        /// <summary>
        /// Set if is IconType
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
                IconTypePropertyChanged(currentIconType, value);
                currentIconType = value;
            }
        }

        private void IconTypePropertyChanged(IconType oldValue, IconType newValue)
        {
            if(imageButton != null)
            {
                imageButton.ChangeIconType("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", newValue);
            }
        }

        /// <summary>
        /// Enter the height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(IconButton),
            defaultValue: 42.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightPropertyChanged);

        /// <summary>
        /// Enter the height.
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
            IconButton iconButton = (IconButton)bindable;
            double buttonHeight = (double)newValue;
            iconButton.imageButton.HeightRequest = buttonHeight;
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty HeightRequestProperty = BindableProperty.Create(
            propertyName: nameof(HeightRequest),
            returnType: typeof(double),
            declaringType: typeof(IconButton),
            defaultValue: 70.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Deprecate.
        /// </summary>
        [Obsolete]
        public new double HeightRequest
        {
            get
            {
                return (double)GetValue(HeightRequestProperty);
            }
            set { }
        }

        /// <summary>
        /// Enter the width.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(IconButton),
            defaultValue: 42.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter the width.
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
            IconButton iconButton = (IconButton)bindable;
            double buttonWidth = (double)newValue;
            iconButton.imageButton.WidthRequest = buttonWidth;
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty WidthRequestProperty = BindableProperty.Create(
            propertyName: nameof(WidthRequest),
            returnType: typeof(double),
            declaringType: typeof(IconButton),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Deprecate.
        /// </summary>
        [Obsolete]
        public new double WidthRequest
        {
            get
            {
                return (double)GetValue(WidthRequestProperty);
            }
            set { }
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
                    await imageButton.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    await imageButton.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await imageButton.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
