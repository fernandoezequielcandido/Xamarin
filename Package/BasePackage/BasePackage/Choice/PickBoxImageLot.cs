using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Choice
    {
        /// <summary>
        /// Class PickBoxImageMultiple
        /// </summary>
        public class PickBoxImageLot : Frame
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
            private PickImageLot choiceImageMultiple;
            private PickImageInternalChoice imageInternal;

            private ColorUI colorUIChosen = ColorUI.Blue;
            private ColorUI borderColorChosen = ColorUI.Black;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Constructor of ChoiceBoxImageMultiple
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="choiceMultiple"></param>
            /// <param name="value_"></param>
            /// <param name="imgSource"></param>
            /// <param name="index"></param>
            /// <param name="vivacity"></param>
            /// <param name="depth"></param>
            /// <param name="vivacitySpeed"></param>
            public PickBoxImageLot(string hash, PickImageLot choiceMultiple, string value_, string imgSource, int index, Vivacity vivacity, Depth depth, VivacitySpeed vivacitySpeed) : base()
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Invalid Hash");
                }

                this.ValueBindable = value_;
                this.Index = index;

                choiceImageMultiple = choiceMultiple;

                InitializeComponents();

                SetValue(ImageProperty, imgSource);

                Vivacity = vivacity;
                Depth = depth;
                VivacitySpeed = vivacitySpeed;

                VivacityPropertyChanged();

            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="key"></param>
            /// <param name="vivacity"></param>
            /// <param name="depth"></param>
            /// <param name="vivacitySpeed"></param>
            public void ChangeVivacity(string key, Vivacity vivacity, Depth depth, VivacitySpeed vivacitySpeed)
            {
                if (key == "__Laavor*+-")
                {
                    Vivacity = vivacity;
                    Depth = depth;
                    VivacitySpeed = vivacitySpeed;

                    if (!IsChosen)
                    {
                        VivacityPropertyChanged();
                    }
                }
            }

            private TapGestureRecognizer GetTouch()
            {
                var touch = new TapGestureRecognizer();
                touch.Tapped += Touch_Tapped;
                return touch;
            }

            private void Touch_Tapped(object sender, EventArgs e)
            {
                ChosenImage(sender, e);
            }

            private void InitializeComponents()
            {
                InitAll();
            }

            private void InitAll()
            {
                imageInternal = new PickImageInternalChoice();

                imageInternal.IsChosen = false;
                imageInternal.WidthRequest = WidthImage;
                imageInternal.HeightRequest = HeightImage;
                imageInternal.MinimumWidthRequest = WidthImage;
                imageInternal.MinimumHeightRequest = HeightImage;
                imageInternal.Source = Image;
                imageInternal.VerticalOptions = LayoutOptions.FillAndExpand;
                imageInternal.HorizontalOptions = LayoutOptions.FillAndExpand;
                imageInternal.Aspect = Aspect.Fill;
                imageInternal.Margin = new Thickness(-15, -15, -15, -15);

                stack = new StackLayout();
                stack.Spacing = 0;
                               
                stack.Children.Add(imageInternal);

                this.Content = stack;

                this.HorizontalOptions = LayoutOptions.Center;
                this.VerticalOptions = LayoutOptions.Center;
                this.BackgroundColor = Color.Transparent;
                this.HasShadow = true;
                this.BorderColor = Color.Transparent;

                imageInternal.Touched += ChosenImage;
            }

            private void ChosenImage(object sender, EventArgs e)
            {
                PickImageInternalChoice choiceImageItem = null;
                if (sender.GetType() == typeof(PickImageInternalChoice))
                {
                    choiceImageItem = (PickImageInternalChoice)sender;
                }
                else if (sender.GetType() == typeof(PickBoxImageLot))
                {
                    choiceImageItem = (sender as PickBoxImageLot).imageInternal;
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
                        this.BorderColor = Colors.Get(choiceImageMultiple.BorderColorChosen);
                        this.BackgroundColor = Colors.Get(choiceImageMultiple.ColorUIChosen);

                        choiceImageItem.IsChosen = true;

                        callChosen = false;
                        this.IsChosen = true;
                        callChosen = true;
                    }

                    choiceImageMultiple.UpdateData(Index, "__Laavor*+-", choiceImageItem.IsChosen);
                }
            }

            /// <summary>
            /// Enter the Image Source of button.
            ///</summary>
            public static readonly BindableProperty ImageProperty = BindableProperty.Create(
                propertyName: nameof(Image),
                returnType: typeof(string),
                declaringType: typeof(PickBoxImageLot),
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
                PickBoxImageLot boxImageMultiple = (PickBoxImageLot)bindable;
                string copyImage = (string)newValue;

                if (boxImageMultiple.imageInternal != null)
                {
                    boxImageMultiple.imageInternal.Source = copyImage;
                }
            }

            /// <summary>
            /// Enter the IsChosen.
            /// </summary>
            public static readonly BindableProperty IsChosenProperty = BindableProperty.Create(
                propertyName: nameof(IsChosen),
                returnType: typeof(bool),
                declaringType: typeof(PickBoxImageLot),
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
                PickBoxImageLot boxImageMultiple = (PickBoxImageLot)bindable;
                bool copyIsChosen = (bool)newValue;
                if (boxImageMultiple.callChosen)
                {
                    boxImageMultiple.ChosenImage(boxImageMultiple, EventArgs.Empty);
                }
            }

            /// <summary>
            /// Set if is ColorUIChosen
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorUIChosen
            {
                get
                {
                    return colorUIChosen;
                }
                set
                {
                    colorUIChosen = value;
                    ColorUIChosenPropertyChanged();
                }
            }

            private void ColorUIChosenPropertyChanged()
            {
                if (!IsChosen)
                {
                    this.BackgroundColor = Colors.Get(colorUIChosen);
                }
            }

            /// <summary>
            /// Set if is BorderColorChosen
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColorChosen
            {
                get
                {
                    return borderColorChosen;
                }
                set
                {
                    borderColorChosen = value;
                    BorderColorChosenPropertyChanged();
                }
            }

            private void BorderColorChosenPropertyChanged()
            {
                if (IsChosen)
                {
                    this.BorderColor = Colors.Get(borderColorChosen);
                }
            }

            /// <summary>
            /// Enter the WidthImage.
            /// </summary>
            public static readonly BindableProperty WidthImageProperty = BindableProperty.Create(
                propertyName: nameof(WidthImage),
                returnType: typeof(double),
                declaringType: typeof(PickBoxImageLot),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthImagePropertyChanged);

            /// <summary>
            /// Enter the WidthImage.
            /// </summary>
            public double WidthImage
            {
                get
                {
                    return (double)GetValue(WidthImageProperty);
                }
                set
                {
                    SetValue(WidthImageProperty, value);
                }
            }

            private static void WidthImagePropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickBoxImageLot choiceBoxImageMultiple = (PickBoxImageLot)bindable;
                double width = (double)newValue;
                
                choiceBoxImageMultiple.WidthRequest = width;
                choiceBoxImageMultiple.MinimumWidthRequest = width;
            }

            /// <summary>
            /// Enter the HeightImage.
            /// </summary>
            public static readonly BindableProperty HeightImageProperty = BindableProperty.Create(
                propertyName: nameof(HeightImage),
                returnType: typeof(double),
                declaringType: typeof(PickImageLot),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: HeightImagePropertyChanged);

            /// <summary>
            /// Enter the HeightImage.
            /// </summary>
            public double HeightImage
            {
                get
                {
                    return (double)GetValue(HeightImageProperty);
                }
                set
                {
                    SetValue(HeightImageProperty, value);
                }
            }

            private static void HeightImagePropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickBoxImageLot choiceBoxImageMultiple = (PickBoxImageLot)bindable;
                double height = (double)newValue;

                choiceBoxImageMultiple.HeightRequest = height;
                choiceBoxImageMultiple.MinimumHeightRequest = height;
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
                if (imageInternal != null)
                {
                    this.GestureRecognizers.Clear();
                    imageInternal.GestureRecognizers.Clear();

                    if (vivacity != Vivacity.None)
                    {
                        if (this.GestureRecognizers.Count == 0)
                        {
                            this.GestureRecognizers.Add(GetVivacity());
                        }

                        if (imageInternal.GestureRecognizers.Count == 0)
                        {
                            imageInternal.GestureRecognizers.Add(GetVivacity());
                        }
                    }

                    if(vivacity == Vivacity.None)
                    {
                        if (this.GestureRecognizers.Count == 0)
                        {
                            this.GestureRecognizers.Add(GetTouch());
                        }

                        if (imageInternal.GestureRecognizers.Count == 0)
                        {
                            imageInternal.GestureRecognizers.Add(GetTouch());
                        }
                    }
                    else
                    {
                        if (this.GestureRecognizers.Count == 1)
                        {
                            this.GestureRecognizers.Add(GetTouch());
                        }

                        if (imageInternal.GestureRecognizers.Count == 1)
                        {
                            imageInternal.GestureRecognizers.Add(GetTouch());
                        }
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
                        await this.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await this.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        await this.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await this.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        await this.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await this.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
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
                        await this.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await this.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await this.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await this.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await this.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await this.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        await this.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await this.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await imageInternal.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
