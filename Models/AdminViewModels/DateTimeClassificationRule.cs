using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LucySkyAdmin.Models.AdminViewModels
{
    /// <summary>
    /// Date time classification rule.
    /// </summary>
    public class DateTimeClassificationRule:BaseClassificationRule
    {
        private readonly string _dateNumericFormatPattern =
            @"(\d{4})(-|.|\/)(\d{1,2})(-|.|\/)(\d{1,2})|(\d{1,2})(-|.|\/)(\d{1,2})(-|.|\/)(\d{4})";
        private readonly string _dateTextFormatPattern =
            @"(now|yesterday|today|tomorrow|(in\s+(\d{1,}|few|several|one|two|three|four|five|six|seven|eight|nine|ten)\s+(days|day|weeks|week|year|years))|((\d{1,}|few|several|one|two|three|four|five|six|seven|eight|nine|ten)\s+(days|day|weeks|week|year|years)\s+(ago|before|after))|((on|next|last|previous|before|after)\s+(week|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday)|(Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday)|(January|February|March|April|May|June|July|September|October|November|December)))";

        /// <summary>
        /// Gets the class tag.
        /// </summary>
        /// <value>The class tag.</value>
        public override string ClassTag => "date";

        /// <summary>
        /// Applies the rule.
        /// </summary>
        /// <returns>The rule.</returns>
        /// <param name="sentence">Sentence.</param>
        public override string ApplyRule(string sentence)
        {
            Patterns.Add(_dateTextFormatPattern);
            Patterns.Add(_dateNumericFormatPattern);

            return base.ApplyRule(sentence);
        }
    }
}
