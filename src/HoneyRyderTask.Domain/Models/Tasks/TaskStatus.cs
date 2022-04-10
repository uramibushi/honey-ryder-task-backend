namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク状態
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// TODO（未着手）
        /// </summary>
        ToDo,

        /// <summary>
        /// Doing（着手）
        /// </summary>
        Doing,

        /// <summary>
        /// Done（完了）
        /// </summary>
        Done,
    }
}
