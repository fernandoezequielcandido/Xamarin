﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Laavor
{
    namespace Group
    {
        public class Tab: StackLayout
        {
            /// <summary>
            /// Returns current index of image, start in 0.
            /// </summary>
            public int CurrentIndex { get; private set; }

            private int currentIndex;

            private ArrowControl imageArrowLeft;
            private ArrowControl imageArrowRight;

            private StackLayout dataItems;
            private StackLayout stackTop;
            // private StackLayout stackLeft;
            private StackLayout stackCenter;
            private StackLayout stackContent;
           // private StackLayout stackRight;
            private Frame frame;

     //       private const int arrowHeight = 70;
       //     private const int arrowWidth = 40;

            private List<TabItem> listContent;

            /// <summary>
            /// Event called when selected Change Content
            /// </summary>
            public event EventHandler ChangeContent;

            private ColorUI colorUI = ColorUI.Gray;
            private ColorUI borderColor = ColorUI.Black;
            private DesignType designType = DesignType.Shinning;

            /// <summary>
            /// Constructor of Tab        
            /// </summary>
            public Tab() : base()
            {
                InitializeComponents();
                this.Spacing = 0;
            }

            private void InitializeComponents()
            {
                Orientation = StackOrientation.Horizontal;
                HorizontalOptions = LayoutOptions.Center;
                InitAll();
            }

            private TapGestureRecognizer GetClickLeftAnimation()
            {
                TapGestureRecognizer animationTapImg = new TapGestureRecognizer();
                animationTapImg.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageArrowLeft.ScaleTo(0.80, 140, Easing.Linear);
                        await imageArrowLeft.ScaleTo(1, 140, Easing.Linear);
                    }
                    catch { }
                };

                return animationTapImg;
            }

            private TapGestureRecognizer GetClickRightAnimation()
            {
                TapGestureRecognizer animationTapImg = new TapGestureRecognizer();
                animationTapImg.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageArrowRight.ScaleTo(0.80, 140, Easing.Linear);
                        await imageArrowRight.ScaleTo(1, 140, Easing.Linear);
                    }
                    catch { }
                };

                return animationTapImg;
            }

            private void InitAll()
            {
                Children.Clear();

                dataItems = new StackLayout();
                this.Orientation = StackOrientation.Vertical;
                dataItems.Orientation = StackOrientation.Horizontal;
                dataItems.HorizontalOptions = LayoutOptions.Center;
                dataItems.Spacing = 0;

                listContent = new List<TabItem>();

                stackContent = new StackLayout();
                stackContent.Spacing = 0;

                frame = new Frame();
                frame.BorderColor = Color.Gray;
                frame.VerticalOptions = LayoutOptions.Start;
                frame.BackgroundColor = Color.Transparent;
                frame.Content = stackContent;

                stackCenter = new StackLayout();
                stackCenter.Spacing = 0;
                stackCenter.Margin = new Thickness(0.5, 5, 0.5, 0.5);
                stackCenter.HorizontalOptions = LayoutOptions.Center;
                stackCenter.Orientation = StackOrientation.Vertical;

                stackCenter.Children.Add(frame);

                if (ContentHeight != null)
                {
                    stackContent.HeightRequest = ContentHeight.Value;
                    stackCenter.HeightRequest = ContentHeight.Value;
                }

                if (ContentWidth != null)
                {
                    stackContent.WidthRequest = ContentWidth.Value;
                    stackCenter.WidthRequest = ContentWidth.Value;
                }

                stackTop = new StackLayout();
                stackTop.Orientation = StackOrientation.Horizontal;
                stackTop.Spacing = 1;

                Grid grid = new Grid 
                {

                    ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = GridLength.Star },
                            new ColumnDefinition { Width = GridLength.Star },
                            new ColumnDefinition { Width = GridLength.Star },
                            new ColumnDefinition { Width = GridLength.Star }

                        },
                    RowDefinitions =
                        {
                            new RowDefinition { Height =  GridLength.Auto},
                            new RowDefinition { Height =  GridLength.Auto},
                            new RowDefinition { Height =  GridLength.Auto},
                            new RowDefinition { Height =  GridLength.Auto}
                        }
                };

                grid.Margin = new Thickness(5,5,5,5);


                BaseDesignControl imageButton1 = new BaseDesignControl("__Laavor*+-", DesignType, ColorUI);
                //imageButton.Opacity = 0.3;
               // imageButton1.GestureRecognizers.Add(GetClickRightAnimation());
               // imageButton1.GestureRecognizers.Add(GetClickRight());
                imageButton1.Margin = new Thickness(0, 0, 0, 0);
                imageButton1.Aspect = Aspect.AspectFit;
             imageButton1.HeightRequest = 50;
             //imageButton1.WidthRequest = 70;
                

                BaseDesignControl imageButton2 = new BaseDesignControl("__Laavor*+-", DesignType, ColorUI);
                //imageButton.Opacity = 0.3;
             //   imageButton2.GestureRecognizers.Add(GetClickRightAnimation());
              //  imageButton2.GestureRecognizers.Add(GetClickRight());
                imageButton2.Margin = new Thickness(0, 0, 0, 0);
                imageButton2.Aspect = Aspect.AspectFit;
               imageButton2.HeightRequest = 50;
               //imageButton2.WidthRequest = 70;
                
                imageButton2.ChangeColor("__Laavor*+-", ColorUI.BlueDark);

                BaseDesignControl imageButton3 = new BaseDesignControl("__Laavor*+-", DesignType, ColorUI);
                //imageButton.Opacity = 0.3;
               // imageButton3.GestureRecognizers.Add(GetClickRightAnimation());
               // imageButton3.GestureRecognizers.Add(GetClickRight());
                imageButton3.Margin = new Thickness(0, 0, 0, 0);
                imageButton3.Aspect = Aspect.AspectFit;
                imageButton3.HeightRequest = 50;
                //imageButton3.WidthRequest = 70;

                BaseDesignControl imageButton4 = new BaseDesignControl("__Laavor*+-", DesignType, ColorUI);
                //imageButton.Opacity = 0.3;
                //   imageButton4.GestureRecognizers.Add(GetClickRightAnimation());
                //  imageButton4.GestureRecognizers.Add(GetClickRight());
                imageButton4.Margin = new Thickness(0, 0, 0, 0);
                imageButton4.Aspect = Aspect.AspectFit;
                imageButton4.HeightRequest = 50;
                //imageButton4.WidthRequest = 70;

                Grid.SetColumn(imageButton1, 0);
                Grid.SetColumn(imageButton2, 1);
                Grid.SetColumn(imageButton3, 2);
                Grid.SetColumn(imageButton4, 3);

                Grid.SetRow(imageButton1, 0);
                Grid.SetRow(imageButton2, 0);
                Grid.SetRow(imageButton3, 0);
                Grid.SetRow(imageButton4, 0);

                stackTop.Children.Add(imageButton1);
                stackTop.Children.Add(imageButton2);
                stackTop.Children.Add(imageButton3);
                stackTop.Children.Add(imageButton4);

                grid.Children.Add(stackTop);
                //dataItems.Children.Add(grid);

                Grid grid2 = new Grid
                {

                    ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = GridLength.Star }
                        },
                    RowDefinitions =
                        {
                            new RowDefinition { Height =  GridLength.Star}
                        }
                };

                grid2.Children.Add(grid);
                Children.Add(grid);
            }

            /// <summary>
            /// Change current item/index. The index must exist, otherwise it does nothing
            /// Does not call the ChangeContent event
            /// </summary>
            /// <param name="index"></param>
            public void NavigateToIndex(int index)
            {
                try
                {
                    if (index >= listContent.Count || index < 0)
                    {
                        return;
                    }

                    if (currentIndex != index)
                    {
                        listContent[CurrentIndex].SetContent("__Laavor*+-", false);
                    }

                    TabItem item = listContent[index];
                    stackContent.Children.Clear();
                    stackContent.Children.Add(item.Content);
                    imageArrowLeft.Opacity = 0.3;
                    item.SetContent("__Laavor*+-", true);

                    if (index == 0)
                    {
                        imageArrowLeft.Opacity = 0.3;
                        imageArrowRight.Opacity = 1;
                    }
                    else if (index == (listContent.Count - 1))
                    {
                        imageArrowLeft.Opacity = 1;
                        imageArrowRight.Opacity = 0.3;
                    }
                    else
                    {
                        imageArrowLeft.Opacity = 1;
                        imageArrowRight.Opacity = 1;
                    }

                    imageArrowRight.ChangeIndex("__Laavor*+-", item.Index);
                    imageArrowLeft.ChangeIndex("__Laavor*+-", item.Index);

                    CurrentIndex = item.Index;
                }
                catch { }
            }

            private void Left_Clicked(object sender, EventArgs e)
            {
                var itemUser = (ArrowControl)sender;

                try
                {
                    TabItem item;
                    if (itemUser.Index == 1)
                    {
                        item = listContent[0];
                        stackContent.Children.Clear();
                        stackContent.Children.Add(item.Content);
                        imageArrowLeft.Opacity = 0.3;
                        item.SetContent("__Laavor*+-", true);
                        listContent[itemUser.Index].SetContent("__Laavor*+-", false);
                    }
                    else if (itemUser.Index == 0)
                    {
                        return;
                    }
                    else
                    {
                        item = listContent[itemUser.Index - 1];
                        stackContent.Children.Clear();
                        stackContent.Children.Add(item.Content);
                        imageArrowLeft.Opacity = 1;
                        item.SetContent("__Laavor*+-", true);
                        listContent[itemUser.Index].SetContent("__Laavor*+-", false);
                    }

                    if (item.Index < (listContent.Count - 1))
                    {
                        imageArrowRight.Opacity = 1;
                    }

                    imageArrowRight.ChangeIndex("__Laavor*+-", item.Index);
                    imageArrowLeft.ChangeIndex("__Laavor*+-", item.Index);

                    CurrentIndex = item.Index;

                    ChangeContent?.Invoke(this, e);
                }
                catch
                { }
            }

            private void Right_Clicked(object sender, EventArgs e)
            {
                var itemUser = (ArrowControl)sender;

                try
                {
                    TabItem item;
                    if (itemUser.Index == (listContent.Count - 2))
                    {
                        item = listContent[itemUser.Index + 1];
                        stackContent.Children.Clear();
                        stackContent.Children.Add(item.Content);
                        imageArrowRight.Opacity = 0.3;
                        item.SetContent("__Laavor*+-", true);
                        listContent[itemUser.Index].SetContent("__Laavor*+-", false);
                    }
                    else if (itemUser.Index == (listContent.Count - 1))
                    {
                        return;
                    }
                    else
                    {
                        imageArrowRight.Opacity = 1;
                        item = listContent[itemUser.Index + 1];
                        stackContent.Children.Clear();
                        stackContent.Children.Add(item.Content);
                        item.SetContent("__Laavor*+-", true);
                        listContent[itemUser.Index].SetContent("__Laavor*+-", false);
                    }

                    if (item.Index > 0)
                    {
                        imageArrowLeft.Opacity = 1;
                    }

                    imageArrowRight.ChangeIndex("__Laavor*+-", item.Index);
                    imageArrowLeft.ChangeIndex("__Laavor*+-", item.Index);

                    CurrentIndex = item.Index;

                    ChangeContent?.Invoke(this, e);
                }
                catch
                { }
            }

            private TapGestureRecognizer GetClickLeft()
            {
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += Left_Clicked;
                return tapGestureRecognizer;
            }

            private TapGestureRecognizer GetClickRight()
            {
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += Right_Clicked;
                return tapGestureRecognizer;
            }

            /// <summary>
            /// Enter the image height.
            /// </summary>
            public static readonly BindableProperty ContentHeightProperty = BindableProperty.Create(
                propertyName: nameof(ContentHeight),
                returnType: typeof(double?),
                declaringType: typeof(Tab),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ContentHeightPropertyChanged);

            /// <summary>
            /// Enter the Content Height.
            /// </summary>
            public double? ContentHeight
            {
                get
                {
                    return (double?)GetValue(ContentHeightProperty);
                }
                set
                {
                    SetValue(ContentHeightProperty, value);
                }
            }

            private static void ContentHeightPropertyChanged(object bindable, object oldValue, object newValue)
            {
                Tab item = (Tab)bindable;

                if (newValue != null)
                {
                    double contentHeight = (double)newValue;
                    item.stackContent.HeightRequest = contentHeight;
                    item.stackCenter.HeightRequest = contentHeight;
                }
            }

            /// <summary>
            /// Enter the image width.
            /// </summary>
            public static readonly BindableProperty ContentWidthProperty = BindableProperty.Create(
                propertyName: nameof(ContentWidth),
                returnType: typeof(double?),
                declaringType: typeof(Tab),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ContentWidthPropertyChanged);

            /// <summary>
            /// Enter the Content width.
            /// </summary>
            public double? ContentWidth
            {
                get
                {
                    return (double?)GetValue(ContentWidthProperty);
                }
                set
                {
                    SetValue(ContentWidthProperty, value);
                }
            }

            private static void ContentWidthPropertyChanged(object bindable, object oldValue, object newValue)
            {
                Tab item = (Tab)bindable;

                if (newValue != null)
                {
                    double contentWidth = (double)newValue;
                    item.stackContent.WidthRequest = contentWidth;
                    item.stackCenter.WidthRequest = contentWidth;
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
                if (imageArrowLeft != null)
                {
                    imageArrowRight.ChangeColor("__Laavor*+-", colorUI);
                    imageArrowLeft.ChangeColor("__Laavor*+-", colorUI);
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
                    frame.BorderColor = Colors.Get(borderColor);
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
                if (imageArrowRight != null)
                {
                    imageArrowRight.ChangeDesignType("__Laavor*+-", designType);
                }

                if (imageArrowLeft != null)
                {
                    imageArrowLeft.ChangeDesignType("__Laavor*+-", designType);
                }
            }

            /// <summary>
            /// Internal.
            /// </summary>
            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);

                if (child.GetType() == typeof(TabItem))
                {
                    TabItem item = (TabItem)child;
                    base.OnChildAdded(child);

                    listContent.Add(item);

                    if (item.Content != null)
                    {

                    }
                    else
                    {
                        StackLayout stack = new StackLayout();
                        for (int iS = 0; iS < item.Children.Count; iS++)
                        {
                            stack.Children.Add(item.Children[iS]);
                        }

                        item.Content = stack;

                        if (currentIndex == 0)
                        {
                            stackContent.Children.Clear();
                            for (int iS = 0; iS < item.Children.Count; iS++)
                            {
                                stackContent.Children.Add(item.Children[iS]);
                            }

                            item.SetContent("__Laavor*+-", true);

                            //imageArrowRight.ChangeIndex("__Laavor*+-", item.Index);
                            //imageArrowLeft.ChangeIndex("__Laavor*+-", item.Index);

                            //imageArrowRight.Opacity = 1.0;
                        }
                    }

                    item.setIndex("__Laavor*+-", currentIndex);
                    currentIndex++;

                }
            }
        }
    }
}
