using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			// так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
			int intersection_left = Math.Max(r1.Left, r2.Left);
			int intersection_top = Math.Min(r1.Bottom, r2.Bottom);
			int intersection_right = Math.Min(r1.Right, r2.Right);
			int intersection_bottom = Math.Max(r1.Top, r2.Top); 

			return intersection_right >= intersection_left && intersection_top >= intersection_bottom;

		}


		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			int intersection_left = Math.Max(r1.Left, r2.Left);
			int intersection_top = Math.Min(r1.Bottom, r2.Bottom);
			int intersection_right = Math.Min(r1.Right, r2.Right);
			int intersection_bottom = Math.Max(r1.Top, r2.Top);

			int intersection_width = intersection_right - intersection_left;
			int intersection_height = intersection_top - intersection_bottom;
			
			return AreIntersected(r1, r2) ? (intersection_width * intersection_height) : 0;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			// Первый внутри второго
			if (r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Top >= r2.Top && r1.Bottom <= r2.Bottom)
				return 0;
			else if (r1.Left <= r2.Left && r1.Right >= r2.Right && r1.Top <= r2.Top && r1.Bottom >= r2.Bottom)
			return 1;
			else
				return -1;
		}
	}
}