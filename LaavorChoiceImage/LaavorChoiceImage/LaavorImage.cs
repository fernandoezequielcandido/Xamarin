using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LaavorChoiceImage
{
    /// <summary>
    /// Clas LaavorImage
    /// </summary>
    public class LaavorImage: Image
    {
        /// <summary>
        /// Index of LaavorImage  
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Constructor of Laavor Image
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="index"></param>
        public LaavorImage(string hash, int index)
        {
            if (hash != "__Laavor*+-///indexfaearara$$##%¨¨¨¨=@33%%*&¨VVVMMad13,a,a8d939kl")
            {
                throw new Exception("Invalid Hash");
            }

            this.Index = index;
        }

        /// <summary>
        /// Enter the Source of Image Deselect.
        /// </summary>
        public static readonly BindableProperty UnChosenImageProperty = BindableProperty.Create(
            propertyName: nameof(UnChosenImage),
            returnType: typeof(string),
            declaringType: typeof(LaavorImage),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Source of Image Deselect.
        /// </summary>
        public string UnChosenImage
        {
            get
            {
                return (string)GetValue(UnChosenImageProperty);
            }
            set
            {
                SetValue(UnChosenImageProperty, value);
            }
        }

        /// <summary>
        /// Enter the Image.
        /// </summary>
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            propertyName: nameof(Image),
            returnType: typeof(string),
            declaringType: typeof(LaavorImage),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Image.
        /// </summary>
        public string Image
        {
            get
            {
                return (string)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
            }
        }

        /// <summary>
        /// Enter the Source of Image Select.
        /// </summary>
        public static readonly BindableProperty ChosenImageProperty = BindableProperty.Create(
            propertyName: nameof(ChosenImage),
            returnType: typeof(string),
            declaringType: typeof(LaavorImage),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Source of Image Select.
        /// </summary>
        public string ChosenImage
        {
            get
            {
                return (string)GetValue(ChosenImageProperty);
            }
            set
            {
                SetValue(ChosenImageProperty, value);
            }
        }

        /// <summary>
        /// Enter the IsChosen.
        /// </summary>
        public static readonly BindableProperty IsChosenProperty = BindableProperty.Create(
            propertyName: nameof(IsChosen),
            returnType: typeof(bool),
            declaringType: typeof(LaavorImage),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the IsChosen.
        /// </summary>
        public bool IsChosen
        {
            get
            {
                return (bool)GetValue(IsChosenProperty);
            }
            set
            {
                SetValue(IsChosenProperty, value);
            }
        }

        /// <summary>
        /// Enter the Value
        /// </summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            propertyName: nameof(Value),
            returnType: typeof(string),
            declaringType: typeof(LaavorImage),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the value
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
