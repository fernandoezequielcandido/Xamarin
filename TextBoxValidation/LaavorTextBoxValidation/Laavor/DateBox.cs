using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{
    /// <summary>
    /// Class DateBox 
    /// </summary>
    public class DateBox: LaavorBaseValidate
    {
        /// <summary>
        /// Date Chosen
        /// </summary>
        public DateTime DateChosen { get; private set; }

        private Grid gridReference;
        private DatePicker datePickerReference;
        private Frame frameReference;

        private DateTime currentInitialDate = DateTime.Today;
        private DateTime currentMaximum;
        private DateTime currentMinimum;

        /// <summary>
        /// Constructor of DateBox
        /// </summary>
        public DateBox() : base()
        {
            InitiAll();
            IsValid = true;
        }

        private void InitiAll()
        {
            Children.Clear();

            datePickerReference = new DatePicker();
            datePickerReference.TextColor = Colors.Get(TextColor);
            datePickerReference.DateSelected += DatePickerReference_DateChosen;
            datePickerReference.FontSize = FontSize;
            datePickerReference.Margin = new Thickness(-10, -20, -10, -20);
            datePickerReference.WidthRequest = Width;
            datePickerReference.BackgroundColor = Color.Transparent;
            datePickerReference.Date = InitialDate;

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

            frameReference.HasShadow = true;
            frameReference.Content = datePickerReference;
                       
            gridReference.Children.Add(frameReference, 0, 0);

            Children.Add(gridReference);
        }

        private void DatePickerReference_DateChosen(object sender, EventArgs e)
        {
            DateChosen = (sender as DatePicker).Date;
        }

        /// <summary>
        /// Internal
        /// </summary>
        public override void ForceValidate()
        {

        }

        /// <summary>
        /// Start date for pre choice
        /// </summary>
        [Bindable(true)]
        public DateTime InitialDate
        {
            get
            {
                return currentInitialDate;
            }
            set
            {
                currentInitialDate = value;
                datePickerReference.Date = value;
            }
        }

        /// <summary>
        /// Width of DateBox
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(DateBox),
            defaultValue: 300.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Width of DateBox
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
            DateBox dateBox = (DateBox)bindable;

            if (dateBox.datePickerReference != null)
            {
                dateBox.datePickerReference.WidthRequest = (double)newValue;
            }
        }

        /// <summary>
        /// Enter the ColorUI (background).
        /// </summary>
        public static readonly BindableProperty ColorUIProperty = BindableProperty.Create(
         propertyName: nameof(ColorUI),
         returnType: typeof(ColorUI),
         declaringType: typeof(DateBox),
         defaultValue: ColorUI.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: ColorUIPropertyChanged);

        /// <summary>
        /// Enter the colorUI (Background).
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
            DateBox dateBox = (DateBox)bindable;
            ColorUI copyColor = (ColorUI)newValue;

            if (dateBox.frameReference != null)
            {
                if (dateBox.IsValid)
                {
                    dateBox.frameReference.BackgroundColor = Colors.Get(copyColor);
                }
            }
        }

        /// <summary>
        /// Enter the text color.
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
         propertyName: nameof(TextColor),
         returnType: typeof(ColorUI),
         declaringType: typeof(DateBox),
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
            DateBox dateBox = (DateBox)bindable;
            ColorUI color = (ColorUI)newValue;

            if (dateBox.datePickerReference != null)
            {
                dateBox.datePickerReference.TextColor = Colors.Get(color);
            }
        }

        /// <summary>
        /// Enter the  BorderColor
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
           propertyName: nameof(BorderColor),
           returnType: typeof(ColorUI),
           declaringType: typeof(DateBox),
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
            DateBox dateBox = (DateBox)bindable;
            ColorUI copyBorderColor = (ColorUI)newValue;

            if (dateBox.frameReference != null)
            {
                if (dateBox.IsValid)
                {
                    dateBox.frameReference.BorderColor = Colors.Get(copyBorderColor);
                }
            }
        }

        /// <summary>
        /// Enter the font size.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(DateBox),
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
            DateBox dateBox = (DateBox)bindable;
            double copyFontSize = (double)newValue;

            if (dateBox.datePickerReference != null)
            {
                dateBox.datePickerReference.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Biggest possible date to choose
        /// </summary>
        [Bindable(true)]
        public DateTime Maximum
        {
            get
            {
                return currentMaximum; 
            }
            set
            {
                currentMaximum = value;
                datePickerReference.MaximumDate = value;
            }
        }

        /// <summary>
        /// Lowest possible date to choose
        /// </summary>
        [Bindable(true)]
        public DateTime Minimum
        {
            get
            {
                return currentMinimum;
            }
            set
            {
                currentMinimum = value;
                datePickerReference.MinimumDate = value;
            }
        }
    }
}
