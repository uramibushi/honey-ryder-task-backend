using HoneyRyderTask.Domain.Helpers.Extensions;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク予定時間
    /// </summary>
    public record TaskScheduleTime
    {
        private TaskScheduleTime(decimal value)
        {
            this.Value = value;
        }

        /// <summary>
        /// タスク予定時間（h)
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// 指定した値でタスク予定時間を生成します。
        /// </summary>
        /// <param name="value">指定値</param>
        /// <returns>
        /// タスク予定時間
        /// </returns>
        public static TaskScheduleTime ValueOf(decimal value)
        {
            var adjustedValue = AdjustValue(value);
            return new TaskScheduleTime(adjustedValue);
        }

        /// <summary>
        /// 値を調整する。
        /// タスク予定時間の小数部は２桁までとする。３桁以上は切り捨てを行う。
        /// </summary>
        /// <param name="value">調整を行う値。</param>
        /// <returns>調整後の値</returns>
        private static decimal AdjustValue(decimal value)
        {
            return value.Truncate(2);
        }
    }
}
