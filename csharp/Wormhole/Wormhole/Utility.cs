using System;
using System.Linq;

namespace Wormhole
{
    public static class Utility
    {
        /// <summary>
        /// Returns the input value.
        /// </summary>
        /// <returns>The identity.</returns>
        /// <param name="val">Value.</param>
        /// <typeparam name="T">The `Type` of the input value.</typeparam>
        public static T Identity<T>(T val) => val;

        /// <summary>
        /// Increment an integer by 1.
        /// </summary>
        /// <returns>The incremented value.</returns>
        /// <param name="i">Value to increment.</param>
        public static int Inc(int i) => i + 1;

        /// <summary>
        /// Decrement an integer by 1.
        /// </summary>
        /// <returns>The decremented value.</returns>
        /// <param name="i">Value to decrement.</param>
        public static int Dec(int i) => i - 1;

        /// <summary>
        /// Juxtapose the specified functions.
        /// </summary>
        /// <returns>A function that executes</returns>
        /// <param name="funcs">Array of functions</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="U">The 2nd type parameter.</typeparam>
        public static Func<T, U[]> Juxt<T, U>(Func<T, U>[] funcs) =>
            x => funcs.Select(f => f(x)).ToArray();

        public static Func<T1, T2, U[]> Juxt<T1, T2, U>(Func<T1, T2, U>[] funcs) =>
            (x,y) => funcs.Select(f => f(x,y)).ToArray();

        public static Func<T1, T2, T3, U[]> Juxt<T1, T2, T3, U>(Func<T1, T2, T3, U>[] funcs) =>
            (x, y, z) => funcs.Select(f => f(x, y, z)).ToArray();
    }
}
