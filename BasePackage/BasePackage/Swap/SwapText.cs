using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Swap
    {
        /// <summary>
        /// Class SwapText
        /// </summary>
        public class SwapText: StackLayout
        {
            /// <summary>
            /// Returns current Text.
            /// </summary>
            public string CurrentText { get; private set; }

            /// <summary>
            /// Returns current Value.
            /// </summary>
            public string CurrentValue { get; private set; }

            /// <summary>
            /// Returns current index of Text.
            /// </summary>
            public int CurrentIndex { get; private set; }

            private int currentIndex;

            private SwapBox frame;
            private SwapLabel label;

            private ColorUI colorUI = ColorUI.Transparent;
            private FontAttributes fontType = FontAttributes.Bold;
            private ColorUI textColor = ColorUI.Black;
            private ColorUI borderColor = ColorUI.Black;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            private List<SwapTextItem> listItems;

            /// <summary>
            /// Event called when change Text
            /// </summary>
            public event EventHandler Swap;

            /// <summary>
            /// Constructor of SwapText
            /// </summary>
            public SwapText() : base()
            {
                Orientation = StackOrientation.Horizontal;
                this.Spacing = 0;
                this.HorizontalOptions = LayoutOptions.Center;
                InitAll();
            }

            private void InitAll()
            {
                Children.Clear();

                CurrentText = "";
                CurrentValue = "";
                CurrentIndex = 0;
                currentIndex = 0;

                frame = new SwapBox();
                label = new SwapLabel();
                listItems = new List<SwapTextItem>();

                label.Text = "";

                label.setIndex("__Laavor*+-", 0);
                label.FontAttributes = FontType;
                label.FontSize = FontSize;
                label.TextColor = Colors.Get(TextColor);
                label.InputTransparent = false;
                label.HorizontalTextAlignment = TextAlignment.Center;
                label.HorizontalOptions = LayoutOptions.Center;

                label.Margin = new Thickness(-10, -17, -10, -17);

                frame.setIndex("__Laavor*+-", 0);
                frame.Content = label;
                frame.HasShadow = true;
                frame.BackgroundColor = Colors.Get(ColorUI);
                frame.GestureRecognizers.Add(GetVivacity());
                frame.GestureRecognizers.Add(GetTouch());
                frame.WidthRequest = Width;
                WidthRequest = Width;

                label.GestureRecognizers.Add(GetVivacity());
                label.GestureRecognizers.Add(GetTouch());
                label.IsChosen = true;

                Children.Add(frame);
            }

            private TapGestureRecognizer GetTouch()
            {
                var touch = new TapGestureRecognizer();
                touch.Tapped += Text_Touched;
                return touch;
            }

            /// <summary>
            /// Block Swap
            /// </summary>
            public void BlockSwap()
            {
                frame.GestureRecognizers.Clear();
                label.GestureRecognizers.Clear();
            }

            /// <summary>
            /// Release Swap
            /// </summary>
            public void ReleaseSwap()
            {
                frame.GestureRecognizers.Clear();
                label.GestureRecognizers.Clear();

                frame.GestureRecognizers.Add(GetVivacity());
                frame.GestureRecognizers.Add(GetTouch());

                label.GestureRecognizers.Add(GetVivacity());
                label.GestureRecognizers.Add(GetVivacity());
            }

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(SwapText),
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
                SwapText swapLabel = (SwapText)bindable;
                string fontFamily = (string)newValue;

                if (swapLabel.label != null)
                {
                    swapLabel.label.FontFamily = fontFamily;
                }
            }

            /// <summary>
            /// Enter the fonttype (None, Bold, Italic).
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
                label.FontAttributes = fontType;
            }

            /// <summary>
            /// Enter the Width.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(SwapText),
                defaultValue: 140.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthPropertyChanged);

            /// <summary>
            /// Enter the font Width.
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
                SwapText swap = (SwapText)bindable;
                double width = (double)newValue;

                if (swap.frame != null)
                {
                    swap.frame.WidthRequest = width;
                    swap.WidthRequest = width;
                }
            }

            /// <summary>
            /// Enter the font size, represents only one number.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(SwapText),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizePropertyChanged);

            /// <summary>
            /// Enter the font size, represents only one number.
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
                SwapText swap = (SwapText)bindable;
                double fontSize = (double)newValue;

                if (swap.label != null)
                {
                    swap.label.FontSize = fontSize;
                }
            }

            /// <summary>
            /// Enter the TextColor.
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
                if (label != null)
                {
                    label.TextColor = Colors.Get(textColor);
                }
            }

            /// <summary>
            /// Enter the BorderColor.
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
            /// Enter the ColorUI.
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
            /// Internal.
            /// </summary>
            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);

                if (child.GetType() == typeof(SwapTextItem))
                {
                    SwapTextItem item = (SwapTextItem)child;
                    item.setIndex("__Laavor*+-", currentIndex);

                    if (currentIndex == 0)
                    {
                        label.setIndex("__Laavor*+-", currentIndex);
                        label.Text = item.Text;

                        if (item.UseSpecificTextColor)
                        {
                            label.TextColor = Colors.Get(item.TextColor);
                        }
                        else
                        {
                            label.TextColor = Colors.Get(TextColor);
                        }

                        if (item.UseSpecificBackgroundColor)
                        {
                            frame.BackgroundColor = Colors.Get(item.ColorUI);
                        }
                        else
                        {
                            frame.BackgroundColor = Colors.Get(ColorUI);
                        }

                        if (item.UseSpecificBorderColor)
                        {
                            frame.BorderColor = Colors.Get(item.BorderColor);
                        }
                        else
                        {
                            frame.BorderColor = Colors.Get(BorderColor);
                        }

                        CurrentText = item.Text;
                        CurrentValue = item.Value;
                    }

                    listItems.Add(item);

                    currentIndex++;
                }
            }

            private void Text_Touched(object sender, EventArgs e)
            {
                SwapLabel itemUser;

                if (sender.GetType() == typeof(SwapLabel))
                {
                    itemUser = (SwapLabel)sender;
                }
                else
                {
                    SwapBox itemBox = (SwapBox)sender;
                    itemUser = new SwapLabel();
                    itemUser.setIndex("__Laavor*+-", itemBox.Index);
                }
                                
                SwapTextItem item;
                if ((itemUser.Index + 1) >= listItems.Count)
                {
                    item = listItems[0];
                    label.Text = item.Text;
                    label.setIndex("__Laavor*+-", 0);
                    frame.setIndex("__Laavor*+-", 0);
                }
                else
                {
                    item = listItems[itemUser.Index + 1];
                    label.Text = item.Text;
                    label.setIndex("__Laavor*+-", (itemUser.Index + 1));
                    frame.setIndex("__Laavor*+-", (itemUser.Index + 1));
                }

                CurrentIndex = label.Index;
                CurrentText = item.Text;
                CurrentValue = item.Value;

                if (item.UseSpecificTextColor)
                {
                    label.TextColor = Colors.Get(item.TextColor);
                }
                else
                {
                    label.TextColor = Colors.Get(TextColor);
                }

                if (item.UseSpecificBackgroundColor)
                {
                    label.BackgroundColor = Colors.Get(item.ColorUI);
                    frame.BackgroundColor = Colors.Get(item.ColorUI);
                }
                else
                {
                    label.BackgroundColor = Colors.Get(ColorUI);
                    frame.BackgroundColor = Colors.Get(ColorUI);
                }

                if (item.UseSpecificBorderColor)
                {
                    frame.BorderColor = Colors.Get(item.BorderColor);
                }
                else
                {
                    frame.BorderColor = Colors.Get(BorderColor);
                }

                if (Swap != null)
                {
                    Swap?.Invoke(this, e);
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
                label.GestureRecognizers.Clear();
                frame.GestureRecognizers.Clear();

                label.GestureRecognizers.Add(GetVivacity());
                frame.GestureRecognizers.Add(GetVivacity());

                label.GestureRecognizers.Add(GetTouch());
                frame.GestureRecognizers.Add(GetTouch());

                label.Opacity = 1.0;
                frame.Opacity = 1.0;
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
                        await label.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await frame.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await label.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                        await frame.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        await label.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await frame.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await label.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                        await frame.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        await label.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await frame.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await label.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
                        await frame.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
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
                        await label.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await label.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await label.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await label.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await label.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await label.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await label.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await label.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await frame.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
