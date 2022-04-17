using HoneyRyderTask.Domain.Models.Shared;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Shared
{
    /// <summary>
    /// IsDeleted - test
    /// </summary>
    public class IsDeleted_Test
    {
        [Fact(DisplayName = "[ValueOf()] 指定した値でIsDeletedを生成できる")]
        public void ValueOf_Test1()
        {
            // act
            var isDeleted = IsDeleted.ValueOf(true);

            // assert
            Assert.True(isDeleted.Value);
        }

        [Theory(DisplayName = "[==(isDeleted, boolValue)] IsDeletedとBool値が等しいか判断できる")]
        [InlineData(true, false, false)]
        [InlineData(true, true, true)]
        [InlineData(false, false, true)]
        [InlineData(false, true, false)]
        public void Equals_Test1(bool value, bool boolValue, bool expected)
        {
            // arrange
            var isDeleted = IsDeleted.ValueOf(value);

            // act
            var actual = isDeleted == boolValue;

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "[!=(isDeleted, boolValue)] IsDeletedとBool値が等しくないか判断できる")]
        [InlineData(true, false, true)]
        [InlineData(true, true, false)]
        [InlineData(false, false, false)]
        [InlineData(false, true, true)]
        public void NotEquals_Test1(bool value, bool boolValue, bool expected)
        {
            // arrange
            var isDeleted = IsDeleted.ValueOf(value);

            // act
            var actual = isDeleted != boolValue;

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
