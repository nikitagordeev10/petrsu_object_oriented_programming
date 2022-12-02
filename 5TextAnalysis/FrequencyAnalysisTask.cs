using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var freqs = new Dictionary<string, Dictionary<string, int>>();
            
            foreach (var sentence in text) 
                UpdateFrequencyMap(freqs, sentence);
            
            return MakePairs(freqs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="freqs"></param>
        /// <param name="words"></param>
        static void UpdateFrequencyMap(Dictionary<string, Dictionary<string, int>> freqs, List<string> words)
        {
            string prevWord = null;
            foreach (var word in words)
            {
                if (prevWord != null)
                {
                    if (!freqs.ContainsKey(prevWord)) freqs[prevWord] = new Dictionary<string, int>();
                    if (!freqs[prevWord].ContainsKey(word)) freqs[prevWord][word] = 0;
                    ++freqs[prevWord][word];
                }
                prevWord = word;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="freqs"></param>
        /// <returns></returns>
        static Dictionary<string, string> MakePairs(Dictionary<string, Dictionary<string, int>> freqs)
        {
            var pairs = new Dictionary<string, string>();
            foreach (var firstPair in freqs)
            {
                var savedSecond = "";
                var savedFreq = int.MinValue;
                foreach (var secondPair in firstPair.Value)
                {
                    if (savedFreq < secondPair.Value || (savedFreq == secondPair.Value &&
                        string.CompareOrdinal(secondPair.Key, savedSecond) < 0))
                    {
                        savedSecond = secondPair.Key;
                        savedFreq = secondPair.Value;
                    }
                }
                pairs[firstPair.Key] = savedSecond;
            }
            return pairs;
        }
        // Подзадача 1: Построить частотный словарь
        // Подзадача 2: По началу N-граммы выбирать самое частное продолжение
        // Подзадача 3: Собрать результаты остальных подзадач в решение всей задачи
    }
}


//Шаг 1.Получаю список биграм
//Шаг 2. Получаю список триграм
//Шаг 3. Объединяю биграмы и триграмы в один список nграм
//Шаг 4. Из списка nграм получаю трехуровневый словарь: < начало < продолжение, частота >>
//Шаг 5.Из трехуровневого словатя получаю результирующий словарь

/*
 * Подсказки: 
 * 1) В этой задаче важно придумать декомпозицию всей задачи на 3-4 подзадачи. Если не получается самостоятельно, то в следующих подсказках предложены несколько подзадач, которые можно выделить из всей задачи.
 * 2) Одна из возможных подзадач — построить частотный словарь: начало N-граммы → последнее слово N-граммы → количество повторов этой N-граммы
 * 3) Вторая подзадача — по началу N-граммы выбирать самое частное продолжение.
 * 4) И, наконец, третья подзадача — собрать результаты остальных подзадач в решение всей задачи.
 */

/*
 * Использованные материалы:
 * Улучшить код поиска частотности словосочетаний // cyberforum URL: https://www.cyberforum.ru/csharp-beginners/thread2348594.html (дата обращения: 05.11.2022).
 * Частотность N-грамм // pastebin URL: https://pastebin.com/dmw8KCzY (дата обращения: 05.11.2022).
 * Проблема с памятью // stackoverflow URL: https://ru.stackoverflow.com/questions/1037316/Проблема-с-памятью (дата обращения: 05.11.2022).
 * Dictionary<TKey,TValue>.ContainsKey(TKey) Метод // Microsoft URL: https://learn.microsoft.com/ru-ru/dotnet/api/system.collections.generic.dictionary-2.containskey?view=net-6.0 (дата обращения: 05.11.2022).
 * String.CompareOrdinal Метод // Microsoft URL: https://learn.microsoft.com/ru-Ru/dotnet/api/system.string.compareordinal?view=net-5.0 (дата обращения: 05.11.2022).
 */