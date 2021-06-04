using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace ControlTemplateExample
{
    public sealed class ButtonControl : Control
    {
        public ButtonControl()
        {
            this.DefaultStyleKey = typeof(ButtonControl);
        }

        public static readonly DependencyProperty contentProperty = DependencyProperty.Register("ButtonContent", typeof(string),typeof(ButtonControl),null);

        public string ButtonContent
        {
            get { return (string)GetValue(contentProperty); }
            set { SetValue(contentProperty, value); }
        }
    }
}
