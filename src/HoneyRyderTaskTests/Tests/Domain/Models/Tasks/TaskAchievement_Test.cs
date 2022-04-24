using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// タスク実績 - test
    /// </summary>
    public class TaskAchievement_Test
    {
        [Fact(DisplayName = "[ValueOf(startDate, endDate, time) 指定した値でタスク実績を生成できる")]
        public void ValueOf_Test1()
        {
            // arrange
            var startDate = new DateTime(2022, 4, 1);
            var endDate = new DateTime(2022, 4, 3);
            var time = 24M;

            // act
            var taskAchievement = TaskAchievement.ValueOf(startDate, endDate, time);

            // assert
            Assert.Equal(startDate, taskAchievement.Period.StartDate);
            Assert.Equal(endDate, taskAchievement.Period.EndDate);
            Assert.Equal(time, taskAchievement.Time?.Value);
        }

        [Fact(DisplayName = "[ValueOf(startDate, endDate, time) タスク実績時間は省略可能")]
        public void ValueOf_Test2()
        {
            // arrange
            var startDate = new DateTime(2022, 4, 1);
            var endDate = new DateTime(2022, 4, 3);
            decimal? time = null;

            // act
            var taskAchievement = TaskAchievement.ValueOf(startDate, endDate, time);

            // assert
            Assert.Equal(startDate, taskAchievement.Period.StartDate);
            Assert.Equal(endDate, taskAchievement.Period.EndDate);
            Assert.Null(taskAchievement.Time);
        }

        [Fact(DisplayName = "等価性を持っている")]
        public void Equivalence_Test()
        {
            // arrange
            var value1 = TaskAchievement.ValueOf(
                startDate: new DateTime(2022, 4, 1),
                endDate: new DateTime(2022, 4, 2),
                time: 16M);
            var value2 = TaskAchievement.ValueOf(
                startDate: new DateTime(2022, 4, 1),
                endDate: new DateTime(2022, 4, 2),
                time: 16M);

            // act
            var actual = value1 == value2;

            // assert
            Assert.True(actual);
        }
    }
}
