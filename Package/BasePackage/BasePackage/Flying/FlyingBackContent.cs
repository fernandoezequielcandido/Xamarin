using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Flying
    {
        /// <summary>
        /// FlyingBoxContent
        /// </summary>
        public class FlyingBackContent : StackLayout
        {
            /// <summary>
            /// Call when FlyingBox is Closed
            /// </summary>
            public EventHandler Closed;

            private Frame frame;
            private StackLayout dataItems;
            private StackLayout stackClose;
            private Grid grid;
                       
            /// <summary>
            /// Informs if is flying (Open)
            /// </summary>
            public bool IsFlying { get; private set; }

            private bool isInternal;

            private CloseControl closeBoxImage;

            private ColorUI colorClose = ColorUI.Black;
            private ColorUI borderColor = ColorUI.Black;
            private ColorUI colorUI = ColorUI.White;

            private Depth depth = Depth.Medium;
            private Vivacity vivacity = Vivacity.Decrease;
            private DesignType designType = DesignType.Shinning;

            /// <summary>
            /// Constructor of FlyingBackContent
            /// </summary>
            public FlyingBackContent()
            {
                InitAll();
            }

            private void InitAll()
            {
                Children.Clear();

                IsFlying = false;

                this.Orientation = StackOrientation.Vertical;
                this.Spacing = 0;
                this.WidthRequest = Width;
                this.HorizontalOptions = LayoutOptions.CenterAndExpand;
                this.VerticalOptions = LayoutOptions.CenterAndExpand;

                dataItems = new StackLayout();
                dataItems.Margin = new Thickness(-10, -10, -10, -10);
                dataItems.VerticalOptions = LayoutOptions.Center;
                dataItems.FlowDirection = FlowDirection.MatchParent;
                dataItems.Spacing = 0;
                dataItems.WidthRequest = Width;

                frame = new Frame();
                frame.BorderColor = Colors.Get(borderColor);
                frame.VerticalOptions = LayoutOptions.Center;
                frame.BackgroundColor = Colors.Get(colorUI);
                frame.HasShadow = true;
                frame.HeightRequest = Height;
                frame.WidthRequest = Width;
                frame.Content = dataItems;

                AbsoluteLayout.SetLayoutFlags(this, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(this, new Rectangle(0.5, 0.5, 1.0, 1.0));

                IsVisible = false;

                isInternal = true;

                grid = new Grid
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = Width }
                    },
                    RowDefinitions =
                    {
                        new RowDefinition { Height =  GridLength.Auto}
                    }
                };

                grid.RowSpacing = 0;
                grid.HorizontalOptions = LayoutOptions.Center;

                closeBoxImage = new CloseControl("__Laavor*+-", colorClose);

                closeBoxImage.WidthRequest = WidthClose;
                closeBoxImage.HeightRequest = HeightClose;
                closeBoxImage.HorizontalOptions = LayoutOptions.End;

                closeBoxImage.GestureRecognizers.Add(GetVivacityIncrease());

                stackClose = new StackLayout();

                stackClose.Children.Add(closeBoxImage);
                stackClose.GestureRecognizers.Add(GetVivacityIncrease());

                Grid.SetRow(stackClose, 0);
                Grid.SetColumn(stackClose, 0);

                grid.Children.Add(stackClose);

                Grid.SetRow(frame, 1);
                Grid.SetColumn(frame, 0);
                grid.Children.Add(frame);

                Children.Add(grid);
                isInternal = false;
            }

            /// <summary>
            /// Depends on current state (IsFlying)
            /// </summary>
            public void HideShowContent()
            {
                IsFlying = !IsFlying;
                IsVisible = IsFlying;
            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="child"></param>
            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);

                if (!isInternal)
                {
                    if (child.GetType() == typeof(FlyingContent))
                    {
                        StackLayout userContentBox = (StackLayout)child;
                        for (int iS = 0; iS < userContentBox.Children.Count; iS++)
                        {
                            dataItems.Children.Add(userContentBox.Children[iS]);
                        }
                    }
                    else
                    {
                        Children.RemoveAt(Children.Count - 1);
                    }
                }
            }

            private void Close()
            {
                IsFlying = false;
                IsVisible = false;

                Closed?.Invoke(this, EventArgs.Empty);
            }

            private TapGestureRecognizer GetVivacity()
            {
                MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
                TapGestureRecognizer touchVivacity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);

                return touchVivacity;
            }

            private TapGestureRecognizer GetVivacityIncrease()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await closeBoxImage.ScaleTo(GetDepthIncrease(depth), 100, Easing.Linear);
                        await closeBoxImage.ScaleTo(1, 100, Easing.Linear);

                        IsFlying = false;
                        IsVisible = false;

                        Close();
                    }
                    catch { }
                };

                return animationTap;
            }


            private double GetDepthIncrease(Depth depth)
            {
                if (depth == Depth.Small)
                {
                    return 1.05;
                }
                else if (depth == Depth.LessMedium)
                {
                    return 1.10;
                }
                else if (depth == Depth.Medium)
                {
                    return 1.15;
                }
                else
                {
                    return 1.20;
                }
            }

            private TapGestureRecognizer GetVivacityDecrease()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await closeBoxImage.ScaleTo(GetDepthDecrease(depth), 100, Easing.Linear);
                        await closeBoxImage.ScaleTo(1, 100, Easing.Linear);

                        IsFlying = false;
                        IsVisible = false;

                        Close();
                    }
                    catch { }
                };

                return animationTap;
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

            private TapGestureRecognizer GetVivacityJump()
            {
                TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
                vivacityTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await closeBoxImage.TranslateTo(0, GetDepthJump(depth), 100, Easing.Linear);
                        await closeBoxImage.TranslateTo(0, 0, 100, Easing.Linear);

                        IsFlying = false;
                        IsVisible = false;

                        Close();
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
                closeBoxImage.GestureRecognizers.Clear();
                stackClose.GestureRecognizers.Clear();

                closeBoxImage.GestureRecognizers.Add(GetVivacity());
                stackClose.GestureRecognizers.Add(GetVivacity());
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
                    DepthPropertyChanged();
                }
            }

            private void DepthPropertyChanged()
            {
                VivacityPropertyChanged();
            }

            /// <summary>
            /// Set Color of Close Image
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorClose
            {
                get
                {
                    return colorClose;
                }
                set
                {
                    colorClose = value;
                    ColorClosePropertyChanged(colorClose);
                }
            }

            private void ColorClosePropertyChanged(ColorUI newValue)
            {
                closeBoxImage.ChangeColor("__Laavor*+-", newValue);
            }

            /// <summary>
            /// Set ColorUI
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
                    ColorUIPropertyChanged(value);
                }
            }

            private void ColorUIPropertyChanged(ColorUI newValue)
            {
                if (frame != null)
                {
                    frame.BackgroundColor = Colors.Get(newValue);
                }
            }

            /// <summary>
            /// Set BorderColor
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
                    BorderColorPropertyChanged(value);
                }
            }

            private void BorderColorPropertyChanged(ColorUI newValue)
            {
                if (frame != null)
                {
                    frame.BorderColor = Colors.Get(newValue);
                }
            }

            /// <summary>
            /// Set DesignType
            /// </summary>
            [Bindable(true)]
            public DesignType DesignType
            {
                get
                {
                    return designType;
                }
                set
                {
                    designType = value;
                    DesignTypePropertyChanged();
                }
            }

            private void DesignTypePropertyChanged()
            {
                closeBoxImage.ChangeDesignType("__Laavor*+-", designType);
            }

            /// <summary>
            /// Enter the Width.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(FlyingBackContent),
                defaultValue: 300.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthPropertyChanged);

            /// <summary>
            /// Enter the Width.
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
                FlyingBackContent flyingBoxContent = (FlyingBackContent)bindable;
                double copyWidth = (double)newValue;

                if (flyingBoxContent.frame != null)
                {
                    flyingBoxContent.frame.WidthRequest = copyWidth;
                    flyingBoxContent.dataItems.WidthRequest = copyWidth;
                    flyingBoxContent.WidthRequest = copyWidth;
                    flyingBoxContent.grid.ColumnDefinitions[0].Width = copyWidth;
                }
            }

            /// <summary>
            /// Enter the Height.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(FlyingBackContent),
                defaultValue: 300.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: HeightPropertyChanged);

            /// <summary>
            /// Enter the Height.
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
                FlyingBackContent flyingBoxContent = (FlyingBackContent)bindable;
                double copyHeight = (double)newValue;

                if (flyingBoxContent.frame != null)
                {
                    flyingBoxContent.frame.HeightRequest = copyHeight;
                }
            }

            /// <summary>
            /// Enter the Width Close Image.
            /// </summary>
            public static readonly BindableProperty WidthCloseProperty = BindableProperty.Create(
                propertyName: nameof(WidthClose),
                returnType: typeof(double),
                declaringType: typeof(FlyingBackContent),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthClosePropertyChanged);

            /// <summary>
            /// Enter the Width Close Image.
            /// </summary>
            public double WidthClose
            {
                get
                {
                    return (double)GetValue(WidthCloseProperty);
                }
                set
                {
                    SetValue(WidthCloseProperty, value);
                }
            }

            private static void WidthClosePropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingBackContent flyingBoxContent = (FlyingBackContent)bindable;
                double copyWidthClose = (double)newValue;

                if (flyingBoxContent.closeBoxImage != null)
                {
                    flyingBoxContent.closeBoxImage.WidthRequest = copyWidthClose;
                }
            }

            /// <summary>
            /// Enter the Height Close Image.
            /// </summary>
            public static readonly BindableProperty HeightCloseProperty = BindableProperty.Create(
                propertyName: nameof(HeightClose),
                returnType: typeof(double),
                declaringType: typeof(FlyingBackContent),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: HeightClosePropertyChanged);

            /// <summary>
            /// Enter the Height Close Image.
            /// </summary>
            public double HeightClose
            {
                get
                {
                    return (double)GetValue(HeightCloseProperty);
                }
                set
                {
                    SetValue(HeightCloseProperty, value);
                }
            }

            private static void HeightClosePropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingBackContent flyingBoxContent = (FlyingBackContent)bindable;
                double copyHeightClose = (double)newValue;

                if (flyingBoxContent.closeBoxImage != null)
                {
                    flyingBoxContent.closeBoxImage.HeightRequest = copyHeightClose;
                }
            }
        }
    }
}
