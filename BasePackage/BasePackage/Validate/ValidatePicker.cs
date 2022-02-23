using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Validate
    {
        /// <summary>
        /// Class PickerBox 
        /// </summary>
        public class ValidatePicker : ValidateBase
        {
            /// <summary>
            /// Returns the value of the item chosen.
            /// </summary>
            public string ValueChosen { get; private set; }

            /// <summary>
            /// Returns the text of the item chosen.
            /// </summary>
            public string TextChosen { get; private set; }

            /// <summary>
            /// Call when item is chosen
            /// </summary>
            public event EventHandler Chosen;

            /// <summary>
            /// Call when is validate
            /// </summary>
            public event EventHandler Validate;

            private ObservableCollection<string> listData = new ObservableCollection<string>();

            private Grid grid;
            private Picker pick;
            private Frame frame;

            private IEnumerable items = null;

            private Dictionary<string, ValidatePickerItem> dicItemsPicker;

            private bool blockValidate;

            private bool automaticStarted = false;

            private Label labelError;

            private FontAttributes fontType = FontAttributes.None;
            private ColorUI textColor = ColorUI.Black;
            private ColorUI textColorError = ColorUI.Red;
            private ColorUI colorUI = ColorUI.White;
            private ColorUI colorUIError = ColorUI.White;
            private ColorUI borderColor = ColorUI.Black;
            private ColorUI borderColorError = ColorUI.Black;
            private ColorUI placeHolderColor = ColorUI.GrayLight;

            /// <summary>
            /// Constructor of PickerBox
            /// </summary>
            public ValidatePicker() : base()
            {
                InitiAll();
                IsValid = true;
            }

            private void InitiAll()
            {
                dicItemsPicker = new Dictionary<string, ValidatePickerItem>();

                Children.Clear();

                pick = new Picker();
                pick.TextColor = Colors.Get(TextColor);
                pick.SelectedIndexChanged += PickReference_SelectedIndexChanged;
                pick.Unfocused += PickReference_Unfocused;
                pick.FontSize = FontSize;
                pick.Margin = new Thickness(-10, -20, -10, -20);
                pick.WidthRequest = Width;
                pick.BackgroundColor = Color.Transparent;

                grid = new Grid
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = GridLength.Auto}
                    },
                    RowDefinitions =
                    {
                        new RowDefinition { Height =  GridLength.Auto }
                    }
                };

                frame = new Frame();
                frame.BorderColor = Colors.Get(BorderColor);
                frame.VerticalOptions = LayoutOptions.Start;
                frame.BackgroundColor = Colors.Get(ColorUI);

                frame.Content = pick;

                grid.Children.Add(frame, 0, 0);

                Children.Add(grid);
            }

            private void PickReference_Unfocused(object sender, FocusEventArgs e)
            {
                if (blockValidate)
                {
                    validate(false);
                    blockValidate = false;
                }
                else
                {
                    validate(true);
                }
            }

            private void PickReference_SelectedIndexChanged(object sender, EventArgs e)
            {
                TextChosen = (sender as Picker).SelectedItem.ToString();

                ValueChosen = dicItemsPicker[TextChosen].Value;

                blockValidate = true;

                if ((sender as Picker).SelectedIndex > -1)
                {
                    IsValid = true;
                }

                Chosen?.Invoke(this, e);
            }

            private void SetColorsInitialState()
            {
                frame.BackgroundColor = Colors.Get(ColorUI);
                frame.BorderColor = Colors.Get(BorderColor);

                if (LabelMessageError != null && ChangeMessageLabel)
                {
                    LabelMessageError.Text = "";
                }
            }

            /// <summary>
            /// Internal
            /// </summary>
            public override void ForceValidate()
            {
                validate(false);
            }

            private void validate(bool callEventValidate = true)
            {
                SetColorsInitialState();
                bool isValid = true;

                if (pick.SelectedIndex < 0)
                {
                    if (!CanEmpty)
                    {
                        isValid = false;

                        if (ChangeMessageLabel && LabelMessageError != null)
                        {
                            LabelMessageError.Text = "Can not be left blank.";
                        }
                    }
                    else
                    {
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    if (callEventValidate)
                    {
                        if (LabelMessageError != null)
                        {
                            LabelMessageError.IsVisible = true;
                        }

                        frame.BackgroundColor = Colors.Get(ColorUIError);
                        frame.BorderColor = Colors.Get(BorderColorError);
                    }

                    IsValid = false;
                }
                else
                {
                    if (LabelMessageError != null)
                    {
                        LabelMessageError.IsVisible = false;

                        if (ChangeMessageLabel)
                        {
                            LabelMessageError.Text = "";
                        }
                    }

                    IsValid = true;
                }

                base.IsValid = IsValid;
                if (callEventValidate)
                {
                    Validate?.Invoke(this, EventArgs.Empty);
                }
            }

            /// <summary>
            /// Width of PickerBox
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(ValidatePicker),
                defaultValue: 300.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthPropertyChanged);

            /// <summary>
            /// Width of PickerBox
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
                ValidatePicker pickerBox = (ValidatePicker)bindable;

                if (pickerBox.pick != null)
                {
                    pickerBox.pick.WidthRequest = (double)newValue;
                }
            }

            /// <summary>
            /// Property to report if PickerBox is nullable
            /// </summary>
            public static readonly BindableProperty CanEmptyProperty = BindableProperty.Create(
                     propertyName: nameof(CanEmpty),
                     returnType: typeof(bool),
                     declaringType: typeof(ValidatePicker),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Property to report if PickerBox is nullable
            /// </summary>
            public bool CanEmpty
            {
                get
                {
                    return (bool)GetValue(CanEmptyProperty);
                }
                set
                {
                    SetValue(CanEmptyProperty, value);
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
                if (frame != null)
                {
                    if (IsValid)
                    {
                        frame.BackgroundColor = Colors.Get(colorUI);
                    }
                }
            }

            /// <summary>
            /// Set ColorUIError
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorUIError
            {
                get
                {
                    return colorUIError;
                }
                set
                {
                    colorUIError = value;
                    ColorUIErrorPropertyChanged();
                }
            }

            private void ColorUIErrorPropertyChanged()
            {
                if (frame != null)
                {
                    if (!IsValid)
                    {
                        frame.BackgroundColor = Colors.Get(colorUIError);
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
                if (pick != null)
                {
                    pick.TextColor = Colors.Get(textColor);
                }
            }

            /// <summary>
            /// Set BorderColor
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColor
            {
                get
                {
                    return borderColor;
                }
                set
                {
                    borderColor = value;
                    BorderColorPropertyChanged();
                }
            }

            private void BorderColorPropertyChanged()
            {
                if (frame != null)
                {
                    if (IsValid)
                    {
                        frame.BorderColor = Colors.Get(borderColor);
                    }
                }
            }

            /// <summary>
            /// Set BorderColorError
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColorError
            {
                get
                {
                    return borderColorError;
                }
                set
                {
                    borderColorError = value;
                    BorderColorErrorPropertyChanged();
                }
            }
      
            private void BorderColorErrorPropertyChanged()
            {
                if (!IsValid)
                {
                    if (frame != null)
                    {
                        if (!IsValid)
                        {
                            frame.BorderColor = Colors.Get(borderColorError);
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the font size.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(ValidatePicker),
                defaultValue: 20.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizePropertyChanged);

            /// <summary>
            /// Enter the font size.
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
                ValidatePicker pickerBox = (ValidatePicker)bindable;
                double copyFontSize = (double)newValue;

                if (pickerBox.pick != null)
                {
                    pickerBox.pick.FontSize = copyFontSize;
                }
            }

            /// <summary>
            /// Enter the Title.
            /// </summary>
            public static readonly BindableProperty TitleProperty = BindableProperty.Create(
                propertyName: nameof(Title),
                returnType: typeof(string),
                declaringType: typeof(ValidatePicker),
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TitlePropertyChanged);

            /// <summary>
            /// Enter the Title.
            /// </summary>
            public string Title
            {
                get
                {
                    return (string)GetValue(TitleProperty);
                }
                set
                {
                    SetValue(TitleProperty, value);
                }
            }

            private static void TitlePropertyChanged(object bindable, object oldValue, object newValue)
            {
                ValidatePicker pickerBox = (ValidatePicker)bindable;
                string copyTitle = (string)newValue;

                if (pickerBox.pick != null)
                {
                    pickerBox.pick.Title = copyTitle;
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
                if (pick != null)
                {
                    pick.FontAttributes = fontType;
                }
            }

            /// <summary>
            /// Enter the label to set message error, you can create your message without change.
            /// </summary>
            [Bindable(true)]
            public Label LabelMessageError
            {
                get
                {
                    return labelError;
                }
                set
                {
                    labelError = value;
                    if (value != null)
                    {
                        labelError.IsVisible = false;
                    }
                }
            }

            /// <summary>
            /// Informs if use the default messages of plugin laavor.
            /// </summary>
            public static readonly BindableProperty ChangeMessageLabelProperty = BindableProperty.Create(
                propertyName: nameof(ChangeMessageLabel),
                returnType: typeof(bool),
                declaringType: typeof(ValidatePicker),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Informs if use the default messages of plugin laavor.
            /// </summary>
            public bool ChangeMessageLabel
            {
                get
                {
                    return (bool)GetValue(ChangeMessageLabelProperty);
                }
                set
                {
                    SetValue(ChangeMessageLabelProperty, value);
                }
            }

            /// <summary>
            /// Enter the ValueField, only when using list.
            /// </summary>
            public static readonly BindableProperty ValueFieldProperty = BindableProperty.Create(
                propertyName: nameof(ValueField),
                returnType: typeof(string),
                declaringType: typeof(ValidatePicker),
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
                ValidatePicker pickerBox = (ValidatePicker)bindable;
                pickerBox.InitAllBindable();
            }

            /// <summary>
            /// Enter the TextField, only when using list mvvm.
            /// </summary>
            public static readonly BindableProperty TextFieldProperty = BindableProperty.Create(
                propertyName: nameof(TextField),
                returnType: typeof(string),
                declaringType: typeof(ValidatePicker),
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextFieldPropertyChanged);

            /// <summary>
            /// Enter the TextField, only when using list mvvm.
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
                    InitAllBindable();
                }
            }

            private static void TextFieldPropertyChanged(object bindable, object oldValue, object newValue)
            {
                ValidatePicker pickerBox = (ValidatePicker)bindable;
                pickerBox.InitAllBindable();
            }

            /// <summary>
            /// Enter the ListItens (List of Object to bind Picker)
            /// </summary>
            public static readonly BindableProperty ListItemsProperty = BindableProperty.Create(
                propertyName: nameof(ListItems),
                returnType: typeof(IEnumerable),
                declaringType: typeof(ValidatePicker),
                defaultBindingMode: BindingMode.OneWay,
                defaultValue: null,
                propertyChanged: ListItemsPropertyChanged);

            /// <summary>
            /// Enter the ListItens (List of Object to bind Picker)
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
                ValidatePicker pickerBox = (ValidatePicker)bindable;
                pickerBox.items = (IEnumerable)newValue;
                pickerBox.InitAllBindable();
            }

            private void InitAllBindable()
            {
                dicItemsPicker = new Dictionary<string, ValidatePickerItem>();

                if (this.items != null && !string.IsNullOrEmpty(this.TextField) && !string.IsNullOrEmpty(this.ValueField))
                {
                    this.automaticStarted = true;
                    var enumerator = this.items.GetEnumerator();
                    List<string> dataFromPicker = new List<string>();
                    while (enumerator.MoveNext())
                    {
                        object obj = enumerator.Current;
                        string textObj = obj.GetType().GetProperty(this.TextField).GetValue(obj).ToString();
                        string valueObj = obj.GetType().GetProperty(this.ValueField).GetValue(obj).ToString();

                        ValidatePickerItem item = new ValidatePickerItem(textObj, valueObj);
                        dataFromPicker.Add(item.Text);
                        dicItemsPicker.Add(item.Text, item);

                    }

                    this.pick.ItemsSource = dataFromPicker;
                }
            }

            /// <summary>
            /// Inernal
            /// </summary>
            protected override void OnChildAdded(Element child)
            {
                if (!automaticStarted)
                {
                    if (child.GetType() == typeof(Grid))
                    {
                        base.OnChildAdded(child);
                        return;
                    }

                    if (this.pick.ItemsSource == null)
                    {
                        this.pick.ItemsSource = listData;
                    }

                    ValidatePickerItem item = (ValidatePickerItem)child;
                    listData.Add(item.Text);

                    dicItemsPicker.Add(item.Text, item);

                    base.OnChildAdded(child);
                }
            }

        }
    }
}
