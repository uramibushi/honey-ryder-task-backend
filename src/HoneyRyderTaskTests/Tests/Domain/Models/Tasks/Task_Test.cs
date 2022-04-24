using System;
using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// タスク - test
    /// </summary>
    public class Task_Test
    {
        [Fact(DisplayName = "[CreateNewTask()] 指定した値でタスクが作成される")]
        public void CreateNewTask_Test1()
        {
            // arrange
            var title = TaskTitle.ValueOf("タスクタイトル");
            var detail = TaskDetail.ValueOf("タスク詳細");
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 4, 1));

            // act
            var task = Task.CreateNewTask(title, detail, dueDate);

            // assert
            Assert.Equal(title, task.Title);
            Assert.Equal(detail, task.Detail);
            Assert.Equal(dueDate, task.DueDate);
        }

        [Fact(DisplayName = "[CreateNewTask()] 「タスクID」は新規採番される")]
        public void CreateNewTask_Test2()
        {
            // arrange
            var title = TaskTitle.ValueOf("タスクタイトル");
            var detail = TaskDetail.ValueOf("タスク詳細");
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 4, 1));

            // act
            var task = Task.CreateNewTask(title, detail, dueDate);

            // assert
            Assert.Equal(26, task.Id.Value.Length);
        }

        [Fact(DisplayName = "[CreateNewTask()] 「タスク状態」は 未着手 で作成される")]
        public void CreateNewTask_Test3()
        {
            // arrange
            var title = TaskTitle.ValueOf("タスクタイトル");
            var detail = TaskDetail.ValueOf("タスク詳細");
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 4, 1));

            // act
            var task = Task.CreateNewTask(title, detail, dueDate);

            // assert
            Assert.Equal(TaskStatus.ToDo, task.Status);
        }

        [Fact(DisplayName = "[CreateNewTask()] 「削除済み」は false で作成される")]
        public void CreateNewTask_Test4()
        {
            // arrange
            var title = TaskTitle.ValueOf("タスクタイトル");
            var detail = TaskDetail.ValueOf("タスク詳細");
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 4, 1));

            // act
            var task = Task.CreateNewTask(title, detail, dueDate);

            // assert
            Assert.False(task.IsDeleted.Value);
        }

        [Fact(DisplayName = "[CreateNewTask()] 「タスク予定」「タスク実績」は未設定で作成される")]
        public void CreateNewTask_Test5()
        {
            // arrange
            var title = TaskTitle.ValueOf("タスクタイトル");
            var detail = TaskDetail.ValueOf("タスク詳細");
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 4, 1));

            // act
            var task = Task.CreateNewTask(title, detail, dueDate);

            // assert
            Assert.Null(task.Schedule);
            Assert.Null(task.Achievement);
        }

        [Fact(DisplayName = "[Reconstruct()] 指定した値でタスクを再構築できる")]
        public void Reconstruct_Test1()
        {
            // arrange
            var id = TaskId.NewId();
            var status = TaskStatus.Done;
            var title = TaskTitle.ValueOf("タスクタイトル");
            var detail = TaskDetail.ValueOf("タスク詳細");
            var dueDate = TaskDueDate.ValueOf(new DateTime(2022, 4, 1));
            var schedule = TaskSchedule.ValueOf(
                new DateTime(2022, 4, 1),
                new DateTime(2022, 4, 2),
                16M);
            var achievement = TaskAchievement.ValueOf(
                new DateTime(2022, 4, 2),
                new DateTime(2022, 4, 4),
                24M);
            var isDeleted = IsDeleted.ValueOf(false);

            // act
            var task = Task.Reconstruct(
                id,
                title,
                status,
                detail,
                dueDate,
                schedule,
                achievement,
                isDeleted);

            // assert
            Assert.Equal(id, task.Id);
            Assert.Equal(title, task.Title);
            Assert.Equal(status, task.Status);
            Assert.Equal(detail, task.Detail);
            Assert.Equal(dueDate, task.DueDate);
            Assert.Equal(schedule, task.Schedule);
            Assert.Equal(achievement, task.Achievement);
            Assert.Equal(isDeleted, task.IsDeleted);
        }
    }
}
