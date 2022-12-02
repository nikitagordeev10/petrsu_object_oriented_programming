namespace Mazes
{
	public static class DiagonalMazeTask
	{
        public static void MoveOut(Robot robot, int width, int height)
        {
            //while (!robot.Finished)
            //{
                robot.MoveTo(Direction.Right);
                robot.MoveTo(Direction.Down);
            //}
        }
    }
}