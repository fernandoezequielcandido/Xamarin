using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Choice
    {
        /// <summary>
        /// PickImageSwaptLot
        /// </summary>
        public class PickImageSwapLot : StackLayout
        {
            /// <summary>
            /// Returns the List the chosen items.
            /// </summary>
            public List<PickChosenItem> ItemsChosen { get; private set; }

            private List<PickChosenItem> allItemsChosen;

            /// <summary>
            /// Call when image is Chosen
            /// </summary>
            public event EventHandler Chosen;

            private ScrollView scroll;

            /// <summary>
            /// Internal use.
            /// </summary>
            public StackLayout dataItems;

            private int currentIndex;

            private IEnumerable items = null;

            private const double spaceDecrease = 0;

            private ChoiceOrientation choiceOrientation = ChoiceOrientation.Horizontal;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Constructor of Choice Image Shift Multiple
            /// </summary>
            public PickImageSwapLot() : base()
            {
                InitAll();
            }

            private void InitAll()
            {
                currentIndex = 0;

                this.Children.Clear();
                this.HorizontalOptions = LayoutOptions.Center;
                this.Spacing = 0;

                ItemsChosen = new List<PickChosenItem>();
                allItemsChosen = new List<PickChosenItem>();

                dataItems = new StackLayout();
                dataItems.Spacing = 0;

                scroll = new ScrollView();
                scroll.Content = dataItems;

                if (ChoiceOrientation == ChoiceOrientation.Horizontal)
                {
                    scroll.Orientation = ScrollOrientation.Horizontal;
                    dataItems.Orientation = StackOrientation.Horizontal;
                    base.Orientation = StackOrientation.Horizontal;
                }
                else
                {
                    scroll.Orientation = ScrollOrientation.Vertical;
                    dataItems.Orientation = StackOrientation.Vertical;
                    base.Orientation = StackOrientation.Vertical;
                }

                scroll.HorizontalOptions = LayoutOptions.Center;
                scroll.VerticalOptions = LayoutOptions.Center;

                this.Children.Add(scroll);
            }

            private void ChangeOrientation(ChoiceOrientation o)
            {
                if (o == ChoiceOrientation.Horizontal)
                {
                    base.Orientation = StackOrientation.Horizontal;
                }
                else
                {
                    base.Orientation = StackOrientation.Vertical;
                }
            }

            /// <summary>
            /// Set ChoiceOrientation
            /// </summary>
            [Bindable(true)]
            public ChoiceOrientation ChoiceOrientation
            {
                get
                {
                    return choiceOrientation;
                }
                set
                {
                    choiceOrientation = value;
                    ChoiceOrientationPropertyChanged();
                }
            }

            private void ChoiceOrientationPropertyChanged()
            {
                if (scroll != null && dataItems != null)
                {
                    if (choiceOrientation == Laavor.ChoiceOrientation.Horizontal)
                    {
                        scroll.Orientation = ScrollOrientation.Horizontal;
                        dataItems.Orientation = StackOrientation.Horizontal;
                        scroll.WidthRequest = Width;
                        scroll.HeightRequest = -1;
                    }
                    else
                    {
                        scroll.Orientation = ScrollOrientation.Vertical;
                        dataItems.Orientation = StackOrientation.Vertical;
                        scroll.HeightRequest = Height;
                        scroll.WidthRequest = -1;
                    }
                }

                ChangeOrientation(choiceOrientation);
            }

            /// <summary>
            /// Enter ListItems(Data items).
            /// </summary>
            public static readonly BindableProperty ListItemsProperty = BindableProperty.Create(
                propertyName: nameof(ListItems),
                returnType: typeof(IEnumerable),
                declaringType: typeof(PickImageSwapLot),
                defaultBindingMode: BindingMode.OneWay,
                defaultValue: null,
                propertyChanged: ListItemsPropertyChanged);

            /// <summary>
            /// Enter ListItems(Data items).
            /// </summary>
            public IEnumerable ListItems
            {
                get
                {
                    return (IEnumerable)GetValue(ListItemsProperty);
                }
                set
                {
                    SetValue(ListItemsProperty, value);
                }
            }

            private static void ListItemsPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickImageSwapLot multiple = (PickImageSwapLot)bindable;
                multiple.items = (IEnumerable)newValue;
                multiple.InitAllBindable();
            }

            /// <summary>
            /// Enter the ValueField, only when using list.
            /// </summary>
            public static readonly BindableProperty ValueFieldProperty = BindableProperty.Create(
                propertyName: nameof(ValueField),
                returnType: typeof(string),
                declaringType: typeof(PickImageSwapLot),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ValueFieldPropertyChanged);

            /// <summary>
            /// Enter the ValueField, only when using list.
            /// </summary>
            public string ValueField
            {
                get
                {
                    return (string)GetValue(ValueFieldProperty);
                }
                set
                {
                    SetValue(ValueFieldProperty, value);
                }
            }

            private static void ValueFieldPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickImageSwapLot multiple = (PickImageSwapLot)bindable;
                multiple.InitAllBindable();
            }

            /// <summary>
            /// Enter the ImageUnChosenField, only when using list.
            /// </summary>
            public static readonly BindableProperty ImageUnChosenFieldProperty = BindableProperty.Create(
                propertyName: nameof(ImageUnChosenField),
                returnType: typeof(string),
                declaringType: typeof(PickImageSwapLot),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImageUnChosenFieldPropertyChanged);

            /// <summary>
            /// Enter the ImageUnChosenField, only when using list.
            /// </summary>
            public string ImageUnChosenField
            {
                get
                {
                    return (string)GetValue(ImageUnChosenFieldProperty);
                }
                set
                {
                    SetValue(ImageUnChosenFieldProperty, value);
                }
            }

            private static void ImageUnChosenFieldPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickImageSwapLot multiple = (PickImageSwapLot)bindable;
                multiple.InitAllBindable();
            }

            /// <summary>
            /// Enter the ImageChosenField, only when using list.
            /// </summary>
            public static readonly BindableProperty ImageChosenFieldProperty = BindableProperty.Create(
                propertyName: nameof(ImageChosenField),
                returnType: typeof(string),
                declaringType: typeof(PickImageSwapLot),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImageChosenFieldPropertyChanged);

            /// <summary>
            /// Enter the ImageChosenField, only when using list.
            /// </summary>
            public string ImageChosenField
            {
                get
                {
                    return (string)GetValue(ImageChosenFieldProperty);
                }
                set
                {
                    SetValue(ImageChosenFieldProperty, value);
                }
            }

            private static void ImageChosenFieldPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickImageSwapLot multiple = (PickImageSwapLot)bindable;
                multiple.InitAllBindable();
            }

            /// <summary>
            /// Enter the Height.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(PickImageSwapLot),
                defaultValue: 25.0,
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
                PickImageSwapLot multiple = (PickImageSwapLot)bindable;
                double height = (double)newValue;

                if (multiple.scroll != null)
                {
                    if (multiple.ChoiceOrientation == ChoiceOrientation.Vertical)
                    {
                        multiple.scroll.HeightRequest = height;
                    }
                    else
                    {
                        multiple.scroll.WidthRequest = -1;
                    }
                }
            }

            /// <summary>
            /// Enter Widht.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(PickImageSwapLot),
                defaultValue: 80.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthPropertyChanged);

            /// <summary>
            /// Enter Widht.
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
                PickImageSwapLot multiple = (PickImageSwapLot)bindable;
                double width = (double)newValue;

                if (multiple.scroll != null)
                {
                    if (multiple.ChoiceOrientation == ChoiceOrientation.Horizontal)
                    {
                        multiple.scroll.WidthRequest = width;
                    }
                    else
                    {
                        multiple.scroll.HeightRequest = -1;
                    }
                }
            }

            /// <summary>
            /// Enter the HeightImage.
            /// </summary>
            public static readonly BindableProperty HeightImageProperty = BindableProperty.Create(
                propertyName: nameof(HeightImage),
                returnType: typeof(double),
                declaringType: typeof(PickImageSwapLot),
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
                PickImageSwapLot multiple = (PickImageSwapLot)bindable;
                double height = (double)newValue;

                if (multiple.dataItems != null)
                {
                    for (int iItem = 0; iItem < multiple.dataItems.Children.Count; iItem++)
                    {
                        if (multiple.dataItems.Children[iItem].GetType() == typeof(LaavorFormer))
                        {
                            LaavorFormer laavorFormer = (LaavorFormer)multiple.dataItems.Children[iItem];
                            if (laavorFormer.Children[0].GetType() == typeof(PickImageBase))
                            {
                                PickImageBase choiceImageBase = (PickImageBase)laavorFormer.Children[0];
                                choiceImageBase.HeightRequest = height;
                                choiceImageBase.MinimumHeightRequest = height;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the WidthImage.
            /// </summary>
            public static readonly BindableProperty WidthImageProperty = BindableProperty.Create(
                propertyName: nameof(WidthImage),
                returnType: typeof(double),
                declaringType: typeof(PickImageSwapLot),
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
                PickImageSwapLot multiple = (PickImageSwapLot)bindable;
                double width = (double)newValue;

                if (multiple.dataItems != null)
                {
                    for (int iItem = 0; iItem < multiple.dataItems.Children.Count; iItem++)
                    {
                        if (multiple.dataItems.Children[iItem].GetType() == typeof(LaavorFormer))
                        {
                            LaavorFormer laavorFormer = (LaavorFormer)multiple.dataItems.Children[iItem];
                            if (laavorFormer.Children[0].GetType() == typeof(PickImageBase))
                            {
                                PickImageBase choiceImageBase = (PickImageBase)laavorFormer.Children[0];
                                choiceImageBase.WidthRequest = width;
                                choiceImageBase.MinimumWidthRequest = width;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Property to inform SpaceBetween
            /// </summary>
            public static readonly BindableProperty SpaceBetweenProperty = BindableProperty.Create(
                     propertyName: nameof(SpaceBetween),
                     returnType: typeof(int),
                     declaringType: typeof(PickImageSwapLot),
                     defaultValue: 0,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: SpaceBetweenPropertyChanged);

            /// <summary>
            /// Property to inform SpaceBetween
            /// </summary>
            public int SpaceBetween
            {
                get
                {
                    return (int)GetValue(SpaceBetweenProperty);
                }
                set
                {
                    SetValue(SpaceBetweenProperty, value);
                }
            }

            private static void SpaceBetweenPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickImageSwapLot multiple = (PickImageSwapLot)bindable;
                int copyMargin = (int)newValue;

                if (multiple.dataItems != null)
                {
                    if (multiple.dataItems.Children.Count > 0)
                    {
                        multiple.dataItems.Children[multiple.dataItems.Children.Count - 1].Margin = new Thickness(0, 0, 0, 0);
                    }
                }

                for (int iItem = 1; iItem < multiple.Children.Count; iItem++)
                {
                    if (multiple.Children[0].GetType() == typeof(PickImageBase))
                    {
                        PickImageBase choiceImageBase = (PickImageBase)multiple.Children[0];
                        choiceImageBase.Margin = new Thickness(copyMargin, 0, 0, 0);
                    }
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
                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(PickImageBase))
                        {
                            PickImageBase choiceItem = (PickImageBase)dataItems.Children[iItem];

                            choiceItem.GestureRecognizers.Clear();

                            choiceItem.GestureRecognizers.Add(GetVivacity());
                            choiceItem.GestureRecognizers.Add(GetVivacity());

                            choiceItem.GestureRecognizers.Add(GetTouch());
                            choiceItem.GestureRecognizers.Add(GetTouch());

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

            private void InitAllBindable()
            {
                PickImageSwapLot multiple = this;

                if (multiple.ListItems != null && !string.IsNullOrEmpty(multiple.ImageUnChosenField) && !string.IsNullOrEmpty(multiple.ImageChosenField))
                {
                    dataItems.Children.Clear();
                    currentIndex = 0;

                    IEnumerator enumerator = multiple.ListItems.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        object obj = enumerator.Current;

                        string valueObj = "";
                        string sourceUnChosenObj = obj.GetType().GetProperty(multiple.ImageUnChosenField).GetValue(obj).ToString();
                        string sourceChosenObj = obj.GetType().GetProperty(multiple.ImageChosenField).GetValue(obj).ToString();

                        if (!string.IsNullOrEmpty(multiple.ValueField))
                        {
                            valueObj = obj.GetType().GetProperty(multiple.ValueField).GetValue(obj).ToString();
                        }

                        PickImageBase image = new PickImageBase("__Laavor*+-", currentIndex);

                        image.WidthRequest = WidthImage;
                        image.MinimumWidthRequest = WidthImage;
                        image.HeightRequest = HeightImage;
                        image.MinimumHeightRequest = HeightImage;
                        image.Aspect = Aspect.Fill;
                        image.VerticalOptions = LayoutOptions.Center;
                        image.HorizontalOptions = LayoutOptions.Center;
                        image.Source = sourceUnChosenObj;
                        image.UnChosenImage = sourceUnChosenObj;
                        image.ChosenImage = sourceChosenObj;
                        image.IsChosen = false;
                        image.Value = valueObj;

                        if (currentIndex > 0)
                        {
                            image.Margin = new Thickness(SpaceBetween, 0, 0, 0);
                        }

                        PickChosenItem chosen = new PickChosenItem(currentIndex, "", image.Value, image.UnChosenImage);
                        allItemsChosen.Insert(currentIndex, chosen);

                        image.GestureRecognizers.Add(GetVivacity());
                        image.GestureRecognizers.Add(GetTouch());

                        dataItems.Children.Add(image);

                        currentIndex++;
                    }
                }
            }

            /// <summary>
            /// Internal.
            /// </summary>
            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);

                if (child.GetType() == typeof(PickImageSwapItem))
                {
                    PickImageSwapItem choiceImageShiftItem = (PickImageSwapItem)child;
                    PickImageBase image = new PickImageBase("__Laavor*+-", currentIndex);

                    image.WidthRequest = WidthImage;
                    image.MinimumWidthRequest = WidthImage;
                    image.HeightRequest = HeightImage;
                    image.MinimumHeightRequest = HeightImage;
                    image.Aspect = Aspect.Fill;
                    image.VerticalOptions = LayoutOptions.Center;
                    image.HorizontalOptions = LayoutOptions.Center;
                    image.Source = choiceImageShiftItem.ImageUnChosen;
                    image.UnChosenImage = choiceImageShiftItem.ImageUnChosen;
                    image.ChosenImage = choiceImageShiftItem.ImageChosen;
                    image.Value = choiceImageShiftItem.Value;
                    image.IsChosen = false;

                    if (currentIndex > 0)
                    {
                        image.Margin = new Thickness(SpaceBetween, 0, 0, 0);
                    }

                    PickChosenItem chosen = new PickChosenItem(currentIndex, "", choiceImageShiftItem.Value, image.UnChosenImage);
                    allItemsChosen.Insert(currentIndex, chosen);

                    image.GestureRecognizers.Add(GetVivacity());
                    image.GestureRecognizers.Add(GetTouch());

                    dataItems.Children.Add(image);

                    currentIndex++;
                }
            }

            /// <summary>
            /// Get Vivacity
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacity()
            {
                if (vivacity != Vivacity.None)
                {
                    MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
                    TapGestureRecognizer touchVivavicity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
                    return touchVivavicity;
                }
                else
                {
                    return new TapGestureRecognizer();
                }
            }

            private TapGestureRecognizer GetTouch()
            {
                TapGestureRecognizer tp = new TapGestureRecognizer();
                tp.Tapped += ChosenImage;
                return tp;
            }

            private void ChosenImage(object sender, EventArgs e)
            {
                PickImageBase choiceImageBase = (PickImageBase)sender;
                if (choiceImageBase.IsChosen)
                {
                    choiceImageBase.Source = choiceImageBase.UnChosenImage;
                    choiceImageBase.IsChosen = false;
                    ItemsChosen.Add(allItemsChosen[choiceImageBase.Index]);
                }
                else
                {
                    choiceImageBase.Source = choiceImageBase.ChosenImage;
                    choiceImageBase.IsChosen = true;
                    ItemsChosen.Add(allItemsChosen[choiceImageBase.Index]);
                }

                Chosen?.Invoke(this, EventArgs.Empty);
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
                        PickImageBase choiceItem = (PickImageBase)sender;

                        await choiceItem.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await choiceItem.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        PickImageBase choiceItem = (PickImageBase)sender;

                        await choiceItem.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await choiceItem.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        PickImageBase choiceItem = (PickImageBase)sender;

                        await choiceItem.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await choiceItem.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
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
                        PickImageBase choiceItem = (PickImageBase)sender;

                        await choiceItem.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await choiceItem.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        PickImageBase choiceItem = (PickImageBase)sender;

                        await choiceItem.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await choiceItem.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        PickImageBase choiceItem = (PickImageBase)sender;

                        await choiceItem.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await choiceItem.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        PickImageBase choiceItem = (PickImageBase)sender;

                        await choiceItem.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await choiceItem.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
