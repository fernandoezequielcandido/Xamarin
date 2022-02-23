namespace LaavorSwapImage
{
    /// <summary>
    /// Class ChosenItem
    /// </summary>
    public class ChosenItem
    {
        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="indexImage"></param>
        /// <param name="numberContent"></param>
        /// <param name="valueImage"></param>
        /// <param name="valueContent"></param>
        /// <param name="source"></param>
        public void Update(string hash, int indexImage, int numberContent, string valueImage, string valueContent, string source)
        {
            if (hash == "laavorffabna87987*--/*-*-/-*.8sdfsakjksfdjkb")
            {
                this.IndexImage = indexImage;
                this.NumberContent = numberContent;
                this.ValueContent = valueImage;
                this.ValueImage = valueContent;
                this.SourceImage = source;
            }
        }

        /// <summary>
        /// Constructor of ChosenItem
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="indexImage"></param>
        /// <param name="numberContent"></param>
        /// <param name="valueContent"></param>
        /// <param name="valueImage"></param>
        /// <param name="source"></param>
        public ChosenItem(string hash, int indexImage, int numberContent, string valueContent, string valueImage, string source)
        {
            if (hash == "laavorffabna87987*--/*-*-/-*.8sdfsakjksfdjkb")
            {
                this.IndexImage = indexImage;
                this.NumberContent = numberContent;
                this.ValueContent = valueContent;
                this.ValueImage = valueImage;
                this.SourceImage = source;
            }
        }

        /// <summary>
        ///Internal 
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="value"></param>
        /// <param name="source"></param>
        public void ChangeValueImage(string hash, string value, string source)
        {
            if (hash == "laavorffabna87987*--/*-*-/-*.8sdfsakjksfdjkb")
            {
                this.ValueImage = value;
                this.SourceImage = source;
            }
        }

        /// <summary>
        /// Return Index of image chosen in Content.
        /// </summary>
        public int IndexImage { get; private set; }

        /// <summary>
        /// Get Value of Image chosen in Content.
        /// </summary>
        public string ValueImage { get; private set; }

        /// <summary>
        /// Return Number of Content.
        /// </summary>
        public int NumberContent { get; private set; }

        /// <summary>
        /// Return Value of Content.
        /// </summary>
        public string ValueContent { get; set; }

        /// <summary>
        /// Return Source of Image.
        /// </summary>
        public string SourceImage { get; set; }

    }
}
