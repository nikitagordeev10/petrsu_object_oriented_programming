using System;
using System.Drawing;
using NUnit.Framework;
using static Manipulation.Manipulator;

namespace Manipulation
{
    public static class AnglesToCoordinatesTask
    {
        /// <summary>
        /// По значению углов суставов возвращает массив координат суставов
        /// в порядке new []{elbow, wrist, palmEnd}
        /// </summary>
        public static PointF[] GetJointPositions(double shoulder, double elbow, double wrist)
        {
            /*
             * Длины суставов манипулятора
             * public const float UpperArm = 150;
             * public const float Forearm = 120;
             * public const float Palm = 60;
             */

            // Сначала вычислите координаты сустава elbow (локоть)
            var elbowX = UpperArm * Math.Cos(shoulder);
            var elbowY = UpperArm * Math.Sin(shoulder);
            var elbowPos = new PointF((float)elbowX, (float)elbowY);

            // угол наклона
            var angleElbow = elbow + shoulder - Math.PI;
            
            // относительно него вычислите координаты wrist (запястье)
            var wristX = Forearm * Math.Cos(angleElbow) + elbowX;
            var wristY = Forearm * Math.Sin(angleElbow) + elbowY;
            var wristPos = new PointF((float)wristX, (float)wristY);

            // угол наклона
            var angleWrist = wrist + angleElbow - Math.PI;
            
            // а относительно него — координаты кончика palm (ладонь)
            var palmX = Palm * Math.Cos(angleWrist) + wristX;
            var palmY = Palm * Math.Sin(angleWrist) + wristY;
            var palmEndPos = new PointF((float)palmX, (float)palmY);

            // возвращает массив координат суставов
            return new PointF[]
            {
                elbowPos,
                wristPos,
                palmEndPos
            };
        }
    }

    [TestFixture]
    public class AnglesToCoordinatesTask_Tests
    {
        // Доработайте эти тесты!
        // С помощью строчки TestCase можно добавлять новые тестовые данные.
        // Аргументы TestCase превратятся в аргументы метода.
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI, Manipulator.Forearm + Manipulator.Palm, Manipulator.UpperArm)]
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI / 2, Forearm, UpperArm - Palm)]
        [TestCase(Math.PI / 2, 3 * Math.PI / 2, 3 * Math.PI / 2, -Forearm, UpperArm - Palm)]
        [TestCase(Math.PI / 2, Math.PI, 3 * Math.PI, 0, Forearm + UpperArm + Palm)]
        public void TestGetJointPositions(double shoulder, double elbow, double wrist, double palmEndX, double palmEndY)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(shoulder, elbow, wrist);
            Assert.AreEqual(palmEndX, joints[2].X, 1e-5, "palm endX");
            Assert.AreEqual(palmEndY, joints[2].Y, 1e-5, "palm endY");
            //Assert.Fail("TODO: проверить, что расстояния между суставами равны длинам сегментов манипулятора!");
            Assert.AreEqual(UpperArm, Distance(joints[0], new PointF(0, 0)), 1e-5, "upper arm length");
            Assert.AreEqual(Forearm, Distance(joints[1], joints[0]), 1e-5, "forearm length");
            Assert.AreEqual(Palm, Distance(joints[2], joints[1]), 1e-5, "palm length"); 
        }

        // функция подсчёта
        public static double Distance(PointF a, PointF b)
        {
            double dx = b.X - a.X;
            double dy = b.Y - a.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}

/*
 * Подсказки:
 * 1) Сначала вычислите координаты сустава elbow, относительно него вычислите координаты wrist, а относительно него — координаты кончика palm.
 * 2) Угол между горизонталью и суставом forearm можно вычислить так: shoulder + Math.PI + elbow
 * 3) Угол между горизонталью и суставом palm можно вычислить так: shoulder + Math.PI + elbow + Math.PI + wrist
 * 4) При тестировании не забудьте, что углы могут быть и отрицательными.
*/

/*
 * Материалы:
 * Модульное тестирование кода C# с использованием NUnit и .NET Core // Microsoft URL: https://learn.microsoft.com/ru-ru/dotnet/core/testing/unit-testing-with-nunit?cid=kerryherger (дата обращения: 19.11.2022).
 * Как найти координаты точки зная длину отрезка // ПК знаток URL: https://pcznatok.ru/kompjutery/kak-najti-koordinaty-tochki-znaja-dlinu-otrezka.html (дата обращения: 19.11.2022).
 * Расчет углов. Задание манипулятор // cyberforum URL: https://www.cyberforum.ru/csharp-beginners/thread2018107.html (дата обращения: 19.11.2022).
 * Как узнать координаты точки на окружности, зная только радиус? // Хабр URL: https://qna.habr.com/q/392212 (дата обращения: 19.11.2022).
*/