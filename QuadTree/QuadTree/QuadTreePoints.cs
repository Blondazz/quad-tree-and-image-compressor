using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace QuadTree {
    public class QuadTreePoints:QuadTree {
        
        public List<Point> Points = new();

        public QuadTreePoints(BoundingBox boundary) : base(boundary) { }

        public new QuadTreePoints NorthWest { get; set; }
        public new QuadTreePoints NorthEast { get; set; }
        public new QuadTreePoints SouthWest { get; set; }
        public new QuadTreePoints SouthEast { get; set; }


        public bool Insert(Point p) {

            if (!Boundary.ContainsPoint(p))
                return false;
            if(Points != null)
                if (Points.Count < Capacity && NorthWest == null) {
                    Points.Add(p);
                    return true;
                }
            if(NorthWest == null)
                Subdivide();

            if (NorthWest.Insert(p)) return true;
            if (NorthEast.Insert(p)) return true;
            if (SouthWest.Insert(p)) return true;
            if (SouthEast.Insert(p)) return true;

            throw new InvalidOperationException("Inserting points has failed for an unknown reason.");
        }

        public void Subdivide() {
            float newHalfWidth = Boundary.HalfWidth / 2f;
            float newHalfHeight = Boundary.HalfHeight / 2f;
            NorthWest = new QuadTreePoints(new BoundingBox(
                new Point(Boundary.Center.X - newHalfWidth, Boundary.Center.Y + newHalfHeight),
                newHalfWidth, newHalfHeight));
            NorthEast = new QuadTreePoints(new BoundingBox(
                new Point(Boundary.Center.X + newHalfWidth, Boundary.Center.Y + newHalfHeight),
                newHalfWidth, newHalfHeight));
            SouthWest = new QuadTreePoints(new BoundingBox(
                new Point(Boundary.Center.X - newHalfWidth, Boundary.Center.Y - newHalfHeight),
                newHalfWidth, newHalfHeight));
            SouthEast = new QuadTreePoints(new BoundingBox(
                new Point(Boundary.Center.X + newHalfWidth, Boundary.Center.Y - newHalfHeight),
                newHalfWidth, newHalfHeight));
            foreach (var point in Points) {
                NorthWest.Insert(point);
                NorthEast.Insert(point);
                SouthWest.Insert(point);
                SouthEast.Insert(point);
            }
            Points = null;
        }

        public List<Point> QueryRange(BoundingBox query) {
            var points = new List<Point>();
            if (!Boundary.IntersectsAnotherBox(query))
                return points;
            if(Points != null)
                for (int i = 0; i < Points.Count; i++) {
                    if(query.ContainsPoint(Points[i]))
                        points.Add(Points[i]);
                }

            if (NorthWest == null)
                return points;

            var p1 = NorthWest.QueryRange(query);
            var p2 = NorthEast.QueryRange(query);
            var p3 = SouthWest.QueryRange(query);
            var p4 = SouthEast.QueryRange(query);

            foreach (var point in p1) {
                points.Add(point);
            }
            foreach (var point in p2) {
                points.Add(point);
            }
            foreach (var point in p3) {
                points.Add(point);
            }
            foreach (var point in p4) {
                points.Add(point);
            }

            return points;
        }

        

        
    }
}
