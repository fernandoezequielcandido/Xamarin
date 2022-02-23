using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace List
    {
        /// <summary>
        /// Class ListColor
        /// </summary>
        public class ListColor : StackLayout
        {
            private StackLayout dataItems;
            private ScrollView scrollItems;

            /// <summary>
            /// Return the LastTouchedIndex
            /// </summary>
            public int LastTouchedIndex { get; private set; }

            /// <summary>
            /// Event call when button is Touched
            /// </summary>
            public event EventHandler Touched;
            private ListLineControl lastLine = null;

            private List<ListColorContent> listColorContent = new List<ListColorContent>();
            private List<ListColorControl> listColorControl = new List<ListColorControl>();

            private ColorUI colorUI = Laavor.ColorUI.BlueSky;

            /// <summary>
            /// Constructor of ColoredBox
            /// </summary>
            public ListColor()
            {
                dataItems = new StackLayout();
                dataItems.Spacing = 0;
                scrollItems = new ScrollView();
                scrollItems.Content = dataItems;
                Children.Add(scrollItems);

                this.Margin = new Thickness(0, 2, 0, 2);
            }

            /// <summary>
            /// Clear All Items
            /// </summary>
            public void Clear()
            {
                dataItems.Children.Clear();

                listColorContent.Clear();
                listColorControl.Clear();
            }

            private void Touch_Tapped(object sender, EventArgs e)
            {
                if (e.GetType() == typeof(TappedEventArgs))
                {
                    this.LastTouchedIndex = (int)(e as TappedEventArgs).Parameter;
                }
                Touched?.Invoke(this, EventArgs.Empty);
            }

            private TapGestureRecognizer GetTouch(int index)
            {
                var touched = new TapGestureRecognizer();
                touched.CommandParameter = index;
                touched.Tapped += Touch_Tapped;
                return touched;
            }

            private TapGestureRecognizer GetTouchAnimation(Image img)
            {
                TapGestureRecognizer animationTapImg = new TapGestureRecognizer();
                animationTapImg.Tapped += async (sender, e) =>
                {
                    await img.ScaleTo(0.97, 100, Easing.Linear);
                    await img.ScaleTo(1, 100, Easing.Linear);
                };

                return animationTapImg;
            }

            /// <summary>
            /// Enter the heightItem.
            /// </summary>
            public static readonly BindableProperty HeightItemProperty = BindableProperty.Create(
                propertyName: nameof(HeightItem),
                returnType: typeof(double?),
                declaringType: typeof(ListColor),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: HeightItemPropertyChanged);

            /// <summary>
            /// Enter the heightItem.
            /// </summary>
            public double? HeightItem
            {
                get
                {
                    return (double?)GetValue(HeightItemProperty);
                }
                set
                {
                    SetValue(HeightItemProperty, value);
                }
            }

            private static void HeightItemPropertyChanged(object bindable, object oldValue, object newValue)
            {
                ListColor coloredBox = (ListColor)bindable;
                double coloredBoxHeight = (double)newValue;

                for (int i = 0; i < coloredBox.listColorControl.Count; i++)
                {
                    coloredBox.listColorControl[i].HeightRequest = coloredBoxHeight;
                    coloredBox.listColorContent[i].HeightRequest = coloredBoxHeight;
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
                for (int i = 0; i < listColorControl.Count; i++)
                {
                    listColorControl[i].ChangeColor("__Laavor*+-", colorUI);
                }
            }

            /// <summary>
            /// Internal.
            /// </summary>
            protected override void OnChildAdded(Element child)
            {
                if (child.GetType() == typeof(ListColorContent))
                {
                    ListColorContent userItem = (ListColorContent)child;

                    StackLayout stackContent = new StackLayout();
                    stackContent.Margin = new Thickness(2, 0, 2, 0);
                    stackContent.Spacing = 0;

                    Grid grid = new Grid
                    {
                        ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = GridLength.Star }
                    },
                        RowDefinitions =
                    {
                        new RowDefinition { Height =  GridLength.Auto},
                        new RowDefinition { Height =  1}
                    }
                    };

                    grid.RowSpacing = -1;

                    ListColorControl listColorControl = new ListColorControl("__Laavor*+-", ColorUI);
                    ListLineControl lineImage = new ListLineControl("__Laavor*+-");

                    lineImage.IsVisible = false;
                    lastLine = lineImage;

                    ListColorContent item = new ListColorContent();
                    item.SetIndex("__Laavor*+-", listColorContent.Count);
                    item.Margin = new Thickness(4, 0, 2, 2);

                    if (Touched != null)
                    {
                        listColorControl.GestureRecognizers.Add(GetTouchAnimation(listColorControl));
                        listColorControl.GestureRecognizers.Add(GetTouch(item.Index));
                    }

                    if (userItem.Content != null)
                    {
                        for (int iS = 0; iS < userItem.Children.Count; iS++)
                        {
                            if (Touched != null)
                            {
                                userItem.Children[item.Children.Count - 1].GestureRecognizers.Add(GetTouchAnimation(listColorControl));
                                userItem.Children[item.Children.Count - 1].GestureRecognizers.Add(GetTouch(item.Index));
                            }
                        }

                        item.Content = userItem.Content;
                    }
                    else
                    {
                        for (int iS = 0; iS < userItem.Children.Count; iS++)
                        {
                            item.Children.Add(userItem.Children[iS]);

                            if (Touched != null)
                            {
                                item.Children[item.Children.Count - 1].GestureRecognizers.Add(GetTouchAnimation(listColorControl));
                                item.Children[item.Children.Count - 1].GestureRecognizers.Add(GetTouch(item.Index));
                            }
                        }
                    }

                    if (HeightItem.HasValue)
                    {
                        listColorControl.HeightRequest = HeightItem.Value;
                        item.HeightRequest = HeightItem.Value;
                    }

                    if (Touched != null)
                    {
                        listColorControl.GestureRecognizers.Add(GetTouchAnimation(listColorControl));
                        listColorControl.GestureRecognizers.Add(GetTouch(item.Index));

                        item.GestureRecognizers.Add(GetTouchAnimation(listColorControl));
                        item.GestureRecognizers.Add(GetTouch(item.Index));
                    }

                    grid.GestureRecognizers.Add(GetTouch(item.Index));

                    if (lastLine != null)
                    {
                        lastLine.IsVisible = true;
                    }

                    grid.Children.Add(listColorControl, 0, 0);
                    grid.Children.Add(lineImage, 0, 1);
                    grid.Children.Add(item, 0, 0);

                    stackContent.Children.Add(grid);

                    dataItems.Children.Add(stackContent);

                    dataItems.Spacing = 0;
                    
                    this.listColorControl.Add(listColorControl);
                    listColorContent.Add(item);

                    this.ForceLayout();
                    this.UpdateChildrenLayout();
                }
            }
        }
    }
}
