using System;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Group
    {
        /// <summary>
        /// Class ExpanderControl
        /// </summary>
        public class ExpanderControl : Image
        {
            private ImageSource internalSource;
            private DesignType designType;
            private ColorUI colorUI;
            private StateExpander state;

            /// <summary>
            /// Constructor of ExpanderControl
            /// </summary>
            public ExpanderControl(string hash, DesignType design, ColorUI color, StateExpander state)
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Key in Invalid in Constructor");
                }

                designType = design;
                colorUI = color;
                this.state = state;

                Aspect = Aspect.Fill;

                byte[] imageBytes = Convert.FromBase64String(GetColor(designType, color, this.state));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }

            /// <summary>
            /// Change State
            /// </summary>
            public void ChangeState(string hash, StateExpander state)
            {
                this.state = state;
                byte[] imageBytes = Convert.FromBase64String(GetColor(designType, colorUI, this.state));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }

            /// <summary>
            /// Change Color
            /// </summary>
            public void ChangeColor(string hash, ColorUI color)
            {
                colorUI = color;
                byte[] imageBytes = Convert.FromBase64String(GetColor(designType, colorUI, state));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }

            /// <summary>
            /// Change DesignType
            /// </summary>
            public void ChangeDesignType(string hash, DesignType design)
            {
                designType = design;
                byte[] imageBytes = Convert.FromBase64String(GetColor(designType, colorUI, state));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }


            private string GetImageFilled(ColorUI color, StateExpander state)
            {         
                switch (color)
                {
                    case ColorUI.Black:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.BlackSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Black;
                        }
                    case ColorUI.Blue:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.BlueSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Blue;
                        }
                    case ColorUI.Gray:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.GraySelected;
                        }
                        else
                        {
                            return ExpanderFilled.Gray;
                        }
                    case ColorUI.Green:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.GreenSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Green;
                        }
                    case ColorUI.Red:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.RedSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Red;
                        }
                    case ColorUI.Yellow:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.YellowSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Yellow;
                        }
                    case ColorUI.BlueLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.BlueLightSelected;
                        }
                        else
                        {
                            return ExpanderFilled.BlueLight;
                        }
                    case ColorUI.GreenLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.GreenLightSelected;
                        }
                        else
                        {
                            return ExpanderFilled.GreenLight;
                        }
                    case ColorUI.YellowLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.YellowLightSelected;
                        }
                        else
                        {
                            return ExpanderFilled.YellowLight;
                        }
                    case ColorUI.White:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.WhiteSelected;
                        }
                        else
                        {
                            return ExpanderFilled.White;
                        }
                    case ColorUI.Pink:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.PinkSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Pink;
                        }
                    case ColorUI.Orange:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.OrangeSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Orange;
                        }
                    case ColorUI.Brown:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.BrownSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Brown;
                        }
                    case ColorUI.Purple:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.PurpleSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Purple;
                        }
                    case ColorUI.Turquoise:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.TurquoiseSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Turquoise;
                        }
                    case ColorUI.PinkLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.PinkLightSelected;
                        }
                        else
                        {
                            return ExpanderFilled.PinkLight;
                        }
                    case ColorUI.BlueSky:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderFilled.BlueSky;
                        }
                    case ColorUI.GrayLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.GrayLightSelected;
                        }
                        else
                        {
                            return ExpanderFilled.GrayLight;
                        }
                    case ColorUI.RedLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.RedLightSelected;
                        }
                        else
                        {
                            return ExpanderFilled.RedLight;
                        }
                    case ColorUI.OrangeLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.OrangeLightSelected;
                        }
                        else
                        {
                            return ExpanderFilled.OrangeLight;
                        }
                    case ColorUI.YellowDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.YellowDarkSelected;
                        }
                        else
                        {
                            return ExpanderFilled.YellowDark;
                        }
                    case ColorUI.BlueDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.BlueDarkSelected;
                        }
                        else
                        {
                            return ExpanderFilled.BlueDark;
                        }
                    case ColorUI.GreenDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.GreenDarkSelected;
                        }
                        else
                        {
                            return ExpanderFilled.GreenDark;
                        }
                    case ColorUI.Aqua:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.AquaSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Aqua;
                        }
                    case ColorUI.Tan:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.TanSelected;
                        }
                        else
                        {
                            return ExpanderFilled.Tan;
                        }
                    case ColorUI.GreenDarkness:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.GreenDarknessSelected;
                        }
                        else
                        {
                            return ExpanderFilled.GreenDarkness;
                        }
                    case ColorUI.BlueViolet:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.BlueVioletSelected;
                        }
                        else
                        {
                            return ExpanderFilled.BlueViolet;
                        }
                    case ColorUI.Transparent:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.White;
                        }
                        else
                        {
                            return ExpanderFilled.White;
                        }
                    default:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFilled.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderFilled.BlueSky;
                        }
                }
            }         

            private string GetImageFit(ColorUI color, StateExpander state)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.BlackSelected;
                        }
                        else
                        {
                            return ExpanderFit.Black;
                        }
                    case ColorUI.Blue:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.BlueSelected;
                        }
                        else
                        {
                            return ExpanderFit.Blue;
                        }
                    case ColorUI.Gray:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.GraySelected;
                        }
                        else
                        {
                            return ExpanderFit.Gray;
                        }
                    case ColorUI.Green:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.GreenSelected;
                        }
                        else
                        {
                            return ExpanderFit.Green;
                        }
                    case ColorUI.Red:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.RedSelected;
                        }
                        else
                        {
                            return ExpanderFit.Red;
                        }
                    case ColorUI.Yellow:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.YellowSelected;
                        }
                        else
                        {
                            return ExpanderFit.Yellow;
                        }
                    case ColorUI.BlueLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.BlueLightSelected;
                        }
                        else
                        {
                            return ExpanderFit.BlueLight;
                        }
                    case ColorUI.GreenLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.GreenLightSelected;
                        }
                        else
                        {
                            return ExpanderFit.GreenLight;
                        }
                    case ColorUI.YellowLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.YellowLightSelected;
                        }
                        else
                        {
                            return ExpanderFit.YellowLight;
                        }
                    case ColorUI.White:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.WhiteSelected;
                        }
                        else
                        {
                            return ExpanderFit.White;
                        }
                    case ColorUI.Pink:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.PinkSelected;
                        }
                        else
                        {
                            return ExpanderFit.Pink;
                        }
                    case ColorUI.Orange:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.OrangeSelected;
                        }
                        else
                        {
                            return ExpanderFit.Orange;
                        }
                    case ColorUI.Brown:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.BrownSelected;
                        }
                        else
                        {
                            return ExpanderFit.Brown;
                        }
                    case ColorUI.Purple:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.PurpleSelected;
                        }
                        else
                        {
                            return ExpanderFit.Purple;
                        }
                    case ColorUI.Turquoise:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.TurquoiseSelected;
                        }
                        else
                        {
                            return ExpanderFit.Turquoise;
                        }
                    case ColorUI.PinkLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.PinkLightSelected;
                        }
                        else
                        {
                            return ExpanderFit.PinkLight;
                        }
                    case ColorUI.BlueSky:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderFit.BlueSky;
                        }
                    case ColorUI.GrayLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.GrayLightSelected;
                        }
                        else
                        {
                            return ExpanderFit.GrayLight;
                        }
                    case ColorUI.RedLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.RedLightSelected;
                        }
                        else
                        {
                            return ExpanderFit.RedLight;
                        }
                    case ColorUI.OrangeLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.OrangeLightSelected;
                        }
                        else
                        {
                            return ExpanderFit.OrangeLight;
                        }
                    case ColorUI.YellowDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.YellowDarkSelected;
                        }
                        else
                        {
                            return ExpanderFit.YellowDark;
                        }
                    case ColorUI.BlueDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.BlueDarkSelected;
                        }
                        else
                        {
                            return ExpanderFit.BlueDark;
                        }
                    case ColorUI.GreenDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.GreenDarkSelected;
                        }
                        else
                        {
                            return ExpanderFit.GreenDark;
                        }
                    case ColorUI.Aqua:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.AquaSelected;
                        }
                        else
                        {
                            return ExpanderFit.Aqua;
                        }
                    case ColorUI.Tan:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.TanSelected;
                        }
                        else
                        {
                            return ExpanderFit.Tan;
                        }
                    case ColorUI.GreenDarkness:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.GreenDarknessSelected;
                        }
                        else
                        {
                            return ExpanderFit.GreenDarkness;
                        }
                    case ColorUI.BlueViolet:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.BlueVioletSelected;
                        }
                        else
                        {
                            return ExpanderFit.BlueViolet;
                        }
                    case ColorUI.Transparent:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.White;
                        }
                        else
                        {
                            return ExpanderFit.White;
                        }
                    default:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderFit.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderFit.BlueSky;
                        }
                }
            }

            private string GetImageAllonsy(ColorUI color, StateExpander state)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.BlackSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Black;
                        }
                    case ColorUI.Blue:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.BlueSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Blue;
                        }
                    case ColorUI.Gray:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.GraySelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Gray;
                        }
                    case ColorUI.Green:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.GreenSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Green;
                        }
                    case ColorUI.Red:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.RedSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Red;
                        }
                    case ColorUI.Yellow:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.YellowSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Yellow;
                        }
                    case ColorUI.BlueLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.BlueLightSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.BlueLight;
                        }
                    case ColorUI.GreenLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.GreenLightSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.GreenLight;
                        }
                    case ColorUI.YellowLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.YellowLightSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.YellowLight;
                        }
                    case ColorUI.White:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.WhiteSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.White;
                        }
                    case ColorUI.Pink:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.PinkSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Pink;
                        }
                    case ColorUI.Orange:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.OrangeSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Orange;
                        }
                    case ColorUI.Brown:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.BrownSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Brown;
                        }
                    case ColorUI.Purple:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.PurpleSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Purple;
                        }
                    case ColorUI.Turquoise:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.TurquoiseSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Turquoise;
                        }
                    case ColorUI.PinkLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.PinkLightSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.PinkLight;
                        }
                    case ColorUI.BlueSky:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.BlueSky;
                        }
                    case ColorUI.GrayLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.GrayLightSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.GrayLight;
                        }
                    case ColorUI.RedLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.RedLightSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.RedLight;
                        }
                    case ColorUI.OrangeLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.OrangeLightSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.OrangeLight;
                        }
                    case ColorUI.YellowDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.YellowDarkSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.YellowDark;
                        }
                    case ColorUI.BlueDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.BlueDarkSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.BlueDark;
                        }
                    case ColorUI.GreenDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.GreenDarkSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.GreenDark;
                        }
                    case ColorUI.Aqua:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.AquaSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Aqua;
                        }
                    case ColorUI.Tan:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.TanSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.Tan;
                        }
                    case ColorUI.GreenDarkness:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.GreenDarknessSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.GreenDarkness;
                        }
                    case ColorUI.BlueViolet:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.BlueVioletSelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.BlueViolet;
                        }
                    case ColorUI.Transparent:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.White;
                        }
                        else
                        {
                            return ExpanderAllonsy.White;
                        }
                    default:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderAllonsy.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderAllonsy.BlueSky;
                        }
                }
            }

            private string GetImageCadre(ColorUI color, StateExpander state)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.BlackSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Black;
                        }
                    case ColorUI.Blue:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.BlueSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Blue;
                        }
                    case ColorUI.Gray:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.GraySelected;
                        }
                        else
                        {
                            return ExpanderCadre.Gray;
                        }
                    case ColorUI.Green:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.GreenSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Green;
                        }
                    case ColorUI.Red:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.RedSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Red;
                        }
                    case ColorUI.Yellow:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.YellowSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Yellow;
                        }
                    case ColorUI.BlueLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.BlueLightSelected;
                        }
                        else
                        {
                            return ExpanderCadre.BlueLight;
                        }
                    case ColorUI.GreenLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.GreenLightSelected;
                        }
                        else
                        {
                            return ExpanderCadre.GreenLight;
                        }
                    case ColorUI.YellowLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.YellowLightSelected;
                        }
                        else
                        {
                            return ExpanderCadre.YellowLight;
                        }
                    case ColorUI.White:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.WhiteSelected;
                        }
                        else
                        {
                            return ExpanderCadre.White;
                        }
                    case ColorUI.Pink:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.PinkSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Pink;
                        }
                    case ColorUI.Orange:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.OrangeSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Orange;
                        }
                    case ColorUI.Brown:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.BrownSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Brown;
                        }
                    case ColorUI.Purple:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.PurpleSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Purple;
                        }
                    case ColorUI.Turquoise:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.TurquoiseSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Turquoise;
                        }
                    case ColorUI.PinkLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.PinkLightSelected;
                        }
                        else
                        {
                            return ExpanderCadre.PinkLight;
                        }
                    case ColorUI.BlueSky:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderCadre.BlueSky;
                        }
                    case ColorUI.GrayLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.GrayLightSelected;
                        }
                        else
                        {
                            return ExpanderCadre.GrayLight;
                        }
                    case ColorUI.RedLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.RedLightSelected;
                        }
                        else
                        {
                            return ExpanderCadre.RedLight;
                        }
                    case ColorUI.OrangeLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.OrangeLightSelected;
                        }
                        else
                        {
                            return ExpanderCadre.OrangeLight;
                        }
                    case ColorUI.YellowDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.YellowDarkSelected;
                        }
                        else
                        {
                            return ExpanderCadre.YellowDark;
                        }
                    case ColorUI.BlueDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.BlueDarkSelected;
                        }
                        else
                        {
                            return ExpanderCadre.BlueDark;
                        }
                    case ColorUI.GreenDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.GreenDarkSelected;
                        }
                        else
                        {
                            return ExpanderCadre.GreenDark;
                        }
                    case ColorUI.Aqua:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.AquaSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Aqua;
                        }
                    case ColorUI.Tan:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.TanSelected;
                        }
                        else
                        {
                            return ExpanderCadre.Tan;
                        }
                    case ColorUI.GreenDarkness:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.GreenDarknessSelected;
                        }
                        else
                        {
                            return ExpanderCadre.GreenDarkness;
                        }
                    case ColorUI.BlueViolet:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.BlueVioletSelected;
                        }
                        else
                        {
                            return ExpanderCadre.BlueViolet;
                        }
                    case ColorUI.Transparent:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.White;
                        }
                        else
                        {
                            return ExpanderCadre.White;
                        }
                    default:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderCadre.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderCadre.BlueSky;
                        }
                }
            }

            private string GetImageSmoke(ColorUI color, StateExpander state)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.BlackSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Black;
                        }
                    case ColorUI.Blue:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.BlueSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Blue;
                        }
                    case ColorUI.Gray:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.GraySelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Gray;
                        }
                    case ColorUI.Green:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.GreenSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Green;
                        }
                    case ColorUI.Red:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.RedSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Red;
                        }
                    case ColorUI.Yellow:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.YellowSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Yellow;
                        }
                    case ColorUI.BlueLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.BlueLightSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.BlueLight;
                        }
                    case ColorUI.GreenLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.GreenLightSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.GreenLight;
                        }
                    case ColorUI.YellowLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.YellowLightSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.YellowLight;
                        }
                    case ColorUI.White:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.WhiteSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.White;
                        }
                    case ColorUI.Pink:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.PinkSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Pink;
                        }
                    case ColorUI.Orange:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.OrangeSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Orange;
                        }
                    case ColorUI.Brown:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.BrownSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Brown;
                        }
                    case ColorUI.Purple:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.PurpleSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Purple;
                        }
                    case ColorUI.Turquoise:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.TurquoiseSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Turquoise;
                        }
                    case ColorUI.PinkLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.PinkLightSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.PinkLight;
                        }
                    case ColorUI.BlueSky:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderSmoke.BlueSky;
                        }
                    case ColorUI.GrayLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.GrayLightSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.GrayLight;
                        }
                    case ColorUI.RedLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.RedLightSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.RedLight;
                        }
                    case ColorUI.OrangeLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.OrangeLightSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.OrangeLight;
                        }
                    case ColorUI.YellowDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.YellowDarkSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.YellowDark;
                        }
                    case ColorUI.BlueDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.BlueDarkSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.BlueDark;
                        }
                    case ColorUI.GreenDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.GreenDarkSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.GreenDark;
                        }
                    case ColorUI.Aqua:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.AquaSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Aqua;
                        }
                    case ColorUI.Tan:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.TanSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.Tan;
                        }
                    case ColorUI.GreenDarkness:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.GreenDarknessSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.GreenDarkness;
                        }
                    case ColorUI.BlueViolet:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.BlueVioletSelected;
                        }
                        else
                        {
                            return ExpanderSmoke.BlueViolet;
                        }
                    case ColorUI.Transparent:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.White;
                        }
                        else
                        {
                            return ExpanderSmoke.White;
                        }
                    default:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderSmoke.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderSmoke.BlueSky;
                        }
                }
            }

            private string GetImageShinning(ColorUI color, StateExpander state)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.BlackSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Black;
                        }
                    case ColorUI.Blue:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.BlueSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Blue;
                        }
                    case ColorUI.Gray:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.GraySelected;
                        }
                        else
                        {
                            return ExpanderShinning.Gray;
                        }
                    case ColorUI.Green:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.GreenSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Green;
                        }
                    case ColorUI.Red:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.RedSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Red;
                        }
                    case ColorUI.Yellow:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.YellowSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Yellow;
                        }
                    case ColorUI.BlueLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.BlueLightSelected;
                        }
                        else
                        {
                            return ExpanderShinning.BlueLight;
                        }
                    case ColorUI.GreenLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.GreenLightSelected;
                        }
                        else
                        {
                            return ExpanderShinning.GreenLight;
                        }
                    case ColorUI.YellowLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.YellowLightSelected;
                        }
                        else
                        {
                            return ExpanderShinning.YellowLight;
                        }
                    case ColorUI.White:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.WhiteSelected;
                        }
                        else
                        {
                            return ExpanderShinning.White;
                        }
                    case ColorUI.Pink:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.PinkSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Pink;
                        }
                    case ColorUI.Orange:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.OrangeSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Orange;
                        }
                    case ColorUI.Brown:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.BrownSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Brown;
                        }
                    case ColorUI.Purple:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.PurpleSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Purple;
                        }
                    case ColorUI.Turquoise:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.TurquoiseSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Turquoise;
                        }
                    case ColorUI.PinkLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.PinkLightSelected;
                        }
                        else
                        {
                            return ExpanderShinning.PinkLight;
                        }
                    case ColorUI.BlueSky:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderShinning.BlueSky;
                        }
                    case ColorUI.GrayLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.GrayLightSelected;
                        }
                        else
                        {
                            return ExpanderShinning.GrayLight;
                        }
                    case ColorUI.RedLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.RedLightSelected;
                        }
                        else
                        {
                            return ExpanderShinning.RedLight;
                        }
                    case ColorUI.OrangeLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.OrangeLightSelected;
                        }
                        else
                        {
                            return ExpanderShinning.OrangeLight;
                        }
                    case ColorUI.YellowDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.YellowDarkSelected;
                        }
                        else
                        {
                            return ExpanderShinning.YellowDark;
                        }
                    case ColorUI.BlueDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.BlueDarkSelected;
                        }
                        else
                        {
                            return ExpanderShinning.BlueDark;
                        }
                    case ColorUI.GreenDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.GreenDarkSelected;
                        }
                        else
                        {
                            return ExpanderShinning.GreenDark;
                        }
                    case ColorUI.Aqua:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.AquaSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Aqua;
                        }
                    case ColorUI.Tan:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.TanSelected;
                        }
                        else
                        {
                            return ExpanderShinning.Tan;
                        }
                    case ColorUI.GreenDarkness:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.GreenDarknessSelected;
                        }
                        else
                        {
                            return ExpanderShinning.GreenDarkness;
                        }
                    case ColorUI.BlueViolet:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.BlueVioletSelected;
                        }
                        else
                        {
                            return ExpanderShinning.BlueViolet;
                        }
                    case ColorUI.Transparent:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.White;
                        }
                        else
                        {
                            return ExpanderShinning.White;
                        }
                    default:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderShinning.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderShinning.BlueSky;
                        }
                }
            }

            private string GetImageScratches(ColorUI color, StateExpander state)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.BlackSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Black;
                        }
                    case ColorUI.Blue:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.BlueSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Blue;
                        }
                    case ColorUI.Gray:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.GraySelected;
                        }
                        else
                        {
                            return ExpanderScratches.Gray;
                        }
                    case ColorUI.Green:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.GreenSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Green;
                        }
                    case ColorUI.Red:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.RedSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Red;
                        }
                    case ColorUI.Yellow:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.YellowSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Yellow;
                        }
                    case ColorUI.BlueLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.BlueLightSelected;
                        }
                        else
                        {
                            return ExpanderScratches.BlueLight;
                        }
                    case ColorUI.GreenLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.GreenLightSelected;
                        }
                        else
                        {
                            return ExpanderScratches.GreenLight;
                        }
                    case ColorUI.YellowLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.YellowLightSelected;
                        }
                        else
                        {
                            return ExpanderScratches.YellowLight;
                        }
                    case ColorUI.White:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.WhiteSelected;
                        }
                        else
                        {
                            return ExpanderScratches.White;
                        }
                    case ColorUI.Pink:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.PinkSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Pink;
                        }
                    case ColorUI.Orange:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.OrangeSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Orange;
                        }
                    case ColorUI.Brown:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.BrownSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Brown;
                        }
                    case ColorUI.Purple:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.PurpleSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Purple;
                        }
                    case ColorUI.Turquoise:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.TurquoiseSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Turquoise;
                        }
                    case ColorUI.PinkLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.PinkLightSelected;
                        }
                        else
                        {
                            return ExpanderScratches.PinkLight;
                        }
                    case ColorUI.BlueSky:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderScratches.BlueSky;
                        }
                    case ColorUI.GrayLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.GrayLightSelected;
                        }
                        else
                        {
                            return ExpanderScratches.GrayLight;
                        }
                    case ColorUI.RedLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.RedLightSelected;
                        }
                        else
                        {
                            return ExpanderScratches.RedLight;
                        }
                    case ColorUI.OrangeLight:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.OrangeLightSelected;
                        }
                        else
                        {
                            return ExpanderScratches.OrangeLight;
                        }
                    case ColorUI.YellowDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.YellowDarkSelected;
                        }
                        else
                        {
                            return ExpanderScratches.YellowDark;
                        }
                    case ColorUI.BlueDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.BlueDarkSelected;
                        }
                        else
                        {
                            return ExpanderScratches.BlueDark;
                        }
                    case ColorUI.GreenDark:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.GreenDarkSelected;
                        }
                        else
                        {
                            return ExpanderScratches.GreenDark;
                        }
                    case ColorUI.Aqua:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.AquaSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Aqua;
                        }
                    case ColorUI.Tan:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.TanSelected;
                        }
                        else
                        {
                            return ExpanderScratches.Tan;
                        }
                    case ColorUI.GreenDarkness:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.GreenDarknessSelected;
                        }
                        else
                        {
                            return ExpanderScratches.GreenDarkness;
                        }
                    case ColorUI.BlueViolet:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.BlueVioletSelected;
                        }
                        else
                        {
                            return ExpanderScratches.BlueViolet;
                        }
                    case ColorUI.Transparent:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.White;
                        }
                        else
                        {
                            return ExpanderScratches.White;
                        }
                    default:
                        if (state == StateExpander.Open)
                        {
                            return ExpanderScratches.BlueSkySelected;
                        }
                        else
                        {
                            return ExpanderScratches.BlueSky;
                        }
                }
            }

            private string GetColor(DesignType typeS, ColorUI color, StateExpander state)
            {
                MethodInfo methodToInvoke = this.GetType().GetMethod("GetImage" + typeS.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

                object[] parametersInvoke = { color, state };

                var returnStringColor = (string)methodToInvoke.Invoke(this, parametersInvoke);
                return returnStringColor;
            }
        }
    }
}
