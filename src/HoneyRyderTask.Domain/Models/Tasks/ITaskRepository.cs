namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク リポジトリ
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// タスクをリポジトリに追加します。
        /// </summary>
        /// <param name="task">タスク</param>
        void Add(Task task);
    }
}
