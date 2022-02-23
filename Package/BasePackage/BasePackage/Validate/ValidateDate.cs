using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Validate
    {
        /// <summary>
        /// Class ValidateDate 
        /// </summary>
        public class ValidateDate : ValidateBase
        {
            /// <summary>
            /// Date Chosen
            /// </summary>
            public DateTime DateChosen { get; private set; }

            private Grid grid;
            private DatePicker datePicker;
            private Frame frame;

            private ColorUI colorUI = ColorUI.White;
            private ColorUI textColor = ColorUI.Black;
            private ColorUI borderColor = ColorUI.Black;

            /// <summary>
            /// Constructor of ValidateDate
            /// </summary>
            public ValidateDate() : base()
            {
                InitiAll();
                IsValid = true;
            }

            private void InitiAll()
            {
                Children.Clear();

                datePicker = new DatePicker();
                datePicker.TextColor = Colors.Get(TextColor);
                datePicker.DateSelected += DatePickerReference_DateChosen;
                datePicker.FontSize = FontSize;
                datePicker.Margin = new Thickness(-10, -20, -10, -20);
                datePicker.WidthRequest = Width;
                datePicker.BackgroundColor = Color.Transparent;
                datePicker.Date = InitialDate;

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

                frame.HasShadow = true;
                frame.Content = datePicker;

                grid.Children.Add(frame, 0, 0);

                Children.Add(grid);
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
            /// Start Date
            /// </summary>
            public static readonly BindableProperty InitialDateProperty = BindableProperty.Create(
                propertyName: nameof(InitialDate),
                returnType: typeof(DateTime),
                declaringType: typeof(ValidateDate),
                defaultValue: DateTime.Today,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: InitialDatePropertyChanged);

            /// <summary>
            /// Start Date
            /// </summary>
            public DateTime InitialDate
            {
                get
                {
                    return (DateTime)GetValue(InitialDateProperty);
                }
                set
                {
                    SetValue(InitialDateProperty, value);
                }
            }

            private static void InitialDatePropertyChanged(object bindable, object oldValue, object newValue)
            {
                ValidateDate validateDate = (ValidateDate)bindable;
                DateTime date = (DateTime)newValue;

                if (validateDate.datePicker != null)
                {
                    validateDate.datePicker.Date = (DateTime)newValue;
                }
            }

            /// <summary>
            /// Width of DateBox
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(ValidateDate),
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
                ValidateDate validateDate = (ValidateDate)bindable;
                double width = (double)newValue;

                if (validateDate.datePicker != null)
                {
                    validateDate.datePicker.WidthRequest = width;
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
                if (datePicker != null)
                {
                    datePicker.TextColor = Colors.Get(textColor);
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
            /// Enter the font size.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(ValidateDate),
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
                ValidateDate date = (ValidateDate)bindable;
                double fontSize = (double)newValue;

                if (date.datePicker != null)
                {
                    date.datePicker.FontSize = fontSize;
                }
            }

            /// <summary>
            /// Minimum Date
            /// </summary>
            public static readonly BindableProperty MinimumProperty = BindableProperty.Create(
                propertyName: nameof(Minimum),
                returnType: typeof(DateTime),
                declaringType: typeof(ValidateDate),
                defaultValue: DateTime.Today,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: MinimumPropertyChanged);

            /// <summary>
            /// Minimum Date
            /// </summary>
            public DateTime Minimum
            {
                get
                {
                    return (DateTime)GetValue(MinimumProperty);
                }
                set
                {
                    SetValue(MinimumProperty, value);
                }
            }

            private static void MinimumPropertyChanged(object bindable, object oldValue, object newValue)
            {
                ValidateDate validateDate = (ValidateDate)bindable;
                DateTime date = (DateTime)newValue;

                if (validateDate.datePicker != null)
                {
                    validateDate.datePicker.MinimumDate = date;
                }
            }

            /// <summary>
            /// Maximum Date
            /// </summary>
            public static readonly BindableProperty MaximumProperty = BindableProperty.Create(
                propertyName: nameof(Maximum),
                returnType: typeof(DateTime),
                declaringType: typeof(ValidateDate),
                defaultValue: DateTime.Today,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: MaximumPropertyChanged);

            /// <summary>
            /// Maximum Date
            /// </summary>
            public DateTime Maximum
            {
                get
                {
                    return (DateTime)GetValue(MaximumProperty);
                }
                set
                {
                    SetValue(MaximumProperty, value);
                }
            }

            private static void MaximumPropertyChanged(object bindable, object oldValue, object newValue)
            {
                ValidateDate validateDate = (ValidateDate)bindable;
                DateTime date = (DateTime)newValue;

                if (validateDate.datePicker != null)
                {
                    validateDate.datePicker.MaximumDate = date;
                }
            }

        }
    }
}
