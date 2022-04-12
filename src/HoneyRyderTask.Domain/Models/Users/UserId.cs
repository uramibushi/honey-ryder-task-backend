using HoneyRyderTask.Domain.Models.Shared;

namespace HoneyRyderTask.Domain.Models.Users
{
    /// <summary>
    /// ユーザーID
    /// ユーザーを一位に識別します。
    /// </summary>
    public record UserId
    {
        private const int Length = 26;

        private UserId(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// ユーザーID
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 指定された値でユーザーIDを生成します。
        /// </summary>
        /// <param name="value">指定値</param>
        /// <returns>ユーザーID</returns>
        public static UserId ValueOf(string value)
        {
            Validate(value);
            return new UserId(value);
        }

        /// <summary>
        /// ULID形式の新しいユーザーIDを生成します。
        /// </summary>
        /// <returns>
        /// 新しく生成したユーザーIDを返します。
        /// </returns>
        public static UserId NewId()
        {
            return new UserId(ULID.NewULID().Value);
        }

        private static void Validate(string value)
        {
            if (value.Length != Length) throw new Exception($"ユーザーIDは{Length}文字である必要があります。");
        }
    }
}
