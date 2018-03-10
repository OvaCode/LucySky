using System;
using System.Collections.Generic;

namespace LucySkyAdmin.Models.AdminViewModels
{
    public class NerAnalyzer: INerAnalyzer
    {
        private IEntityClassifier _classifier;

        public NerAnalyzer() => _classifier = new EntityClassifier();
        internal NerAnalyzer(IEntityClassifier classifier) => _classifier = classifier;

        public IEntityClassifier Classifier { get => _classifier; }

        public IList<NerEntity> Analyze(string sentence)
        {
            Classifier.Rules.Add(new DateTimeClassificationRule());

            return Classifier.Classify(sentence);
        }
    }
}
