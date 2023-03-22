using EFCore.NamingConventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utilities
{
    public static class StringExtentions
    {
        static SnakeCaseNameRewriter writer = new(System.Globalization.CultureInfo.CurrentCulture);

        public static string ToSnakeCase(this string str)
        {
            return writer.RewriteName(str);
        }
    }
}
