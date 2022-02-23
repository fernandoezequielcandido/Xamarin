using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// Class RadioButton
        /// </summary>
        public class RadioButton : StackLayout
        {
            /// <summary>
            /// Value of item chosen
            /// </summary>
            public string ValueChosen { get; private set; }

            /// <summary>
            /// Text of item chosen
            /// </summary>
            public string TextChosen { get; private set; }

            /// <summary>
            /// Index of item chosen
            /// </summary>
            public int IndexChosen { get; private set; }

            /// <summary>
            /// Event call When Item is Chosen
            /// </summary>
            public event EventHandler Chosen;

            private Grid grid;

            private IEnumerable items = null;

            private int currentIndex = 0;

            private List<InquiryRadioBox> listRadioBox;

            private int lastIndexChosen;

            private ColorUI colorUI = ColorUI.Black;
            private ColorUI textColor = ColorUI.Black;

            private TouchType touchType = TouchType.WithText;
            private DesignType designType = DesignType.Shinning; 

            private FontAttributes fontType = FontAttributes.Bold;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

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

                listRadioBox = new List<InquiryRadioBox>();

                TextChosen = "";
                IndexChosen = -1;
                ValueChosen = "";

                grid = new Grid();

                this.Children.Add(grid);
            }

            /// <summary>
            /// Clear the list Images - necessary insert ChoiceImageSwapItem again
            /// </summary>
            public void ResetAll()
            {
                InitAll();
            }

            /// <summary>
            /// Property to report if InquiryRadio is readonly.
            /// </summary>
            public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                     propertyName: nameof(IsReadOnly),
                     returnType: typeof(bool),
                     declaringType: typeof(RadioButton),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: IsReadOnlyPropertyChanged);

            /// <summary>
            /// Property to report if InquiryRadio is readonly.
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                bool isReadOnly = (bool)newValue;

                for (int iItem = 0; iItem < inquiryRadio.listRadioBox.Count; iItem++)
                {
                    if (isReadOnly)
                    {
                        inquiryRadio.listRadioBox[iItem].RadioImage.GestureRecognizers.Clear();
                        inquiryRadio.listRadioBox[iItem].RadioImage.Opacity = 0.25;
                    }
                    else
                    {
                        if (inquiryRadio.Vivacity != Vivacity.None)
                        {
                            if (inquiryRadio.listRadioBox[iItem].RadioImage.GestureRecognizers.Count == 0)
                            {
                                inquiryRadio.listRadioBox[iItem].RadioImage.GestureRecognizers.Add(inquiryRadio.GetVivacity());
                            }
                        }

                        if (inquiryRadio.Vivacity == Vivacity.None)
                        {
                            if (inquiryRadio.listRadioBox[iItem].RadioImage.GestureRecognizers.Count == 0)
                            {
                                inquiryRadio.listRadioBox[iItem].RadioImage.GestureRecognizers.Add(inquiryRadio.GetVivacity());
                            }
                        }
                        else
                        {
                            if (inquiryRadio.listRadioBox[iItem].RadioImage.GestureRecognizers.Count == 1)
                            {
                                inquiryRadio.listRadioBox[iItem].RadioImage.GestureRecognizers.Add(inquiryRadio.GetTouch());
                            }
                        }
                        
                        inquiryRadio.listRadioBox[iItem].RadioImage.Opacity = 1;
                    }
                }
            }

            /// <summary>
            /// Property inform initial index selected of InquiryRadio.
            /// </summary>
            public static readonly BindableProperty InitialIndexProperty = BindableProperty.Create(
                     propertyName: nameof(InitialIndex),
                     returnType: typeof(int),
                     declaringType: typeof(RadioButton),
                     defaultValue: 0,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: InitialIndexPropertyChanged);

            /// <summary>
            /// Property inform initial index selected of InquiryRadio.
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                int initialIndex = (int)newValue;

                if (inquiryRadio.listRadioBox != null)
                {
                    for (int iItem = 0; iItem < inquiryRadio.listRadioBox.Count; iItem++)
                    {
                        if (inquiryRadio.listRadioBox[iItem].RadioImage != null)
                        {
                            if (inquiryRadio.listRadioBox[iItem].RadioImage.Index == initialIndex)
                            {
                                inquiryRadio.listRadioBox[iItem].RadioImage.ChangeState("__Laavor*+-", true);
                                inquiryRadio.IndexChosen = inquiryRadio.listRadioBox[iItem].RadioImage.Index;
                                inquiryRadio.ValueChosen = inquiryRadio.listRadioBox[iItem].RadioImage.Value;
                                inquiryRadio.TextChosen = inquiryRadio.listRadioBox[iItem].RadioLabel.Text;
                            }
                            else
                            {
                                inquiryRadio.listRadioBox[iItem].RadioImage.ChangeState("__Laavor*+-", false);
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Property inform initial value selected of InquiryRadio.
            /// </summary>
            public static readonly BindableProperty InitialValueProperty = BindableProperty.Create(
                     propertyName: nameof(InitialValue),
                     returnType: typeof(string),
                     declaringType: typeof(RadioButton),
                     defaultValue: "",
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: InitialValuePropertyChanged);

            /// <summary>
            /// Property inform initial value selected of InquiryRadio.
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                string initialValue = (string)newValue;

                if (string.IsNullOrEmpty(initialValue))
                {
                    if (inquiryRadio.listRadioBox != null)
                    {
                        for (int iItem = 0; iItem < inquiryRadio.listRadioBox.Count; iItem++)
                        {
                            if (inquiryRadio.listRadioBox[iItem].RadioImage != null)
                            {
                                if (inquiryRadio.listRadioBox[iItem].RadioImage.Value == initialValue)
                                {
                                    inquiryRadio.listRadioBox[iItem].RadioImage.ChangeState("__Laavor*+-", true);
                                    inquiryRadio.IndexChosen = inquiryRadio.listRadioBox[iItem].RadioImage.Index;
                                    inquiryRadio.ValueChosen = inquiryRadio.listRadioBox[iItem].RadioImage.Value;
                                    inquiryRadio.TextChosen = inquiryRadio.listRadioBox[iItem].RadioLabel.Text;
                                }
                                else
                                {
                                    inquiryRadio.listRadioBox[iItem].RadioImage.ChangeState("__Laavor*+-", false);
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
                if (listRadioBox != null)
                {
                    for (int iItem = 0; iItem < listRadioBox.Count; iItem++)
                    {
                        listRadioBox[iItem].RadioImage.ChangeColor("__Laavor*+-", colorUI);
                    }
                }
            }

            /// <summary>
            /// Set TouchType
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
                for (int iItem = 0; iItem <listRadioBox.Count; iItem++)
                {
                    if (vivacity != Vivacity.None)
                    {
                        if (listRadioBox[iItem].RadioLabel != null)
                        {
                            listRadioBox[iItem].RadioLabel.GestureRecognizers.Clear();

                            if (vivacity != Vivacity.None || touchType == TouchType.WithText)
                            {
                                if (listRadioBox[iItem].RadioLabel.GestureRecognizers.Count == 0)
                                {
                                    listRadioBox[iItem].RadioLabel.GestureRecognizers.Add(GetVivacity());
                                }

                                if (listRadioBox[iItem].RadioLabel.GestureRecognizers.Count == 1)
                                {
                                    listRadioBox[iItem].RadioLabel.GestureRecognizers.Add(GetTouch());
                                }
                            }
                        }
                      
                    }
                }
            }

            /// <summary>
            /// Set DesignType
            /// </summary>
            [Bindable(true)]
            public DesignType DesignType
            {
                get
                {
                    return designType;
                }
                set
                {
                    designType = value;
                    DesignTypePropertyChanged();
                }
            }
                       
            private void DesignTypePropertyChanged()
            {
                if (listRadioBox != null)
                {
                    for (int iItem = 0; iItem < listRadioBox.Count; iItem++)
                    {
                        if (listRadioBox[iItem].RadioImage != null)
                        {
                            listRadioBox[iItem].RadioImage.ChangeDesignType("__Laavor*+-", designType);
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the height, represents only one InquiryRadioItem.
            /// </summary>
            public static readonly BindableProperty HeightItemProperty = BindableProperty.Create(
                propertyName: nameof(HeightItem),
                returnType: typeof(double),
                declaringType: typeof(RadioButton),
                defaultValue: 40.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: HeightItemPropertyChanged);

            /// <summary>
            /// Enter the height, represents only one InquiryRadioItem.
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                double radioHeight = (double)newValue;

                if (inquiryRadio.listRadioBox != null)
                {
                    for (int iItem = 0; iItem < inquiryRadio.listRadioBox.Count; iItem++)
                    {
                        if (inquiryRadio.listRadioBox[iItem].RadioImage != null)
                        {
                            inquiryRadio.listRadioBox[iItem].RadioImage.HeightRequest = radioHeight;
                            inquiryRadio.listRadioBox[iItem].RadioImage.MinimumHeightRequest = radioHeight;
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                double radioWidth = (double)newValue;

                if (inquiryRadio.listRadioBox != null)
                {
                    for (int iItem = 0; iItem < inquiryRadio.listRadioBox.Count; iItem++)
                    {
                        if (inquiryRadio.listRadioBox[iItem].RadioImage != null)
                        {
                            inquiryRadio.listRadioBox[iItem].RadioImage.WidthRequest = radioWidth;
                            inquiryRadio.listRadioBox[iItem].RadioImage.MinimumWidthRequest = radioWidth;
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                double fontSize = (double)newValue;

                if (inquiryRadio.listRadioBox != null)
                {
                    for (int iItem = 0; iItem < inquiryRadio.listRadioBox.Count; iItem++)
                    {
                        if (inquiryRadio.listRadioBox[iItem].RadioLabel != null)
                        {
                            inquiryRadio.listRadioBox[iItem].RadioLabel.FontSize = fontSize;
                        }
                    }
                }
            }

            /// <summary>
            /// Set FontType
            /// </summary>
            [Bindable(true)]
            public FontAttributes FontType
            {
                get
                {
                    return fontType;
                }
                set
                {
                    fontType = value;
                    FontTypePropertyChanged();
                }
            }

            private void FontTypePropertyChanged()
            {
                if (listRadioBox != null)
                {
                    for (int iItem = 0; iItem < listRadioBox.Count; iItem++)
                    {
                        if (listRadioBox[iItem].RadioLabel != null)
                        {
                            listRadioBox[iItem].RadioLabel.FontAttributes = fontType;
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
                    return textColor;
                }
                set
                {
                    textColor = value;
                    TextColorPropertyChanged();
                }
            }
                    
            private void TextColorPropertyChanged()
            {
                if (listRadioBox != null)
                {
                    for (int iItem = 0; iItem < listRadioBox.Count; iItem++)
                    {
                        if (listRadioBox[iItem].RadioLabel != null)
                        {
                            listRadioBox[iItem].RadioLabel.TextColor = Colors.Get(textColor);
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                inquiryRadio.items = (IEnumerable)newValue;
                inquiryRadio.InitAllBindable(inquiryRadio);
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                inquiryRadio.InitAllBindable(inquiryRadio);
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                inquiryRadio.InitAllBindable(inquiryRadio);
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                inquiryRadio.InitAllBindable(inquiryRadio);
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                inquiryRadio.InitAllBindable(inquiryRadio);
            }

            private void InitAllBindable(object sender)
            {
                RadioButton inquiryRadio = (RadioButton)sender;

                if (inquiryRadio.items != null && !string.IsNullOrEmpty(inquiryRadio.TextField) && !string.IsNullOrEmpty(inquiryRadio.ValueField))
                {
                    grid.Children.Clear();
                    var enumerator = inquiryRadio.items.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        object obj = enumerator.Current;
                        string textObj = obj.GetType().GetProperty(inquiryRadio.TextField).GetValue(obj).ToString();
                        string valueObj = obj.GetType().GetProperty(inquiryRadio.ValueField).GetValue(obj).ToString();

                        bool hasRowCol = false;
                        int row = -1;
                        int col = -1;
                        if (!string.IsNullOrEmpty(inquiryRadio.RowField) || !string.IsNullOrEmpty(inquiryRadio.ColField))
                        {
                            string rowObj = obj.GetType().GetProperty(inquiryRadio.RowField).GetValue(obj).ToString();
                            string colObj = obj.GetType().GetProperty(inquiryRadio.ColField).GetValue(obj).ToString();

                            int.TryParse(rowObj, out row);
                            int.TryParse(colObj, out col);

                            if (row >= 0 && col >= 0)
                            {
                                hasRowCol = true;
                            }
                        }

                        InquiryRadioControl radioImage;

                        if (InitialIndex != -1 && InitialIndex == currentIndex)
                        {
                            radioImage = new InquiryRadioControl("__Laavor*+-", DesignType, ColorUI, true, currentIndex, valueObj);
                        }
                        else
                        {
                            radioImage = new InquiryRadioControl("__Laavor*+-", DesignType, ColorUI, false, currentIndex, valueObj);
                        }

                        radioImage.WidthRequest = WidthItem;
                        radioImage.MinimumWidthRequest = WidthItem;
                        radioImage.HeightRequest = HeightItem;
                        radioImage.MinimumWidthRequest = HeightItem;

                        InquiryRadioLabel label = new InquiryRadioLabel();
                        label.FontSize = FontSize;
                        label.FontFamily = FontFamily;
                        label.TextColor = Colors.Get(TextColor);
                        label.Text = textObj;

                        if (IsReadOnly)
                        {
                            radioImage.Opacity = 0.25;
                        }
                        else
                        {
                            radioImage.GestureRecognizers.Add(GetTouch());

                            if (TouchType == TouchType.WithText)
                            {
                                label.GestureRecognizers.Add(GetTouch());
                            }

                            if (inquiryRadio.Vivacity != Vivacity.None)
                            {
                                radioImage.GestureRecognizers.Add(GetVivacity());

                                if (TouchType == TouchType.WithText)
                                {
                                    label.GestureRecognizers.Add(GetVivacity());
                                }
                            }
                        }

                        label.setImage("__Laavor*+-", radioImage);
                        radioImage.setLabel("__Laavor*+-", label);

                        listRadioBox.Insert(currentIndex, new InquiryRadioBox() { RadioImage = radioImage, RadioLabel = label });

                        StackLayout stackInternal = new StackLayout();
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

                        grid.Children.Add(stackInternal);

                        currentIndex++;
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
                RadioButton inquiryRadio = (RadioButton)bindable;
                string fontFamily = (string)newValue;

                if (inquiryRadio.listRadioBox != null)
                {
                    for (int iItem = 0; iItem < inquiryRadio.listRadioBox.Count; iItem++)
                    {
                        if (inquiryRadio.listRadioBox[iItem].RadioLabel != null)
                        {
                            inquiryRadio.listRadioBox[iItem].RadioLabel.FontFamily = fontFamily;
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
                if (!IsReadOnly)
                {
                    for (int iItem = 0; iItem < listRadioBox.Count; iItem++)
                    {
                        if (vivacity != Vivacity.None)
                        {
                            listRadioBox[iItem].RadioImage.GestureRecognizers.Clear();
                            listRadioBox[iItem].RadioImage.GestureRecognizers.Add(GetTouch());

                            if (TouchType == TouchType.WithText)
                            {
                                listRadioBox[iItem].RadioLabel.GestureRecognizers.Add(GetTouch());
                            }

                            if (Vivacity != Vivacity.None)
                            {
                                listRadioBox[iItem].RadioImage.GestureRecognizers.Add(GetVivacity());

                                if (TouchType == TouchType.WithText)
                                {
                                    listRadioBox[iItem].RadioLabel.GestureRecognizers.Add(GetVivacity());
                                }
                            }
                        }
                        else
                        {
                            listRadioBox[iItem].RadioImage.GestureRecognizers.Clear();

                            if (Vivacity != Vivacity.None)
                            {
                                listRadioBox[iItem].RadioImage.GestureRecognizers.Add(GetVivacity());
                            }

                            listRadioBox[iItem].RadioImage.GestureRecognizers.Add(GetTouch());

                            if (TouchType == TouchType.WithText)
                            {
                                if (Vivacity != Vivacity.None)
                                {
                                    listRadioBox[iItem].RadioLabel.GestureRecognizers.Add(GetVivacity());
                                }

                                listRadioBox[iItem].RadioLabel.GestureRecognizers.Add(GetTouch());
                            }
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

                if (child.GetType() == typeof(InquiryRadioItem))
                {
                    InquiryRadioItem radioItem = (InquiryRadioItem)child;
                    InquiryRadioControl radioImage;

                    if (InitialIndex != -1 && InitialIndex == currentIndex)
                    {
                        radioImage = new InquiryRadioControl("__Laavor*+-", DesignType, ColorUI, true, currentIndex, radioItem.Value);
                    }
                    else
                    {
                        radioImage = new InquiryRadioControl("__Laavor*+-", DesignType, ColorUI, false, currentIndex, radioItem.Value);
                    }

                    radioImage.WidthRequest = WidthItem;
                    radioImage.MinimumWidthRequest = WidthItem;
                    radioImage.HeightRequest = HeightItem;
                    radioImage.MinimumWidthRequest = HeightItem;

                    InquiryRadioLabel label = new InquiryRadioLabel();
                    label.FontSize = FontSize;
                    label.FontFamily = FontFamily;
                    label.TextColor = Colors.Get(TextColor);
                    label.Text = radioItem.Text;
                    label.FontAttributes = fontType;
                    label.VerticalOptions = LayoutOptions.Center;
                    label.VerticalTextAlignment = TextAlignment.Center;

                    if (IsReadOnly)
                    {
                        radioImage.Opacity = 0.25;
                    }
                    else
                    {
                        radioImage.GestureRecognizers.Add(GetTouch());

                        if (TouchType == TouchType.WithText)
                        {
                            label.GestureRecognizers.Add(GetTouch());
                        }

                        if (Vivacity != Vivacity.None)
                        {
                            radioImage.GestureRecognizers.Add(GetVivacity());

                            if (TouchType == TouchType.WithText)
                            {
                                label.GestureRecognizers.Add(GetVivacity());
                            }
                        }
                    }

                    label.setImage("__Laavor*+-", radioImage);
                    radioImage.setLabel("__Laavor*+-", label);

                    listRadioBox.Insert(currentIndex, new InquiryRadioBox() { RadioImage = radioImage, RadioLabel = label });

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

                    grid.Children.Add(stackInternal);

                    currentIndex++;
                }
            }

            private TapGestureRecognizer GetTouch()
            {
                TapGestureRecognizer tp = new TapGestureRecognizer();
                tp.Tapped += TouchRadio;
                return tp;
            }

            private void TouchRadio(object sender, EventArgs e)
            {
                InquiryRadioControl radioImage;
                InquiryRadioLabel labelImage;

                try
                {
                    if (sender.GetType() == typeof(InquiryRadioControl))
                    {
                        radioImage = (InquiryRadioControl)sender;
                        labelImage = radioImage.Label;
                    }
                    else
                    {
                        labelImage = (InquiryRadioLabel)sender;
                        radioImage = labelImage.Image;
                    }

                    listRadioBox[lastIndexChosen].RadioImage.ChangeState("__Laavor*+-", false);
                    listRadioBox[radioImage.Index].RadioImage.ChangeState("__Laavor*+-", true);
                    lastIndexChosen = radioImage.Index;
                }
                catch { }

                Chosen?.Invoke(this, EventArgs.Empty);
            }

            private TapGestureRecognizer GetVivacity()
            {
                MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + Vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

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
                        InquiryRadioControl radioImage;
                        InquiryRadioLabel labelImage;

                        if (sender.GetType() == typeof(InquiryRadioControl))
                        {
                            radioImage = (InquiryRadioControl)sender;
                            labelImage = radioImage.Label;
                        }
                        else
                        {
                            labelImage = (InquiryRadioLabel)sender;
                            radioImage = labelImage.Image;
                        }

                        await radioImage.ScaleTo(GetDepthDecrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await radioImage.ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
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
                        InquiryRadioControl radioImage;
                        InquiryRadioLabel labelImage;

                        if (sender.GetType() == typeof(InquiryRadioControl))
                        {
                            radioImage = (InquiryRadioControl)sender;
                            labelImage = radioImage.Label;
                        }
                        else
                        {
                            labelImage = (InquiryRadioLabel)sender;
                            radioImage = labelImage.Image;
                        }

                        await radioImage.ScaleTo(GetDepthIncrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await radioImage.ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
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
                        InquiryRadioControl radioImage;
                        InquiryRadioLabel labelImage;

                        if (sender.GetType() == typeof(InquiryRadioControl))
                        {
                            radioImage = (InquiryRadioControl)sender;
                            labelImage = radioImage.Label;
                        }
                        else
                        {
                            labelImage = (InquiryRadioLabel)sender;
                            radioImage = labelImage.Image;
                        }

                        await radioImage.RotateTo(GetDepthRotation(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await radioImage.RotateTo(0, (uint)VivacitySpeed, Easing.Linear);
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
                        InquiryRadioControl radioImage;
                        InquiryRadioLabel labelImage;

                        if (sender.GetType() == typeof(InquiryRadioControl))
                        {
                            radioImage = (InquiryRadioControl)sender;
                            labelImage = radioImage.Label;
                        }
                        else
                        {
                            labelImage = (InquiryRadioLabel)sender;
                            radioImage = labelImage.Image;
                        }

                        await radioImage.TranslateTo(0, GetDepthJump(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await radioImage.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
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
                        InquiryRadioControl radioImage;
                        InquiryRadioLabel labelImage;

                        if (sender.GetType() == typeof(InquiryRadioControl))
                        {
                            radioImage = (InquiryRadioControl)sender;
                            labelImage = radioImage.Label;
                        }
                        else
                        {
                            labelImage = (InquiryRadioLabel)sender;
                            radioImage = labelImage.Image;
                        }

                        await radioImage.TranslateTo(0, GetDepthDown(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await radioImage.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
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
                        InquiryRadioControl radioImage;
                        InquiryRadioLabel labelImage;

                        if (sender.GetType() == typeof(InquiryRadioControl))
                        {
                            radioImage = (InquiryRadioControl)sender;
                            labelImage = radioImage.Label;
                        }
                        else
                        {
                            labelImage = (InquiryRadioLabel)sender;
                            radioImage = labelImage.Image;
                        }

                        await radioImage.TranslateTo(GetDepthLeft(Depth), 0, (uint)VivacitySpeed, Easing.Linear);
                        await radioImage.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
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
        }
    }
}
