using System;
using System.Linq;
using System.Collections.Generic;

namespace Wormhole
{
    public static class IEnumerableExtensions
    {
        public static TAcc ReduceWhile<T, TAcc>(
            this IEnumerable<T> data, Func<T, TAcc, Tuple<bool, TAcc>> reducerFunc, TAcc initial)
        {
            TAcc state = initial;
            foreach (var item in data)
            {
                var result = reducerFunc(item, state);
                if (result.Item1)
                    return result.Item2;
                state = result.Item2;
            }
            return state;
        }

        public static TAcc Reduce<T, TAcc>(this IEnumerable<T> data, Func<T, TAcc, TAcc> reducerFunc, TAcc initial) =>
            data.ReduceWhile((t, acc) => Tuple.Create(false, reducerFunc(t, acc)), initial);

        public static IEnumerable<TAcc> Scan<T,TAcc>(
            this IEnumerable<T> data, Func<T,TAcc,TAcc> reducerFunc, TAcc initial) {

            TAcc state = initial;
            foreach (var item in data) {
                var result = reducerFunc(item, state);
                yield return result;
                state = result;
            }
            yield break;
        }

        public static IEnumerable<IEnumerable<T>> ChunkBy<T, U>(this IEnumerable<T> data, Func<T, U> mapper)
        {
            if (data == null || !data.Any())
                yield break;

            var value = mapper(data.First());
            var acc = new List<T>();

            foreach (var item in data)
            {
                var result = mapper(item);

                if (result.Equals(value))
                    acc.Add(item);
                else
                {
                    value = result;
                    yield return acc;
                    acc = new List<T>();
                }
            }

            if (acc.Any())
                yield return acc;

            yield break;
        }

        public static IDictionary<TKey, int> Frequencies<T,TKey>(
            this IEnumerable<T> data, Func<T, TKey> keySelector) =>
                data.GroupBy(keySelector).ToDictionary(x => x.Key, x => x.Count());
    }
}
