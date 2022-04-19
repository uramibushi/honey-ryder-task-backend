using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// タスク期限 - test
    /// </summary>
    public class TaskDueDate_Test
    {
        [Fact(DisplayName = "[ValueOf(value)] 指定した値でタスク期限を生成できる")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = new DateTime(2020, 1, 1);

            // act
            var taskDueDate = TaskDueDate.ValueOf(value);

            // assert
            Assert.Equal(value, taskDueDate.Value);
        }

        [Fact(DisplayName = "[ValueOf(value)] 指定日時の時間部分は丸められて日付のみになる")]
        public void ValueOf_Test2()
        {
            // arrange
            var value = new DateTime(2020, 1, 1, 11, 12, 13);

            // act
            var taskDueDate = TaskDueDate.ValueOf(value);

            // asserts
            Assert.NotEqual(value, taskDueDate.Value);
            Assert.Equal(value.Date, taskDueDate.Value);
        }
    }
}
