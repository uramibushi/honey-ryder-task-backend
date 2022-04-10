using System;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク詳細
    /// </summary>
    public record TaskDetail
    {
        private const int MaxLength = 300;

        private TaskDetail(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// タスク詳細
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 指定した値でタスク詳細を生成します。
        /// </summary>
        /// <param name="value">指定値</param>
        /// <returns>
        /// タスク詳細
        /// </returns>
        public static TaskDetail ValueOf(string value)
        {
            Validate(value);
            return new TaskDetail(value);
        }

        private static void Validate(string value)
        {
            if (value.Length > MaxLength) throw new Exception($"タスク詳細は{MaxLength}文字以下である必要があります");
        }
    }
}
