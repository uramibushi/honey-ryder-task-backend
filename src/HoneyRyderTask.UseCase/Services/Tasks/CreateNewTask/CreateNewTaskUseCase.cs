using System.Transactions;
using HoneyRyderTask.Domain.Models.Tasks;
using Task = HoneyRyderTask.Domain.Models.Tasks.Task;

namespace HoneyRyderTask.UseCase.Services.Tasks.CreateNewTask
{
    /// <summary>
    /// タスクを新規作成します。
    /// </summary>
    public class CreateNewTaskUseCase
    {
        private readonly ITaskRepository taskRepository;

        /// <summary>
        /// タスクを新規作成します。
        /// </summary>
        /// <param name="taskRepository">タスクリポジトリ</param>
        public CreateNewTaskUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        /// <summary>
        /// タスクを新規作成します。
        /// </summary>
        /// <param name="command">コマンド</param>
        public void Execute(CreateNewTaskCommand command)
        {
            using (var scope = new TransactionScope())
            {
                var title = TaskTitle.ValueOf(command.Title);
                var detail = command.Detail != null ? TaskDetail.ValueOf(command.Detail) : null;
                var dueDate = command.DueDate != null ? TaskDueDate.ValueOf(command.DueDate.Value) : null;

                var task = Task.CreateNewTask(title, detail, dueDate);

                this.taskRepository.Add(task);

                scope.Complete();
            }
        }
    }
}
