using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Group
    {
        /// <summary>
        /// Class AccordionImage
        /// </summary>
        public class AccordionImage: StackLayout
        {
            private StackLayout dataItems;

            private bool canChangeListSelect = true;

            private const double opacity = 0.4;

            /// <summary>
            /// Call when event TitleTouched
            /// </summary>
            public event EventHandler TitleTouched;

            private List<AccordionSection> listIndex = new List<AccordionSection>();
            private List<AccordionImageAll> listMerge = new List<AccordionImageAll>();
            private List<Frame> listFrames = new List<Frame>();

            private ColorUI contentColor = ColorUI.White;
            private FontAttributes fontType = FontAttributes.Bold;
            private ColorUI textColor = ColorUI.Black;
            private ColorUI borderContentColor = ColorUI.Black;

            /// <summary>
            /// Constructor of AccordionImage
            /// </summary>
            public AccordionImage() : base()
            {
                dataItems = new StackLayout();
                Children.Add(dataItems);
            }

            private void TitleTouched_Tapped(object sender, EventArgs e)
            {
                TouchTitle(sender);
                TitleTouched?.Invoke(this, EventArgs.Empty);
            }

            private TapGestureRecognizer GetTouch()
            {
                var touch = new TapGestureRecognizer();
                touch.Tapped += TitleTouched_Tapped;
                return touch;
            }

            private void TouchTitle(object sender)
            {
                if (sender.GetType() == typeof(GroupBoxControl))
                {
                    SetValue(ChosenSectionIndexProperty, (sender as GroupBoxControl).Index);
                }
                else if (sender.GetType() == typeof(AccordionTitle))
                {
                    SetValue(ChosenSectionIndexProperty, (sender as AccordionTitle).Index);
                }
            }

            private TapGestureRecognizer GetTouchVivacity(Image imageButton, AccordionTitle labelText)
            {
                TapGestureRecognizer animationTapImg = new TapGestureRecognizer();
                animationTapImg.Tapped += async (sender, e) =>
                {
                    await imageButton.ScaleTo(0.97, 100, Easing.Linear);
                    await labelText.ScaleTo(0.97, 100, Easing.Linear);
                    await imageButton.ScaleTo(1, 100, Easing.Linear);
                    await labelText.ScaleTo(1, 100, Easing.Linear);
                };

                return animationTapImg;
            }

            /// <summary>
            /// ChosenSectionValue (Get, Set).
            /// </summary>
            public static readonly BindableProperty ChosenSectionValueProperty = BindableProperty.Create(
                propertyName: nameof(ChosenSectionValue),
                returnType: typeof(string),
                declaringType: typeof(AccordionImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ChosenSectionValueChanged);

            /// <summary>
            /// ChosenSectionValue (Get, SET).
            /// </summary>
            public string ChosenSectionValue
            {
                get
                {
                    return (string)GetValue(ChosenSectionValueProperty);
                }
                set
                {
                    SetValue(ChosenSectionValueProperty, value);
                }
            }

            private static void ChosenSectionValueChanged(object bindable, object oldValue, object newValue)
            {
                AccordionImage accordion = (AccordionImage)bindable;
                string value = (string)newValue;
                if (accordion.canChangeListSelect)
                {
                    accordion.canChangeListSelect = false;
                    if (accordion.listMerge != null && accordion.listIndex != null && accordion.listFrames != null)
                    {
                        for (int iL = 0; iL < accordion.listIndex.Count; iL++)
                        {
                            if (value == accordion.listIndex[iL].Value)
                            {
                                accordion.SetIndex(iL);
                                accordion.SetTitle(accordion.listIndex[iL].Title);

                                if (accordion.listMerge[iL].barImage != null)
                                {
                                    accordion.listMerge[iL].barImage.GestureRecognizers.Clear();
                                }

                                if (accordion.listMerge[iL].barTitle != null)
                                {
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();
                                }

                                if (accordion.listMerge[iL].barImage != null)
                                {
                                    accordion.listMerge[iL].barImage.Opacity = opacity;
                                }

                                if (accordion.listMerge[iL].barTitle != null)
                                {
                                    accordion.listMerge[iL].barTitle.Opacity = opacity;
                                }

                                accordion.listIndex[iL].SetContent("__Laavor*+-", true);
                                accordion.listFrames[iL].IsVisible = true;
                            }
                            else
                            {
                                if (accordion.listMerge[iL].barImage != null)
                                {
                                    accordion.listMerge[iL].barImage.GestureRecognizers.Clear();
                                }

                                if (accordion.listMerge[iL].barTitle != null)
                                {
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();
                                }

                                if (accordion.listMerge[iL].barImage != null && accordion.listMerge[iL].barTitle != null)
                                {
                                    accordion.listMerge[iL].barImage.GestureRecognizers.Add(accordion.GetTouchVivacity(accordion.listMerge[iL].barImage, accordion.listMerge[iL].barTitle));
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetTouchVivacity(accordion.listMerge[iL].barImage, accordion.listMerge[iL].barTitle));
                                    accordion.listMerge[iL].barImage.GestureRecognizers.Add(accordion.GetTouch());
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetTouch());

                                    accordion.listMerge[iL].barImage.Opacity = 1;
                                    accordion.listMerge[iL].barTitle.Opacity = 1;
                                }

                                accordion.listIndex[iL].SetContent("__Laavor*+-", false);
                                accordion.listFrames[iL].IsVisible = false;
                            }
                        }
                    }
                    accordion.canChangeListSelect = true;
                }
            }

            /// <summary>
            /// SelectedSectionText (Get, SET).
            /// </summary>
            public static readonly BindableProperty ChosenSectionTitleProperty = BindableProperty.Create(
                propertyName: nameof(ChosenSectionTitle),
                returnType: typeof(string),
                declaringType: typeof(AccordionImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ChosenSectionTitleChanged);

            /// <summary>
            /// ChosenSectionTitle (Get, SET).
            /// </summary>
            public string ChosenSectionTitle
            {
                get
                {
                    return (string)GetValue(ChosenSectionTitleProperty);
                }
                set
                {
                    SetValue(ChosenSectionTitleProperty, value);
                }
            }

            private static void ChosenSectionTitleChanged(object bindable, object oldValue, object newValue)
            {
                AccordionImage accordion = (AccordionImage)bindable;
                string title = (string)newValue;
                if (accordion.canChangeListSelect)
                {
                    accordion.canChangeListSelect = false;
                    if (accordion.listMerge != null && accordion.listIndex != null && accordion.listFrames != null)
                    {
                        for (int iL = 0; iL < accordion.listIndex.Count; iL++)
                        {
                            if (title == accordion.listIndex[iL].Title)
                            {
                                accordion.SetIndex(iL);
                                accordion.SetValue(accordion.listIndex[iL].Value);

                                if (accordion.listMerge != null)
                                {
                                    accordion.listMerge[iL].barImage.GestureRecognizers.Clear();
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();
                                    accordion.listMerge[iL].barImage.Opacity = opacity;
                                    accordion.listMerge[iL].barTitle.Opacity = opacity;
                                }

                                if (accordion.listIndex != null)
                                {
                                    accordion.listIndex[iL].SetContent("__Laavor*+-", true);
                                }

                                if (accordion.listFrames[iL] != null)
                                {
                                    accordion.listFrames[iL].IsVisible = true;
                                }
                            }
                            else
                            {
                                if (accordion.listMerge[iL].barImage != null && accordion.listMerge[iL].barTitle != null)
                                {
                                    accordion.listMerge[iL].barImage.GestureRecognizers.Clear();
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();

                                    accordion.listMerge[iL].barImage.GestureRecognizers.Add(accordion.GetTouchVivacity(accordion.listMerge[iL].barImage, accordion.listMerge[iL].barTitle));
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetTouchVivacity(accordion.listMerge[iL].barImage, accordion.listMerge[iL].barTitle));
                                    accordion.listMerge[iL].barImage.GestureRecognizers.Add(accordion.GetTouch());
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetTouch());

                                    accordion.listMerge[iL].barImage.Opacity = 1;
                                    accordion.listMerge[iL].barTitle.Opacity = 1;

                                    accordion.listIndex[iL].SetContent("__Laavor*+-", false);
                                    accordion.listFrames[iL].IsVisible = false;
                                }
                            }
                            accordion.canChangeListSelect = true;
                        }
                    }
                }
            }

            /// <summary>
            /// ChosenSectionIndex (Get, SET).
            /// </summary>
            public static readonly BindableProperty ChosenSectionIndexProperty = BindableProperty.Create(
                propertyName: nameof(ChosenSectionIndex),
                returnType: typeof(int),
                declaringType: typeof(AccordionImage),
                defaultValue: 0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ChosenSectionIndexChanged);

            /// <summary>
            /// ChosenSectionIndex (Get, SET).
            /// </summary>
            public double ChosenSectionIndex
            {
                get
                {
                    return (int)GetValue(ChosenSectionIndexProperty);
                }
                set
                {
                    SetValue(ChosenSectionIndexProperty, value);
                }
            }

            private static void ChosenSectionIndexChanged(object bindable, object oldValue, object newValue)
            {
                AccordionImage accordion = (AccordionImage)bindable;
                int index = (int)newValue;
                if (accordion.canChangeListSelect)
                {
                    accordion.canChangeListSelect = false;
                    if (accordion.listMerge != null && accordion.listIndex != null && accordion.listFrames != null)
                    {
                        for (int iL = 0; iL < accordion.listIndex.Count; iL++)
                        {
                            if (index == iL)
                            {
                                accordion.SetTitle(accordion.listIndex[iL].Title);
                                accordion.SetValue(accordion.listIndex[iL].Value);

                                if (accordion.listMerge != null)
                                {
                                    accordion.listMerge[iL].barImage.GestureRecognizers.Clear();
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();
                                    accordion.listMerge[iL].barImage.Opacity = opacity;
                                    accordion.listMerge[iL].barTitle.Opacity = opacity;
                                }

                                if (accordion.listIndex != null)
                                {
                                    accordion.listIndex[iL].SetContent("__Laavor*+-", true);
                                }

                                if (accordion.listFrames != null)
                                {
                                    accordion.listFrames[iL].IsVisible = true;
                                }
                            }
                            else
                            {
                                if (accordion.listMerge[iL].barImage != null && accordion.listMerge[iL].barTitle != null)
                                {
                                    accordion.listMerge[iL].barImage.GestureRecognizers.Clear();
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Clear();

                                    accordion.listMerge[iL].barImage.GestureRecognizers.Add(accordion.GetTouchVivacity(accordion.listMerge[iL].barImage, accordion.listMerge[iL].barTitle));
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetTouchVivacity(accordion.listMerge[iL].barImage, accordion.listMerge[iL].barTitle));
                                    accordion.listMerge[iL].barImage.GestureRecognizers.Add(accordion.GetTouch());
                                    accordion.listMerge[iL].barTitle.GestureRecognizers.Add(accordion.GetTouch());

                                    accordion.listMerge[iL].barImage.Opacity = 1;
                                    accordion.listMerge[iL].barTitle.Opacity = 1;
                                }

                                accordion.listIndex[iL].SetContent("__Laavor*+-", false);
                                accordion.listFrames[iL].IsVisible = false;
                            }
                        }
                    }
                    accordion.canChangeListSelect = true;
                }
            }

            private void SetTitle(string title)
            {
                SetValue(ChosenSectionTitleProperty, title);
            }

            private void SetValue(string value)
            {
                SetValue(ChosenSectionValueProperty, value);
            }

            private void SetIndex(int index)
            {
                SetValue(ChosenSectionIndexProperty, index);
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
                if (listMerge != null)
                {
                    for (int index = 0; index < listMerge.Count; index++)
                    {
                        if (listMerge[index].barTitle != null)
                        {
                            listMerge[index].barTitle.TextColor = Colors.Get(textColor);
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the font size of the title
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(AccordionImage),
                defaultValue: 15.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizePropertyChanged);

            /// <summary>
            /// Enter the font size of the title
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
                AccordionImage accordion = (AccordionImage)bindable;
                double fontSize = (double)newValue;

                if (accordion.listMerge != null)
                {
                    for (int index = 0; index < accordion.listMerge.Count; index++)
                    {
                        if (accordion.listMerge[index].barTitle != null)
                        {
                            accordion.listMerge[index].barTitle.FontSize = fontSize;
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the font family Title.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(AccordionImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontFamilyPropertyChanged);

            /// <summary>
            /// Enter the font family Title.
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
                AccordionImage accordion = (AccordionImage)bindable;
                string fontFamily = (string)newValue;

                if (accordion.listMerge != null)
                {
                    for (int index = 0; index < accordion.listMerge.Count; index++)
                    {
                        if (accordion.listMerge[index].barTitle != null)
                        {
                            accordion.listMerge[index].barTitle.FontFamily = fontFamily;
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
                if (listMerge != null)
                {
                    for (int index = 0; index < listMerge.Count; index++)
                    {
                        if (listMerge[index].barTitle != null)
                        {
                            listMerge[index].barTitle.FontAttributes = fontType;
                        }
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
                    return contentColor;
                }
                set
                {
                    contentColor = value;
                    ContentColorPropertyChanged();
                }
            }
                        
            private void ContentColorPropertyChanged()
            {
                if (listFrames != null)
                {
                    int countList = listFrames.Count;

                    for (int iList = 0; iList < countList; iList++)
                    {
                        listFrames[iList].BackgroundColor = Colors.Get(contentColor);
                    }
                }
            }

            /// <summary>
            /// Set BorderContentColor
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderContentColor
            {
                get
                {
                    return borderContentColor;
                }
                set
                {
                    borderContentColor = value;
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
                        listFrames[iList].BorderColor = Colors.Get(borderContentColor);
                    }
                }
            }

            /// <summary>
            /// Enter the width Accordion.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(AccordionImage),
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
                AccordionImage accordion = (AccordionImage)bindable;
                double accordionWidth = (double)newValue;

                if (accordion.listMerge != null)
                {
                    for (int iM = 0; iM < accordion.listMerge.Count; iM++)
                    {
                        if (accordion.listMerge[iM].barImage != null)
                        {
                            accordion.listMerge[iM].barImage.WidthRequest = accordionWidth;
                            accordion.listFrames[iM].WidthRequest = accordionWidth;
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the heightBarTitle
            /// </summary>
            public static readonly BindableProperty HeightBarTitleProperty = BindableProperty.Create(
                propertyName: nameof(HeightBarTitle),
                returnType: typeof(double),
                declaringType: typeof(AccordionImage),
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
                AccordionImage accordion = (AccordionImage)bindable;
                double groupHeight = (double)newValue;

                if (accordion.listMerge != null)
                {
                    for (int iMerge = 0; iMerge < accordion.listMerge.Count; iMerge++)
                    {
                        if (accordion.listMerge[iMerge].barImage != null)
                        {
                            accordion.listMerge[iMerge].barImage.HeightRequest = groupHeight;
                        }
                    }
                }
            }

            /// <summary>
            /// Set Image.
            /// </summary>
            public static readonly BindableProperty ImageProperty = BindableProperty.Create(
                propertyName: nameof(Image),
                returnType: typeof(string),
                declaringType: typeof(AccordionImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImagePropertyChanged);

            /// <summary>
            /// Set Image.
            /// </summary>
            public string Image
            {
                get
                {
                    return (string)GetValue(ImageProperty);
                }
                set
                {
                    SetValue(ImageProperty, value);
                }
            }

            private static void ImagePropertyChanged(object bindable, object oldValue, object newValue)
            {
                AccordionImage groupAccordionImage = (AccordionImage)bindable;
                string imageSource = (string)newValue;
                if (groupAccordionImage.listMerge != null)
                {
                    for (int index = 0; index < groupAccordionImage.listMerge.Count; index++)
                    {
                        if (groupAccordionImage.listMerge[index].barImage != null)
                        {
                            groupAccordionImage.listMerge[index].barImage.Source = imageSource;
                        }
                    }
                }
            }

            /// <summary>
            /// Internal.
            /// </summary>
            protected override void OnChildAdded(Element child)
            {
                if (child.GetType() == typeof(AccordionSection))
                {
                    AccordionSection userItem = (AccordionSection)child;
                    base.OnChildAdded(child);

                    AccordionSection item = new AccordionSection();
                    item.WidthRequest = Width;

                    if(listFrames == null)
                    {
                        listFrames = new List<Frame>();
                    }

                    if(listIndex == null)
                    {
                        listIndex = new List<AccordionSection>();
                    }

                    if(dataItems == null)
                    {
                        dataItems = new StackLayout();
                    }

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
                        BorderColor = Colors.Get(BorderContentColor),
                        WidthRequest = Width - 42,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        BackgroundColor = Colors.Get(ContentColor),
                        HasShadow = true,
                        Margin = new Thickness(0, -7, 0, 0)
                    };

                    frame.Content = item;

                    if (dataItems.Children.Count == 0)
                    {
                        item.SetContent("__Laavor*+-", false);
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
                if (listMerge == null)
                {
                    listMerge = new List<AccordionImageAll>();
                }

                Image imageButton = new Image();
                imageButton.Source = Image;
                imageButton.WidthRequest = Width;
                imageButton.MinimumWidthRequest = Width;
                imageButton.HeightRequest = HeightBarTitle;
                imageButton.MinimumHeightRequest = HeightBarTitle;
                imageButton.Aspect = Aspect.Fill;
                imageButton.Margin = new Thickness(2, 0, 2, 0);
                imageButton.HorizontalOptions = LayoutOptions.FillAndExpand;
                imageButton.VerticalOptions = LayoutOptions.FillAndExpand;

                AccordionTitle labelText = new AccordionTitle();
                labelText.SetIndex("__Laavor*+-", index);
                labelText.Text = title;
                labelText.TextColor = Colors.Get(TextColor);
                labelText.FontAttributes = FontType;
                labelText.BackgroundColor = Color.Transparent;
                labelText.FontFamily = FontFamily;
                labelText.HorizontalOptions = LayoutOptions.Center;
                labelText.FontSize = FontSize;

                AbsoluteLayout.SetLayoutFlags(labelText, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(labelText, new Rectangle(0.5, 0.5, -1, -1));

                if (spacingNormal)
                {
                    if (index > 0)
                    {
                        imageButton.Margin = new Thickness(0, -7, 0, 0);
                        labelText.Margin = new Thickness(0, -7, 0, 0);
                    }

                    imageButton.GestureRecognizers.Add(GetTouchVivacity(imageButton, labelText));
                    labelText.GestureRecognizers.Add(GetTouchVivacity(imageButton, labelText));
                    imageButton.GestureRecognizers.Add(GetTouch());
                    labelText.GestureRecognizers.Add(GetTouch());
                }
                else
                {
                    imageButton.Opacity = opacity;
                    labelText.Opacity = opacity;
                }

                imageButton.HeightRequest = HeightBarTitle;

                listMerge.Insert(index, new AccordionImageAll() { barImage = imageButton, barTitle = labelText });

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
}
