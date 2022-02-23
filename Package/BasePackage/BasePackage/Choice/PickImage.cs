using System;
using System.Collections;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Choice
    {
        /// <summary>
        /// Class PickImage
        /// </summary>
        public class PickImage : StackLayout
        {
            /// <summary>
            /// Call when image is chosen
            /// </summary>
            public event EventHandler Chosen;

            /// <summary>
            /// Returns the index of the chosen.
            /// </summary>
            public int IndexChosen { get; set; }

            /// <summary>
            /// Returns the source of the chosen.
            /// </summary>
            public string SourceChosen { get; set; }

            /// <summary>
            /// Returns the value of the chosen.
            /// </summary>
            public string ValueChosen { get; set; }

            private ScrollView scroll;

            /// <summary>
            /// Internal use.
            /// </summary>
            private StackLayout dataItems;

            private int currentIndex;

            private IEnumerable items = null;

            private ChoiceOrientation choiceOrientation = Laavor.ChoiceOrientation.Horizontal;

            private ColorUI borderColorChosen;
            private ColorUI colorUIChosen;
            private ColorUI colorUI;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Constructor of ChoiceImage
            /// </summary>
            public PickImage() : base()
            {
                InitAll();
            }

            private void InitAll()
            {
                currentIndex = 0;

                this.Children.Clear();
                this.HorizontalOptions = LayoutOptions.Center;

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

            /// <summary>
            /// Clear the list Images - necessary insert ChoiceImageItem again
            /// </summary>
            public void ResetAll()
            {
                InitAll();
            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public StackLayout GetData(string key)
            {
                if (key == "__Laavor*+-")
                {
                    return dataItems;
                }

                return null;
            }

            /// <summary>
            /// Internal
            /// </summary>
            public void UpdateData(string value, string imgSource, int index, string Key)
            {
                if (Key == "__Laavor*+-")
                {
                    this.ValueChosen = value;
                    this.SourceChosen = imgSource;
                    this.IndexChosen = index;
                }

                Chosen?.Invoke(this, EventArgs.Empty);
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
            /// Property to inform SpaceBetween Items
            /// </summary>
            public static readonly BindableProperty SpaceBetweenProperty = BindableProperty.Create(
                     propertyName: nameof(SpaceBetween),
                     returnType: typeof(int),
                     declaringType: typeof(PickImage),
                     defaultValue: 0,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: SpaceBetweenPropertyChanged);

            /// <summary>
            /// Property to inform SpaceBetween Items
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
                PickImage choiceImage = (PickImage)bindable;
                int copyMargin = (int)newValue;

                if (choiceImage.dataItems != null)
                {
                    if (choiceImage.dataItems.Children.Count > 0)
                    {
                        choiceImage.dataItems.Children[choiceImage.dataItems.Children.Count - 1].Margin = new Thickness(0, 0, 0, 0);
                    }

                    for (int iItem = 0; iItem < choiceImage.dataItems.Children.Count - 1; iItem++)
                    {
                        if (choiceImage.dataItems.Children[iItem].GetType() == typeof(PickBoxImage))
                        {
                            PickBoxImage image = (PickBoxImage)choiceImage.dataItems.Children[iItem];
                            image.Margin = new Thickness(image.Margin.Right, image.Margin.Top, copyMargin, image.Margin.Bottom);
                        }
                    }
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

                ChangeOrientation(choiceOrientation);
            }

            /// <summary>
            /// Preselected index
            /// </summary>
            public static readonly BindableProperty InitialIndexChosenProperty = BindableProperty.Create(
                propertyName: nameof(InitialIndexChosen),
                returnType: typeof(int),
                declaringType: typeof(PickImage),
                defaultValue: -1,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: InitialIndexChosenChanged);

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

            private static void InitialIndexChosenChanged(object bindable, object oldValue, object newValue)
            {
                PickImage choiceImage = (PickImage)bindable;
                int copyIndex = (int)newValue;

                if (choiceImage.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceImage.dataItems.Children.Count; iItem++)
                    {
                        if (choiceImage.dataItems.Children[iItem].GetType() == typeof(PickBoxImage))
                        {
                            PickBoxImage image = (PickBoxImage)choiceImage.dataItems.Children[iItem];
                            if (image.Index == copyIndex)
                            {
                                image.IsChosen = true;
                            }
                            else
                            {
                                image.IsChosen = false;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Preselected index
            /// </summary>
            public static readonly BindableProperty InitialValueChosenProperty = BindableProperty.Create(
                propertyName: nameof(InitialValueChosen),
                returnType: typeof(string),
                declaringType: typeof(PickImage),
                defaultValue: "_laavor_nothing_2018_77",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: InitialValueChosenPropertyChanged);

            /// <summary>
            /// Preselected Value
            /// </summary>
            public string InitialValueChosen
            {
                get
                {
                    return (string)GetValue(InitialValueChosenProperty);
                }
                set
                {
                    SetValue(InitialValueChosenProperty, value);
                }
            }

            private static void InitialValueChosenPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickImage choiceImage = (PickImage)bindable;
                string copyValue = newValue.ToString();

                if (choiceImage.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceImage.dataItems.Children.Count; iItem++)
                    {
                        if (choiceImage.dataItems.Children[iItem].GetType() == typeof(PickBoxImage))
                        {
                            PickBoxImage image = (PickBoxImage)choiceImage.dataItems.Children[iItem];
                            if (image.Value == copyValue)
                            {
                                image.IsChosen = true;
                            }
                            else
                            {
                                image.IsChosen = false;
                            }
                        }
                    }
                }
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
                    ColorUIPropertyChanged();
                }
            }

            private void ColorUIPropertyChanged()
            {
                if (scroll != null)
                {
                    scroll.BackgroundColor = Colors.Get(colorUI);
                }
            }

            /// <summary>
            /// Set ColorUIChosen
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
                if (dataItems != null)
                {
                    for (int index = 0; index < dataItems.Children.Count; index++)
                    {
                        if (dataItems.Children[index].GetType() == typeof(PickBoxImage))
                        {
                            PickBoxImage image = (PickBoxImage)dataItems.Children[index];
                            image.ColorUIChosen = colorUIChosen;
                        }
                    }
                }
            }

            /// <summary>
            /// Set BorderColor
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
                if (dataItems != null)
                {
                    for (int index = 0; index < dataItems.Children.Count; index++)
                    {
                        if (dataItems.Children[index].GetType() == typeof(PickBoxImage))
                        {
                            PickBoxImage image = (PickBoxImage)dataItems.Children[index];
                            image.BorderColorChosen = BorderColorChosen;
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
                declaringType: typeof(PickImage),
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
                PickImage choiceImage = (PickImage)bindable;
                choiceImage.items = (IEnumerable)newValue;
                choiceImage.InitAllBindable();
            }

            /// <summary>
            /// Enter the ValueField, only when using list.
            /// </summary>
            public static readonly BindableProperty ValueFieldProperty = BindableProperty.Create(
                propertyName: nameof(ValueField),
                returnType: typeof(string),
                declaringType: typeof(PickImage),
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
                PickImage choiceImage = (PickImage)bindable;
                choiceImage.InitAllBindable();
            }

            /// <summary>
            /// Enter the ValueField, only when using list.
            /// </summary>
            public static readonly BindableProperty ImageSourceFieldProperty = BindableProperty.Create(
                propertyName: nameof(ImageSourceField),
                returnType: typeof(string),
                declaringType: typeof(PickImage),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ValueFieldPropertyChanged);

            /// <summary>
            /// Enter the ImageSourceField, only when using list.
            /// </summary>
            public string ImageSourceField
            {
                get
                {
                    return (string)GetValue(ImageSourceFieldProperty);
                }
                set
                {
                    SetValue(ImageSourceFieldProperty, value);
                }
            }

            private static void ImageSourceFieldPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickImage choiceImage = (PickImage)bindable;
                choiceImage.InitAllBindable();
            }

            /// <summary>
            /// Enter Widht.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(PickImage),
                defaultValue: -1.0,
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
                PickImage choiceImage = (PickImage)bindable;
                double width = (double)newValue;

                if (choiceImage.scroll != null)
                {
                    if (choiceImage.ChoiceOrientation == ChoiceOrientation.Horizontal)
                    {
                        choiceImage.scroll.WidthRequest = width;
                    }
                    else
                    {
                        choiceImage.scroll.HeightRequest = -1;
                    }
                }
            }

            /// <summary>
            /// Enter Height.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(PickImage),
                defaultValue: -1.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: HeightPropertyChanged);

            /// <summary>
            /// Enter Height.
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
                PickImage choiceImage = (PickImage)bindable;
                double height = (double)newValue;

                if (choiceImage.scroll != null)
                {
                    if (choiceImage.ChoiceOrientation == ChoiceOrientation.Vertical)
                    {
                        choiceImage.scroll.HeightRequest = height;
                    }
                    else
                    {
                        choiceImage.scroll.WidthRequest = -1;
                    }
                }
            }

            /// <summary>
            /// Enter the WidthImage.
            /// </summary>
            public static readonly BindableProperty WidthImageProperty = BindableProperty.Create(
                propertyName: nameof(WidthImage),
                returnType: typeof(double),
                declaringType: typeof(PickImage),
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
                PickImage choiceImage = (PickImage)bindable;
                double width = (double)newValue;

                if (choiceImage.dataItems != null)
                {
                    for (int iCh = 0; iCh < choiceImage.dataItems.Children.Count; iCh++)
                    {
                        PickBoxImage image = (PickBoxImage)choiceImage.dataItems.Children[iCh];
                        image.WidthImage = width;
                    }
                }
            }

            /// <summary>
            /// Enter the HeightImage.
            /// </summary>
            public static readonly BindableProperty HeightImageProperty = BindableProperty.Create(
                propertyName: nameof(HeightImage),
                returnType: typeof(double),
                declaringType: typeof(PickImage),
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
                PickImage pickImage = (PickImage)bindable;
                double height = (double)newValue;

                if (pickImage.dataItems != null)
                {
                    for (int iCh = 0; iCh < pickImage.dataItems.Children.Count; iCh++)
                    {
                        PickBoxImage image = (PickBoxImage)pickImage.dataItems.Children[iCh];
                        image.HeightImage = height;
                    }
                }
            }

            private void InitAllBindable()
            {
                PickImage pickImage = this;

                if (pickImage.items != null && !string.IsNullOrEmpty(pickImage.ImageSourceField))
                {
                    dataItems.Children.Clear();
                    currentIndex = 0;

                    IEnumerator enumerator = pickImage.ListItems.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        object obj = enumerator.Current;
                        string valueObj = "";

                        if (!string.IsNullOrEmpty(pickImage.ValueField))
                        {
                            obj.GetType().GetProperty(pickImage.ValueField).GetValue(obj).ToString();
                        }

                        string sourceObj = obj.GetType().GetProperty(pickImage.ImageSourceField).GetValue(obj).ToString();

                        PickImageItem choiceImageItem = new PickImageItem();
                        choiceImageItem.Value = valueObj;
                        choiceImageItem.Image = sourceObj;

                        PickBoxImage image = new PickBoxImage("__Laavor*+-", this, choiceImageItem.Value, choiceImageItem.Image, currentIndex, Vivacity, Depth, VivacitySpeed);
                        image.WidthImage = WidthImage;
                        image.HeightImage = HeightImage;
                        image.BorderColorChosen = BorderColorChosen;
                        image.ColorUIChosen = ColorUIChosen;

                        if ((InitialIndexChosen != -1 && InitialIndexChosen == currentIndex) || (InitialValueChosen != "_laavor_nothing_2018_77" && InitialValueChosen == image.Value))
                        {
                            image.IsChosen = true;
                        }

                        if (currentIndex > 0)
                        {
                            dataItems.Children[currentIndex - 1].Margin = new Thickness(image.Margin.Right, image.Margin.Top, SpaceBetween, image.Margin.Bottom);
                        }

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

                if (child.GetType() == typeof(PickImageItem))
                {
                    PickImageItem pickImageItem = (PickImageItem)child;
                    PickBoxImage image = new PickBoxImage("__Laavor*+-", this, pickImageItem.Value, pickImageItem.Image, currentIndex, Vivacity, Depth, VivacitySpeed);
                    image.WidthImage = WidthImage;
                    image.HeightImage = HeightImage;
                    image.BorderColorChosen = BorderColorChosen;
                    image.ColorUIChosen = ColorUIChosen;

                    if ((InitialIndexChosen != -1 && InitialIndexChosen == currentIndex) || (InitialValueChosen != "_laavor_nothing_2018_77" && InitialValueChosen == image.Value))
                    {
                        image.IsChosen = true;
                    }

                    dataItems.Children.Add(image);

                    if (currentIndex > 0)
                    {
                        dataItems.Children[currentIndex - 1].Margin = new Thickness(image.Margin.Right, image.Margin.Top, SpaceBetween, image.Margin.Bottom);
                    }

                    currentIndex++;
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
                    for (int index = 0; index < dataItems.Children.Count; index++)
                    {
                        if (dataItems.Children[index].GetType() == typeof(PickBoxImage))
                        {
                            PickBoxImage image = (PickBoxImage)dataItems.Children[index];
                            image.Vivacity = vivacity;
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
                    VivacitySpeedPropertyChanged();
                }
            }

            private void VivacitySpeedPropertyChanged()
            {
                if (dataItems != null)
                {
                    for (int index = 0; index < dataItems.Children.Count; index++)
                    {
                        if (dataItems.Children[index].GetType() == typeof(PickBoxImage))
                        {
                            PickBoxImage image = (PickBoxImage)dataItems.Children[index];
                            image.VivacitySpeed = vivacitySpeed;
                        }
                    }
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

            private void DepthPropertyChanged()
            {
                if (dataItems != null)
                {
                    for (int index = 0; index < dataItems.Children.Count; index++)
                    {
                        if (dataItems.Children[index].GetType() == typeof(PickBoxImage))
                        {
                            PickBoxImage image = (PickBoxImage)dataItems.Children[index];
                            image.Depth = depth;
                        }
                    }
                }
            }
        }
    }
}
