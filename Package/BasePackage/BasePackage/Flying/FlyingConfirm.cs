using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Flying
    {
        /// <summary>
        /// Class Flying Confirm
        /// </summary>
        public class FlyingConfirm: AbsoluteLayout
        {
            public Answer Answer { get; private set; }
            
            private StackLayout dataItems = new StackLayout();

            private FlyingConfirmInternal flyingConfirmInternal;

            private bool isAnswered;

            /// <summary>
            /// Call is Chosen
            /// </summary>
            public event EventHandler Chosen;

            private bool isInternal;

            private ColorUI borderColorButtons = ColorUI.Black;
            private ColorUI borderColor = ColorUI.Black;
            private ColorUI textColorButtons = ColorUI.Black;
            private ColorUI textColorQuestion = ColorUI.Black;
            private ColorUI colorUIButtons = ColorUI.BlueSky;
            private ColorUI colorUI = ColorUI.BlueSky;
            private FontAttributes fontTypeQuestion = FontAttributes.None;
            private FontAttributes fontTypeButtons = FontAttributes.None;

            /// <summary>
            /// Constructor of FlyingConfirm
            /// </summary>
            public FlyingConfirm()
            {
                InitAll();
            }

            public void InitAll()
            {
                flyingConfirmInternal = null;

                isInternal = true;
                isAnswered = false;
                dataItems.Spacing = 0;

                flyingConfirmInternal = new FlyingConfirmInternal();
                flyingConfirmInternal.TextConfirm = TextConfirm;
                flyingConfirmInternal.TextCancel = TextCancel;
                flyingConfirmInternal.TextQuestion = TextQuestion;
                flyingConfirmInternal.AddItem("__Laavor*+-", this);

                AbsoluteLayout.SetLayoutBounds(dataItems, new Rectangle(0.0, 0.0, 1.0, 1.0));
                AbsoluteLayout.SetLayoutFlags(dataItems, AbsoluteLayoutFlags.All);

                this.Children.Add(dataItems);

                this.Children.Add(flyingConfirmInternal);

                isInternal = false;
            }

            public void Show()
            {
                if (flyingConfirmInternal != null)
                {
                    if (BlockWhenAnswered && isAnswered)
                    {
                        return;
                    }
                    else
                    {
                        flyingConfirmInternal.Show();
                    }
                }
            }

            public void Cancel(string key)
            {
                if (key == "__Laavor*+-")
                {
                    this.Answer = Answer.Canceled;
                    isAnswered = true;
                    //flyingConfirmInternal.Hide();
                    Chosen?.Invoke(this, EventArgs.Empty);
                }
            }

            public void Confirm(string key)
            {
                if (key == "__Laavor*+-")
                {
                    this.Answer = Answer.Confirmed;
                    isAnswered = true;
                    //flyingConfirmInternal.Hide();
                    Chosen?.Invoke(this, EventArgs.Empty);
                }
            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="child"></param>
            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);

                if (!isInternal)
                {
                    if (child.GetType() == typeof(FlyingConfirmContent))
                    {
                        StackLayout userContentBox = (StackLayout)child;
                        for (int iS = 0; iS < userContentBox.Children.Count; iS++)
                        {
                            dataItems.Children.Add(userContentBox.Children[iS]);
                        }
                    }
                    else
                    {
                        Children.RemoveAt(Children.Count - 1);
                    }
                }
            }

            /// <summary>
            /// Enter the BlockWhenAnswered.
            /// </summary>
            public static readonly BindableProperty BlockWhenAnsweredProperty = BindableProperty.Create(
                propertyName: nameof(BlockWhenAnswered),
                returnType: typeof(bool),
                declaringType: typeof(FlyingConfirm),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the BlockWhenAnswered.
            /// </summary>
            public bool BlockWhenAnswered
            {
                get
                {
                    return (bool)GetValue(BlockWhenAnsweredProperty);
                }
                set
                {
                    SetValue(BlockWhenAnsweredProperty, value);
                }
            }

            /// <summary>
            /// Enter the font size of text Question.
            /// </summary>
            public static readonly BindableProperty FontSizeQuestionProperty = BindableProperty.Create(
                propertyName: nameof(FontSizeQuestion),
                returnType: typeof(double),
                declaringType: typeof(FlyingConfirm),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizeQuestionPropertyChanged);

            /// <summary>
            /// Enter the font size of text Question.
            /// </summary>
            public double FontSizeQuestion
            {
                get
                {
                    return (double)GetValue(FontSizeQuestionProperty);
                }
                set
                {
                    SetValue(FontSizeQuestionProperty, value);
                }
            }

            private static void FontSizeQuestionPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirm flyingConfirm = (FlyingConfirm)bindable;
                double fontSize = (double)newValue;

                if (flyingConfirm.flyingConfirmInternal != null)
                {
                    flyingConfirm.flyingConfirmInternal.FontSizeQuestion = fontSize;
                }
            }

            /// <summary>
            /// Enter the font size of text Buttons.
            /// </summary>
            public static readonly BindableProperty FontSizeButtonsProperty = BindableProperty.Create(
                propertyName: nameof(FontSizeButtons),
                returnType: typeof(double),
                declaringType: typeof(FlyingConfirm),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizeButtonsPropertyChanged);

            /// <summary>
            /// Enter the font size of text Buttons.
            /// </summary>
            public double FontSizeButtons
            {
                get
                {
                    return (double)GetValue(FontSizeButtonsProperty);
                }
                set
                {
                    SetValue(FontSizeButtonsProperty, value);
                }
            }

            private static void FontSizeButtonsPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirm flyingConfirm = (FlyingConfirm)bindable;
                double fontSize = (double)newValue;

                if (flyingConfirm.flyingConfirmInternal != null)
                {
                    flyingConfirm.flyingConfirmInternal.FontSizeButtons = fontSize;
                }
            }

            /// <summary>
            /// Set FontTypeQuestion
            /// </summary>
            [Bindable(true)]
            public FontAttributes FontTypeQuestion
            {
                get
                {
                    return fontTypeQuestion;
                }
                set
                {
                    fontTypeQuestion = value;
                    FontTypeQuestionPropertyChanged();
                }
            }
                     
            private void FontTypeQuestionPropertyChanged()
            {
                if (flyingConfirmInternal != null)
                {
                    flyingConfirmInternal.FontTypeQuestion = fontTypeQuestion;
                }
            }

            /// <summary>
            /// Set FontTypeButtons
            /// </summary>
            [Bindable(true)]
            public FontAttributes FontTypeButtons
            {
                get
                {
                    return fontTypeButtons;
                }
                set
                {
                    fontTypeButtons = value;
                    FontTypeButtonsPropertyChanged();
                }
            }
            
            private void FontTypeButtonsPropertyChanged()
            {
                if (flyingConfirmInternal != null)
                {
                    flyingConfirmInternal.FontTypeQuestion = fontTypeQuestion;
                }
            }

            /// <summary>
            /// Enter the FontFamily Question.
            /// </summary>
            public static readonly BindableProperty FontFamilyQuestionProperty = BindableProperty.Create(
                propertyName: nameof(FontFamilyQuestion),
                returnType: typeof(string),
                declaringType: typeof(FlyingConfirm),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontFamilyQuestionPropertyChanged);

            /// <summary>
            /// Enter the FontFamily Question.
            /// </summary>
            public string FontFamilyQuestion
            {
                get
                {
                    return (string)GetValue(FontFamilyQuestionProperty);
                }
                set
                {
                    SetValue(FontFamilyQuestionProperty, value);
                }
            }

            private static void FontFamilyQuestionPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirm flyingConfirm = (FlyingConfirm)bindable;
                string fontFamily = (string)newValue;

                if (flyingConfirm.flyingConfirmInternal != null)
                {
                    flyingConfirm.flyingConfirmInternal.FontFamilyQuestion = fontFamily;
                }
            }

            /// <summary>
            /// Enter the FontFamily Buttons.
            /// </summary>
            public static readonly BindableProperty FontFamilyButtonsProperty = BindableProperty.Create(
                propertyName: nameof(FontFamilyButtons),
                returnType: typeof(string),
                declaringType: typeof(FlyingConfirm),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontFamilyButtonsPropertyChanged);

            /// <summary>
            /// Enter the FontFamily Buttons.
            /// </summary>
            public string FontFamilyButtons
            {
                get
                {
                    return (string)GetValue(FontFamilyButtonsProperty);
                }
                set
                {
                    SetValue(FontFamilyButtonsProperty, value);
                }
            }

            private static void FontFamilyButtonsPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirm flyingConfirm = (FlyingConfirm)bindable;
                string fontFamily = (string)newValue;

                if (flyingConfirm.flyingConfirmInternal != null)
                {
                    flyingConfirm.flyingConfirmInternal.FontFamilyButtons = fontFamily;
                }
            }

            /// <summary>
            /// Set ColorButtonsUI
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorUIButtons
            {
                get
                {
                    return colorUIButtons;
                }
                set
                {
                    colorUIButtons = value;
                    ColorUIButtonsPropertyChanged();
                }
            }

            private void ColorUIButtonsPropertyChanged()
            {
                if (flyingConfirmInternal != null)
                {
                    flyingConfirmInternal.ColorUIButtons = colorUIButtons;
                }

                if (flyingConfirmInternal != null)
                {
                    flyingConfirmInternal.ColorUIButtons = colorUIButtons;
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
                if (flyingConfirmInternal != null)
                {
                    flyingConfirmInternal.ColorUI = colorUI;
                }
            }

            /// <summary>
            /// Set TextColorButtons
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColorButtons
            {
                get
                {
                    return textColorButtons;
                }
                set
                {
                    textColorButtons = value;
                    TextColorButtonsPropertyChanged();
                }
            }
                     
            private void TextColorButtonsPropertyChanged()
            {
                if (flyingConfirmInternal != null)
                {
                    flyingConfirmInternal.TextColorButtons = textColorButtons;
                }
            }

            /// <summary>
            /// Set TextColorQuestion
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColorQuestion
            {
                get
                {
                    return textColorQuestion;
                }
                set
                {
                    textColorQuestion = value;
                    TextColorQuestionPropertyChanged();
                }
            }

            private void TextColorQuestionPropertyChanged()
            {
                if (flyingConfirmInternal != null)
                {
                    flyingConfirmInternal.TextColorQuestion = textColorQuestion;
                }
            }

            /// <summary>
            /// Set BorderColorButtons
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColorButtons
            {
                get
                {
                    return borderColorButtons;
                }
                set
                {
                    borderColorButtons = value;
                    BorderColorButtonsPropertyChanged();
                }
            }

            private void BorderColorButtonsPropertyChanged()
            {
                if (flyingConfirmInternal != null)
                {
                    flyingConfirmInternal.BorderColorButtons = borderColorButtons;
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
                if (flyingConfirmInternal != null)
                {
                    flyingConfirmInternal.BorderColor = borderColor;
                }
            }

            /// <summary>
            /// Enter the Text Confirm
            /// </summary>
            public static readonly BindableProperty TextConfirmProperty = BindableProperty.Create(
                propertyName: nameof(TextConfirm),
                returnType: typeof(string),
                declaringType: typeof(FlyingConfirm),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextConfirmPropertyChanged);

            /// <summary>
            /// Enter the Text Confirm
            /// </summary>
            public string TextConfirm
            {
                get
                {
                    return (string)GetValue(TextConfirmProperty);
                }
                set
                {
                    SetValue(TextConfirmProperty, value);
                }
            }

            private static void TextConfirmPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirm flyingConfirm = (FlyingConfirm)bindable;
                string text = (string)newValue;

                if (flyingConfirm.flyingConfirmInternal != null)
                {
                    flyingConfirm.flyingConfirmInternal.TextConfirm = text;
                }
            }

            /// <summary>
            /// Enter the text Cancel
            /// </summary>
            public static readonly BindableProperty TextCancelProperty = BindableProperty.Create(
                propertyName: nameof(TextCancel),
                returnType: typeof(string),
                declaringType: typeof(FlyingConfirm),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextCancelPropertyChanged);

            /// <summary>
            /// Enter the Text Cancel
            /// </summary>
            public string TextCancel
            {
                get
                {
                    return (string)GetValue(TextCancelProperty);
                }
                set
                {
                    SetValue(TextCancelProperty, value);
                }
            }

            private static void TextCancelPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirm flyingConfirm = (FlyingConfirm)bindable;
                string text = (string)newValue;

                if (flyingConfirm.flyingConfirmInternal != null)
                {
                    flyingConfirm.flyingConfirmInternal.TextCancel = text;
                }
            }

            /// <summary>
            /// Enter the text Question
            /// </summary>
            public static readonly BindableProperty TextQuestionProperty = BindableProperty.Create(
                propertyName: nameof(TextQuestion),
                returnType: typeof(string),
                declaringType: typeof(FlyingConfirm),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextQuestionPropertyChanged);

            /// <summary>
            /// Enter the text Question
            /// </summary>
            public string TextQuestion
            {
                get
                {
                    return (string)GetValue(TextQuestionProperty);
                }
                set
                {
                    SetValue(TextQuestionProperty, value);
                }
            }

            private static void TextQuestionPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirm flyingConfirm = (FlyingConfirm)bindable;
                string text = (string)newValue;

                if (flyingConfirm.flyingConfirmInternal != null)
                {
                    flyingConfirm.flyingConfirmInternal.TextQuestion = text;
                }
            }
        }
    }
}
