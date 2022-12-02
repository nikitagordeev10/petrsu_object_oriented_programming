using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class RightBorderTask
    {
        /// <returns>
        /// Возвращает индекс правой границы. 
        /// То есть индекс минимального элемента, который не начинается с prefix и большего prefix.
        /// Если такого нет, то возвращает items.Length
        /// </returns>
        /// <remarks>
        /// Функция должна быть НЕ рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            // IReadOnlyList похож на List, но у него нет методов модификации списка.
            // Этот код решает задачу, но слишком неэффективно. Замените его на бинарный поиск!
            //for (int i = phrases.Count-1; i >= 0; i--)
            //{
            //    if (string.Compare(prefix, phrases[i], StringComparison.OrdinalIgnoreCase) >= 0 
            //        || phrases[i].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            //        return i + 1;
            //}
            //return 0;

            // Рекурсивный бинарный поиск
            //if (right - left <= 1) return left;
            //var middle = (left + right) / 2;
            //if (string.Compare(prefix, phrases[middle], StringComparison.OrdinalIgnoreCase) < 0 || phrases[middle].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            //    return GetRightBorderIndex(phrases, prefix, left, middle);
            //return GetRightBorderIndex(phrases, prefix, middle, right);

            // Бинарный поиск
            while (right - left > 1)
            {
                var middle = left + (right - left) / 2;
                if (string.Compare(prefix, phrases[middle], StringComparison.OrdinalIgnoreCase) >= 0 || phrases[middle].StartsWith(prefix))
                    left = middle;
                else 
                    right = middle;
            }

            return right;
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
 * Бинарный поиск // Ulearn URL: https://ulearn.me/course/basicprogramming/Binarnyy_poisk_d48408e2-8baf-4742-8f87-c0c866ee4d38 (дата обращения: 13.11.2022).
 */
