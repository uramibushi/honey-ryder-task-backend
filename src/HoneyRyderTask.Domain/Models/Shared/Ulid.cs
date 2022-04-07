using System;
namespace HoneyRyderTask.Domain.Models.Shared
{
	/// <summary>
	/// ULID（Universally Unique Lexicographically Sortable Identifier）
	/// 重複しない一意なIDを生成し、かつミリ秒単位で時系列ソートができる値
	/// </summary>
	public class ULID
	{
		private ULID(string value)
		{
			this.Value = value;
		}

		public string Value { get; }

		/// <summary>
        /// 新しいULIDを採番します。
        /// </summary>
        /// <returns></returns>
		public static ULID NewULID()
        {
			return new ULID(NUlid.Ulid.NewUlid().ToString());
		}

		/// <summary>
        /// 指定した値がULIDであるかどうかを返します。
        /// ULIDであればtrue。それ以外はfalseを返します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
		public static bool IsULID(string value)
        {
			NUlid.Ulid result;
			return NUlid.Ulid.TryParse(value, out result);
        }
	}
}

