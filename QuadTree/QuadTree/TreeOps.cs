using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace QuadTree {
    static class TreeOps {
        public static TreeWrapper GenerateTree(int amount) {
            var points = new List<Point>();
            var random = new Random();
            for (int i = 0; i < amount; i++) {
                points.Add(new Point((float)random.NextDouble() * 100, (float)random.NextDouble() * 100));
            }

            var tree = new QuadTreePoints(new BoundingBox(new Point(50f, 50f), 50, 50));
            foreach (var point in points) {
                tree.Insert(point);
            }

            return new TreeWrapper(tree, points);
        }

        public static TreeWrapper UpdateTree(List<Point> points) {
            var tree = new QuadTreePoints(new BoundingBox(new Point(50f, 50f), 50, 50));
            foreach (var point in points) {
                tree.Insert(point);
            }

            return new TreeWrapper(tree, points);
        }

        public static void Draw(TreeWrapper treeWrapper, PictureBox pictureBox, Graphics graphics) {

            DrawPoints(treeWrapper.Points, pictureBox, graphics);
            DrawTree(treeWrapper.Tree, pictureBox, graphics);
            
        }
        public static void DrawTreeBitmap(QuadTreeBitmap tree, PictureBox pictureBox, Graphics graphics) {
            DrawTree(tree, pictureBox, graphics);
        }
        private static void DrawPoints(List<Point> points, PictureBox pictureBox, Graphics graphics) {
            float scale = pictureBox.Width / 100f;
            
            Pen pen = new Pen(Color.Black, 1);
            Brush brush = new SolidBrush(Color.Black);
            foreach (var point in points) {
                graphics.FillCircle(brush, point.X*scale, point.Y*scale, 3f);
            }

            //pictureBox.Image = bitmap;
        }
        private static void DrawTree(QuadTreePoints tree, PictureBox pictureBox, Graphics graphics) {
            if (tree.NorthWest is not null) {
                float scale = pictureBox.Width / 100f;
                Pen pen = new Pen(Color.Red, 2);
                float x1 = tree.Boundary.Center.X - tree.Boundary.HalfWidth;
                float x2 = tree.Boundary.Center.X + tree.Boundary.HalfWidth;
                float y1 = tree.Boundary.Center.Y;
                float y2 = tree.Boundary.Center.Y;

                graphics.DrawLine(pen, x1*scale, y1*scale, x2*scale, y2*scale);
                x1 = tree.Boundary.Center.X;
                x2 = tree.Boundary.Center.X;
                y1 = tree.Boundary.Center.Y - tree.Boundary.HalfHeight;
                y2 = tree.Boundary.Center.Y + tree.Boundary.HalfHeight;
                graphics.DrawLine(pen, x1 * scale, y1 * scale, x2 * scale, y2 * scale);
               
            
                DrawTree(tree.NorthWest, pictureBox, graphics);
                DrawTree(tree.NorthEast, pictureBox, graphics);
                DrawTree(tree.SouthWest, pictureBox, graphics);
                DrawTree(tree.SouthEast, pictureBox, graphics);
            }
        }
        private static void DrawTree(QuadTreeBitmap tree, PictureBox pictureBox, Graphics graphics) {
            if (tree.NorthWest is not null && tree.Boundary.Width > 4) {
               // float scale = pictureBox.Width / 100f;
                Pen pen = new Pen(Color.Red, 1);
                float x1 = tree.Boundary.Center.X - tree.Boundary.Width/2;
                float x2 = tree.Boundary.Center.X + tree.Boundary.Width/2;
                float y1 = tree.Boundary.Center.Y;
                float y2 = tree.Boundary.Center.Y;
                graphics.DrawLine(pen, x1, y1, x2, y2);
                // graphics.DrawLine(pen, tree.Boundary.DrawingPoint.X, tree.Boundary.DrawingPoint.Y,
                //     tree.Boundary.DrawingPoint.X + tree.Boundary.Width,
                //     tree.Boundary.DrawingPoint.Y + tree.Boundary.Height);
                // graphics.DrawLine(pen, tree.Boundary.DrawingPoint.X, tree.Boundary.DrawingPoint.Y + tree.Boundary.Height,
                //     tree.Boundary.DrawingPoint.X + tree.Boundary.Width,
                //     tree.Boundary.DrawingPoint.Y );

                x1 = tree.Boundary.Center.X;
                x2 = tree.Boundary.Center.X;
                y1 = tree.Boundary.Center.Y - tree.Boundary.Height/2;
                y2 = tree.Boundary.Center.Y + tree.Boundary.Height/2;
                graphics.DrawLine(pen, x1, y1, x2, y2);


                DrawTree(tree.NorthWest, pictureBox, graphics);
                DrawTree(tree.NorthEast, pictureBox, graphics);
                DrawTree(tree.SouthWest, pictureBox, graphics);
                DrawTree(tree.SouthEast, pictureBox, graphics);
            }

           
        }

        public static Bitmap getCompressedImage(QuadTreeBitmap tree, Bitmap bitmap, int treeSide) {
            if(treeSide == 0)
                using (var g = Graphics.FromImage(bitmap)) {
                    g.FillRectangle(new SolidBrush(Color.Magenta), 0 ,0, bitmap.Width, bitmap.Height);
                }
            if (tree.NorthWest is not null) {
                bitmap = getCompressedImage(tree.NorthWest, bitmap, 1);
                bitmap = getCompressedImage(tree.NorthEast, bitmap, 1);
                bitmap = getCompressedImage(tree.SouthWest, bitmap, 2);
                bitmap = getCompressedImage(tree.SouthEast, bitmap, 2);
            }
            if(tree.Bitmap is null)
                return bitmap;
            else {
                // int x = 0;
                // int y = 0;
                // if (treeSide == 2) {
                //     x = tree.Boundary.Center.X - tree.Boundary.Width / 2;
                //     y = tree.Boundary.Center.Y - tree.Boundary.Height / 2 -1;
                // }
               
                
                // switch (treeSide) {
                //     case 1:
                //         x = tree.Boundary.Center.X - tree.Boundary.Width/2;
                //         y = tree.Boundary.Center.Y - tree.Boundary.Height/2;
                //         break;
                //     case 2:
                //         break;
                //     case 3:
                //         break;
                //
                // }
               // var p = new System.Drawing.Point(x, y);
                using (var g = Graphics.FromImage(bitmap)) {
                    Bitmap bmp = tree.Bitmap;
                    g.DrawImage(bmp, tree.Boundary.DrawingPoint);
                    tree.Bitmap = null;
                }
                return bitmap;
            }
        }
    }
}
