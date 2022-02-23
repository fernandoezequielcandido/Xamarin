using Laavor.Buttons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{ 
    namespace Validate
    {
        /// <summary>
        /// Class ValidateContent
        /// </summary>
        public class ValidateContent : StackLayout
        {
            /// <summary>
            /// Returns if field value is valid.
            /// </summary>
            public bool IsValid { get; private set; }

            private List<ValidateBase> listItems = new List<ValidateBase>();

            /// <summary>
            /// Call When For is Validate
            /// </summary>
            public event EventHandler Validate;

            private ButtonBox submit;

            /// <summary>
            /// Constructor of TextBox
            /// </summary>
            public ValidateContent() : base()
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

                if (child.GetType() == typeof(ValidateText))
                {
                    listItems.Add((child as ValidateText));

                    (child as ValidateText).Validate += ItemValidate_Validate;
                }

                if (child.GetType() == typeof(ValidateNumber))
                {
                    listItems.Add((child as ValidateBase));

                    (child as ValidateNumber).Validate += ItemValidate_Validate;
                }

                if (child.GetType() == typeof(ValidateEmail))
                {
                    listItems.Add((child as ValidateBase));

                    (child as ValidateEmail).Validate += ItemValidate_Validate;
                }

                if (child.GetType() == typeof(ValidatePicker))
                {
                    listItems.Add((child as ValidateBase));

                    (child as ValidatePicker).Validate += ItemValidate_Validate;
                }
            }

            private void ItemValidate_Validate(object sender, EventArgs e)
            {
                bool isValid = true;

                int countInvalid = 0;
                ValidateBase item = null;

                for (int iItem = 0; iItem < listItems.Count; iItem++)
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
                    if (item.GetType() != typeof(ValidatePicker))
                    {
                        item.GetType().GetProperty("ValidationType").SetValue(item, ValidationType.CharacterToCharacter);
                    }
                }

                IsValid = isValid;

                if (!IsValid && submit != null)
                {
                    submit.IsReadOnly = true;
                }
                else if (IsValid && submit != null)
                {
                    submit.IsReadOnly = false;
                }

                Validate?.Invoke(this, EventArgs.Empty);
            }

            /// <summary>
            /// Enter the button to set form disable control.
            /// </summary>
            [Bindable(true)]
            public ButtonBox ButtonValidate
            {
                get
                {
                    return submit;
                }
                set
                {
                    submit = value;
                    submit.IsReadOnly = true;
                }
            }
        }
    }
}
