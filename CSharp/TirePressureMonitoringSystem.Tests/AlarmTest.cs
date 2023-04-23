using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        public void Foo()
        {
            Alarm alarm = new Alarm(new Sensor());
            Assert.False(alarm.AlarmOn);
        }
    }
}