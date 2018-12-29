using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CaterCommon
{
    public partial class MD5Helper
    {
        public static string EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] bytesOld = Encoding.UTF8.GetBytes(str);
            byte[] bytesNew = md5.ComputeHash(bytesOld);

            StringBuilder stringBuilder= new StringBuilder();
            foreach (byte VARIABLE in bytesNew)
            {
                stringBuilder.Append(VARIABLE.ToString("x2"));

            }

            return stringBuilder.ToString();
        }
    }
}
