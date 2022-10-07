using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgancyPro.Classes
{
    public static class StringExtension
    {
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetExtention(string FileName)
        {

            string Extention = Path.GetExtension(@FileName.Trim('"'));
            return Extention;
        }
        public static string RandomCode(int Min, int Max)
        {
            Random generator = new Random();
            String code = generator.Next(Min, Max).ToString("D6");
            return code;
        }
    }
}
