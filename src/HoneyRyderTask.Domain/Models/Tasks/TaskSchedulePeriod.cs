namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク予定期間
    /// </summary>
    public record TaskSchedulePeriod
    {
        private TaskSchedulePeriod(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        /// <summary>
        /// タスク予定開始日
        /// </summary>
        public DateTime StartDate { get; }

        /// <summary>
        /// タスク予定終了日
        /// </summary>
        public DateTime EndDate { get; }

        /// <summary>
        /// 指定した値でタスク予定期間を生成します。
        /// </summary>
        /// <param name="startDate">予定開始日</param>
        /// <param name="endDate">予定終了日</param>
        /// <returns>タスク予定期間</returns>
        public static TaskSchedulePeriod ValueOf(DateTime startDate, DateTime endDate)
        {
            var roundedStartDate = RoundDate(startDate);
            var roundedEndDate = RoundDate(endDate);
            Validate(roundedStartDate, roundedEndDate);
            return new TaskSchedulePeriod(roundedStartDate, roundedEndDate);
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
        /// タスク予定開始日と終了日の
        /// </summary>
        /// <param name="startDate">予定開始日</param>
        /// <param name="endDate">予定終了日</param>
        /// <exception cref="Exception">日付に矛盾がある場合、例外を投げます</exception>
        private static void Validate(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate) throw new Exception("開始日と終了日の前後関係に誤りがあります。");
        }
    }
}
