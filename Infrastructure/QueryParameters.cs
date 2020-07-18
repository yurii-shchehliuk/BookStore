using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class QueryParameters
    {
        const int maxSize = 100;
        private int defalutSize = 50;

        public int Page { get; set; }
        public int Size { get { return defalutSize; } set { defalutSize = Math.Min(maxSize, value); } }
    }
}
