using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSMaterServer
{
    public class Helper
    {
        public static string GetStringFromBytes(byte[] bytes,ref int start)
        {
            List<char> ls = new List<char>();
            for (; start < bytes.Length; start++)
            {
                if (bytes[start] == '\0')
                {
                    start++;
                    return new string(ls.ToArray());
                }
                ls.Add((char)bytes[start]);
            }
            return new string(ls.ToArray());

        }
    }
}
