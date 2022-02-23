using System;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    /// <summary>
    /// Class BaseDesignControl
    /// </summary>
    public class BaseDesignControl : Image
    {
        private ImageSource internalSource;
        private DesignType currentDesignType;
        private ColorUI currentColor;

        /// <summary>
        /// Constructor of BaseDesignControl
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        /// <param name="designType"></param>
        public BaseDesignControl(string hash, DesignType designType, ColorUI color)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in Constructor");
            }

            currentDesignType = designType;
            currentColor = color;

            Aspect = Aspect.Fill;
            HorizontalOptions = LayoutOptions.Start;
            VerticalOptions = LayoutOptions.Center;

            byte[] imageBytes = Convert.FromBase64String(GetColor(designType, color));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Change ColorUI of Button
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

            byte[] imageBytes = Convert.FromBase64String(GetColor(currentDesignType, color));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Change DesignType of Button
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

            byte[] imageBytes = Convert.FromBase64String(GetColor(designType, currentColor));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        private string GetImageShinning(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Blue:
                    return BaseShinning.Blue;
                case ColorUI.Gray:
                    return BaseShinning.Gray;
                case ColorUI.Green:
                    return BaseShinning.Green;
                case ColorUI.Red:
                    return BaseShinning.Red;
                case ColorUI.Yellow:
                    return BaseShinning.Yellow;
                case ColorUI.BlueLight:
                    return BaseShinning.BlueLight;
                case ColorUI.GreenLight:
                    return BaseShinning.GreenLight;
                case ColorUI.YellowLight:
                    return BaseShinning.YellowLight;
                case ColorUI.White:
                    return BaseShinning.White;
                case ColorUI.Pink:
                    return BaseShinning.Pink;
                case ColorUI.Orange:
                    return BaseShinning.Orange;
                case ColorUI.Brown:
                    return BaseShinning.Brown;
                case ColorUI.Purple:
                    return BaseShinning.Purple;
                case ColorUI.Turquoise:
                    return BaseShinning.Turquoise;
                case ColorUI.PinkLight:
                    return BaseShinning.PinkLight;
                case ColorUI.BlueSky:
                    return BaseShinning.BlueSky;
                case ColorUI.Black:
                    return BaseShinning.Black;
                case ColorUI.RedLight:
                    return BaseShinning.RedLight;
                case ColorUI.GrayLight:
                    return BaseShinning.GrayLight;
                case ColorUI.OrangeLight:
                    return BaseShinning.OrangeLight;
                case ColorUI.YellowDark:
                    return BaseShinning.YellowDark;
                case ColorUI.GreenDark:
                    return BaseShinning.GreenDark;
                case ColorUI.BlueDark:
                    return BaseShinning.BlueDark;
                case ColorUI.Aqua:
                    return BaseShinning.Aqua;
                case ColorUI.Tan:
                    return BaseShinning.Tan;
                case ColorUI.GreenDarkness:
                    return BaseShinning.GreenDarkness;
                case ColorUI.BlueViolet:
                    return BaseShinning.BlueViolet;
                default:
                    return BaseShinning.BlueSky;
            }
        }

        private string GetImageFit(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return BaseFit.Black;
                case ColorUI.Blue:
                    return BaseFit.Blue;
                case ColorUI.Gray:
                    return BaseFit.Gray;
                case ColorUI.Green:
                    return BaseFit.Green;
                case ColorUI.Red:
                    return BaseFit.Red;
                case ColorUI.Yellow:
                    return BaseFit.Yellow;
                case ColorUI.BlueLight:
                    return BaseFit.BlueLight;
                case ColorUI.GreenLight:
                    return BaseFit.GreenLight;
                case ColorUI.YellowLight:
                    return BaseFit.YellowLight;
                case ColorUI.White:
                    return BaseFit.White;
                case ColorUI.Pink:
                    return BaseFit.Pink;
                case ColorUI.Orange:
                    return BaseFit.Orange;
                case ColorUI.Brown:
                    return BaseFit.Brown;
                case ColorUI.Purple:
                    return BaseFit.Purple;
                case ColorUI.Turquoise:
                    return BaseFit.Turquoise;
                case ColorUI.PinkLight:
                    return BaseFit.PinkLight;
                case ColorUI.BlueSky:
                    return BaseFit.BlueSky;
                case ColorUI.GrayLight:
                    return BaseFit.GrayLight;
                case ColorUI.RedLight:
                    return BaseFit.RedLight;
                case ColorUI.OrangeLight:
                    return BaseFit.OrangeLight;
                case ColorUI.YellowDark:
                    return BaseFit.YellowDark;
                case ColorUI.BlueDark:
                    return BaseFit.BlueDark;
                case ColorUI.GreenDark:
                    return BaseFit.GreenDark;
                case ColorUI.Aqua:
                    return BaseFit.Aqua;
                case ColorUI.Tan:
                    return BaseFit.Tan;
                case ColorUI.GreenDarkness:
                    return BaseFit.GreenDarkness;
                case ColorUI.BlueViolet:
                    return BaseFit.BlueViolet;
                default:
                    return BaseFit.BlueSky;
            }
        }

        private string GetImageScratches(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return BaseScratches.Black;
                case ColorUI.Blue:
                    return BaseScratches.Blue;
                case ColorUI.Gray:
                    return BaseScratches.Gray;
                case ColorUI.Green:
                    return BaseScratches.Green;
                case ColorUI.Red:
                    return BaseScratches.Red;
                case ColorUI.Yellow:
                    return BaseScratches.Yellow;
                case ColorUI.BlueLight:
                    return BaseScratches.BlueLight;
                case ColorUI.GreenLight:
                    return BaseScratches.GreenLight;
                case ColorUI.YellowLight:
                    return BaseScratches.YellowLight;
                case ColorUI.White:
                    return BaseScratches.White;
                case ColorUI.Pink:
                    return BaseScratches.Pink;
                case ColorUI.Orange:
                    return BaseScratches.Orange;
                case ColorUI.Brown:
                    return BaseScratches.Brown;
                case ColorUI.Purple:
                    return BaseScratches.Purple;
                case ColorUI.Turquoise:
                    return BaseScratches.Turquoise;
                case ColorUI.PinkLight:
                    return BaseScratches.PinkLight;
                case ColorUI.BlueSky:
                    return BaseScratches.BlueSky;
                case ColorUI.GrayLight:
                    return BaseScratches.GrayLight;
                case ColorUI.RedLight:
                    return BaseScratches.RedLight;
                case ColorUI.OrangeLight:
                    return BaseScratches.OrangeLight;
                case ColorUI.YellowDark:
                    return BaseScratches.YellowDark;
                case ColorUI.BlueDark:
                    return BaseScratches.BlueDark;
                case ColorUI.GreenDark:
                    return BaseScratches.GreenDark;
                case ColorUI.Aqua:
                    return BaseScratches.Aqua;
                case ColorUI.Tan:
                    return BaseScratches.Tan;
                case ColorUI.GreenDarkness:
                    return BaseScratches.GreenDarkness;
                case ColorUI.BlueViolet:
                    return BaseScratches.BlueViolet;
                default:
                    return BaseScratches.BlueSky;
            }
        }


        private string GetImageFilled(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return BaseFilled.Black;
                case ColorUI.Blue:
                    return BaseFilled.Blue;
                case ColorUI.Gray:
                    return BaseFilled.Gray;
                case ColorUI.Green:
                    return BaseFilled.Green;
                case ColorUI.Red:
                    return BaseFilled.Red;
                case ColorUI.Yellow:
                    return BaseFilled.Yellow;
                case ColorUI.BlueLight:
                    return BaseFilled.BlueLight;
                case ColorUI.GreenLight:
                    return BaseFilled.GreenLight;
                case ColorUI.YellowLight:
                    return BaseFilled.YellowLight;
                case ColorUI.White:
                    return BaseFilled.White;
                case ColorUI.Pink:
                    return BaseFilled.Pink;
                case ColorUI.Orange:
                    return BaseFilled.Orange;
                case ColorUI.Brown:
                    return BaseFilled.Brown;
                case ColorUI.Purple:
                    return BaseFilled.Purple;
                case ColorUI.Turquoise:
                    return BaseFilled.Turquoise;
                case ColorUI.PinkLight:
                    return BaseFilled.PinkLight;
                case ColorUI.BlueSky:
                    return BaseFilled.BlueSky;
                case ColorUI.GrayLight:
                    return BaseFilled.GrayLight;
                case ColorUI.RedLight:
                    return BaseFilled.RedLight;
                case ColorUI.OrangeLight:
                    return BaseFilled.OrangeLight;
                case ColorUI.YellowDark:
                    return BaseFilled.YellowDark;
                case ColorUI.GreenDark:
                    return BaseFilled.GreenDark;
                case ColorUI.BlueDark:
                    return BaseFilled.BlueDark;
                case ColorUI.Aqua:
                    return BaseFilled.Aqua;
                case ColorUI.Tan:
                    return BaseFilled.Tan;
                case ColorUI.GreenDarkness:
                    return BaseFilled.GreenDarkness;
                case ColorUI.BlueViolet:
                    return BaseFilled.BlueViolet;
                default:
                    return BaseFilled.Gray;
            }
        }


        private string GetImageAllonsy(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return BaseAllonsy.Black;
                case ColorUI.Blue:
                    return BaseAllonsy.Blue;
                case ColorUI.Gray:
                    return BaseAllonsy.Gray;
                case ColorUI.Green:
                    return BaseAllonsy.Green;
                case ColorUI.Red:
                    return BaseAllonsy.Red;
                case ColorUI.Yellow:
                    return BaseAllonsy.Yellow;
                case ColorUI.BlueLight:
                    return BaseAllonsy.BlueLight;
                case ColorUI.GreenLight:
                    return BaseAllonsy.GreenLight;
                case ColorUI.YellowLight:
                    return BaseAllonsy.YellowLight;
                case ColorUI.White:
                    return BaseAllonsy.White;
                case ColorUI.Pink:
                    return BaseAllonsy.Pink;
                case ColorUI.Orange:
                    return BaseAllonsy.Orange;
                case ColorUI.Brown:
                    return BaseAllonsy.Brown;
                case ColorUI.Purple:
                    return BaseAllonsy.Purple;
                case ColorUI.Turquoise:
                    return BaseAllonsy.Turquoise;
                case ColorUI.PinkLight:
                    return BaseAllonsy.PinkLight;
                case ColorUI.BlueSky:
                    return BaseAllonsy.BlueSky;
                case ColorUI.GrayLight:
                    return BaseAllonsy.GrayLight;
                case ColorUI.RedLight:
                    return BaseAllonsy.RedLight;
                case ColorUI.OrangeLight:
                    return BaseAllonsy.OrangeLight;
                case ColorUI.YellowDark:
                    return BaseAllonsy.YellowDark;
                case ColorUI.GreenDark:
                    return BaseAllonsy.GreenDark;
                case ColorUI.BlueDark:
                    return BaseAllonsy.BlueDark;
                case ColorUI.Aqua:
                    return BaseAllonsy.Aqua;
                case ColorUI.Tan:
                    return BaseAllonsy.Tan;
                case ColorUI.GreenDarkness:
                    return BaseAllonsy.GreenDarkness;
                case ColorUI.BlueViolet:
                    return BaseAllonsy.BlueViolet;
                default:
                    return BaseAllonsy.BlueSky;
            }
        }

        private string GetImageCadre(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return BaseCadre.Black;
                case ColorUI.Blue:
                    return BaseCadre.Blue;
                case ColorUI.Gray:
                    return BaseCadre.Gray;
                case ColorUI.Green:
                    return BaseCadre.Green;
                case ColorUI.Red:
                    return BaseCadre.Red;
                case ColorUI.Yellow:
                    return BaseCadre.Yellow;
                case ColorUI.BlueLight:
                    return BaseCadre.BlueLight;
                case ColorUI.GreenLight:
                    return BaseCadre.GreenLight;
                case ColorUI.YellowLight:
                    return BaseCadre.YellowLight;
                case ColorUI.White:
                    return BaseCadre.White;
                case ColorUI.Pink:
                    return BaseCadre.Pink;
                case ColorUI.Orange:
                    return BaseCadre.Orange;
                case ColorUI.Brown:
                    return BaseCadre.Brown;
                case ColorUI.Purple:
                    return BaseCadre.Purple;
                case ColorUI.Turquoise:
                    return BaseCadre.Turquoise;
                case ColorUI.PinkLight:
                    return BaseCadre.PinkLight;
                case ColorUI.BlueSky:
                    return BaseCadre.BlueSky;
                case ColorUI.GrayLight:
                    return BaseCadre.GrayLight;
                case ColorUI.RedLight:
                    return BaseCadre.RedLight;
                case ColorUI.OrangeLight:
                    return BaseCadre.OrangeLight;
                case ColorUI.YellowDark:
                    return BaseCadre.YellowDark;
                case ColorUI.BlueDark:
                    return BaseCadre.BlueDark;
                case ColorUI.GreenDark:
                    return BaseCadre.GreenDark;
                case ColorUI.Aqua:
                    return BaseCadre.Aqua;
                case ColorUI.Tan:
                    return BaseCadre.Tan;
                case ColorUI.GreenDarkness:
                    return BaseCadre.GreenDarkness;
                case ColorUI.BlueViolet:
                    return BaseCadre.BlueViolet;
                default:
                    return BaseCadre.BlueSky;
            }
        }

        private string GetImageSmoke(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return BaseSmoke.Black;
                case ColorUI.Blue:
                    return BaseSmoke.Blue;
                case ColorUI.Gray:
                    return BaseSmoke.Gray;
                case ColorUI.Green:
                    return BaseSmoke.Green;
                case ColorUI.Red:
                    return BaseSmoke.Red;
                case ColorUI.Yellow:
                    return BaseSmoke.Yellow;
                case ColorUI.BlueLight:
                    return BaseSmoke.BlueLight;
                case ColorUI.GreenLight:
                    return BaseSmoke.GreenLight;
                case ColorUI.YellowLight:
                    return BaseSmoke.YellowLight;
                case ColorUI.White:
                    return BaseSmoke.White;
                case ColorUI.Pink:
                    return BaseSmoke.Pink;
                case ColorUI.Orange:
                    return BaseSmoke.Orange;
                case ColorUI.Brown:
                    return BaseSmoke.Brown;
                case ColorUI.Purple:
                    return BaseSmoke.Purple;
                case ColorUI.Turquoise:
                    return BaseSmoke.Turquoise;
                case ColorUI.PinkLight:
                    return BaseSmoke.PinkLight;
                case ColorUI.BlueSky:
                    return BaseSmoke.BlueSky;
                case ColorUI.GrayLight:
                    return BaseSmoke.GrayLight;
                case ColorUI.RedLight:
                    return BaseSmoke.RedLight;
                case ColorUI.OrangeLight:
                    return BaseSmoke.OrangeLight;
                case ColorUI.YellowDark:
                    return BaseSmoke.YellowDark;
                case ColorUI.BlueDark:
                    return BaseSmoke.BlueDark;
                case ColorUI.GreenDark:
                    return BaseSmoke.GreenDark;
                case ColorUI.Aqua:
                    return BaseSmoke.Aqua;
                case ColorUI.Tan:
                    return BaseSmoke.Tan;
                case ColorUI.GreenDarkness:
                    return BaseSmoke.GreenDarkness;
                case ColorUI.BlueViolet:
                    return BaseSmoke.BlueViolet;
                default:
                    return BaseSmoke.BlueSky;
            }
        }

        private string GetColor(DesignType type, ColorUI color)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetImage" + type.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            object[] parametersInvoke = { color };

            var returnStringColor = (string)methodToInvoke.Invoke(this, parametersInvoke);
            return returnStringColor;
        }
    }
}
