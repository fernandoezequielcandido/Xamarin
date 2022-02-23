using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{ 
    /// <summary>
    /// Class Form
    /// </summary>
    public class Form: StackLayout
    {
        /// <summary>
        /// Returns if field value is valid.
        /// </summary>
        public bool IsValid { get; private set; }

        private List<LaavorBaseValidate> listItems = new List<LaavorBaseValidate>();

        /// <summary>
        /// Call When For is Validate
        /// </summary>
        public event EventHandler Validate;

        private Submit submit;

        /// <summary>
        /// Constructor of TextBox
        /// </summary>
        public Form() : base()
        {
            IsValid = true;
            submit = null;
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(TextBox))
            {
                listItems.Add((child as LaavorBaseValidate));

                (child as TextBox).Validate += ItemValidate_Validate;
            }

            if (child.GetType() == typeof(NumericBox))
            {
                listItems.Add((child as LaavorBaseValidate));

                (child as NumericBox).Validate += ItemValidate_Validate;
            }

            if (child.GetType() == typeof(EmailBox))
            {
                listItems.Add((child as LaavorBaseValidate));

                (child as EmailBox).Validate += ItemValidate_Validate;
            }

            if (child.GetType() == typeof(PickerBox))
            {
                listItems.Add((child as LaavorBaseValidate));

                (child as PickerBox).OnChangeSelected += ItemValidate_Validate;
            }

            if (child.GetType() == typeof(ChoiceBox))
            {
                listItems.Add((child as LaavorBaseValidate));

                (child as ChoiceBox).Chosen += ItemValidate_Validate;
            }
        }

        private void ItemValidate_Validate(object sender, EventArgs e)
        {
            bool isValid = true;

            int countInvalid = 0;
            LaavorBaseValidate item = null;

            for(int iItem = 0; iItem < listItems.Count; iItem++)
            {
                if (listItems[iItem] == sender)
                {
                    if (isValid)
                    {
                        isValid = listItems[iItem].IsValid;
                    }

                    if (!listItems[iItem].IsValid)
                    {
                        item = listItems[iItem];
                        countInvalid++;
                    }
                }
                else
                {
                    listItems[iItem].ForceValidate();

                    if (isValid)
                    {
                        isValid = listItems[iItem].IsValid;
                    }

                    if (!listItems[iItem].IsValid)
                    {
                        item = listItems[iItem];
                        countInvalid++;
                    }
                }
            }

            if (countInvalid == 1 && item != null)
            {
                if (item.GetType() != typeof(PickerBox) && item.GetType() != typeof(ChoiceBox))
                {
                    item.GetType().GetProperty("ValidationType").SetValue(item, ValidationType.CharacterToCharacter);
                }
            }

            IsValid = isValid;

            if (!IsValid && submit != null)
            {
                submit.IsReadOnly = true;
            }
            else if(IsValid && submit != null)
            {
                submit.IsReadOnly = false;
            }

            Validate?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Enter the button to set form disable control.
        /// </summary>
        [Bindable(true)]
        public Submit ButtonSubmit
        {
            get
            {
                return submit;
            }
            set
            {
                submit = value;
                submit.SetIsForm("ezequiel77_il_li_*+---////1", true);
                submit.IsReadOnly = true;
            }
        }
    }
}
