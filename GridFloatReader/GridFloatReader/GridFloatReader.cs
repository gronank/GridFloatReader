using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GridFloat
{
    public class GridFloatReader
    {
        public static GridFloat Read(string path)
        {
            string headerPath = Path.ChangeExtension(path, "hdr");
            if (!File.Exists(path))
            {
                throw new Exception("File not found");
            }
            if (!File.Exists(headerPath))
            {
                throw new Exception("Header file not found");
            }
            GridFloatHeader header = ReadHeader(headerPath);
            float[,] data = ReadData(header,path);
            return new GridFloat(data, header);
        }

        private static float[,] ReadData(GridFloatHeader header,string path)
        {
            float[,] data = new float[header.ncols,header.nrows];
            using (var stream = File.OpenRead(path))
            {
                byte[] buffer = new byte[4];
                for (int x = 0; x < header.ncols; x++)
                {
                    for (int y = 0; y < header.nrows; y++)
                    {
                        stream.Read(buffer, 0, 4);
                        if (BitConverter.IsLittleEndian ^ header.byteorder)
                        {
                            Array.Reverse(buffer);
                        }
                        data[x,y]=BitConverter.ToSingle(buffer, 0);
                    }
                }
            }
            return data;
        }

        private static GridFloatHeader ReadHeader(string headerPath)
        {
            var header = new GridFloatHeader(headerPath);
            
            return header;
        }
    }
}
