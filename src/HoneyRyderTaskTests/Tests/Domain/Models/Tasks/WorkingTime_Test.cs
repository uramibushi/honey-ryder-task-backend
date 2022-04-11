using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// 作業時間 - test
    /// </summary>
    public class WorkingTime_Test
    {
        [Fact(DisplayName = "[ValueOf()] 指定した値で作業時間を生成できる")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = 1.25M;

            // act
            var workingTime = WorkingTime.ValueOf(value);

            // assert
            Assert.Equal(value, workingTime.Value);
        }

        [Fact(DisplayName = "[ValueOf()] 指定した値の小数部３桁以上の値は切り捨てられる")]
        public void ValueOf_Test2()
        {
            // arrange
            var value = 1.255M;

            // act
            var workingTime = WorkingTime.ValueOf(value);

            // assert
            Assert.Equal(1.25M, workingTime.Value);
        }
    }
}
