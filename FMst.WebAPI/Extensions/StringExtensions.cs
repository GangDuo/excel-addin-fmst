using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FMst.WebAPI.Extensions
{
    internal static class StringExtensions
    {
        public static string ToSnakeCase(this string s)
        {
            var rgx = new Regex("[a-z][A-Z]");
            return rgx.Replace(s, m => m.Groups[0].Value[0] + "_" + m.Groups[0].Value[1]);
        }

        public static string ToUpperSnakeCase(this string s)
        {
            return s.ToSnakeCase().ToUpper();
        }

        public static string ToLowerSnakeCase(this string s)
        {
            return s.ToSnakeCase().ToLower();
        }
    }
}
