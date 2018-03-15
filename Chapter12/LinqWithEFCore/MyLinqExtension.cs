using System.Collections.Generic;
using System.Linq;

namespace LinqWithEFCore{
    public static class MyLinqExtension{
        public static int? Median(this IEnumerable<int?> sequenze)
        {
            var ordered = sequenze.OrderBy(item => item);
            return ordered.ElementAt(ordered.Count() / 2);
        }

        
    }
}