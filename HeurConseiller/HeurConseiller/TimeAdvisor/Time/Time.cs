using System;

namespace HeurConseiller.TimeAdvisor.Time
{
    public class Time
    {
        private DateTime _DateTime;

        public Time(DateTime dateTime)
        {
            _DateTime = dateTime;
        }

        public int GetHours()
        {
            return _DateTime.Hour;
        }

        public int GetMinutes()
        {
            return _DateTime.Minute;
        }

        public int GetSeconds()
        {
            return _DateTime.Second;
        }
    }
}