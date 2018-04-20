using System;
using System.Collections.Generic;

namespace LucySkyAdmin.Models.AdminViewModels
{
    public class DateTimeTranslator: IEntityTranslator
    {
        public string Translate(string input)
        {
            DateTime result = DateTime.Now;

            if(input.Equals("today", StringComparison.InvariantCultureIgnoreCase))
            {
                result = DateTime.Now;
            } 
            else if(input.Equals("tomorrow", StringComparison.InvariantCultureIgnoreCase ))
            {
                result = DateTime.Now.AddDays(1);
            }
            else if (input.Equals("yesterday", StringComparison.InvariantCultureIgnoreCase))
            {
                result = DateTime.Now.AddDays(-1);
            }
            else if (input.ToLower().StartsWith("in") || input.ToLower().EndsWith("ago"))
            {
                var entity = ParseDateTimeString(input);

                result = result.AddSeconds(entity.Seconds);
                result = result.AddMinutes(entity.Minutes);
                result = result.AddHours(entity.Hours);
                result = result.AddDays(entity.Days + (entity.Weeks * 7)); // 
                result = result.AddMonths(entity.Months);
                result = result.AddYears(entity.Years);
            }


            // today, tomorrow, yesterday, day after tomorrow,  

            return result.ToShortDateString();
        }

        private int GetNumberFromText(string input)
        {
            var result = 0;

            string[] textNums = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve" };

            for (var i = 0; i < textNums.Length; i++)
            {

                if(input.ToLower().Contains(textNums[i]))
                {
                    result = i + 1;
                    break;
                }
            }

            return result;
        }

        private DateTimeEntity ParseDateTimeString(string input)
        {
            var result = new DateTimeEntity();
            var multiplicator = 1;

            if(input.ToLower().EndsWith("ago"))
            {
                multiplicator = -1;
            }

            if (input.ToLower().Contains("second"))
            {
                result.Seconds = GetNumberFromText(input) * multiplicator;
            }
            else if (input.ToLower().Contains("minute"))
            {
                result.Minutes = GetNumberFromText(input) * multiplicator;
            }
            else if (input.ToLower().Contains("hour"))
            {
                result.Hours = GetNumberFromText(input) * multiplicator;
            }
            else if (input.ToLower().Contains("day"))
            {
                result.Days = GetNumberFromText(input) * multiplicator;
            }
            else if (input.ToLower().Contains("week"))
            {
                result.Weeks = GetNumberFromText(input) * multiplicator;
            }
            else if (input.ToLower().Contains("month"))
            {
                result.Months = GetNumberFromText(input) * multiplicator;
            }
            else if (input.ToLower().Contains("year"))
            {
                result.Years = GetNumberFromText(input) * multiplicator;
            }

            return result;
        }
    }

    internal class DateTimeEntity
    {
        public DateTimeEntity()
        {
            Seconds = 0;
            Minutes = 0;
            Hours = 0;
            Days = 0;
            Weeks = 0;
            Months = 0;
            Years = 0;
        }

        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }
        public int Days { get; set; }
        public int Weeks { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }
    }
}
