namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// 予定時間
    /// </summary>
    public class PlanTime
    {
        private PlanTime(decimal value)
        {
            this.Value = value;
        }

        /// <summary>
        /// 予定時間（h)
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// 指定した値で予定時間を生成します。
        /// </summary>
        /// <param name="value">指定値</param>
        /// <returns>
        /// 予定時間
        /// </returns>
        public static PlanTime ValueOf(decimal value)
        {
            return new PlanTime(value);
        }
    }
}
