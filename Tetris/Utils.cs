using System;
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

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    // Place the elements in the new array rotated 90 degrees to the right
                    result[j, N - i - 1] = matrix[i, j];
                }
            }

            return result;
        }
    }
}

