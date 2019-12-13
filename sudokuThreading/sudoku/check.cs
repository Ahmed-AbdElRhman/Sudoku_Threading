using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace sudoku
{

    class check
    {
    public static int[,] puzzle =  {
    { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
    { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
    { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
    { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
    { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
    { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
    { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
    { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
    { 0, 0, 0, 0, 8, 0, 0, 7, 9 }

            }

;

        public bool check_row(int[,] puzzle,int row,int num)
        {
            int counter = 0;

            for(int i=0;i<9;i++)
            {
                if(puzzle[row,i]==num )
                {
                     counter++;
                }
            }
            if (counter == 1) return true;
            else return false;
        }



        public bool check_col(int[,] puzzle, int col, int num)
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
            {
                if (puzzle[ i,col] == num)
                {
                    counter++;
                }
            }
            if (counter == 1)return true;
            else return false;
        }


        public bool check_squer(int[,] puzzle, int row,int col, int num)
        {
            int counter = 0;
            int x = 0, y = 0;
            if (row < 3)
            {
                x = 0;
            }
            else if (row < 6)
            {
                x = 3;
            }
            else x = 6;

            if (col < 3)
            {
                y = 0;
            }
            else if (col < 6)
            {
                y = 3;
            }
            else y = 6;
            for (int i = x; i < x+3; i++)
            {
                for(int j=y;j<y+3;j++)
                {
                    if (puzzle[i, j] == num)
                    {
                        counter++;
                    }
                }
                
            }
            if (counter == 1) return true;
            else return false;
        }



        public bool check_availability()
        {
            Boolean b;
            int x;
            
            for(int i=0;i<9;i++)
            {
                for(int j=0;j<9;j++)
                {
                    x = puzzle[i, j];
                    if(x!=0)
                    {
                        b = (check_row(puzzle, i, x) && check_col(puzzle, j, x) && check_squer(puzzle, i, j, x));
                        if(!b)
                        {
                            return false;
                        }

                    }

                }
            }
            return true;
        }

        public bool IsAvailable(int[,] puzzle, int row, int col, int num)
        {
            int rowStart = (row / 3) * 3;
            int colStart = (col / 3) * 3;

            for (int i = 0; i < 9; ++i)
            {
                if (puzzle[row, i] == num) return false;
                if (puzzle[i, col] == num) return false;
                if (puzzle[rowStart + (i % 3), colStart + (i / 3)] == num) return false;
            }

            return true;
        }


    }
}
