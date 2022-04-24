using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// タスク実績時間 - test
    /// </summary>
    public class TaskAchievementTime_Test
    {
        [Fact(DisplayName = "[ValueOf()] 指定した値でタスク実績時間を生成できる")]
        public void ValueOf_Test1()
        {
            // arrange
            var value = 1.25M;

            // act
            var workingTime = TaskAchievementTime.ValueOf(value);

            // assert
            Assert.Equal(value, workingTime.Value);
        }

        [Fact(DisplayName = "[ValueOf()] 指定した値の小数部２桁まで。それ以上の値は切り捨てられる")]
        public void ValueOf_Test2()
        {
            // arrange
            var value = 1.255M;

            // act
            var workingTime = TaskAchievementTime.ValueOf(value);

            // assert
            Assert.Equal(1.25M, workingTime.Value);
        }
    }
}
