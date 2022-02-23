using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{
    /// <summary>
    /// Class PickerBox 
    /// </summary>
    public class PickerBox: LaavorBaseValidate
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
        /// Call when select is changed
        /// </summary>
        public event EventHandler OnChangeSelected;

        /// <summary>
        /// Call when item is chosen
        /// </summary>
        public event EventHandler Chosen;

        /// <summary>
        /// Call when is validate
        /// </summary>
        public event EventHandler Validate;

        private ObservableCollection<string> listData = new ObservableCollection<string>();

        private Grid gridReference;
        private Picker pickReference;
        private Frame frameReference;

        private FontAttributes currentFontType = FontAttributes.None;

        private IEnumerable items = null;

        private Dictionary<string, PickerItem> dicItemsPicker;

        private bool blockValidate;

        private bool automaticStarted = false;

        private Label labelError;

        /// <summary>
        /// Constructor of PickerBox
        /// </summary>
        public PickerBox() : base()
        {
            InitiAll();
            IsValid = true;
        }

        private void InitiAll()
        {
            dicItemsPicker = new Dictionary<string, PickerItem>();

            Children.Clear();

            pickReference = new Picker();
            pickReference.TextColor = Colors.Get(TextColor);
            pickReference.SelectedIndexChanged += PickReference_SelectedIndexChanged;
            pickReference.Unfocused += PickReference_Unfocused;
            pickReference.FontSize = FontSize;
            pickReference.Margin = new Thickness(-10, -20, -10, -20);
            pickReference.WidthRequest = Width;
            pickReference.BackgroundColor = Color.Transparent;

            gridReference = new Grid
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

            frameReference = new Frame();
            frameReference.BorderColor = Colors.Get(BorderColor);
            frameReference.VerticalOptions = LayoutOptions.Start;
            frameReference.BackgroundColor = Colors.Get(ColorUI);

            frameReference.Content = pickReference;

            gridReference.Children.Add(frameReference, 0, 0);
            
            Children.Add(gridReference);
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
            
            OnChangeSelected?.Invoke(this, e);
            Chosen?.Invoke(this, e);
        }

        private void SetColorsInitialState()
        {
            frameReference.BackgroundColor = Colors.Get(ColorUI);
            frameReference.BorderColor = Colors.Get(BorderColor);

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

            if (pickReference.SelectedIndex < 0)
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

                    frameReference.BackgroundColor = Colors.Get(ColorUIError);
                    frameReference.BorderColor = Colors.Get(BorderColorError);
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
            declaringType: typeof(PickerBox),
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
            PickerBox pickerBox = (PickerBox)bindable;

            if (pickerBox.pickReference != null)
            {
                pickerBox.pickReference.WidthRequest = (double)newValue;
            }
        }

        /// <summary>
        /// Property to report if PickerBox is nullable
        /// </summary>
        public static readonly BindableProperty CanEmptyProperty = BindableProperty.Create(
                 propertyName: nameof(CanEmpty),
                 returnType: typeof(bool),
                 declaringType: typeof(PickerBox),
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
        /// Enter the ColorUI(background) color.
        /// </summary>
        public static readonly BindableProperty ColorUIProperty = BindableProperty.Create(
         propertyName: nameof(ColorUI),
         returnType: typeof(ColorUI),
         declaringType: typeof(PickerBox),
         defaultValue: ColorUI.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: ColorUIPropertyChanged);

        /// <summary>
        /// Enter the ColorUI (background) color.
        /// </summary>
        public ColorUI ColorUI
        {
            get
            {
                return (ColorUI)GetValue(ColorUIProperty);
            }
            set
            {
                SetValue(ColorUIProperty, value);
            }
        }

        private static void ColorUIPropertyChanged(object bindable, object oldValue, object newValue)
        {
            PickerBox pickerBox = (PickerBox)bindable;
            ColorUI copyColor = (ColorUI)newValue;

            if (pickerBox.frameReference != null)
            {
                if (pickerBox.IsValid)
                {
                    pickerBox.frameReference.BackgroundColor = Colors.Get(copyColor);
                }
            }
        }

        /// <summary>
        /// Enter the ColorUIError (background).
        /// </summary>
        public static readonly BindableProperty ColorUIErrorProperty = BindableProperty.Create(
         propertyName: nameof(ColorUIError),
         returnType: typeof(ColorUI),
         declaringType: typeof(PickerBox),
         defaultValue: ColorUI.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: ColorUIErrorPropertyChanged);

        /// <summary>
        /// Enter the ColorUI(background) color Error.
        /// </summary>
        public ColorUI ColorUIError
        {
            get
            {
                return (ColorUI)GetValue(ColorUIErrorProperty);
            }
            set
            {
                SetValue(ColorUIErrorProperty, value);
            }
        }

        private static void ColorUIErrorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            PickerBox pickerBox = (PickerBox)bindable;
            ColorUI copyColorError = (ColorUI)newValue;

            if (pickerBox.frameReference != null)
            {
                if (!pickerBox.IsValid)
                {
                    pickerBox.frameReference.BackgroundColor = Colors.Get(copyColorError);
                }
            }
        }

        /// <summary>
        /// Enter the text color.
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
         propertyName: nameof(TextColor),
         returnType: typeof(ColorUI),
         declaringType: typeof(PickerBox),
         defaultValue: ColorUI.Black,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: TextColorPropertyChanged);

        /// <summary>
        /// Enter the text color.
        /// </summary>
        public ColorUI TextColor
        {
            get
            {
                return (ColorUI)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        private static void TextColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            PickerBox pickerBox = (PickerBox)bindable;
            ColorUI color = (ColorUI)newValue;

            if (pickerBox.pickReference != null)
            {
                pickerBox.pickReference.TextColor = Colors.Get(color);
            }
        }

        /// <summary>
        /// Enter the  BorderColor
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
           propertyName: nameof(BorderColor),
           returnType: typeof(ColorUI),
           declaringType: typeof(PickerBox),
           defaultValue: ColorUI.Black,
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: BorderColorPropertyChanged);

        /// <summary>
        /// Enter the  BorderColor
        /// </summary>
        public ColorUI BorderColor
        {
            get
            {
                return (ColorUI)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        private static void BorderColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            PickerBox pickerBox = (PickerBox)bindable;
            ColorUI copyBorderColor = (ColorUI)newValue;

            if (pickerBox.frameReference != null)
            {
                if (pickerBox.IsValid)
                {
                    pickerBox.frameReference.BorderColor = Colors.Get(copyBorderColor);
                }
            }
        }

        /// <summary>
        /// Enter the BorderColor Error shows only when is invalid (Empty)
        /// </summary>
        public static readonly BindableProperty BorderColorErrorProperty = BindableProperty.Create(
           propertyName: nameof(BorderColorError),
           returnType: typeof(ColorUI),
           declaringType: typeof(PickerBox),
           defaultValue: ColorUI.Black,
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: BorderColorErrorPropertyChanged);

        /// <summary>
        /// Enter the BorderColor Error shows only when is invalid (Empty)
        /// </summary>
        public ColorUI BorderColorError
        {
            get
            {
                return (ColorUI)GetValue(BorderColorErrorProperty);
            }
            set
            {
                SetValue(BorderColorErrorProperty, value);
            }
        }

        private static void BorderColorErrorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            PickerBox pickerBox = (PickerBox)bindable;
            ColorUI copyBorderColorError = (ColorUI)newValue;
            if (!pickerBox.IsValid)
            {
                if (pickerBox.frameReference != null)
                {
                    if (!pickerBox.IsValid)
                    {
                        pickerBox.frameReference.BorderColor = Colors.Get(copyBorderColorError);
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
            declaringType: typeof(PickerBox),
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
            PickerBox pickerBox = (PickerBox)bindable;
            double copyFontSize = (double)newValue;

            if (pickerBox.pickReference != null)
            {
                pickerBox.pickReference.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Enter the Title.
        /// </summary>
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(PickerBox),
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
            PickerBox pickerBox = (PickerBox)bindable;
            string copyTitle = (string)newValue;

            if (pickerBox.pickReference != null)
            {
                pickerBox.pickReference.Title = copyTitle;
            }
        }

        ///// <summary>
        ///// Enter the font family.
        ///// </summary>
        //public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
        //    propertyName: nameof(FontFamily),
        //    returnType: typeof(string),
        //    declaringType: typeof(PickerBox),
        //    defaultValue: "",
        //    defaultBindingMode: BindingMode.OneWay,
        //    propertyChanged: FontFamilyPropertyChanged);

        ///// <summary>
        ///// Enter the font family.
        ///// </summary>
        //public string FontFamily
        //{
        //    get
        //    {
        //        return (string)GetValue(FontFamilyProperty);
        //    }
        //    set
        //    {
        //        SetValue(FontFamilyProperty, value);
        //    }
        //}

        //private static void FontFamilyPropertyChanged(object bindable, object oldValue, object newValue)
        //{
        //    PickerBox pickerBox = (PickerBox)bindable;
        //    string fontFamily = (string)newValue;
        //    pickerBox.pickReference.FontFamily = fontFamily;
        //}

        /// <summary>
        /// Enter the fonttype (None, Bold, Italic).
        /// </summary>
        [Bindable(true)]
        public FontAttributes FontType
        {
            get
            {
                return currentFontType;
            }
            set
            {
                currentFontType = value;
                FontTypePropertyChanged();
            }
        }

        private void FontTypePropertyChanged()
        {
            pickReference.FontAttributes = currentFontType;
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
            declaringType: typeof(PickerBox),
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
            declaringType: typeof(PickerBox),
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
            PickerBox pickerBox = (PickerBox)bindable;
            pickerBox.InitAllBindable();
        }

        /// <summary>
        /// Enter the TextField, only when using list mvvm.
        /// </summary>
        public static readonly BindableProperty TextFieldProperty = BindableProperty.Create(
            propertyName: nameof(TextField),
            returnType: typeof(string),
            declaringType: typeof(PickerBox),
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
            PickerBox pickerBox = (PickerBox)bindable;
            pickerBox.InitAllBindable();
        }

        /// <summary>
        /// Enter the ListItens (List of Object to bind Picker)
        /// </summary>
        public static readonly BindableProperty ListItemsProperty = BindableProperty.Create(
            propertyName: nameof(ListItems),
            returnType: typeof(IEnumerable),
            declaringType: typeof(PickerBox),
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
            PickerBox pickerBox = (PickerBox)bindable;
            pickerBox.items = (IEnumerable)newValue;
            pickerBox.InitAllBindable();
        }

        private void InitAllBindable()
        {
            dicItemsPicker = new Dictionary<string, PickerItem>();

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

                    PickerItem item = new PickerItem(textObj, valueObj);
                    dataFromPicker.Add(item.Text);
                    dicItemsPicker.Add(item.Text, item);

                }

                this.pickReference.ItemsSource = dataFromPicker;
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

                if (this.pickReference.ItemsSource == null)
                {
                    this.pickReference.ItemsSource = listData;
                }

                PickerItem item = (PickerItem)child;
                listData.Add(item.Text);

                dicItemsPicker.Add(item.Text, item);

                base.OnChildAdded(child);
            }

        }
    }
}
