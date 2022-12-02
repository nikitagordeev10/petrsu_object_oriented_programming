namespace Recognizer
{
    public static class GrayscaleTask
    {
        /// <summary>
        /// Перевод цветного изображения в серую гамму.
        /// </summary>
        /// <param name="original">массив пикселей с координатами x, y (цветной)</param>
        /// <returns>массив пикселей с координатами x, y (чёрно-белый)</returns>
        public static double[,] ToGrayscale(Pixel[,] original)
        {
            // Извлекаем координаты x, y
            var x = original.GetLength(0);
            var y = original.GetLength(1);

            // создаём массив ответ
            var grayscale = new double[x, y];

            // Проходим по массиву и пересчитываем значения по формуле
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    grayscale[i, j] = (0.299 * original[i, j].R + 0.587 * original[i, j].G + 0.114 * original[i, j].B) / 255;
                }
            }
            return grayscale;
        }
    }
}


/*
 * Подсказки:
 * 1) Переведите изображение в серую гамму.
 * 2) original[x, y] - массив пикселей с координатами x, y. Каждый канал R,G,B лежит в диапазоне от 0 до 255.
 * 3) Получившийся массив должен иметь те же размеры, grayscale[x, y] - яркость пикселя (x,y) в диапазоне от 0.0 до 1.0
 * 4) Используйте формулу: Яркость = (0.299*R + 0.587*G + 0.114*B) / 255
 */

/*
 * Материалы:
 * Оттенки серого // Википедия URL: https://ru.wikipedia.org/wiki/Оттенки_серого (дата обращения: 05.11.2022).
 */
