using System;
using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        /// <summary>
        /// Медианный фильтр для уменьшения шума. 
        /// </summary>
        /// <param name="original">массив пикселей с координатами x, y (цветной)</param>
        /// <returns></returns>
        public static double[,] MedianFilter(double[,] original)
        {
            // Извлекаем координаты x, y
            var x = original.GetLength(0);
            var y = original.GetLength(1);

            // Создаём массив ответ
            var corrected = new double[x, y];

            // Окно значений пикселей
            var window = new List<double> { };

            // Создаём окно размером 3х3 для не граничных пикселей,
            // Создаём окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    // левый столбец
                    if (j > 0 && i > 0)
                        window.Add(original[i - 1, j - 1]); // левый x, верхний y
                    if (i > 0)
                        window.Add(original[i - 1, j]); // левый x, средний y
                    if (i > 0 && j < y - 1)
                        window.Add(original[i - 1, j + 1]); // левый x, нижний y

                    // средний столбец
                    if (j > 0)
                        window.Add(original[i, j - 1]); // средний x, верхний y
                    window.Add(original[i, j]); // средний x, средний y
                    if (j < y - 1)
                        window.Add(original[i, j + 1]); // средний x, нижний y

                    // правый столбец
                    if (i < x - 1 && j > 0)
                        window.Add(original[i + 1, j - 1]); // правый x, верхний y
                    if (i < x - 1)
                        window.Add(original[i + 1, j]); // правый x, средний y
                    if (j < y - 1 && i < x - 1)
                        window.Add(original[i + 1, j + 1]); // правый x, нижний y

                    // Фильтруем изображение с N пикселями окном размера K x K пикселей: быстрая сортировка
                    corrected[i, j] = GetMedian(window);

                    // Подготовка к следующей итерации
                    window.Clear();
                }
            }

            return corrected;
        }
        /// <summary>
        /// Медианная фильтрация
        /// </summary>
        /// <param name="window">Матрица значений пикселей</param>
        /// <returns>Откорректированное значение ячейки</returns>
        public static double GetMedian(List<double> window)
        {
            // Вытягиваем значение пикселей в массив с k^2 элементами 
            var arrayWindowValues = window.ToArray();

            // Отсортируем полученный массив 
            Array.Sort(arrayWindowValues);

            // Возьмём центральный элемент - медиану 
            if (arrayWindowValues.Length % 2 != 0)
                return arrayWindowValues[(arrayWindowValues.Length) / 2];
            else if (arrayWindowValues.Length > 1)
                return (arrayWindowValues[arrayWindowValues.Length / 2] + arrayWindowValues[arrayWindowValues.Length / 2 - 1]) / 2;
            else return arrayWindowValues[0];
        }
    }
}


/*
 * Подсказки:
 * 1) Используйте окно размером 3х3 для не граничных пикселей,
 * 2) Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
 */

/*
 * Материалы:
 * Median filter // Wikipedia URL: https://en.wikipedia.org/wiki/Median_filter (дата обращения: 05.11.2022).
 * Медианный фильтр // Википедия URL: https://ru.wikipedia.org/wiki/Медианный_фильтр (дата обращения: 05.11.2022).
 * 09 - Обработка изображений. Медианный фильтр // YouTube URL: https://www.youtube.com/watch?v=XafWWzra3ww (дата обращения: 05.11.2022).
 * Рефакторинг кода медианного фильтра черно-белого изображения // cyberforum URL: https://www.cyberforum.ru/csharp-beginners/thread2354441.html (дата обращения: 05.11.2022).
 * Матричные фильтры обработки изображений // Habr URL: https://habr.com/ru/post/142818/ (дата обращения: 05.11.2022).
 * C# How to: Image Median Filter // SoftwareByDefault.com URL: https://softwarebydefault.com/2013/05/18/image-median-filter/ (дата обращения: 05.11.2022).
 * Обработка изображения с использованием медианного фильтра // cyberforum URL: https://www.cyberforum.ru/csharp-beginners/thread1699866.html (дата обращения: 05.11.2022).
 * System.Linq Пространство имен // Microsoft URL: https://learn.microsoft.com/ru-ru/dotnet/api/system.linq?view=net-6.0 (дата обращения: 05.11.2022).
 * System.Collections.Generic Пространство имен // Microsoft URL: https://learn.microsoft.com/ru-ru/dotnet/api/system.collections.generic?view=net-5.0 (дата обращения: 05.11.2022).
 */
