using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger {
    //Напишите здесь классы Player, Terrain и другие.

    // Сделайте класс Terrain, реализовав ICreature. Сделайте так, чтобы он ничего не делал.
    public class Terrain : ICreature {
        
        // Действовать — возвращать направление перемещения и, если объект во что-то превращается на следующем ходу, то результат превращения.
        public CreatureCommand Act(int x, int y) {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        // Разрешать столкновения двух элементов в одной клетке.
        public bool DeadInConflict(ICreature conflictedObject) {
            return true;
        }
        
        // Сообщать приоритет отрисовки. Чем выше приоритет, тем раньше рисуется соответствующий элемент, это важно для анимации.
        public int GetDrawingPriority() {
            return 2;
        }

        // Возвращать имя файла, в котором лежит соответствующая ему картинка (например, "Terrain.png")
        public string GetImageFileName() {
            return "Terrain.png";
        }
    }


    public class Player : ICreature {
        //Координатные поля
        public static int X, Y = 0;
        public static int dX, dY = 0;

        // Действовать — возвращать направление перемещения и, если объект во что-то превращается на следующем ходу, то результат превращения.
        public CreatureCommand Act(int x, int y) {
            
            // Координаты поля
            X = x;
            Y = y;

            //Обработка нажатия клавиш присвоение значений дельтам
            switch (Game.KeyPressed) {
                case System.Windows.Forms.Keys.Up: // Вверх
                    dY = -1;
                    dX = 0;
                    break;
                case System.Windows.Forms.Keys.Down: // Вниз
                    dY = 1;
                    dX = 0;
                    break;
                case System.Windows.Forms.Keys.Right: // Вправо
                    dY = 0;
                    dX = 1;
                    break;
                case System.Windows.Forms.Keys.Left: // Влево
                    dY = 0;
                    dX = -1;
                    break;
                default: // Иначе
                    Stay();
                    break;
            }

            //Запрет выхода за пределы карты 
            if (!(x + dX >= 0 && x + dX < Game.MapWidth && y + dY >= 0 && y + dY < Game.MapHeight)) 
                Stay();

            //возвращение следующих координат отрисовки
            return new CreatureCommand() { DeltaX = dX, DeltaY = dY };
        }

        // Разрешать столкновения двух элементов в одной клетке.
        public bool DeadInConflict(ICreature conflictedObject) {
            return false;
        }

        // Сообщать приоритет отрисовки. Чем выше приоритет, тем раньше рисуется соответствующий элемент, это важно для анимации.
        public int GetDrawingPriority() {
            return 1;
        }

        // Возвращать имя файла, в котором лежит соответствующая ему картинка (например, "Digger.png")
        public string GetImageFileName() {
            return "Digger.png";
        }

        // Не делать шагов
        private static void Stay() {
            dX = 0;
            dY = 0;
        }
    }
}


/* Подсказки в комментариях:
 * Класс Terrain
 * 1) Сделайте класс Terrain, реализовав ICreature.
 * 2) GetImageFileName() Возвратите имя объекта, его можна посмотреть в папке с проектом.
 * 3) Метод Act(x,y) (отвечает за перемещение объекта). Кубики земли статические элемент.
 * 4) DeadInConflict(conflictedObject) метод который определяет (по факту ссылку) есть ли на одном поле два объекта.
 * 5) GetDrawingPriority() Приоритет анимации.
 * Класс Player
 * 1) Сделайте класс Player, реализовав ICreature.
 * 2) Метод Act(x,y) (отвечает за перемещение объекта).
 *  * Х/У которые принимает клас это координаты Player.
 *  * DeltaX\Y это смещение Player в соответствующем направление по координате.
 *  * 2.А) Написать логику реакции Player на клавиши (left, right, up, down) изучив Game.KeyPressed.
 *  * 2.Б) В каждой логике определить смещение Player
 *  * 2.В) Не забыть про выход за края карты
 *  * 2.Г) Смещение одномоментно! Если про это забыть Player будет двигаться постоянно.
 * 3) Реализуйте логику исчезновения земли на месте где стоит Player.
 * Изучите class CreatureCommand и пункт 4 класса Terrain.
 */