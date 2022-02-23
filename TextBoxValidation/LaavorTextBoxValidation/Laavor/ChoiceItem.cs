using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{
    /// <summary>
    /// Class ChoiceItem
    /// </summary>
    public class ChoiceItem : StackLayout
    {
        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; private set; }

        private bool isChosen;

        private LaavorLabel labelReference;

        private ColorUI textColorChosen;
        private ColorUI textColorUnChosen;
        private ColorUI colorChosen;

        private double fontSize;
        private FontAttributes fontType;
        private string currentText;
        private string currentValue;

        //private Image imageReference;
        //private string currentImage = "";
        //private double currentImageWidth = 10;
        //private double currentImageHeight = 7;
        private ChoiceBox choiceReference;

        /// <summary>
        /// Constructor of ChoiceItem
        /// </summary>
        public ChoiceItem()
        {
            this.isChosen = true;
            //this.IsVisible = false;
        }

        /// <summary>
        /// Constructor of ChoiceItem
        /// </summary>
        /// <param name="key"></param>
        /// <param name="another"></param>
        /// <param name="choiceBoxFather"></param>
        /// <param name="index"></param>
        public ChoiceItem(string key, ChoiceItem another, ChoiceBox choiceBoxFather, int index)
        {
            if (another != null && key == "77__htu_KK_Laavor_*-+/.Ezequiel")
            {
                this.textColorChosen = choiceBoxFather.TextColorItemsChosen;
                this.textColorUnChosen = choiceBoxFather.TextColorItemsUnChosen;
                this.currentValue = another.Value;
                this.currentText = another.Text;

                this.colorChosen = choiceBoxFather.ColorUIChosen;

                this.fontType = choiceBoxFather.FontTypeforItems;
                this.fontSize = choiceBoxFather.FontSizeforItems;
                   
                //this.currentImage = another.Image;
                //this.currentImageWidth = another.Width;
                //this.currentImageHeight = another.Height;

                this.Index = index;

                choiceReference = choiceBoxFather;

                InitAll();
            }
        }

        /// <summary>
        /// Constructor of ChoiceItem
        /// </summary>
        /// <param name="key"></param>
        /// <param name="choiceBoxFather"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <param name="text"></param>
        public ChoiceItem(string key, ChoiceBox choiceBoxFather, int index, string text, string value)
        {
            if (key == "77__htu_KK_Laavor_*-+/.Ezequiel")
            {
                this.textColorChosen = choiceBoxFather.TextColorItemsChosen;
                this.textColorUnChosen = choiceBoxFather.TextColorItemsUnChosen;
                this.currentValue = value;
                this.currentText = text;

                this.colorChosen = choiceBoxFather.ColorUIChosen;

                this.fontType = choiceBoxFather.FontTypeforItems;
                this.fontSize = choiceBoxFather.FontSizeforItems;

                //this.currentImage = another.Image;
                //this.currentImageWidth = another.Width;
                //this.currentImageHeight = another.Height;

                this.Index = index;

                choiceReference = choiceBoxFather;

                InitAll();
            }
        }

        private void InitAll()
        {
            this.Orientation = StackOrientation.Horizontal;

            labelReference = new LaavorLabel("HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122", Index);
            labelReference.TextColor = Colors.Get(textColorUnChosen);
            labelReference.FontAttributes = fontType;
            labelReference.FontSize = fontSize;
            labelReference.Text = currentText;
            labelReference.Margin = new Thickness(10, 0, 0, 0);

            //imageReference = new Image();
            //imageReference.Source = currentImage;
            //imageReference.WidthRequest = currentImageWidth;
            //imageReference.HeightRequest = currentImageHeight;

            this.Children.Add(labelReference);
            //   this.Children.Add(imageReference);

            this.GestureRecognizers.Add(GetTouch());
            labelReference.GestureRecognizers.Add(GetTouch());
            //imageReference.GestureRecognizers.Add(GetTouch());

            this.BackgroundColor = Color.Transparent;


        }

        private TapGestureRecognizer GetTouch()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += Touch_Choice;
            return touch;
        }

        private void Touch_Choice(object sender, EventArgs e)
        {
            //this.BackgroundColor = b;
            if (sender.GetType() == typeof(LaavorLabel))
            {
                LaavorLabel laavorLabel = (LaavorLabel)sender;
                choiceReference.ChangeChosen("HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122", laavorLabel.Index);

                if (!isChosen)
                {
                    SetChosen("HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122", true);
                }
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="isChosen"></param>
        public void SetChosen(string hash, bool isChosen)
        {
            if (hash == "HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122")
            {
                if (labelReference != null)
                {
                    if (isChosen)
                    {
                        labelReference.TextColor = Colors.Get(textColorChosen);
                    }
                    else
                    {
                        labelReference.TextColor = Colors.Get(textColorUnChosen);
                    }
                }

                if (isChosen)
                {
                    this.BackgroundColor = Colors.Get(colorChosen);
                }
                else
                {
                    this.BackgroundColor = Color.Transparent;
                }
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="fontSize"></param>
        public void SetFontSize(string hash, double fontSize)
        {
            if (hash == "HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122" && labelReference != null)
            {
                labelReference.FontSize = fontSize;
                this.fontSize = fontSize;
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="fontType"></param>
        public void SetFontType(string hash, FontAttributes fontType)
        {
            if (hash == "HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122" && labelReference != null)
            {
                labelReference.FontAttributes = fontType;
                this.fontType = fontType;
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        public void SetTexColorChosen(string hash, ColorUI color)
        {
            if (hash == "HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122" && labelReference != null && isChosen)
            {
                labelReference.TextColor = Colors.Get(color);
                textColorChosen = color;
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        public void SetTexColorUnChosen(string hash, ColorUI color)
        {
            if (hash == "HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122" && labelReference != null && !isChosen)
            {
                labelReference.TextColor = Colors.Get(color);
                textColorUnChosen = color;
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        public void SetColorUIUnChosen(string hash, ColorUI color)
        {
            if (hash == "HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122" && !isChosen)
            {
                this.BackgroundColor = Colors.Get(color);
            }
        }

        ///// <summary>
        ///// Enter the Image Source.
        ///// </summary>
        //[Bindable(true)]
        //public string Image
        //{
        //    get
        //    {
        //        return currentImage;
        //    }
        //    set
        //    {
        //        currentImage = value;
        //        ImagePropertyChanged();
        //    }
        //}

        //private void ImagePropertyChanged()
        //{
        //    if(imageReference != null)
        //    {
        //        imageReference.Source = currentImage;
        //    }
        //}

        ///// <summary>
        ///// Enter the ImageWidth.
        ///// </summary>
        //[Bindable(true)]
        //public double ImageWidth
        //{
        //    get
        //    {
        //        return currentImageWidth;
        //    }
        //    set
        //    {
        //        currentImageWidth = value;
        //        ImageWidthPropertyChanged();
        //    }
        //}

        //private void ImageWidthPropertyChanged()
        //{
        //    if (imageReference != null)
        //    {
        //        imageReference.WidthRequest = currentImageWidth;
        //    }
        //}

        ///// <summary>
        ///// Enter the ImageHeight.
        ///// </summary>
        //[Bindable(true)]
        //public double ImageHeight
        //{
        //    get
        //    {
        //        return currentImageHeight;
        //    }
        //    set
        //    {
        //        currentImageHeight = value;
        //        ImageHeightPropertyChanged();
        //    }
        //}

        //private void ImageHeightPropertyChanged()
        //{
        //    if (imageReference != null)
        //    {
        //        imageReference.HeightRequest = currentImageHeight;
        //    }
        //}

        /// <summary>
        /// Enter the Value.
        /// </summary>
        [Bindable(true)]
        public string Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
            }
        }

        /// <summary>
        /// Enter the Text.
        /// </summary>
        [Bindable(true)]
        public string Text
        {
            get
            {
                return currentText;
            }
            set
            {
                currentText = value;
            }
        }

    }
}
