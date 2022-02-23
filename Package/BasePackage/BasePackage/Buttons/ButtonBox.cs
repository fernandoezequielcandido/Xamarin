using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Buttons
    {
        /// <summary>
        /// Class Button Box
        /// </summary>
        public class ButtonBox : StackLayout
        {
            /// <summary>
            /// Call when Button Box is Touched
            /// </summary>
            public event EventHandler Touched;

            private Frame frame;
            private Label labelText;

            private StackLayout stackAll;
            
            private ColorUI colorUI = ColorUI.Gray;
            private FontAttributes fontType = FontAttributes.Bold;
            private ColorUI textColor = ColorUI.Black;
            private ColorUI borderColor = ColorUI.Black;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Class ButtonBox
            /// </summary>
            public ButtonBox()
            {
                InitAll();
            }
   
            private void InitAll()
            {
                Children.Clear();

                this.Spacing = 0;

                labelText = new Label();
                labelText.VerticalOptions = LayoutOptions.Start;
                labelText.HorizontalTextAlignment = TextAlignment.Center;
                labelText.HorizontalOptions = LayoutOptions.Center;
                labelText.FontSize = FontSize;
                labelText.Margin = new Thickness(0, -15, 0, -15);
                labelText.InputTransparent = InputTransparent;
                labelText.TextColor = Colors.Get(TextColor);
                labelText.BackgroundColor = Color.Transparent;
                labelText.Text = Text;

                labelText.GestureRecognizers.Clear();

                if (!IsReadOnly)
                {
                    if (vivacity != Vivacity.None)
                    {
                        if (labelText.GestureRecognizers.Count == 0)
                        {
                            labelText.GestureRecognizers.Add(GetVivacity());
                        }
                    }

                    if (vivacity == Vivacity.None)
                    {
                        if (labelText.GestureRecognizers.Count == 0)
                        {
                            labelText.GestureRecognizers.Add(GetTouch());
                        }
                    }
                    else
                    {
                        if (labelText.GestureRecognizers.Count == 1)
                        {
                            labelText.GestureRecognizers.Add(GetTouch());
                        }
                    }
                }

                frame = new Frame();
                frame.BorderColor = Color.Black;
                frame.VerticalOptions = LayoutOptions.Center;
                frame.HorizontalOptions = LayoutOptions.Center;
                frame.BackgroundColor = Colors.Get(ColorUI);

                frame.GestureRecognizers.Clear();

                if(frame.GestureRecognizers.Count == 0)
                {
                    frame.GestureRecognizers.Add(GetVivacity());
                }

                if (frame.GestureRecognizers.Count == 1)
                {
                    frame.GestureRecognizers.Add(GetTouch());
                }
                
                frame.BackgroundColor = Colors.Get(ColorUI);
                frame.BorderColor = Colors.Get(BorderColor);
                frame.HasShadow = true;
                frame.Content = labelText;

                stackAll = new StackLayout();
                stackAll.Spacing = 0;
                stackAll.Orientation = StackOrientation.Vertical;
                stackAll.Children.Add(frame);

                Children.Add(stackAll);

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
            /// Property to report if Button Box is readonly.
            /// </summary>
            public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                     propertyName: nameof(IsReadOnly),
                     returnType: typeof(bool),
                     declaringType: typeof(ButtonBox),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: IsReadOnlyPropertyChanged);

            /// <summary>
            /// Property to report if Button Box is readonly.
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
                ButtonBox button = (ButtonBox)bindable;
                bool isReadOnly = (bool)newValue;

                if (button.frame != null && button.labelText != null)
                {
                    if (isReadOnly)
                    {
                        button.frame.GestureRecognizers.Clear();
                        button.labelText.GestureRecognizers.Clear();

                        button.frame.Opacity = 0.3;
                        button.labelText.Opacity = 0.3;

                        button.labelText.Text = button.TextReadOnly;
                    }
                    else
                    {
                        button.frame.GestureRecognizers.Clear();
                        button.labelText.GestureRecognizers.Clear();

                        if (button.vivacity != Vivacity.None)
                        {
                            if (button.frame.GestureRecognizers.Count == 0)
                            {
                                button.frame.GestureRecognizers.Add(button.GetVivacity());
                            }

                            if (button.labelText.GestureRecognizers.Count == 0)
                            {
                                button.labelText.GestureRecognizers.Add(button.GetVivacity());
                            }
                        }

                        if (button.vivacity == Vivacity.None)
                        {
                            if (button.frame.GestureRecognizers.Count == 0)
                            {
                                button.frame.GestureRecognizers.Add(button.GetTouch());
                            }

                            if (button.labelText.GestureRecognizers.Count == 0)
                            {
                                button.labelText.GestureRecognizers.Add(button.GetTouch());
                            }
                        }
                        else
                        {
                            if (button.frame.GestureRecognizers.Count == 1)
                            {
                                button.frame.GestureRecognizers.Add(button.GetTouch());
                            }

                            if (button.labelText.GestureRecognizers.Count == 1)
                            {
                                button.labelText.GestureRecognizers.Add(button.GetTouch());
                            }
                        }

                        button.frame.Opacity = 1.0;
                        button.labelText.Opacity = 1.0;
                    }
                }
            }
                      
            /// <summary>
            /// Enter the text
            /// </summary>
            public static readonly BindableProperty TextProperty = BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(ButtonBox),
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
                ButtonBox buttonBox = (ButtonBox)bindable;
                string buttonText = (string)newValue;
                if (buttonBox.labelText != null)
                {
                    buttonBox.labelText.Text = buttonText;
                }
            }

            /// <summary>
            /// Enter the font size of text Button Box.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(ButtonBox),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizePropertyChanged);

            /// <summary>
            /// Enter the font size of text Button Box.
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
                ButtonBox buttonBox = (ButtonBox)bindable;
                double fontSize = (double)newValue;
                if (buttonBox.labelText != null)
                {
                    buttonBox.labelText.FontSize = fontSize;
                }
            }

            /// <summary>
            /// Set FontType
            /// </summary>
            [Bindable(true)]
            public FontAttributes FontType
            {
                get
                {
                    return fontType;
                }
                set
                {
                    fontType = value;
                    FontTypePropertyChanged();
                }
            }

            private void FontTypePropertyChanged()
            {
                if (labelText != null)
                {
                    labelText.FontAttributes = fontType;
                }
            }

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(ButtonBox),
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
                ButtonBox buttonBox = (ButtonBox)bindable;
                string fontFamily = (string)newValue;

                if (buttonBox.labelText != null)
                {
                    buttonBox.labelText.FontFamily = fontFamily;
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
                    colorUI = value;
                    ColorUIPropertyChanged();
                 
                }
            }

            private void ColorUIPropertyChanged()
            {
                if (frame != null)
                {
                    frame.BackgroundColor = Colors.Get(colorUI);
                }
            }

            /// <summary>
            /// Set if is TextColor
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColor
            {
                get
                {
                    return textColor;
                }
                set
                {
                    textColor = value;
                    TextColorPropertyChanged();
                }
            }

            private void TextColorPropertyChanged()
            {
                if (labelText != null)
                {
                    labelText.TextColor = Colors.Get(textColor);
                }
            }

            /// <summary>
            /// Set if is BorderColor
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColor
            {
                get
                {
                    return borderColor;
                }
                set
                {
                    borderColor = value;
                    BorderColorPropertyChanged();

                }
            }

            private void BorderColorPropertyChanged()
            {
                if (frame != null)
                {
                    frame.BorderColor = Colors.Get(borderColor);
                }
            }

            /// <summary>
            /// Text ReadOnly
            /// </summary>
            public static readonly BindableProperty TextReadOnlyProperty = BindableProperty.Create(
                     propertyName: nameof(TextReadOnly),
                     returnType: typeof(string),
                     declaringType: typeof(ButtonBox),
                     defaultValue: "",
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: TextReadOnlyPropertyChanged);

            /// <summary>
            /// Text ReadOnly
            /// </summary>
            public string TextReadOnly
            {
                get
                {
                    return (string)GetValue(TextReadOnlyProperty);
                }
                set
                {
                    SetValue(TextReadOnlyProperty, value);
                }
            }

            private static void TextReadOnlyPropertyChanged(object bindable, object oldValue, object newValue)
            {
                ButtonBox buttonBox = (ButtonBox)bindable;
                if (buttonBox.IsReadOnly && buttonBox.labelText != null)
                {
                    buttonBox.labelText.Text = (string)newValue;
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
                    if (frame != null && labelText != null)
                    {
                        frame.GestureRecognizers.Clear();
                        labelText.GestureRecognizers.Clear();

                        if (vivacity != Vivacity.None)
                        {
                            if (frame.GestureRecognizers.Count == 0)
                            {
                                frame.GestureRecognizers.Add(GetVivacity());
                            }

                            if (labelText.GestureRecognizers.Count == 0)
                            {
                                labelText.GestureRecognizers.Add(GetVivacity());
                            }
                        }

                        if (vivacity == Vivacity.None)
                        {
                            if (frame.GestureRecognizers.Count == 0)
                            {
                                frame.GestureRecognizers.Add(GetTouch());
                            }

                            if (labelText.GestureRecognizers.Count == 0)
                            {
                                labelText.GestureRecognizers.Add(GetTouch());
                            }
                        }
                        else
                        {
                            if (frame.GestureRecognizers.Count == 0)
                            {
                                frame.GestureRecognizers.Add(GetTouch());
                            }

                            if (labelText.GestureRecognizers.Count == 0)
                            {
                                labelText.GestureRecognizers.Add(GetTouch());
                            }
                        }

                        frame.Opacity = 1.0;
                        labelText.Opacity = 1.0;
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
                        await frame.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await frame.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        await frame.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await frame.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        await frame.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await frame.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
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
                        await frame.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await frame.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await frame.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await frame.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
