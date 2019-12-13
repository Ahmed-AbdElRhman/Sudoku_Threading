using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sudoku
{
    class Program
    {
        //public static bool flag;
        static void Main(string[] args)
        {


      int[,] puzzle =  {
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
            check availability = new check();
            solver solve = new solver();

            Stopwatch stopwach = new Stopwatch();

            // Creat checking thred && solving Thread 

            //-----------------How Sending puzzle Array as Object to availability.check_availability(puzzele)----
            Task<bool> check_thread  = new Task<bool>(availability.check_availability(puzzle));
            //---------------------------------------------------------------------------------------------------

            Thread solver_thread = new Thread     (()=> solve.SolveSudoku(puzzle, 0, 0));

            // Starting checking thread && solving Thread 
            check_thread.Start();
            solver_thread.Start();

            //Stop Wach
            stopwach.Start();
            // Wait checking thread till End TO get the return Value
            check_thread.Wait();

            if (!check_thread.Result)
            {
                solver_thread.Abort(); //Stop Solve Puzzle If not available (no solution)
                Console.WriteLine("this puzzle not available....ther is no solution!");
            }
            else
            {


                solver_thread.Join(); // Wait Till Solve Puzzele
                solve.print(puzzle);
            }

            stopwach.Stop();

            Console.WriteLine("\n Time :{0}", stopwach.ElapsedMilliseconds);

            Console.ReadKey();

        }
        //public static bool call()
        //{
        //    return availability.check_availability(puzzle);
        //}
        //public static void call2()
        //{
        //     solve.SolveSudoku(puzzle, 0, 0);
        //}
        //Task<bool> f1 = new Task(() => {
        //    for (int i = 0; i < 9; ++i)
        //    {
        //        if (availability.IsAvailable(puzzle, row, col, i + 1))
        //        {
        //            puzzle[row, col] = i + 1;

        //            if ((col + 1) < 9)
        //            {
        //                if (SolveSudoku(puzzle, row, col + 1)) return true;
        //                else puzzle[row, col] = 0;
        //            }
        //            else if ((row + 1) < 9)
        //            {
        //                if (SolveSudoku(puzzle, row + 1, 0)) return true;
        //                else puzzle[row, col] = 0;
        //            }
        //            else return true;
        //        }
        //    }
        //});

    }
}
