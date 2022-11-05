//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;

//namespace TableParser
//{
//    [TestFixture]
//    public class QuotedFieldTaskTests
//    {
//        [TestCase("''", 0, "", 2)]
//        [TestCase("'a'", 0, "a", 3)]
//        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
//        {
//            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
//            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
//        }

//        // Добавьте свои тесты
//    }

//    class QuotedFieldTask
//    {
//        public static Token ReadQuotedField(string line, int startIndex)
//        {
//            return new Token(line, startIndex, line.Length - startIndex);
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture] // Таким атрибутом нужно пометить класс, чтобы система тестирования начала искать в нем тесты.
    public class QuotedFieldTaskTests
    {
        //[TestCase("''", 0, "", 2)] // не нужно помечать атрибутом [Test]
        //[TestCase("'a'", 0, "a", 3)] // каждый такой атрибут станет отдельным тестом

        //public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        //{
        //    var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
        //    Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        //}

        // Добавьте свои тесты
        //[TestMethod] // <= так нужно пометить метод, чтобы система тестирования поняла, что это тест.
        public void TestSolve() // обратите внимание, что метод не статический.
        {
            //Assert:
            Assert.AreEqual(("''", 0), ("", 2));
            Assert.AreEqual(("bcd ef", 0), ("a", 3));
        }
    }

    class QuotedFieldTask
    {
        /// <summary>
        /// Обрабатывает символы до следующей кавычки, если она есть, и возвращает токен поля в кавычках
        /// </summary>
        /// <param name="line">строка</param>
        /// <param name="startIndex">позиция в строке</param>
        /// <returns></returns>
        public static Token ReadQuotedField(string line, int startIndex)
        {
            var tokenValue = new StringBuilder(); // получаемая строка
            var stopСharacter = line[startIndex]; // символ выхода из программы
            var i = startIndex + 1; // начинаем проход предложения со 2го символа
            var countQuotes = 1; // т.к. начинаем обход со 2го символа
            while (i < line.Length)
            {
                // сохраняем символ для выхода из программы
                if (line[i] == stopСharacter)
                {
                    countQuotes++;
                    break;
                }

                // обрабатываем символ экранирования
                if (line[i] == '\\') 
                {
                    if (i + 1 == line.Length)
                    {
                        tokenValue.Append(line[i]);
                        break;
                    }
                    else if (line[i + 1] == '\'' || line[i + 1] == '\"' || line[i + 1] == '\\')
                    {
                        tokenValue.Append(line[i + 1]);
                        countQuotes++;
                        i += 2;
                    }
                    else
                    {
                        tokenValue.Append(line[i]);
                        i++;
                    }
                }

                // добавляем в предложение
                else
                {
                    tokenValue.Append(line[i]);
                    i++;
                }
            }
            
            // Отправка результата
            var value = tokenValue.ToString();
            var length = tokenValue.Length + countQuotes;
            var position = startIndex;
            return new Token(value, position, length); // Иллюстрация поясняющая семантику свойств класса Token при анализе текста.
        }
    }
}

/*
 * Подсказки:
 * 1) Не забывайте, что под startindex находится кавычка, которую тоже надо считать в длину токена.
 * 2) Экранирующий символ \, открывающая и закрывающая кавычки считаются в длину токена, но в итоговую строку не входят.
 */

/*
 * Использованные материалы:
 * Туториал по запуску тестов // Ulearn.me URL: https://ulearn.me/course/basicprogramming/Tutorial_po_zapusku_testov_c13df4c1-6fe9-4602-a2a8-c6a5c56a4333 (дата обращения: 04.11.2022).
 * How to solve the error "Must use PackageReference"? // stackoverflow URL: https://stackoverflow.com/questions/58540212/how-to-solve-the-error-must-use-packagereference (дата обращения: 04.11.2022).
 * Ошибка Must use PackageReference // cyberforum URL: https://www.cyberforum.ru/windows-forms/thread2812511.html (дата обращения: 04.11.2022).
 * Пошаговое руководство. Создание и запуск модульных тестов для управляемого кода // Microsoft URL: https://zetcode.com/csharp/nunit/ (дата обращения: 04.11.2022).
 * NUnit Documentation Site // NUnit URL: https://docs.nunit.org/ (дата обращения: 04.11.2022).
 */


