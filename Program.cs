using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        { int y = 10, x = 10;


            //initial grid with hard coded pattern
            int[,] grid = {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            Console.WriteLine("Initial Generation");
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (grid[i, j] == 0)
                        Console.Write(" . ");
                    else
                        Console.Write(" * ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            nextGeneration(grid, x, y);
        }

        /*Loop over the array
         *find neighbouring cells which are alive
         *implement the rules of life
         */
        public static void nextGeneration(int[,] grid, int x, int y)
        {
            int[,] nextGeneration = new int[y, x];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {

                    //liveNeighbours per cell
                    int liveNeighbours = 0;

                    /*~~checking for live cells around the current cell 
                    and if neighbouring cells are not out of array bounds
                    1.checking for diagonal upper left
                    2.checking for up
                    3.checking for diagonal upper right
                    4.checking for right
                    5.checking for diagonal bottom right 
                    6.checking for bottom
                    7.chegking for diagonal bottom left
                    7.checking for leftt
                    */
                    if(!isOutOfBounds(i-1,j-1,y,x))
                        if(grid[i-1,j-1] == 1) liveNeighbours++;

                    if(!isOutOfBounds(i-1,j,y,x))
                        if(grid[i-1,j] == 1) liveNeighbours++;

                    if(!isOutOfBounds(i-1,j+1,y,x))
                        if(grid[i-1,j+1] == 1) liveNeighbours++;

                    if(!isOutOfBounds(i,j+1,y,x))
                        if(grid[i,j+1] == 1) liveNeighbours++;

                    if(!isOutOfBounds(i+1,j+1,y,x))
                        if(grid[i+1,j+1] == 1) liveNeighbours++;

                    if(!isOutOfBounds(i+1,j,y,x))
                        if(grid[i+1,j] == 1) liveNeighbours++;

                    if(!isOutOfBounds(i+1,j-1,y,x))
                        if(grid[i+1,j-1] == 1) liveNeighbours++;

                    if(!isOutOfBounds(i,j-1,y,x))
                        if(grid[i,j-1] == 1) liveNeighbours++;


                    /*applying the rules of life!
                    *1.Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                    *2.Any live cell with more than three live neighbours dies, as if by overpopulation.
                    *3.Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                    *4.Any live cell with two or three live neighbours lives on to the next generation.
                    */
                    if((grid[i,j] == 1) && (liveNeighbours < 2)) nextGeneration[i,j] = 0;
                    else if((grid[i,j] == 1) && (liveNeighbours > 3)) nextGeneration[i,j] = 0;
                    else if((grid[i,j] == 0) && (liveNeighbours == 3)) nextGeneration[i,j] = 1;
                    else nextGeneration[i,j] = grid[i,j];

                    //reseting live neighbours
                    liveNeighbours = 0;

                }
            }

            //print the new generation of cells
            System.Console.WriteLine("New Generation");
            for(int q = 0; q < y; q++)
            {
                for(int p = 0; p < x; p++)
                {
                    if(nextGeneration[q,p] == 0)
                        System.Console.Write(" . ");
                    else
                        System.Console.Write(" * ");
                }
                System.Console.WriteLine();
            }
        }


        public static bool isOutOfBounds(int y, int x,int height, int width)
        {
            return (y < 0 || y >= height || x < 0 || x >= width);
            
        }
    }
}