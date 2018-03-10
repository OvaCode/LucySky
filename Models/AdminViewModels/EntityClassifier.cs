using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LucySkyAdmin.Models.AdminViewModels
{
    public class EntityClassifier : IEntityClassifier
    {
        #region Private variables
        readonly string ENTITIES_REGEX = @"\[.*?\]";
        private IList<IClassificationRule> _rules;
        #endregion

        #region Ctor
        public EntityClassifier()
        {
            _rules = new List<IClassificationRule>();
        }
        public EntityClassifier(IList<IClassificationRule> rules)
        {
            _rules = rules;
        }
        #endregion

        /// <summary>
        /// Gets the rules.
        /// </summary>
        /// <value>The rules.</value>
        public IList<IClassificationRule> Rules
        {
            get => _rules;
        }

        public IList<NerEntity> Classify(string originalSentence)
        {
            _rules.Add(new OtherClassificationRule());
            var classifiedSentence = originalSentence;
            IList<NerEntity> result = new List<NerEntity>();

            foreach (var rule in _rules)
            {
                classifiedSentence = rule.ApplyRule(classifiedSentence);
            }

            var matches = Regex.Matches(classifiedSentence, ENTITIES_REGEX);

            foreach (Match m in matches)
            {
                var entityString = m.Value;

                entityString = entityString.Replace("[", "");
                entityString = entityString.Replace("]", "");

                var entityProps = entityString.Split('|');

                try
                {
                    result.Add(new NerEntity(entityProps[0], entityProps[1], entityProps[2]));
                }
                catch (IndexOutOfRangeException indexOutEx)
                {
                    Console.WriteLine(indexOutEx.ToString());
                }
            }

            return result;
        }
    }
}

