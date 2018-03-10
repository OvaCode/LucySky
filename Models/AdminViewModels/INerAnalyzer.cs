using System;
using System.Collections.Generic;

namespace LucySkyAdmin.Models.AdminViewModels
{
    public interface INerAnalyzer
    {
        IList<NerEntity> Analyze(string sentence);
        IEntityClassifier Classifier { get; }
    }
}
