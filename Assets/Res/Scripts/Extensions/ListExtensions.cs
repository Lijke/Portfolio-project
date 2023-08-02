

using System.Linq;

namespace System.Collections.Generic{
    public static class ListExtensions{
        public static T GetRandom<T>(this IList<T> list) {
            if (list.Count == 0) {
                return default(T);
            }

            return list[UnityEngine.Random.Range(0, list.Count)];
        }
    }
}