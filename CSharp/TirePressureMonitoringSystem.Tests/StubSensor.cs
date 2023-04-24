namespace TDDMicroExercises.TirePressureMonitoringSystem;

public class StubSensor : ISensor
{
    public double NextPressurePsiValue { get; set; }
        
    public double PopNextPressurePsiValue()
    {
        return NextPressurePsiValue;
    }
}