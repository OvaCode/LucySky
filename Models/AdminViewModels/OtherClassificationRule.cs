using System.Collections.Generic;
using System.Collections.Concurrent;
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
            var tempSentence = sentence;
            var index = 0;
            var tempLength = 0;
            // get the classified fragments
            MatchCollection matches = Regex.Matches(sentence, CLASSIFIED_BLOCKS_PATTERN);
            IList<string> sentenceParts = new List<string>();

            // replace each classified fragment with a placeholder {0}
            foreach(Match m in matches)
            {
                var tempInsert = "{" + index.ToString() + "}";

                sentenceParts.Add(m.Value);
                tempSentence = tempSentence.Remove(m.Index - tempLength, m.Length);
                tempSentence = tempSentence.Insert(m.Index - tempLength, tempInsert);
                tempLength += m.Value.Length - tempInsert.Length;

                index++;
            }

            return BuildFinalSentence(tempSentence, sentenceParts);
        }

        /// <summary>
        /// Builds the final sentence from given list of parts. Parts can be classifed or not classified 
        /// fragments of the sentence. Here they are put into the final form.
        /// </summary>
        /// <returns>The final sentence.</returns>
        /// <param name="sentence">Sentence.</param>
        /// <param name="sentenceParts">Temp memory.</param>
        private string BuildFinalSentence(string sentence, IList<string> sentenceParts)
        {
            var result = "";
            // split sentence to words
            char[] separators = { ' ', ',', '.', '?', '!', ':', ';', '/', '\\' };
            var words = sentence.Split(separators);
            // make a string array with classified fragments
            string[] tempArray = new string[sentenceParts.Count];
            sentenceParts.CopyTo(tempArray, 0);

            foreach(string word in words)
            {
                // ignore empty strings
                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }
                // if word starts with { it means it's a classified fragment placeholder
                // so, no action needed add it to result
                if (word.StartsWith('{'))
                {
                    result += word;
                    continue;
                }
                // if you get here it means the word is unclassified.
                // make it a @other class fragment
                result += string.Format("[{0}|@{1}|{2}]", word, ClassTag, word);
            }

            // replace classified placeholders with their original values
            return string.Format(result, tempArray);
        }
    }
}
