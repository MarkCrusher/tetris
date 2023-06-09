namespace Tetris
{
	public class Utils
	{
		public Utils()
		{
		}

        public static int[,] RotateMatrix90DegreesClockwise(int[,] matrix)
        {
            int N = matrix.GetLength(0); // Number of rows
            int M = matrix.GetLength(1); // Number of columns

            // Create new array of MxN
            int[,] result = new int[M, N];

            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    // Place the elements in the new array rotated 90 degrees to the right
                    result[col, N - row - 1] = matrix[row, col];
                }
            }

            return result;
        }
    }
}

