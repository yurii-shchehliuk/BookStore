﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class QueryParameters
    {
        const int maxSize = 30;
        private int defalutSize = 15;

        public int Page { get; set; }
        public int Size { get { return defalutSize; } set { defalutSize = Math.Min(maxSize, value); } }
    }
}
