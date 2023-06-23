using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;
namespace Multi_Shop.Models
{
    public class Security
    {
        public static string encryptSHA256(string PlainText)
        {
            string result = "";

            // Create a SHA512 object
            using(SHA256 sha256 = SHA256.Create())
            {

                byte[] sourceData = Encoding.UTF8.GetBytes(PlainText);

                byte[] hashResult = sha256.ComputeHash(sourceData);
                result = BitConverter.ToString(hashResult);
                    
            }
            return result;

        }
    }
}