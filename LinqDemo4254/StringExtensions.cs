using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo4254
{
    static class StringExtensions
    {
        /// <summary>
        /// Является ли строка целым числом?
        /// </summary>
        public static bool IsInt(this string s)
        {
            int i;
            return Int32.TryParse(s, out i);
        }
    }
}
