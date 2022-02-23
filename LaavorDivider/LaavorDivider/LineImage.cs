using System;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorDivider
{
    /// <summary>
    /// Class LineImage
    /// </summary>
    public class LineImage : Image
    {
        private ImageSource internalSource;
        private ColorUI currentColor;
        private LineSize currentSize;

        /// <summary>
        /// Constructor of LineImage
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        /// <param name="size"></param>
        public LineImage(string hash, ColorUI color, LineSize size)
        {
            if (hash != "hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ")
            {
                throw new Exception("Key in Invalid in Constructor");
            }

            currentColor = color;
            currentSize = size;

            Aspect = Aspect.Fill;

            HorizontalOptions = LayoutOptions.Fill;

            //HorizontalOptions = LayoutOptions.Start;
            //VerticalOptions = LayoutOptions.Center;

            byte[] imageBytes = Convert.FromBase64String(GetLine(currentColor, currentSize));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Change Color Internal
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

            byte[] imageBytes = Convert.FromBase64String(GetLine(currentColor, currentSize));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Change Size Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="size"></param>
        public void ChangeSize(string hash, LineSize size)
        {
            if (hash != "hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ")
            {
                throw new Exception("Key in Invalid in ChangeColor");
            }

            currentSize = size;

            byte[] imageBytes = Convert.FromBase64String(GetLine(currentColor, currentSize));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        ///// <summary>
        ///// Change State Internal
        ///// </summary>
        ///// <param name="hash"></param>
        ///// <param name="designType"></param>
        //public void ChangeDesignType(string hash, DesignType designType)
        //{
        //    if (hash != "hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ")
        //    {
        //        throw new Exception("Key in Invalid in ChangeColor");
        //    }

        //    currentDesignType = designType;

        //    byte[] imageBytes = Convert.FromBase64String(GetColor(designType, currentColor, IsChecked));
        //    var streamImage = new System.IO.MemoryStream(imageBytes);

        //    this.internalSource = ImageSource.FromStream(() => streamImage);
        //    Source = internalSource;
        //}

        private string GetLineSizeOne(ColorUI color)
        {
            string Black = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY2RgYPjPMApGwSgYBcMAMA20A0bBKBgFo4BaAACxzwED6WWxlgAAAABJRU5ErkJggg==";
            string Blue = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY2Rg+P+fYRSMglEwCoYBYBpoB4yCUTAKRgG1AABHxgICL5aAlAAAAABJRU5ErkJggg==";
            string Gray = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY2xoaPjPMApGwSgYBcMAMA20A0bBKBgFo4BaAAAisAKDc/VsjwAAAABJRU5ErkJggg==";
            string Green = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY2xoaPjPMApGwSgYBcMAMA20A0bBKBgFo4BaAAAisAKDc/VsjwAAAABJRU5ErkJggg==";
            string Red = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY/zPwPCfYRSMglEwCoYBYBpoB4yCUTAKRgG1AABJxAICa4cpfgAAAABJRU5ErkJggg==";
            string Yellow = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY/z/n+E/wygYBaNgFAwDwDTQDhgFo2AUjAJqAQDgqwMB0L3iagAAAABJRU5ErkJggg==";
            string Orange = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY/yfxvCfYRSMglEwCoYBYBpoB4yCUTAKRgG1AAAfwAJoR6umeAAAAABJRU5ErkJggg==";
            string Pink = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY/zP8P8/wygYBaNgFAwDwDTQDhgFo2AUjAJqAQDfrAMBWXAsIwAAAABJRU5ErkJggg==";
            string White = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY/z///9/hlEwCkbBKBgGgGmgHTAKRsEoGAXUAgB2ogQApxVDQAAAAABJRU5ErkJggg==";
            string BlueLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY1x15v9/hlEwCkbBKBgGgGmgHTAKRsEoGAXUAgBZAgN4R+BDvgAAAABJRU5ErkJggg==";
            string YellowLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY/z/btV/hlEwCkbBKBgGgGmgHTAKRsEoGAXUAgCg+wOaW+AEngAAAABJRU5ErkJggg==";
            string GreenLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY2T4z/CfYRSMglEwCoYBYBpoB4yCUTAKRgG1AABIxQICim61pgAAAABJRU5ErkJggg==";
            string Brown = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY2wwZvjPMApGwSgYBcMAMA20A0bBKBgFo4BaAABtmAG23C8DNwAAAABJRU5ErkJggg==";
            string Purple = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY2xgaPjPMApGwSgYBcMAMA20A0bBKBgFo4BaAABSZQIDCQ/+YAAAAABJRU5ErkJggg==";
            string Turquoise = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY2RoaPjPMApGwSgYBcMAMA20A0bBKBgFo4BaAABR5QIDbqQ40gAAAABJRU5ErkJggg==";
            string PinkLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY/y/6sx/hlEwCkbBKBgGgGmgHTAKRsEoGAXUAgBZigN4P7IVcwAAAABJRU5ErkJggg==";
            string BlueSky = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJYwyd+f8/wygYBaNgFAwDwDTQDhgFo2AUjAJqAQA7YgLwCAdUYwAAAABJRU5ErkJggg==";
            string RedLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY/zf0PCfYRSMglEwCoYBYBpoB4yCUTAKRgG1AADpywMCqjn3FQAAAABJRU5ErkJggg==";
            string GrayLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJYzxz5sx/hlEwCkbBKBgGgGmgHTAKRsEoGAXUAgC1qANnHgmGzwAAAABJRU5ErkJggg==";
            string OrangeLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY/y/ueE/wygYBaNgFAwDwDTQDhgFo2AUjAJqAQDUyQM1opFskQAAAABJRU5ErkJggg==";
            string YellowDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY/x/huE/wygYBaNgFAwDwDTQDhgFo2AUjAJqAQD1rQLOy/1nmgAAAABJRU5ErkJggg==";
            string BlueDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY2RQCv3PMApGwSgYBcMAMA20A0bBKBgFo4BaAAArJQF60gFQYAAAAABJRU5ErkJggg==";
            string GreenDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY1QKZfjPMApGwSgYBcMAMA20A0bBKBgFo4BaAAArnAF69NeGvQAAAABJRU5ErkJggg==";
            string Aqua = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY2T4//8/wygYBaNgFAwDwDTQDhgFo2AUjAJqAQDerQMBuJmw+wAAAABJRU5ErkJggg==";
            string Tan = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY1wzd/J/hlEwCkbBKBgGgGmgHTAKRsEoGAXUAgCYdgLfRbIKsAAAAABJRU5ErkJggg==";
            string GreenDarkness = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY2RQYvjPMApGwSgYBcMAMA20A0bBKBgFo4BaAAD5HgEleLBM3wAAAABJRU5ErkJggg==";
            string BlueViolet = "iVBORw0KGgoAAAANSUhEUgAAATQAAAACCAYAAADW1SCbAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAjSURBVEiJY+zSfvSfYRSMglEwCoYBYBpoB4yCUTAKRgG1AAD/uAKaByzC6gAAAABJRU5ErkJggg==";

            switch (color)
            {
                case ColorUI.Black:
                    return Black;
                case ColorUI.Blue:
                    return Blue;
                case ColorUI.Gray:
                    return Gray;
                case ColorUI.Green:
                    return Green;
                case ColorUI.Red:
                    return Red;
                case ColorUI.Yellow:
                    return Yellow;
                case ColorUI.BlueLight:
                    return BlueLight;
                case ColorUI.GreenLight:
                    return GreenLight;
                case ColorUI.YellowLight:
                    return YellowLight;
                case ColorUI.White:
                    return White;
                case ColorUI.Pink:
                    return Pink;
                case ColorUI.Orange:
                    return Orange;
                case ColorUI.Brown:
                    return Brown;
                case ColorUI.Purple:
                    return Purple;
                case ColorUI.Turquoise:
                    return Turquoise;
                case ColorUI.PinkLight:
                    return PinkLight;
                case ColorUI.BlueSky:
                    return BlueSky;
                case ColorUI.GrayLight:
                    return GrayLight;
                case ColorUI.RedLight:
                    return RedLight;
                case ColorUI.OrangeLight:
                    return OrangeLight;
                case ColorUI.YellowDark:
                    return YellowDark;
                case ColorUI.GreenDark:
                    return GreenDark;
                case ColorUI.BlueDark:
                    return BlueDark;
                case ColorUI.Aqua:
                    return Aqua;
                case ColorUI.Tan:
                    return Tan;
                case ColorUI.GreenDarkness:
                    return GreenDarkness;
                case ColorUI.BlueViolet:
                    return BlueViolet;
                default:
                    return Gray;
            }
        }

        private string GetLineSizeTwo(ColorUI color)
        {
            string Black = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAsSURBVFiF7dTBCQAwDAMxp/vv3C4RKBhpgnvdJLkBKHB+BwBsMTSghqEBNR6OMQEHLQXYNgAAAABJRU5ErkJggg==";
            string Blue = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAsSURBVFiF7dTBCQAwDAMxt/vvnCxRKBhpgnvdSWYCUOD+DgB4xdCAGoYG1Fi9DQIG3LVyewAAAABJRU5ErkJggg==";
            string Gray = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA8SURBVFiF7dbBDQAgDMNAt5N38/JiApAqkG8Cv6JEVTWS9IGcDpCkWxKg25Mm6V17wxIgIkZjJOnE3rAFtIMIh0Pk4K0AAAAASUVORK5CYII=";
            string Green = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA5SURBVFiF7dbBCQAgDATBaOV2ro/YgUJQZiq413ItRswA+ECvHgBwSwbNRwNethuWQWuFQwBO7YYtmvcDh6CEfq8AAAAASUVORK5CYII=";
            string Red = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAsSURBVFiF7dTBCQAwDAMxt/vvnCxRKBhpgnvdmWQCUOD+DgB4xdCAGoYG1Fi/CwIGNUlycAAAAABJRU5ErkJggg==";
            string Yellow = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAsSURBVFiF7dTBCQAwDAOxtPvv7CxRKBhpgnvdSSYDUOD+DgB4xdCAGoYG1Fju5gMF5pFlwAAAAABJRU5ErkJggg==";
            string Orange = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAuSURBVFiF7dRBCQAwDATBpGLr30FiolA4ZhTsa3tuTQEEOL8DAF4xNCCGoQExFmvPAmxMBgzMAAAAAElFTkSuQmCC";
            string Pink = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAsSURBVFiF7dTBCQAwDAOxtPvv7CxRKBhpgnvdySQDUOD+DgB4xdCAGoYG1Fjt5wMFDZtLNgAAAABJRU5ErkJggg==";
            string White = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAsSURBVFiF7dTBCQAwDAOxtvvv7C4RCBhpgnvdTZIDUOBtBwBMMTSghqEBNT4d0QQEsMYAmAAAAABJRU5ErkJggg==";
            string BlueLight = "iVBORw0KGgoAAAANSUhEUgAAATcAAAAECAYAAADru3iFAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAIYgAACGIBxW6uDwAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAvSURBVFiF7dRBDQAgDARBwL+SaqmnooKQXGYU7Gt39cwCCHN+BwC8YG5AJHMDIl2IhgN8AtWePgAAAABJRU5ErkJggg==";
            string YellowLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAwSURBVFiF7dRBDQAgDARBwL+SiquFYoKE5DKjYF+7p2sWQIDzOwDgFUMDYhgaEOMCcWIDnp/hwZ4AAAAASUVORK5CYII=";
            string GreenLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAsSURBVFiF7dTBCQAwDAMxt/vvnCxRKBhpgnvdyWQCUOD+DgB4xdCAGoYG1Fi+DAIGN79cjQAAAABJRU5ErkJggg==";
            string Brown = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA7SURBVFiF7dbBDQAgDMNAtyuxIJvDqxOAVIF8E/gVJeZgIUkfyO4ASbolAS+apKfVhiVANIZI0qnasA1z2QO6X4oYfQAAAABJRU5ErkJggg==";
            string Purple = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA7SURBVFiF7dbBDQAgDMNAt5N38/JiApAqkG8Cv6JEUY0kfSCnAyTplgRoPGmS3rU3LAGCGI2RpBN7wxanvQYHcY8ZwwAAAABJRU5ErkJggg==";
            string Turquoise = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA7SURBVFiF7dbBCQAgDARBY+V2Hh/agUJQZiq413LRxsgG8IFePQDglhW0dNKAh+2GraBFVE4BOLMbNgGlPQYHbD9kQQAAAABJRU5ErkJggg==";
            string PinkLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAwSURBVFiF7dRBDQAgDARBwL+SaqmnYoKE5DKjYF+7p3oWQIDzOwDgFUMDYhgaEOMC4k8DfN5cJ/MAAAAASUVORK5CYII=";
            string BlueSky = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAECAYAAAAAjMOGAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAvSURBVFiF7dRBDQAgDARBwGPFVW0xQUJymVGwr93VMwsgwPkdAPCKoQExDA2IcQGlzAL0tUpALQAAAABJRU5ErkJggg==";
            string RedLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAFCAYAAADL0BAjAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAwSURBVFiF7dTBCQAwDMSwppNn83SJQuCQJvDLNd1zAALc7QCAXwwNiGFoQAxDA2I8nBEDCH3gjyAAAAAASUVORK5CYII=";
            string GrayLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAFCAYAAADL0BAjAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAxSURBVFiF7dRRCQAgFARBtX+066QlhAfHTIL92p3kLoACZzoA4BdDA2oYGlDD0IAaDxunA20iPMIeAAAAAElFTkSuQmCC";
            string OrangeLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAFCAYAAADL0BAjAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAySURBVFiF7dRBDQAgDARBQHk9VWAxQUJymVGwr93TNQsgwPkdAPCKoQExDA2IYWhAjAtoJQM7lpQXUwAAAABJRU5ErkJggg==";
            string YellowDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAFCAYAAADL0BAjAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAxSURBVFiF7dRBCQAwDATBpP6l1VNiolA4ZhTsa3tuTQEEOL8DAF4xNCCGoQExDA2IsbhqAtQiD+o1AAAAAElFTkSuQmCC";
            string BlueDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAFCAYAAADL0BAjAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAzSURBVFiF7dRBDQAgDATBgpR6qn8pYIKE5DKjYF+7qucUQID9OwDgFUMDYhgaEMPQgBgXu/oBgLS3bq4AAAAASUVORK5CYII=";
            string GreenDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAFCAYAAADL0BAjAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAzSURBVFiF7dRBDQAgDATBgpR6qn8pYIKE5DKjYF+7euoUQID9OwDgFUMDYhgaEMPQgBgXvHEBgLA+6JQAAAAASUVORK5CYII=";
            string Aqua = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAFCAYAAADL0BAjAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAwSURBVFiF7dTBCQAwDAOxtPvv7CxRKBhpgnvdmSQDUOD+DgB4xdCAGoYG1DA0oMYCgoADBxiZfIAAAAAASUVORK5CYII=";
            string Tan = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAFCAYAAADL0BAjAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA0SURBVFiF7dQxDQAgEARBwH/3NQ7wCCZIPrnMKNhq59l1B0CA1R0A8IuhATEMDYhhaECMB1DlAuX4SUP5AAAAAElFTkSuQmCC";
            string GreenDarkness = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAFCAYAAADL0BAjAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAxSURBVFiF7dRRCQAgFATB0yj276glhAfHTIL92pWTG4ACezoA4BdDA2oYGlDD0IAaD72IASsxzyFEAAAAAElFTkSuQmCC";
            string BlueViolet = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAFCAYAAADL0BAjAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAzSURBVFiF7dRRCQAgEAVBtc41NaZFtIRw8JhJsF87d507AAKs7gCAXwwNiGFoQAxDA2I80uwCoO4O5mQAAAAASUVORK5CYII=";

            switch (color)
            {
                case ColorUI.Black:
                    return Black;
                case ColorUI.Blue:
                    return Blue;
                case ColorUI.Gray:
                    return Gray;
                case ColorUI.Green:
                    return Green;
                case ColorUI.Red:
                    return Red;
                case ColorUI.Yellow:
                    return Yellow;
                case ColorUI.BlueLight:
                    return BlueLight;
                case ColorUI.GreenLight:
                    return GreenLight;
                case ColorUI.YellowLight:
                    return YellowLight;
                case ColorUI.White:
                    return White;
                case ColorUI.Pink:
                    return Pink;
                case ColorUI.Orange:
                    return Orange;
                case ColorUI.Brown:
                    return Brown;
                case ColorUI.Purple:
                    return Purple;
                case ColorUI.Turquoise:
                    return Turquoise;
                case ColorUI.PinkLight:
                    return PinkLight;
                case ColorUI.BlueSky:
                    return BlueSky;
                case ColorUI.GrayLight:
                    return GrayLight;
                case ColorUI.RedLight:
                    return RedLight;
                case ColorUI.OrangeLight:
                    return OrangeLight;
                case ColorUI.YellowDark:
                    return YellowDark;
                case ColorUI.GreenDark:
                    return GreenDark;
                case ColorUI.BlueDark:
                    return BlueDark;
                case ColorUI.Aqua:
                    return Aqua;
                case ColorUI.Tan:
                    return Tan;
                case ColorUI.GreenDarkness:
                    return GreenDarkness;
                case ColorUI.BlueViolet:
                    return BlueViolet;
                default:
                    return Gray;
            }
        }

        private string GetLineSizeThree(ColorUI color)
        {
            string Black = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA/SURBVGiB7dTBCQAgEMCw0/131iUEoSQT9NU1M2cAAvbvAIBXDA3IMDQgw9CADEMDMgwNyDA0IMPQgAxDAzIuCpYBE2iEZzQAAAAASUVORK5CYII=";
            string Blue = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA/SURBVGiB7dTBCQAgEMCw0/131iUEoSQT9NU1c84ABOzfAQCvGBqQYWhAhqEBGYYGZBgakGFoQIahARmGBmRcBD8CEvHbgTMAAAAASUVORK5CYII=";
            string Gray = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABBSURBVGiB7dTBCQAhEMDA8yrfzrUJQQgzFeSVNTP7Awj4XwcA3GJoQIahARmGBmQYGpBhaECGoQEZhgZkGBqQcQBKzgKTqx/9TgAAAABJRU5ErkJggg==";
            string Green = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABBSURBVGiB7dTBCQAhEMDA9Sq3c23iQAgzFeSVNXvOAAR8rwMA/mJoQIahARmGBmQYGpBhaECGoQEZhgZkGBqQcQEf/gGTX29aRQAAAABJRU5ErkJggg==";
            string Red = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA/SURBVGiB7dTBCQAgEMCw0/131iUEoSQT9NV1Zs4ABOzfAQCvGBqQYWhAhqEBGYYGZBgakGFoQIahARmGBmRcBj0CEmPBqZEAAAAASUVORK5CYII=";
            string Yellow = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA/SURBVGiB7dTBCQAgEMAwdf+dzyUEoSQT9NU9s2YBBJzfAQCvGBqQYWhAhqEBGYYGZBgakGFoQIahARmGBmRcAOUDEbZ5708AAAAASUVORK5CYII=";
            string Orange = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABBSURBVGiB7dRBCQAgAMBANaz9G2gJQRh3CfbaPHucARCwfgcAvGJoQIahARmGBmQYGpBhaECGoQEZhgZkGBqQcQE3SgJ4pdwiIQAAAABJRU5ErkJggg==";
            string Pink = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA/SURBVGiB7dTBCQAgEMAwdf+dzyUEoSQT9NU9a2YBBJzfAQCvGBqQYWhAhqEBGYYGZBgakGFoQIahARmGBmRc/9cDEW6FX88AAAAASUVORK5CYII=";
            string White = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA/SURBVGiB7dTBCQAgEMAwdf+dzyUEoSQT9NU9M7MAAs7vAIBXDA3IMDQgw9CADEMDMgwNyDA0IMPQgAxDAzIu+n8EEGeh6MkAAAAASUVORK5CYII=";
            string BlueLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABDSURBVGiB7dRBDcAgAMBAwL8StOAJTCxZ0twp6Ktzn3sHQMD6OwDgK4YGZBgakGFoQIahARmGBmQYGpBhaECGoQEZD2NzA4hNHPk2AAAAAElFTkSuQmCC";
            string YellowLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABDSURBVGiB7dRBDcAgAMBAwL8SxGEBTCxZ0twp6Kvznn0HQMD6OwDgK4YGZBgakGFoQIahARmGBmQYGpBhaECGoQEZD8nHA6ptBndpAAAAAElFTkSuQmCC";
            string GreenLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA/SURBVGiB7dTBCQAgEMCw0/131iUEoSQT9NU1Z84ABOzfAQCvGBqQYWhAhqEBGYYGZBgakGFoQIahARmGBmRcBT4CEmzDzEAAAAAASUVORK5CYII=";
            string Brown = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABCSURBVGiB7dRBDcAgAMBAmCUM4pyZICFp7hT01bnXOAMg4HsdAHCLoQEZhgZkGBqQYWhAhqEBGYYGZBgakGFoQMYPuP0BxjbleD8AAAAASUVORK5CYII=";
            string Purple = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA/SURBVGiB7dRBCQAgAMBANbnNtYQgjLsEe23usc8ACFi/AwBeMTQgw9CADEMDMgwNyDA0IMPQgAxDAzIMDci4NWYCE77RluAAAAAASUVORK5CYII=";
            string Turquoise = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA/SURBVGiB7dRBCQAgAMBANbnNtYQgjLsEe22Ovc8ACFi/AwBeMTQgw9CADEMDMgwNyDA0IMPQgAxDAzIMDci4NOYCE0j9vjQAAAAASUVORK5CYII=";
            string PinkLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABDSURBVGiB7dRBDcAgAMBAwL8StOAJTCxZ0twp6Kvz7nMHQMD6OwDgK4YGZBgakGFoQIahARmGBmQYGpBhaECGoQEZD2P7A4j2S0cpAAAAAElFTkSuQmCC";
            string BlueSky = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABCSURBVGiB7dRBDcAgAMBAwCPiUAsmlixp7hT01bnPvQMgYP0dAPAVQwMyDA3IMDQgw9CADEMDMgwNyDA0IMPQgIwHzFgDAG+0QzcAAAAASUVORK5CYII=";
            string RedLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAATCAYAAAAeX/GlAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABdSURBVHic7dRBCQAgAMBANbnNtYQgjLsEe22evc8ACFi/AwBeMTQgw9CADEMDMgwNyDA0IMPQgAxDAzIMDcgwNCDD0IAMQwMyDA3IMDQgw9CADEMDMgwNyDA0IOMCATIDJOeF7boAAAAASUVORK5CYII=";
            string GrayLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABCSURBVGiB7dRBCQAxEMDA6/mXtp5aE4VCmFGQV9bM7A8g4H8dAHCLoQEZhgZkGBqQYWhAhqEBGYYGZBgakGFoQMYBMPMDdylrkX4AAAAASUVORK5CYII=";
            string OrangeLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABCSURBVGiB7dRBDcAgAMBAQDmeEAgmlixp7hT01XnPvgMgYP0dAPAVQwMyDA3IMDQgw9CADEMDMgwNyDA0IMPQgIwHyQwDRaWz9dAAAAAASUVORK5CYII=";
            string YellowDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABBSURBVGiB7dRBCQAgAMBAtX80O2kJQRh3CfbaPHucARCwfgcAvGJoQIahARmGBmQYGpBhaECGoQEZhgZkGBqQcQFoVwLeZiYQFAAAAABJRU5ErkJggg==";
            string BlueDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABDSURBVGiB7dRBDcAgAMBAmBQ84V8KM0FC0twp6KtzrH0GQMD3OgDgFkMDMgwNyDA0IMPQgAxDAzIMDcgwNCDD0ICMH24jAYqnWsfqAAAAAElFTkSuQmCC";
            string GreenDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABDSURBVGiB7dRBDcAgAMBAmBQ84V8KM0FC0twp6Ktz7XEGQMD3OgDgFkMDMgwNyDA0IMPQgAxDAzIMDcgwNCDD0ICMH26aAYqfhbbVAAAAAElFTkSuQmCC";
            string Aqua = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAA/SURBVGiB7dTBCQAgEMAwdf+dzyUEoSQT9NW9ZmYBBJzfAQCvGBqQYWhAhqEBGYYGZBgakGFoQIahARmGBmRc/tgDEWLJ5fMAAAAASUVORK5CYII=";
            string Tan = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABESURBVGiB7dSxDcAgAMCw0v83Zj7gR/pEJaTIviBTxl7zPAAB7+0AgL8YGpBhaECGoQEZhgZkGBqQYWhAhqEBGYYGZHyaRgLvOswuUwAAAABJRU5ErkJggg==";
            string GreenDarkness = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABCSURBVGiB7dRBCQAxEMDA7Umpf4+tiYNCmFGQV9bsOQMQ8L0OAPiLoQEZhgZkGBqQYWhAhqEBGYYGZBgakGFoQMYFcEABNe1XLyUAAAAASUVORK5CYII=";
            string BlueViolet = "iVBORw0KGgoAAAANSUhEUgAAATQAAAAKCAYAAAA6hqL2AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABESURBVGiB7dRBDcAgAMDAMTs4RSZGmIklJM2dgr461tznAQh4bwcA/MXQgAxDAzIMDcgwNCDD0IAMQwMyDA3IMDQg4wOeSgKqv3N+XgAAAABJRU5ErkJggg==";

            switch (color)
            {
                case ColorUI.Black:
                    return Black;
                case ColorUI.Blue:
                    return Blue;
                case ColorUI.Gray:
                    return Gray;
                case ColorUI.Green:
                    return Green;
                case ColorUI.Red:
                    return Red;
                case ColorUI.Yellow:
                    return Yellow;
                case ColorUI.BlueLight:
                    return BlueLight;
                case ColorUI.GreenLight:
                    return GreenLight;
                case ColorUI.YellowLight:
                    return YellowLight;
                case ColorUI.White:
                    return White;
                case ColorUI.Pink:
                    return Pink;
                case ColorUI.Orange:
                    return Orange;
                case ColorUI.Brown:
                    return Brown;
                case ColorUI.Purple:
                    return Purple;
                case ColorUI.Turquoise:
                    return Turquoise;
                case ColorUI.PinkLight:
                    return PinkLight;
                case ColorUI.BlueSky:
                    return BlueSky;
                case ColorUI.GrayLight:
                    return GrayLight;
                case ColorUI.RedLight:
                    return RedLight;
                case ColorUI.OrangeLight:
                    return OrangeLight;
                case ColorUI.YellowDark:
                    return YellowDark;
                case ColorUI.GreenDark:
                    return GreenDark;
                case ColorUI.BlueDark:
                    return BlueDark;
                case ColorUI.Aqua:
                    return Aqua;
                case ColorUI.Tan:
                    return Tan;
                case ColorUI.GreenDarkness:
                    return GreenDarkness;
                case ColorUI.BlueViolet:
                    return BlueViolet;
                default:
                    return Gray;
            }
        }

        private string GetLineSizeFour(ColorUI color)
        {
            string Black = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABcSURBVHic7dRBDQAgEMCwA/+eQQUhWVoFe23NzBmAoP07AOAVgwOyDA7IMjggy+CALIMDsgwOyDI4IMvggCyDA7IMDsgyOCDL4IAsgwOyDA7IMjggy+CALIMDsi6WGgElixc+pgAAAABJRU5ErkJggg==";
            string Blue = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABcSURBVHic7dRBDQAgEMCwA/+eQQUhWVoFe23NnDMAQft3AMArBgdkGRyQZXBAlsEBWQYHZBkckGVwQJbBAVkGB2QZHJBlcECWwQFZBgdkGRyQZXBAlsEBWQYHZF3uzgIknphQCAAAAABJRU5ErkJggg==";
            string Gray = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABeSURBVHic7dTBDcAgEMCw0slvc5gCIUX2BHllzcz+AIL+1wEAtxgckGVwQJbBAVkGB2QZHJBlcECWwQFZBgdkGRyQZXBAlsEBWQYHZBkckGVwQJbBAVkGB2QZHJB1AKe/AqVQe3nbAAAAAElFTkSuQmCC";
            string Green = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABeSURBVHic7dTBDcAgEMCwo5OzOUxRIUX2BHllzZ4zAEHf6wCAvxgckGVwQJbBAVkGB2QZHJBlcECWwQFZBgdkGRyQZXBAlsEBWQYHZBkckGVwQJbBAVkGB2QZHJB1AfFMAaXC18O9AAAAAElFTkSuQmCC";
            string Red = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABcSURBVHic7dRBDQAgEMCwA/+eQQUhWVoFe22dmTMAQft3AMArBgdkGRyQZXBAlsEBWQYHZBkckGVwQJbBAVkGB2QZHJBlcECWwQFZBgdkGRyQZXBAlsEBWQYHZF3wzAIkuV3vrAAAAABJRU5ErkJggg==";
            string Yellow = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABcSURBVHic7dRBDQAgEMAwwL/nQwUhWVoFe23PrFkAQed3AMArBgdkGRyQZXBAlsEBWQYHZBkckGVwQJbBAVkGB2QZHJBlcECWwQFZBgdkGRyQZXBAlsEBWQYHZF1KjgMjzhLvvgAAAABJRU5ErkJggg==";
            string Orange = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABeSURBVHic7dRBCQAgAMBANaz9G2gKEcZdgr02zx5nAASt3wEArxgckGVwQJbBAVkGB2QZHJBlcECWwQFZBgdkGRyQZXBAlsEBWQYHZBkckGVwQJbBAVkGB2QZHJB1AeF9AopyUonoAAAAAElFTkSuQmCC";
            string Pink = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABcSURBVHic7dRBDQAgEMAwwL/nQwUhWVoFe23PmlkAQed3AMArBgdkGRyQZXBAlsEBWQYHZBkckGVwQJbBAVkGB2QZHJBlcECWwQFZBgdkGRyQZXBAlsEBWQYHZF1JjwMjCa8icgAAAABJRU5ErkJggg==";
            string White = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABcSURBVHic7dRBDQAgEMAwwL/nQwUhWVoFe23PzCyAoPM7AOAVgwOyDA7IMjggy+CALIMDsgwOyDI4IMvggCyDA7IMDsgyOCDL4IAsgwOyDA7IMjggy+CALIMDsi6jQgQi77B8LQAAAABJRU5ErkJggg==";
            string BlueLight = "iVBORw0KGgoAAAANSUhEUgAAATcAAAATCAYAAAD1aEqmAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABgSURBVHic7dRBDcAgAMBAwL8StOAJVCxLmjsFfXXuc+8AiFl/BwB8wdyAJHMDkswNSDI3IMncgCRzA5LMDUgyNyDJ3IAkcwOSzA1IMjcgydyAJHMDkswNSDI3IMncgKQHVZcDmm5UvMAAAAAASUVORK5CYII=";
            string YellowLight = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABgSURBVHic7dRBDcAgAMBAwL8SxGEBVCxLmjsFfXXes+8ACFp/BwB8xeCALIMDsgwOyDI4IMvggCyDA7IMDsgyOCDL4IAsgwOyDA7IMjggy+CALIMDsgwOyDI4IMvggKwHsuYDvGGvTSIAAAAASUVORK5CYII=";
            string GreenLight = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABcSURBVHic7dRBDQAgEMCwA/+eQQUhWVoFe23NmTMAQft3AMArBgdkGRyQZXBAlsEBWQYHZBkckGVwQJbBAVkGB2QZHJBlcECWwQFZBgdkGRyQZXBAlsEBWQYHZF3vzQIkE5AIOgAAAABJRU5ErkJggg==";
            string Brown = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABfSURBVHic7dRBDcAgAMBAmCUM4pypICTNnYK+OvcaZwAEfa8DAG4xOCDL4IAsgwOyDA7IMjggy+CALIMDsgwOyDI4IMvggCyDA7IMDsgyOCDL4IAsgwOyDA7IMjgg6wdqLAHYztmXBwAAAABJRU5ErkJggg==";
            string Purple = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABcSURBVHic7dRBCQAgAMBANbnNNYUI4y7BXpt77DMAgtbvAIBXDA7IMjggy+CALIMDsgwOyDI4IMvggCyDA7IMDsgyOCDL4IAsgwOyDA7IMjggy+CALIMDsgwOyLpMjQIldjY5PwAAAABJRU5ErkJggg==";
            string Turquoise = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABcSURBVHic7dRBCQAgAMBANbnNNYUI4y7BXptj7zMAgtbvAIBXDA7IMjggy+CALIMDsgwOyDI4IMvggCyDA7IMDsgyOCDL4IAsgwOyDA7IMjggy+CALIMDsgwOyLpMDQIlA+v8lgAAAABJRU5ErkJggg==";
            string PinkLight = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABgSURBVHic7dRBDcAgAMBAwL8StOAJVCxLmjsFfXXefe4ACFp/BwB8xeCALIMDsgwOyDI4IMvggCyDA7IMDsgyOCDL4IAsgwOyDA7IMjggy+CALIMDsgwOyDI4IMvggKwHYo4Dmnw+oxMAAAAASUVORK5CYII=";
            string BlueSky = "iVBORw0KGgoAAAANSUhEUgAAATgAAAATCAYAAAAEYxErAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABfSURBVHic7dRBDcAgAMBAwCPiUAsqliXNnYK+Ove5dwAErb8DAL5icECWwQFZBgdkGRyQZXBAlsEBWQYHZBkckGVwQJbBAVkGB2QZHJBlcECWwQFZBgdkGRyQZXBA1gMgygMSU8tspQAAAABJRU5ErkJggg==";
            string RedLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAATCAYAAAAeX/GlAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABdSURBVHic7dRBCQAgAMBANbnNtYQgjLsEe22evc8ACFi/AwBeMTQgw9CADEMDMgwNyDA0IMPQgAxDAzIMDcgwNCDD0IAMQwMyDA3IMDQgw9CADEMDMgwNyDA0IOMCATIDJOeF7boAAAAASUVORK5CYII=";
            string GrayLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAATCAYAAAAeX/GlAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABfSURBVHic7dRBCQAxEMDA6/mXtp5aE4VCmFGQV9bM7A8g4H8dAHCLoQEZhgZkGBqQYWhAhqEBGYYGZBgakGFoQIahARmGBmQYGpBhaECGoQEZhgZkGBqQYWhAhqEBGQcctAOJV+KWlQAAAABJRU5ErkJggg==";
            string OrangeLight = "iVBORw0KGgoAAAANSUhEUgAAATQAAAATCAYAAAAeX/GlAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABfSURBVHic7dRBDcAgAMBAQDmeEAgmlixp7hT01XnPvgMgYP0dAPAVQwMyDA3IMDQgw9CADEMDMgwNyDA0IMPQgAxDAzIMDcgwNCDD0IAMQwMyDA3IMDQgw9CADEMDMh488wNXEHYTYAAAAABJRU5ErkJggg==";
            string YellowDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAATCAYAAAAeX/GlAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABeSURBVHic7dRBCQAgAMBAtX80O2kJQRh3CfbaPHucARCwfgcAvGJoQIahARmGBmQYGpBhaECGoQEZhgZkGBqQYWhAhqEBGYYGZBgakGFoQIahARmGBmQYGpBhaEDGBWphAvAcH7CcAAAAAElFTkSuQmCC";
            string BlueDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAATCAYAAAAeX/GlAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABgSURBVHic7dRBDcAgAMBAmBQ84V8KM0FC0twp6KtzrH0GQMD3OgDgFkMDMgwNyDA0IMPQgAxDAzIMDcgwNCDD0IAMQwMyDA3IMDQgw9CADEMDMgwNyDA0IMPQgAxDAzJ+2pMBnMBMPLQAAAAASUVORK5CYII=";
            string GreenDark = "iVBORw0KGgoAAAANSUhEUgAAATQAAAATCAYAAAAeX/GlAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABgSURBVHic7dRBDcAgAMBAmBQ84V8KM0FC0twp6Ktz7XEGQMD3OgDgFkMDMgwNyDA0IMPQgAxDAzIMDcgwNCDD0IAMQwMyDA3IMDQgw9CADEMDMgwNyDA0IMPQgAxDAzJ+2woBnBp8vg0AAAAASUVORK5CYII=";
            string Aqua = "iVBORw0KGgoAAAANSUhEUgAAATQAAAATCAYAAAAeX/GlAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABdSURBVHic7dTBCQAgEMAwdf+dzyUEoSQT9NW9ZmYBBJzfAQCvGBqQYWhAhqEBGYYGZBgakGFoQIahARmGBmQYGpBhaECGoQEZhgZkGBqQYWhAhqEBGYYGZBgakHEBpCQDIxjK/3sAAAAASUVORK5CYII=";
            string Tan = "iVBORw0KGgoAAAANSUhEUgAAATQAAAATCAYAAAAeX/GlAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABiSURBVHic7dSxDcAgAMCw0v83Zj7gR/pEJaTIviBTxl7zPAAB7+0AgL8YGpBhaECGoQEZhgZkGBqQYWhAhqEBGYYGZBgakGFoQIahARmGBmQYGpBhaECGoQEZhgZkGBqQ8QF9ZgMBKBAR3wAAAABJRU5ErkJggg==";
            string GreenDarkness = "iVBORw0KGgoAAAANSUhEUgAAATQAAAATCAYAAAAeX/GlAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABfSURBVHic7dRBCQAxEMDA7Umpf4+tiYNCmFGQV9bsOQMQ8L0OAPiLoQEZhgZkGBqQYWhAhqEBGYYGZBgakGFoQIahARmGBmQYGpBhaECGoQEZhgZkGBqQYWhAhqEBGRd3UQFH+aT7TgAAAABJRU5ErkJggg==";
            string BlueViolet = "iVBORw0KGgoAAAANSUhEUgAAATQAAAATCAYAAAAeX/GlAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAITgAACE4BjDEA7AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAABhSURBVHic7dRBDcAgAMDAMTs4RSZGmIklJM2dgr461tznAQh4bwcA/MXQgAxDAzIMDcgwNCDD0IAMQwMyDA3IMDQgw9CADEMDMgwNyDA0IMPQgAxDAzIMDcgwNCDD0ICMD9G5ArxATZYdAAAAAElFTkSuQmCC";

            switch (color)
            {
                case ColorUI.Black:
                    return Black;
                case ColorUI.Blue:
                    return Blue;
                case ColorUI.Gray:
                    return Gray;
                case ColorUI.Green:
                    return Green;
                case ColorUI.Red:
                    return Red;
                case ColorUI.Yellow:
                    return Yellow;
                case ColorUI.BlueLight:
                    return BlueLight;
                case ColorUI.GreenLight:
                    return GreenLight;
                case ColorUI.YellowLight:
                    return YellowLight;
                case ColorUI.White:
                    return White;
                case ColorUI.Pink:
                    return Pink;
                case ColorUI.Orange:
                    return Orange;
                case ColorUI.Brown:
                    return Brown;
                case ColorUI.Purple:
                    return Purple;
                case ColorUI.Turquoise:
                    return Turquoise;
                case ColorUI.PinkLight:
                    return PinkLight;
                case ColorUI.BlueSky:
                    return BlueSky;
                case ColorUI.GrayLight:
                    return GrayLight;
                case ColorUI.RedLight:
                    return RedLight;
                case ColorUI.OrangeLight:
                    return OrangeLight;
                case ColorUI.YellowDark:
                    return YellowDark;
                case ColorUI.GreenDark:
                    return GreenDark;
                case ColorUI.BlueDark:
                    return BlueDark;
                case ColorUI.Aqua:
                    return Aqua;
                case ColorUI.Tan:
                    return Tan;
                case ColorUI.GreenDarkness:
                    return GreenDarkness;
                case ColorUI.BlueViolet:
                    return BlueViolet;
                default:
                    return Gray;
            }
        }

        private string GetLine(ColorUI color, LineSize size)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetLineSize" + size.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            object[] parametersInvoke = { color };

            var returnStringColor = (string)methodToInvoke.Invoke(this, parametersInvoke);
            return returnStringColor;
        }
    }
}
