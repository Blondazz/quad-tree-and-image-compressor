using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree {
    public class QuadTreeBitmap {
        public static int ColorTolerance = 10;
        public static double DesiredRatio = 0.975;
        public BoundingBoxInt Boundary { get; set; }
        public Bitmap Bitmap { get; set; }
        private Color _mainColor;
        public QuadTreeBitmap(BoundingBoxInt boundary) {
            Boundary = boundary;
        }


        public  QuadTreeBitmap NorthWest { get; set; }
        public  QuadTreeBitmap NorthEast { get; set; }
        public  QuadTreeBitmap SouthWest { get; set; }
        public  QuadTreeBitmap SouthEast { get; set; }

        public void GenerateFromBitmap(Bitmap bmp) {
            List<List<Color>> colorGroups = new List<List<Color>>();
            for (int i = 0; i < Boundary.Width; i++) {
                for (int j = 0; j < Boundary.Height; j++) {
                    if (i == 0 && j == 0) {
                        var colorGroup = new List<Color>();
                        colorGroup.Add(bmp.GetPixel(i, j));
                        colorGroups.Add(colorGroup);
                    }
                    else {
                        var pixel = bmp.GetPixel(i, j);
                        bool found = false;
                        for (int k = 0; k < colorGroups.Count; k++) {
                            if (Math.Abs(colorGroups[k][0].R - pixel.R) < ColorTolerance &&
                                Math.Abs(colorGroups[k][0].G - pixel.G) < ColorTolerance &&
                                Math.Abs(colorGroups[k][0].B - pixel.B) < ColorTolerance) {
                                colorGroups[k].Add(pixel);
                                found = true;
                            }
                        }
                        if (found is false) {
                            var colorGroup = new List<Color>();
                            colorGroup.Add(pixel);
                            colorGroups.Add(colorGroup);

                        }
                    }
                }
            }

            int countMax = colorGroups.Max(cg => cg.Count);
            if (countMax / (float)(bmp.Width * bmp.Height) <= DesiredRatio && (Boundary.Width >= 4 && Boundary.Height >= 4 )) {
                BitmapSubdivide(bmp);

            }
            else {
                colorGroups.Sort((a, b) => b.Count - a.Count);
                _mainColor = colorGroups[0][0];
                using (var g = Graphics.FromImage(bmp)) {
                    g.FillRectangle(new SolidBrush(_mainColor), 0, 0, bmp.Width, bmp.Height);
                }
                Bitmap = bmp;
            }
            Console.WriteLine();
        }

        private void BitmapSubdivide(Bitmap bmp) {
            int newWidth = bmp.Width / 2;
            int newWidth1 = Boundary.Width - newWidth;
            int newHeight = bmp.Height / 2;
            int newHeight1 = Boundary.Height - newHeight;

            Rectangle nwRect = new Rectangle(0, 0, newWidth, newHeight);
            Rectangle neRect = new Rectangle(newWidth, 0, newWidth1, newHeight);
            Rectangle swRect = new Rectangle(0, newHeight, newWidth, newHeight1);
            Rectangle seRect = new Rectangle(newWidth, newHeight, newWidth1, newHeight1);

            Bitmap nwBitmap = bmp.Clone(nwRect, bmp.PixelFormat);
            Bitmap neBitmap = bmp.Clone(neRect, bmp.PixelFormat);
            Bitmap swBitmap = bmp.Clone(swRect, bmp.PixelFormat);
            Bitmap seBitmap = bmp.Clone(seRect, bmp.PixelFormat);
            //zajebac 4 ify dla roznych przypadkow parzystosci wysokosci i szerokosci
            int subX = ((newWidth) / 2);
            int subY = ((newHeight) / 2);
            if (newWidth % 2 == 1) 
                subX += 1;
            if (newHeight % 2 == 1)
                subY += 1;

            NorthWest = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X - subX, Boundary.Center.Y - subY),
                nwBitmap.Width, nwBitmap.Height, Boundary.DrawingPoint));

            // if (newWidth % 2 == 1 && newHeight % 2 == 1) {
            //
            //     NorthWest = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X - ((neRect.Width) / 2 + 1), Boundary.Center.Y -
            //             (swRect.Height / 2 + 1)),
            //         nwBitmap.Width, nwBitmap.Height));
            //     NorthEast = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X + nwRect.Width / 2, Boundary.Center.Y - (swRect.Height / 2 + 1)),
            //         neBitmap.Width, neBitmap.Height));
            //     SouthWest = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X - ((neRect.Width) / 2 + 1), Boundary.Center.Y + nwRect.Height / 2),
            //         swBitmap.Width, swBitmap.Height));
            //     SouthEast = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X + swRect.Width / 2, Boundary.Center.Y + neRect.Height / 2),
            //         seBitmap.Width, seBitmap.Height));
            // }
            var nePoint = new System.Drawing.Point(Boundary.DrawingPoint.X + newWidth, Boundary.DrawingPoint.Y);
            var swPoint = new System.Drawing.Point(Boundary.DrawingPoint.X, Boundary.DrawingPoint.Y + newHeight);
            var sePoint = new System.Drawing.Point(Boundary.DrawingPoint.X +newWidth, Boundary.DrawingPoint.Y + newHeight);
            // var nePoint = new System.Drawing.Point(neRect.X, neRect.Y);
            // var swPoint = new System.Drawing.Point(swRect.X, swRect.Y);
            // var sePoint = new System.Drawing.Point(seRect.X, seRect.Y);
            

            if (bmp.Width % 2 == 1 && bmp.Height % 2 == 1) {
                NorthEast = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X + newWidth1 - newWidth1/2, Boundary.Center.Y - subY),
                    neBitmap.Width, neBitmap.Height, nePoint));
                SouthWest = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X - subX, Boundary.Center.Y + newHeight1 - newHeight1 / 2),
                    swBitmap.Width, swBitmap.Height, swPoint));
                SouthEast = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X + newWidth1 - newWidth1/2, Boundary.Center.Y + newHeight1 - newHeight1 / 2),
                    seBitmap.Width, seBitmap.Height, sePoint));
            }
            else if (bmp.Width % 2 == 1 && bmp.Height % 2 == 0) {
                NorthEast = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X + newWidth1 - newWidth1 / 2, Boundary.Center.Y - subY),
                    neBitmap.Width, neBitmap.Height, nePoint));
                SouthWest = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X - subX, Boundary.Center.Y + newHeight1 - subY),
                    swBitmap.Width, swBitmap.Height,swPoint));
                SouthEast = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X + newWidth1 - newWidth1 / 2, Boundary.Center.Y + newHeight1 - subY),
                    seBitmap.Width, seBitmap.Height, sePoint));
            }
            else if (bmp.Width % 2 == 0 && bmp.Height % 2 == 1) {
                NorthEast = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X + newWidth1 - subX, Boundary.Center.Y - subY),
                    neBitmap.Width, neBitmap.Height, nePoint));
                SouthWest = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X - subX, Boundary.Center.Y + newHeight - newHeight / 2),
                    swBitmap.Width, swBitmap.Height, swPoint));
                SouthEast = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X + newWidth1 - subX, Boundary.Center.Y + newHeight1 - newHeight1 / 2),
                    seBitmap.Width, seBitmap.Height, sePoint));
            }
            else {
                NorthEast = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X + newWidth1 - subX, Boundary.Center.Y - subY),
                    neBitmap.Width, neBitmap.Height, nePoint));
                SouthWest = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X - subX, Boundary.Center.Y + newHeight1 - subY),
                    swBitmap.Width, swBitmap.Height, swPoint));
                SouthEast = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(Boundary.Center.X + newWidth1 - subX, Boundary.Center.Y + newHeight1 - subY),
                    seBitmap.Width, seBitmap.Height, sePoint));
            }
            


            NorthWest.GenerateFromBitmap(nwBitmap);
            NorthEast.GenerateFromBitmap(neBitmap);
            SouthWest.GenerateFromBitmap(swBitmap);
            SouthEast.GenerateFromBitmap(seBitmap);


        }

    }
}
