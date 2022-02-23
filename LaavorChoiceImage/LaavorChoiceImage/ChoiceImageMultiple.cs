using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorChoiceImage
{
    /// <summary>
    /// Class ChoiceImageMultiple
    /// </summary>
    public class ChoiceImageMultiple: StackLayout
    {
        /// <summary>
        /// Returns the List f the chosen items.
        /// </summary>
        public List<ChosenItem> ItemsChosen { get; private set; }

        private List<ChosenItem> allItemsChosen;
               
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

        private ChoiceOrientation currentOrientation = ChoiceOrientation.Horizontal;

        private Vivacity vivacity = Vivacity.Decrease;
        private Depth depth = Depth.Medium;
        private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

        private const double spaceDecrease = 0.5;
        /// <summary>
        /// Constructor of ChoiceImage
        /// </summary>
        public ChoiceImageMultiple() : base()
        {
            InitAll();
        }

        private void InitAll()
        {
            currentIndex = 0;

            this.HorizontalOptions = LayoutOptions.Center;

            ItemsChosen = new List<ChosenItem>();
            allItemsChosen = new List<ChosenItem>();

            this.Children.Clear();

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
        public void UpdateData(int index, string Key, bool chosen)
        {
            if (Key == "amebaprotozoarioindexDD1458**")
            {
                if(chosen)
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            ChoiceOrientation copyOrientation = newValue;

            if (copyOrientation == ChoiceOrientation.Horizontal)
            {
                choiceImageMultiple.scroll.Orientation = ScrollOrientation.Horizontal;
                choiceImageMultiple.dataItems.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                choiceImageMultiple.scroll.Orientation = ScrollOrientation.Vertical;
                choiceImageMultiple.dataItems.Orientation = StackOrientation.Vertical;
            }

            choiceImageMultiple.ChangeOrientation(copyOrientation);
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
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            int copyIndex = (int)newValue;
            for (int iLV = 0; iLV < choiceImageMultiple.dataItems.Children.Count; iLV++)
            {
                for (int iItem = 0; iItem < choiceImageMultiple.dataItems.Children.Count; iItem++)
                {
                    if (choiceImageMultiple.dataItems.Children[iItem].GetType() == typeof(BoxImageMultiple))
                    {
                        BoxImageMultiple image = (BoxImageMultiple)choiceImageMultiple.dataItems.Children[iItem];
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

        /// <summary>
        /// Enter the backgroundcolor chosen.
        /// </summary>
        public static readonly BindableProperty BackgroundColorChosenProperty = BindableProperty.Create(
            propertyName: nameof(BackgroundColorChosen),
            returnType: typeof(Color),
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            Color copyColor = (Color)newValue;
            for (int iNS = 0; iNS < choiceImageMultiple.dataItems.Children.Count; iNS++)
            {
                BoxImageMultiple image = (BoxImageMultiple)choiceImageMultiple.dataItems.Children[iNS];
                image.BackgroundColorChosen = copyColor;
            }
        }
        /// <summary>
        /// Enter the BorderColorChosen.
        /// </summary>
        public static readonly BindableProperty BorderColorChosenProperty = BindableProperty.Create(
            propertyName: nameof(BorderColorChosen),
            returnType: typeof(Color),
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            Color copyBorderColorChosen = (Color)newValue;
            for (int iNS = 0; iNS < choiceImageMultiple.dataItems.Children.Count; iNS++)
            {
                BoxImage image = (BoxImage)choiceImageMultiple.dataItems.Children[iNS];
                image.BorderColorChosen = copyBorderColorChosen;
            }
        }

        /// <summary>
        /// Enter ListItems(Data items).
        /// </summary>
        public static readonly BindableProperty ListItemsProperty = BindableProperty.Create(
            propertyName: nameof(ListItems),
            returnType: typeof(IEnumerable),
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            choiceImageMultiple.items = (IEnumerable)newValue;
            choiceImageMultiple.InitAllBindable();
        }

        /// <summary>
        /// Enter the ValueField, only when using list.
        /// </summary>
        public static readonly BindableProperty ValueFieldProperty = BindableProperty.Create(
            propertyName: nameof(ValueField),
            returnType: typeof(string),
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            choiceImageMultiple.InitAllBindable();
        }

        /// <summary>
        /// Enter the ValueField, only when using list.
        /// </summary>
        public static readonly BindableProperty ImageSourceFieldProperty = BindableProperty.Create(
            propertyName: nameof(ImageSourceField),
            returnType: typeof(string),
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            choiceImageMultiple.InitAllBindable();
        }

        /// <summary>
        /// Enter the MarginLeftItems.
        /// </summary>
        public static readonly BindableProperty MarginLeftItemsProperty = BindableProperty.Create(
            propertyName: nameof(MarginLeftItems),
            returnType: typeof(int),
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            int marginLeft = (int)newValue;
            choiceImageMultiple.dataItems.Margin = new Thickness(marginLeft, 0, 0, 0);
        }

        /// <summary>
        /// Enter the MarginRightItems.
        /// </summary>
        public static readonly BindableProperty MarginRightItemsProperty = BindableProperty.Create(
            propertyName: nameof(MarginRightItems),
            returnType: typeof(int),
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            int marginRight = (int)newValue;
            choiceImageMultiple.dataItems.Padding = new Thickness(0, 0, marginRight, 0);
        }

        /// <summary>
        /// Enter Widht.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            double width = (double)newValue;
            choiceImageMultiple.ChangeWidthRequest(width);
        }

        private void ChangeWidthRequest(double w)
        {
            base.WidthRequest = w;
            WidthRequest = w;
        }
      
        /// <summary>
        /// Enter the HeightItems.
        /// </summary>
        public static readonly BindableProperty HeightItemsProperty = BindableProperty.Create(
            propertyName: nameof(HeightItems),
            returnType: typeof(double),
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            double heightItem = (double)newValue;
            for (int iCh = 0; iCh < choiceImageMultiple.dataItems.Children.Count; iCh++)
            {
                BoxImageMultiple boxImageMultiple = (BoxImageMultiple)choiceImageMultiple.dataItems.Children[iCh];
                boxImageMultiple.Height = heightItem;
            }

        }

        /// <summary>
        /// Enter the WidthItems.
        /// </summary>
        public static readonly BindableProperty WidthItemsProperty = BindableProperty.Create(
            propertyName: nameof(WidthItems),
            returnType: typeof(double),
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            double widthItem = (double)newValue;
            for (int iCh = 0; iCh < choiceImageMultiple.dataItems.Children.Count; iCh++)
            {
                BoxImageMultiple boxImageMultiple = (BoxImageMultiple)choiceImageMultiple.dataItems.Children[iCh];
                boxImageMultiple.Width = widthItem;
            }
        }

        /// <summary>
        /// Enter the Height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(ChoiceImageMultiple),
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
            ChoiceImageMultiple choiceImageMultiple = (ChoiceImageMultiple)bindable;
            double height = (double)newValue;
            choiceImageMultiple.ChangeHeightBase(height);
        }

        private void ChangeHeightBase(double r)
        {
            base.HeightRequest = r;
        }

        private void InitAllBindable()
        {
            ChoiceImageMultiple choiceImageMultiple = this;

            if (choiceImageMultiple.items != null && !string.IsNullOrEmpty(choiceImageMultiple.ImageSourceField))
            {
                dataItems.Children.Clear();

                ChoiceImageItem choiceImageItem = new ChoiceImageItem();
                choiceImageItem.Value = ValueField;
                choiceImageItem.Image = ImageSourceField;

                BoxImageMultiple image = new BoxImageMultiple("__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl", this, choiceImageItem.Value, choiceImageItem.Image, currentIndex, vivacity, depth, vivacitySpeed);
                image.Width = WidthItems;
                image.WidthRequest = WidthItems;
                image.Height = HeightItems;
                image.HeightRequest = HeightItems;
                image.BorderColorChosen = BorderColorChosen;
                image.BackgroundColorChosen = BackgroundColorChosen;

                ChosenItem chosen = new ChosenItem(currentIndex, "", choiceImageItem.Value, choiceImageItem.Image);
                allItemsChosen.Insert(currentIndex, chosen);

                if (InitialIndexChosen != -1 && InitialIndexChosen == currentIndex)
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
                BoxImageMultiple image = new BoxImageMultiple("__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl", this, choiceImageItem.Value, choiceImageItem.Image, currentIndex, vivacity, depth, vivacitySpeed);
                image.Width = WidthItems;
                image.WidthRequest = WidthItems;
                image.Height = HeightItems;
                image.HeightRequest = HeightItems;
                image.BorderColorChosen = BorderColorChosen;
                image.BackgroundColorChosen = BackgroundColorChosen;

                ChosenItem chosen = new ChosenItem(currentIndex, "", choiceImageItem.Value, choiceImageItem.Image);
                allItemsChosen.Insert(currentIndex, chosen);

                if (InitialIndexChosen != -1 && InitialIndexChosen == currentIndex)
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
                    BoxImageMultiple boxImageMultiple = (BoxImageMultiple)dataItems.Children[iItem];
                    boxImageMultiple.ChangeVivacity("__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl", vivacity, depth, vivacitySpeed);
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
