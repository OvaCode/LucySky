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

            // today, tomorrow, yesterday, day after tomorrow,  

            return result.ToShortDateString();
        }
    }
}
