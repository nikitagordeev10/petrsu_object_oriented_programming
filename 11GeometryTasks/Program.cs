using System;

// В этом проекте создайте два класса, Vector и Geometry, в пространстве имен GeometryTasks.
// Оба класса разместите в одном файле. Вообще-то так обычно делать не стоит,
// но так удобнее для нашей автоматической проверки выполнения задания.
namespace GeometryTasks {
    // В классе Vector должно быть два публичных поля,
    // X и Y, типа double.
    public class Vector {
        //Так объявляется поле класса.
        //Оно не статическое, т.е. не является глобальной переменной. 
        public double X;
        public double Y;
    }
    // В классе Geometry должно быть два статических метода:
    // GetLength, который возвращает длину переданного вектора, и
    // Add, который возвращает сумму двух переданных векторов.
    public class Geometry {
        //Так объявляется поле класса.
        //Оно не статическое, т.е. не является глобальной переменной. 
        public static double GetLength(Vector vector) {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector vector1, Vector vector2) {
            return new Vector { X = vector1.X + vector2.X, Y = vector1.Y + vector2.Y };
        }

        // Добавьте метод Geometry.GetLength, вычисляющий длину сегмента, и 
        public static double GetLength(Segment segment) {
            double dX = Math.Abs(segment.End.X - segment.Begin.X);
            double dY = Math.Abs(segment.End.Y - segment.Begin.Y);
            return Math.Sqrt((dX * dX) + (dY * dY));
        }

        // метод Geometry.IsVectorInSegment(Vector, Segment), проверяющий, что задаваемая вектором точка лежит в отрезке.
        public static bool IsVectorInSegment(Vector vector, Segment segment) {
            if (vector.X == segment.Begin.X && vector.X == segment.End.X && vector.Y == segment.Begin.Y && vector.Y == segment.End.Y) return true;
            else 
                return ((vector.X - segment.Begin.X) * (segment.End.Y - segment.Begin.Y) == (segment.End.X - segment.Begin.X) * (vector.Y - segment.Begin.Y))  
                    && (vector.X >= segment.Begin.X && vector.X <= segment.End.X && vector.Y >= segment.Begin.Y && vector.Y <= segment.End.Y); 
            }
        }

    // Создайте класс Segment, представляющий отрезок прямой.
    // Концы его отрезков должны задаваться двумя публичными полями: Begin и End типа Vector.
    public class Segment {
        //Так объявляется поле класса.
        //Оно не статическое, т.е. не является глобальной переменной. 
        public Vector Begin;
        public Vector End;
    }

}

/*
 * Материалы задание 1:
 * Практика «Вектор» // ULearn.me URL: https://ulearn.me/course/basicprogramming/Praktika_Vektor__e6b85bbf-1dbf-4099-84db-906579169b8d (дата обращения: 27.11.2022).
 * Классы // ULearn.me URL: https://ulearn.me/course/basicprogramming/Klassy_9eb68528-17cb-4d7f-99f3-40210a8f6cef (дата обращения: 27.11.2022).
 * Статическое и динамическое // ULearn.me URL: https://ulearn.me/course/basicprogramming/Staticheskoe_i_dinamicheskoe_9ab27cb1-cd14-4248-89d5-5981490bb766 (дата обращения: 27.11.2022).
 * Методы расширения // ULearn.me URL: https://ulearn.me/course/basicprogramming/Metody_rasshireniya_01a1f9a5-c475-4af3-bef3-060f92e69a92 (дата обращения: 27.11.2022).
 * Вычисление длины вектора по его координатам. // URL: http://images.myshared.ru/4/159798/slide_3.jpg (дата обращения: 27.11.2022).
 * Как вычислить сумму векторов // URL: https://prezentacii.org/upload/cloud/19/01/114609/images/screen9.jpg (дата обращения: 27.11.2022).
 */

/*
 * Материалы задание 2:
 * Calculating the arc length of a circle segment // StackExchange URL: https://math.stackexchange.com/questions/830413/calculating-the-arc-length-of-a-circle-segment (дата обращения: 27.11.2022).
 * Лежит ли точка на отрезке прямой? // CyberForum URL: https://www.cyberforum.ru/geometry/thread2427522.html (дата обращения: 27.11.2022).
 * Ошибка в методе // CyberForum URL: https://www.cyberforum.ru/csharp-beginners/thread2189480.html (дата обращения: 27.11.2022).
 * Определить, принадлежит ли точка отрезку // CyberForum URL: https://www.cyberforum.ru/csharp-beginners/thread605547.html (дата обращения: 27.11.2022).
 */