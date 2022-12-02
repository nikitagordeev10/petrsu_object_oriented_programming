using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    // Внимание!
    // Есть одна распространенная ловушка при сравнении строк: строки можно сравнивать по-разному:
    // с учетом регистра, без учета, зависеть от кодировки и т.п.
    // В файле словаря все слова отсортированы методом StringComparison.OrdinalIgnoreCase.
    // Во всех функциях сравнения строк в C# можно передать способ сравнения.
    public class LeftBorderTask
    {
        /// <returns>
        /// Возвращает индекс левой границы.
        /// То есть индекс максимальной фразы, которая не начинается с prefix и меньшая prefix.
        /// Если такой нет, то возвращает -1
        /// </returns>
        /// <remarks>
        /// Функция должна быть рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            // IReadOnlyList похож на List, но у него нет методов модификации списка.
            // Этот код решает задачу, но слишком неэффективно. Замените его на бинарный поиск!
            
            //for (int i = 0; i < phrases.Count; i++)
            //{
            //    if (string.Compare(prefix, phrases[i], StringComparison.OrdinalIgnoreCase) < 0 || phrases[i].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            //        return i - 1;
            //}
            //return phrases.Count-1;

            if (right - left <= 1) return left;
            var middle = (left + right) / 2;
            //if (array[m] < value)
            if (string.Compare(prefix, phrases[middle], StringComparison.OrdinalIgnoreCase) < 0 || phrases[middle].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                //return BinSearchLeftBorder(array, value, m, right);
                return GetLeftBorderIndex(phrases, prefix, left, middle);
            
            //return BinSearchLeftBorder(array, value, left, m);
            return GetLeftBorderIndex(phrases, prefix, middle, right);
        }
    }
}

/*
 * Подсказки:
 * 1) Длина множества фраз слишком большая. Избегайте переполнения при арифметике с индексами.
 * 2) При первом вызове left = -1, а right = phrases.Length.
 */

/*
 * Использованные материалы:
 * StringComparison Перечисление // Microsoft URL: https://learn.microsoft.com/ru-ru/dotnet/api/system.stringcomparison?view=net-6.0 (дата обращения: 13.11.2022).
 * Рекурсивный бинарный поиск // Ulearn URL: https://ulearn.me/course/basicprogramming/Rekursivnyy_binarnyy_poisk_4d7960d8-7d65-4ff7-b070-36e8ff618755 (дата обращения: 13.11.2022).
 * Анализ бинпоиска // Ulearn URL: https://ulearn.me/course/basicprogramming/Analiz_binpoiska_fd0b0306-9ea0-4592-bfd6-6b394fea62dc (дата обращения: 13.11.2022).
 */