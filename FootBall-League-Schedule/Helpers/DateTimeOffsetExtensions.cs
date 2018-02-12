using System;

namespace FootBallLeagueSchedule.Helpers
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTime? dateTime)
        {
            if (dateTime == null)
                return 0;
            var currentDate = DateTime.Now;
            int age = currentDate.Year - dateTime.Value.Year;
            if(currentDate < dateTime.Value.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}
