//using System;
//using System.Collections.Generic;

//namespace TextAnalysis
//{
//    static class SentencesParserTask
//    {
//        public static List<List<string>> ParseSentences(string text)
//        {
//            var listSentences = new List<List<string>>();
//            var sentences = text.Split(new char[] { '.', '!', '?', ';', ':', ')', '(', },
//                StringSplitOptions.RemoveEmptyEntries);

//            for (var i = 0; i < sentences.Length; i++)
//            {
//                var listWords = new List<string>();

//                var words = sentences[i].Split(' ', ',');
//                foreach (var word in words)
//                {
//                    if (WordIsLetter(word))
//                    {
//                        listWords.Add(word);
//                    }
//                }

//                listSentences.Add(listWords);
//            }

//            return listSentences;
//        }

//        public static bool WordIsLetter(string word)
//        {
//            var symbols = word.ToCharArray();

//            foreach (var symbol in symbols)
//            {
//                if (!char.IsLetter(symbol))
//                {
//                    return false;
//                }
//            }

//            return true;
//        }
//    }
//}

//Подсказки:
//1) Разделить текст на предложения можно методом string.Split, указав ему все возможные разделители
//2) Чтобы разделить предложение на слова, придется написать проход по строке циклом. Лучше сразу выделить эту логику во вспомогательный метод
//3) Распространенная ошибка — забыть обработать последнее слово в предложении.
//4) Не забудьте отфильтровать предложения, в которых не оказалось слов.

using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var listSentences = new List<List<string>>();
            char[] separators = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            text.Split(separators).ToList();

            foreach (var sentence in listSentences)
                listSentences.Add(GetListOfWords(sentence));

            return listSentences;
        }

        public static List<string> GetListOfWords(List<string> sentence)
        {
            foreach (var word in sentence)
            {
                if (word.Contains(",") || word.Contains("."))
                    word.Remove(word.Length - 1);
                word.ToLower();
            }
            return sentence;
        }
    }
}
