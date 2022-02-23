using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace BasePackage.Details
{
    public class Content : StackLayout, IContent
    {

        /// <summary>
        /// Enter the width.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new double Width
        {
            get
            {
                return (double)GetValue(WidthProperty);
            }
            set
            {
                SetValue(WidthProperty, value);
            }
        }

        /// <summary>
        /// Enter the widthRequest.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty WidthRequestProperty = BindableProperty.Create(
            propertyName: nameof(WidthRequest),
            returnType: typeof(double),
            declaringType: typeof(Content),
            defaultValue: 250.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the widthRequest.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new double WidthRequest
        {
            get
            {
                return (double)GetValue(WidthRequestProperty);
            }
            set
            {
                SetValue(WidthRequestProperty, value);
            }
        }

        /// <summary>
        /// Enter the Height.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(Content),
            defaultValue: 250.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Height.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new double Height
        {
            get
            {
                return (double)GetValue(HeightProperty);
            }
            set
            {
                SetValue(HeightProperty, value);
            }
        }

        /// <summary>
        /// Enter the HeightRequest.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty HeightRequestProperty = BindableProperty.Create(
            propertyName: nameof(HeightRequest),
            returnType: typeof(double),
            declaringType: typeof(Content),
            defaultValue: 250.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the HeightRequest.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new double HeightRequest
        {
            get
            {
                return (double)GetValue(HeightRequestProperty);
            }
            set
            {
                SetValue(HeightRequestProperty, value);
            }
        }

        /// <summary>
        /// Enter the AnchorY.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty AnchorYProperty = BindableProperty.Create(
            propertyName: nameof(AnchorY),
            returnType: typeof(double),
            declaringType: typeof(Content),
            defaultValue: 250.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the AnchorX.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty AnchorXProperty = BindableProperty.Create(
            propertyName: nameof(AnchorX),
            returnType: typeof(double),
            declaringType: typeof(Content),
            defaultValue: 250.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the AnchorX.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new double AnchorX
        {
            get
            {
                return (double)GetValue(AnchorXProperty);
            }
            set
            {
                SetValue(AnchorXProperty, value);
            }
        }

        /// <summary>
        /// Enter the AutomationId.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty AutomationIdProperty = BindableProperty.Create(
            propertyName: nameof(AutomationId),
            returnType: typeof(string),
            declaringType: typeof(Content),
            defaultValue: 250.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the AutomationId.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string AutomationId
        {
            get
            {
                return (string)GetValue(AutomationIdProperty);
            }
            set
            {
                SetValue(AutomationIdProperty, value);
            }
        }
        

    }
}
