namespace HoneyRyderTask.Domain.Helpers.Extensions
{
    /// <summary>
    /// decimal（拡張メソッド）
    /// </summary>
    public static class DecimalExtension
    {
        /// <summary>
        /// 小数値の切り捨てを行います
        /// </summary>
        /// <param name="d">切り捨て対象の10進数</param>
        /// <param name="decimals">切り捨て結果の数値の小数点以下の桁数を指定します</param>
        /// <returns>切り捨て結果の値</returns>
        public static decimal Truncate(this decimal d, int decimals)
        {
            // Truncateメソッドでは切り捨てを行う小数桁数を指定できない為、
            // 桁を左シフト -> 切り捨て -> シフトした桁を右シフトして戻す。
            // 例) 123.456から小数桁2桁の位置で切り捨てを行う場合。
            // 12345.6 -> 12345 -> 123.45
            var shiftedValue = d.ShiftLeft(decimals);
            var truncatedValue = decimal.Truncate(shiftedValue);
            return truncatedValue.ShiftRight(decimals);
        }

        /// <summary>
        /// 桁を左にシフトします。
        /// </summary>
        /// <param name="d">シフト対象の10進数</param>
        /// <param name="shiftCount">桁移動数</param>
        /// <returns>シフト結果の値</returns>
        public static decimal ShiftLeft(this decimal d, int shiftCount)
        {
            return d * (decimal)Math.Pow(10, shiftCount);
        }

        /// <summary>
        /// 桁を右にシフトします。
        /// </summary>
        /// <param name="d">シフト対象の10進数</param>
        /// <param name="shiftCount">桁移動数</param>
        /// <returns>シフト結果の値</returns>
        public static decimal ShiftRight(this decimal d, int shiftCount)
        {
            return d / (decimal)Math.Pow(10, shiftCount);
        }
    }
}
