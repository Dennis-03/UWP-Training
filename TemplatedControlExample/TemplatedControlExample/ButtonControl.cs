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

namespace TemplatedControlExample
{
    public sealed class ButtonControl : Control
    {
        public ButtonControl()
        {
            this.DefaultStyleKey = typeof(ButtonControl);
        }
        public static readonly DependencyProperty contentProperty = DependencyProperty.Register("ButtonContent", typeof(string), typeof(ButtonControl), null);

        public string ButtonContent
        {
            get { return (string)GetValue(contentProperty); }
            set { SetValue(contentProperty, value); }
        }

        //public static readonly DependencyProperty clickProperty = DependencyProperty.Register("ButtonClick", typeof(EventHandler), typeof(ButtonControl), null);

        //public EventHandler ButtonClick
        //{
        //    get { return (EventHandler)GetValue(clickProperty); }
        //    set { SetValue(clickProperty, value); }
        //}

        private Button ControlButton;

        public static event Action ClickHandler;

        public static void NotifyClickHandler()
        {
            ClickHandler?.Invoke();
        }

        protected override void OnApplyTemplate()
        {
            ControlButton = GetTemplateChild(nameof(ControlButton)) as Button;
            ControlButton.Click += ControlButton_Click;
            //ControlButton.AddHandler(KeyUpEvent, ControlButton_Click(), true);
        }

        private void ControlButton_Click(object sender, RoutedEventArgs e)
        {
            NotifyClickHandler();
        }
    }
}
