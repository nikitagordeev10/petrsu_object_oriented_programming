namespace Mazes
{
	public static class EmptyMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
        {
            MakeHorizontalMove(robot, width);
            MakeVerticalMove(robot, height);

        }

        private static void MakeHorizontalMove(Robot robot, int width)
        {
            for (int i = 0; i < width -3; i++)
                robot.MoveTo(Direction.Right);
        }

        private static void MakeVerticalMove(Robot robot, int height)
        {
            for (int i = 0; i < height - 3; i++)
                robot.MoveTo(Direction.Down);
        }
    }
}