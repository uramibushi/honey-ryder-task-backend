using System;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.UseCase.Services.Tasks.CreateNewTask;
using Moq;
using Xunit;

namespace HoneyRyderTaskTests.Tests.UseCase.Services.Tasks.CreateNewTask
{
    /// <summary>
    /// タスクを新規作成する（ユースケース） - test
    /// </summary>
    public class CreateNewTaskUseCase_Test
    {
        [Fact(DisplayName = "[Execute()] 指定した値のタスクがリポジトリに保存される")]
        public void Execute_Test1()
        {
            // arrange
            Task? savedTask = null;
            var mock = new Mock<ITaskRepository>();
            mock.Setup(repository => repository.Add(It.IsAny<Task>()))
                .Callback((Task task) => savedTask = task);
            var taskRepository = mock.Object;
            var usecase = new CreateNewTaskUseCase(taskRepository);
            var command = new CreateNewTaskCommand(
                title: "タスクタイトル",
                detail: "タスク詳細",
                dueDate: new DateTime(2022, 4, 1));

            // act
            usecase.Execute(command);

            // assert
            Assert.Equal(command.Title, savedTask?.Title.Value);
            Assert.Equal(command.Detail, savedTask?.Detail?.Value);
            Assert.Equal(command.DueDate, savedTask?.DueDate?.Value);
        }
    }
}
