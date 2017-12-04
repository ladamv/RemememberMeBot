using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteSample
{
    public class WordAndTranslation
    {
        public int ID { get; set; }
        public string RussianWord { get; set; }
        public string EnglishWord { get; set; }

        public WordAndTranslation(int id, string russianWord, string englishWord)
        {
            ID = id;
            RussianWord = russianWord;
            EnglishWord = englishWord;
        }
    }
}
