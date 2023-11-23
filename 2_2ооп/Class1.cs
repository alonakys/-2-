using System;
using System.Collections.Generic;
using System.Text;

namespace lab5_1_2
{
    public class MyTime
    {
        private int hour, minute, second;
        private const int numOfSecondsInHour = 3600;
        private const int numOfHoursInDay = 24;
        private const int numOfSecondsInAMinute = 60;

        public int Hour
        {
            get { return hour; }
            set
            {
                if (hour < 0 || hour > 23)
                {
                    throw new ArgumentException("Формат годин неправильний");
                }
                hour = value;
            }
        }
        public int Minute
        {
            get { return minute; }
            set
            {
                if (hour < 0 || hour > 59)
                {
                    throw new ArgumentException("Формат хвилин неправильний");
                }
                minute = value;
            }
        }
        public int Second
        {
            get { return second; }
            set
            {
                if (hour < 0 || hour > 59)
                {
                    throw new ArgumentException("Формат секунд неправильний");
                }
                second = value;
            }
        }

        public MyTime(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
        public override string ToString()
        {
            return $"{Hour}:{Minute:D2}:{Second:D2}";
        }
        public static int TimeSinceMidnight(MyTime time)
        {
            return time.Hour * numOfSecondsInHour + time.Minute * numOfSecondsInAMinute + time.Second;
        }
        public static MyTime TimeSinceMidnight(int time)
        {
            int hour = time / numOfSecondsInHour % numOfHoursInDay;
            int minute = time / numOfSecondsInAMinute % numOfSecondsInAMinute;
            int second = time % numOfSecondsInAMinute;
            return new MyTime(hour, minute, second);
        }
        public static MyTime AddOneSecond(MyTime time)
        {
            int secondSinceMidnight = TimeSinceMidnight(time);
            secondSinceMidnight = (secondSinceMidnight + 1) % (numOfHoursInDay * numOfSecondsInHour);
            return TimeSinceMidnight(secondSinceMidnight);
        }
        public static MyTime AddOneMinute(MyTime time)
        {
            int secondsSinceMidnight = TimeSinceMidnight(time);
            secondsSinceMidnight = (secondsSinceMidnight + numOfSecondsInAMinute) % (numOfHoursInDay * numOfSecondsInHour);
            return TimeSinceMidnight(secondsSinceMidnight);
        }
        public static MyTime AddOneHour(MyTime time)
        {
            int secondsSinceMidnight = TimeSinceMidnight(time);
            secondsSinceMidnight = (secondsSinceMidnight + numOfSecondsInHour) % (numOfHoursInDay * numOfSecondsInHour);
            return TimeSinceMidnight(secondsSinceMidnight);
        }
        public static MyTime AddSeconds(MyTime time, int seconds)
        {
            int secondsSinceMidnight = TimeSinceMidnight(time);
            secondsSinceMidnight = (secondsSinceMidnight + numOfHoursInDay * numOfSecondsInHour + seconds) % (numOfHoursInDay * numOfSecondsInHour);
            return TimeSinceMidnight(secondsSinceMidnight);
        }
    }
}
