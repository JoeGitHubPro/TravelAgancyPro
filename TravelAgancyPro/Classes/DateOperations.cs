using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgancyPro.Classes
{
    public static class DateOperations
    {      
        public static DateTime CairoTimeZone = DateTime.UtcNow.AddHours(2);

        public static string DateMethod(DateTime? PostDate)
        {
            //Cairo time zone
            DateTime? ND = CairoTimeZone;

            TimeSpan timeSpan = ND.Value.Subtract(PostDate.Value);

            string Result = String.Empty;

            if (timeSpan.TotalSeconds < 60)
            {
                Result = $"{Convert.ToInt32(timeSpan.TotalSeconds)} s";
            }
            else if (timeSpan.TotalMinutes < 60)
            {
                Result = $"{Convert.ToInt32(timeSpan.TotalMinutes)} m";
            }
            else if (timeSpan.TotalHours < 24)
            {

                Result = $"{Convert.ToInt32(timeSpan.TotalHours)} h";
            }
            else if (timeSpan.TotalDays < 7)
            {
                Result = $"{Convert.ToInt32(timeSpan.TotalDays)} d";
            }
            else
            {
                return PostDate.Value.ToLongDateString();

            }
            return Result;

        }


    }
}