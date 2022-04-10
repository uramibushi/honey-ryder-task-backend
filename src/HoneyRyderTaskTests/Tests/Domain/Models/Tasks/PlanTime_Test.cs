using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// 予定時間 - test
    /// </summary>
    public class PlanTime_Test
    {
        [Fact(DisplayName = "[ValueOf()] 指定した値で予定時間を生成できる")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = 4.5M;

            // act
            var planTime = PlanTime.ValueOf(value);

            // assert
            Assert.Equal(value, planTime.Value);
        }
    }
}
