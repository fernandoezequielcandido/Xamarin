using Laavor.Inquiry;
using System;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    /// <summary>
    /// Class Inquiry Radio Control
    /// </summary>
    public class InquiryRadioControl: Image
    {
        private ImageSource internalSource;
        private DesignType currentDesignType;
        private ColorUI currentColor;

        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Inform if is Chosen
        /// </summary>
        public bool IsChosen { get; private set; }

        /// <summary>
        /// Internal
        /// </summary>
        public InquiryRadioLabel Label { get; private set; }

        /// <summary>
        /// Constructor of RadioControl
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        /// <param name="designType"></param>
        /// <param name="chosen"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public InquiryRadioControl(string hash, DesignType designType, ColorUI color, bool chosen, int index, string value)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in Constructor");
            }

            Value = value;

            IsChosen = chosen;

            Index = index;

            currentDesignType = designType;
            currentColor = color;

            Aspect = Aspect.Fill;
            HorizontalOptions = LayoutOptions.Start;
            VerticalOptions = LayoutOptions.Center;

            byte[] imageBytes = Convert.FromBase64String(GetColor(designType, color, chosen));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="inquiryRadioLabel"></param>
        public void setLabel(string hash, InquiryRadioLabel inquiryRadioLabel)
        {
            if (hash == "__Laavor*+-")
            {
                Label = inquiryRadioLabel;
            }
        }

        /// <summary>
        /// Class ChangeState
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="selected"></param>
        public void ChangeState(string hash, bool selected)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in ChangeColor");
            }

            IsChosen = selected;

            byte[] imageBytes = Convert.FromBase64String(GetColor(currentDesignType, currentColor, selected));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// ChangeColor
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        public void ChangeColor(string hash, ColorUI color)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in ChangeColor");
            }

            currentColor = color;

            byte[] imageBytes = Convert.FromBase64String(GetColor(currentDesignType, color, IsChosen));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// ChangeDesignType
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="designType"></param>
        public void ChangeDesignType(string hash, DesignType designType)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in ChangeColor");
            }

            currentDesignType = designType;

            byte[] imageBytes = Convert.FromBase64String(GetColor(designType, currentColor, IsChosen));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }
               
        private string GetImageFit(ColorUI color, bool isSelected)
        {
            switch (color)
            {
                case ColorUI.Blue:
                    if (isSelected)
                    {
                        return RadioFit.BlueSelected;
                    }
                    else
                    {
                        return RadioFit.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return RadioFit.GraySelected;
                    }
                    else
                    {
                        return RadioFit.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return RadioFit.GreenSelected;
                    }
                    else
                    {
                        return RadioFit.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return RadioFit.RedSelected;
                    }
                    else
                    {
                        return RadioFit.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return RadioFit.YellowSelected;
                    }
                    else
                    {
                        return RadioFit.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return RadioFit.BlueLightSelected;
                    }
                    else
                    {
                        return RadioFit.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return RadioFit.GreenLightSelected;
                    }
                    else
                    {
                        return RadioFit.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return RadioFit.YellowLightSelected;
                    }
                    else
                    {
                        return RadioFit.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return RadioFit.WhiteSelected;
                    }
                    else
                    {
                        return RadioFit.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return RadioFit.PinkSelected;
                    }
                    else
                    {
                        return RadioFit.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return RadioFit.OrangeSelected;
                    }
                    else
                    {
                        return RadioFit.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return RadioFit.BrownSelected;
                    }
                    else
                    {
                        return RadioFit.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return RadioFit.PurpleSelected;
                    }
                    else
                    {
                        return RadioFit.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return RadioFit.TurquoiseSelected;
                    }
                    else
                    {
                        return RadioFit.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return RadioFit.PinkLightSelected;
                    }
                    else
                    {
                        return RadioFit.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return RadioFit.BlueSkySelected;
                    }
                    else
                    {
                        return RadioFit.BlueSky;
                    }
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return RadioFit.BlackSelected;
                    }
                    else
                    {
                        return RadioFit.Black;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return RadioFit.RedLightSelected;
                    }
                    else
                    {
                        return RadioFit.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return RadioFit.GrayLightSelected;
                    }
                    else
                    {
                        return RadioFit.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return RadioFit.OrangeLightSelected;
                    }
                    else
                    {
                        return RadioFit.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return RadioFit.YellowDarkSelected;
                    }
                    else
                    {
                        return RadioFit.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return RadioFit.GreenDarkSelected;
                    }
                    else
                    {
                        return RadioFit.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return RadioFit.BlueDarkSelected;
                    }
                    else
                    {
                        return RadioFit.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return RadioFit.AquaSelected;
                    }
                    else
                    {
                        return RadioFit.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return RadioFit.TanSelected;
                    }
                    else
                    {
                        return RadioFit.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return RadioFit.GreenDarknessSelected;
                    }
                    else
                    {
                        return RadioFit.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return RadioFit.BlueVioletSelected;
                    }
                    else
                    {
                        return RadioFit.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return RadioFit.YellowSelected;
                    }
                    else
                    {
                        return RadioFit.Yellow;
                    }
            }
        }

        private string GetImageFilled(ColorUI color, bool isSelected)
        {
            switch (color)
            {
                case ColorUI.Blue:
                    if (isSelected)
                    {
                        return RadioFilled.BlueSelected;
                    }
                    else
                    {
                        return RadioFilled.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return RadioFilled.GraySelected;
                    }
                    else
                    {
                        return RadioFilled.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return RadioFilled.GreenSelected;
                    }
                    else
                    {
                        return RadioFilled.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return RadioFilled.RedSelected;
                    }
                    else
                    {
                        return RadioFilled.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return RadioFilled.YellowSelected;
                    }
                    else
                    {
                        return RadioFilled.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return RadioFilled.BlueLightSelected;
                    }
                    else
                    {
                        return RadioFilled.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return RadioFilled.GreenLightSelected;
                    }
                    else
                    {
                        return RadioFilled.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return RadioFilled.YellowLightSelected;
                    }
                    else
                    {
                        return RadioFilled.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return RadioFilled.WhiteSelected;
                    }
                    else
                    {
                        return RadioFilled.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return RadioFilled.PinkSelected;
                    }
                    else
                    {
                        return RadioFilled.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return RadioFilled.OrangeSelected;
                    }
                    else
                    {
                        return RadioFilled.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return RadioFilled.BrownSelected;
                    }
                    else
                    {
                        return RadioFilled.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return RadioFilled.PurpleSelected;
                    }
                    else
                    {
                        return RadioFilled.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return RadioFilled.TurquoiseSelected;
                    }
                    else
                    {
                        return RadioFilled.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return RadioFilled.PinkLightSelected;
                    }
                    else
                    {
                        return RadioFilled.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return RadioFilled.BlueSkySelected;
                    }
                    else
                    {
                        return RadioFilled.BlueSky;
                    }
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return RadioFilled.BlackSelected;
                    }
                    else
                    {
                        return RadioFilled.Black;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return RadioFilled.RedLightSelected;
                    }
                    else
                    {
                        return RadioFilled.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return RadioFilled.GrayLightSelected;
                    }
                    else
                    {
                        return RadioFilled.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return RadioFilled.OrangeLightSelected;
                    }
                    else
                    {
                        return RadioFilled.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return RadioFilled.YellowDarkSelected;
                    }
                    else
                    {
                        return RadioFilled.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return RadioFilled.GreenDarkSelected;
                    }
                    else
                    {
                        return RadioFilled.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return RadioFilled.BlueDarkSelected;
                    }
                    else
                    {
                        return RadioFilled.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return RadioFilled.AquaSelected;
                    }
                    else
                    {
                        return RadioFilled.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return RadioFilled.TanSelected;
                    }
                    else
                    {
                        return RadioFilled.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return RadioFilled.GreenDarknessSelected;
                    }
                    else
                    {
                        return RadioFilled.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return RadioFilled.BlueVioletSelected;
                    }
                    else
                    {
                        return RadioFilled.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return RadioFilled.YellowSelected;
                    }
                    else
                    {
                        return RadioFilled.Yellow;
                    }
            }
        }

        private string GetImageSmoke(ColorUI color, bool isSelected)
        {
            switch (color)
            {
                case ColorUI.Blue:
                    if (isSelected)
                    {
                        return RadioSmoke.BlueSelected;
                    }
                    else
                    {
                        return RadioSmoke.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return RadioSmoke.GraySelected;
                    }
                    else
                    {
                        return RadioSmoke.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return RadioSmoke.GreenSelected;
                    }
                    else
                    {
                        return RadioSmoke.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return RadioSmoke.RedSelected;
                    }
                    else
                    {
                        return RadioSmoke.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return RadioSmoke.YellowSelected;
                    }
                    else
                    {
                        return RadioSmoke.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return RadioSmoke.BlueLightSelected;
                    }
                    else
                    {
                        return RadioSmoke.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return RadioSmoke.GreenLightSelected;
                    }
                    else
                    {
                        return RadioSmoke.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return RadioSmoke.YellowLightSelected;
                    }
                    else
                    {
                        return RadioSmoke.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return RadioSmoke.WhiteSelected;
                    }
                    else
                    {
                        return RadioSmoke.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return RadioSmoke.PinkSelected;
                    }
                    else
                    {
                        return RadioSmoke.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return RadioSmoke.OrangeSelected;
                    }
                    else
                    {
                        return RadioSmoke.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return RadioSmoke.BrownSelected;
                    }
                    else
                    {
                        return RadioSmoke.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return RadioSmoke.PurpleSelected;
                    }
                    else
                    {
                        return RadioSmoke.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return RadioSmoke.TurquoiseSelected;
                    }
                    else
                    {
                        return RadioSmoke.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return RadioSmoke.PinkLightSelected;
                    }
                    else
                    {
                        return RadioSmoke.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return RadioSmoke.BlueSkySelected;
                    }
                    else
                    {
                        return RadioSmoke.BlueSky;
                    }
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return RadioSmoke.BlackSelected;
                    }
                    else
                    {
                        return RadioSmoke.Black;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return RadioSmoke.RedLightSelected;
                    }
                    else
                    {
                        return RadioSmoke.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return RadioSmoke.GrayLightSelected;
                    }
                    else
                    {
                        return RadioSmoke.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return RadioSmoke.OrangeLightSelected;
                    }
                    else
                    {
                        return RadioSmoke.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return RadioSmoke.YellowDarkSelected;
                    }
                    else
                    {
                        return RadioSmoke.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return RadioSmoke.GreenDarkSelected;
                    }
                    else
                    {
                        return RadioSmoke.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return RadioSmoke.BlueDarkSelected;
                    }
                    else
                    {
                        return RadioSmoke.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return RadioSmoke.AquaSelected;
                    }
                    else
                    {
                        return RadioSmoke.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return RadioSmoke.TanSelected;
                    }
                    else
                    {
                        return RadioSmoke.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return RadioSmoke.GreenDarknessSelected;
                    }
                    else
                    {
                        return RadioSmoke.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return RadioSmoke.BlueVioletSelected;
                    }
                    else
                    {
                        return RadioSmoke.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return RadioSmoke.YellowSelected;
                    }
                    else
                    {
                        return RadioSmoke.Yellow;
                    }
            }
        }


        private string GetImageAllonsy(ColorUI color, bool isSelected)
        {
            switch (color)
            {
                case ColorUI.Blue:
                    if (isSelected)
                    {
                        return RadioAllonsy.BlueSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return RadioAllonsy.GraySelected;
                    }
                    else
                    {
                        return RadioAllonsy.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return RadioAllonsy.GreenSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return RadioAllonsy.RedSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return RadioAllonsy.YellowSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return RadioAllonsy.BlueLightSelected;
                    }
                    else
                    {
                        return RadioAllonsy.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return RadioAllonsy.GreenLightSelected;
                    }
                    else
                    {
                        return RadioAllonsy.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return RadioAllonsy.YellowLightSelected;
                    }
                    else
                    {
                        return RadioAllonsy.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return RadioAllonsy.WhiteSelected;
                    }
                    else
                    {
                        return RadioAllonsy.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return RadioAllonsy.PinkSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return RadioAllonsy.OrangeSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return RadioAllonsy.BrownSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return RadioAllonsy.PurpleSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return RadioAllonsy.TurquoiseSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return RadioAllonsy.PinkLightSelected;
                    }
                    else
                    {
                        return RadioAllonsy.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return RadioAllonsy.BlueSkySelected;
                    }
                    else
                    {
                        return RadioAllonsy.BlueSky;
                    }
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return RadioAllonsy.BlackSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Black;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return RadioAllonsy.RedLightSelected;
                    }
                    else
                    {
                        return RadioAllonsy.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return RadioAllonsy.GrayLightSelected;
                    }
                    else
                    {
                        return RadioAllonsy.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return RadioAllonsy.OrangeLightSelected;
                    }
                    else
                    {
                        return RadioAllonsy.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return RadioAllonsy.YellowDarkSelected;
                    }
                    else
                    {
                        return RadioAllonsy.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return RadioAllonsy.GreenDarkSelected;
                    }
                    else
                    {
                        return RadioAllonsy.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return RadioAllonsy.BlueDarkSelected;
                    }
                    else
                    {
                        return RadioAllonsy.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return RadioAllonsy.AquaSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return RadioAllonsy.TanSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return RadioAllonsy.GreenDarknessSelected;
                    }
                    else
                    {
                        return RadioAllonsy.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return RadioAllonsy.BlueVioletSelected;
                    }
                    else
                    {
                        return RadioAllonsy.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return RadioAllonsy.YellowSelected;
                    }
                    else
                    {
                        return RadioAllonsy.Yellow;
                    }
            }
        }

        private string GetImageCadre(ColorUI color, bool isSelected)
        {
            switch (color)
            {
                case ColorUI.Blue:
                    if (isSelected)
                    {
                        return RadioCadre.BlueSelected;
                    }
                    else
                    {
                        return RadioCadre.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return RadioCadre.GraySelected;
                    }
                    else
                    {
                        return RadioCadre.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return RadioCadre.GreenSelected;
                    }
                    else
                    {
                        return RadioCadre.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return RadioCadre.RedSelected;
                    }
                    else
                    {
                        return RadioCadre.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return RadioCadre.YellowSelected;
                    }
                    else
                    {
                        return RadioCadre.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return RadioCadre.BlueLightSelected;
                    }
                    else
                    {
                        return RadioCadre.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return RadioCadre.GreenLightSelected;
                    }
                    else
                    {
                        return RadioCadre.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return RadioCadre.YellowLightSelected;
                    }
                    else
                    {
                        return RadioCadre.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return RadioCadre.WhiteSelected;
                    }
                    else
                    {
                        return RadioCadre.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return RadioCadre.PinkSelected;
                    }
                    else
                    {
                        return RadioCadre.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return RadioCadre.OrangeSelected;
                    }
                    else
                    {
                        return RadioCadre.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return RadioCadre.BrownSelected;
                    }
                    else
                    {
                        return RadioCadre.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return RadioCadre.PurpleSelected;
                    }
                    else
                    {
                        return RadioCadre.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return RadioCadre.TurquoiseSelected;
                    }
                    else
                    {
                        return RadioCadre.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return RadioCadre.PinkLightSelected;
                    }
                    else
                    {
                        return RadioCadre.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return RadioCadre.BlueSkySelected;
                    }
                    else
                    {
                        return RadioCadre.BlueSky;
                    }
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return RadioCadre.BlackSelected;
                    }
                    else
                    {
                        return RadioCadre.Black;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return RadioCadre.RedLightSelected;
                    }
                    else
                    {
                        return RadioCadre.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return RadioCadre.GrayLightSelected;
                    }
                    else
                    {
                        return RadioCadre.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return RadioCadre.OrangeLightSelected;
                    }
                    else
                    {
                        return RadioCadre.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return RadioCadre.YellowDarkSelected;
                    }
                    else
                    {
                        return RadioCadre.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return RadioCadre.GreenDarkSelected;
                    }
                    else
                    {
                        return RadioCadre.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return RadioCadre.BlueDarkSelected;
                    }
                    else
                    {
                        return RadioCadre.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return RadioCadre.AquaSelected;
                    }
                    else
                    {
                        return RadioCadre.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return RadioCadre.TanSelected;
                    }
                    else
                    {
                        return RadioCadre.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return RadioCadre.GreenDarknessSelected;
                    }
                    else
                    {
                        return RadioCadre.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return RadioCadre.BlueVioletSelected;
                    }
                    else
                    {
                        return RadioCadre.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return RadioCadre.YellowSelected;
                    }
                    else
                    {
                        return RadioCadre.Yellow;
                    }
            }
        }

        private string GetImageShinning(ColorUI color, bool isSelected)
        {
            switch (color)
            {
                case ColorUI.Blue:
                    if (isSelected)
                    {
                        return RadioShinning.BlueSelected;
                    }
                    else
                    {
                        return RadioShinning.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return RadioShinning.GraySelected;
                    }
                    else
                    {
                        return RadioShinning.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return RadioShinning.GreenSelected;
                    }
                    else
                    {
                        return RadioShinning.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return RadioShinning.RedSelected;
                    }
                    else
                    {
                        return RadioShinning.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return RadioShinning.YellowSelected;
                    }
                    else
                    {
                        return RadioShinning.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return RadioShinning.BlueLightSelected;
                    }
                    else
                    {
                        return RadioShinning.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return RadioShinning.GreenLightSelected;
                    }
                    else
                    {
                        return RadioShinning.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return RadioShinning.YellowLightSelected;
                    }
                    else
                    {
                        return RadioShinning.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return RadioShinning.WhiteSelected;
                    }
                    else
                    {
                        return RadioShinning.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return RadioShinning.PinkSelected;
                    }
                    else
                    {
                        return RadioShinning.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return RadioShinning.OrangeSelected;
                    }
                    else
                    {
                        return RadioShinning.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return RadioShinning.BrownSelected;
                    }
                    else
                    {
                        return RadioShinning.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return RadioShinning.PurpleSelected;
                    }
                    else
                    {
                        return RadioShinning.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return RadioShinning.TurquoiseSelected;
                    }
                    else
                    {
                        return RadioShinning.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return RadioShinning.PinkLightSelected;
                    }
                    else
                    {
                        return RadioShinning.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return RadioShinning.BlueSkySelected;
                    }
                    else
                    {
                        return RadioShinning.BlueSky;
                    }
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return RadioShinning.BlackSelected;
                    }
                    else
                    {
                        return RadioShinning.Black;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return RadioShinning.RedLightSelected;
                    }
                    else
                    {
                        return RadioShinning.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return RadioShinning.GrayLightSelected;
                    }
                    else
                    {
                        return RadioShinning.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return RadioShinning.OrangeLightSelected;
                    }
                    else
                    {
                        return RadioShinning.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return RadioShinning.YellowDarkSelected;
                    }
                    else
                    {
                        return RadioShinning.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return RadioShinning.GreenDarkSelected;
                    }
                    else
                    {
                        return RadioShinning.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return RadioShinning.BlueDarkSelected;
                    }
                    else
                    {
                        return RadioShinning.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return RadioShinning.AquaSelected;
                    }
                    else
                    {
                        return RadioShinning.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return RadioShinning.TanSelected;
                    }
                    else
                    {
                        return RadioShinning.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return RadioShinning.GreenDarknessSelected;
                    }
                    else
                    {
                        return RadioShinning.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return RadioShinning.BlueVioletSelected;
                    }
                    else
                    {
                        return RadioShinning.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return RadioShinning.YellowSelected;
                    }
                    else
                    {
                        return RadioShinning.Yellow;
                    }
            }
        }

        private string GetImageScratches(ColorUI color, bool isSelected)
        {
            switch (color)
            {
                case ColorUI.Blue:
                    if (isSelected)
                    {
                        return RadioScratches.BlueSelected;
                    }
                    else
                    {
                        return RadioScratches.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return RadioScratches.GraySelected;
                    }
                    else
                    {
                        return RadioScratches.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return RadioScratches.GreenSelected;
                    }
                    else
                    {
                        return RadioScratches.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return RadioScratches.RedSelected;
                    }
                    else
                    {
                        return RadioScratches.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return RadioScratches.YellowSelected;
                    }
                    else
                    {
                        return RadioScratches.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return RadioScratches.BlueLightSelected;
                    }
                    else
                    {
                        return RadioScratches.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return RadioScratches.GreenLightSelected;
                    }
                    else
                    {
                        return RadioScratches.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return RadioScratches.YellowLightSelected;
                    }
                    else
                    {
                        return RadioScratches.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return RadioScratches.WhiteSelected;
                    }
                    else
                    {
                        return RadioScratches.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return RadioScratches.PinkSelected;
                    }
                    else
                    {
                        return RadioScratches.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return RadioScratches.OrangeSelected;
                    }
                    else
                    {
                        return RadioScratches.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return RadioScratches.BrownSelected;
                    }
                    else
                    {
                        return RadioScratches.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return RadioScratches.PurpleSelected;
                    }
                    else
                    {
                        return RadioScratches.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return RadioScratches.TurquoiseSelected;
                    }
                    else
                    {
                        return RadioScratches.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return RadioScratches.PinkLightSelected;
                    }
                    else
                    {
                        return RadioScratches.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return RadioScratches.BlueSkySelected;
                    }
                    else
                    {
                        return RadioScratches.BlueSky;
                    }
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return RadioScratches.BlackSelected;
                    }
                    else
                    {
                        return RadioScratches.Black;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return RadioScratches.RedLightSelected;
                    }
                    else
                    {
                        return RadioScratches.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return RadioScratches.GrayLightSelected;
                    }
                    else
                    {
                        return RadioScratches.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return RadioScratches.OrangeLightSelected;
                    }
                    else
                    {
                        return RadioScratches.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return RadioScratches.YellowDarkSelected;
                    }
                    else
                    {
                        return RadioScratches.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return RadioScratches.GreenDarkSelected;
                    }
                    else
                    {
                        return RadioScratches.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return RadioScratches.BlueDarkSelected;
                    }
                    else
                    {
                        return RadioScratches.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return RadioScratches.AquaSelected;
                    }
                    else
                    {
                        return RadioScratches.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return RadioScratches.TanSelected;
                    }
                    else
                    {
                        return RadioScratches.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return RadioScratches.GreenDarknessSelected;
                    }
                    else
                    {
                        return RadioScratches.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return RadioScratches.BlueVioletSelected;
                    }
                    else
                    {
                        return RadioScratches.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return RadioScratches.YellowSelected;
                    }
                    else
                    {
                        return RadioScratches.Yellow;
                    }
            }
        }

        private string GetColor(DesignType type, ColorUI color, bool selected)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetImage" + type.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            object[] parametersInvoke = { color, selected };

            var returnStringColor = (string)methodToInvoke.Invoke(this, parametersInvoke);
            return returnStringColor;
        }
    }
}
