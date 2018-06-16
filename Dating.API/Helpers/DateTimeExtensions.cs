using System;

namespace Dating.API.Helpers
{
    public static class DateTimeExtensions
    {
        public static int CalulateAge(this DateTime dateTime)
        {
            var age = DateTime.Today.Year - dateTime.Year;
            if (dateTime.AddYears(age) > DateTime.Today)
            {
                age--;
            }

            return age;
        }
    }
}