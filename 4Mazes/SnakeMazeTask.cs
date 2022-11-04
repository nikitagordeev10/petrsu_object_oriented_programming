namespace Mazes
{
    public static class SnakeMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            while (!robot.Finished)
            {
                MakeHorizontalMove(robot, width, Direction.Right);
                MoveDownMax(robot);
                MakeHorizontalMove(robot, width, Direction.Left);
                if (!robot.Finished)
                    MoveDownMax(robot);
            }
        }

        private static void MakeHorizontalMove(Robot robot, int width, Direction dir)
        {
            for (int i = 1; i < width - 2; i++)
                robot.MoveTo(dir);
        }

        private static void MoveDownMax(Robot robot)
        {
            robot.MoveTo(Direction.Down);
            robot.MoveTo(Direction.Down);
        }
    }
}