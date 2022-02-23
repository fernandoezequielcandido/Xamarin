using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Buttons
    {
        /// <summary>
        /// Class ButtonIcon
        /// </summary>
        public class ButtonIcon : StackLayout
        {
            /// <summary>
            /// Event call when Icon is Touched
            /// </summary>
            public event EventHandler Touched;

            private ButtonIconImage imageButton;

            private ColorUI colorUI = ColorUI.Gray;
            private IconType iconType = IconType.Like;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Constructor of ButtonIcon
            /// </summary>
            public ButtonIcon()
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
                imageButton = new ButtonIconImage("__Laavor*+-", IconType, ColorUI);
                imageButton.WidthRequest = Width;
                imageButton.MinimumWidthRequest = Width;
                imageButton.HeightRequest = Height;
                imageButton.MinimumHeightRequest = Height;

                imageButton.GestureRecognizers.Clear();

                if (!IsReadOnly)
                {
                    if (Vivacity != Vivacity.None)
                    {
                        if (imageButton.GestureRecognizers.Count == 0)
                        {
                            imageButton.GestureRecognizers.Add(GetVivacity());
                        }
                    }

                    if (Vivacity == Vivacity.None)
                    {
                        if (imageButton.GestureRecognizers.Count == 0)
                        {
                            imageButton.GestureRecognizers.Add(GetTouch());
                        }
                    }
                    else
                    {
                        if (imageButton.GestureRecognizers.Count == 1)
                        {
                            imageButton.GestureRecognizers.Add(GetTouch());
                        }
                    }
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

            /// <summary>
            /// Property to report if ButtonIcon is readonly.
            /// </summary>
            public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                     propertyName: nameof(IsReadOnly),
                     returnType: typeof(bool),
                     declaringType: typeof(ButtonIcon),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: IsReadOnlyPropertyChanged);

            /// <summary>
            /// Property to report if ButtonIcon is readonly.
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
                ButtonIcon buttonIcon = (ButtonIcon)bindable;
                bool isReadOnly = (bool)newValue;

                if (buttonIcon.imageButton != null)
                {
                    if (isReadOnly)
                    {
                        buttonIcon.imageButton.GestureRecognizers.Clear();

                        buttonIcon.imageButton.Opacity = 0.3;
                    }
                    else
                    {
                        if (buttonIcon.vivacity != Vivacity.None)
                        {
                            if (buttonIcon.GestureRecognizers.Count == 0)
                            {
                                buttonIcon.imageButton.GestureRecognizers.Add(buttonIcon.GetVivacity());
                            }
                        }

                        if (buttonIcon.vivacity == Vivacity.None)
                        {
                            if (buttonIcon.imageButton.GestureRecognizers.Count == 0)
                            {
                                buttonIcon.imageButton.GestureRecognizers.Add(buttonIcon.GetTouch());
                            }
                        }
                        else
                        {
                            if (buttonIcon.imageButton.GestureRecognizers.Count == 1)
                            {
                                buttonIcon.imageButton.GestureRecognizers.Add(buttonIcon.GetTouch());
                            }
                        }

                        buttonIcon.imageButton.Opacity = 1.0;
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
                    return colorUI;
                }
                set
                {
                    ColorUIPropertyChanged(this, colorUI, value);
                    colorUI = value;
                }
            }

            private void ColorUIPropertyChanged(object bindable, ColorUI oldValue, ColorUI newValue)
            {
                if (imageButton != null)
                {
                    imageButton.ChangeColor("__Laavor*+-", newValue);
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
                    return iconType;
                }
                set
                {
                    iconType = value;
                    IconTypePropertyChanged();
                }
            }

            private void IconTypePropertyChanged()
            {
                if (imageButton != null)
                {
                    imageButton.ChangeIconType("__Laavor*+-", iconType);
                }
            }

            /// <summary>
            /// Enter the height.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(ButtonIcon),
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
                ButtonIcon buttonIcon = (ButtonIcon)bindable;
                double buttonHeight = (double)newValue;

                if (buttonIcon.imageButton != null)
                {
                    buttonIcon.imageButton.HeightRequest = buttonHeight;
                }
            }

            /// <summary>
            /// Enter the width.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(ButtonIcon),
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
                ButtonIcon buttonIcon = (ButtonIcon)bindable;
                double buttonWidth = (double)newValue;

                if (buttonIcon.imageButton != null)
                {
                    buttonIcon.imageButton.WidthRequest = buttonWidth;
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
                    return vivacity;
                }
                set
                {
                    vivacity = value;
                    VivacityPropertyChanged();
                }
            }

            private void VivacityPropertyChanged()
            {
                if (!IsReadOnly)
                {
                    imageButton.GestureRecognizers.Clear();

                    if (vivacity != Vivacity.None)
                    {
                        if (imageButton.GestureRecognizers.Count == 0)
                        {
                            imageButton.GestureRecognizers.Add(GetVivacity());
                        }
                    }

                    if (vivacity == Vivacity.None)
                    {
                        if (imageButton.GestureRecognizers.Count == 0)
                        {
                            imageButton.GestureRecognizers.Add(GetTouch());
                        }
                    }
                    else
                    {
                        if (imageButton.GestureRecognizers.Count == 0)
                        {
                            imageButton.GestureRecognizers.Add(GetTouch());
                        }
                    }

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
                    return vivacitySpeed;
                }
                set
                {
                    vivacitySpeed = value;
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
                    return depth;
                }
                set
                {
                    depth = value;
                    VivacityPropertyChanged();
                }
            }

            /// <summary>
            /// Get Vivacity
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacity()
            {
                if (Vivacity != Vivacity.None)
                {
                    MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + Vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
                    TapGestureRecognizer touchVivavicity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
                    return touchVivavicity;
                }
                else
                {
                    return new TapGestureRecognizer();
                }
            }

            /// <summary>
            /// Use to create VivacityDecrease is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityDecrease()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };

                return animationTap;
            }

            /// <summary>
            /// Use to create DepthDecrease is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthDecrease(Depth depth)
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

            /// <summary>
            /// Use to create VivacityIncrease is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityIncrease()
            {
                TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
                vivacityTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };

                return vivacityTap;
            }

            /// <summary>
            /// Use to create DepthIncrease is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthIncrease(Depth depth)
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

            /// <summary>
            /// Use to create VivacityRotation is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityRotation()
            {
                TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
                vivacityTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };
                return vivacityTap;
            }

            /// <summary>
            /// Use to create DepthRotation is Auto Call
            /// </summary>
            /// <returns></returns>
            protected int GetDepthRotation(Depth depth)
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

            /// <summary>
            /// Use to create VivacityJump is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityJump()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };
                return animationTap;
            }

            /// <summary>
            /// Use to create DepthJump is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthJump(Depth depth)
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

            /// <summary>
            /// Use to create VivacityDown is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityDown()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };
                return animationTap;
            }

            /// <summary>
            /// Use to create DepthDown is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthDown(Depth depth)
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

            /// <summary>
            /// Use to create VivacityLeft is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityLeft()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };
                return animationTap;
            }

            /// <summary>
            /// Use to create DepthLeft is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthLeft(Depth depth)
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
            /// Use to create VivacityRight is Auto Call
            /// </summary>
            /// <returns></returns>
            private TapGestureRecognizer GetVivacityRight()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };
                return animationTap;
            }

            /// <summary>
            /// Use to create DepthRight is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthRight(Depth depth)
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
}
