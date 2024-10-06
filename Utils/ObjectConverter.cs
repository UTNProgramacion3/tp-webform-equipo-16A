using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class ObjectConverter
    {
        public static List<string> ConvertToStringList<T>(List<T> objects, Func<T, string> selector)
        {
            return objects.Select(selector).ToList();
        }
    }
}
