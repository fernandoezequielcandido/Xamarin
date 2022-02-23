using System;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorGroupBox
{
    /// <summary>
    /// Class BarBox
    /// </summary>
    public class BarBox: Image
    {
        private ImageSource internalSource;
        private DesignType currentDesignType;
        private ColorUI currentColor;

        /// <summary>
        /// Constructor of BoxImage
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        /// <param name="designType"></param>
        public BarBox(string hash, DesignType designType, ColorUI color)
        {
            if (hash != "hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ")
            {
                throw new Exception("Key in Invalid in Constructor");
            }

            currentDesignType = designType;
            currentColor = color;

            Aspect = Aspect.Fill;
            Margin = new Thickness(2, 0, 2, 0);
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;

            byte[] imageBytes = Convert.FromBase64String(GetColor(designType, color));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        private string GetImageShining(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Shinning.Black;
                case ColorUI.Blue:
                    return Shinning.Blue;
                case ColorUI.Gray:
                    return Shinning.Gray;
                case ColorUI.Green:
                    return Shinning.Green;
                case ColorUI.Red:
                    return Shinning.Red;
                case ColorUI.Yellow:
                    return Shinning.Yellow;
                case ColorUI.BlueLight:
                    return Shinning.BlueLight;
                case ColorUI.GreenLight:
                    return Shinning.GreenLight;
                case ColorUI.YellowLight:
                    return Shinning.YellowLight;
                case ColorUI.White:
                    return Shinning.White;
                case ColorUI.Pink:
                    return Shinning.Pink;
                case ColorUI.Orange:
                    return Shinning.Orange;
                case ColorUI.Brown:
                    return Shinning.Brown;
                case ColorUI.Purple:
                    return Shinning.Purple;
                case ColorUI.Turquoise:
                    return Shinning.Turquoise;
                case ColorUI.PinkLight:
                    return Shinning.PinkLight;
                case ColorUI.BlueSky:
                    return Shinning.BlueSky;
                case ColorUI.GrayLight:
                    return Shinning.GrayLight;
                case ColorUI.RedLight:
                    return Shinning.RedLight;
                case ColorUI.OrangeLight:
                    return Shinning.OrangeLight;
                case ColorUI.YellowDark:
                    return Shinning.YellowDark;
                case ColorUI.GreenDark:
                    return Shinning.GreenDark;
                case ColorUI.BlueDark:
                    return Shinning.BlueDark;
                case ColorUI.Aqua:
                    return Shinning.Aqua;
                case ColorUI.Tan:
                    return Shinning.Tan;
                case ColorUI.GreenDarkness:
                    return Shinning.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Shinning.BlueViolet;
                case ColorUI.Transparent:
                    return Shinning.White;
                default:
                    return Shinning.Gray;
            }
        }

        private string GetImageStandard(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Standard.Black;
                case ColorUI.Blue:
                    return Standard.Blue;
                case ColorUI.Gray:
                    return Standard.Gray;
                case ColorUI.Green:
                    return Standard.Green;
                case ColorUI.Red:
                    return Standard.Red;
                case ColorUI.Yellow:
                    return Standard.Yellow;
                case ColorUI.BlueLight:
                    return Standard.BlueLight;
                case ColorUI.GreenLight:
                    return Standard.GreenLight;
                case ColorUI.YellowLight:
                    return Standard.YellowLight;
                case ColorUI.White:
                    return Standard.White;
                case ColorUI.Pink:
                    return Standard.Pink;
                case ColorUI.Orange:
                    return Standard.Orange;
                case ColorUI.Brown:
                    return Standard.Brown;
                case ColorUI.Purple:
                    return Standard.Purple;
                case ColorUI.Turquoise:
                    return Standard.Turquoise;
                case ColorUI.PinkLight:
                    return Standard.PinkLight;
                case ColorUI.BlueSky:
                    return Standard.BlueSky;
                case ColorUI.GrayLight:
                    return Standard.GrayLight;
                case ColorUI.RedLight:
                    return Standard.RedLight;
                case ColorUI.OrangeLight:
                    return Standard.OrangeLight;
                case ColorUI.YellowDark:
                    return Standard.YellowDark;
                case ColorUI.GreenDark:
                    return Standard.GreenDark;
                case ColorUI.BlueDark:
                    return Standard.BlueDark;
                case ColorUI.Aqua:
                    return Standard.Aqua;
                case ColorUI.Tan:
                    return Standard.Tan;
                case ColorUI.GreenDarkness:
                    return Standard.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Standard.BlueViolet;
                case ColorUI.Transparent:
                    return Standard.White;
                default:
                    return Standard.Gray;
            }
        }

        private string GetImageFit(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Fit.Black;
                case ColorUI.Blue:
                    return Fit.Blue;
                case ColorUI.Gray:
                    return Fit.Gray;
                case ColorUI.Green:
                    return Fit.Green;
                case ColorUI.Red:
                    return Fit.Red;
                case ColorUI.Yellow:
                    return Fit.Yellow;
                case ColorUI.BlueLight:
                    return Fit.BlueLight;
                case ColorUI.GreenLight:
                    return Fit.GreenLight;
                case ColorUI.YellowLight:
                    return Fit.YellowLight;
                case ColorUI.White:
                    return Fit.White;
                case ColorUI.Pink:
                    return Fit.Pink;
                case ColorUI.Orange:
                    return Fit.Orange;
                case ColorUI.Brown:
                    return Fit.Brown;
                case ColorUI.Purple:
                    return Fit.Purple;
                case ColorUI.Turquoise:
                    return Fit.Turquoise;
                case ColorUI.PinkLight:
                    return Fit.PinkLight;
                case ColorUI.BlueSky:
                    return Fit.BlueSky;
                case ColorUI.GrayLight:
                    return Fit.GrayLight;
                case ColorUI.RedLight:
                    return Fit.RedLight;
                case ColorUI.OrangeLight:
                    return Fit.OrangeLight;
                case ColorUI.YellowDark:
                    return Fit.YellowDark;
                case ColorUI.GreenDark:
                    return Fit.GreenDark;
                case ColorUI.BlueDark:
                    return Fit.BlueDark;
                case ColorUI.Aqua:
                    return Fit.Aqua;
                case ColorUI.Tan:
                    return Fit.Tan;
                case ColorUI.GreenDarkness:
                    return Fit.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Fit.BlueViolet;
                case ColorUI.Transparent:
                    return Fit.White;
                default:
                    return Fit.Gray;
            }
        }

        private string GetImageFilled(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Filled.Black;
                case ColorUI.Blue:
                    return Filled.Blue;
                case ColorUI.Gray:
                    return Filled.Gray;
                case ColorUI.Green:
                    return Filled.Green;
                case ColorUI.Red:
                    return Filled.Red;
                case ColorUI.Yellow:
                    return Filled.Yellow;
                case ColorUI.BlueLight:
                    return Filled.BlueLight;
                case ColorUI.GreenLight:
                    return Filled.GreenLight;
                case ColorUI.YellowLight:
                    return Filled.YellowLight;
                case ColorUI.White:
                    return Filled.White;
                case ColorUI.Pink:
                    return Filled.Pink;
                case ColorUI.Orange:
                    return Filled.Orange;
                case ColorUI.Brown:
                    return Filled.Brown;
                case ColorUI.Purple:
                    return Filled.Purple;
                case ColorUI.Turquoise:
                    return Filled.Turquoise;
                case ColorUI.PinkLight:
                    return Filled.PinkLight;
                case ColorUI.BlueSky:
                    return Filled.BlueSky;
                case ColorUI.GrayLight:
                    return Filled.GrayLight;
                case ColorUI.RedLight:
                    return Filled.RedLight;
                case ColorUI.OrangeLight:
                    return Filled.OrangeLight;
                case ColorUI.YellowDark:
                    return Filled.YellowDark;
                case ColorUI.GreenDark:
                    return Filled.GreenDark;
                case ColorUI.BlueDark:
                    return Filled.BlueDark;
                case ColorUI.Aqua:
                    return Filled.Aqua;
                case ColorUI.Tan:
                    return Filled.Tan;
                case ColorUI.GreenDarkness:
                    return Filled.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Filled.BlueViolet;
                case ColorUI.Transparent:
                    return Filled.White;
                default:
                    return Filled.Gray;
            }
        }

        private string GetImageAllonsy(ColorUI color)
        {            
            switch (color)
            {
                case ColorUI.Black:
                    return Allonsy.Black;
                case ColorUI.Blue:
                    return Allonsy.Blue;
                case ColorUI.Gray:
                    return Allonsy.Gray;
                case ColorUI.Green:
                    return Allonsy.Green;
                case ColorUI.Red:
                    return Allonsy.Red;
                case ColorUI.Yellow:
                    return Allonsy.Yellow;
                case ColorUI.BlueLight:
                    return Allonsy.BlueLight;
                case ColorUI.GreenLight:
                    return Allonsy.GreenLight;
                case ColorUI.YellowLight:
                    return Allonsy.YellowLight;
                case ColorUI.White:
                    return Allonsy.White;
                case ColorUI.Pink:
                    return Allonsy.Pink;
                case ColorUI.Orange:
                    return Allonsy.Orange;
                case ColorUI.Brown:
                    return Allonsy.Brown;
                case ColorUI.Purple:
                    return Allonsy.Purple;
                case ColorUI.Turquoise:
                    return Allonsy.Turquoise;
                case ColorUI.PinkLight:
                    return Allonsy.PinkLight;
                case ColorUI.BlueSky:
                    return Allonsy.BlueSky;
                case ColorUI.GrayLight:
                    return Allonsy.GrayLight;
                case ColorUI.RedLight:
                    return Allonsy.RedLight;
                case ColorUI.OrangeLight:
                    return Allonsy.OrangeLight;
                case ColorUI.YellowDark:
                    return Allonsy.YellowDark;
                case ColorUI.GreenDark:
                    return Allonsy.GreenDark;
                case ColorUI.BlueDark:
                    return Allonsy.BlueDark;
                case ColorUI.Aqua:
                    return Allonsy.Aqua;
                case ColorUI.Tan:
                    return Allonsy.Tan;
                case ColorUI.GreenDarkness:
                    return Allonsy.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Allonsy.BlueViolet;
                case ColorUI.Transparent:
                    return Allonsy.White;
                default:
                    return Allonsy.Gray;
            }
        }

        private string GetImageScratches(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Scratches.Black;
                case ColorUI.Blue:
                    return Scratches.Blue;
                case ColorUI.Gray:
                    return Scratches.Gray;
                case ColorUI.Green:
                    return Scratches.Green;
                case ColorUI.Red:
                    return Scratches.Red;
                case ColorUI.Yellow:
                    return Scratches.Yellow;
                case ColorUI.BlueLight:
                    return Scratches.BlueLight;
                case ColorUI.GreenLight:
                    return Scratches.GreenLight;
                case ColorUI.YellowLight:
                    return Scratches.YellowLight;
                case ColorUI.White:
                    return Scratches.White;
                case ColorUI.Pink:
                    return Scratches.Pink;
                case ColorUI.Orange:
                    return Scratches.Orange;
                case ColorUI.Brown:
                    return Scratches.Brown;
                case ColorUI.Purple:
                    return Scratches.Purple;
                case ColorUI.Turquoise:
                    return Scratches.Turquoise;
                case ColorUI.PinkLight:
                    return Scratches.PinkLight;
                case ColorUI.BlueSky:
                    return Scratches.BlueSky;
                case ColorUI.GrayLight:
                    return Scratches.GrayLight;
                case ColorUI.RedLight:
                    return Scratches.RedLight;
                case ColorUI.OrangeLight:
                    return Scratches.OrangeLight;
                case ColorUI.YellowDark:
                    return Scratches.YellowDark;
                case ColorUI.BlueDark:
                    return Scratches.BlueDark;
                case ColorUI.GreenDark:
                    return Scratches.GreenDark;
                case ColorUI.Aqua:
                    return Scratches.Aqua;
                case ColorUI.Tan:
                    return Scratches.Tan;
                case ColorUI.GreenDarkness:
                    return Scratches.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Scratches.BlueViolet;
                case ColorUI.Transparent:
                    return Scratches.White;
                default:
                    return Scratches.Gray;
            }
        }

        private string GetImageCadre(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Cadre.Black;
                case ColorUI.Blue:
                    return Cadre.Blue;
                case ColorUI.Gray:
                    return Cadre.Gray;
                case ColorUI.Green:
                    return Cadre.Green;
                case ColorUI.Red:
                    return Cadre.Red;
                case ColorUI.Yellow:
                    return Cadre.Yellow;
                case ColorUI.BlueLight:
                    return Cadre.BlueLight;
                case ColorUI.GreenLight:
                    return Cadre.GreenLight;
                case ColorUI.YellowLight:
                    return Cadre.YellowLight;
                case ColorUI.White:
                    return Cadre.White;
                case ColorUI.Pink:
                    return Cadre.Pink;
                case ColorUI.Orange:
                    return Cadre.Orange;
                case ColorUI.Brown:
                    return Cadre.Brown;
                case ColorUI.Purple:
                    return Cadre.Purple;
                case ColorUI.Turquoise:
                    return Cadre.Turquoise;
                case ColorUI.PinkLight:
                    return Cadre.PinkLight;
                case ColorUI.BlueSky:
                    return Cadre.BlueSky;
                case ColorUI.GrayLight:
                    return Cadre.GrayLight;
                case ColorUI.RedLight:
                    return Cadre.RedLight;
                case ColorUI.OrangeLight:
                    return Cadre.OrangeLight;
                case ColorUI.YellowDark:
                    return Cadre.YellowDark;
                case ColorUI.BlueDark:
                    return Cadre.BlueDark;
                case ColorUI.GreenDark:
                    return Cadre.GreenDark;
                case ColorUI.Aqua:
                    return Cadre.Aqua;
                case ColorUI.Tan:
                    return Cadre.Tan;
                case ColorUI.GreenDarkness:
                    return Cadre.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Cadre.BlueViolet;
                case ColorUI.Transparent:
                    return Cadre.White;
                default:
                    return Cadre.Gray;
            }
        }

        private string GetImageSmoke(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Smoke.Black;
                case ColorUI.Blue:
                    return Smoke.Blue;
                case ColorUI.Gray:
                    return Smoke.Gray;
                case ColorUI.Green:
                    return Smoke.Green;
                case ColorUI.Red:
                    return Smoke.Red;
                case ColorUI.Yellow:
                    return Smoke.Yellow;
                case ColorUI.BlueLight:
                    return Smoke.BlueLight;
                case ColorUI.GreenLight:
                    return Smoke.GreenLight;
                case ColorUI.YellowLight:
                    return Smoke.YellowLight;
                case ColorUI.White:
                    return Smoke.White;
                case ColorUI.Pink:
                    return Smoke.Pink;
                case ColorUI.Orange:
                    return Smoke.Orange;
                case ColorUI.Brown:
                    return Smoke.Brown;
                case ColorUI.Purple:
                    return Smoke.Purple;
                case ColorUI.Turquoise:
                    return Smoke.Turquoise;
                case ColorUI.PinkLight:
                    return Smoke.PinkLight;
                case ColorUI.BlueSky:
                    return Smoke.BlueSky;
                case ColorUI.GrayLight:
                    return Smoke.GrayLight;
                case ColorUI.RedLight:
                    return Smoke.RedLight;
                case ColorUI.OrangeLight:
                    return Smoke.OrangeLight;
                case ColorUI.YellowDark:
                    return Smoke.YellowDark;
                case ColorUI.BlueDark:
                    return Smoke.BlueDark;
                case ColorUI.GreenDark:
                    return Smoke.GreenDark;
                case ColorUI.Aqua:
                    return Smoke.Aqua;
                case ColorUI.Tan:
                    return Smoke.Tan;
                case ColorUI.GreenDarkness:
                    return Smoke.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Smoke.BlueViolet;
                case ColorUI.Transparent:
                    return Smoke.White;
                default:
                    return Smoke.Gray;
            }
        }


        /// <summary>
        /// Change Color of BarBox
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        public void ChangeColor(string hash, ColorUI color)
        {
            if (hash != "hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ")
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
        /// Change DesignType of BarBox
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="designType"></param>
        public void ChangeDesignType(string hash, DesignType designType)
        {
            if (hash != "hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ")
            {
                throw new Exception("Key in Invalid in ChangeColor");
            }

            currentDesignType = designType;

            byte[] imageBytes = Convert.FromBase64String(GetColor(designType, currentColor));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }


        private string GetColor(DesignType design, ColorUI color)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetImage" + design.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            object[] parametersInvoke = { color };

            var returnStringColor = (string)methodToInvoke.Invoke(this, parametersInvoke);
            return returnStringColor;
        }
    }
}
