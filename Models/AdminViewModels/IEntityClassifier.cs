using System;
using System.Collections.Generic;

namespace LucySkyAdmin.Models.AdminViewModels
{
    public interface IEntityClassifier
    {

        /// <summary>
        /// Takes an original sentence and builds a list of NerEntities  according to the given rules.
        /// </summary>
        /// <returns>List of classified entities.
        /// </returns>
        /// <param name="originalSentence">Original sentence.</param>
        IList<NerEntity> Classify(string originalSentence);

        /// <summary>
        /// Gets the rules.
        /// </summary>
        /// <value>The rules.</value>
        IList<IClassificationRule> Rules { get; }
    }
}
