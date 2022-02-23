using Xamarin.Forms;

namespace LaavorAccordion
{
    /// <summary>
    /// Class SectionContent works inside Accordion
    /// </summary>
    public class SectionContent: StackLayout
    {
        /// <summary>
        /// Constructor of SectionContent
        /// </summary>
        public SectionContent()
        {
            base.IsVisible = false;
            this.IsVisible = false;
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        public void SetContent(string hash)
        {
            if (hash == "VisibleLL4488*-+++kmasdflaavor___")
            {
                base.IsVisible = true;
                this.IsVisible = true;
            }
            else if(hash == "InvisiblekktyRE35__00.)*+-////]]]}}}}}")
            {
                base.IsVisible = false;
                this.IsVisible = false;
            }
        }


        /// <summary>
        /// Content.
        /// </summary>
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(
            propertyName: nameof(Content),
            returnType: typeof(View),
            declaringType: typeof(Accordion),
            defaultValue:null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ContentChanged);

        /// <summary>
        /// Content.
        /// </summary>
        public View Content
        {
            get
            {
                return (View)GetValue(ContentProperty);
            }
            set
            {
                SetValue(ContentProperty, value);
            }
        }

        private static void ContentChanged(object bindable, object oldValue, object newValue)
        {
            SectionContent sectionContent = (SectionContent)bindable;
            View copyContent = (View)newValue;
            sectionContent.Children.Add(copyContent);
        }

        /// <summary>
        /// Content.
        /// </summary>
        public new static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(
            propertyName: nameof(SectionContent),
            returnType: typeof(bool),
            declaringType: typeof(Accordion),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ContentChanged);

        /// <summary>
        /// Content.
        /// </summary>
        public new bool IsVisible
        {
            get
            {
                return (bool)GetValue(IsVisibleProperty);
            }
            set
            {
                //SetValue(ContentProperty, value);
            }
        }

        /// <summary>
        /// Title.
        /// </summary>
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(Accordion),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Title.
        /// </summary>
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        /// <summary>
        /// Value.
        /// </summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            propertyName: nameof(Value),
            returnType: typeof(string),
            declaringType: typeof(Accordion),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Value.
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

    }
}
