using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree {
    public abstract class QuadTree {
        public static int Capacity { get; set; }
        public BoundingBox Boundary { get; set; }


        protected QuadTree(BoundingBox boundary) {
            Boundary = boundary;
        }
    }
}
