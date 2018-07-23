using System.Collections.Generic;
using System.Linq;
using System;


namespace Excessives.LinqE
{
	/* {TODO}
     * Fix indentations
     * Comment obscure code (Fairly obvious)
     */

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
		public static IEnumerable<TSource> ForEachR<TSource>(
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
		public static IEnumerable<TSource> ForR<TSource>(
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
		/// <summary>
		/// Creates a sub array from one passed to it
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="enumerable"></param>
		/// <param name="startIndex"></param>
		/// <param name="length"></param>
		/// <returns></returns>
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

		#region Min
		//float
		public static TSource Minimum<TSource>(
		  this IEnumerable<TSource> enumerable,
		  Func<TSource, float> selector
	  )
		{
			TSource minimum = default(TSource);

			float minimumVal = float.MaxValue;

			float testVal;

			enumerable.ForEach(
				n =>
				{
					testVal = selector(n);
					if (testVal < minimumVal)
					{
						minimum = n;
						minimumVal = testVal;
					}
				}
				);

			return minimum;
		}

		//int
		public static TSource Minimum<TSource>(
		  this IEnumerable<TSource> enumerable,
		  Func<TSource, int> selector
	  )
		{
			TSource minimum = default(TSource);

			int minimumVal = int.MaxValue;

			int testVal;

			enumerable.ForEach(
				n =>
				{
					testVal = selector(n);
					if (testVal < minimumVal)
					{
						minimum = n;
						minimumVal = testVal;
					}
				}
				);

			return minimum;
		}

		//double
		public static TSource Minimum<TSource>(
		  this IEnumerable<TSource> enumerable,
		  Func<TSource, double> selector
	  )
		{
			TSource minimum = default(TSource);

			double minimumVal = double.MaxValue;

			double testVal;

			enumerable.ForEach(
				n =>
				{
					testVal = selector(n);
					if (testVal < minimumVal)
					{
						minimum = n;
						minimumVal = testVal;
					}
				}
				);

			return minimum;
		}

		//byte
		public static TSource Minimum<TSource>(
		  this IEnumerable<TSource> enumerable,
		  Func<TSource, byte> selector
	  )
		{
			TSource minimum = default(TSource);

			byte minimumVal = byte.MaxValue;

			byte testVal;

			enumerable.ForEach(
				n =>
				{
					testVal = selector(n);
					if (testVal < minimumVal)
					{
						minimum = n;
						minimumVal = testVal;
					}
				}
				);

			return minimum;
		}

		#endregion

		#region Max
		//float
		public static TSource Maximum<TSource>(
		 this IEnumerable<TSource> enumerable,
		 Func<TSource, float> selector
	  )
		{
			TSource maximum = default(TSource);

			float maximumVal = float.MaxValue;

			float testVal;

			enumerable.ForEach(
				n =>
				{
					testVal = selector(n);
					if (testVal > maximumVal)
					{
						maximum = n;
						maximumVal = testVal;
					}
				}
				);

			return maximum;
		}

		//int
		public static TSource Maximum<TSource>(
		 this IEnumerable<TSource> enumerable,
		 Func<TSource, int> selector
	  )
		{
			TSource maximum = default(TSource);

			int maximumVal = int.MaxValue;

			int testVal;

			enumerable.ForEach(
				n =>
				{
					testVal = selector(n);
					if (testVal > maximumVal)
					{
						maximum = n;
						maximumVal = testVal;
					}
				}
				);

			return maximum;
		}

		//double
		public static TSource Maximum<TSource>(
		 this IEnumerable<TSource> enumerable,
		 Func<TSource, double> selector
	  )
		{
			TSource maximum = default(TSource);

			double maximumVal = double.MaxValue;

			double testVal;

			enumerable.ForEach(
				n =>
				{
					testVal = selector(n);
					if (testVal > maximumVal)
					{
						maximum = n;
						maximumVal = testVal;
					}
				}
				);

			return maximum;
		}

		//byte
		public static TSource Maximum<TSource>(
		 this IEnumerable<TSource> enumerable,
		 Func<TSource, byte> selector
	  )
		{
			TSource maximum = default(TSource);

			byte maximumVal = byte.MaxValue;

			byte testVal;

			enumerable.ForEach(
				n =>
				{
					testVal = selector(n);
					if (testVal > maximumVal)
					{
						maximum = n;
						maximumVal = testVal;
					}
				}
				);

			return maximum;
		}

		#endregion

		#region Misc

		/// <summary>
		/// Returns the first element in an array that fits a given criteria
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="enumerable"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		public static TSource First<TSource>(
			this IEnumerable<TSource> enumerable,
			Func<TSource, bool> selector
			)
		{
			using (var enumerator = enumerable.GetEnumerator())
			{
				while (enumerator.MoveNext())
					if (selector(enumerator.Current))
						return enumerator.Current;
				return default(TSource);
			}
		}

		/// <summary>
		/// Finds the index of a given object in an enumerable
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="enumerable"></param>
		/// <param name="instance"></param>
		/// <returns></returns>
		public static int FindIndex<TSource>(
			this IEnumerable<TSource> enumerable,
			TSource instance
			)
		{
			int i = 0;
			var enumerator = enumerable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Equals(instance))
					return i;
				i++;
			}

			return -1; //Could not find it in the array
		}

		#endregion

		#region Random

		/// <summary>
		/// Randomly picks an element from an enumerable
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="enumerable"></param>
		/// <returns></returns>
		public static TSource Pick<TSource>(
			this IEnumerable<TSource> enumerable
		)
		{
			return CryptoRand.Pick(enumerable.ToArray());
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
