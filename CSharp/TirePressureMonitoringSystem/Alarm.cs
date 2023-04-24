namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        public static double LowPressureThreshold = 17;
        public static double HighPressureThreshold = 21;

        ISensor _sensor;

        bool _alarmOn = false;
        private long _alarmCount = 0;

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        public void CheckForLowPressure()
        {
            Check(checkForLowPressure: true);
        }

        public void CheckForHighPressure()
        {
            Check(checkForLowPressure: false);
        }

        private void Check(bool checkForLowPressure)
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (checkForLowPressure)
            {
                if (isLowPressure(psiPressureValue))
                {
                    SetAlarm();
                }
            }
            else
            {
                if (isHighPressure(psiPressureValue))
                {
                    SetAlarm();
                }
            }
        }

        private void SetAlarm()
        {
            _alarmOn = true;
            _alarmCount += 1;
        }

        private static bool isHighPressure(double psiPressureValue)
        {
            return HighPressureThreshold < psiPressureValue;
        }

        private static bool isLowPressure(double psiPressureValue)
        {
            return psiPressureValue < LowPressureThreshold;
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}
