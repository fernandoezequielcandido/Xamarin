using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace LaavorSwapImage
{
    /// <summary>
    /// Class SwapSlotContent
    /// </summary>
    public class SwapSlotContent:StackLayout
    {
        /// <summary>
        /// Number
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Index of Image
        /// </summary>
        public int IndexImage { get; private set; }

        private Image image;
        private List<SwapSlotContentImage> listContents;

        private int indexInternal;

        private SwapSlotImage slotImage;

        /// <summary>
        /// SlotContent
        /// </summary>
        public SwapSlotContent()
        {
            Number = 0;
            IndexImage = -1;

            indexInternal = 0;

            InitAll();
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="number"></param>
        public void InformNumber(string hash, int number)
        {
            if (hash == "laavorffabna87987*--/*-*-/-*.8sdfsakjksfdjkb")
            {
                Number = number;
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="image"></param>
        public void InformSlotImage(string hash, SwapSlotImage image)
        {
            if (hash == "laavorffabna87987*--/*-*-/-*.8sdfsakjksfdjkb")
            {
                slotImage = image;
            }
        }

        private void InitAll()
        {
            this.Spacing = 0;

            image = new Image();
            image.Aspect = Aspect.AspectFill;
            listContents = new List<SwapSlotContentImage>();

            Children.Add(image);
            Number = 0;

            image.GestureRecognizers.Add(GetTouch());
        }
        
        private void Touch_Tapped(object sender, EventArgs e)
        {
            Next();
        }

        private TapGestureRecognizer GetTouch()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += Touch_Tapped;
            return touch;
        }
        
        private void Next()
        {
            if(listContents != null)
            {
                indexInternal++;
                if(indexInternal > (listContents.Count - 1))
                {
                    indexInternal = 0;
                }

                IndexImage = listContents[indexInternal].Index;
                image.Source = listContents[indexInternal].Image;

                slotImage.Update("laavorffabna87987*--/*-*-/-*.8sdfsakjksfdjkb", IndexImage, Number, listContents[indexInternal].Value, Value, listContents[indexInternal].Image);
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="w"></param>
        public void ChangeWidth(string hash, double w)
        {
            if (hash == "laavorffabna87987*--/*-*-/-*.8sdfsakjksfdjkb")
            {
                image.WidthRequest = w;
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="h"></param>
        public void ChangeHeight(string hash, double h)
        {
            if (hash == "laavorffabna87987*--/*-*-/-*.8sdfsakjksfdjkb")
            {
                image.HeightRequest = h;
            }
        }

        /// <summary>
        /// Enter the Value of Content.
        /// </summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            propertyName: nameof(Value),
            returnType: typeof(string),
            declaringType: typeof(SwapSlotContent),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Value of Content.
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
        /// Internal
        /// </summary>
        /// <param name="child"></param>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(SwapSlotContentImage))
            {
                SwapSlotContentImage slotUser = (SwapSlotContentImage)child;
                SwapSlotContentImage slotItem = new SwapSlotContentImage();
                slotItem.InformIndex("laavorffabna87987*--/*-*-/-*.8sdfsakjksfdjkb", listContents.Count);
                slotItem.Image = slotUser.Image;
                slotItem.Value = slotUser.Value;

                if (listContents.Count == 0)
                {
                    image.Source = slotItem.Image;
                }

                listContents.Add(slotItem);
            }
            else if(child.GetType() != typeof(Image))
            {
                Children.RemoveAt(Children.Count - 1);
            }
        }
    }
}
