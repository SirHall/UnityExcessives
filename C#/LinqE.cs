using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;


namespace Excessives.LinqE
{
    public static class LinqE
    {
        #region Loops

        //Foreach, no return
        public static IEnumerable<TSource> ForEach<TSource>(
            this IEnumerable<TSource> enumerable,
            Action<TSource> action
        )
        {
            for (int i = 0; i < enumerable.Count(); i++)
            {
                action(enumerable.ElementAt(i));
            }
            return enumerable;
        }

        //For, no return
        public static IEnumerable<TSource> For<TSource>(
            this IEnumerable<TSource> enumerable,
            Action<TSource, int> action
        )
        {
            for (int i = 0; i < enumerable.Count(); i++)
            {
                action(enumerable.ElementAt(i), i);
            }
            return enumerable;
        }

        //Foreach, return
        public static IEnumerable<TSource> ForEach<TSource>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, TSource> action
        )
        {
            for (int i = 0; i < enumerable.Count(); i++)
            {
                enumerable.ToArray()[i] = action(enumerable.ElementAt(i));
            }
            return enumerable.AsEnumerable();
        }

        //For, return
        public static IEnumerable<TSource> For<TSource>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, int, TSource> action
        )
        {
            for (int i = 0; i < enumerable.Count(); i++)
            {
                enumerable.ToArray()[i] = action(enumerable.ElementAt(i), i);
            }
            return enumerable.AsEnumerable();
        }

        #endregion

        #region Loops Backward

        //Foreach, no return
        public static IEnumerable<TSource> ForEachBack<TSource>(
            this IEnumerable<TSource> enumerable,
            Action<TSource> action
        )
        {
            for (int i = enumerable.Count() - 1; i >= 0; i--)
            {
                action(enumerable.ElementAt(i));
            }
            return enumerable;
        }

        //For, no return
        public static IEnumerable<TSource> ForBack<TSource>(
            this IEnumerable<TSource> enumerable,
            Action<TSource, int> action
        )
        {
            for (int i = enumerable.Count() - 1; i >= 0; i--)
            {
                action(enumerable.ElementAt(i), i);
            }
            return enumerable;
        }

        //Foreach, return
        public static IEnumerable<TSource> ForEachBack<TSource>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, TSource> action
        )
        {
            for (int i = enumerable.Count() - 1; i >= 0; i--)
            {
                enumerable.ToArray()[i] = action(enumerable.ElementAt(i));
            }
            return enumerable.AsEnumerable();
        }

        //For, return
        public static IEnumerable<TSource> ForBack<TSource>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, int, TSource> action
        )
        {
            for (int i = enumerable.Count() - 1; i >= 0; i--)
            {
                enumerable.ToArray()[i] = action(enumerable.ElementAt(i), i);
            }
            return enumerable.AsEnumerable();
        }

        #endregion

        #region Get Sub Array
        public static IEnumerable<TSource> SubArray<TSource>(
            this IEnumerable<TSource> enumerable,
            int startIndex, int length
        )
        {
            TSource[] final = new TSource[length];

            Array.Copy(enumerable.ToArray(), startIndex, final, 0, length);

            return final.AsEnumerable();
        }
        #endregion

        //		//Repeat, return
        //		public static IEnumerable<TSource> RepeatReplace<TSource> (
        //			this IEnumerable<TSource> enumerable,
        //			int iterations,
        //			Action<TSource, int> action
        //		)
        //		{
        //			enumerable.
        //
        //			for (int i = 0; i < iterations; i++) {
        //				action (enumerable.ElementAt (i), i);
        //			}
        //			return enumerable.AsEnumerable ();
        //		}
    }
}
