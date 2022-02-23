using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Choice
    {
        /// <summary>
        /// Class PickTextBase
        /// </summary>
        public class PickTextBase : Button
        {
            /// <summary>
            /// Index of PickTextBase In ChoiceText
            /// </summary>
            public int Index { get; private set; }

            private ColorUI textColorChosen = ColorUI.Black;
            private ColorUI textColorUnChosen = ColorUI.GrayLight;
            private ColorUI borderColorChosen = ColorUI.Transparent;
            private ColorUI borderColorUnChosen = ColorUI.Transparent;
            private ColorUI colorUIChosen = ColorUI.Transparent;
            private ColorUI colorUIUnChosen = ColorUI.Transparent;

            private FontAttributes fontType = FontAttributes.None;

            /// <summary>
            /// Constructor of PickTextBase
            /// </summary>
            public PickTextBase() : base()
            {
            }

            /// <summary>
            /// Cronstructor of LaavorWord
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="index"></param>
            /// <param name="value"></param>
            public PickTextBase(string hash, int index, string value) : base()
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Invalid Hash");
                }

                this.Value = value;
                this.Index = index;
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
                    FontTypeChanged();
                }
            }

            private void FontTypeChanged()
            {
               FontAttributes = fontType;
            }

            /// <summary>
            /// Enter the height.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(PickTextBase),
                defaultValue: 30.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: HeightPropertyChanged);

            /// <summary>
            /// Enter the height.
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
                PickTextBase choiceTextBase = (PickTextBase)bindable;
                double height = (double)newValue;
                choiceTextBase.HeightRequest = height;
            }

            /// <summary>
            /// Enter the width.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(PickTextBase),
                defaultValue: 180.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthPropertyChanged);

            /// <summary>
            /// Enter the width.
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
                PickTextBase choiceTextBase = (PickTextBase)bindable;
                double width = (double)newValue;
                choiceTextBase.WidthRequest = width;
            }

            /// <summary>
            /// Enter the IsChosen.
            /// </summary>
            public static readonly BindableProperty IsChosenProperty = BindableProperty.Create(
                propertyName: nameof(IsChosen),
                returnType: typeof(bool),
                declaringType: typeof(PickTextBase),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the IsChosen.
            /// </summary>
            public bool IsChosen
            {
                get
                {
                    return (bool)GetValue(IsChosenProperty);
                }
                set
                {
                    SetValue(IsChosenProperty, value);
                }
            }

            /// <summary>
            /// Enter the Value
            /// </summary>
            public static readonly BindableProperty ValueProperty = BindableProperty.Create(
                propertyName: nameof(Value),
                returnType: typeof(string),
                declaringType: typeof(PickTextBase),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the value
            /// </summary>
            public string Value
            {
                get
                {
                    return (string)GetValue(ValueProperty);
                }
                set
                {
                    SetValue(ValueProperty, value);
                }
            }

            /// <summary>
            /// Set TextColorChosen
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColorChosen
            {
                get
                {
                    return textColorChosen;
                }
                set
                {
                    textColorChosen = value;
                    TextColorChosenPropertyChanged();
                }
            }

            private void TextColorChosenPropertyChanged()
            {
                if (IsChosen)
                {
                    TextColor = Colors.Get(textColorChosen);
                }
            }

            /// <summary>
            /// Set TextColorUnChosen
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColorUnChosen
            {
                get
                {
                    return textColorUnChosen;
                }
                set
                {
                    textColorUnChosen = value;
                    TextColorUnChosenPropertyChanged();
                }
            }

            private void TextColorUnChosenPropertyChanged()
            {
                if (!IsChosen)
                {
                    TextColor = Colors.Get(textColorUnChosen);
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
                if (IsChosen)
                {
                    BorderColor = Colors.Get(borderColorChosen);
                }
            }

            /// <summary>
            /// Set BorderColorUnChosen
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColorUnChosen
            {
                get
                {
                    return borderColorUnChosen;
                }
                set
                {
                    borderColorUnChosen = value;
                    BorderColorPropertyUnChosen();
                }
            }

            private void BorderColorPropertyUnChosen()
            {
                if (!IsChosen)
                {
                    BorderColor = Colors.Get(borderColorUnChosen);
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
                if (IsChosen)
                {
                    BackgroundColor = Colors.Get(colorUIChosen);
                }
            }

            /// <summary>
            /// Set ColorUIUnChosen
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorUIUnChosen
            {
                get
                {
                    return colorUIUnChosen;
                }
                set
                {
                    colorUIUnChosen = value;
                    ColorUIUnChosenPropertyChanged();
                }
            }

            private void ColorUIUnChosenPropertyChanged()
            {
                if (!IsChosen)
                {
                    BackgroundColor = Colors.Get(colorUIUnChosen);
                }
            }


            /// <summary>
            /// Enter the text Chosen
            /// </summary>
            public static readonly BindableProperty TextChosenProperty = BindableProperty.Create(
                propertyName: nameof(TextChosen),
                returnType: typeof(string),
                declaringType: typeof(PickTextBase),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextChosenPropertyChanged);

            /// <summary>
            /// Enter the text Chosen
            /// </summary>
            public string TextChosen
            {
                get
                {
                    return (string)GetValue(TextChosenProperty);
                }
                set
                {
                    SetValue(TextChosenProperty, value);
                }
            }

            private static void TextChosenPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickTextBase choiceTextBase = (PickTextBase)bindable;
                string text = (string)newValue;

                if (choiceTextBase.IsChosen)
                {
                    choiceTextBase.Text = text;
                }
            }

            /// <summary>
            /// Enter the text UnChosen
            /// </summary>
            public static readonly BindableProperty TextUnChosenProperty = BindableProperty.Create(
                propertyName: nameof(TextUnChosen),
                returnType: typeof(string),
                declaringType: typeof(PickTextBase),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextUnChosenPropertyChanged);

            /// <summary>
            /// Enter the text UnChosen
            /// </summary>
            public string TextUnChosen
            {
                get
                {
                    return (string)GetValue(TextUnChosenProperty);
                }
                set
                {
                    SetValue(TextUnChosenProperty, value);
                }
            }

            private static void TextUnChosenPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickTextBase choiceTextBase = (PickTextBase)bindable;
                string text = (string)newValue;

                if (!choiceTextBase.IsChosen)
                {
                    choiceTextBase.Text = text;
                }
            }
        }
    }
}
