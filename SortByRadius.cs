using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10
{
    public class SortByRadius : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Circle c1 = x as Circle;
            Circle c2 = y as Circle;
            if (c1.Radius < c2.Radius) return -1;
            if (c1.Radius > c2.Radius) return 1;
            return 0;
        }
    }
}
