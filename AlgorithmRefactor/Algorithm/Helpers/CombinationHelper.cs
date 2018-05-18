using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Helpers
{
    public static class CombinationHelper
    {
        /// <summary>
        /// Build a list of all combinations in the source list, skipping combinations already found.
        /// </summary>
        /// <typeparam name="T">The type of object in the list</typeparam>
        /// <typeparam name="TResult">The result on each yield of type T</typeparam>
        /// <param name="list"></param>
        /// <param name="combinator"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> CombinationBuilder<T, TResult>(this IEnumerable<T> list, Func<T, T, TResult> combinator)
        {
            var arrList = list.ToArray();

            for (int i = 0; i < arrList.Count() - 1; i++)
                for (int j = i + 1; j < arrList.Count(); j++)
                    yield return combinator(arrList[i], arrList[j]);
        }
    }
}
