using System;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    /// <summary>
    /// Class ButtonIconImage
    /// </summary>
    public class ButtonIconImage : Image
    {
        private ImageSource internalSource;
        private IconType currentIconType;
        private ColorUI currentColor;

        /// <summary>
        /// Constructor of ButtonIconImage
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="iconType"></param>
        /// <param name="color"></param>
        public ButtonIconImage(string hash, IconType iconType, ColorUI color)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in Constructor");
            }

            currentIconType = iconType;
            currentColor = color;

            Aspect = Aspect.Fill;
            HorizontalOptions = LayoutOptions.Start;
            VerticalOptions = LayoutOptions.Center;

            byte[] imageBytes = Convert.FromBase64String(GetColor(iconType, color));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Change ColorUI of ButtonIcon
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

            byte[] imageBytes = Convert.FromBase64String(GetColor(currentIconType, color));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Change IconType of ButtonIcon
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="iconType"></param>
        public void ChangeIconType(string hash, IconType iconType)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in ChangeIconType");
            }

            currentIconType = iconType;

            byte[] imageBytes = Convert.FromBase64String(GetColor(iconType, currentColor));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        private string GetImageConfiguration(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Configuration.Black;
                case ColorUI.Blue:
                    return Configuration.Blue;
                case ColorUI.Gray:
                    return Configuration.Gray;
                case ColorUI.Green:
                    return Configuration.Green;
                case ColorUI.Red:
                    return Configuration.Red;
                case ColorUI.Yellow:
                    return Configuration.Yellow;
                case ColorUI.BlueLight:
                    return Configuration.BlueLight;
                case ColorUI.GreenLight:
                    return Configuration.GreenLight;
                case ColorUI.YellowLight:
                    return Configuration.YellowLight;
                case ColorUI.White:
                    return Configuration.White;
                case ColorUI.Pink:
                    return Configuration.Pink;
                case ColorUI.Orange:
                    return Configuration.Orange;
                case ColorUI.Brown:
                    return Configuration.Brown;
                case ColorUI.Purple:
                    return Configuration.Purple;
                case ColorUI.Turquoise:
                    return Configuration.Turquoise;
                case ColorUI.PinkLight:
                    return Configuration.PinkLight;
                case ColorUI.BlueSky:
                    return Configuration.BlueSky;
                case ColorUI.GrayLight:
                    return Configuration.GrayLight;
                case ColorUI.RedLight:
                    return Configuration.RedLight;
                case ColorUI.OrangeLight:
                    return Configuration.OrangeLight;
                case ColorUI.YellowDark:
                    return Configuration.YellowDark;
                case ColorUI.GreenDark:
                    return Configuration.GreenDark;
                case ColorUI.BlueDark:
                    return Configuration.BlueDark;
                case ColorUI.Aqua:
                    return Configuration.Aqua;
                case ColorUI.Tan:
                    return Configuration.Tan;
                case ColorUI.GreenDarkness:
                    return Configuration.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Configuration.BlueViolet;
                case ColorUI.Transparent:
                    return Configuration.White;
                default:
                    return Configuration.Gray;
            }
        }

        private string GetImageLike(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Like.Black;
                case ColorUI.Blue:
                    return Like.Blue;
                case ColorUI.Gray:
                    return Like.Gray;
                case ColorUI.Green:
                    return Like.Green;
                case ColorUI.Red:
                    return Like.Red;
                case ColorUI.Yellow:
                    return Like.Yellow;
                case ColorUI.BlueLight:
                    return Like.BlueLight;
                case ColorUI.GreenLight:
                    return Like.GreenLight;
                case ColorUI.YellowLight:
                    return Like.YellowLight;
                case ColorUI.White:
                    return Like.White;
                case ColorUI.Pink:
                    return Like.Pink;
                case ColorUI.Orange:
                    return Like.Orange;
                case ColorUI.Brown:
                    return Like.Brown;
                case ColorUI.Purple:
                    return Like.Purple;
                case ColorUI.Turquoise:
                    return Like.Turquoise;
                case ColorUI.PinkLight:
                    return Like.PinkLight;
                case ColorUI.BlueSky:
                    return Like.BlueSky;
                case ColorUI.GrayLight:
                    return Like.GrayLight;
                case ColorUI.RedLight:
                    return Like.RedLight;
                case ColorUI.OrangeLight:
                    return Like.OrangeLight;
                case ColorUI.YellowDark:
                    return Like.YellowDark;
                case ColorUI.GreenDark:
                    return Like.GreenDark;
                case ColorUI.BlueDark:
                    return Like.BlueDark;
                case ColorUI.Aqua:
                    return Like.Aqua;
                case ColorUI.Tan:
                    return Like.Tan;
                case ColorUI.GreenDarkness:
                    return Like.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Like.BlueViolet;
                case ColorUI.Transparent:
                    return Like.White;
                default:
                    return Like.Gray;
            }
        }

        private string GetImageMail(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Mail.Black;
                case ColorUI.Blue:
                    return Mail.Blue;
                case ColorUI.Gray:
                    return Mail.Gray;
                case ColorUI.Green:
                    return Mail.Green;
                case ColorUI.Red:
                    return Mail.Red;
                case ColorUI.Yellow:
                    return Mail.Yellow;
                case ColorUI.BlueLight:
                    return Mail.BlueLight;
                case ColorUI.GreenLight:
                    return Mail.GreenLight;
                case ColorUI.YellowLight:
                    return Mail.YellowLight;
                case ColorUI.White:
                    return Mail.White;
                case ColorUI.Pink:
                    return Mail.Pink;
                case ColorUI.Orange:
                    return Mail.Orange;
                case ColorUI.Brown:
                    return Mail.Brown;
                case ColorUI.Purple:
                    return Mail.Purple;
                case ColorUI.Turquoise:
                    return Mail.Turquoise;
                case ColorUI.PinkLight:
                    return Mail.PinkLight;
                case ColorUI.BlueSky:
                    return Mail.BlueSky;
                case ColorUI.GrayLight:
                    return Mail.GrayLight;
                case ColorUI.RedLight:
                    return Mail.RedLight;
                case ColorUI.OrangeLight:
                    return Mail.OrangeLight;
                case ColorUI.YellowDark:
                    return Mail.YellowDark;
                case ColorUI.GreenDark:
                    return Mail.GreenDark;
                case ColorUI.BlueDark:
                    return Mail.BlueDark;
                case ColorUI.Aqua:
                    return Mail.Aqua;
                case ColorUI.Tan:
                    return Mail.Tan;
                case ColorUI.GreenDarkness:
                    return Mail.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Mail.BlueViolet;
                case ColorUI.Transparent:
                    return Mail.White;
                default:
                    return Mail.BlueSky;
            }
        }

        private string GetImageQuestion(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Question.Black;
                case ColorUI.Blue:
                    return Question.Blue;
                case ColorUI.Gray:
                    return Question.Gray;
                case ColorUI.Green:
                    return Question.Green;
                case ColorUI.Red:
                    return Question.Red;
                case ColorUI.Yellow:
                    return Question.Yellow;
                case ColorUI.BlueLight:
                    return Question.BlueLight;
                case ColorUI.GreenLight:
                    return Question.GreenLight;
                case ColorUI.YellowLight:
                    return Question.YellowLight;
                case ColorUI.White:
                    return Question.White;
                case ColorUI.Pink:
                    return Question.Pink;
                case ColorUI.Orange:
                    return Question.Orange;
                case ColorUI.Brown:
                    return Question.Brown;
                case ColorUI.Purple:
                    return Question.Purple;
                case ColorUI.Turquoise:
                    return Question.Turquoise;
                case ColorUI.PinkLight:
                    return Question.PinkLight;
                case ColorUI.BlueSky:
                    return Question.BlueSky;
                case ColorUI.GrayLight:
                    return Question.GrayLight;
                case ColorUI.RedLight:
                    return Question.RedLight;
                case ColorUI.OrangeLight:
                    return Question.OrangeLight;
                case ColorUI.YellowDark:
                    return Question.YellowDark;
                case ColorUI.GreenDark:
                    return Question.GreenDark;
                case ColorUI.BlueDark:
                    return Question.BlueDark;
                case ColorUI.Aqua:
                    return Question.Aqua;
                case ColorUI.Tan:
                    return Question.Tan;
                case ColorUI.GreenDarkness:
                    return Question.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Question.BlueViolet;
                case ColorUI.Transparent:
                    return Question.White;
                default:
                    return Question.BlueSky;
            }
        }

        private string GetImageShare(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Share.Black;
                case ColorUI.Blue:
                    return Share.Blue;
                case ColorUI.Gray:
                    return Share.Gray;
                case ColorUI.Green:
                    return Share.Green;
                case ColorUI.Red:
                    return Share.Red;
                case ColorUI.Yellow:
                    return Share.Yellow;
                case ColorUI.BlueLight:
                    return Share.BlueLight;
                case ColorUI.GreenLight:
                    return Share.GreenLight;
                case ColorUI.YellowLight:
                    return Share.YellowLight;
                case ColorUI.White:
                    return Share.White;
                case ColorUI.Pink:
                    return Share.Pink;
                case ColorUI.Orange:
                    return Share.Orange;
                case ColorUI.Brown:
                    return Share.Brown;
                case ColorUI.Purple:
                    return Share.Purple;
                case ColorUI.Turquoise:
                    return Share.Turquoise;
                case ColorUI.PinkLight:
                    return Share.PinkLight;
                case ColorUI.BlueSky:
                    return Share.BlueSky;
                case ColorUI.GrayLight:
                    return Share.GrayLight;
                case ColorUI.RedLight:
                    return Share.RedLight;
                case ColorUI.OrangeLight:
                    return Share.OrangeLight;
                case ColorUI.YellowDark:
                    return Share.YellowDark;
                case ColorUI.GreenDark:
                    return Share.GreenDark;
                case ColorUI.BlueDark:
                    return Share.BlueDark;
                case ColorUI.Aqua:
                    return Share.Aqua;
                case ColorUI.Tan:
                    return Share.Tan;
                case ColorUI.GreenDarkness:
                    return Share.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Share.BlueViolet;
                case ColorUI.Transparent:
                    return Share.White;
                default:
                    return Share.BlueSky;
            }
        }

        private string GetImageSubtraction(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Subtraction.Black;
                case ColorUI.Blue:
                    return Subtraction.Blue;
                case ColorUI.Gray:
                    return Subtraction.Gray;
                case ColorUI.Green:
                    return Subtraction.Green;
                case ColorUI.Red:
                    return Subtraction.Red;
                case ColorUI.Yellow:
                    return Subtraction.Yellow;
                case ColorUI.BlueLight:
                    return Subtraction.BlueLight;
                case ColorUI.GreenLight:
                    return Subtraction.GreenLight;
                case ColorUI.YellowLight:
                    return Subtraction.YellowLight;
                case ColorUI.White:
                    return Subtraction.White;
                case ColorUI.Pink:
                    return Subtraction.Pink;
                case ColorUI.Orange:
                    return Subtraction.Orange;
                case ColorUI.Brown:
                    return Subtraction.Brown;
                case ColorUI.Purple:
                    return Subtraction.Purple;
                case ColorUI.Turquoise:
                    return Subtraction.Turquoise;
                case ColorUI.PinkLight:
                    return Subtraction.PinkLight;
                case ColorUI.BlueSky:
                    return Subtraction.BlueSky;
                case ColorUI.GrayLight:
                    return Subtraction.GrayLight;
                case ColorUI.RedLight:
                    return Subtraction.RedLight;
                case ColorUI.OrangeLight:
                    return Subtraction.OrangeLight;
                case ColorUI.YellowDark:
                    return Subtraction.YellowDark;
                case ColorUI.GreenDark:
                    return Subtraction.GreenDark;
                case ColorUI.BlueDark:
                    return Subtraction.BlueDark;
                case ColorUI.Aqua:
                    return Subtraction.Aqua;
                case ColorUI.Tan:
                    return Subtraction.Tan;
                case ColorUI.GreenDarkness:
                    return Subtraction.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Subtraction.BlueViolet;
                case ColorUI.Transparent:
                    return Subtraction.White;
                default:
                    return Subtraction.BlueSky;
            }
        }

        private string GetImageCopy(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Copy.Black;
                case ColorUI.Blue:
                    return Copy.Blue;
                case ColorUI.Gray:
                    return Copy.Gray;
                case ColorUI.Green:
                    return Copy.Green;
                case ColorUI.Red:
                    return Copy.Red;
                case ColorUI.Yellow:
                    return Copy.Yellow;
                case ColorUI.BlueLight:
                    return Copy.BlueLight;
                case ColorUI.GreenLight:
                    return Copy.GreenLight;
                case ColorUI.YellowLight:
                    return Copy.YellowLight;
                case ColorUI.White:
                    return Copy.White;
                case ColorUI.Pink:
                    return Copy.Pink;
                case ColorUI.Orange:
                    return Copy.Orange;
                case ColorUI.Brown:
                    return Copy.Brown;
                case ColorUI.Purple:
                    return Copy.Purple;
                case ColorUI.Turquoise:
                    return Copy.Turquoise;
                case ColorUI.PinkLight:
                    return Copy.PinkLight;
                case ColorUI.BlueSky:
                    return Copy.BlueSky;
                case ColorUI.GrayLight:
                    return Copy.GrayLight;
                case ColorUI.RedLight:
                    return Copy.RedLight;
                case ColorUI.OrangeLight:
                    return Copy.OrangeLight;
                case ColorUI.YellowDark:
                    return Copy.YellowDark;
                case ColorUI.GreenDark:
                    return Copy.GreenDark;
                case ColorUI.BlueDark:
                    return Copy.BlueDark;
                case ColorUI.Aqua:
                    return Copy.Aqua;
                case ColorUI.Tan:
                    return Copy.Tan;
                case ColorUI.GreenDarkness:
                    return Copy.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Copy.BlueViolet;
                case ColorUI.Transparent:
                    return Copy.White;
                default:
                    return Copy.BlueSky;
            }
        }

        private string GetImageEdit(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Edit.Black;
                case ColorUI.Blue:
                    return Edit.Blue;
                case ColorUI.Gray:
                    return Edit.Gray;
                case ColorUI.Green:
                    return Edit.Green;
                case ColorUI.Red:
                    return Edit.Red;
                case ColorUI.Yellow:
                    return Edit.Yellow;
                case ColorUI.BlueLight:
                    return Edit.BlueLight;
                case ColorUI.GreenLight:
                    return Edit.GreenLight;
                case ColorUI.YellowLight:
                    return Edit.YellowLight;
                case ColorUI.White:
                    return Edit.White;
                case ColorUI.Pink:
                    return Edit.Pink;
                case ColorUI.Orange:
                    return Edit.Orange;
                case ColorUI.Brown:
                    return Edit.Brown;
                case ColorUI.Purple:
                    return Edit.Purple;
                case ColorUI.Turquoise:
                    return Edit.Turquoise;
                case ColorUI.PinkLight:
                    return Edit.PinkLight;
                case ColorUI.BlueSky:
                    return Edit.BlueSky;
                case ColorUI.GrayLight:
                    return Edit.GrayLight;
                case ColorUI.RedLight:
                    return Edit.RedLight;
                case ColorUI.OrangeLight:
                    return Edit.OrangeLight;
                case ColorUI.YellowDark:
                    return Edit.YellowDark;
                case ColorUI.GreenDark:
                    return Edit.GreenDark;
                case ColorUI.BlueDark:
                    return Edit.BlueDark;
                case ColorUI.Aqua:
                    return Edit.Aqua;
                case ColorUI.Tan:
                    return Edit.Tan;
                case ColorUI.GreenDarkness:
                    return Edit.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Edit.BlueViolet;
                case ColorUI.Transparent:
                    return Edit.White;
                default:
                    return Edit.BlueSky;
            }
        }

        private string GetImagePaste(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Paste.Black;
                case ColorUI.Blue:
                    return Paste.Blue;
                case ColorUI.Gray:
                    return Paste.Gray;
                case ColorUI.Green:
                    return Paste.Green;
                case ColorUI.Red:
                    return Paste.Red;
                case ColorUI.Yellow:
                    return Paste.Yellow;
                case ColorUI.BlueLight:
                    return Paste.BlueLight;
                case ColorUI.GreenLight:
                    return Paste.GreenLight;
                case ColorUI.YellowLight:
                    return Paste.YellowLight;
                case ColorUI.White:
                    return Paste.White;
                case ColorUI.Pink:
                    return Paste.Pink;
                case ColorUI.Orange:
                    return Paste.Orange;
                case ColorUI.Brown:
                    return Paste.Brown;
                case ColorUI.Purple:
                    return Paste.Purple;
                case ColorUI.Turquoise:
                    return Paste.Turquoise;
                case ColorUI.PinkLight:
                    return Paste.PinkLight;
                case ColorUI.BlueSky:
                    return Paste.BlueSky;
                case ColorUI.GrayLight:
                    return Paste.GrayLight;
                case ColorUI.RedLight:
                    return Paste.RedLight;
                case ColorUI.OrangeLight:
                    return Paste.OrangeLight;
                case ColorUI.YellowDark:
                    return Paste.YellowDark;
                case ColorUI.GreenDark:
                    return Paste.GreenDark;
                case ColorUI.BlueDark:
                    return Paste.BlueDark;
                case ColorUI.Aqua:
                    return Paste.Aqua;
                case ColorUI.Tan:
                    return Paste.Tan;
                case ColorUI.GreenDarkness:
                    return Paste.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Paste.BlueViolet;
                case ColorUI.Transparent:
                    return Paste.White;
                default:
                    return Paste.BlueSky;
            }
        }

        private string GetImagePencil(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Pencil.Black;
                case ColorUI.Blue:
                    return Pencil.Blue;
                case ColorUI.Gray:
                    return Pencil.Gray;
                case ColorUI.Green:
                    return Pencil.Green;
                case ColorUI.Red:
                    return Pencil.Red;
                case ColorUI.Yellow:
                    return Pencil.Yellow;
                case ColorUI.BlueLight:
                    return Pencil.BlueLight;
                case ColorUI.GreenLight:
                    return Pencil.GreenLight;
                case ColorUI.YellowLight:
                    return Pencil.YellowLight;
                case ColorUI.White:
                    return Pencil.White;
                case ColorUI.Pink:
                    return Pencil.Pink;
                case ColorUI.Orange:
                    return Pencil.Orange;
                case ColorUI.Brown:
                    return Pencil.Brown;
                case ColorUI.Purple:
                    return Pencil.Purple;
                case ColorUI.Turquoise:
                    return Pencil.Turquoise;
                case ColorUI.PinkLight:
                    return Pencil.PinkLight;
                case ColorUI.BlueSky:
                    return Pencil.BlueSky;
                case ColorUI.GrayLight:
                    return Pencil.GrayLight;
                case ColorUI.RedLight:
                    return Pencil.RedLight;
                case ColorUI.OrangeLight:
                    return Pencil.OrangeLight;
                case ColorUI.YellowDark:
                    return Pencil.YellowDark;
                case ColorUI.GreenDark:
                    return Pencil.GreenDark;
                case ColorUI.BlueDark:
                    return Pencil.BlueDark;
                case ColorUI.Aqua:
                    return Pencil.Aqua;
                case ColorUI.Tan:
                    return Pencil.Tan;
                case ColorUI.GreenDarkness:
                    return Pencil.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Pencil.BlueViolet;
                case ColorUI.Transparent:
                    return Pencil.White;
                default:
                    return Pencil.BlueSky;
            }
        }

        private string GetImagePlus(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Plus.Black;
                case ColorUI.Blue:
                    return Plus.Blue;
                case ColorUI.Gray:
                    return Plus.Gray;
                case ColorUI.Green:
                    return Plus.Green;
                case ColorUI.Red:
                    return Plus.Red;
                case ColorUI.Yellow:
                    return Plus.Yellow;
                case ColorUI.BlueLight:
                    return Plus.BlueLight;
                case ColorUI.GreenLight:
                    return Plus.GreenLight;
                case ColorUI.YellowLight:
                    return Plus.YellowLight;
                case ColorUI.White:
                    return Plus.White;
                case ColorUI.Pink:
                    return Plus.Pink;
                case ColorUI.Orange:
                    return Plus.Orange;
                case ColorUI.Brown:
                    return Plus.Brown;
                case ColorUI.Purple:
                    return Plus.Purple;
                case ColorUI.Turquoise:
                    return Plus.Turquoise;
                case ColorUI.PinkLight:
                    return Plus.PinkLight;
                case ColorUI.BlueSky:
                    return Plus.BlueSky;
                case ColorUI.GrayLight:
                    return Plus.GrayLight;
                case ColorUI.RedLight:
                    return Plus.RedLight;
                case ColorUI.OrangeLight:
                    return Plus.OrangeLight;
                case ColorUI.YellowDark:
                    return Plus.YellowDark;
                case ColorUI.GreenDark:
                    return Plus.GreenDark;
                case ColorUI.BlueDark:
                    return Plus.BlueDark;
                case ColorUI.Aqua:
                    return Plus.Aqua;
                case ColorUI.Tan:
                    return Plus.Tan;
                case ColorUI.GreenDarkness:
                    return Plus.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Plus.BlueViolet;
                case ColorUI.Transparent:
                    return Plus.White;
                default:
                    return Plus.BlueSky;
            }
        }

        private string GetImageSphere(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Sphere.Black;
                case ColorUI.Blue:
                    return Sphere.Blue;
                case ColorUI.Gray:
                    return Sphere.Gray;
                case ColorUI.Green:
                    return Sphere.Green;
                case ColorUI.Red:
                    return Sphere.Red;
                case ColorUI.Yellow:
                    return Sphere.Yellow;
                case ColorUI.BlueLight:
                    return Sphere.BlueLight;
                case ColorUI.GreenLight:
                    return Sphere.GreenLight;
                case ColorUI.YellowLight:
                    return Sphere.YellowLight;
                case ColorUI.White:
                    return Sphere.White;
                case ColorUI.Pink:
                    return Sphere.Pink;
                case ColorUI.Orange:
                    return Sphere.Orange;
                case ColorUI.Brown:
                    return Sphere.Brown;
                case ColorUI.Purple:
                    return Sphere.Purple;
                case ColorUI.Turquoise:
                    return Sphere.Turquoise;
                case ColorUI.PinkLight:
                    return Sphere.PinkLight;
                case ColorUI.BlueSky:
                    return Sphere.BlueSky;
                case ColorUI.GrayLight:
                    return Sphere.GrayLight;
                case ColorUI.RedLight:
                    return Sphere.RedLight;
                case ColorUI.OrangeLight:
                    return Sphere.OrangeLight;
                case ColorUI.YellowDark:
                    return Sphere.YellowDark;
                case ColorUI.GreenDark:
                    return Sphere.GreenDark;
                case ColorUI.BlueDark:
                    return Sphere.BlueDark;
                case ColorUI.Aqua:
                    return Sphere.Aqua;
                case ColorUI.Tan:
                    return Sphere.Tan;
                case ColorUI.GreenDarkness:
                    return Sphere.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Sphere.BlueViolet;
                case ColorUI.Transparent:
                    return Sphere.White;
                default:
                    return Sphere.BlueSky;
            }
        }

        private string GetImageStar(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Star.Black;
                case ColorUI.Blue:
                    return Star.Blue;
                case ColorUI.Gray:
                    return Star.Gray;
                case ColorUI.Green:
                    return Star.Green;
                case ColorUI.Red:
                    return Star.Red;
                case ColorUI.Yellow:
                    return Star.Yellow;
                case ColorUI.BlueLight:
                    return Star.BlueLight;
                case ColorUI.GreenLight:
                    return Star.GreenLight;
                case ColorUI.YellowLight:
                    return Star.YellowLight;
                case ColorUI.White:
                    return Star.White;
                case ColorUI.Pink:
                    return Star.Pink;
                case ColorUI.Orange:
                    return Star.Orange;
                case ColorUI.Brown:
                    return Star.Brown;
                case ColorUI.Purple:
                    return Star.Purple;
                case ColorUI.Turquoise:
                    return Star.Turquoise;
                case ColorUI.PinkLight:
                    return Star.PinkLight;
                case ColorUI.BlueSky:
                    return Star.BlueSky;
                case ColorUI.GrayLight:
                    return Star.GrayLight;
                case ColorUI.RedLight:
                    return Star.RedLight;
                case ColorUI.OrangeLight:
                    return Star.OrangeLight;
                case ColorUI.YellowDark:
                    return Star.YellowDark;
                case ColorUI.GreenDark:
                    return Star.GreenDark;
                case ColorUI.BlueDark:
                    return Star.BlueDark;
                case ColorUI.Aqua:
                    return Star.Aqua;
                case ColorUI.Tan:
                    return Star.Tan;
                case ColorUI.GreenDarkness:
                    return Star.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Star.BlueViolet;
                case ColorUI.Transparent:
                    return Star.White;
                default:
                    return Star.BlueSky;
            }
        }

        private string GetImageEye(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Eye.Black;
                case ColorUI.Blue:
                    return Eye.Blue;
                case ColorUI.Gray:
                    return Eye.Gray;
                case ColorUI.Green:
                    return Eye.Green;
                case ColorUI.Red:
                    return Eye.Red;
                case ColorUI.Yellow:
                    return Eye.Yellow;
                case ColorUI.BlueLight:
                    return Eye.BlueLight;
                case ColorUI.GreenLight:
                    return Eye.GreenLight;
                case ColorUI.YellowLight:
                    return Eye.YellowLight;
                case ColorUI.White:
                    return Eye.White;
                case ColorUI.Pink:
                    return Eye.Pink;
                case ColorUI.Orange:
                    return Eye.Orange;
                case ColorUI.Brown:
                    return Eye.Brown;
                case ColorUI.Purple:
                    return Eye.Purple;
                case ColorUI.Turquoise:
                    return Eye.Turquoise;
                case ColorUI.PinkLight:
                    return Eye.PinkLight;
                case ColorUI.BlueSky:
                    return Eye.BlueSky;
                case ColorUI.GrayLight:
                    return Eye.GrayLight;
                case ColorUI.RedLight:
                    return Eye.RedLight;
                case ColorUI.OrangeLight:
                    return Eye.OrangeLight;
                case ColorUI.YellowDark:
                    return Eye.YellowDark;
                case ColorUI.GreenDark:
                    return Eye.GreenDark;
                case ColorUI.BlueDark:
                    return Eye.BlueDark;
                case ColorUI.Aqua:
                    return Eye.Aqua;
                case ColorUI.Tan:
                    return Eye.Tan;
                case ColorUI.GreenDarkness:
                    return Eye.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Eye.BlueViolet;
                case ColorUI.Transparent:
                    return Eye.White;
                default:
                    return Eye.BlueSky;
            }
        }

        private string GetImageBox(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Box.Black;
                case ColorUI.Blue:
                    return Box.Blue;
                case ColorUI.Gray:
                    return Box.Gray;
                case ColorUI.Green:
                    return Box.Green;
                case ColorUI.Red:
                    return Box.Red;
                case ColorUI.Yellow:
                    return Box.Yellow;
                case ColorUI.BlueLight:
                    return Box.BlueLight;
                case ColorUI.GreenLight:
                    return Box.GreenLight;
                case ColorUI.YellowLight:
                    return Box.YellowLight;
                case ColorUI.White:
                    return Box.White;
                case ColorUI.Pink:
                    return Box.Pink;
                case ColorUI.Orange:
                    return Box.Orange;
                case ColorUI.Brown:
                    return Box.Brown;
                case ColorUI.Purple:
                    return Box.Purple;
                case ColorUI.Turquoise:
                    return Box.Turquoise;
                case ColorUI.PinkLight:
                    return Box.PinkLight;
                case ColorUI.BlueSky:
                    return Box.BlueSky;
                case ColorUI.GrayLight:
                    return Box.GrayLight;
                case ColorUI.RedLight:
                    return Box.RedLight;
                case ColorUI.OrangeLight:
                    return Box.OrangeLight;
                case ColorUI.YellowDark:
                    return Box.YellowDark;
                case ColorUI.GreenDark:
                    return Box.GreenDark;
                case ColorUI.BlueDark:
                    return Box.BlueDark;
                case ColorUI.Aqua:
                    return Box.Aqua;
                case ColorUI.Tan:
                    return Box.Tan;
                case ColorUI.GreenDarkness:
                    return Box.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Box.BlueViolet;
                case ColorUI.Transparent:
                    return Box.White;
                default:
                    return Box.BlueSky;
            }
        }

        private string GetImageSearchLeft(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return SearchLeft.Black;
                case ColorUI.Blue:
                    return SearchLeft.Blue;
                case ColorUI.Gray:
                    return SearchLeft.Gray;
                case ColorUI.Green:
                    return SearchLeft.Green;
                case ColorUI.Red:
                    return SearchLeft.Red;
                case ColorUI.Yellow:
                    return SearchLeft.Yellow;
                case ColorUI.BlueLight:
                    return SearchLeft.BlueLight;
                case ColorUI.GreenLight:
                    return SearchLeft.GreenLight;
                case ColorUI.YellowLight:
                    return SearchLeft.YellowLight;
                case ColorUI.White:
                    return SearchLeft.White;
                case ColorUI.Pink:
                    return SearchLeft.Pink;
                case ColorUI.Orange:
                    return SearchLeft.Orange;
                case ColorUI.Brown:
                    return SearchLeft.Brown;
                case ColorUI.Purple:
                    return SearchLeft.Purple;
                case ColorUI.Turquoise:
                    return SearchLeft.Turquoise;
                case ColorUI.PinkLight:
                    return SearchLeft.PinkLight;
                case ColorUI.BlueSky:
                    return SearchLeft.BlueSky;
                case ColorUI.GrayLight:
                    return SearchLeft.GrayLight;
                case ColorUI.RedLight:
                    return SearchLeft.RedLight;
                case ColorUI.OrangeLight:
                    return SearchLeft.OrangeLight;
                case ColorUI.YellowDark:
                    return SearchLeft.YellowDark;
                case ColorUI.GreenDark:
                    return SearchLeft.GreenDark;
                case ColorUI.BlueDark:
                    return SearchLeft.BlueDark;
                case ColorUI.Aqua:
                    return SearchLeft.Aqua;
                case ColorUI.Tan:
                    return SearchLeft.Tan;
                case ColorUI.GreenDarkness:
                    return SearchLeft.GreenDarkness;
                case ColorUI.BlueViolet:
                    return SearchLeft.BlueViolet;
                case ColorUI.Transparent:
                    return SearchLeft.White;
                default:
                    return SearchLeft.BlueSky;
            }
        }

        private string GetImageHeart(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Heart.Black;
                case ColorUI.Blue:
                    return Heart.Blue;
                case ColorUI.Gray:
                    return Heart.Gray;
                case ColorUI.Green:
                    return Heart.Green;
                case ColorUI.Red:
                    return Heart.Red;
                case ColorUI.Yellow:
                    return Heart.Yellow;
                case ColorUI.BlueLight:
                    return Heart.BlueLight;
                case ColorUI.GreenLight:
                    return Heart.GreenLight;
                case ColorUI.YellowLight:
                    return Heart.YellowLight;
                case ColorUI.White:
                    return Heart.White;
                case ColorUI.Pink:
                    return Heart.Pink;
                case ColorUI.Orange:
                    return Heart.Orange;
                case ColorUI.Brown:
                    return Heart.Brown;
                case ColorUI.Purple:
                    return Heart.Purple;
                case ColorUI.Turquoise:
                    return Heart.Turquoise;
                case ColorUI.PinkLight:
                    return Heart.PinkLight;
                case ColorUI.BlueSky:
                    return Heart.BlueSky;
                case ColorUI.GrayLight:
                    return Heart.GrayLight;
                case ColorUI.RedLight:
                    return Heart.RedLight;
                case ColorUI.OrangeLight:
                    return Heart.OrangeLight;
                case ColorUI.YellowDark:
                    return Heart.YellowDark;
                case ColorUI.GreenDark:
                    return Heart.GreenDark;
                case ColorUI.BlueDark:
                    return Heart.BlueDark;
                case ColorUI.Aqua:
                    return Heart.Aqua;
                case ColorUI.Tan:
                    return Heart.Tan;
                case ColorUI.GreenDarkness:
                    return Heart.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Heart.BlueViolet;
                case ColorUI.Transparent:
                    return Heart.White;
                default:
                    return Heart.BlueSky;
            }
        }

        private string GetImageFlag(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Flag.Black;
                case ColorUI.Blue:
                    return Flag.Blue;
                case ColorUI.Gray:
                    return Flag.Gray;
                case ColorUI.Green:
                    return Flag.Green;
                case ColorUI.Red:
                    return Flag.Red;
                case ColorUI.Yellow:
                    return Flag.Yellow;
                case ColorUI.BlueLight:
                    return Flag.BlueLight;
                case ColorUI.GreenLight:
                    return Flag.GreenLight;
                case ColorUI.YellowLight:
                    return Flag.YellowLight;
                case ColorUI.White:
                    return Flag.White;
                case ColorUI.Pink:
                    return Flag.Pink;
                case ColorUI.Orange:
                    return Flag.Orange;
                case ColorUI.Brown:
                    return Flag.Brown;
                case ColorUI.Purple:
                    return Flag.Purple;
                case ColorUI.Turquoise:
                    return Flag.Turquoise;
                case ColorUI.PinkLight:
                    return Flag.PinkLight;
                case ColorUI.BlueSky:
                    return Flag.BlueSky;
                case ColorUI.GrayLight:
                    return Flag.GrayLight;
                case ColorUI.RedLight:
                    return Flag.RedLight;
                case ColorUI.OrangeLight:
                    return Flag.OrangeLight;
                case ColorUI.YellowDark:
                    return Flag.YellowDark;
                case ColorUI.GreenDark:
                    return Flag.GreenDark;
                case ColorUI.BlueDark:
                    return Flag.BlueDark;
                case ColorUI.Aqua:
                    return Flag.Aqua;
                case ColorUI.Tan:
                    return Flag.Tan;
                case ColorUI.GreenDarkness:
                    return Flag.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Flag.BlueViolet;
                case ColorUI.Transparent:
                    return Flag.White;
                default:
                    return Flag.BlueSky;
            }
        }

        private string GetImageArrowLeft(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return ArrowLeft.Black;
                case ColorUI.Blue:
                    return ArrowLeft.Blue;
                case ColorUI.Gray:
                    return ArrowLeft.Gray;
                case ColorUI.Green:
                    return ArrowLeft.Green;
                case ColorUI.Red:
                    return ArrowLeft.Red;
                case ColorUI.Yellow:
                    return ArrowLeft.Yellow;
                case ColorUI.BlueLight:
                    return ArrowLeft.BlueLight;
                case ColorUI.GreenLight:
                    return ArrowLeft.GreenLight;
                case ColorUI.YellowLight:
                    return ArrowLeft.YellowLight;
                case ColorUI.White:
                    return ArrowLeft.White;
                case ColorUI.Pink:
                    return ArrowLeft.Pink;
                case ColorUI.Orange:
                    return ArrowLeft.Orange;
                case ColorUI.Brown:
                    return ArrowLeft.Brown;
                case ColorUI.Purple:
                    return ArrowLeft.Purple;
                case ColorUI.Turquoise:
                    return ArrowLeft.Turquoise;
                case ColorUI.PinkLight:
                    return ArrowLeft.PinkLight;
                case ColorUI.BlueSky:
                    return ArrowLeft.BlueSky;
                case ColorUI.GrayLight:
                    return ArrowLeft.GrayLight;
                case ColorUI.RedLight:
                    return ArrowLeft.RedLight;
                case ColorUI.OrangeLight:
                    return ArrowLeft.OrangeLight;
                case ColorUI.YellowDark:
                    return ArrowLeft.YellowDark;
                case ColorUI.GreenDark:
                    return ArrowLeft.GreenDark;
                case ColorUI.BlueDark:
                    return ArrowLeft.BlueDark;
                case ColorUI.Aqua:
                    return ArrowLeft.Aqua;
                case ColorUI.Tan:
                    return ArrowLeft.Tan;
                case ColorUI.GreenDarkness:
                    return ArrowLeft.GreenDarkness;
                case ColorUI.BlueViolet:
                    return ArrowLeft.BlueViolet;
                case ColorUI.Transparent:
                    return ArrowLeft.White;
                default:
                    return ArrowLeft.BlueSky;
            }
        }

        private string GetImageArrowRight(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return ArrowRight.Black;
                case ColorUI.Blue:
                    return ArrowRight.Blue;
                case ColorUI.Gray:
                    return ArrowRight.Gray;
                case ColorUI.Green:
                    return ArrowRight.Green;
                case ColorUI.Red:
                    return ArrowRight.Red;
                case ColorUI.Yellow:
                    return ArrowRight.Yellow;
                case ColorUI.BlueLight:
                    return ArrowRight.BlueLight;
                case ColorUI.GreenLight:
                    return ArrowRight.GreenLight;
                case ColorUI.YellowLight:
                    return ArrowRight.YellowLight;
                case ColorUI.White:
                    return ArrowRight.White;
                case ColorUI.Pink:
                    return ArrowRight.Pink;
                case ColorUI.Orange:
                    return ArrowRight.Orange;
                case ColorUI.Brown:
                    return ArrowRight.Brown;
                case ColorUI.Purple:
                    return ArrowRight.Purple;
                case ColorUI.Turquoise:
                    return ArrowRight.Turquoise;
                case ColorUI.PinkLight:
                    return ArrowRight.PinkLight;
                case ColorUI.BlueSky:
                    return ArrowRight.BlueSky;
                case ColorUI.GrayLight:
                    return ArrowRight.GrayLight;
                case ColorUI.RedLight:
                    return ArrowRight.RedLight;
                case ColorUI.OrangeLight:
                    return ArrowRight.OrangeLight;
                case ColorUI.YellowDark:
                    return ArrowRight.YellowDark;
                case ColorUI.GreenDark:
                    return ArrowRight.GreenDark;
                case ColorUI.BlueDark:
                    return ArrowRight.BlueDark;
                case ColorUI.Aqua:
                    return ArrowRight.Aqua;
                case ColorUI.Tan:
                    return ArrowRight.Tan;
                case ColorUI.GreenDarkness:
                    return ArrowRight.GreenDarkness;
                case ColorUI.BlueViolet:
                    return ArrowRight.BlueViolet;
                case ColorUI.Transparent:
                    return ArrowRight.White;
                default:
                    return ArrowRight.BlueSky;
            }
        }

        private string GetImageCut(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Cut.Black;
                case ColorUI.Blue:
                    return Cut.Blue;
                case ColorUI.Gray:
                    return Cut.Gray;
                case ColorUI.Green:
                    return Cut.Green;
                case ColorUI.Red:
                    return Cut.Red;
                case ColorUI.Yellow:
                    return Cut.Yellow;
                case ColorUI.BlueLight:
                    return Cut.BlueLight;
                case ColorUI.GreenLight:
                    return Cut.GreenLight;
                case ColorUI.YellowLight:
                    return Cut.YellowLight;
                case ColorUI.White:
                    return Cut.White;
                case ColorUI.Pink:
                    return Cut.Pink;
                case ColorUI.Orange:
                    return Cut.Orange;
                case ColorUI.Brown:
                    return Cut.Brown;
                case ColorUI.Purple:
                    return Cut.Purple;
                case ColorUI.Turquoise:
                    return Cut.Turquoise;
                case ColorUI.PinkLight:
                    return Cut.PinkLight;
                case ColorUI.BlueSky:
                    return Cut.BlueSky;
                case ColorUI.GrayLight:
                    return Cut.GrayLight;
                case ColorUI.RedLight:
                    return Cut.RedLight;
                case ColorUI.OrangeLight:
                    return Cut.OrangeLight;
                case ColorUI.YellowDark:
                    return Cut.YellowDark;
                case ColorUI.GreenDark:
                    return Cut.GreenDark;
                case ColorUI.BlueDark:
                    return Cut.BlueDark;
                case ColorUI.Aqua:
                    return Cut.Aqua;
                case ColorUI.Tan:
                    return Cut.Tan;
                case ColorUI.GreenDarkness:
                    return Cut.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Cut.BlueViolet;
                case ColorUI.Transparent:
                    return Cut.White;
                default:
                    return Cut.Gray;
            }
        }

        private string GetImageArrowDown(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return ArrowDown.Black;
                case ColorUI.Blue:
                    return ArrowDown.Blue;
                case ColorUI.Gray:
                    return ArrowDown.Gray;
                case ColorUI.Green:
                    return ArrowDown.Green;
                case ColorUI.Red:
                    return ArrowDown.Red;
                case ColorUI.Yellow:
                    return ArrowDown.Yellow;
                case ColorUI.BlueLight:
                    return ArrowDown.BlueLight;
                case ColorUI.GreenLight:
                    return ArrowDown.GreenLight;
                case ColorUI.YellowLight:
                    return ArrowDown.YellowLight;
                case ColorUI.White:
                    return ArrowDown.White;
                case ColorUI.Pink:
                    return ArrowDown.Pink;
                case ColorUI.Orange:
                    return ArrowDown.Orange;
                case ColorUI.Brown:
                    return ArrowDown.Brown;
                case ColorUI.Purple:
                    return ArrowDown.Purple;
                case ColorUI.Turquoise:
                    return ArrowDown.Turquoise;
                case ColorUI.PinkLight:
                    return ArrowDown.PinkLight;
                case ColorUI.BlueSky:
                    return ArrowDown.BlueSky;
                case ColorUI.GrayLight:
                    return ArrowDown.GrayLight;
                case ColorUI.RedLight:
                    return ArrowDown.RedLight;
                case ColorUI.OrangeLight:
                    return ArrowDown.OrangeLight;
                case ColorUI.YellowDark:
                    return ArrowDown.YellowDark;
                case ColorUI.GreenDark:
                    return ArrowDown.GreenDark;
                case ColorUI.BlueDark:
                    return ArrowDown.BlueDark;
                case ColorUI.Aqua:
                    return ArrowDown.Aqua;
                case ColorUI.Tan:
                    return ArrowDown.Tan;
                case ColorUI.GreenDarkness:
                    return ArrowDown.GreenDarkness;
                case ColorUI.BlueViolet:
                    return ArrowDown.BlueViolet;
                case ColorUI.Transparent:
                    return ArrowDown.White;
                default:
                    return ArrowDown.BlueSky;
            }
        }

        private string GetImageArrowUp(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return ArrowUp.Black;
                case ColorUI.Blue:
                    return ArrowUp.Blue;
                case ColorUI.Gray:
                    return ArrowUp.Gray;
                case ColorUI.Green:
                    return ArrowUp.Green;
                case ColorUI.Red:
                    return ArrowUp.Red;
                case ColorUI.Yellow:
                    return ArrowUp.Yellow;
                case ColorUI.BlueLight:
                    return ArrowUp.BlueLight;
                case ColorUI.GreenLight:
                    return ArrowUp.GreenLight;
                case ColorUI.YellowLight:
                    return ArrowUp.YellowLight;
                case ColorUI.White:
                    return ArrowUp.White;
                case ColorUI.Pink:
                    return ArrowUp.Pink;
                case ColorUI.Orange:
                    return ArrowUp.Orange;
                case ColorUI.Brown:
                    return ArrowUp.Brown;
                case ColorUI.Purple:
                    return ArrowUp.Purple;
                case ColorUI.Turquoise:
                    return ArrowUp.Turquoise;
                case ColorUI.PinkLight:
                    return ArrowUp.PinkLight;
                case ColorUI.BlueSky:
                    return ArrowUp.BlueSky;
                case ColorUI.GrayLight:
                    return ArrowUp.GrayLight;
                case ColorUI.RedLight:
                    return ArrowUp.RedLight;
                case ColorUI.OrangeLight:
                    return ArrowUp.OrangeLight;
                case ColorUI.YellowDark:
                    return ArrowUp.YellowDark;
                case ColorUI.GreenDark:
                    return ArrowUp.GreenDark;
                case ColorUI.BlueDark:
                    return ArrowUp.BlueDark;
                case ColorUI.Aqua:
                    return ArrowUp.Aqua;
                case ColorUI.Tan:
                    return ArrowUp.Tan;
                case ColorUI.GreenDarkness:
                    return ArrowUp.GreenDarkness;
                case ColorUI.BlueViolet:
                    return ArrowUp.BlueViolet;
                case ColorUI.Transparent:
                    return ArrowUp.White;
                default:
                    return ArrowUp.BlueSky;
            }
        }

        private string GetImageKeyboard(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return IconKeyboard.Black;
                case ColorUI.Blue:
                    return IconKeyboard.Blue;
                case ColorUI.Gray:
                    return IconKeyboard.Gray;
                case ColorUI.Green:
                    return IconKeyboard.Green;
                case ColorUI.Red:
                    return IconKeyboard.Red;
                case ColorUI.Yellow:
                    return IconKeyboard.Yellow;
                case ColorUI.BlueLight:
                    return IconKeyboard.BlueLight;
                case ColorUI.GreenLight:
                    return IconKeyboard.GreenLight;
                case ColorUI.YellowLight:
                    return IconKeyboard.YellowLight;
                case ColorUI.White:
                    return IconKeyboard.White;
                case ColorUI.Pink:
                    return IconKeyboard.Pink;
                case ColorUI.Orange:
                    return IconKeyboard.Orange;
                case ColorUI.Brown:
                    return IconKeyboard.Brown;
                case ColorUI.Purple:
                    return IconKeyboard.Purple;
                case ColorUI.Turquoise:
                    return IconKeyboard.Turquoise;
                case ColorUI.PinkLight:
                    return IconKeyboard.PinkLight;
                case ColorUI.BlueSky:
                    return IconKeyboard.BlueSky;
                case ColorUI.GrayLight:
                    return IconKeyboard.GrayLight;
                case ColorUI.RedLight:
                    return IconKeyboard.RedLight;
                case ColorUI.OrangeLight:
                    return IconKeyboard.OrangeLight;
                case ColorUI.YellowDark:
                    return IconKeyboard.YellowDark;
                case ColorUI.GreenDark:
                    return IconKeyboard.GreenDark;
                case ColorUI.BlueDark:
                    return IconKeyboard.BlueDark;
                case ColorUI.Aqua:
                    return IconKeyboard.Aqua;
                case ColorUI.Tan:
                    return IconKeyboard.Tan;
                case ColorUI.GreenDarkness:
                    return IconKeyboard.GreenDarkness;
                case ColorUI.BlueViolet:
                    return IconKeyboard.BlueViolet;
                case ColorUI.Transparent:
                    return IconKeyboard.White;
                default:
                    return IconKeyboard.BlueSky;
            }
        }

        private string GetImagePerson(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Person.Black;
                case ColorUI.Blue:
                    return Person.Blue;
                case ColorUI.Gray:
                    return Person.Gray;
                case ColorUI.Green:
                    return Person.Green;
                case ColorUI.Red:
                    return Person.Red;
                case ColorUI.Yellow:
                    return Person.Yellow;
                case ColorUI.BlueLight:
                    return Person.BlueLight;
                case ColorUI.GreenLight:
                    return Person.GreenLight;
                case ColorUI.YellowLight:
                    return Person.YellowLight;
                case ColorUI.White:
                    return Person.White;
                case ColorUI.Pink:
                    return Person.Pink;
                case ColorUI.Orange:
                    return Person.Orange;
                case ColorUI.Brown:
                    return Person.Brown;
                case ColorUI.Purple:
                    return Person.Purple;
                case ColorUI.Turquoise:
                    return Person.Turquoise;
                case ColorUI.PinkLight:
                    return Person.PinkLight;
                case ColorUI.BlueSky:
                    return Person.BlueSky;
                case ColorUI.GrayLight:
                    return Person.GrayLight;
                case ColorUI.RedLight:
                    return Person.RedLight;
                case ColorUI.OrangeLight:
                    return Person.OrangeLight;
                case ColorUI.YellowDark:
                    return Person.YellowDark;
                case ColorUI.GreenDark:
                    return Person.GreenDark;
                case ColorUI.BlueDark:
                    return Person.BlueDark;
                case ColorUI.Aqua:
                    return Person.Aqua;
                case ColorUI.Tan:
                    return Person.Tan;
                case ColorUI.GreenDarkness:
                    return Person.GreenDarkness;
                case ColorUI.BlueViolet:
                    return Person.BlueViolet;
                case ColorUI.Transparent:
                    return Person.White;
                default:
                    return Person.BlueSky;
            }
        }

        private string GetColor(IconType typeIcon, ColorUI color)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetImage" + typeIcon.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            object[] parametersInvoke = { color };

            var returnStringColor = (string)methodToInvoke.Invoke(this, parametersInvoke);
            return returnStringColor;
        }
    }
}
