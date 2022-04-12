using System;
using HoneyRyderTask.Domain.Models.Users;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Users
{
    /// <summary>
    /// ユーザーID - test
    /// </summary>
    public class UserId_Test
    {
        [Fact(DisplayName = "[ValueOf()] 指定した値でユーザーIDが生成される")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = "12345678901234567890123456";

            // act
            var id = UserId.ValueOf(value);

            // assert
            Assert.Equal(value, id.Value);
        }

        [Theory(DisplayName = "[ValueOf()] 26文字以外の値を渡すと例外が発生する")]
        [InlineData("1234567890123456789012345")]
        [InlineData("123456789012345678901234567")]
        public void ValueOf_Test2(string value)
        {
            // act
            var target = () => UserId.ValueOf(value);

            // assert
            var ex = Assert.Throws<Exception>(target);
            Assert.Equal("ユーザーIDは26文字である必要があります。", ex.Message);
        }

        [Fact(DisplayName = "[NewId()] 新しいIDがULID形式で生成される")]
        public void NewId_Test1()
        {
            // act
            var id = UserId.NewId();

            // assert
            Assert.Equal(26, id.Value.Length);
        }
    }
}