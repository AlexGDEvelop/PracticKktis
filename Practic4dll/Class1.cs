using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic4dll
{
    public class MyDll
    {
        public float Formula(float x,float y)
        {
            float a, b, c,d,e,f;
            a = x + y;
            b = y + 1;
            c = (x * y) - 12;
            d = 34 + x;
            f = a / b;
            e = c / d;
            return f-e;
        }
    }
}
