using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorFlyingBox
{
    /// <summary>
    /// FlyingBoxContent
    /// </summary>
    public class FlyingBoxContent : StackLayout
    {
        /// <summary>
        /// Call when FlyingBox is Closed
        /// </summary>
        public EventHandler Closed;

        private Frame frameReference;
        private StackLayout dataItems;
        private StackLayout stackClose;
        private Grid gridReference;



        /// <summary>
        /// Informs if is flying (Open)
        /// </summary>
        public bool IsFlying { get; private set; }

        private bool isInternal;

        private CloseBoxImage closeBoxImageReference;

        private ColorUI currentColorClose = ColorUI.Black;
        private ColorUI currentBorderColor = ColorUI.Black;
        private ColorUI currentColorUI = ColorUI.White;

        private Depth currentDepth = Depth.Medium;
        private Vivacity currentVivacity = Vivacity.Decrease;
        private DesignType currentDesignType = DesignType.Standard;

        /// <summary>
        /// Constructor of FlyingBoxContent
        /// </summary>
        public FlyingBoxContent()
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
            dataItems.Margin = new Thickness(-20, -20, -20, -20);
            dataItems.VerticalOptions = LayoutOptions.Center;
            dataItems.FlowDirection = FlowDirection.MatchParent;
            dataItems.Spacing = 0;
            dataItems.WidthRequest = Width;

            frameReference = new Frame();
            frameReference.BorderColor = GetColorFromColorUI(currentBorderColor);
            frameReference.VerticalOptions = LayoutOptions.Center;
            frameReference.BackgroundColor = GetColorFromColorUI(currentColorUI);
            frameReference.HasShadow = true;
            frameReference.HeightRequest = Height;
            frameReference.WidthRequest = Width;
            frameReference.Content = dataItems;

            AbsoluteLayout.SetLayoutFlags(this, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(this, new Rectangle(0.5, 0.5, 1.0, 1.0));

            IsVisible = false;

            isInternal = true;

            gridReference = new Grid
            {
                ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = Width }
                    },
                RowDefinitions =
                    {
                        new RowDefinition { Height =  GridLength.Auto},
                        new RowDefinition { Height =  GridLength.Auto}
                    }
            };

            gridReference.RowSpacing = 0;
            gridReference.HorizontalOptions = LayoutOptions.Center;

            closeBoxImageReference = new CloseBoxImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorClose);

            closeBoxImageReference.WidthRequest = WidthClose;
            closeBoxImageReference.HeightRequest = HeightClose;
            closeBoxImageReference.HorizontalOptions = LayoutOptions.End;

            closeBoxImageReference.GestureRecognizers.Add(GetVivacityIncrease());

            stackClose = new StackLayout();

            stackClose.Children.Add(closeBoxImageReference);
            stackClose.GestureRecognizers.Add(GetVivacityIncrease());

            Grid.SetRow(stackClose, 0);
            Grid.SetColumn(stackClose, 0);

            gridReference.Children.Add(stackClose);

            Grid.SetRow(frameReference, 1);
            Grid.SetColumn(frameReference, 0);
            gridReference.Children.Add(frameReference);

            Children.Add(gridReference);
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
                if (child.GetType() == typeof(ContentBox))
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
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + currentVivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
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
                    await closeBoxImageReference.ScaleTo(GetDepthIncrease(currentDepth), 100, Easing.Linear);
                    await closeBoxImageReference.ScaleTo(1, 100, Easing.Linear);

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
                    await closeBoxImageReference.ScaleTo(GetDepthDecrease(currentDepth), 100, Easing.Linear);
                    await closeBoxImageReference.ScaleTo(1, 100, Easing.Linear);

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
                    await closeBoxImageReference.TranslateTo(0, GetDepthJump(currentDepth), 100, Easing.Linear);
                    await closeBoxImageReference.TranslateTo(0, 0, 100, Easing.Linear);

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
            closeBoxImageReference.GestureRecognizers.Clear();
            stackClose.GestureRecognizers.Clear();

            closeBoxImageReference.GestureRecognizers.Add(GetVivacity());
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
                return currentColorClose;
            }
            set
            {
                currentColorClose = value;
                ColorClosePropertyChanged(currentColorClose);
            }
        }

        private void ColorClosePropertyChanged(ColorUI newValue)
        {
            closeBoxImageReference.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", newValue);
        }

        /// <summary>
        /// Set ColorUI
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
                ColorUIPropertyChanged(value);
            }
        }

        private void ColorUIPropertyChanged(ColorUI newValue)
        {
            if (frameReference != null)
            {
                frameReference.BackgroundColor = GetColorFromColorUI(newValue);
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
                return currentBorderColor;
            }
            set
            {
                currentBorderColor = value;
                BorderColorPropertyChanged(value);
            }
        }

        private void BorderColorPropertyChanged(ColorUI newValue)
        {
            if (frameReference != null)
            {
                frameReference.BorderColor = GetColorFromColorUI(newValue);
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
                return currentDesignType;
            }
            set
            {
                currentDesignType = value;
                DesignTypePropertyChanged();
            }
        }

        private void DesignTypePropertyChanged()
        {
            closeBoxImageReference.ChangeDesignType("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentDesignType);
        }

        private Color GetColorFromColorUI(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Color.FromHex("#000000");
                case ColorUI.Blue:
                    return Color.FromHex("#0000FF");
                case ColorUI.Gray:
                    return Color.FromHex("#808080");
                case ColorUI.Green:
                    return Color.FromHex("#008000");
                case ColorUI.Red:
                    return Color.FromHex("#FF0000");
                case ColorUI.Yellow:
                    return Color.FromHex("#FFFF00");
                case ColorUI.BlueLight:
                    return Color.FromHex("#5599FF");
                case ColorUI.GreenLight:
                    return Color.FromHex("#00FF00");
                case ColorUI.YellowLight:
                    return Color.FromHex("#FFEEAA");
                case ColorUI.White:
                    return Color.FromHex("#FFFFFF");
                case ColorUI.Pink:
                    return Color.FromHex("#FF00FF");
                case ColorUI.Orange:
                    return Color.FromHex("#FF6600");
                case ColorUI.Brown:
                    return Color.FromHex("#803300");
                case ColorUI.Purple:
                    return Color.FromHex("#800080");
                case ColorUI.Turquoise:
                    return Color.FromHex("#008080");
                case ColorUI.PinkLight:
                    return Color.FromHex("#FFAACC");
                case ColorUI.BlueSky:
                    return Color.FromHex("#5599FF");
                case ColorUI.GrayLight:
                    return Color.FromHex("#CCCCCC");
                case ColorUI.RedLight:
                    return Color.FromHex("#FF8080");
                case ColorUI.OrangeLight:
                    return Color.FromHex("#FFB380");
                case ColorUI.YellowDark:
                    return Color.FromHex("#FFCC00");
                case ColorUI.GreenDark:
                    return Color.FromHex("#225500");
                case ColorUI.BlueDark:
                    return Color.FromHex("#002255");
                case ColorUI.Oliva:
                    return Color.FromHex("#808000");
                case ColorUI.Aqua:
                    return Color.FromHex("#00FFFF");
                case ColorUI.Tan:
                    return Color.FromHex("#AC9D93");
                case ColorUI.GreenDarkness:
                    return Color.FromHex("#002200");
                case ColorUI.BlueViolet:
                    return Color.FromHex("#8A2BE2");
                case ColorUI.Transparent:
                    return Color.Transparent;
                default:
                    return Color.FromHex("#CCCCCC");
            }
        }

        /// <summary>
        /// Enter the Width.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(FlyingBoxContent),
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
            FlyingBoxContent flyingBoxContent = (FlyingBoxContent)bindable;
            double copyWidth = (double)newValue;

            if (flyingBoxContent.frameReference != null)
            {
                flyingBoxContent.frameReference.WidthRequest = copyWidth;
                flyingBoxContent.dataItems.WidthRequest = copyWidth;
                flyingBoxContent.WidthRequest = copyWidth;
                flyingBoxContent.gridReference.ColumnDefinitions[0].Width = copyWidth;
            }
        }

        /// <summary>
        /// Enter the Height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(FlyingBoxContent),
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
            FlyingBoxContent flyingBoxContent = (FlyingBoxContent)bindable;
            double copyHeight = (double)newValue;

            if (flyingBoxContent.frameReference != null)
            {
                flyingBoxContent.frameReference.HeightRequest = copyHeight;
            }
        }

        /// <summary>
        /// Enter the Width Close Image.
        /// </summary>
        public static readonly BindableProperty WidthCloseProperty = BindableProperty.Create(
            propertyName: nameof(WidthClose),
            returnType: typeof(double),
            declaringType: typeof(FlyingBoxContent),
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
            FlyingBoxContent flyingBoxContent = (FlyingBoxContent)bindable;
            double copyWidthClose = (double)newValue;

            if (flyingBoxContent.closeBoxImageReference != null)
            {
                flyingBoxContent.closeBoxImageReference.WidthRequest = copyWidthClose;
            }
        }

        /// <summary>
        /// Enter the Height Close Image.
        /// </summary>
        public static readonly BindableProperty HeightCloseProperty = BindableProperty.Create(
            propertyName: nameof(HeightClose),
            returnType: typeof(double),
            declaringType: typeof(FlyingBoxContent),
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
            FlyingBoxContent flyingBoxContent = (FlyingBoxContent)bindable;
            double copyHeightClose = (double)newValue;

            if (flyingBoxContent.closeBoxImageReference != null)
            {
                flyingBoxContent.closeBoxImageReference.HeightRequest = copyHeightClose;
            }
        }
    }
}
