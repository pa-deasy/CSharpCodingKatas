using System.Collections.Generic;

namespace RatInAMazeAllPossibleDirections
{
    public static class ListExtensions
    {
        public static List<T> With<T>(this List<T> originalList, T item)
        {
            var newList = new List<T>(originalList);
            newList.Add(item);
            return newList;
        }
    }
}
