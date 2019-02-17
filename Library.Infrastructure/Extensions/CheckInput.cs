using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Infrastructure.Extensions
{
    public static class CheckInput
    {
        public static bool CheckIfEmpty(this string inputString) => inputString == "";

        public static bool TryParseInt(this string inputString)
        {
            var output = 0;
            return int.TryParse(inputString, out output);
        }

        public static bool CheckForAges(this DateTime date,int downAge, int? upAge)
        {
            var years = DateTime.Now.Year - date.Year;
            if ((date.Month > DateTime.Now.Month) || (date.Month == DateTime.Now.Month && date.Day > DateTime.Now.Day))
                years--;

            if (upAge != null)
                return years >= downAge && years <= upAge;
            return years >= downAge;

        }
    }
}
