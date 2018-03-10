using System;
using System.Collections.Generic;

namespace LucySkyAdmin.Models.AdminViewModels
{
    public class NerFakeAnalyzer: INerAnalyzer
    {
        public NerFakeAnalyzer()
        {
        }

        public IEntityClassifier Classifier => throw new NotImplementedException();

        public IList<NerEntity> Analyze(string sentence)
        {
            string[] words = sentence.Split(new char[] { ' ', ',', '.', '!', '?' });
            IList<NerEntity> result = new List<NerEntity>();

            foreach(string w in words)
            {
                if(w.Equals("today", StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Add(new NerEntity(w, "@date", DateTime.Now.ToShortDateString().ToString()));
                }
                else if(w.Equals("tomorrow", StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Add(new NerEntity(w, "@date", DateTime.Now.AddDays(1).ToShortDateString().ToString()));
                }
                else if (w.Equals("ostrava", StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Add(new NerEntity(w, "@location", w));
                }
                else if (w.Equals("praha", StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Add(new NerEntity(w, "@location", w));
                }
                else if (w.Equals("lucy", StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Add(new NerEntity(w, "@person", w));
                }
                else
                {
                    result.Add(new NerEntity(w, w));
                }
            }

            return result;
        }
    }
}
