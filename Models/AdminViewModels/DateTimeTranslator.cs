using System;
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
            else if (input.Equals("in two days", StringComparison.InvariantCultureIgnoreCase))
            {
                result = DateTime.Now.AddDays(2);
            }
            else if (input.Equals("in three days", StringComparison.InvariantCultureIgnoreCase))
            {
                result = DateTime.Now.AddDays(3);
            }
            else if (input.Equals("in four days", StringComparison.InvariantCultureIgnoreCase))
            {
                result = DateTime.Now.AddDays(4);
            }

            // today, tomorrow, yesterday, day after tomorrow,  

            return result.ToShortDateString();
        }
    }
}
