using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// タスク予定 - test
    /// </summary>
    public class TaskSchedule_Test
    {
        [Fact(DisplayName = "[ValueOf(startDate, endDate, time) 指定した値でタスク予定を生成できる")]
        public void ValueOf_Test1()
        {
            // arrange
            var startDate = new DateTime(2022, 4, 1);
            var endDate = new DateTime(2022, 4, 3);
            var time = 24M;

            // act
            var taskSchedule = TaskSchedule.ValueOf(startDate, endDate, time);

            // assert
            Assert.Equal(startDate, taskSchedule.Period.StartDate);
            Assert.Equal(endDate, taskSchedule.Period.EndDate);
            Assert.Equal(time, taskSchedule.Time?.Value);
        }

        [Fact(DisplayName = "[ValueOf(startDate, endDate, time) タスク予定時間は省略可能")]
        public void ValueOf_Test2()
        {
            // arrange
            var startDate = new DateTime(2022, 4, 1);
            var endDate = new DateTime(2022, 4, 3);
            decimal? time = null;

            // act
            var taskSchedule = TaskSchedule.ValueOf(startDate, endDate, time);

            // assert
            Assert.Equal(startDate, taskSchedule.Period.StartDate);
            Assert.Equal(endDate, taskSchedule.Period.EndDate);
            Assert.Null(taskSchedule.Time);
        }

        [Fact(DisplayName = "等価性を持っている")]
        public void Equivalence_Test()
        {
            // arrange
            var value1 = TaskSchedule.ValueOf(
                startDate: new DateTime(2022, 4, 1),
                endDate: new DateTime(2022, 4, 2),
                time: 16M);
            var value2 = TaskSchedule.ValueOf(
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
