using System;
using System.Collections.Generic;
using System.Text;

namespace sudoku
{
    class solver
    {
        check availability = new check();

        public bool SolveSudoku(int[,] puzzle, int row, int col)
        {
            if (row < 9 && col < 9)
            {
                //-------
                if (puzzle[row, col] != 0)
                {
                    if ((col + 1) < 9) return SolveSudoku(puzzle, row, col + 1);
                    else if ((row + 1) < 9) return SolveSudoku(puzzle, row + 1, 0);
                    else return true;
                }

                else
                {
                    for (int i = 0; i < 9; ++i)
                    {
                        if (availability.IsAvailable(puzzle, row, col, i + 1))
                        {
                            puzzle[row, col] = i + 1;

                            if ((col + 1) < 9)
                            {
                                if (SolveSudoku(puzzle, row, col + 1)) return true;
                                else puzzle[row, col] = 0;
                            }
                            else if ((row + 1) < 9)
                            {
                                if (SolveSudoku(puzzle, row + 1, 0)) return true;
                                else puzzle[row, col] = 0;
                            }
                            else return true;
                        }
                    }
                }//else

                return false;

            }//-------End If
            else return true;
        }


        public void print(int[,] puzzle)
        {
            Console.WriteLine("+-----+-----+-----+");
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    Console.Write("|" + puzzle[i - 1, j - 1]);
                }
                Console.WriteLine("|");
                if (i % 3 == 0) Console.WriteLine("+-----+-----+-----+");

            }
        }


    }
}


            