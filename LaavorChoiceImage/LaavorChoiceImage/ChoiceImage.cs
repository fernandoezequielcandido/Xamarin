using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorChoiceImage
{
    /// <summary>
    /// Class ChoiceImage
    /// </summary>
    public class ChoiceImage : StackLayout
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

        private ChoiceOrientation currentOrientation = ChoiceOrientation.Horizontal;

        private Vivacity vivacity = Vivacity.Decrease;
        private Depth depth = Depth.Medium;
        private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

        /// <summary>
        /// Constructor of ChoiceImage
        /// </summary>
        public ChoiceImage() : base()
        {
            InitAll();
        }

        private void InitAll()
        {
            currentIndex = 0;

            this.Children.Clear();

            ValueChosen = "";
            IndexChosen = -1;
            SourceChosen = "";

            dataItems = new StackLayout();
            scroll = new ScrollView();
            scroll.Content = dataItems;

            if (currentOrientation == ChoiceOrientation.Horizontal)
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
            if (key == "Asaph_77_laavor_lincohl_il71_++*e*e-")
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
            if (Key == "amebaprotozoarioindexDD1458**")
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
        /// Choice should be vertically or horizontally oriented.
        /// </summary>
        [Bindable(true)]
        public ChoiceOrientation OrientationChoice
        {
            get
            {
                return currentOrientation;
            }
            set
            {
                OrientationChoicePropertyChanged(this, currentOrientation, value);
                currentOrientation = value;
            }
        }

        private static void OrientationChoicePropertyChanged(object bindable, ChoiceOrientation oldValue, ChoiceOrientation newValue)
        {
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            ChoiceOrientation copyOrientation = newValue;

            if (copyOrientation == ChoiceOrientation.Horizontal)
            {
                choiceImage.scroll.Orientation = ScrollOrientation.Horizontal;
                choiceImage.dataItems.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                choiceImage.scroll.Orientation = ScrollOrientation.Vertical;
                choiceImage.dataItems.Orientation = StackOrientation.Vertical;
            }

            choiceImage.ChangeOrientation(copyOrientation);
        }


        /// <summary>
        /// Orientation is deprecate
        /// </summary>
        [Obsolete]
        [Bindable(true)]
        public new StackOrientation Orientation
        {
            get
            {
                return StackOrientation.Horizontal;
            }
            set { }
        }

        /// <summary>
        /// Preselected index
        /// </summary>
        public static readonly BindableProperty InitialIndexChosenProperty = BindableProperty.Create(
            propertyName: nameof(InitialIndexChosen),
            returnType: typeof(int),
            declaringType: typeof(ChoiceImage),
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
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            int copyIndex = (int)newValue;
            for (int iLV = 0; iLV < choiceImage.dataItems.Children.Count; iLV++)
            {
                for (int iItem = 0; iItem < choiceImage.dataItems.Children.Count; iItem++)
                {
                    if (choiceImage.dataItems.Children[iItem].GetType() == typeof(BoxImage))
                    {
                        BoxImage image = (BoxImage)choiceImage.dataItems.Children[iItem];
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
            declaringType: typeof(ChoiceImage),
            defaultValue: "_laavor_nothing_2018_77",
            defaultBindingMode: BindingMode.OneWay);

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
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            string copyValue = newValue.ToString();

            for (int iItem = 0; iItem < choiceImage.dataItems.Children.Count; iItem++)
            {
                if (choiceImage.dataItems.Children[iItem].GetType() == typeof(BoxImage))
                {
                    BoxImage image = (BoxImage)choiceImage.dataItems.Children[iItem];
                    if(image.Value == copyValue)
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

        /// <summary>
        /// Enter the backgroundcolor chosen.
        /// </summary>
        public static readonly BindableProperty BackgroundColorChosenProperty = BindableProperty.Create(
            propertyName: nameof(BackgroundColorChosen),
            returnType: typeof(Color),
            declaringType: typeof(ChoiceImage),
            defaultValue: Color.Gold,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BackgroundColorChosenPropertyChanged);

        /// <summary>
        /// Enter the backgroundcolor unchosen.
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
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            Color copyColor = (Color)newValue;
            for (int iNS = 0; iNS < choiceImage.dataItems.Children.Count; iNS++)
            {
                BoxImage image = (BoxImage)choiceImage.dataItems.Children[iNS];
                image.BackgroundColorChosen = copyColor;
            }
        }

        /// <summary>
        /// Enter the BorderRadius.
        /// </summary>
        public static readonly BindableProperty BorderRadiusProperty = BindableProperty.Create(
            propertyName: nameof(BorderRadius),
            returnType: typeof(int),
            declaringType: typeof(ChoiceImage),
            defaultValue: 0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BorderRadiusPropertyChanged);

        /// <summary>
        /// Enter the BorderRadius.
        /// </summary>
        public int BorderRadius
        {
            get
            {
                return (int)GetValue(BorderRadiusProperty);
            }
            set
            {
                SetValue(BorderRadiusProperty, value);
            }
        }

        private static void BorderRadiusPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            int copyBorderRadius = (int)newValue;
            for (int iNS = 0; iNS < choiceImage.dataItems.Children.Count; iNS++)
            {
                BoxImage image = (BoxImage)choiceImage.dataItems.Children[iNS];
                image.CornerRadius = copyBorderRadius;
            }
        }

        /// <summary>
        /// Enter the BorderColorChosen.
        /// </summary>
        public static readonly BindableProperty BorderColorChosenProperty = BindableProperty.Create(
            propertyName: nameof(BorderColorChosen),
            returnType: typeof(Color),
            declaringType: typeof(ChoiceImage),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BorderColorChosenPropertyChanged);

        /// <summary>
        /// Enter the BorderColorChosen.
        /// </summary>
        public Color BorderColorChosen
        {
            get
            {
                return (Color)GetValue(BorderColorChosenProperty);
            }
            set
            {
                SetValue(BorderColorChosenProperty, value);
            }
        }

        private static void BorderColorChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            Color copyBorderColorChosen = (Color)newValue;
            for (int iNS = 0; iNS < choiceImage.dataItems.Children.Count; iNS++)
            {
                BoxImage image = (BoxImage)choiceImage.dataItems.Children[iNS];
                image.BorderColorChosen = copyBorderColorChosen;
            }
        }

        /// <summary>
        /// Enter ListItems(Data items).
        /// </summary>
        public static readonly BindableProperty ListItemsProperty = BindableProperty.Create(
            propertyName: nameof(ListItems),
            returnType: typeof(IEnumerable),
            declaringType: typeof(ChoiceImage),
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
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            choiceImage.items = (IEnumerable)newValue;
            choiceImage.InitAllBindable();
        }

        /// <summary>
        /// Enter the ValueField, only when using list.
        /// </summary>
        public static readonly BindableProperty ValueFieldProperty = BindableProperty.Create(
            propertyName: nameof(ValueField),
            returnType: typeof(string),
            declaringType: typeof(ChoiceImage),
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
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            choiceImage.InitAllBindable();
        }

        /// <summary>
        /// Enter the ValueField, only when using list.
        /// </summary>
        public static readonly BindableProperty ImageSourceFieldProperty = BindableProperty.Create(
            propertyName: nameof(ImageSourceField),
            returnType: typeof(string),
            declaringType: typeof(ChoiceImage),
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
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            choiceImage.InitAllBindable();
        }

        /// <summary>
        /// Enter the MarginLeftItems.
        /// </summary>
        public static readonly BindableProperty MarginLeftItemsProperty = BindableProperty.Create(
            propertyName: nameof(MarginLeftItems),
            returnType: typeof(int),
            declaringType: typeof(ChoiceImage),
            defaultValue: 15,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: MarginLeftItemsPropertyChanged);

        /// <summary>
        /// Enter the MarginLeftItems.
        /// </summary>
        public int MarginLeftItems
        {
            get
            {
                return (int)GetValue(MarginLeftItemsProperty);
            }
            set
            {
                SetValue(MarginLeftItemsProperty, value);
            }
        }

        private static void MarginLeftItemsPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            int marginLeft = (int)newValue;
            choiceImage.dataItems.Margin = new Thickness(marginLeft, 0, 0, 0);
        }

        /// <summary>
        /// Enter the MarginRightItems.
        /// </summary>
        public static readonly BindableProperty MarginRightItemsProperty = BindableProperty.Create(
            propertyName: nameof(MarginRightItems),
            returnType: typeof(int),
            declaringType: typeof(ChoiceImage),
            defaultValue: 15,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: MarginRightItemsPropertyChanged);

        /// <summary>
        /// Enter the MarginRightItems.
        /// </summary>
        public int MarginRightItems
        {
            get
            {
                return (int)GetValue(MarginRightItemsProperty);
            }
            set
            {
                SetValue(MarginRightItemsProperty, value);
            }
        }

        private static void MarginRightItemsPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            int marginRight = (int)newValue;
            choiceImage.dataItems.Padding = new Thickness(0, 0, marginRight, 0);
        }

        /// <summary>
        /// Enter Widht.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(ChoiceImage),
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
                return (double)GetValue(MarginRightItemsProperty);
            }
            set
            {
                SetValue(MarginRightItemsProperty, value);
            }
        }

        private static void WidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            double width = (double)newValue;
            choiceImage.ChangeWidthRequest(width);
        }

        private void ChangeWidthRequest(double w)
        {
            base.WidthRequest = w;
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty WidthRequestProperty = BindableProperty.Create(
            propertyName: nameof(WidthRequest),
            returnType: typeof(double),
            declaringType: typeof(ChoiceImage),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Deprecate.
        /// </summary>
        [Obsolete]
        public new double WidthRequest
        {
            get
            {
                return (double)GetValue(WidthRequestProperty);
            }
            set { }
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty HeightRequestProperty = BindableProperty.Create(
            propertyName: nameof(HeightRequest),
            returnType: typeof(double),
            declaringType: typeof(ChoiceImage),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Deprecate.
        /// </summary>
        [Obsolete]
        public new double HeightRequest
        {
            get
            {
                return (double)GetValue(HeightRequestProperty);
            }
            set { }
        }

        /// <summary>
        /// Enter the HeightItems.
        /// </summary>
        public static readonly BindableProperty HeightItemsProperty = BindableProperty.Create(
            propertyName: nameof(HeightItems),
            returnType: typeof(double),
            declaringType: typeof(ChoiceImage),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightItemsPropertyChanged);

        /// <summary>
        /// Enter the HeightItems.
        /// </summary>
        public double HeightItems
        {
            get
            {
                return (double)GetValue(HeightItemsProperty);
            }
            set
            {
                SetValue(HeightItemsProperty, value);
            }
        }

        private static void HeightItemsPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            double heightItem = (double)newValue;
            for (int iCh = 0; iCh < choiceImage.dataItems.Children.Count; iCh++)
            {
                BoxImage image = (BoxImage)choiceImage.dataItems.Children[iCh];
                image.Height = heightItem;
            }

        }

        /// <summary>
        /// Enter the WidthItems.
        /// </summary>
        public static readonly BindableProperty WidthItemsProperty = BindableProperty.Create(
            propertyName: nameof(WidthItems),
            returnType: typeof(double),
            declaringType: typeof(ChoiceImage),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthItemsPropertyChanged);

        /// <summary>
        /// Enter the WidthItems.
        /// </summary>
        public double WidthItems
        {
            get
            {
                return (double)GetValue(HeightItemsProperty);
            }
            set
            {
                SetValue(HeightItemsProperty, value);
            }
        }

        private static void WidthItemsPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            double widthItem = (double)newValue;
            for (int iCh = 0; iCh < choiceImage.dataItems.Children.Count; iCh++)
            {
                BoxImage image = (BoxImage)choiceImage.dataItems.Children[iCh];
                image.Width = widthItem;
            }
        }

        /// <summary>
        /// Enter the Height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(ChoiceImage),
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
            ChoiceImage choiceImage = (ChoiceImage)bindable;
            double height = (double)newValue;
            choiceImage.ChangeHeightBase(height);
        }

        private void ChangeHeightBase(double r)
        {
            base.HeightRequest = r;
        }

        private void InitAllBindable()
        {
            ChoiceImage choiceImage = this;

            if (choiceImage.items != null && !string.IsNullOrEmpty(choiceImage.ImageSourceField))
            {
                dataItems.Children.Clear();

                ChoiceImageItem choiceImageItem = new ChoiceImageItem();
                choiceImageItem.Value = ValueField;
                choiceImageItem.Image = ImageSourceField;

                BoxImage image = new BoxImage("__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl", this, choiceImageItem.Value, choiceImageItem.Image, currentIndex, vivacity, depth, vivacitySpeed);
                image.Width = WidthItems;
                image.MinimumWidthRequest = WidthItems;
                image.Height = HeightItems;
                image.HeightRequest = HeightItems;
                image.BorderColorChosen = BorderColorChosen;
                image.BackgroundColorChosen = BackgroundColorChosen;

                if ((InitialIndexChosen != -1 && InitialIndexChosen == currentIndex) || (InitialValueChosen != "_laavor_nothing_2018_77" && InitialValueChosen == image.Value))
                {
                    image.IsChosen = true;
                }

                dataItems.Children.Add(image);

                currentIndex++;
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(ChoiceImageItem))
            {
                ChoiceImageItem choiceImageItem = (ChoiceImageItem)child;
                BoxImage image = new BoxImage("__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl", this, choiceImageItem.Value, choiceImageItem.Image, currentIndex, vivacity, depth, vivacitySpeed);
                image.Width = WidthItems;
                image.Height = HeightItems;
                image.BorderColorChosen = BorderColorChosen;
                image.BackgroundColorChosen = BackgroundColorChosen;
                
                if ((InitialIndexChosen != -1 && InitialIndexChosen == currentIndex) || (InitialValueChosen != "_laavor_nothing_2018_77" && InitialValueChosen == image.Value))
                {
                    image.IsChosen = true;
                }
                   
                dataItems.Children.Add(image);

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
            for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
            {
                if (dataItems.Children[iItem].GetType() == typeof(BoxImage))
                {
                    BoxImage boxImage = (BoxImage)dataItems.Children[iItem];
                    boxImage.ChangeVivacity("__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl", vivacity, depth, vivacitySpeed);
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
                DepthPropertyChanged();
            }
        }

        private void DepthPropertyChanged()
        {
            VivacityPropertyChanged();
        }

        /// <summary>
        /// VivacitySpeed changes speed vivacity touch. 
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
    }
}
