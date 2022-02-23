using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorCheckBoxRadio
{
    /// <summary>
    /// Class RadioButton
    /// </summary>
    public class RadioButton : StackLayout
    {
        /// <summary>
        /// Value of item selected
        /// </summary>
        public string ValueSelected { get; private set; }

        /// <summary>
        /// Text of item selected
        /// </summary>
        public string TextSelected { get; private set; }

        /// <summary>
        /// Index of item selected
        /// </summary>
        public int IndexSelected { get; private set; }

        /// <summary>
        /// Event call When Selected Item is changed
        /// </summary>
        public event EventHandler OnChangeSelected;

        ///// <summary>
        ///// Internal use.
        ///// </summary>
        //private StackLayout dataItems;
        private Grid gridReference;

        private ColorUI currentColorUI;
        private DesignType currentDesignType;
        private ColorUI currentTextColor = ColorUI.Black;
        private TouchType touchType = TouchType.WithText;

        private IEnumerable items = null;

        private int currentIndex = 0;

        private List<RadioBox> listRadioBox;

        private Vivacity currentVivacity = Vivacity.Decrease;
        private Depth currentDepth = Depth.Medium;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;

        private int lastIndexChosen;

        /// <summary>
        /// Constructor of RadioButton
        /// </summary>
        public RadioButton() : base()
        {
            InitAll();
        }

        private void InitAll()
        {
            Orientation = StackOrientation.Vertical;

            currentIndex = 0;

            lastIndexChosen = 0;

            this.Children.Clear();
            this.Spacing = 0;

            listRadioBox = new List<RadioBox>();

            TextSelected = "";
            IndexSelected = -1;
            ValueSelected = "";

            gridReference = new Grid();

            this.Children.Add(gridReference);
        }

        /// <summary>
        /// Clear the list Images - necessary insert ChoiceImageSwapItem again
        /// </summary>
        public void ResetAll()
        {
            InitAll();
        }

        /// <summary>
        /// Property to report if RadioButton is readonly.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(RadioButton),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: IsReadOnlyPropertyChanged);

        /// <summary>
        /// Property to report if RadioButton is readonly.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return (bool)GetValue(IsReadOnlyProperty);
            }
            set
            {
                SetValue(IsReadOnlyProperty, value);
            }
        }

        private static void IsReadOnlyPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RadioButton radioButton = (RadioButton)bindable;
            bool isReadOnly = (bool)newValue;

            if (radioButton.listRadioBox != null)
            {
                for (int iItem = 0; iItem < radioButton.listRadioBox.Count; iItem++)
                {
                    if (radioButton.listRadioBox[iItem].RadioImage != null)
                    {
                        if (isReadOnly)
                        {
                            radioButton.listRadioBox[iItem].RadioImage.GestureRecognizers.Clear();
                            radioButton.listRadioBox[iItem].RadioImage.Opacity = 0.25;

                            radioButton.listRadioBox[iItem].LabelRadio.GestureRecognizers.Clear();
                            radioButton.listRadioBox[iItem].LabelRadio.Opacity = 0.25;
                        }
                        else
                        {
                            radioButton.listRadioBox[iItem].RadioImage.GestureRecognizers.Clear();
                            if (radioButton.listRadioBox[iItem].RadioImage.GestureRecognizers.Count == 0)
                            {
                                radioButton.listRadioBox[iItem].RadioImage.GestureRecognizers.Add(radioButton.GetClickChosen());
                            }

                            if (radioButton.currentVivacity != Vivacity.None)
                            {
                                if (radioButton.listRadioBox[iItem].RadioImage.GestureRecognizers.Count == 1)
                                {
                                    radioButton.listRadioBox[iItem].RadioImage.GestureRecognizers.Add(radioButton.GetVivacity());
                                }
                            }

                            radioButton.listRadioBox[iItem].RadioImage.Opacity = 1;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Property inform initial index selected of RadioButton.
        /// </summary>
        public static readonly BindableProperty InitialIndexProperty = BindableProperty.Create(
                 propertyName: nameof(InitialIndex),
                 returnType: typeof(int),
                 declaringType: typeof(RadioButton),
                 defaultValue: -1,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: InitialIndexPropertyChanged);

        /// <summary>
        /// Property inform initial index selected of RadioButton.
        /// </summary>
        public int InitialIndex
        {
            get
            {
                return (int)GetValue(InitialIndexProperty);
            }
            set
            {
                SetValue(InitialIndexProperty, value);
            }
        }

        private static void InitialIndexPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RadioButton radioButton = (RadioButton)bindable;
            int initialIndex = (int)newValue;

            if (initialIndex != -1)
            {
                if (radioButton.listRadioBox != null)
                {
                    for (int iItem = 0; iItem < radioButton.listRadioBox.Count; iItem++)
                    {
                        if (radioButton.listRadioBox[iItem].RadioImage != null)
                        {
                            if (radioButton.listRadioBox[iItem].RadioImage.Index == initialIndex)
                            {
                                radioButton.listRadioBox[iItem].RadioImage.ChangeState("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", true);
                                radioButton.IndexSelected = radioButton.listRadioBox[iItem].RadioImage.Index;
                                radioButton.ValueSelected = radioButton.listRadioBox[iItem].RadioImage.Value;
                                radioButton.TextSelected = radioButton.listRadioBox[iItem].LabelRadio.Text;
                            }
                            else
                            {
                                radioButton.listRadioBox[iItem].RadioImage.ChangeState("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", false);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Property inform initial value selected of RadioButton.
        /// </summary>
        public static readonly BindableProperty InitialValueProperty = BindableProperty.Create(
                 propertyName: nameof(InitialValue),
                 returnType: typeof(string),
                 declaringType: typeof(RadioButton),
                 defaultValue: "",
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: InitialValuePropertyChanged);

        /// <summary>
        /// Property inform initial value selected of RadioButton.
        /// </summary>
        public string InitialValue
        {
            get
            {
                return (string)GetValue(InitialValueProperty);
            }
            set
            {
                SetValue(InitialValueProperty, value);
            }
        }

        private static void InitialValuePropertyChanged(object bindable, object oldValue, object newValue)
        {
            RadioButton radioButton = (RadioButton)bindable;
            string initialValue = (string)newValue;

            if (!string.IsNullOrEmpty(initialValue))
            {
                if (radioButton.listRadioBox != null)
                {
                    for (int iItem = 0; iItem < radioButton.listRadioBox.Count; iItem++)
                    {
                        if (radioButton.listRadioBox[iItem].RadioImage != null)
                        {
                            if (radioButton.listRadioBox[iItem].RadioImage.Value == initialValue)
                            {
                                radioButton.listRadioBox[iItem].RadioImage.ChangeState("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", true);
                                radioButton.IndexSelected = radioButton.listRadioBox[iItem].RadioImage.Index;
                                radioButton.ValueSelected = radioButton.listRadioBox[iItem].RadioImage.Value;
                                radioButton.TextSelected = radioButton.listRadioBox[iItem].LabelRadio.Text;
                            }
                            else
                            {
                                radioButton.listRadioBox[iItem].RadioImage.ChangeState("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", false);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Set if is ColorUI
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
                ColorUIPropertyChanged();
            }
        }

        private void ColorUIPropertyChanged()
        {
            if (listRadioBox != null)
            {
                for (int iItem = 0; iItem < listRadioBox.Count; iItem++)
                {
                    if (listRadioBox[iItem].RadioImage != null)
                    {
                        listRadioBox[iItem].RadioImage.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorUI);
                    }
                }
            }
        }

        /// <summary>
        /// Set if is TouchType
        /// </summary>
        [Bindable(true)]
        public TouchType TouchType
        {
            get
            {
                return touchType;
            }
            set
            {
                touchType = value;
                TouchTypePropertyChanged();
            }
        }

        private void TouchTypePropertyChanged()
        {
            VivacityPropertyChanged();
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
                DesignTypePropertyChanged(this, currentDesignType, value);
            }
        }

        private static void DesignTypePropertyChanged(object bindable, object oldValue, object newValue)
        {
            RadioButton radioButton = (RadioButton)bindable;
            DesignType copyDesignType = (DesignType)newValue;

            if (radioButton.listRadioBox != null)
            {
                for (int iItem = 0; iItem < radioButton.listRadioBox.Count; iItem++)
                {
                    if (radioButton.listRadioBox[iItem].RadioImage != null)
                    {
                        radioButton.listRadioBox[iItem].RadioImage.ChangeDesignType("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", copyDesignType);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the height, represents only one radioitem.
        /// </summary>
        public static readonly BindableProperty HeightItemProperty = BindableProperty.Create(
            propertyName: nameof(HeightItem),
            returnType: typeof(double),
            declaringType: typeof(RadioButton),
            defaultValue: 40.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightItemPropertyChanged);

        /// <summary>
        /// Enter the height, represents only one radioitem.
        /// </summary>
        public double HeightItem
        {
            get
            {
                return (double)GetValue(HeightItemProperty);
            }
            set
            {
                SetValue(HeightItemProperty, value);
            }
        }

        private static void HeightItemPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RadioButton radioButton = (RadioButton)bindable;
            double radioHeight = (double)newValue;

            if (radioButton.listRadioBox != null)
            {
                for (int iItem = 0; iItem < radioButton.listRadioBox.Count; iItem++)
                {
                    if (radioButton.listRadioBox[iItem].RadioImage != null)
                    {
                        radioButton.listRadioBox[iItem].RadioImage.HeightRequest = radioHeight;
                        radioButton.listRadioBox[iItem].RadioImage.MinimumHeightRequest = radioHeight;
                    }
                }
            }
        }

        /// <summary>
        /// Enter the width, represents only one radioitem.
        /// </summary>
        public static readonly BindableProperty WidthItemProperty = BindableProperty.Create(
            propertyName: nameof(WidthItem),
            returnType: typeof(double),
            declaringType: typeof(RadioButton),
            defaultValue: 40.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthItemPropertyChanged);

        /// <summary>
        /// Enter the width, represents only one radioitem.
        /// </summary>
        public double WidthItem
        {
            get
            {
                return (double)GetValue(WidthItemProperty);
            }
            set
            {
                SetValue(WidthItemProperty, value);
            }
        }

        private static void WidthItemPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RadioButton radioButton = (RadioButton)bindable;
            double radioWidth = (double)newValue;

            if (radioButton.listRadioBox != null)
            {
                for (int iItem = 0; iItem < radioButton.listRadioBox.Count; iItem++)
                {
                    if (radioButton.listRadioBox[iItem].RadioImage == null)
                    {
                        radioButton.listRadioBox[iItem].RadioImage.WidthRequest = radioWidth;
                        radioButton.listRadioBox[iItem].RadioImage.MinimumWidthRequest = radioWidth;
                    }
                }
            }
        }

        /// <summary>
        /// Enter the font size of text.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(RadioButton),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size of text.
        /// </summary>
        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        private static void FontSizePropertyChanged(object bindable, object oldValue, object newValue)
        {
            RadioButton radioButton = (RadioButton)bindable;
            double fontSize = (double)newValue;

            if (radioButton.listRadioBox != null)
            {
                for (int iItem = 0; iItem < radioButton.listRadioBox.Count; iItem++)
                {
                    if (radioButton.listRadioBox[iItem].LabelRadio != null)
                    {
                        radioButton.listRadioBox[iItem].LabelRadio.FontSize = fontSize;
                    }
                }
            }
        }

        /// <summary>
        /// Set TextColor
        /// </summary>
        [Bindable(true)]
        public ColorUI TextColor
        {
            get
            {
                return currentTextColor;
            }
            set
            {
                currentTextColor = value;
                TextColorPropertyChanged();
            }
        }

        private void TextColorPropertyChanged()
        {
            if (listRadioBox != null)
            {
                for (int iItem = 0; iItem < listRadioBox.Count; iItem++)
                {
                    if (listRadioBox[iItem].LabelRadio != null)
                    {
                        listRadioBox[iItem].LabelRadio.TextColor = Colors.Get(currentTextColor);
                    }
                }
            }
        }

        /// <summary>
        /// Enter ListItems (Data items).
        /// </summary>
        public static readonly BindableProperty ListItemsProperty = BindableProperty.Create(
            propertyName: nameof(ListItems),
            returnType: typeof(IEnumerable),
            declaringType: typeof(RadioButton),
            defaultBindingMode: BindingMode.OneWay,
            defaultValue: null,
            propertyChanged: ListItemsPropertyChanged);

        /// <summary>
        /// Enter ListItems (Data items).
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
            RadioButton radioButton = (RadioButton)bindable;
            radioButton.items = (IEnumerable)newValue;
            radioButton.InitAllBindable(radioButton);
        }

        /// <summary>
        /// Enter the ValueField, only when using list.
        /// </summary>
        public static readonly BindableProperty ValueFieldProperty = BindableProperty.Create(
            propertyName: nameof(ValueField),
            returnType: typeof(string),
            declaringType: typeof(RadioButton),
            defaultValue: null,
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
            RadioButton radioButton = (RadioButton)bindable;
            radioButton.InitAllBindable(radioButton);
        }

        /// <summary>
        /// Enter the TextField, only when using list.
        /// </summary>
        public static readonly BindableProperty TextFieldProperty = BindableProperty.Create(
            propertyName: nameof(TextField),
            returnType: typeof(string),
            declaringType: typeof(RadioButton),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextFieldPropertyChanged);

        /// <summary>
        /// Enter the TextField, only when using list.
        /// </summary>
        public string TextField
        {
            get
            {
                return (string)GetValue(TextFieldProperty);
            }
            set
            {
                SetValue(TextFieldProperty, value);
                InitAllBindable(this);
            }
        }

        private static void TextFieldPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RadioButton radioButton = (RadioButton)bindable;
            radioButton.InitAllBindable(radioButton);
        }

        /// <summary>
        /// Enter the RowField, only when using list.
        /// </summary>
        public static readonly BindableProperty RowFieldProperty = BindableProperty.Create(
            propertyName: nameof(RowField),
            returnType: typeof(string),
            declaringType: typeof(RadioButton),
            defaultBindingMode: BindingMode.OneWay,
            defaultValue: "",
            propertyChanged: RowFieldPropertyChanged);

        /// <summary>
        /// Enter the RowField, only when using list.
        /// </summary>
        public string RowField
        {
            get
            {
                return (string)GetValue(RowFieldProperty);
            }
            set
            {
                SetValue(RowFieldProperty, value);
                InitAllBindable(this);
            }
        }

        private static void RowFieldPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RadioButton radioButton = (RadioButton)bindable;
            radioButton.InitAllBindable(radioButton);
        }

        /// <summary>
        /// Enter the ColField, only when using list.
        /// </summary>
        public static readonly BindableProperty ColFieldProperty = BindableProperty.Create(
            propertyName: nameof(ColField),
            returnType: typeof(string),
            declaringType: typeof(RadioButton),
            defaultBindingMode: BindingMode.OneWay,
            defaultValue: "",
            propertyChanged: ColFieldPropertyChanged);

        /// <summary>
        /// Enter the ColField, only when using list.
        /// </summary>
        public string ColField
        {
            get
            {
                return (string)GetValue(ColFieldProperty);
            }
            set
            {
                SetValue(ColFieldProperty, value);
                InitAllBindable(this);
            }
        }

        private static void ColFieldPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RadioButton radioButton = (RadioButton)bindable;
            radioButton.InitAllBindable(radioButton);
        }

        private void InitAllBindable(object sender)
        {
            RadioButton radioButton = (RadioButton)sender;

            bool hasFirstItem = false;
            if (radioButton.items != null && !string.IsNullOrEmpty(radioButton.TextField) && !string.IsNullOrEmpty(radioButton.ValueField))
            {
                gridReference.Children.Clear();
                var enumerator = radioButton.items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object obj = enumerator.Current;
                    string textObj = obj.GetType().GetProperty(radioButton.TextField).GetValue(obj).ToString();
                    string valueObj = obj.GetType().GetProperty(radioButton.ValueField).GetValue(obj).ToString();

                    bool hasRowCol = false;
                    int row = -1;
                    int col = -1;
                    if (!string.IsNullOrEmpty(radioButton.RowField) || !string.IsNullOrEmpty(radioButton.ColField))
                    {
                        string rowObj = "";
                        string colObj = "";

                        try
                        {
                            rowObj = obj.GetType().GetProperty(radioButton.RowField).GetValue(obj).ToString();
                            colObj = obj.GetType().GetProperty(radioButton.ColField).GetValue(obj).ToString();
                        }
                        catch { }

                        if (!string.IsNullOrEmpty(rowObj) && !string.IsNullOrEmpty(colObj))
                        {
                            int.TryParse(rowObj, out row);
                            int.TryParse(colObj, out col);

                            if (row >= 0 && col >= 0)
                            {
                                hasRowCol = true;
                            }
                        }
                    }

                    RadioImage radioImage;


                    if ((InitialIndex != -1 && InitialIndex == currentIndex) || (currentIndex == 0 && InitialIndex == -1 && string.IsNullOrEmpty(InitialValue)))
                    {
                        radioImage = new RadioImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", DesignType, ColorUI, true, currentIndex, valueObj);
                        IndexSelected = currentIndex;
                        ValueSelected = valueObj;
                        TextSelected = textObj;
                        lastIndexChosen = currentIndex;
                        hasFirstItem = true;
                    }
                    else if (!string.IsNullOrEmpty(InitialValue) && InitialValue == valueObj && InitialIndex == -1)
                    {
                        radioImage = new RadioImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", DesignType, ColorUI, true, currentIndex, valueObj);
                        IndexSelected = currentIndex;
                        ValueSelected = valueObj;
                        TextSelected = textObj;
                        lastIndexChosen = currentIndex;
                        hasFirstItem = true;
                    }
                    else
                    {
                        radioImage = new RadioImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", DesignType, ColorUI, false, currentIndex, valueObj);
                    }

                    radioImage.WidthRequest = WidthItem;
                    radioImage.MinimumWidthRequest = WidthItem;
                    radioImage.HeightRequest = HeightItem;
                    radioImage.MinimumWidthRequest = HeightItem;

                    LabelRadio label = new LabelRadio();
                    label.FontSize = FontSize;
                    label.FontFamily = FontFamily;
                    label.TextColor = Colors.Get(currentTextColor);
                    label.Text = textObj;

                    if (IsReadOnly)
                    {
                        radioImage.GestureRecognizers.Clear();
                        label.GestureRecognizers.Clear();

                        radioImage.Opacity = 0.25;
                        label.Opacity = 0.25;
                    }
                    else
                    {
                        radioImage.Opacity = 1;
                        label.Opacity = 1;

                        radioImage.GestureRecognizers.Add(GetClickChosen());

                        if (touchType == TouchType.WithText)
                        {
                            label.GestureRecognizers.Add(GetClickChosen());
                        }

                        if (radioButton.Vivacity != Vivacity.None)
                        {
                            radioImage.GestureRecognizers.Add(GetVivacity());

                            if (touchType == TouchType.WithText)
                            {
                                label.GestureRecognizers.Add(GetVivacity());
                            }
                        }
                    }

                    label.setImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", radioImage);
                    radioImage.setLabel("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", label);

                    listRadioBox.Insert(currentIndex, new RadioBox() { RadioImage = radioImage, LabelRadio = label });

                    StackLayout stackInternal = new StackLayout();
                    stackInternal.Spacing = 0;
                    stackInternal.Orientation = StackOrientation.Horizontal;

                    stackInternal.Children.Add(radioImage);
                    stackInternal.Children.Add(label);

                    if (hasRowCol)
                    {
                        Grid.SetRow(stackInternal, row);
                    }
                    else
                    {
                        Grid.SetRow(stackInternal, currentIndex);
                    }

                    if (hasRowCol)
                    {
                        Grid.SetColumn(stackInternal, col);
                    }

                    gridReference.Children.Add(stackInternal);

                    currentIndex++;
                }

                if (!hasFirstItem)
                {
                    if (listRadioBox != null && listRadioBox.Count > 0)
                    {
                        listRadioBox[0].RadioImage.ChangeState("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", true);
                    }
                    hasFirstItem = true;
                }
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(RadioButton),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontFamilyPropertyChanged);

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public string FontFamily
        {
            get
            {
                return (string)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
            }
        }

        private static void FontFamilyPropertyChanged(object bindable, object oldValue, object newValue)
        {
            RadioButton radioButton = (RadioButton)bindable;
            string fontFamily = (string)newValue;

            if (radioButton.listRadioBox != null)
            {
                for (int iItem = 0; iItem < radioButton.listRadioBox.Count; iItem++)
                {
                    if (radioButton.listRadioBox[iItem].LabelRadio != null)
                    {
                        radioButton.listRadioBox[iItem].LabelRadio.FontFamily = fontFamily;
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
                return currentVivacitySpeed;
            }
            set
            {
                currentVivacitySpeed = value;
                VivacityPropertyChanged();
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
            if (!IsReadOnly)
            {
                if (listRadioBox != null)
                {
                    for (int iItem = 0; iItem < listRadioBox.Count; iItem++)
                    {
                        listRadioBox[iItem].RadioImage.Opacity = 1;
                        listRadioBox[iItem].LabelRadio.Opacity = 1;

                        if (listRadioBox[iItem].RadioImage != null && listRadioBox[iItem].LabelRadio != null)
                        {
                            if (currentVivacity != Vivacity.None)
                            {
                                listRadioBox[iItem].RadioImage.GestureRecognizers.Clear();

                                if (listRadioBox[iItem].RadioImage.GestureRecognizers.Count == 0)
                                {
                                    listRadioBox[iItem].RadioImage.GestureRecognizers.Add(GetClickChosen());
                                }

                                if (touchType == TouchType.WithText)
                                {
                                    if (listRadioBox[iItem].LabelRadio.GestureRecognizers.Count == 0)
                                    {
                                        listRadioBox[iItem].LabelRadio.GestureRecognizers.Add(GetClickChosen());
                                    }
                                }

                                if (currentVivacity != Vivacity.None)
                                {
                                    if (listRadioBox[iItem].RadioImage.GestureRecognizers.Count == 1)
                                    {
                                        listRadioBox[iItem].RadioImage.GestureRecognizers.Add(GetVivacity());
                                    }

                                    if (touchType == TouchType.WithText)
                                    {
                                        if (listRadioBox[iItem].LabelRadio.GestureRecognizers.Count == 1)
                                        {
                                            listRadioBox[iItem].LabelRadio.GestureRecognizers.Add(GetVivacity());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                listRadioBox[iItem].RadioImage.GestureRecognizers.Clear();

                                if (currentVivacity != Vivacity.None && listRadioBox[iItem].RadioImage.GestureRecognizers.Count == 0)
                                {
                                    listRadioBox[iItem].RadioImage.GestureRecognizers.Add(GetVivacity());
                                }

                                if (currentVivacity == Vivacity.None && listRadioBox[iItem].RadioImage.GestureRecognizers.Count == 0)
                                {
                                    listRadioBox[iItem].RadioImage.GestureRecognizers.Add(GetClickChosen());
                                }
                                else if (listRadioBox[iItem].RadioImage.GestureRecognizers.Count == 1)
                                {
                                    listRadioBox[iItem].RadioImage.GestureRecognizers.Add(GetClickChosen());
                                }


                                if (touchType == TouchType.WithText)
                                {
                                    listRadioBox[iItem].LabelRadio.GestureRecognizers.Clear();

                                    if (currentVivacity != Vivacity.None)
                                    {
                                        listRadioBox[iItem].LabelRadio.GestureRecognizers.Add(GetVivacity());
                                    }

                                    if (currentVivacity == Vivacity.None && listRadioBox[iItem].LabelRadio.GestureRecognizers.Count == 0)
                                    {
                                        listRadioBox[iItem].LabelRadio.GestureRecognizers.Add(GetClickChosen());
                                    }
                                    else if (listRadioBox[iItem].LabelRadio.GestureRecognizers.Count == 1)
                                    {
                                        listRadioBox[iItem].LabelRadio.GestureRecognizers.Add(GetClickChosen());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int iItem = 0; iItem < listRadioBox.Count; iItem++)
                {
                    if (listRadioBox[iItem].RadioImage != null && listRadioBox[iItem].LabelRadio != null)
                    {
                        listRadioBox[iItem].RadioImage.GestureRecognizers.Clear();
                        listRadioBox[iItem].LabelRadio.GestureRecognizers.Clear();

                        listRadioBox[iItem].RadioImage.Opacity = 0.25;
                        listRadioBox[iItem].LabelRadio.Opacity = 0.25;
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
            if (!IsReadOnly)
            {
                VivacityPropertyChanged();
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(RadioItem))
            {
                RadioItem radioItem = (RadioItem)child;
                RadioImage radioImage;

                if ((InitialIndex != -1 && InitialIndex == currentIndex) || ((currentIndex == 0 && InitialIndex == -1) && string.IsNullOrEmpty(InitialValue)))
                {
                    radioImage = new RadioImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", DesignType, ColorUI, true, currentIndex, radioItem.Value);
                    IndexSelected = currentIndex;
                    ValueSelected = radioItem.Value;
                    TextSelected = radioItem.Text;
                    lastIndexChosen = currentIndex;

                    if (currentIndex != 0 && listRadioBox.Count > 0)
                    {
                        listRadioBox[0].RadioImage.ChangeState("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", false);
                    }
                }
                else if (!string.IsNullOrEmpty(InitialValue) && InitialValue == radioItem.Value && InitialIndex == -1)
                {
                    radioImage = new RadioImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", DesignType, ColorUI, true, currentIndex, radioItem.Value);
                    IndexSelected = currentIndex;
                    ValueSelected = radioItem.Value;
                    TextSelected = radioItem.Text;
                    lastIndexChosen = currentIndex;

                    if (currentIndex != 0 && listRadioBox.Count > 0)
                    {
                        listRadioBox[0].RadioImage.ChangeState("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", false);
                    }
                }
                else
                {
                    if (currentIndex == 0)
                    {
                        radioImage = new RadioImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", DesignType, ColorUI, true, currentIndex, radioItem.Value);
                    }
                    else
                    {
                        radioImage = new RadioImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", DesignType, ColorUI, false, currentIndex, radioItem.Value);
                    }
                }



                radioImage.WidthRequest = WidthItem;
                radioImage.MinimumWidthRequest = WidthItem;
                radioImage.HeightRequest = HeightItem;
                radioImage.MinimumWidthRequest = HeightItem;

                LabelRadio label = new LabelRadio();
                label.FontSize = FontSize;
                label.FontFamily = FontFamily;
                label.TextColor = Colors.Get(currentTextColor);
                label.Text = radioItem.Text;
                label.VerticalOptions = LayoutOptions.Center;
                label.VerticalTextAlignment = TextAlignment.Center;

                if (IsReadOnly)
                {
                    radioImage.GestureRecognizers.Clear();
                    label.GestureRecognizers.Clear();

                    radioImage.Opacity = 0.25;
                    label.Opacity = 0.25;
                }
                else
                {
                    radioImage.Opacity = 1;
                    label.Opacity = 1;

                    radioImage.GestureRecognizers.Clear();

                    if (radioImage.GestureRecognizers.Count == 0)
                    {
                        radioImage.GestureRecognizers.Add(GetClickChosen());
                    }

                    if (touchType == TouchType.WithText)
                    {
                        if (label.GestureRecognizers.Count == 0)
                        {
                            label.GestureRecognizers.Add(GetClickChosen());
                        }
                    }

                    if (currentVivacity != Vivacity.None)
                    {
                        if (radioImage.GestureRecognizers.Count == 1)
                        {
                            radioImage.GestureRecognizers.Add(GetVivacity());
                        }

                        if (touchType == TouchType.WithText)
                        {
                            if (label.GestureRecognizers.Count == 1)
                            {
                                label.GestureRecognizers.Add(GetVivacity());
                            }
                        }
                    }
                }

                label.setImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", radioImage);
                radioImage.setLabel("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", label);

                listRadioBox.Insert(currentIndex, new RadioBox() { RadioImage = radioImage, LabelRadio = label });

                StackLayout stackInternal = new StackLayout();
                stackInternal.Orientation = StackOrientation.Horizontal;

                stackInternal.Children.Add(radioImage);
                stackInternal.Children.Add(label);

                if (radioItem.Row != null)
                {
                    Grid.SetRow(stackInternal, radioItem.Row.Value);
                }
                else
                {
                    Grid.SetRow(stackInternal, currentIndex);
                }

                if (radioItem.Col != null)
                {
                    Grid.SetColumn(stackInternal, radioItem.Col.Value);
                }

                gridReference.Children.Add(stackInternal);

                currentIndex++;
            }
        }

        private TapGestureRecognizer GetClickChosen()
        {
            TapGestureRecognizer tp = new TapGestureRecognizer();
            tp.Tapped += TouchRadio;
            return tp;
        }

        private void TouchRadio(object sender, EventArgs e)
        {
            RadioImage radioImage;
            LabelRadio labelImage;

            if (sender.GetType() == typeof(RadioImage))
            {
                radioImage = (RadioImage)sender;
                labelImage = radioImage.Label;
            }
            else
            {
                labelImage = (LabelRadio)sender;
                radioImage = labelImage.Image;
            }

            if (listRadioBox != null)
            {
                try
                {
                    if (listRadioBox[lastIndexChosen].RadioImage != null)
                    {
                        listRadioBox[lastIndexChosen].RadioImage.ChangeState("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", false);
                        listRadioBox[radioImage.Index].RadioImage.ChangeState("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", true);
                        lastIndexChosen = radioImage.Index;
                        IndexSelected = radioImage.Index;
                        ValueSelected = radioImage.Value;

                        if (listRadioBox[radioImage.Index].LabelRadio != null)
                        {
                            TextSelected = listRadioBox[radioImage.Index].LabelRadio.Text;
                        }
                    }
                }
                catch { }
            }

            OnChangeSelected?.Invoke(this, EventArgs.Empty);
        }

        private TapGestureRecognizer GetVivacity()
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + currentVivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            TapGestureRecognizer touchAnimation = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);

            return touchAnimation;
        }

        private TapGestureRecognizer GetVivacityDecrease()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    RadioImage radioImage;
                    LabelRadio labelImage;

                    if (sender.GetType() == typeof(RadioImage))
                    {
                        radioImage = (RadioImage)sender;
                        labelImage = radioImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelRadio)sender;
                        radioImage = labelImage.Image;
                    }

                    await radioImage.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await radioImage.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                }
                catch { }
            };

            return vivacityTap;
        }

        private double GetDepthDecrease(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 0.80;
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

        private TapGestureRecognizer GetVivacityIncrease()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    RadioImage radioImage;
                    LabelRadio labelImage;

                    if (sender.GetType() == typeof(RadioImage))
                    {
                        radioImage = (RadioImage)sender;
                        labelImage = radioImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelRadio)sender;
                        radioImage = labelImage.Image;
                    }

                    await radioImage.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await radioImage.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityRotation()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    RadioImage radioImage;
                    LabelRadio labelImage;

                    if (sender.GetType() == typeof(RadioImage))
                    {
                        radioImage = (RadioImage)sender;
                        labelImage = radioImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelRadio)sender;
                        radioImage = labelImage.Image;
                    }

                    await radioImage.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await radioImage.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
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

        private TapGestureRecognizer GetVivacityJump()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    RadioImage radioImage;
                    LabelRadio labelImage;

                    if (sender.GetType() == typeof(RadioImage))
                    {
                        radioImage = (RadioImage)sender;
                        labelImage = radioImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelRadio)sender;
                        radioImage = labelImage.Image;
                    }

                    await radioImage.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await radioImage.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                }
                catch { }
            };
            return animationTap;
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

        private TapGestureRecognizer GetVivacityDown()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    RadioImage radioImage;
                    LabelRadio labelImage;

                    if (sender.GetType() == typeof(RadioImage))
                    {
                        radioImage = (RadioImage)sender;
                        labelImage = radioImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelRadio)sender;
                        radioImage = labelImage.Image;
                    }

                    await radioImage.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await radioImage.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    RadioImage radioImage;
                    LabelRadio labelImage;

                    if (sender.GetType() == typeof(RadioImage))
                    {
                        radioImage = (RadioImage)sender;
                        labelImage = radioImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelRadio)sender;
                        radioImage = labelImage.Image;
                    }

                    await radioImage.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await radioImage.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    RadioImage radioImage;
                    LabelRadio labelImage;

                    if (sender.GetType() == typeof(RadioImage))
                    {
                        radioImage = (RadioImage)sender;
                        labelImage = radioImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelRadio)sender;
                        radioImage = labelImage.Image;
                    }

                    await radioImage.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await radioImage.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
