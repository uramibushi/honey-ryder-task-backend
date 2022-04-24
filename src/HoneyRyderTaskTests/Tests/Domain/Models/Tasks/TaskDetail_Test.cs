using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// タスク詳細 - test
    /// </summary>
    public class TaskDetail_Test
    {
        [Fact(DisplayName = "[ValueOf()] 指定した値でタスク詳細を生成できる")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = new string('あ', 300);

            // act
            var taskDetail = TaskDetail.ValueOf(value);

            // assert
            Assert.Equal(value, taskDetail.Value);
        }

        [Fact(DisplayName = "[ValueOf()] タスク詳細は300文字以下である必要がある")]
        public void ValueOf_Test2()
        {
            // arrange
            var value = new string('あ', 301);

            // act
            var target = () => TaskDetail.ValueOf(value);

            // assert
            var ex = Assert.Throws<Exception>(target);
            Assert.Equal($"タスク詳細は300文字以下である必要があります", ex.Message);
        }

        [Fact(DisplayName = "等価性を持っている")]
        public void Equivalence_Test()
        {
            // arrange
            var value1 = TaskDetail.ValueOf("12345");
            var value2 = TaskDetail.ValueOf("12345");

            // act
            var actual = value1 == value2;

            // assert
            Assert.True(actual);
        }
    }
}
