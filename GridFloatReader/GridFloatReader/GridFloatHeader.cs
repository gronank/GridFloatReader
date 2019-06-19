using System.Globalization;
using System.IO;
using System.Linq;
namespace GridFloat
{
    public class GridFloatHeader
    {
        public readonly int ncols;
        public readonly int nrows;
        public readonly double xllCorner;
        public readonly double yllCorner;
        public readonly double cellsize;
        public readonly int NODATA_value;
        public readonly bool byteorder;
        public readonly int NODATA;

        internal GridFloatHeader(string headerPath)
        {
            var f=File.OpenRead(headerPath);
            
            using (var headerFile = File.OpenText(headerPath))
            {
                ncols=ParseInt(headerFile);
                nrows=ParseInt(headerFile);
                xllCorner=ParseFloat(headerFile);
                yllCorner=ParseFloat(headerFile);
                cellsize=ParseFloat(headerFile);
                NODATA_value=ParseInt(headerFile);
                byteorder=ParseByteOrder(headerFile);
                NODATA=ParseInt(headerFile);
            }
        }
        private int ParseInt(StreamReader headerFile)
        {
            var line = headerFile.ReadLine();
            string[] columns = line.Split(' ');
            return int.Parse(columns.Last());
        }
        private double ParseFloat(StreamReader headerFile)
        {
            var line = headerFile.ReadLine();
            string[] columns = line.Split(' ');
            string s = columns.Last();
            return double.Parse(s,CultureInfo.InvariantCulture);
        }
        private bool ParseByteOrder(StreamReader headerFile)
        {
            var line = headerFile.ReadLine();
            string[] columns = line.Split(' ');
            return columns.Last().ToLower()=="lsbfirst";
        }
    }
}