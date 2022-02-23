using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorChoiceImage
{
    /// <summary>
    /// Class BoxImageMultiple
    /// </summary>
    public class BoxImageMultiple : Frame
    {
        private bool callChosen = true;

        /// <summary>
        /// Index of BoxImage 
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// ValueBindable
        /// </summary>
        public string ValueBindable { get; private set; }

        private StackLayout stack = new StackLayout();
        private ChoiceImageMultiple choiceImageMultiple;
        private ImageInternalChoice imageInternalReference;

        private Color currentBorderColorChosen = Color.Black;
        private Color currentBackgroundColorChosen = Color.Gold;

        private Vivacity vivacity = Vivacity.Decrease;
        private Depth depth = Depth.LessMedium;
        private VivacitySpeed vivacitySpeed = VivacitySpeed.Fast;

        /// <summary>
        /// Constructor of BoxImage
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="choiceMultiple"></param>
        /// <param name="value_"></param>
        /// <param name="imgSource"></param>
        /// <param name="index"></param>
        /// <param name="vivacity_"></param>
        /// <param name="depth_"></param>
        /// <param name="vivacitySpeed_"></param>
        public BoxImageMultiple(string hash, ChoiceImageMultiple choiceMultiple, string value_, string imgSource, int index, Vivacity vivacity_, Depth depth_, VivacitySpeed vivacitySpeed_) : base()
        {
            if (hash != "__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl")
            {
                throw new Exception("Invalid Hash");
            }

            this.ValueBindable = value_;
            this.Index = index;

            choiceImageMultiple = choiceMultiple;

            InitializeComponents();

            SetValue(ImageProperty, imgSource);

            vivacity = vivacity_;
            depth = depth_;
            vivacitySpeed = vivacitySpeed_;

            if (vivacity.ToString() != "None")
            {
                this.GestureRecognizers.Add(GetVivacity());
            }

            this.GestureRecognizers.Add(getClick());
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="key"></param>
        /// <param name="vivacity_"></param>
        /// <param name="depth_"></param>
        /// <param name="vivacitySpeed_"></param>
        public void ChangeVivacity(string key, Vivacity vivacity_, Depth depth_, VivacitySpeed vivacitySpeed_)
        {
            if (key == "__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl")
            {
                vivacity = vivacity_;
                depth = depth_;
                vivacitySpeed = vivacitySpeed_;

                if (!IsChosen)
                {
                    if (vivacity.ToString() != "None")
                    {
                        this.GestureRecognizers.Add(GetVivacity());
                    }
                    else
                    {
                        this.GestureRecognizers.Clear();
                    }

                    this.GestureRecognizers.Add(getClick());
                }
            }
        }

        private TapGestureRecognizer getClick()
        {
            var click = new TapGestureRecognizer();
            click.Tapped += Click_Tapped;
            return click;
        }

        private void Click_Tapped(object sender, EventArgs e)
        {
            ChosenImage(sender, e);
        }

        private void InitializeComponents()
        {
            InitAll();
        }

        private void InitAll()
        {
            imageInternalReference = new ImageInternalChoice();

            imageInternalReference.IsChosen = false;
            imageInternalReference.WidthRequest = Width;
            imageInternalReference.HeightRequest = Height;
            imageInternalReference.MinimumWidthRequest = Width;
            imageInternalReference.MinimumHeightRequest = Height;
            imageInternalReference.Source = Image;
            imageInternalReference.VerticalOptions = LayoutOptions.FillAndExpand;
            imageInternalReference.HorizontalOptions = LayoutOptions.FillAndExpand;
            imageInternalReference.Aspect = Aspect.Fill;
            imageInternalReference.Margin = new Thickness(-15, -15, -15, -15);

            stack = new StackLayout();
            stack.HeightRequest = Height;
            stack.WidthRequest = Width;

            stack.Children.Add(imageInternalReference);

            this.Content = stack;

            this.WidthRequest = Width;
            this.HeightRequest = Height;
            this.HorizontalOptions = LayoutOptions.Center;
            this.VerticalOptions = LayoutOptions.Center;
            this.BackgroundColor = Color.Transparent;
            this.HasShadow = true;
            this.BorderColor = Color.Transparent;

            imageInternalReference.Clicked += ChosenImage;
        }

        private void ChosenImage(object sender, EventArgs e)
        {
            ImageInternalChoice choiceImageItem = null;
            if (sender.GetType() == typeof(ImageInternalChoice))
            {
                choiceImageItem = (ImageInternalChoice)sender;
            }
            else if (sender.GetType() == typeof(BoxImageMultiple))
            {
                choiceImageItem = (sender as BoxImageMultiple).imageInternalReference;
            }

            if (choiceImageItem != null)
            {
                if (choiceImageItem.IsChosen)
                {
                    this.BorderColor = Color.Transparent;
                    this.BackgroundColor = Color.Transparent;

                    choiceImageItem.IsChosen = false;

                    callChosen = false;
                    this.IsChosen = false;
                    callChosen = true;
                }
                else
                {
                    this.BorderColor = choiceImageMultiple.BorderColorChosen;
                    this.BackgroundColor = choiceImageMultiple.BackgroundColorChosen;

                    choiceImageItem.IsChosen = true;

                    callChosen = false;
                    this.IsChosen = true;
                    callChosen = true;
                }

                choiceImageMultiple.UpdateData(Index, "amebaprotozoarioindexDD1458**", choiceImageItem.IsChosen);

            }
        }

        /// <summary>
        /// Enter the Image Source of button.
        ///</summary>
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            propertyName: nameof(Image),
            returnType: typeof(string),
            declaringType: typeof(BoxImageMultiple),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImagePropertyChanged);

        /// <summary>
        /// Enter the Image Source of button.
        /// </summary>
        public string Image
        {
            get
            {
                return (string)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
            }
        }

        private static void ImagePropertyChanged(object bindable, object oldValue, object newValue)
        {
            BoxImageMultiple boxImageMultiple = (BoxImageMultiple)bindable;
            string copyImage = (string)newValue;
            boxImageMultiple.imageInternalReference.Source = copyImage;
        }

        /// <summary>
        /// Enter the height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(BoxImageMultiple),
            defaultValue: 40.0,
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
            BoxImageMultiple boxImageMultiple = (BoxImageMultiple)bindable;
            double imageHeight = (double)newValue;
            boxImageMultiple.imageInternalReference.HeightRequest = imageHeight;
            boxImageMultiple.imageInternalReference.MinimumHeightRequest = imageHeight;
            boxImageMultiple.stack.HeightRequest = imageHeight;
            boxImageMultiple.HeightRequest = imageHeight;
        }

        /// <summary>
        /// Enter the width.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(BoxImageMultiple),
            defaultValue: 80.0,
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
            BoxImageMultiple boxImageMultiple = (BoxImageMultiple)bindable;
            double imageWidth = (double)newValue;
            boxImageMultiple.imageInternalReference.WidthRequest = imageWidth;
            boxImageMultiple.imageInternalReference.MinimumWidthRequest = imageWidth;
            boxImageMultiple.stack.WidthRequest = imageWidth;
            boxImageMultiple.WidthRequest = imageWidth;
        }

        /// <summary>
        /// Enter the IsChosen.
        /// </summary>
        public static readonly BindableProperty IsChosenProperty = BindableProperty.Create(
            propertyName: nameof(IsChosen),
            returnType: typeof(bool),
            declaringType: typeof(BoxImageMultiple),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: IsChosenPropertyChanged);

        /// <summary>
        /// Enter the IsChosen.
        /// </summary>
        public bool IsChosen
        {
            get
            {
                return (bool)GetValue(IsChosenProperty);
            }
            set
            {
                SetValue(IsChosenProperty, value);
            }
        }

        private static void IsChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            BoxImageMultiple boxImageMultiple = (BoxImageMultiple)bindable;
            bool copyIsChosen = (bool)newValue;
            if (boxImageMultiple.callChosen)
            {
                boxImageMultiple.ChosenImage(boxImageMultiple, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Enter the BackgroundColorChosen.
        /// </summary>
        public static readonly BindableProperty BackgroundColorChosenProperty = BindableProperty.Create(
            propertyName: nameof(BackgroundColorChosen),
            returnType: typeof(Color),
            declaringType: typeof(BoxImageMultiple),
            defaultValue: Color.Gold,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BackgroundColorChosenPropertyChanged);

        /// <summary>
        /// Enter the BackgroundColorChosen.
        /// </summary>
        public Color BackgroundColorChosen
        {
            get
            {
                return (Color)GetValue(BackgroundColorChosenProperty);
            }
            set
            {
                SetValue(BackgroundColorChosenProperty, value);
            }
        }

        private static void BackgroundColorChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            BoxImageMultiple boxImageMultiple = (BoxImageMultiple)bindable;
            Color copyColor = (Color)newValue;

            if (boxImageMultiple.IsChosen)
            {
                boxImageMultiple.BackgroundColor = copyColor;
            }
        }

        /// <summary>
        /// Enter the BorderColorChosen.
        /// </summary>
        [Bindable(true)]
        public Color BorderColorChosen
        {
            get
            {
                return currentBorderColorChosen;
            }
            set
            {
                BorderColorChosenPropertyChanged(this, currentBorderColorChosen, value);
                currentBorderColorChosen = value;
            }
        }

        private static void BorderColorChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            BoxImageMultiple boxImageMultiple = (BoxImageMultiple)bindable;
            Color copyColor = (Color)newValue;

            if (boxImageMultiple.IsChosen)
            {
                boxImageMultiple.BorderColor = copyColor;
            }
        }

        private TapGestureRecognizer GetVivacity()
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            TapGestureRecognizer touchAnimation = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
            return touchAnimation;
        }

        private TapGestureRecognizer GetVivacityDecrease()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await this.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                    await this.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                }
                catch { }
            };

            return animationTap;
        }

        private double GetDepthDecrease(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 0.80;
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
                    await this.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                    await this.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityJump()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await this.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                    await this.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                }
                catch { }
            };

            return vivacityTap;
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

        private TapGestureRecognizer GetVivacityRotation()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await this.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                    await this.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
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
                return 90;
            }
            else if (depth == Depth.Medium)
            {
                return 140;
            }
            else
            {
                return 210;
            }
        }

        private TapGestureRecognizer GetVivacityDown()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await this.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                    await this.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                    await this.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                    await this.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                    await this.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                    await this.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
