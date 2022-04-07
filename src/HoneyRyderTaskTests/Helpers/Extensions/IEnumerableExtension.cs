using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HoneyRyderTaskTests.Helpers.Extensions
{
	/// <summary>
    /// IEnumerable（拡張メソッド）
    /// </summary>
	public static class IEnumerableExtension
	{
		/// <summary>
        /// リスト内に重複する要素があるかどうかを返します。」
        /// 重複する要素があれば true。なければ false を返します。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="list"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
		public static bool IsDuplicated<T1,T2>(this IEnumerable<T1> list, Func<T1,T2> keySelector)
        {
			return list.GroupBy(keySelector).Any(g => g.Count() > 1);
        }
	}
}

