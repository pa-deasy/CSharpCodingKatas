using System.Collections.Generic;

namespace ZigZagTreeTraversal
{
    public static class ListExtensions
    {
        public static List<T> WithRange<T>(this List<T> originalList, List<T> listToAdd)
        {
            var listWithRange = new List<T>(originalList);
            listWithRange.AddRange(listToAdd);

            return listWithRange;
        }
    }
}
