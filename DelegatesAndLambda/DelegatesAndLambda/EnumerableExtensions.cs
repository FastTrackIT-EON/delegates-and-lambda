using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndLambda
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(
            this IEnumerable<T> source,
            Action<T> actOnElement)
        {
            foreach (T element in source)
            {
                actOnElement(element);
            }
        }

        public static bool HasMatch<T>(
            this IEnumerable<T> source,
            Func<T, bool> isMatch)
        {
            foreach (T element in source)
            {
                bool wasMatched = isMatch(element);
                if (wasMatched)
                {
                    return true;
                }
            }

            return false;
        }

        public static IEnumerable<T> Filter<T>(
            this IEnumerable<T> source,
            Func<T, bool> shouldInclude)
        {
            foreach (T element in source)
            {
                bool shouldKeep = shouldInclude(element);
                if (shouldKeep)
                {
                    yield return element;
                }
            }
        }
    }
}
