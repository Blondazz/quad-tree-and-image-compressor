using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree {
    public static class ImageOps {
        public static Image getImage(string path) {
            Image img = Image.FromFile(path);
            return img;
        }

        public static QuadTreeBitmap generateTree(Image img) {
            QuadTreeBitmap tree = new QuadTreeBitmap(new BoundingBoxInt(new PointInt(img.Width / 2, img.Height / 2), 
                img.Width, img.Height, new System.Drawing.Point(0,0)));
            Bitmap bmp = new Bitmap(img);
            tree.GenerateFromBitmap(bmp);

            return tree;
        }
    }
}
