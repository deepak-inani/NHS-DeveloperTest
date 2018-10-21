using System;

namespace NHSHealthCareSolution
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTime dateTimeOffset)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - dateTimeOffset.Year;

            if (currentDate < dateTimeOffset.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}