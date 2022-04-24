using System;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスクタイトル
    /// </summary>
    public record TaskTitle
    {
        private const int MaxLength = 30;

        private TaskTitle(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// タスクタイトル
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 指定した値でタスクタイトルを生成します。
        /// </summary>
        /// <param name="value">指定値</param>
        /// <returns>
        /// タスクタイトル
        /// </returns>
        public static TaskTitle ValueOf(string value)
        {
            Validate(value);
            return new TaskTitle(value);
        }

        private static void Validate(string value)
        {
            if (value.Length > MaxLength) throw new Exception($"タスクタイトルは{MaxLength}文字以下である必要があります");
        }

    }
}
