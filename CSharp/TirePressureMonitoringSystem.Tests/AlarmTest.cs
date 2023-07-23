using TDDMicroExercises.TirePressureMonitoringSystem.Tests;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        public void Alarm_IsOff_ByDefault()
        {
            // Arrange and Act
            Alarm alarm = new Alarm(new Sensor());
            
            // Assert
            Assert.False(alarm.AlarmOn);
        }
        
        [Fact]
        public void Alarm_GoesOn_WhenPressureValue_LessThanLowPressureThreshold()
        {
            // Arrange
            var stubSensor = new StubSensor
            {
                NextPressurePsiValue = Alarm.LowPressureThreshold - 1
            };
            Alarm alarm = new Alarm(stubSensor);

            // Act
            alarm.Check(true);
            
            // Assert
            Assert.True(alarm.AlarmOn);
        }
        
        [Fact]
        public void Alarm_GoesOn_WhenPressureValue_HigherThanHighPressureThreshold()
        {
            // Arrange
            var stubSensor = new StubSensor
            {
                NextPressurePsiValue = Alarm.HighPressureThreshold + 1
            };
            Alarm alarm = new Alarm(stubSensor);

            // Act
            alarm.Check(true);
            
            // Assert
            Assert.True(alarm.AlarmOn);
        }
        
        [Fact]
        public void Alarm_StaysOff_WhenPressureValue_BetweenPressureThresholds()
        {
            // Arrange
            var stubSensor = new StubSensor
            {
                NextPressurePsiValue = Alarm.LowPressureThreshold + 1
            };
            Alarm alarm = new Alarm(stubSensor);

            // Act
            alarm.Check(true);
            
            // Assert
            Assert.False(alarm.AlarmOn);
        }
        
        [Fact]
        public void AlarmNotSet_WhenFlagFalse_ForLowPressure()
        {
            // Arrange
            var stubSensor = new StubSensor
            {
                NextPressurePsiValue = Alarm.LowPressureThreshold - 1
            };
            Alarm alarm = new Alarm(stubSensor);

            // Act
            alarm.Check(false);
            
            // Assert
            Assert.False(alarm.AlarmOn);
        }
        
        [Fact]
        public void AlarmNotSet_WhenFlagFalse_ForHighPressure()
        {
            // Arrange
            var stubSensor = new StubSensor
            {
                NextPressurePsiValue = Alarm.HighPressureThreshold + 1
            };
            Alarm alarm = new Alarm(stubSensor);

            // Act
            alarm.Check(false);
            
            // Assert
            Assert.False(alarm.AlarmOn);
        }
    }
}