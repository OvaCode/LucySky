using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LucySkyAdmin.Models.AdminViewModels
{
    /// <summary>
    /// Sentence view model.
    /// </summary>
    public class SentenceViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LucySkyAdmin.Models.AdminViewModels.SentenceViewModel"/> class.
        /// </summary>
        public SentenceViewModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Sentence = "";
            Entities = new List<NerEntity>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the sentence.
        /// </summary>
        /// <value>The sentence.</value>
        [Display(Name = "Training set sentence")]
        public string Sentence { get; set; }

        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>The entities.</value>
        [Display(Name = "Analyzed entities")]
        public IList<NerEntity> Entities { get; set; }
    }
}
