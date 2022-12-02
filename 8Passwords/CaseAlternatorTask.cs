using System;
using System.Collections.Generic;
using System.Linq;

namespace Passwords
{
    public class CaseAlternatorTask
    {
        //Тесты будут вызывать этот метод
        public static List<string> AlternateCharCases(string lowercaseWord)
        {
            var result = new List<string>();
            AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
            return result;
        }

        /// <summary>
        /// Перебор слов заменой регистра
        /// </summary>
        /// <param name="word">слово в нижнем регистре</param>
        /// <param name="startIndex">точка старта</param>
        /// <param name="result">ответ</param>
        static void AlternateCharCases(char[] word, int startIndex, List<string> result)
        {
            // База рекурсии
            if (startIndex == word.Length)
            {
                result.Add(new string(word));
                return;
            }

            // У некоторых не букв тоже есть верхний и нижний регистр
            if (char.IsLetter(word[startIndex]) && char.ToLower(word[startIndex]) != char.ToUpper(word[startIndex]))
            {
                // в лексикографическом порядке, считая, что маленькие буквы меньше больших
                word[startIndex] = char.ToLower(word[startIndex]);
                AlternateCharCases(word, startIndex + 1, result);

                word[startIndex] = char.ToUpper(word[startIndex]);
                AlternateCharCases(word, startIndex + 1, result);
            }
            else
            {
                // Не все буквы имеют верхний и нижний регистр
                AlternateCharCases(word, startIndex + 1, result);
            }

        }
    }
}

/*
 * Подсказки:
 * 1) Помните, что у вас в распоряжении есть методы char.IsLetter, char.ToLower и char.ToUpper.
 * 2) Не все буквы имеют верхний и нижний регистр! Например, еврейский алфавит не имеет различий в регистрах.
 * 3) У некоторых не букв тоже есть верхний и нижний регистр. Например, у римских цифр (для них есть отдельные символы Unicode) есть регистр, но это не буквы, а цифры.
 */

/*
 * Использованные материалы:
 * Перебор паролей // Ulearn.me URL: https://ulearn.me/course/basicprogramming/Perebor_paroley_a859b4b5-ba6f-48c6-a745-19ea5f4a307c (дата обращения: 05.11.2022).
 * Комбинаторика. Теория вероятностей. Часть 3. Перестановка, размещение, сочетание // internetурок URL: https://interneturok.ru/lesson/algebra/9-klass/effektivnye-kursy/kombinatorika-teoriya-veroyatnostey-chast-3-perestanovka-razmeschenie-sochetanie (дата обращения: 05.11.2022).
 * Подмножества // ulearn.me URL: https://ulearn.me/course/basicprogramming/Podmnozhestva_67cb3e0c-6cf3-49c0-ac8d-4c2b58b262d3 (дата обращения: 05.11.2022).
 * Index was outside of the bounds of the array [duplicate] // stackoverflow URL: https://stackoverflow.com/questions/3701767/index-was-outside-of-the-bounds-of-the-array (дата обращения: 05.11.2022).
 */