using System;
using System.Collections.Generic;
using System.Text;

namespace GridFloat
{
    public class GridFloat
    {
        public readonly float[,] Data;
        public readonly GridFloatHeader Header;
        internal GridFloat(float[,] data, GridFloatHeader header)
        {
            Data = data;
            Header = header;
        }
    }
}
