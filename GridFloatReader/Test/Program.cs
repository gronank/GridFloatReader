using System;
using GridFloat;
namespace Test
{
    class Program
    {
        static readonly string Path=@"C:\Users\ander\Downloads\USGS_NED_13_n40w124_GridFloat\usgs_ned_13_n40w124_gridfloat.flt";
        static void Main(string[] args)
        {
            var floats = GridFloatReader.Read(Path);
        }
    }
}
