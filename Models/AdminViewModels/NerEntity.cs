using System;
namespace LucySkyAdmin.Models.AdminViewModels
{
    public class NerEntity
    {
        public NerEntity(): this(string.Empty, "@other", string.Empty)
        {
            
        }

        public NerEntity(string word, string value): this(word, "@other", value)
        {
            
        }

        public NerEntity(string word, string wordClass, string value)
        {
            Word = word;
            Class = wordClass;
            Value = value;
        }

        public string Word { get; set; }
        public string Class { get; set; }
        public string Value { get; set; }

    }
}
