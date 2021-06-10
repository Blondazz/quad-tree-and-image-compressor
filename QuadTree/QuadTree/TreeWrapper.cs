using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree {
     public class TreeWrapper {
        public QuadTreePoints Tree { get; set; }
        public List<Point> Points { get; set; }

        public TreeWrapper(QuadTreePoints tree, List<Point> points) {
            Tree = tree;
            Points = points;
        }
    }
}
