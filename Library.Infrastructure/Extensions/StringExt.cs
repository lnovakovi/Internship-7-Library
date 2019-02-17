using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Infrastructure.Extensions
{
    public static class StringExt
    {
       
        public static string RemoveWhiteSpaces(this string s)
        {
            
            s = s.Trim();
            return Regex.Replace(s, @"\s{2,}", " ");
        }

        public static string CapitalizeEachWord(this string s)
        {
            return Regex.Replace(s.ToLower(), @"(^\w)|(\s\w)", m => m.Value.ToUpper());
        }

    }
}
