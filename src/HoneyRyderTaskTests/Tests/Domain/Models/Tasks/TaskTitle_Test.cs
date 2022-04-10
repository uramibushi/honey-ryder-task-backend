using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// タスクタイトル - test
    /// </summary>
    public class TaskTitle_Test
    {
        [Fact(DisplayName = "[ValueOf()] 指定した値でタスクタイトルを生成できる")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０";

            // act
            var taskTitle = TaskTitle.ValueOf(value);

            // assert
            Assert.Equal(value, taskTitle.Value);
        }

        [Fact(DisplayName = "[ValueOf()] タスクタイトルは30文字以下である必要がある")]
        public void ValueOf_Test2()
        {
            // arrange
            var value = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０１";

            // act
            var target = () => TaskTitle.ValueOf(value);

            // assert
            var ex = Assert.Throws<Exception>(target);
            Assert.Equal($"タスクタイトルは30文字以下である必要があります", ex.Message);
        }
    }
}
