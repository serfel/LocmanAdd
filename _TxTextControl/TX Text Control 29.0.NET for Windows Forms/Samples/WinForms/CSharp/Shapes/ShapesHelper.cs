/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Ribbon Modify Tutorial Sample
** description:	Describes how to add drawings functionality to TX Text Control.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using TXTextControl.Drawing;

namespace Shapes {

    public class ShapesHelper {

        // enum to set the alignment of shape objects
        public enum ShapeAlignment {
            Top,
            Bottom,
            Left,
            Right
        }

        // this method aligns shapes in their canvas container
        public static void AlignShapes(Shape[] shapes, ShapeAlignment alignment) {
            int iMaxValue = 0;

            switch (alignment) {
                case ShapeAlignment.Top:
                    iMaxValue = FindMaxYValue(shapes, true);
                    break;
                case ShapeAlignment.Bottom:
                    iMaxValue = FindMaxYValue(shapes, false);
                    break;
                case ShapeAlignment.Left:
                    iMaxValue = FindMaxXValue(shapes, true);
                    break;
                case ShapeAlignment.Right:
                    iMaxValue = FindMaxXValue(shapes, false);
                    break;
            }

            // loop through all shapes and set the location to the same min/max value
            foreach (Shape shape in shapes) {
                switch (alignment) {
                    case ShapeAlignment.Top:
                        shape.Location = new Point(shape.Location.X, iMaxValue);
                        break;
                    case ShapeAlignment.Bottom:
                        shape.Location = shape.Location.X + shape.Size.Width != iMaxValue ?
                            new Point(shape.Location.X, iMaxValue - shape.Size.Height) :
                            shape.Location;
                        break;
                    case ShapeAlignment.Left:
                        shape.Location = new Point(iMaxValue, shape.Location.Y);
                        break;
                    case ShapeAlignment.Right:
                        shape.Location = shape.Location.X + shape.Size.Width != iMaxValue ?
                            new Point(iMaxValue - shape.Size.Width, shape.Location.Y) :
                            shape.Location;
                        break;
                }
            }
        }

        // find the max/min Y value of an array of shapes
        public static int FindMaxYValue(Shape[] shapes, bool minimum) {
            if (shapes.Length == 0) {
                throw new InvalidOperationException("Empty array");
            }

            int iMaxValue = minimum == true ? int.MaxValue : int.MinValue;

            foreach (Shape shape in shapes) {
                if (minimum == false) {
                    iMaxValue = shape.Location.Y + shape.Size.Height > iMaxValue ?
                        shape.Location.Y + shape.Size.Height : iMaxValue;
                }
                else
                    iMaxValue = shape.Location.Y < iMaxValue ? shape.Location.Y : iMaxValue;
            }

            return iMaxValue;
        }

        // find the max/min X value of an array of shapes
        public static int FindMaxXValue(Shape[] shapes, bool minimum) {
            if (shapes.Length == 0) {
                throw new InvalidOperationException("Empty array");
            }

            int iMaxValue = minimum == true ? int.MaxValue : int.MinValue;

            foreach (Shape shape in shapes) {
                if (minimum == false) {
                    iMaxValue = shape.Location.X + shape.Size.Width > iMaxValue ?
                        shape.Location.X + shape.Size.Width : iMaxValue;
                }
                else
                    iMaxValue = shape.Location.X < iMaxValue ? shape.Location.X : iMaxValue;
            }

            return iMaxValue;
        }
    }
}
