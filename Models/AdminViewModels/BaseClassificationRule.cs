using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LucySkyAdmin.Models.AdminViewModels
{
    public abstract class BaseClassificationRule: IClassificationRule
    {
        private IList<string> _patterns;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LucySkyAdmin.Models.AdminViewModels.BaseClassificationRule"/> class.
        /// </summary>
        public BaseClassificationRule()
        {
            _patterns = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LucySkyAdmin.Models.AdminViewModels.BaseClassificationRule"/> class.
        /// </summary>
        /// <param name="patterns">Patterns.</param>
        public BaseClassificationRule(IList<string> patterns)
        {
            _patterns = patterns;
        }

        /// <summary>
        /// Gets the patterns.
        /// </summary>
        /// <value>The patterns.</value>
        public IList<string> Patterns => _patterns;

        /// <summary>
        /// Gets the class tag.
        /// </summary>
        /// <value>The class tag.</value>
        public virtual string ClassTag => "@other";

        /// <summary>
        /// Applies the rule.
        /// </summary>
        /// <returns>The rule.</returns>
        /// <param name="sentence">Sentence.</param>
        public virtual string ApplyRule(string sentence)
        {
            var result = sentence;

            foreach (var pattern in _patterns)
            {
                MatchCollection matches = Regex.Matches(result, pattern);
                var addedLength = 0;

                foreach (Match m in matches)
                {
                    var index = m.Index + addedLength;
                    var originalSequence = result.Substring(index, m.Length);
                    var newSequence = string.Format("[{0}|{1}|{2}]", 
                                                    originalSequence, 
                                                    ClassTag, 
                                                    originalSequence);
                    var seqenceLength = newSequence.Length;

                    result = result.Remove(index, m.Length);
                    result = result.Insert(index, newSequence);

                    addedLength += seqenceLength - m.Length;
                }
            }

            return result;
        }
    }
}
