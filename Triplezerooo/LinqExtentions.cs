using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Triplezerooo
{
    public static class LinqExtentions
    {
        public static IEnumerable<T> SingleToEnumerable<T>(this T singleItem) { yield return singleItem; }
        public static T[] SingleToArray<T>(this T singleItem) => new T[] { singleItem };
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> list) => list.Where(x => x != null);
    }
}
