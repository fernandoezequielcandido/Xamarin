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
        /// Class SwapImage
        /// </summary>
        public class SwapImage : StackLayout
        {
            /// <summary>
            /// Returns current source.
            /// </summary>
            public string CurrentSource { get; private set; }

            /// <summary>
            /// Returns current value.
            /// </summary>
            public string CurrentValue { get; private set; }

            /// <summary>
            /// Returns current index of image, start in 0.
            /// </summary>
            public int CurrentIndex { get; private set; }

            private int currentIndex;

            private SwapImageBase image;

            private List<SwapImageItem> listItems;

            private SwapLabel labelText;
            private AbsoluteLayout absoluteToImage;
            private StackLayout stackContent;

            private FontAttributes fontType = FontAttributes.Bold;
            private ColorUI textColor = ColorUI.Black;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Event called when change image
            /// </summary>
            public event EventHandler Swap;

            /// <summary>
            /// Constructor of SwapImage        
            /// </summary>
            public SwapImage() : base()
            {
                this.Spacing = 0;
                Orientation = StackOrientation.Vertical;
                HorizontalOptions = LayoutOptions.Center;
                InitAll();
            }

            private void InitAll()
            {
                this.Spacing = 0;
                Children.Clear();

                listItems = new List<SwapImageItem>();
                image = new SwapImageBase();

                absoluteToImage = new AbsoluteLayout();

                stackContent = new StackLayout();
                stackContent.Spacing = 0;

                image.WidthRequest = ImageWidth;
                image.HeightRequest = ImageHeight;
                image.MinimumWidthRequest = ImageWidth;
                image.MinimumHeightRequest = ImageHeight;
                image.VerticalOptions = LayoutOptions.Center;
                image.HorizontalOptions = LayoutOptions.Center;
                image.Aspect = Aspect.AspectFill;

                image.GestureRecognizers.Add(GetVivacity());
                image.GestureRecognizers.Add(GetTouch());

                image.Source = "";

                AbsoluteLayout.SetLayoutFlags(stackContent, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(stackContent, new Rectangle(GetX(Position), GetY(Position), -1, -1));

                absoluteToImage.VerticalOptions = LayoutOptions.CenterAndExpand;

                Children.Add(absoluteToImage);

                labelText = new SwapLabel();
                labelText.IsVisible = false;
                labelText.FontSize = FontSize;
                labelText.TextColor = Colors.Get(TextColor);
                labelText.FontFamily = FontFamily;
                labelText.FontAttributes = FontType;
                labelText.GestureRecognizers.Add(GetVivacity());
                labelText.GestureRecognizers.Add(GetTouch());
                labelText.HorizontalOptions = LayoutOptions.Center;

                Children.Add(labelText);

                this.Margin = new Thickness(5, 5, 5, 5);
            }

            private TapGestureRecognizer GetTouch()
            {
                var touch = new TapGestureRecognizer();
                touch.Tapped += Touched;
                return touch;
            }

            /// <summary>
            /// Block Swap
            /// </summary>
            public void BlockSwap()
            {
                image.GestureRecognizers.Clear();
                labelText.GestureRecognizers.Clear();
            }

            /// <summary>
            /// Release Swap
            /// </summary>
            public void ReleaseSwap()
            {
                image.GestureRecognizers.Clear();
                labelText.GestureRecognizers.Clear();

                image.GestureRecognizers.Add(GetVivacity());
                labelText.GestureRecognizers.Add(GetTouch());

                image.GestureRecognizers.Add(GetVivacity());
                labelText.GestureRecognizers.Add(GetVivacity());
            }

            private double GetX(PositionContent p)
            {
                if (p == PositionContent.CenterBottom || p == PositionContent.CenterMidle || p == PositionContent.CenterTop)
                {
                    return 0.5;
                }
                else if (p == PositionContent.LeftBottom || p == PositionContent.LeftMidle || p == PositionContent.LeftTop)
                {
                    return 0.03;
                }
                else
                {
                    return 0.93;
                }
            }

            private double GetY(PositionContent p)
            {
                if (p == PositionContent.CenterTop || p == PositionContent.LeftTop || p == PositionContent.RightTop)
                {
                    return 0.03;
                }
                else if (p == PositionContent.CenterMidle || p == PositionContent.LeftMidle || p == PositionContent.RightMidle)
                {
                    return 0.5;
                }
                else
                {
                    return 0.93;
                }
            }

            /// <summary>
            /// Enter the Position.
            /// </summary>
            public static readonly BindableProperty PositionProperty = BindableProperty.Create(
                propertyName: nameof(Position),
                returnType: typeof(PositionContent),
                declaringType: typeof(SwapImage),
                defaultValue: PositionContent.LeftBottom,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: PositionPropertyChanged);

            /// <summary>
            /// Enter the Position.
            /// </summary>
            public PositionContent Position
            {
                get
                {
                    return (PositionContent)GetValue(PositionProperty);
                }
                set
                {
                    SetValue(PositionProperty, value);
                }
            }

            private static void PositionPropertyChanged(object bindable, object oldValue, object newValue)
            {
                SwapImage swap = (SwapImage)bindable;
                PositionContent position = (PositionContent)newValue;
                if (swap.image != null)
                {
                    AbsoluteLayout.SetLayoutBounds(swap.stackContent, new Rectangle(swap.GetX(position), swap.GetY(position), -1, -1));
                }
            }

            /// <summary>
            /// Enter the image height.
            /// </summary>
            public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create(
                propertyName: nameof(ImageHeight),
                returnType: typeof(double),
                declaringType: typeof(SwapImage),
                defaultValue: 200.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImageHeightPropertyChanged);

            /// <summary>
            /// Enter the image height.
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
                SwapImage swap = (SwapImage)bindable;
                double imageHeight = (double)newValue;
                if (swap.image != null)
                {
                    swap.image.HeightRequest = imageHeight;
                }
            }

            /// <summary>
            /// Enter the image width.
            /// </summary>
            public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(
                propertyName: nameof(ImageWidth),
                returnType: typeof(double),
                declaringType: typeof(SwapImage),
                defaultValue: 200.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImageWidthPropertyChanged);

            /// <summary>
            /// Enter the image width.
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
                SwapImage swap = (SwapImage)bindable;
                double imageWidth = (double)newValue;
                if (swap.image != null)
                {
                    swap.image.WidthRequest = imageWidth;
                    swap.WidthRequest = imageWidth;
                    swap.MinimumWidthRequest = imageWidth;
                }
            }

            /// <summary>
            /// Enter the font size of text.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(SwapImage),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizePropertyChanged);

            /// <summary>
            /// Enter the font size of text.
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
                SwapImage swapImage = (SwapImage)bindable;
                double fontSize = (double)newValue;

                if (swapImage.labelText != null)
                {
                    swapImage.labelText.FontSize = fontSize;
                }
            }

            /// <summary>
            /// Set TextColor
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
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(SwapImage),
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
                SwapImage swapImage = (SwapImage)bindable;
                string fontFamily = (string)newValue;

                if (swapImage.labelText != null)
                {
                    swapImage.labelText.FontFamily = fontFamily;
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
            /// Internal.
            /// </summary>
            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);

                if (child.GetType() == typeof(SwapImageItem))
                {
                    SwapImageItem item = (SwapImageItem)child;
                    item.setIndex("__Laavor*+-", currentIndex);

                    if (currentIndex == 0)
                    {
                        image.Index = currentIndex;
                        image.Source = item.Image;

                        if (!string.IsNullOrEmpty(item.Text))
                        {
                            labelText.Text = item.Text;
                            labelText.IsVisible = true;
                        }
                        else
                        {
                            labelText.IsVisible = false;
                        }

                        labelText.setIndex("__Laavor*+-", currentIndex);
                    }

                    if (item.UseSpecificWidth)
                    {
                        image.WidthRequest = item.ImageWidth;
                    }
                    else
                    {
                        image.WidthRequest = ImageWidth;
                    }

                    if (item.UseSpecificHeight)
                    {
                        image.HeightRequest = item.ImageHeight;
                    }
                    else
                    {
                        image.HeightRequest = ImageHeight;
                    }

                    absoluteToImage.Children.Add(image);
                    absoluteToImage.Children.Add(stackContent);

                    if (item.Content != null)
                    {
                        (item.Content as SwapImageItemContent).SetUser("__Laavor*+-", this);

                        if (currentIndex == 0)
                        {
                            item.Content.IsVisible = true;
                        }
                        else
                        {
                            item.Content.IsVisible = false;
                        }
                        stackContent.Children.Add(item.Content);
                        absoluteToImage.Children.Add(stackContent);
                    }

                    listItems.Add(item);
                    currentIndex++;
                }
            }

            private void Touched(object sender, EventArgs e)
            {
                try
                {
                    int index;

                    if (sender.GetType() == typeof(SwapImageBase))
                    {
                        var itemUser = (SwapImageBase)sender;
                        index = itemUser.Index;
                    }
                    else if (sender.GetType() == typeof(SwapLabel))
                    {
                        var itemUser = (SwapLabel)sender;
                        index = itemUser.Index;
                    }
                    else
                    {
                        return;
                    }

                    if (listItems[index].Content != null)
                    {
                        listItems[index].Content.IsVisible = false;
                    }

                    SwapImageItem item;
                    if ((index + 1) >= listItems.Count)
                    {
                        item = listItems[0];
                        image.Source = item.Image;
                        image.Index = 0;
                    }
                    else
                    {
                        item = listItems[index + 1];
                        image.Source = item.Image;
                        image.Index = index + 1;
                    }

                    if (item.UseSpecificWidth)
                    {
                        image.WidthRequest = item.ImageWidth;
                    }
                    else
                    {
                        image.WidthRequest = ImageWidth;
                    }

                    if (item.UseSpecificHeight)
                    {
                        image.HeightRequest = item.ImageHeight;
                    }
                    else
                    {
                        image.HeightRequest = ImageHeight;
                    }

                    stackContent.Children.Clear();
                    if (item.Content != null)
                    {
                        stackContent.Children.Add(item.Content);
                        item.Content.IsVisible = true;
                        AbsoluteLayout.SetLayoutBounds(stackContent, new Rectangle(GetX((item.Content as SwapImageItemContent).Position), GetY((item.Content as SwapImageItemContent).Position), -1, -1));
                    }

                    if (!string.IsNullOrEmpty(item.Text))
                    {
                        labelText.Text = item.Text;
                        labelText.IsVisible = true;
                    }
                    else
                    {
                        labelText.IsVisible = false;
                    }

                    CurrentIndex = item.Index;
                    CurrentValue = item.Value;
                    CurrentSource = item.Image;

                    labelText.setIndex("__Laavor*+-", CurrentIndex);

                    if (Swap != null)
                    {
                        Swap?.Invoke(this, e);
                    }
                }
                catch
                { }
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
                image.GestureRecognizers.Clear();
                labelText.GestureRecognizers.Clear();

                image.GestureRecognizers.Add(GetVivacity());
                labelText.GestureRecognizers.Add(GetVivacity());

                image.GestureRecognizers.Add(GetTouch());
                labelText.GestureRecognizers.Add(GetTouch());

                image.Opacity = 1.0;
                labelText.Opacity = 1.0;
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
                        await image.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await image.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        await image.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await image.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        await image.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await image.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
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
                        await image.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await image.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await image.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await image.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await image.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await image.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await image.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await image.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
