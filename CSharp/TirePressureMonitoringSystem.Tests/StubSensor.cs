namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests;

public class StubSensor : ISensor
{
    public double NextPressurePsiValue { get; set; }

    public double PopNextPressurePsiValue()
    {
        return NextPressurePsiValue;
    }
}