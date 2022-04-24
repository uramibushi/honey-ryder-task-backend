namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク予定
    /// </summary>
    public class TaskSchedule
    {
        private TaskSchedule(DateTime startDate, DateTime endDate, decimal? time)
        {
            this.Period = TaskSchedulePeriod.ValueOf(startDate, endDate);
            this.Time = time.HasValue ? TaskScheduleTime.ValueOf(time.Value) : null;
        }

        /// <summary>
        /// タスク予定期間
        /// </summary>
        public TaskSchedulePeriod Period { get; }

        /// <summary>
        /// タスク予定時間
        /// </summary>
        public TaskScheduleTime? Time { get; }

        /// <summary>
        /// 指定の値でタスク予定を生成します。
        /// </summary>
        /// <param name="startDate">開始日</param>
        /// <param name="endDate">終了日</param>
        /// <param name="time">時間</param>
        /// <returns>
        /// タスク予定
        /// </returns>
        public static TaskSchedule ValueOf(DateTime startDate, DateTime endDate, decimal? time)
        {
            return new TaskSchedule(startDate, endDate, time);
        }
    }
}
