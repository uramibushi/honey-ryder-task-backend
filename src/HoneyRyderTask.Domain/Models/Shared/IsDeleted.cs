namespace HoneyRyderTask.Domain.Models.Shared
{
    /// <summary>
    /// 削除されているかを表します。
    /// 削除されていれば true。それ以外は false。
    /// </summary>
    public record IsDeleted
    {
        private IsDeleted(bool value)
        {
            this.Value = value;
        }

        /// <summary>
        /// 削除されているかを表します。
        /// 削除されていれば true。それ以外は false。
        /// </summary>
        public bool Value { get; }

        /// <summary>
        /// 削除されているかの値を生成します。
        /// </summary>
        /// <param name="value">指定値</param>
        /// <returns>生成した値を返します。</returns>
        public static IsDeleted ValueOf(bool value)
        {
            return new IsDeleted(value);
        }

        /// <summary>
        /// IsDeletedの値とboole値が一致しているかの真偽値を返します。
        /// 一致している場合は true。一致していない場合は false を返します。
        /// </summary>
        /// <param name="isDeleted">IsDeleted</param>
        /// <param name="boolValue">Bool値</param>
        /// <returns>
        /// IsDeletedの値とbool値が一致している場合は true。一致していない場合は false を返します。
        /// </returns>
        public static bool operator ==(IsDeleted isDeleted, bool boolValue)
        {
            return isDeleted.Value == boolValue;
        }

        /// <summary>
        /// IsDeletedの値とboole値が一致していないかの真偽値を返します。
        /// 一致していない場合は true。一致している場合は false を返します。
        /// </summary>
        /// <param name="isDeleted">IsDeleted</param>
        /// <param name="boolValue">Bool値</param>
        /// <returns>
        /// IsDeletedの値とbool値が一致していない場合は true。一致している場合は false を返します。
        /// </returns>
        public static bool operator !=(IsDeleted isDeleted, bool boolValue)
        {
            return isDeleted.Value != boolValue;
        }
    }
}
