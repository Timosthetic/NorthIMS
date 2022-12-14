using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DataVisualization.Converter
{
    public class PartiallyRoundedRectangle : Shape
    {
        public static readonly DependencyProperty RadiusXProperty;
        public static readonly DependencyProperty RadiusYProperty;

        public static readonly DependencyProperty RoundTopLeftProperty;
        public static readonly DependencyProperty RoundTopRightProperty;
        public static readonly DependencyProperty RoundBottomLeftProperty;
        public static readonly DependencyProperty RoundBottomRightProperty;

        public int RadiusX
        {
            get { return (int)GetValue(RadiusXProperty); }
            set { SetValue(RadiusXProperty, value); }
        }

        public int RadiusY
        {
            get { return (int)GetValue(RadiusYProperty); }
            set { SetValue(RadiusYProperty, value); }
        }

        public bool RoundTopLeft
        {
            get { return (bool)GetValue(RoundTopLeftProperty); }
            set { SetValue(RoundTopLeftProperty, value); }
        }

        public bool RoundTopRight
        {
            get { return (bool)GetValue(RoundTopRightProperty); }
            set { SetValue(RoundTopRightProperty, value); }
        }

        public bool RoundBottomLeft
        {
            get { return (bool)GetValue(RoundBottomLeftProperty); }
            set { SetValue(RoundBottomLeftProperty, value); }
        }

        public bool RoundBottomRight
        {
            get { return (bool)GetValue(RoundBottomRightProperty); }
            set { SetValue(RoundBottomRightProperty, value); }
        }

        static PartiallyRoundedRectangle()
        {
            RadiusXProperty = DependencyProperty.Register
                ("RadiusX", typeof(int), typeof(PartiallyRoundedRectangle));
            RadiusYProperty = DependencyProperty.Register
                ("RadiusY", typeof(int), typeof(PartiallyRoundedRectangle));

            RoundTopLeftProperty = DependencyProperty.Register
                ("RoundTopLeft", typeof(bool), typeof(PartiallyRoundedRectangle));
            RoundTopRightProperty = DependencyProperty.Register
                ("RoundTopRight", typeof(bool), typeof(PartiallyRoundedRectangle));
            RoundBottomLeftProperty = DependencyProperty.Register
                ("RoundBottomLeft", typeof(bool), typeof(PartiallyRoundedRectangle));
            RoundBottomRightProperty = DependencyProperty.Register
                ("RoundBottomRight", typeof(bool), typeof(PartiallyRoundedRectangle));
        }

        public PartiallyRoundedRectangle()
        {
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                Geometry result = new RectangleGeometry
                (new Rect(0, 0, base.Width, base.Height), RadiusX, RadiusY);
                double halfWidth = base.Width / 2;
                double halfHeight = base.Height / 2;

                if (!RoundTopLeft)
                    result = new CombinedGeometry
                (GeometryCombineMode.Union, result, new RectangleGeometry
                (new Rect(0, 0, halfWidth, halfHeight)));
                if (!RoundTopRight)
                    result = new CombinedGeometry
                (GeometryCombineMode.Union, result, new RectangleGeometry
                (new Rect(halfWidth, 0, halfWidth, halfHeight)));
                if (!RoundBottomLeft)
                    result = new CombinedGeometry
                (GeometryCombineMode.Union, result, new RectangleGeometry
                (new Rect(0, halfHeight, halfWidth, halfHeight)));
                if (!RoundBottomRight)
                    result = new CombinedGeometry
                (GeometryCombineMode.Union, result, new RectangleGeometry
                (new Rect(halfWidth, halfHeight, halfWidth, halfHeight)));

                return result;
            }
        }
    }
}
