using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab3
{
   partial class Vector
    {
        private enum Error { IndexOutOfRangeException };
        private Error state;
        public static readonly long Id;
        private List<int> vector;
        public static int count;
        private int size;
        public const string owner = "Anna";
    }
}
