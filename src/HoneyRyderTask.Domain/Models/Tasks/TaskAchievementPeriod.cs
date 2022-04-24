namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク実績期間
    /// </summary>
    public record TaskAchievementPeriod
    {
        private TaskAchievementPeriod(DateTime startDate, DateTime? endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        /// <summary>
        /// タスク実績開始日
        /// </summary>
        public DateTime StartDate { get; }

        /// <summary>
        /// タスク実績終了日
        /// </summary>
        public DateTime? EndDate { get; }

        /// <summary>
        /// 指定した値でタスク実績期間を生成します。
        /// </summary>
        /// <param name="startDate">実績開始日</param>
        /// <param name="endDate">実績終了日</param>
        /// <returns>タスク実績期間</returns>
        public static TaskAchievementPeriod ValueOf(DateTime startDate, DateTime? endDate)
        {
            var roundedStartDate = RoundDate(startDate);
            DateTime? roundedEndDate = endDate.HasValue ? RoundDate(endDate.Value) : null;
            Validate(roundedStartDate, roundedEndDate);
            return new TaskAchievementPeriod(roundedStartDate, roundedEndDate);
        }

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

        /// <summary>
        /// 値を検証します。
        /// タスク実績開始日と終了日の
        /// </summary>
        /// <param name="startDate">実績開始日</param>
        /// <param name="endDate">実績終了日</param>
        /// <exception cref="Exception">日付に矛盾がある場合、例外を投げます</exception>
        private static void Validate(DateTime startDate, DateTime? endDate)
        {
            if (!endDate.HasValue) return;
            if (startDate > endDate) throw new Exception("開始日と終了日の前後関係に誤りがあります。");
        }
    }
}
