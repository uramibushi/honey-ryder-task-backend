using HoneyRyderTask.Domain.Models.Shared;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク - entity
    /// </summary>
    public class Task
    {
        private Task(
            TaskId id,
            TaskTitle title,
            TaskStatus status,
            TaskDetail? detail,
            TaskDueDate? dueDate,
            TaskSchedule? schedule,
            TaskAchievement? achievement,
            IsDeleted isDeleted)
        {
            this.Id = id;
            this.Title = title;
            this.Status = status;
            this.Detail = detail;
            this.DueDate = dueDate;
            this.Schedule = schedule;
            this.Achievement = achievement;
            this.IsDeleted = isDeleted;
        }

        /// <summary>
        /// タスクID
        /// </summary>
        public TaskId Id { get; }

        /// <summary>
        /// タスクタイトル
        /// </summary>
        public TaskTitle Title { get; }

        /// <summary>
        /// タスク状態
        /// </summary>
        public TaskStatus Status { get; }

        /// <summary>
        /// タスク詳細
        /// </summary>
        public TaskDetail? Detail { get; }

        /// <summary>
        /// タスク期限
        /// </summary>
        public TaskDueDate? DueDate { get; }

        /// <summary>
        /// タスク予定
        /// </summary>
        public TaskSchedule? Schedule { get; }

        /// <summary>
        /// タスク実績
        /// </summary>
        public TaskAchievement? Achievement { get; }

        /// <summary>
        /// 削除済みであるかを示す値
        /// </summary>
        public IsDeleted IsDeleted { get; }

        /// <summary>
        /// 新しいタスクを作成します。
        /// </summary>
        /// <param name="title">タスクタイトル</param>
        /// <param name="detail">タスク詳細</param>
        /// <param name="dueDate">タスク期限</param>
        /// <returns>
        /// 新しく作成したタスクを返します。
        /// </returns>
        public static Task CreateNewTask(
            TaskTitle title,
            TaskDetail detail,
            TaskDueDate dueDate)
        {
            return new Task(
                id: TaskId.NewId(),
                title: title,
                status: TaskStatus.ToDo,
                detail: detail,
                dueDate: dueDate,
                schedule: null,
                achievement: null,
                isDeleted: IsDeleted.ValueOf(false));
        }

        /// <summary>
        /// タスクを再構築します。
        /// </summary>
        /// <param name="id">タスクID</param>
        /// <param name="title">タスクタイトル</param>
        /// <param name="status">タスク状態</param>
        /// <param name="detail">タスク詳細</param>
        /// <param name="dueDate">タスク期限</param>
        /// <param name="schedule">タスク予定</param>
        /// <param name="achievement">タスク実績</param>
        /// <param name="isDeleted">削除済み</param>
        /// <returns>
        /// 再構築したタスクを返します。
        /// </returns>
        public static Task Reconstruct(
            TaskId id,
            TaskTitle title,
            TaskStatus status,
            TaskDetail? detail,
            TaskDueDate? dueDate,
            TaskSchedule? schedule,
            TaskAchievement? achievement,
            IsDeleted isDeleted)
        {
            return new Task(
                id: id,
                title: title,
                status: status,
                detail: detail,
                dueDate: dueDate,
                schedule: schedule,
                achievement: achievement,
                isDeleted: isDeleted);
        }
    }
}
