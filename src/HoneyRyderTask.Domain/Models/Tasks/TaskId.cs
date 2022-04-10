using HoneyRyderTask.Domain.Models.Shared;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスクID
    /// タスクを一位に識別します。
    /// </summary>
    public record TaskId
    {
        private const int Length = 26;

        private TaskId(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// タスクID
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 指定された値でタスクIDを生成します。
        /// </summary>
        /// <param name="value">指定値</param>
        /// <returns>タスクID</returns>
        public static TaskId ValueOf(string value)
        {
            Validate(value);
            return new TaskId(value);
        }

        /// <summary>
        /// ULID形式の新しいタスクIDを生成します。
        /// </summary>
        /// <returns>
        /// 新しく生成したタスクIDを返します。
        /// </returns>
        public static TaskId NewId()
        {
            return new TaskId(ULID.NewULID().Value);
        }

        private static void Validate(string value)
        {
            if (value.Length != Length) throw new Exception($"タスクIDは{Length}文字である必要があります。");
        }
    }
}
