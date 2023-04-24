using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        public void Test_AlarmIsOff_ByDefault()
        {
            // Arrange & Act
            Alarm alarm = new Alarm(new Sensor());
            
            // Assert
            Assert.False(alarm.AlarmOn);
        }
        
        [Fact]
        public void Test_LowPressureAlarmIsNotTriggered_WhenPressureIsInRange()
        {
            // Arrange
            var stubSensor = new StubSensor();
            stubSensor.NextPressurePsiValue = Alarm.LowPressureThreshold + 1;
            Alarm alarm = new Alarm(stubSensor);
            
            // Act
            alarm.CheckForLowPressure();
            
            // Assert
            Assert.False(alarm.AlarmOn);
        }
        
        [Fact]
        public void Test_HighPressureAlarmIsNotTriggered_WhenPressureIsInRange()
        {
            // Arrange
            var stubSensor = new StubSensor();
            stubSensor.NextPressurePsiValue = Alarm.LowPressureThreshold + 1;
            Alarm alarm = new Alarm(stubSensor);
            
            // Act
            alarm.CheckForHighPressure();
            
            // Assert
            Assert.False(alarm.AlarmOn);
        }
        
        [Fact]
        public void Test_AlarmIsTriggered_WhenPressureIsTooLow()
        {
            // Arrange
            var stubSensor = new StubSensor();
            stubSensor.NextPressurePsiValue = Alarm.LowPressureThreshold - 1;
            Alarm alarm = new Alarm(stubSensor);
            
            // Act
            alarm.CheckForLowPressure();
            
            // Assert
            Assert.True(alarm.AlarmOn);
        }
        
        [Fact]
        public void Test_AlarmIsTriggered_WhenPressureIsTooHigh()
        {
            // Arrange
            var stubSensor = new StubSensor();
            stubSensor.NextPressurePsiValue = Alarm.HighPressureThreshold + 1;
            Alarm alarm = new Alarm(stubSensor);
            
            // Act
            alarm.CheckForHighPressure();
            
            // Assert
            Assert.True(alarm.AlarmOn);
        }
    }
}