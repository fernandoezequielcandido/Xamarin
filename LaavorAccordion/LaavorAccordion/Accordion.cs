using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorAccordion
{
    /// <summary>
    /// Class Accordion
    /// </summary>
    public class Accordion : StackLayout
    {
        private StackLayout dataItems;

        private bool canChangeListSelect = true;

        private const double opacity = 0.4;

        /// <summary>
        /// Call when event TitleCliked
        /// </summary>
        [Obsolete("[This event will be discontinued in future releases] - use TitleTouched.")]
        public event EventHandler TitleClicked;

        /// <summary>
        /// Call when event TitleTouched
        /// </summary>
        public event EventHandler TitleTouched;

        private List<SectionContent> listIndex = new List<SectionContent>();
        private List<MergeBar> listMerge = new List<MergeBar>();
        private List<Frame> listFrames = new List<Frame>();

        private FontAttributes currentFontTypeTitle = FontAttributes.None;
        private DesignType currentDesignType = DesignType.Shinning;
        private ColorUI currentColorUI = ColorUI.Blue;
        private ColorUI currentContentColor = ColorUI.White;
        private ColorUI currentBorderContentColor = ColorUI.Gray;
        private ColorUI currentTextColorTitle = ColorUI.Black;

        /// <summary>
        /// Constructor of Accordion
        /// </summary>
        public Accordion() : base()
        {
            dataItems = new StackLayout();
            Children.Add(dataItems);
        }

        private void TitleClick_Tapped(object sender, EventArgs e)
        {
            ClickTitle(sender);
            TitleTouched?.Invoke(this, EventArgs.Empty);
            TitleClicked?.Invoke(this, EventArgs.Empty);
        }

        private TapGestureRecognizer GetClick()
        {
            var click = new TapGestureRecognizer();
            click.Tapped += TitleClick_Tapped;
            return click;
        }

        private void ClickTitle(object sender)
        {
            if (sender.GetType() == typeof(BarAccordion))
            {
                SetValue(SelectedSectionIndexProperty, (sender as BarAccordion).Index);
            }
            else if (sender.GetType() == typeof(BarTitle))
            {
                SetValue(SelectedSectionIndexProperty, (sender as BarTitle).Index);
            }
        }

        private TapGestureRecognizer GetClickAnimation(BarAccordion imageButton, BarTitle labelText)
        {
            TapGestureRecognizer animationTapImg = new TapGestureRecognizer();
            animationTapImg.Tapped += async (sender, e) =>
            {
                await imageButton.ScaleTo(0.97, 80, Easing.Linear);
                await labelText.ScaleTo(0.97, 80, Easing.Linear);
                await imageButton.ScaleTo(1, 80, Easing.Linear);
                await labelText.ScaleTo(1, 80, Easing.Linear);
            };

            return animationTapImg;
        }

        /// <summary>
        /// SelectedSectionValue (Get, Set).
        /// </summary>
        public static readonly BindableProperty SelectedSectionValueProperty = BindableProperty.Create(
            propertyName: nameof(SelectedSectionValue),
            returnType: typeof(string),
            declaringType: typeof(Accordion),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: SelectedSectionValueChanged);

        /// <summary>
        /// SelectedSectionValue (Get, SET).
        /// </summary>
        public string SelectedSectionValue
        {
            get
            {
                return (string)GetValue(SelectedSectionValueProperty);
            }
            set
            {
                SetValue(SelectedSectionValueProperty, value);
            }
        }

        private static void SelectedSectionValueChanged(object bindable, object oldValue, object newValue)
        {
            Accordion accordion = (Accordion)bindable;
            string copyValue = (string)newValue;
            if (accordion.canChangeListSelect)
            {
                accordion.canChangeListSelect = false;
                for (int iL = 0; iL < accordion.listIndex.Count; iL++)
                {
                    if (copyValue == accordion.listIndex[iL].Value)
                    {
                        accordion.SetIndex(iL);
                        accordion.SetTitle(accordion.listIndex[iL].Title);

                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Clear();
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();
                        accordion.listMerge[iL].barAccordion.Opacity = opacity;
                        accordion.listMerge[iL].barTitle.Opacity = opacity;

                        accordion.listIndex[iL].SetContent("VisibleLL4488*-+++kmasdflaavor___");
                        accordion.listFrames[iL].IsVisible = true;
                    }
                    else
                    {
                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Clear();
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();

                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Add(accordion.GetClickAnimation(accordion.listMerge[iL].barAccordion, accordion.listMerge[iL].barTitle));
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetClickAnimation(accordion.listMerge[iL].barAccordion, accordion.listMerge[iL].barTitle));
                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Add(accordion.GetClick());
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetClick());

                        accordion.listMerge[iL].barAccordion.Opacity = 1;
                        accordion.listMerge[iL].barTitle.Opacity = 1;

                        accordion.listIndex[iL].SetContent("InvisiblekktyRE35__00.)*+-////]]]}}}}}");
                        accordion.listFrames[iL].IsVisible = false;
                    }
                }
                accordion.canChangeListSelect = true;
            }
        }

        /// <summary>
        /// SelectedSectionText (Get, SET).
        /// </summary>
        public static readonly BindableProperty SelectedSectionTitleProperty = BindableProperty.Create(
            propertyName: nameof(SelectedSectionTitle),
            returnType: typeof(string),
            declaringType: typeof(Accordion),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: SelectedSectionTitleChanged);

        /// <summary>
        /// SelectedSectionTitle (Get, SET).
        /// </summary>
        public string SelectedSectionTitle
        {
            get
            {
                return (string)GetValue(SelectedSectionTitleProperty);
            }
            set
            {
                SetValue(SelectedSectionTitleProperty, value);
            }
        }

        private static void SelectedSectionTitleChanged(object bindable, object oldValue, object newValue)
        {
            Accordion accordion = (Accordion)bindable;
            string copyTitle = (string)newValue;
            if (accordion.canChangeListSelect)
            {
                accordion.canChangeListSelect = false;
                for (int iL = 0; iL < accordion.listIndex.Count; iL++)
                {
                    if (copyTitle == accordion.listIndex[iL].Title)
                    {
                        accordion.SetIndex(iL);
                        accordion.SetValue(accordion.listIndex[iL].Value);

                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Clear();
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();
                        accordion.listMerge[iL].barAccordion.Opacity = opacity;
                        accordion.listMerge[iL].barTitle.Opacity = opacity;

                        accordion.listIndex[iL].SetContent("VisibleLL4488*-+++kmasdflaavor___");
                        accordion.listFrames[iL].IsVisible = true;
                    }
                    else
                    {
                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Clear();
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();

                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Add(accordion.GetClickAnimation(accordion.listMerge[iL].barAccordion, accordion.listMerge[iL].barTitle));
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetClickAnimation(accordion.listMerge[iL].barAccordion, accordion.listMerge[iL].barTitle));
                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Add(accordion.GetClick());
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetClick());

                        accordion.listMerge[iL].barAccordion.Opacity = 1;
                        accordion.listMerge[iL].barTitle.Opacity = 1;

                        accordion.listIndex[iL].SetContent("InvisiblekktyRE35__00.)*+-////]]]}}}}}");
                        accordion.listFrames[iL].IsVisible = false;
                    }
                    accordion.canChangeListSelect = true;
                }
            }
        }

        /// <summary>
        /// SelectedSectionIndex (Get, SET).
        /// </summary>
        public static readonly BindableProperty SelectedSectionIndexProperty = BindableProperty.Create(
            propertyName: nameof(SelectedSectionIndex),
            returnType: typeof(int),
            declaringType: typeof(Accordion),
            defaultValue: 0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: SelectedSectionIndexChanged);

        /// <summary>
        /// SelectedSectionIndex (Get, SET).
        /// </summary>
        public double SelectedSectionIndex
        {
            get
            {
                return (int)GetValue(SelectedSectionIndexProperty);
            }
            set
            {
                SetValue(SelectedSectionIndexProperty, value);
            }
        }

        private static void SelectedSectionIndexChanged(object bindable, object oldValue, object newValue)
        {
            Accordion accordion = (Accordion)bindable;
            int copyIndex = (int)newValue;
            if (accordion.canChangeListSelect)
            {
                accordion.canChangeListSelect = false;
                for (int iL = 0; iL < accordion.listIndex.Count; iL++)
                {
                    if (copyIndex == iL)
                    {
                        accordion.SetTitle(accordion.listIndex[iL].Title);
                        accordion.SetValue(accordion.listIndex[iL].Value);

                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Clear();
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();
                        accordion.listMerge[iL].barAccordion.Opacity = opacity;
                        accordion.listMerge[iL].barTitle.Opacity = opacity;

                        accordion.listIndex[iL].SetContent("VisibleLL4488*-+++kmasdflaavor___");
                        accordion.listFrames[iL].IsVisible = true;
                    }
                    else
                    {
                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Clear();
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();

                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Add(accordion.GetClickAnimation(accordion.listMerge[iL].barAccordion, accordion.listMerge[iL].barTitle));
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetClickAnimation(accordion.listMerge[iL].barAccordion, accordion.listMerge[iL].barTitle));
                        accordion.listMerge[iL].barAccordion.GestureRecognizers.Add(accordion.GetClick());
                        accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetClick());

                        accordion.listMerge[iL].barAccordion.Opacity = 1;
                        accordion.listMerge[iL].barTitle.Opacity = 1;

                        accordion.listIndex[iL].SetContent("InvisiblekktyRE35__00.)*+-////]]]}}}}}");
                        accordion.listFrames[iL].IsVisible = false;
                    }
                }
                accordion.canChangeListSelect = true;
            }
        }

        private void SetTitle(string title)
        {
            SetValue(SelectedSectionTitleProperty, title);
        }

        private void SetValue(string value)
        {
            SetValue(SelectedSectionValueProperty, value);
        }

        private void SetIndex(int index)
        {
            SetValue(SelectedSectionIndexProperty, index);
        }

        /// <summary>
        /// Enter the title textcolor.
        /// </summary>
        [Bindable(true)]
        public ColorUI TextColorTitle
        {
            get
            {
                return currentTextColorTitle;
            }
            set
            {
                currentTextColorTitle = value;
                TextColorTitlePropertyChanged();
            }
        }

        private void TextColorTitlePropertyChanged()
        {
            for (int iM = 0; iM < listMerge.Count; iM++)
            {
                if (listMerge[iM].barTitle != null)
                {
                    listMerge[iM].barTitle.TextColor = GetColorFromColorUI(currentTextColorTitle);
                }
            }
        }

        /// <summary>
        /// Enter the font size of the title
        /// </summary>
        public static readonly BindableProperty FontSizeTitleProperty = BindableProperty.Create(
            propertyName: nameof(FontSizeTitle),
            returnType: typeof(double),
            declaringType: typeof(Accordion),
            defaultValue: 15.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizeTitlePropertyChanged
            );

        /// <summary>
        /// Enter the font size of the title
        /// </summary>
        public double FontSizeTitle
        {
            get
            {
                return (double)GetValue(FontSizeTitleProperty);
            }
            set
            {
                SetValue(FontSizeTitleProperty, value);
            }
        }

        private static void FontSizeTitlePropertyChanged(object bindable, object oldValue, object newValue)
        {
            Accordion accordion = (Accordion)bindable;
            double copyFontSizeTitle = (double)newValue;

            for (int iM = 0; iM < accordion.listMerge.Count; iM++)
            {
                if (accordion.listMerge[iM].barTitle != null)
                {
                    accordion.listMerge[iM].barTitle.FontSize = copyFontSizeTitle;
                }
            }
        }

        /// <summary>
        /// Enter the font family Title.
        /// </summary>
        public static readonly BindableProperty FontFamilyTitleProperty = BindableProperty.Create(
            propertyName: nameof(FontFamilyTitle),
            returnType: typeof(string),
            declaringType: typeof(Accordion),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontFamilyTitlePropertyChanged);

        /// <summary>
        /// Enter the font family Title.
        /// </summary>
        public string FontFamilyTitle
        {
            get
            {
                return (string)GetValue(FontFamilyTitleProperty);
            }
            set
            {
                SetValue(FontFamilyTitleProperty, value);
            }
        }

        private static void FontFamilyTitlePropertyChanged(object bindable, object oldValue, object newValue)
        {
            Accordion accordion = (Accordion)bindable;
            string copyFontFamily = (string)newValue;

            for (int iM = 0; iM < accordion.listMerge.Count; iM++)
            {
                if (accordion.listMerge[iM].barTitle != null)
                {
                    accordion.listMerge[iM].barTitle.FontFamily = copyFontFamily;
                }
            }
        }

        /// <summary>
        /// Enter the fonttype title (None, Bold, Italic).
        /// </summary>
        [Bindable(true)]
        public FontAttributes FontTypeTitle
        {
            get
            {
                return currentFontTypeTitle;
            }
            set
            {
                currentFontTypeTitle = value;
                FontTypeTitlePropertyChanged();
            }
        }

        private void FontTypeTitlePropertyChanged()
        {
            for (int iM = 0; iM < listMerge.Count; iM++)
            {
                if (listMerge[iM].barTitle != null)
                {
                    listMerge[iM].barTitle.FontAttributes = currentFontTypeTitle;
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
            for (int iM = 0; iM < listMerge.Count; iM++)
            {
                if (listMerge[iM].barAccordion != null)
                {
                    listMerge[iM].barAccordion.ChangeColor("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentColorUI);
                }
            }
        }

        /// <summary>
        /// Set ContentColor
        /// </summary>
        [Bindable(true)]
        public ColorUI ContentColor
        {
            get
            {
                return currentContentColor;
            }
            set
            {
                currentContentColor = value;
                ColorUIPropertyChanged();
            }
        }

        private void ContentPropertyChanged()
        {
            if (listFrames != null)
            {
                int countList = listFrames.Count;

                for (int iList = 0; iList < countList; iList++)
                {
                    listFrames[iList].BackgroundColor = GetColorFromColorUI(currentContentColor);
                }
            }
        }

        /// <summary>
        /// Set Boder Content Color
        /// </summary>
        [Bindable(true)]
        public ColorUI BorderContentColor
        {
            get
            {
                return currentBorderContentColor;
            }
            set
            {
                currentBorderContentColor = value;
                BorderContentColorPropertyChanged();
            }
        }

        private void BorderContentColorPropertyChanged()
        {
            if (listFrames != null)
            {
                int countList = listFrames.Count;

                for (int iList = 0; iList < countList; iList++)
                {
                    listFrames[iList].BorderColor = GetColorFromColorUI(currentBorderContentColor);
                }
            }
        }

        private Color GetColorFromColorUI(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Color.FromRgb(0, 0, 0);
                case ColorUI.Blue:
                    return Color.FromRgb(0, 0, 255);
                case ColorUI.Gray:
                    return Color.FromRgb(128, 128, 128);
                case ColorUI.Green:
                    return Color.FromRgb(0, 128, 0);
                case ColorUI.Red:
                    return Color.FromRgb(255, 0, 0);
                case ColorUI.Yellow:
                    return Color.FromRgb(255, 255, 0);
                case ColorUI.BlueLight:
                    return Color.FromRgb(170, 204, 255);
                case ColorUI.GreenLight:
                    return Color.FromRgb(0, 255, 0);
                case ColorUI.YellowLight:
                    return Color.FromRgb(255, 238, 170);
                case ColorUI.White:
                    return Color.FromRgb(255, 255, 255);
                case ColorUI.Pink:
                    return Color.FromRgb(255, 0, 255);
                case ColorUI.Orange:
                    return Color.FromRgb(255, 102, 0);
                case ColorUI.Brown:
                    return Color.FromRgb(128, 51, 0);
                case ColorUI.Purple:
                    return Color.FromRgb(128, 0, 128);
                case ColorUI.Turquoise:
                    return Color.FromRgb(0, 128, 128);
                case ColorUI.PinkLight:
                    return Color.FromRgb(255, 170, 204);
                case ColorUI.BlueSky:
                    return Color.FromRgb(85, 153, 255);
                case ColorUI.GrayLight:
                    return Color.FromRgb(204, 204, 204);
                case ColorUI.RedLight:
                    return Color.FromRgb(255, 128, 128);
                case ColorUI.OrangeLight:
                    return Color.FromRgb(255, 179, 128);
                case ColorUI.YellowDark:
                    return Color.FromRgb(255, 204, 0);
                case ColorUI.GreenDark:
                    return Color.FromRgb(34, 85, 0);
                case ColorUI.BlueDark:
                    return Color.FromRgb(0, 34, 85);
                case ColorUI.Aqua:
                    return Color.FromRgb(0, 255, 255);
                case ColorUI.Tan:
                    return Color.FromRgb(172, 157, 147);
                case ColorUI.GreenDarkness:
                    return Color.FromRgb(0, 34, 0);
                case ColorUI.BlueViolet:
                    return Color.FromRgb(138, 43, 226);
                default:
                    return Color.FromRgb(204, 204, 204);
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
                return currentDesignType;
            }
            set
            {
                currentDesignType = value;
                DesignTypePropertyChanged();
            }
        }

        private void DesignTypePropertyChanged()
        {
            for (int iM = 0; iM < listMerge.Count; iM++)
            {
                if (listMerge[iM].barAccordion != null)
                {
                    listMerge[iM].barAccordion.ChangeDesignType("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentDesignType);
                }
            }
        }

        /// <summary>
        /// Enter the width Accordion.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(Accordion),
            defaultValue: 250.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter the width Accordion.
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
            Accordion accordion = (Accordion)bindable;
            double accordionWidth = (double)newValue;

            for (int iM = 0; iM < accordion.listMerge.Count; iM++)
            {
                if (accordion.listMerge[iM].barAccordion != null)
                {
                    accordion.listMerge[iM].barAccordion.WidthRequest = accordionWidth;
                }
            }
        }

        /// <summary>
        /// Enter the heightBarTitle
        /// </summary>
        public static readonly BindableProperty HeightBarTitleProperty = BindableProperty.Create(
            propertyName: nameof(HeightBarTitle),
            returnType: typeof(double),
            declaringType: typeof(Accordion),
            defaultValue: 30.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightBarTitlePropertyChanged);

        /// <summary>
        /// Enter the heightBarTitle.
        /// </summary>
        public double HeightBarTitle
        {
            get
            {
                return (double)GetValue(HeightBarTitleProperty);
            }
            set
            {
                SetValue(HeightBarTitleProperty, value);
            }
        }

        private static void HeightBarTitlePropertyChanged(object bindable, object oldValue, object newValue)
        {
            Accordion accordion = (Accordion)bindable;
            double groupHeight = (double)newValue;

            for (int iMerge = 0; iMerge < accordion.listMerge.Count; iMerge++)
            {
                if (accordion.listMerge[iMerge].barTitle != null)
                {
                    accordion.listMerge[iMerge].barTitle.HeightRequest = groupHeight;
                }
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            if (child.GetType() == typeof(SectionContent))
            {
                SectionContent userItem = (SectionContent)child;
                base.OnChildAdded(child);

                SectionContent item = new SectionContent();
                item.WidthRequest = Width;

                if (userItem.Content != null)
                {
                    item.Content = userItem.Content;
                }
                else
                {
                    for (int iS = 0; iS < userItem.Children.Count; iS++)
                    {
                        item.Children.Add(userItem.Children[iS]);
                    }
                }

                item.Value = userItem.Value;
                item.Title = userItem.Title;

                Frame frame = new Frame()
                {
                    BorderColor = GetColorFromColorUI(currentBorderContentColor),
                    WidthRequest = Width - 42,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    BackgroundColor = GetColorFromColorUI(currentContentColor),
                    HasShadow = true,
                    Margin = new Thickness(0, -7, 0, 0)
                };

                frame.Content = item;

                if (dataItems.Children.Count == 0)
                {
                    item.SetContent("VisibleLL4488*-+++kmasdflaavor___");
                    dataItems.Children.Add(CreateBar(userItem.Title, false, listIndex.Count));
                    frame.IsVisible = true;
                }
                else
                {
                    dataItems.Children.Add(CreateBar(userItem.Title, true, listIndex.Count));
                    frame.IsVisible = false;
                }

                listFrames.Add(frame);
                listIndex.Add(item);
                dataItems.Children.Add(frame);
            }

        }

        private View CreateBar(string title, bool spacingNormal, int index)
        {
            BarAccordion imageButton = new BarAccordion("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentDesignType, currentColorUI, index);
            imageButton.WidthRequest = Width;
            imageButton.MinimumWidthRequest = Width;
            imageButton.HeightRequest = 30;
            imageButton.MinimumHeightRequest = 30;

            BarTitle labelText = new BarTitle();
            labelText.SetIndex("fernandoLaavor77+*_87WW", index);
            labelText.Text = title;
            labelText.TextColor = GetColorFromColorUI(currentTextColorTitle);
            labelText.FontAttributes = currentFontTypeTitle;
            labelText.BackgroundColor = Color.Transparent;
            labelText.FontFamily = FontFamilyTitle;
            labelText.HorizontalOptions = LayoutOptions.Center;
            labelText.FontSize = FontSizeTitle;

            AbsoluteLayout.SetLayoutFlags(labelText, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labelText, new Rectangle(0.5, 0.5, -1, -1));

            if (spacingNormal)
            {
                imageButton.Margin = new Thickness(0, -7, 0, 0);
                labelText.Margin = new Thickness(0, -7, 0, 0);
                imageButton.GestureRecognizers.Add(GetClickAnimation(imageButton, labelText));
                labelText.GestureRecognizers.Add(GetClickAnimation(imageButton, labelText));
                imageButton.GestureRecognizers.Add(GetClick());
                labelText.GestureRecognizers.Add(GetClick());
            }
            else
            {
                imageButton.Opacity = opacity;
                labelText.Opacity = opacity;
            }

            imageButton.HeightRequest = HeightBarTitle;

            listMerge.Insert(index, new MergeBar() { barAccordion = imageButton, barTitle = labelText });

            AbsoluteLayout absolute = new AbsoluteLayout();
            absolute.HorizontalOptions = LayoutOptions.Center;

            absolute.Children.Add(imageButton);
            absolute.Children.Add(labelText);

            StackLayout returnValue = new StackLayout();
            returnValue.Children.Add(absolute);
            return returnValue;
        }

    }
}
