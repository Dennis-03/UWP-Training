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

namespace ButtonTemplatedControl
{
    public sealed class CustomButton : Control
    {
        public CustomButton()
        {
            this.DefaultStyleKey = typeof(CustomButton);
        }

        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("ButtonContent", typeof(string), typeof(CustomButton), null);

        public string ButtonContent
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public Grid ButtonContainer;
        private bool clicked;

        public static event Action CustomButtonClicked;

        protected override void OnApplyTemplate()
        {
            ButtonContainer = GetTemplateChild(nameof(ButtonContainer)) as Grid;
            ButtonContainer.PointerEntered += ButtonContainer_PointerEntered;
            ButtonContainer.PointerExited += ButtonContainer_PointerExited;
            ButtonContainer.PointerPressed += ButtonContainer_PointerPressed;
            ButtonContainer.PointerReleased += ButtonContainer_PointerReleased;
        }

        private void ButtonContainer_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (!clicked)
            {
                VisualStateManager.GoToState(this, "Clicked", true);
                clicked = true;
            }
            else
            {
                VisualStateManager.GoToState(this, "Clicked", true);
                clicked = false;
            }
        }

        private void ButtonContainer_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "Pressed", true);
            CustomButtonClicked?.Invoke();

        }

        private void ButtonContainer_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            if(!clicked)
                VisualStateManager.GoToState(this, "Normal", true);
        }

        private void ButtonContainer_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if(!clicked)
                VisualStateManager.GoToState(this, "PointerOver", true);
        }
    }
}
