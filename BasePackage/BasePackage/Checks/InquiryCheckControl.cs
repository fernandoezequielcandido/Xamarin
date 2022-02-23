using Laavor.Inquiry;
using System;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    /// <summary>
    /// Class InquiryCheckControl
    /// </summary>
    public class InquiryCheckControl: Image
    {
        private ImageSource internalSource;
        private DesignType designType;
        private ColorUI color;

        /// <summary>
        /// Internal
        /// </summary>
        public InquiryCheckLabel Label { get; private set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Inform if is Checked
        /// </summary>
        public bool IsChecked { get; private set; }

        /// <summary>
        /// Constructor of InquiryCheckImage
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        /// <param name="designType"></param>
        /// <param name="isChecked"></param>
        public InquiryCheckControl(string hash, DesignType designType, ColorUI color, bool isChecked)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in Constructor");
            }

            IsChecked = isChecked;

            this.designType = designType;
            this.color = color;

            Aspect = Aspect.Fill;
            HorizontalOptions = LayoutOptions.Start;
            VerticalOptions = LayoutOptions.Center;

            byte[] imageBytes = Convert.FromBase64String(GetColor(designType, color, isChecked));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="label"></param>
        public void setlabel(string hash, InquiryCheckLabel label)
        {
            if (hash != "__Laavor*+-")
            {
                Label = label;
            }
        }

        /// <summary>
        /// Change State Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="isChecked"></param>
        public void ChangeState(string hash, bool isChecked)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in ChangeColor");
            }

            IsChecked = isChecked;

            byte[] imageBytes = Convert.FromBase64String(GetColor(designType, color, isChecked));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Change State Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        public void ChangeColor(string hash, ColorUI color)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in ChangeColor");
            }

            this.color = color;

            byte[] imageBytes = Convert.FromBase64String(GetColor(designType, color, IsChecked));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Change State Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="designType"></param>
        public void ChangeDesignType(string hash, DesignType designType)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in ChangeColor");
            }

            this.designType = designType;

            byte[] imageBytes = Convert.FromBase64String(GetColor(designType, color, IsChecked));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        private string GetImageFit(ColorUI color, bool isSelected)
        {
            switch (color)
            {
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return CheckFit.BlackSelected;
                    }
                    else
                    {
                        return CheckFit.Black;
                    }
                case ColorUI.Blue:
                    if (isSelected)
                    {
                        return CheckFit.BlueSelected;
                    }
                    else
                    {
                        return CheckFit.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return CheckFit.GraySelected;
                    }
                    else
                    {
                        return CheckFit.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return CheckFit.GreenSelected;
                    }
                    else
                    {
                        return CheckFit.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return CheckFit.RedSelected;
                    }
                    else
                    {
                        return CheckFit.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return CheckFit.YellowSelected;
                    }
                    else
                    {
                        return CheckFit.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return CheckFit.BlueLightSelected;
                    }
                    else
                    {
                        return CheckFit.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return CheckFit.GreenLightSelected;
                    }
                    else
                    {
                        return CheckFit.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return CheckFit.YellowLightSelected;
                    }
                    else
                    {
                        return CheckFit.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return CheckFit.WhiteSelected;
                    }
                    else
                    {
                        return CheckFit.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return CheckFit.PinkSelected;
                    }
                    else
                    {
                        return CheckFit.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return CheckFit.OrangeSelected;
                    }
                    else
                    {
                        return CheckFit.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return CheckFit.BrownSelected;
                    }
                    else
                    {
                        return CheckFit.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return CheckFit.PurpleSelected;
                    }
                    else
                    {
                        return CheckFit.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return CheckFit.TurquoiseSelected;
                    }
                    else
                    {
                        return CheckFit.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return CheckFit.PinkLightSelected;
                    }
                    else
                    {
                        return CheckFit.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return CheckFit.BlueSkySelected;
                    }
                    else
                    {
                        return CheckFit.BlueSky;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return CheckFit.RedLightSelected;
                    }
                    else
                    {
                        return CheckFit.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return CheckFit.GrayLightSelected;
                    }
                    else
                    {
                        return CheckFit.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return CheckFit.OrangeLightSelected;
                    }
                    else
                    {
                        return CheckFit.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return CheckFit.YellowDarkSelected;
                    }
                    else
                    {
                        return CheckFit.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return CheckFit.GreenDarkSelected;
                    }
                    else
                    {
                        return CheckFit.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return CheckFit.BlueDarkSelected;
                    }
                    else
                    {
                        return CheckFit.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return CheckFit.AquaSelected;
                    }
                    else
                    {
                        return CheckFit.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return CheckFit.TanSelected;
                    }
                    else
                    {
                        return CheckFit.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return CheckFit.GreenDarknessSelected;
                    }
                    else
                    {
                        return CheckFit.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return CheckFit.BlueVioletSelected;
                    }
                    else
                    {
                        return CheckFit.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return CheckFit.GraySelected;
                    }
                    else
                    {
                        return CheckFit.Gray;
                    }
            }
        }

        private string GetImageFilled(ColorUI color, bool isSelected)
        {
            switch (color)
            {
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return CheckFilled.BlackSelected;
                    }
                    else
                    {
                        return CheckFilled.Black;
                    }
                case ColorUI.Blue:
                    if (isSelected)
                    {
                        return CheckFilled.BlueSelected;
                    }
                    else
                    {
                        return CheckFilled.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return CheckFilled.GraySelected;
                    }
                    else
                    {
                        return CheckFilled.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return CheckFilled.GreenSelected;
                    }
                    else
                    {
                        return CheckFilled.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return CheckFilled.RedSelected;
                    }
                    else
                    {
                        return CheckFilled.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return CheckFilled.YellowSelected;
                    }
                    else
                    {
                        return CheckFilled.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return CheckFilled.BlueLightSelected;
                    }
                    else
                    {
                        return CheckFilled.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return CheckFilled.GreenLightSelected;
                    }
                    else
                    {
                        return CheckFilled.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return CheckFilled.YellowLightSelected;
                    }
                    else
                    {
                        return CheckFilled.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return CheckFilled.WhiteSelected;
                    }
                    else
                    {
                        return CheckFilled.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return CheckFilled.PinkSelected;
                    }
                    else
                    {
                        return CheckFilled.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return CheckFilled.OrangeSelected;
                    }
                    else
                    {
                        return CheckFilled.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return CheckFilled.BrownSelected;
                    }
                    else
                    {
                        return CheckFilled.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return CheckFilled.PurpleSelected;
                    }
                    else
                    {
                        return CheckFilled.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return CheckFilled.TurquoiseSelected;
                    }
                    else
                    {
                        return CheckFilled.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return CheckFilled.PinkLightSelected;
                    }
                    else
                    {
                        return CheckFilled.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return CheckFilled.BlueSkySelected;
                    }
                    else
                    {
                        return CheckFilled.BlueSky;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return CheckFilled.RedLightSelected;
                    }
                    else
                    {
                        return CheckFilled.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return CheckFilled.GrayLightSelected;
                    }
                    else
                    {
                        return CheckFilled.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return CheckFilled.OrangeLightSelected;
                    }
                    else
                    {
                        return CheckFilled.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return CheckFilled.YellowDarkSelected;
                    }
                    else
                    {
                        return CheckFilled.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return CheckFilled.GreenDarkSelected;
                    }
                    else
                    {
                        return CheckFilled.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return CheckFilled.BlueDarkSelected;
                    }
                    else
                    {
                        return CheckFilled.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return CheckFilled.AquaSelected;
                    }
                    else
                    {
                        return CheckFilled.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return CheckFilled.TanSelected;
                    }
                    else
                    {
                        return CheckFilled.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return CheckFilled.GreenDarknessSelected;
                    }
                    else
                    {
                        return CheckFilled.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return CheckFilled.BlueVioletSelected;
                    }
                    else
                    {
                        return CheckFilled.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return CheckFilled.GraySelected;
                    }
                    else
                    {
                        return CheckFilled.Gray;
                    }
            }
        }


        private string GetImageSmoke(ColorUI color, bool isSelected)
        {
            switch (color)
            {
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return CheckSmoke.BlackSelected;
                    }
                    else
                    {
                        return CheckSmoke.Black;
                    }
                case ColorUI.Blue:
                    if (isSelected)
                    {
                        return CheckSmoke.BlueSelected;
                    }
                    else
                    {
                        return CheckSmoke.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return CheckSmoke.GraySelected;
                    }
                    else
                    {
                        return CheckSmoke.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return CheckSmoke.GreenSelected;
                    }
                    else
                    {
                        return CheckSmoke.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return CheckSmoke.RedSelected;
                    }
                    else
                    {
                        return CheckSmoke.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return CheckSmoke.YellowSelected;
                    }
                    else
                    {
                        return CheckSmoke.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return CheckSmoke.BlueLightSelected;
                    }
                    else
                    {
                        return CheckSmoke.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return CheckSmoke.GreenLightSelected;
                    }
                    else
                    {
                        return CheckSmoke.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return CheckSmoke.YellowLightSelected;
                    }
                    else
                    {
                        return CheckSmoke.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return CheckSmoke.WhiteSelected;
                    }
                    else
                    {
                        return CheckSmoke.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return CheckSmoke.PinkSelected;
                    }
                    else
                    {
                        return CheckSmoke.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return CheckSmoke.OrangeSelected;
                    }
                    else
                    {
                        return CheckSmoke.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return CheckSmoke.BrownSelected;
                    }
                    else
                    {
                        return CheckSmoke.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return CheckSmoke.PurpleSelected;
                    }
                    else
                    {
                        return CheckSmoke.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return CheckSmoke.TurquoiseSelected;
                    }
                    else
                    {
                        return CheckSmoke.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return CheckSmoke.PinkLightSelected;
                    }
                    else
                    {
                        return CheckSmoke.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return CheckSmoke.BlueSkySelected;
                    }
                    else
                    {
                        return CheckSmoke.BlueSky;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return CheckSmoke.RedLightSelected;
                    }
                    else
                    {
                        return CheckSmoke.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return CheckSmoke.GrayLightSelected;
                    }
                    else
                    {
                        return CheckSmoke.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return CheckSmoke.OrangeLightSelected;
                    }
                    else
                    {
                        return CheckSmoke.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return CheckSmoke.YellowDarkSelected;
                    }
                    else
                    {
                        return CheckSmoke.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return CheckSmoke.GreenDarkSelected;
                    }
                    else
                    {
                        return CheckSmoke.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return CheckSmoke.BlueDarkSelected;
                    }
                    else
                    {
                        return CheckSmoke.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return CheckSmoke.AquaSelected;
                    }
                    else
                    {
                        return CheckSmoke.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return CheckSmoke.TanSelected;
                    }
                    else
                    {
                        return CheckSmoke.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return CheckSmoke.GreenDarknessSelected;
                    }
                    else
                    {
                        return CheckSmoke.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return CheckSmoke.BlueVioletSelected;
                    }
                    else
                    {
                        return CheckSmoke.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return CheckSmoke.GraySelected;
                    }
                    else
                    {
                        return CheckSmoke.Gray;
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
                        return CheckAllonsy.BlueSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return CheckAllonsy.GraySelected;
                    }
                    else
                    {
                        return CheckAllonsy.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return CheckAllonsy.GreenSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return CheckAllonsy.RedSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return CheckAllonsy.YellowSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return CheckAllonsy.BlueLightSelected;
                    }
                    else
                    {
                        return CheckAllonsy.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return CheckAllonsy.GreenLightSelected;
                    }
                    else
                    {
                        return CheckAllonsy.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return CheckAllonsy.YellowLightSelected;
                    }
                    else
                    {
                        return CheckAllonsy.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return CheckAllonsy.WhiteSelected;
                    }
                    else
                    {
                        return CheckAllonsy.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return CheckAllonsy.PinkSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return CheckAllonsy.OrangeSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return CheckAllonsy.BrownSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return CheckAllonsy.PurpleSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return CheckAllonsy.TurquoiseSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return CheckAllonsy.PinkLightSelected;
                    }
                    else
                    {
                        return CheckAllonsy.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return CheckAllonsy.BlueSkySelected;
                    }
                    else
                    {
                        return CheckAllonsy.BlueSky;
                    }
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return CheckAllonsy.BlackSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Black;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return CheckAllonsy.RedLightSelected;
                    }
                    else
                    {
                        return CheckAllonsy.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return CheckAllonsy.GrayLightSelected;
                    }
                    else
                    {
                        return CheckAllonsy.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return CheckAllonsy.OrangeLightSelected;
                    }
                    else
                    {
                        return CheckAllonsy.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return CheckAllonsy.YellowDarkSelected;
                    }
                    else
                    {
                        return CheckAllonsy.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return CheckAllonsy.GreenDarkSelected;
                    }
                    else
                    {
                        return CheckAllonsy.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return CheckAllonsy.BlueDarkSelected;
                    }
                    else
                    {
                        return CheckAllonsy.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return CheckAllonsy.AquaSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return CheckAllonsy.TanSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return CheckAllonsy.GreenDarknessSelected;
                    }
                    else
                    {
                        return CheckAllonsy.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return CheckAllonsy.BlueVioletSelected;
                    }
                    else
                    {
                        return CheckAllonsy.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return CheckAllonsy.YellowSelected;
                    }
                    else
                    {
                        return CheckAllonsy.Yellow;
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
                        return CheckCadre.BlueSelected;
                    }
                    else
                    {
                        return CheckCadre.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return CheckCadre.GraySelected;
                    }
                    else
                    {
                        return CheckCadre.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return CheckCadre.GreenSelected;
                    }
                    else
                    {
                        return CheckCadre.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return CheckCadre.RedSelected;
                    }
                    else
                    {
                        return CheckCadre.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return CheckCadre.YellowSelected;
                    }
                    else
                    {
                        return CheckCadre.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return CheckCadre.BlueLightSelected;
                    }
                    else
                    {
                        return CheckCadre.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return CheckCadre.GreenLightSelected;
                    }
                    else
                    {
                        return CheckCadre.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return CheckCadre.YellowLightSelected;
                    }
                    else
                    {
                        return CheckCadre.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return CheckCadre.WhiteSelected;
                    }
                    else
                    {
                        return CheckCadre.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return CheckCadre.PinkSelected;
                    }
                    else
                    {
                        return CheckCadre.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return CheckCadre.OrangeSelected;
                    }
                    else
                    {
                        return CheckCadre.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return CheckCadre.BrownSelected;
                    }
                    else
                    {
                        return CheckCadre.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return CheckCadre.PurpleSelected;
                    }
                    else
                    {
                        return CheckCadre.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return CheckCadre.TurquoiseSelected;
                    }
                    else
                    {
                        return CheckCadre.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return CheckCadre.PinkLightSelected;
                    }
                    else
                    {
                        return CheckCadre.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return CheckCadre.BlueSkySelected;
                    }
                    else
                    {
                        return CheckCadre.BlueSky;
                    }
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return CheckCadre.BlackSelected;
                    }
                    else
                    {
                        return CheckCadre.Black;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return CheckCadre.RedLightSelected;
                    }
                    else
                    {
                        return CheckCadre.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return CheckCadre.GrayLightSelected;
                    }
                    else
                    {
                        return CheckCadre.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return CheckCadre.OrangeLightSelected;
                    }
                    else
                    {
                        return CheckCadre.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return CheckCadre.YellowDarkSelected;
                    }
                    else
                    {
                        return CheckCadre.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return CheckCadre.GreenDarkSelected;
                    }
                    else
                    {
                        return CheckCadre.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return CheckCadre.BlueDarkSelected;
                    }
                    else
                    {
                        return CheckCadre.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return CheckCadre.AquaSelected;
                    }
                    else
                    {
                        return CheckCadre.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return CheckCadre.TanSelected;
                    }
                    else
                    {
                        return CheckCadre.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return CheckCadre.GreenDarknessSelected;
                    }
                    else
                    {
                        return CheckCadre.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return CheckCadre.BlueVioletSelected;
                    }
                    else
                    {
                        return CheckCadre.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return CheckCadre.YellowSelected;
                    }
                    else
                    {
                        return CheckCadre.Yellow;
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
                        return CheckShinning.BlueSelected;
                    }
                    else
                    {
                        return CheckShinning.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return CheckShinning.GraySelected;
                    }
                    else
                    {
                        return CheckShinning.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return CheckShinning.GreenSelected;
                    }
                    else
                    {
                        return CheckShinning.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return CheckShinning.RedSelected;
                    }
                    else
                    {
                        return CheckShinning.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return CheckShinning.YellowSelected;
                    }
                    else
                    {
                        return CheckShinning.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return CheckShinning.BlueLightSelected;
                    }
                    else
                    {
                        return CheckShinning.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return CheckShinning.GreenLightSelected;
                    }
                    else
                    {
                        return CheckShinning.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return CheckShinning.YellowLightSelected;
                    }
                    else
                    {
                        return CheckShinning.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return CheckShinning.WhiteSelected;
                    }
                    else
                    {
                        return CheckShinning.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return CheckShinning.PinkSelected;
                    }
                    else
                    {
                        return CheckShinning.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return CheckShinning.OrangeSelected;
                    }
                    else
                    {
                        return CheckShinning.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return CheckShinning.BrownSelected;
                    }
                    else
                    {
                        return CheckShinning.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return CheckShinning.PurpleSelected;
                    }
                    else
                    {
                        return CheckShinning.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return CheckShinning.TurquoiseSelected;
                    }
                    else
                    {
                        return CheckShinning.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return CheckShinning.PinkLightSelected;
                    }
                    else
                    {
                        return CheckShinning.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return CheckShinning.BlueSkySelected;
                    }
                    else
                    {
                        return CheckShinning.BlueSky;
                    }
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return CheckShinning.BlackSelected;
                    }
                    else
                    {
                        return CheckShinning.Black;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return CheckShinning.RedLightSelected;
                    }
                    else
                    {
                        return CheckShinning.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return CheckShinning.GrayLightSelected;
                    }
                    else
                    {
                        return CheckShinning.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return CheckShinning.OrangeLightSelected;
                    }
                    else
                    {
                        return CheckShinning.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return CheckShinning.YellowDarkSelected;
                    }
                    else
                    {
                        return CheckShinning.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return CheckShinning.GreenDarkSelected;
                    }
                    else
                    {
                        return CheckShinning.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return CheckShinning.BlueDarkSelected;
                    }
                    else
                    {
                        return CheckShinning.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return CheckShinning.AquaSelected;
                    }
                    else
                    {
                        return CheckShinning.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return CheckShinning.TanSelected;
                    }
                    else
                    {
                        return CheckShinning.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return CheckShinning.GreenDarknessSelected;
                    }
                    else
                    {
                        return CheckShinning.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return CheckShinning.BlueVioletSelected;
                    }
                    else
                    {
                        return CheckShinning.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return CheckShinning.YellowSelected;
                    }
                    else
                    {
                        return CheckShinning.Yellow;
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
                        return CheckScratches.BlueSelected;
                    }
                    else
                    {
                        return CheckScratches.Blue;
                    }
                case ColorUI.Gray:
                    if (isSelected)
                    {
                        return CheckScratches.GraySelected;
                    }
                    else
                    {
                        return CheckScratches.Gray;
                    }
                case ColorUI.Green:
                    if (isSelected)
                    {
                        return CheckScratches.GreenSelected;
                    }
                    else
                    {
                        return CheckScratches.Green;
                    }
                case ColorUI.Red:
                    if (isSelected)
                    {
                        return CheckScratches.RedSelected;
                    }
                    else
                    {
                        return CheckScratches.Red;
                    }
                case ColorUI.Yellow:
                    if (isSelected)
                    {
                        return CheckScratches.YellowSelected;
                    }
                    else
                    {
                        return CheckScratches.Yellow;
                    }
                case ColorUI.BlueLight:
                    if (isSelected)
                    {
                        return CheckScratches.BlueLightSelected;
                    }
                    else
                    {
                        return CheckScratches.BlueLight;
                    }
                case ColorUI.GreenLight:
                    if (isSelected)
                    {
                        return CheckScratches.GreenLightSelected;
                    }
                    else
                    {
                        return CheckScratches.GreenLight;
                    }
                case ColorUI.YellowLight:
                    if (isSelected)
                    {
                        return CheckScratches.YellowLightSelected;
                    }
                    else
                    {
                        return CheckScratches.YellowLight;
                    }
                case ColorUI.White:
                    if (isSelected)
                    {
                        return CheckScratches.WhiteSelected;
                    }
                    else
                    {
                        return CheckScratches.White;
                    }
                case ColorUI.Pink:
                    if (isSelected)
                    {
                        return CheckScratches.PinkSelected;
                    }
                    else
                    {
                        return CheckScratches.Pink;
                    }
                case ColorUI.Orange:
                    if (isSelected)
                    {
                        return CheckScratches.OrangeSelected;
                    }
                    else
                    {
                        return CheckScratches.Orange;
                    }
                case ColorUI.Brown:
                    if (isSelected)
                    {
                        return CheckScratches.BrownSelected;
                    }
                    else
                    {
                        return CheckScratches.Brown;
                    }
                case ColorUI.Purple:
                    if (isSelected)
                    {
                        return CheckScratches.PurpleSelected;
                    }
                    else
                    {
                        return CheckScratches.Purple;
                    }
                case ColorUI.Turquoise:
                    if (isSelected)
                    {
                        return CheckScratches.TurquoiseSelected;
                    }
                    else
                    {
                        return CheckScratches.Turquoise;
                    }
                case ColorUI.PinkLight:
                    if (isSelected)
                    {
                        return CheckScratches.PinkLightSelected;
                    }
                    else
                    {
                        return CheckScratches.PinkLight;
                    }
                case ColorUI.BlueSky:
                    if (isSelected)
                    {
                        return CheckScratches.BlueSkySelected;
                    }
                    else
                    {
                        return CheckScratches.BlueSky;
                    }
                case ColorUI.Black:
                    if (isSelected)
                    {
                        return CheckScratches.BlackSelected;
                    }
                    else
                    {
                        return CheckScratches.Black;
                    }
                case ColorUI.RedLight:
                    if (isSelected)
                    {
                        return CheckScratches.RedLightSelected;
                    }
                    else
                    {
                        return CheckScratches.RedLight;
                    }
                case ColorUI.GrayLight:
                    if (isSelected)
                    {
                        return CheckScratches.GrayLightSelected;
                    }
                    else
                    {
                        return CheckScratches.GrayLight;
                    }
                case ColorUI.OrangeLight:
                    if (isSelected)
                    {
                        return CheckScratches.OrangeLightSelected;
                    }
                    else
                    {
                        return CheckScratches.OrangeLight;
                    }
                case ColorUI.YellowDark:
                    if (isSelected)
                    {
                        return CheckScratches.YellowDarkSelected;
                    }
                    else
                    {
                        return CheckScratches.YellowDark;
                    }
                case ColorUI.GreenDark:
                    if (isSelected)
                    {
                        return CheckScratches.GreenDarkSelected;
                    }
                    else
                    {
                        return CheckScratches.GreenDark;
                    }
                case ColorUI.BlueDark:
                    if (isSelected)
                    {
                        return CheckScratches.BlueDarkSelected;
                    }
                    else
                    {
                        return CheckScratches.BlueDark;
                    }
                case ColorUI.Aqua:
                    if (isSelected)
                    {
                        return CheckScratches.AquaSelected;
                    }
                    else
                    {
                        return CheckScratches.Aqua;
                    }
                case ColorUI.Tan:
                    if (isSelected)
                    {
                        return CheckScratches.TanSelected;
                    }
                    else
                    {
                        return CheckScratches.Tan;
                    }
                case ColorUI.GreenDarkness:
                    if (isSelected)
                    {
                        return CheckScratches.GreenDarknessSelected;
                    }
                    else
                    {
                        return CheckScratches.GreenDarkness;
                    }
                case ColorUI.BlueViolet:
                    if (isSelected)
                    {
                        return CheckScratches.BlueVioletSelected;
                    }
                    else
                    {
                        return CheckScratches.BlueViolet;
                    }
                default:
                    if (isSelected)
                    {
                        return CheckScratches.YellowSelected;
                    }
                    else
                    {
                        return CheckScratches.Yellow;
                    }
            }
        }

        private string GetColor(DesignType type, ColorUI color, bool isChecked)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetImage" + type.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            object[] parametersInvoke = { color, isChecked };

            var returnStringColor = (string)methodToInvoke.Invoke(this, parametersInvoke);
            return returnStringColor;
        }
    }
}
