using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree {
    public class PointInt {
        public int X { get; set; }
        public int Y { get; set; }

        public PointInt(int x, int y) {
            X = x;
            Y = y;
        }

        public override string ToString() {
            return $"({X.ToString(CultureInfo.InvariantCulture)};{Y.ToString(CultureInfo.InvariantCulture)})";
        }
    }
}
