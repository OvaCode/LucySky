using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LucySkyAdmin.Models.AdminViewModels
{
    internal class OtherClassificationRule: BaseClassificationRule
    {
        private readonly string CLASSIFIED_BLOCKS_PATTERN = @"\[.*?\]";

        /// <summary>
        /// Applies the rule.
        /// </summary>
        /// <returns>The given sentence processed by the rule.</returns>
        /// <param name="sentence">Sentence.</param>
        public override string ApplyRule(string sentence)
        {
            // Split sentence to classified and not classified fragments
            Patterns.Add(CLASSIFIED_BLOCKS_PATTERN);
            MatchCollection matches = Regex.Matches(sentence, Patterns[0]);
            IList<string> sentenceParts = new List<string>();
            var addedIndex = 0;


            // Fill classified and not classified into an array
            foreach(Match m in matches)
            {
                var startIndex = 0;
                var endIndex = 0;

                if(m.Index == 0)
                {
                    startIndex = m.Index;
                    endIndex = m.Index + m.Length;
                }
                else
                {
                    startIndex = addedIndex;
                    endIndex = m.Index;
                }

                if(sentence.Length != endIndex && startIndex != 0)
                {
                    // Take a substring which prior the found classified fragment
                    var plainText = sentence.Substring(startIndex, endIndex - startIndex);
                    // a substring represents not classified fragment so, store it as a whole into the array
                    sentenceParts.Add(plainText);
                }

                // then add found classified fragment to stay consistent
                sentenceParts.Add(m.Value);

                // update index for next reading
                addedIndex = m.Index + m.Length;
            }

            if(matches.Count == 0)
            {
                sentenceParts.Add(sentence);

                return BuildFinalSentence(sentenceParts);
            }

            return BuildFinalSentence(sentenceParts);
        }

        /// <summary>
        /// Builds the final sentence from given list of parts. Parts can be classifed or not classified 
        /// fragments of the sentence. Here they are put into the final form.
        /// </summary>
        /// <returns>The final sentence.</returns>
        /// <param name="parts">Parts.</param>
        private string BuildFinalSentence(IList<string> parts)
        {
            var result = new StringBuilder();

            foreach(var part in parts)
            {
                // check is given part matches the classified fragment. If not process it as @other
                if(!Regex.Match(part, Patterns[0]).Success)
                {
                    var words = part.Split(' ');

                    foreach (var word in words)
                    {
                        if (!string.IsNullOrWhiteSpace(word))
                        {
                            result.AppendFormat("[{0}|{1}|{2}]", word, ClassTag, word);
                        }
                    }
                }
                else
                {
                    result.AppendFormat("{0}", part);
                }
            }

            return result.ToString();
        }
    }
}
