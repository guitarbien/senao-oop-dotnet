using Xunit;
using Service;

namespace ServiceTest
{
    public class ScheduleManagerTest
    {
        [Fact]
        public void ScheduleManager有Count屬性可以使用操作array方式取得configs的內容()
        {
            ScheduleManager scheduleManager = new ScheduleManager();
            scheduleManager.ProcessConfig();

            Assert.IsType<Schedule>(scheduleManager[0]);
            Assert.Equal(scheduleManager.Count, 3);
        }
    }
}