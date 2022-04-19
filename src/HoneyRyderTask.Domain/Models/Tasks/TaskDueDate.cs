namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク期限
    /// </summary>
    public record TaskDueDate
    {
        private TaskDueDate(DateTime value)
        {
            this.Value = value;
        }

        /// <summary>
        /// 指定した値でタスク期限を生成します。
        /// </summary>
        /// <param name="value">指定値</param>
        /// <returns>
        /// タスク期限
        /// </returns>
        public static TaskDueDate ValueOf(DateTime value)
        {
            var roundedDate = RoundDate(value);
            return new TaskDueDate(roundedDate);
        }

        /// <summary>
        /// タスク期限s
        /// </summary>
        public DateTime Value { get; }

        /// <summary>
        /// 日付を丸めます。
        /// 時間は切り捨てして日付のみにします。
        /// </summary>
        /// <param name="value">日付</param>
        /// <returns>丸めた結果の日付</returns>
        private static DateTime RoundDate(DateTime value)
        {
            return value.Date;
        }
    }
}
