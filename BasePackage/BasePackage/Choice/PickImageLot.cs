using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Choice
    {
        /// <summary>
        /// Class PickImageLot
        /// </summary>
        public class PickImageLot : StackLayout
        {
            /// <summary>
            /// Returns the List the chosen items.
            /// </summary>
            public List<PickChosenItem> ItemsChosen { get; private set; }

            private List<PickChosenItem> allItemsChosen;

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

            private ColorUI borderColorChosen = ColorUI.Black;
            private ColorUI colorUIChosen = ColorUI.Blue;
            private ColorUI colorUI = ColorUI.White;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Constructor of ChoiceImageMultiple
            /// </summary>
            public PickImageLot() : base()
            {
                InitAll();
            }

            private void InitAll()
            {
                currentIndex = 0;

                Spacing = 0;

                ItemsChosen = new List<PickChosenItem>();
                allItemsChosen = new List<PickChosenItem>();

                this.Children.Clear();
                this.HorizontalOptions = LayoutOptions.Center;

                dataItems = new StackLayout();
                dataItems.Spacing = 0;

                scroll = new ScrollView();
                scroll.Content = dataItems;

                if (choiceOrientation == Laavor.ChoiceOrientation.Horizontal)
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
            public void UpdateData(int index, string Key, bool chosen)
            {
                if (Key == "__Laavor*+-")
                {
                    if (chosen)
                    {
                        ItemsChosen.Add(allItemsChosen[index]);
                    }
                    else
                    {
                        ItemsChosen.Remove(allItemsChosen[index]);
                    }
                }

                Chosen?.Invoke(this, EventArgs.Empty);
            }

            private void ChangeOrientation(ChoiceOrientation o)
            {
                if (o == Laavor.ChoiceOrientation.Horizontal)
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
                     declaringType: typeof(PickImageLot),
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
                PickImageLot choiceImageMultiple = (PickImageLot)bindable;
                int copySpace = (int)newValue;

                if (choiceImageMultiple.dataItems != null)
                {
                    if (choiceImageMultiple.dataItems.Children.Count > 0)
                    {
                        choiceImageMultiple.dataItems.Children[choiceImageMultiple.dataItems.Children.Count - 1].Margin = new Thickness(0, 0, 0, 0);
                    }

                    for (int iItem = 1; iItem < choiceImageMultiple.dataItems.Children.Count; iItem++)
                    {
                        if (choiceImageMultiple.dataItems.Children[iItem].GetType() == typeof(PickBoxImageLot))
                        {
                            PickBoxImageLot image = (PickBoxImageLot)choiceImageMultiple.dataItems.Children[iItem];
                            image.Margin = new Thickness(copySpace, 0, 0, 0);
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
            /// Preselected index
            /// </summary>
            public static readonly BindableProperty InitialIndexChosenProperty = BindableProperty.Create(
                propertyName: nameof(InitialIndexChosen),
                returnType: typeof(int),
                declaringType: typeof(PickImageLot),
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
                PickImageLot choiceImageMultiple = (PickImageLot)bindable;
                int copyIndex = (int)newValue;

                if (choiceImageMultiple.dataItems != null)
                {
                    for (int iLV = 0; iLV < choiceImageMultiple.dataItems.Children.Count; iLV++)
                    {
                        for (int iItem = 0; iItem < choiceImageMultiple.dataItems.Children.Count; iItem++)
                        {
                            if (choiceImageMultiple.dataItems.Children[iItem].GetType() == typeof(PickBoxImageLot))
                            {
                                PickBoxImageLot image = (PickBoxImageLot)choiceImageMultiple.dataItems.Children[iItem];
                                if (image.Index == copyIndex)
                                {
                                    if (image.IsChosen)
                                    {
                                        image.IsChosen = false;
                                    }
                                    else
                                    {
                                        image.IsChosen = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Set ColorUI
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
                        if (dataItems.Children[index].GetType() == typeof(PickBoxImageLot))
                        {
                            PickBoxImageLot image = (PickBoxImageLot)dataItems.Children[index];
                            image.ColorUIChosen = colorUIChosen;
                        }
                    }
                }
            }

            /// <summary>
            /// Set BorderColorChosen
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
                        if (dataItems.Children[index].GetType() == typeof(PickBoxImageLot))
                        {
                            PickBoxImageLot image = (PickBoxImageLot)dataItems.Children[index];
                            image.BorderColorChosen = borderColorChosen;
                        }
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
                    for (int index = 0; index < dataItems.Children.Count; index++)
                    {
                        if (dataItems.Children[index].GetType() == typeof(PickBoxImageLot))
                        {
                            PickBoxImageLot image = (PickBoxImageLot)dataItems.Children[index];
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
                        if (dataItems.Children[index].GetType() == typeof(PickBoxImageLot))
                        {
                            PickBoxImageLot image = (PickBoxImageLot)dataItems.Children[index];
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
                        if (dataItems.Children[index].GetType() == typeof(PickBoxImageLot))
                        {
                            PickBoxImageLot image = (PickBoxImageLot)dataItems.Children[index];
                            image.Depth = depth;
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
                declaringType: typeof(PickImageLot),
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
                PickImageLot choiceImageMultiple = (PickImageLot)bindable;
                choiceImageMultiple.items = (IEnumerable)newValue;
                choiceImageMultiple.InitAllBindable();
            }

            /// <summary>
            /// Enter the ValueField, only when using list.
            /// </summary>
            public static readonly BindableProperty ValueFieldProperty = BindableProperty.Create(
                propertyName: nameof(ValueField),
                returnType: typeof(string),
                declaringType: typeof(PickImageLot),
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
                PickImageLot choiceImageMultiple = (PickImageLot)bindable;
                choiceImageMultiple.InitAllBindable();
            }

            /// <summary>
            /// Enter the ValueField, only when using list.
            /// </summary>
            public static readonly BindableProperty ImageSourceFieldProperty = BindableProperty.Create(
                propertyName: nameof(ImageSourceField),
                returnType: typeof(string),
                declaringType: typeof(PickImageLot),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImageSourceFieldPropertyChanged);

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
                PickImageLot choiceImageMultiple = (PickImageLot)bindable;
                choiceImageMultiple.InitAllBindable();
            }

            /// <summary>
            /// Enter the Height.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(PickImageLot),
                defaultValue: -1.0,
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
                PickImageLot choiceImageMultiple = (PickImageLot)bindable;
                double height = (double)newValue;

                if (choiceImageMultiple.scroll != null)
                {
                    if (choiceImageMultiple.ChoiceOrientation == ChoiceOrientation.Vertical)
                    {
                        choiceImageMultiple.scroll.HeightRequest = height;
                    }
                    else
                    {
                        choiceImageMultiple.scroll.WidthRequest = -1;
                    }
                }
            }

            /// <summary>
            /// Enter Widht.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(PickImageLot),
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
                PickImageLot choiceImageMultiple = (PickImageLot)bindable;
                double width = (double)newValue;

                if (choiceImageMultiple.scroll != null)
                {
                    if (choiceImageMultiple.ChoiceOrientation == ChoiceOrientation.Horizontal)
                    {
                        choiceImageMultiple.scroll.WidthRequest = width;
                    }
                    else
                    {
                        choiceImageMultiple.scroll.HeightRequest = -1;
                    }
                }
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
                PickImageLot choiceImageMultiple = (PickImageLot)bindable;
                double height = (double)newValue;

                if (choiceImageMultiple.dataItems != null)
                {
                    for (int iCh = 0; iCh < choiceImageMultiple.dataItems.Children.Count; iCh++)
                    {
                        PickBoxImageLot boxImageMultiple = (PickBoxImageLot)choiceImageMultiple.dataItems.Children[iCh];
                        boxImageMultiple.HeightImage = height;
                    }
                }
            }

            /// <summary>
            /// Enter the WidthImage.
            /// </summary>
            public static readonly BindableProperty WidthImageProperty = BindableProperty.Create(
                propertyName: nameof(WidthImage),
                returnType: typeof(double),
                declaringType: typeof(PickImageLot),
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
                PickImageLot choiceImageMultiple = (PickImageLot)bindable;
                double width = (double)newValue;

                if (choiceImageMultiple.dataItems != null)
                {
                    for (int iCh = 0; iCh < choiceImageMultiple.dataItems.Children.Count; iCh++)
                    {
                        PickBoxImageLot boxImageMultiple = (PickBoxImageLot)choiceImageMultiple.dataItems.Children[iCh];
                        boxImageMultiple.WidthImage = width;
                    }
                }
            }

            private void InitAllBindable()
            {
                PickImageLot choiceImageMultiple = this;

                if (choiceImageMultiple.items != null && !string.IsNullOrEmpty(choiceImageMultiple.ImageSourceField))
                {
                    dataItems.Children.Clear();
                    currentIndex = 0;

                    IEnumerator enumerator = choiceImageMultiple.ListItems.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        object obj = enumerator.Current;
                        string valueObj = "";

                        if (!string.IsNullOrEmpty(choiceImageMultiple.ValueField))
                        {
                            valueObj = obj.GetType().GetProperty(choiceImageMultiple.ValueField).GetValue(obj).ToString();
                        }

                        string sourceObj = obj.GetType().GetProperty(choiceImageMultiple.ImageSourceField).GetValue(obj).ToString();

                        PickImageItem choiceImageItem = new PickImageItem();
                        choiceImageItem.Value = valueObj;
                        choiceImageItem.Image = sourceObj;

                        PickBoxImageLot image = new PickBoxImageLot("__Laavor*+-", this, choiceImageItem.Value, choiceImageItem.Image, currentIndex, vivacity, depth, vivacitySpeed);
                        image.WidthImage = WidthImage;
                        image.HeightImage = HeightImage;
                        image.BorderColorChosen = ColorUI.Transparent;
                        image.ColorUIChosen = ColorUI.Transparent;

                        PickChosenItem chosen = new PickChosenItem(currentIndex, "", choiceImageItem.Value, choiceImageItem.Image);
                        allItemsChosen.Insert(currentIndex, chosen);

                        if ((InitialIndexChosen != -1 && InitialIndexChosen == currentIndex))
                        {
                            image.IsChosen = true;
                        }

                        if (currentIndex > 0)
                        {
                            image.Margin = new Thickness(SpaceBetween, 0, 0, 0);
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
                    PickImageItem choiceImageItem = (PickImageItem)child;
                    PickBoxImageLot image = new PickBoxImageLot("__Laavor*+-", this, choiceImageItem.Value, choiceImageItem.Image, currentIndex, vivacity, depth, vivacitySpeed);
                    image.WidthImage = WidthImage;
                    image.HeightImage = HeightImage;
                    image.BorderColorChosen = ColorUI.Transparent;
                    image.ColorUIChosen = ColorUI.Transparent;

                    PickChosenItem chosen = new PickChosenItem(currentIndex, "", choiceImageItem.Value, choiceImageItem.Image);
                    allItemsChosen.Insert(currentIndex, chosen);

                    if (InitialIndexChosen != -1 && InitialIndexChosen == currentIndex)
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
    }
}
