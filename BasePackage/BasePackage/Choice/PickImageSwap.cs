using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Choice
    {
        /// <summary>
        /// Class PickImageSwap
        /// </summary>
        public class PickImageSwap : StackLayout
        {
            /// <summary>
            /// Returns the value of the chosen.
            /// </summary>
            public string ValueChosen { get; set; }

            /// <summary>
            /// Returns the index of the chosen.
            /// </summary>
            public int IndexChosen { get; set; }

            /// <summary>
            /// Returns the source of the chosen.
            /// </summary>
            public string SourceChosen { get; set; }

            /// <summary>
            /// Call when image is chosen
            /// </summary>
            public event EventHandler Chosen;

            private ScrollView scroll;

            /// <summary>
            /// Internal use.
            /// </summary>
            public StackLayout dataItems;

            private int currentIndex;

            private IEnumerable items = null;

            private ChoiceOrientation choiceOrientation = Laavor.ChoiceOrientation.Horizontal;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            private const double spaceDecrease = 2;

            /// <summary>
            /// Constructor of ChoiceImageShift
            /// </summary>
            public PickImageSwap() : base()
            {
                InitAll();
            }

            private void InitAll()
            {
                currentIndex = 0;

                this.Children.Clear();
                this.HorizontalOptions = LayoutOptions.Center;
                this.Spacing = 0;

                ValueChosen = "";
                IndexChosen = -1;
                SourceChosen = "";

                dataItems = new StackLayout();
                dataItems.Spacing = 0;

                scroll = new ScrollView();
                scroll.Content = dataItems;

                if (choiceOrientation == ChoiceOrientation.Horizontal)
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
            /// Preselected index
            /// </summary>
            public static readonly BindableProperty InitialIndexChosenProperty = BindableProperty.Create(
                propertyName: nameof(InitialIndexChosen),
                returnType: typeof(int),
                declaringType: typeof(PickImageSwap),
                defaultValue: -1,
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Preselected index
            /// </summary>
            public int InitialIndexChosen
            {
                get
                {
                    return (int)GetValue(InitialIndexChosenProperty);
                }
                set
                {
                    SetValue(InitialIndexChosenProperty, value);
                }
            }

            private static void InitialIndexChosenPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickImageSwap choiceImageShift = (PickImageSwap)bindable;
                int index = (int)newValue;

                if (choiceImageShift.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceImageShift.dataItems.Children.Count; iItem++)
                    {
                        if (choiceImageShift.dataItems.Children[iItem].GetType() == typeof(PickImageBase))
                        {
                            PickImageBase choiceItem = (PickImageBase)choiceImageShift.dataItems.Children[iItem];

                            if (choiceItem.Index == choiceItem.Index)
                            {
                                choiceItem.IsChosen = true;
                                choiceItem.Source = choiceItem.ChosenImage;

                                choiceImageShift.IndexChosen = index;
                                choiceImageShift.ValueChosen = choiceItem.Value;
                                choiceImageShift.SourceChosen = choiceItem.ChosenImage;
                            }
                            else
                            {
                                choiceItem.IsChosen = false;
                                choiceItem.Source = choiceItem.UnChosenImage;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Enter ListItems(Data items).
            /// </summary>
            public static readonly BindableProperty ListItemsProperty = BindableProperty.Create(
                propertyName: nameof(ListItems),
                returnType: typeof(IEnumerable),
                declaringType: typeof(PickImageSwap),
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
                PickImageSwap choiceImageSwap = (PickImageSwap)bindable;
                choiceImageSwap.items = (IEnumerable)newValue;
                choiceImageSwap.InitAllBindable();
            }

            /// <summary>
            /// Enter the ValueField, only when using list.
            /// </summary>
            public static readonly BindableProperty ValueFieldProperty = BindableProperty.Create(
                propertyName: nameof(ValueField),
                returnType: typeof(string),
                declaringType: typeof(PickImageSwap),
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
                PickImageSwap choiceImageSwap = (PickImageSwap)bindable;
                choiceImageSwap.InitAllBindable();
            }

            /// <summary>
            /// Enter the ImageUnChosenField, only when using list.
            /// </summary>
            public static readonly BindableProperty ImageUnChosenFieldProperty = BindableProperty.Create(
                propertyName: nameof(ImageUnChosenField),
                returnType: typeof(string),
                declaringType: typeof(PickImageSwap),
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
                PickImageSwap choiceImageShift = (PickImageSwap)bindable;
                choiceImageShift.InitAllBindable();
            }

            /// <summary>
            /// Enter the ImageChosenField, only when using list.
            /// </summary>
            public static readonly BindableProperty ImageChosenFieldProperty = BindableProperty.Create(
                propertyName: nameof(ImageChosenField),
                returnType: typeof(string),
                declaringType: typeof(PickImageSwap),
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
                PickImageSwap choiceImageShift = (PickImageSwap)bindable;
                choiceImageShift.InitAllBindable();
            }

            /// <summary>
            /// Enter the Height.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(PickImageSwap),
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
                PickImageSwap choiceImageShift = (PickImageSwap)bindable;
                double height = (double)newValue;

                if (choiceImageShift.scroll != null)
                {
                    if (choiceImageShift.ChoiceOrientation == ChoiceOrientation.Vertical)
                    {
                        choiceImageShift.scroll.HeightRequest = height;
                    }
                    else
                    {
                        choiceImageShift.scroll.WidthRequest = -1;
                    }
                }
            }

            /// <summary>
            /// Enter Widht.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(PickImageSwap),
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
                PickImageSwap choiceImageShift = (PickImageSwap)bindable;
                double width = (double)newValue;

                if (choiceImageShift.scroll != null)
                {
                    if (choiceImageShift.ChoiceOrientation == ChoiceOrientation.Horizontal)
                    {
                        choiceImageShift.scroll.WidthRequest = width;
                    }
                    else
                    {
                        choiceImageShift.scroll.HeightRequest = -1;
                    }
                }
            }

            private void ChangeWidthRequest(double w)
            {
                base.WidthRequest = w;
                WidthRequest = w;
            }

            /// <summary>
            /// Enter the HeightImage.
            /// </summary>
            public static readonly BindableProperty HeightImageProperty = BindableProperty.Create(
                propertyName: nameof(HeightImage),
                returnType: typeof(double),
                declaringType: typeof(PickImageSwap),
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
                PickImageSwap choiceImageShift = (PickImageSwap)bindable;
                double height = (double)newValue;

                if (choiceImageShift.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceImageShift.dataItems.Children.Count; iItem++)
                    {
                        if (choiceImageShift.dataItems.Children[iItem].GetType() == typeof(LaavorFormer))
                        {
                            LaavorFormer laavorFormer = (LaavorFormer)choiceImageShift.dataItems.Children[iItem];
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
                declaringType: typeof(PickImageSwap),
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
                PickImageSwap choiceImageShift = (PickImageSwap)bindable;
                double width = (double)newValue;

                if (choiceImageShift.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceImageShift.dataItems.Children.Count; iItem++)
                    {
                        if (choiceImageShift.dataItems.Children[iItem].GetType() == typeof(LaavorFormer))
                        {
                            LaavorFormer laavorFormer = (LaavorFormer)choiceImageShift.dataItems.Children[iItem];
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
                     declaringType: typeof(PickImageSwap),
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
                PickImageSwap choiceImageShift = (PickImageSwap)bindable;
                int copyMargin = (int)newValue;

                if (choiceImageShift.dataItems != null)
                {
                    if (choiceImageShift.dataItems.Children.Count > 0)
                    {
                        choiceImageShift.dataItems.Children[choiceImageShift.dataItems.Children.Count - 1].Margin = new Thickness(0, 0, 0, 0);
                    }
                }

                for (int iItem = 1; iItem < choiceImageShift.Children.Count; iItem++)
                {
                    if (choiceImageShift.Children[0].GetType() == typeof(PickImageBase))
                    {
                        PickImageBase choiceImageBase = (PickImageBase)choiceImageShift.Children[0];
                        choiceImageBase.Margin = new Thickness(copyMargin, 0, 0, 0);
                    }
                }
            }

            private void InitAllBindable()
            {
                PickImageSwap choiceImageShift = this;

                if(dataItems != null)
                {
                    dataItems = new StackLayout();
                }

                if (choiceImageShift.ListItems != null && !string.IsNullOrEmpty(choiceImageShift.ImageUnChosenField) && !string.IsNullOrEmpty(choiceImageShift.ImageChosenField))
                {
                    dataItems.Children.Clear();
                    currentIndex = 0;

                    IEnumerator enumerator = choiceImageShift.ListItems.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        object obj = enumerator.Current;

                        string valueObj = "";
                        string sourceUnChosenObj = obj.GetType().GetProperty(choiceImageShift.ImageUnChosenField).GetValue(obj).ToString();
                        string sourceChosenObj = obj.GetType().GetProperty(choiceImageShift.ImageChosenField).GetValue(obj).ToString();

                        if (!string.IsNullOrEmpty(choiceImageShift.ValueField))
                        {
                            valueObj = obj.GetType().GetProperty(choiceImageShift.ValueField).GetValue(obj).ToString();
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

                        if (currentIndex == InitialIndexChosen)
                        {
                            image.IsChosen = true;
                            image.Source = sourceChosenObj;

                            choiceImageShift.IndexChosen = currentIndex;
                            choiceImageShift.ValueChosen = valueObj;
                            choiceImageShift.SourceChosen = sourceChosenObj;
                        }

                        if (vivacity != Vivacity.None)
                        {
                            image.GestureRecognizers.Add(GetVivacity());
                        }

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

                    if (currentIndex == InitialIndexChosen)
                    {
                        image.IsChosen = true;
                        image.Source = choiceImageShiftItem.ImageChosen;

                        IndexChosen = currentIndex;
                        ValueChosen = choiceImageShiftItem.Value;
                        SourceChosen = choiceImageShiftItem.ImageChosen;
                    }

                    if (vivacity != Vivacity.None)
                    {
                        image.GestureRecognizers.Add(GetVivacity());
                    }

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

            private TapGestureRecognizer GetTouch()
            {
                TapGestureRecognizer tp = new TapGestureRecognizer();
                tp.Tapped += ChosenImage;
                return tp;
            }

            private void ChosenImage(object sender, EventArgs e)
            {
                PickImageBase choiceImageBase = (PickImageBase)sender;

                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(PickImageBase))
                        {
                            PickImageBase choiceItem = (PickImageBase)dataItems.Children[iItem];

                            if (choiceItem.Index == choiceImageBase.Index)
                            {
                                choiceItem.IsChosen = true;
                                choiceItem.Source = choiceItem.ChosenImage;

                                IndexChosen = choiceItem.Index;
                                ValueChosen = choiceItem.Value;
                                SourceChosen = choiceItem.ChosenImage;
                            }
                            else
                            {
                                choiceItem.IsChosen = false;
                                choiceItem.Source = choiceItem.UnChosenImage;
                            }
                        }
                    }
                }

                Chosen?.Invoke(this, EventArgs.Empty);
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

                            if (vivacity != Vivacity.None)
                            {
                                choiceItem.GestureRecognizers.Add(GetVivacity());
                            }
                            
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
