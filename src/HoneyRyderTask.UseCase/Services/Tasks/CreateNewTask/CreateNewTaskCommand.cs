namespace HoneyRyderTask.UseCase.Services.Tasks.CreateNewTask
{
    /// <summary>
    /// タスクの新規作成に使用するコマンド
    /// </summary>
    public class CreateNewTaskCommand
    {
        /// <summary>
        /// タスクの新規作成に使用するコマンド
        /// </summary>
        /// <param name="title">タスクタイトル</param>
        /// <param name="detail">タスク詳細</param>
        /// <param name="dueDate">タスク期限</param>
        public CreateNewTaskCommand(
            string title,
            string? detail,
            DateTime? dueDate)
        {
            this.Title = title;
            this.Detail = detail;
            this.DueDate = dueDate;
        }

        /// <summary>
        /// タスクタイトル
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// タスク詳細
        /// </summary>
        public string? Detail { get; }

        /// <summary>
        /// タスク期限
        /// </summary>
        public DateTime? DueDate { get; }
    }
}
