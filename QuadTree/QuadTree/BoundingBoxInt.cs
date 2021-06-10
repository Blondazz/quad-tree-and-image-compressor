using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree {
    public class BoundingBoxInt {
        public PointInt Center { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public System.Drawing.Point DrawingPoint { get; set; }
        public BoundingBoxInt(PointInt center, int width, int height, System.Drawing.Point drawingPoint) {
            Center = center;
            Width = width;
            Height = height;
            DrawingPoint = drawingPoint;
        }

        

        // public bool IntersectsAnotherBox(BoundingBoxInt box) {
        //     // var p1 = new Point(Center.X - HalfDimension, Center.Y + HalfDimension);
        //     // var p2 = new Point(Center.X + HalfDimension, Center.Y + HalfDimension);
        //     // var p3 = new Point(Center.X - HalfDimension, Center.Y - HalfDimension);
        //     // var p4 = new Point(Center.X + HalfDimension, Center.Y - HalfDimension);
        //     // if (box.ContainsPoint(p1) || box.ContainsPoint(p2) || box.ContainsPoint(p3) || box.ContainsPoint(p4))
        //     //     return true;
        //     Rectangle thisBox = new Rectangle(new System.Drawing.Point(Center.X - HalfWidth, Center.Y - HalfHeight),
        //         new Size(HalfWidth * 2, HalfHeight * 2));
        //     Rectangle otherBox = new Rectangle(new System.Drawing.Point(box.Center.X - box.HalfWidth, box.Center.Y - box.HalfHeight),
        //         new Size(box.HalfWidth * 2, box.HalfHeight * 2));
        //     bool result = thisBox.IntersectsWith(otherBox);
        //     return result;
        //
        // }

        public override string ToString() {
            return $"Center: {Center}, Width: {Width.ToString(CultureInfo.InvariantCulture)}," +
                   $" Height: {Height.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
