namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        public static double LowPressureThreshold = 17;
        public static double HighPressureThreshold = 21;

        readonly ISensor _sensor;
        
        bool _alarmOn = false;
        private long _alarmCount = 0;

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
                _alarmCount += 1;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}
