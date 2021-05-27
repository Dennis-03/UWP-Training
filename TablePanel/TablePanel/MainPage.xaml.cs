using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TablePanel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    }

    public class Table : Panel
    {
        int rows,childrenCount;
        double maxCellWidth, maxCellHeight, cellWidth, cellHeight;
        protected override Size MeasureOverride(Size availableSize)
        {
            childrenCount = Children.Count;
            rows = childrenCount / Columns;

            maxCellWidth = availableSize.Width / Columns;
            maxCellHeight = double.IsInfinity(availableSize.Height) ? double.PositiveInfinity : availableSize.Height / rows;

            foreach(UIElement child in Children)
            {
                child.Measure(new Size(maxCellWidth, maxCellHeight));
            }

            return LimitUnboundedSize(availableSize);
        }

        Size LimitUnboundedSize(Size input)
        {
            if (Double.IsInfinity(input.Height))
            {
                input.Height = maxCellHeight * rows;
            }
            return input;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            int count = 0;
            double x, y;
            foreach(UIElement child in Children)
            {
                x = count % Columns * maxCellWidth;
                y = child.DesiredSize.Height * (count / Columns);
                Point point = new Point(x, y);
                child.Arrange(new Rect(point, child.DesiredSize));
                count++;
            }
            return finalSize;
        }

        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }
        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register("ColumnsProperty", typeof(int), typeof(Table), null);
    }
}
