using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree {
    public class BoundingBox {
        public Point Center { get; set; }
        public float HalfWidth { get; set; }
        public float HalfHeight { get; set; }   

        public BoundingBox(Point center, float halfWidth, float halfHeight) {
            Center = center;
            HalfWidth = halfWidth;
            HalfHeight = halfHeight;
        }

        public bool ContainsPoint(Point p) {
            if (p.X <= Center.X + HalfWidth && p.X >= Center.X - HalfWidth
                                               && p.Y <= Center.Y + HalfHeight && p.Y >= Center.Y - HalfHeight)
                return true;

            return false;
        }

        public bool IntersectsAnotherBox(BoundingBox box) {
            // var p1 = new Point(Center.X - HalfDimension, Center.Y + HalfDimension);
            // var p2 = new Point(Center.X + HalfDimension, Center.Y + HalfDimension);
            // var p3 = new Point(Center.X - HalfDimension, Center.Y - HalfDimension);
            // var p4 = new Point(Center.X + HalfDimension, Center.Y - HalfDimension);
            // if (box.ContainsPoint(p1) || box.ContainsPoint(p2) || box.ContainsPoint(p3) || box.ContainsPoint(p4))
            //     return true;
            RectangleF thisBox = new RectangleF(new PointF(Center.X - HalfWidth, Center.Y - HalfHeight),
                new SizeF(HalfWidth*2, HalfHeight*2));
            RectangleF otherBox = new RectangleF(new PointF(box.Center.X - box.HalfWidth, box.Center.Y - box.HalfHeight),
                new SizeF(box.HalfWidth*2, box.HalfHeight*2));
            bool result = thisBox.IntersectsWith(otherBox);
            return result;

        }

        public override string ToString() {
            return $"Center: {Center}, HalfWidth: {HalfWidth.ToString(CultureInfo.InvariantCulture)}," +
                   $" HalfHeight: {HalfHeight.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
