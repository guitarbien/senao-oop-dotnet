using Xunit;
using Service;

namespace ServiceTest
{
    public class SchduleTest
    {
        [Fact]
        public void Schdule要有基本屬性()
        {
            Schedule schedule = new Schedule(
                "ext",
                "time",
                "interval"
            );

            Assert.Equal("ext", schedule.Ext);
            Assert.Equal("time", schedule.Time);
            Assert.Equal("interval", schedule.Interval);
        }
    }
}