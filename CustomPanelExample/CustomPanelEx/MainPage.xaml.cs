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

namespace CustomPanelEx
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
    public class BoxPanel : Panel
    {
        int maxrc, rowcount, colcount;
        double cellwidth, cellheight, maxcellheight, aspectratio;

        protected override Size MeasureOverride(Size availableSize)
        {
            maxrc = (int)Math.Ceiling(Math.Sqrt(Children.Count));
            aspectratio = availableSize.Width / availableSize.Height;

            if (aspectratio > 1)
            {
                rowcount = maxrc;
                colcount = (maxrc > 2 && Children.Count < maxrc * (maxrc - 1)) ? maxrc - 1 : maxrc;
            }
            else
            {
                rowcount = (maxrc > 2 && Children.Count < maxrc * (maxrc - 1)) ? maxrc - 1 : maxrc;
                colcount = maxrc;
            }

            cellwidth = (int)Math.Floor(availableSize.Width / colcount);
            cellheight = Double.IsInfinity(availableSize.Height) ? Double.PositiveInfinity : availableSize.Height / rowcount;

            foreach (UIElement child in Children)
            {
                child.Measure(new Size(cellwidth, cellheight));
                maxcellheight = (child.DesiredSize.Height > maxcellheight) ? child.DesiredSize.Height : maxcellheight;
            }
            return LimitUnboundedSize(availableSize);
        }

        Size LimitUnboundedSize(Size input)
        {
            if (Double.IsInfinity(input.Height))
            {
                input.Height = maxcellheight * colcount;
                cellheight = maxcellheight;
            }
            return input;
        }

        protected override Size ArrangeOverride(Size finalSize)
        { 
            int count = 1;
            double x, y;
            foreach (UIElement child in Children)
            {
                x = (count - 1) % colcount * cellwidth;
                y = ((int)(count - 1) / colcount) * cellheight;
                Point anchorPoint = new Point(x, y);
                child.Arrange(new Rect(anchorPoint, child.DesiredSize));
                count++;
            }
            return finalSize;
        }
    }

}
