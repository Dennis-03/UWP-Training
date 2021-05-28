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

namespace CircularPanel
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

    public class Circular : Panel
    {
        int childrenCount,size;
        double cellWidth, cellHeight;
        protected override Size MeasureOverride(Size availableSize)
        {
            childrenCount = Children.Count;
            size = childrenCount / 4;
            cellWidth = availableSize.Width / size;
            cellHeight = double.IsInfinity(availableSize.Height) ? double.PositiveInfinity : availableSize.Height / size;

            foreach(UIElement child in Children)
            {
                child.Measure(new Size(cellWidth, cellHeight));
            }
            return LimitUnboundedSize(availableSize);
        }

        Size LimitUnboundedSize(Size input)
        {
            if (double.IsInfinity(input.Height))
            {
                input.Height = cellHeight * size;
            }
            return input;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            int i,width;
            double x, y;
            UIElementCollection child = Children;
            for (i = 0; i < size; i++)
            {
                x = i * cellWidth;
                y = child[i].DesiredSize.Height * (i / size);
                Point point = new Point(x, y);
                child[i].Arrange(new Rect(point, child[i].DesiredSize));
                childrenCount--;
            }
            width = size;

            for (int count = 1; count < width; count++)
            {
                x = cellWidth * (width-1);
                y = child[i].DesiredSize.Height * count;
                Point point = new Point(x, y);
                child[i].Arrange(new Rect(point, child[i].DesiredSize));
                childrenCount--;
                i++;
            }
            for (int count = 1; count < width; count++)
            {
                x = cellWidth * (width-count-1);
                y = child[i].DesiredSize.Height * (width - 1);
                Point point = new Point(x, y);
                child[i].Arrange(new Rect(point, child[i].DesiredSize));
                childrenCount--;
                i++;
            }
            width--;
            for (int count = 1; count < width; count++)
            {
                x = 0;
                y = child[i].DesiredSize.Height * (width - count);
                Point point = new Point(x, y);
                child[i].Arrange(new Rect(point, child[i].DesiredSize));
                childrenCount--;
                i++;
            }
            return finalSize;
        }
    }
}
