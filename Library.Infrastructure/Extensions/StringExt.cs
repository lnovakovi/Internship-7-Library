using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Extensions
{
    public static class StringExt
    {
        public static bool CheckIfEmpty(this string inputString) => inputString == "";

        public static bool TryParseInt(this string inputString)
        {
            var output = 0;
            return int.TryParse(inputString, out output);
        }
    }
}
