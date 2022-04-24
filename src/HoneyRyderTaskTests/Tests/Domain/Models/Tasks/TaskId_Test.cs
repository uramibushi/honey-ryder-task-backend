using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// タスクID - test
    /// </summary>
    public class TaskId_Test
    {
        [Fact(DisplayName = "[ValueOf()] 指定した値でタスクIDが生成される")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = "12345678901234567890123456";

            // act
            var id = TaskId.ValueOf(value);

            // assert
            Assert.Equal(value, id.Value);
        }

        [Theory(DisplayName = "[ValueOf()] 26文字以外の値を渡すと例外が発生する")]
        [InlineData("1234567890123456789012345")]
        [InlineData("123456789012345678901234567")]
        public void ValueOf_Test2(string value)
        {
            // act
            var target = () => TaskId.ValueOf(value);

            // assert
            var ex = Assert.Throws<Exception>(target);
            Assert.Equal("タスクIDは26文字である必要があります。", ex.Message);
        }

        [Fact(DisplayName = "[NewId()] 新しいIDがULID形式で生成される")]
        public void NewId_Test1()
        {
            // act
            var id = TaskId.NewId();

            // assert
            Assert.Equal(26, id.Value.Length);
        }

        [Fact(DisplayName = "等価性を持っている")]
        public void Equivalence_Test()
        {
            // arrange
            var value1 = TaskId.ValueOf("12345678901234567890123456");
            var value2 = TaskId.ValueOf("12345678901234567890123456");

            // act
            var actual = value1 == value2;

            // assert
            Assert.True(actual);
        }
    }
}
