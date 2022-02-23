using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace LaavorChoiceImage
{
    /// <summary>
    /// Clas BoxImage
    /// </summary>
    public class BoxImage : Frame
    {
        private bool callChosen = true;

        /// <summary>
        /// Index of BoxImage 
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// ValueBindable
        /// </summary>
        public string Value { get; private set; }

        private StackLayout stack = new StackLayout();
        private ChoiceImage choiceImage;
        private ImageInternalChoice imageInternalReference;

        private Color currentBorderColorChosen = Color.Black;
        private Color currentBackgroundColorChosen = Color.Gold;
        private int currentBorderRadius = 0;

        private Vivacity vivacity = Vivacity.Decrease;
        private Depth depth = Depth.LessMedium;
        private VivacitySpeed vivacitySpeed = VivacitySpeed.Fast;

        /// <summary>
        /// Constructor of BoxImage
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="choice"></param>
        /// <param name="value_"></param>
        /// <param name="imgSource"></param>
        /// <param name="index"></param>
        /// <param name="vivacity_"></param>
        /// <param name="depth_"></param>
        /// <param name="vivacitySpeed_"></param>
        public BoxImage(string hash, ChoiceImage choice, string value_, string imgSource, int index, Vivacity vivacity_, Depth depth_, VivacitySpeed vivacitySpeed_) : base()
        {
            if (hash != "__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl")
            {
                throw new Exception("Invalid Hash");
            }

            this.Value = value_;
            this.Index = index;

            choiceImage = choice;

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
                    if(vivacity.ToString() != "None")
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
            imageInternalReference.MinimumWidthRequest = Width;
            imageInternalReference.HeightRequest = Height;
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
            this.CornerRadius = currentBorderRadius;

            imageInternalReference.Clicked += ChosenImage;
        }

        private void ChosenImage(object sender, EventArgs e)
        {
            ImageInternalChoice choiceImageItem = null;
            if (sender.GetType() == typeof(ImageInternalChoice))
            {
                choiceImageItem = (ImageInternalChoice)sender;
            }
            else if (sender.GetType() == typeof(BoxImage))
            {
                choiceImageItem = (sender as BoxImage).imageInternalReference;
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

                    this.GestureRecognizers.Clear();

                    if (vivacity.ToString() != "None")
                    {
                        this.GestureRecognizers.Add(GetVivacity());
                    }

                    this.GestureRecognizers.Add(getClick());

                    choiceImageItem.Clicked -= ChosenImage;
                    choiceImageItem.Clicked += ChosenImage;
                }
                else
                {
                    this.BorderColor = choiceImage.BorderColorChosen;
                    this.BackgroundColor = choiceImage.BackgroundColorChosen;

                    choiceImageItem.IsChosen = true;

                    callChosen = false;
                    this.IsChosen = true;
                    callChosen = true;

                    this.GestureRecognizers.Clear();
                    choiceImageItem.Clicked -= ChosenImage;

                    ChosenAnotherImage();
                }

            }
        }

        private void ChosenAnotherImage()
        {
            if (imageInternalReference != null)
            {
                StackLayout stackChoiceItems = choiceImage.GetData("Asaph_77_laavor_lincohl_il71_++*e*e-");
                for (int iItem = 0; iItem < stackChoiceItems.Children.Count; iItem++)
                {
                    BoxImage item = (BoxImage)stackChoiceItems.Children[iItem];
                    if (item.Index != this.Index)
                    {
                        item.IsChosen = false;
                    }
                    else
                    {
                        choiceImage.UpdateData(item.Value, item.Image, item.Index, "amebaprotozoarioindexDD1458**");
                    }
                }
            }
        }

        /// <summary>
        /// Enter the Image Source of button.
        ///</summary>
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            propertyName: nameof(Image),
            returnType: typeof(string),
            declaringType: typeof(BoxImage),
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
            BoxImage boxImage = (BoxImage)bindable;
            string copyImage = (string)newValue;
            boxImage.imageInternalReference.Source = copyImage;
        }

        /// <summary>
        /// Enter the height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(BoxImage),
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
            BoxImage boxImage = (BoxImage)bindable;
            double imageHeight = (double)newValue;
            boxImage.imageInternalReference.HeightRequest = imageHeight;
            boxImage.stack.HeightRequest = imageHeight;
            boxImage.HeightRequest = imageHeight;
        }

        /// <summary>
        /// Enter the width.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(BoxImage),
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
            BoxImage boxImage = (BoxImage)bindable;
            double imageWidth = (double)newValue;
            boxImage.imageInternalReference.WidthRequest = imageWidth;
            boxImage.stack.WidthRequest = imageWidth;
            boxImage.WidthRequest = imageWidth;
        }

        /// <summary>
        /// Enter the IsChosen.
        /// </summary>
        public static readonly BindableProperty IsChosenProperty = BindableProperty.Create(
            propertyName: nameof(IsChosen),
            returnType: typeof(bool),
            declaringType: typeof(BoxImage),
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
            BoxImage boxImage = (BoxImage)bindable;
            bool copyIsChosen = (bool)newValue;
            if (boxImage.callChosen)
            {
                boxImage.ChosenImage(boxImage, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Enter the BackgroundColorChosen.
        /// </summary>
        public static readonly BindableProperty BackgroundColorChosenProperty = BindableProperty.Create(
            propertyName: nameof(BackgroundColorChosen),
            returnType: typeof(Color),
            declaringType: typeof(BoxImage),
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
            BoxImage boxImage = (BoxImage)bindable;
            Color copyColor = (Color)newValue;

            if (boxImage.IsChosen)
            {
                boxImage.BackgroundColor = copyColor;
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
            BoxImage boxImage = (BoxImage)bindable;
            Color copyColor = (Color)newValue;

            if (boxImage.IsChosen)
            {
                boxImage.BorderColor = copyColor;
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
