using System;
using System.Collections.Generic;

namespace LucySkyAdmin.Models.AdminViewModels
{
    /// <summary>
    /// Classification rule interface.
    /// </summary>
    public interface IClassificationRule
    {
        /// <summary>
        /// Applies the rule to a given sentence.
        /// </summary>
        /// <returns>The modified sentence. Example: Hi [Lucy|@person|Lucy] do you have time [tomorrow|@date|4.3.2018]?
        /// </returns>
        /// <param name="sentence">The original sentence.</param>
        string ApplyRule(string sentence);

        /// <summary>
        /// Gets the patterns.
        /// </summary>
        /// <value>The patterns.</value>
        IList<string> Patterns { get; }

        /// <summary>
        /// Gets the class tag.
        /// </summary>
        /// <value>The class tag.</value>
        string ClassTag { get; }
    }
}
