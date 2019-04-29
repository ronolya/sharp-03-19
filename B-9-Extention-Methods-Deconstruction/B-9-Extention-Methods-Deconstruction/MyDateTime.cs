using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Lesson_9
{
    class MyDateTime
    {
        public MyDateTime(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }
        private DateTime dateTime;

        public void Deconstruct(out int year, out int month, out int day,
            out int hour, out int minute, out int second)
        {
            year = dateTime.Year;
            month = dateTime.Month;
            day = dateTime.Day;
            hour = dateTime.Hour;
            minute = dateTime.Minute;
            second = dateTime.Second;
        }
    }
}
