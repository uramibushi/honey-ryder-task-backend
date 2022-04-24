namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク実績
    /// </summary>
    public record TaskAchievement
    {
        private TaskAchievement(DateTime startDate, DateTime endDate, decimal? time)
        {
            this.Period = TaskAchievementPeriod.ValueOf(startDate, endDate);
            this.Time = time.HasValue ? TaskAchievementTime.ValueOf(time.Value) : null;
        }

        /// <summary>
        /// タスク実績期間
        /// </summary>
        public TaskAchievementPeriod Period { get; }

        /// <summary>
        /// タスク実績時間
        /// </summary>
        public TaskAchievementTime? Time { get; }

        /// <summary>
        /// 指定の値でタスク実績を生成します。
        /// </summary>
        /// <param name="startDate">開始日</param>
        /// <param name="endDate">終了日</param>
        /// <param name="time">時間</param>
        /// <returns>
        /// タスク実績
        /// </returns>
        public static TaskAchievement ValueOf(DateTime startDate, DateTime endDate, decimal? time)
        {
            return new TaskAchievement(startDate, endDate, time);
        }
    }
}
