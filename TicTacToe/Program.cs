using System;

namespace TicTacToe
{
    class Program
    {
        static int[,] grid = new int[3, 3];     // 0 = empty, 1 = player one, 2 = player 2
        static int active_player = 2;           // 1 = player 1's turn, 2 = player 2's turn
        static bool is_game_over = false;
        static bool try_again = false;
        
        static string player_1_name;
        static string player_2_name;

        static int turn = 1;



        static void Main(string[] args)
        {
            // Print welcome message
            Console.WriteLine("Hello!\n");


            // Take player's names
            Console.Write("Player 1 name: ");
            player_1_name = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Player 2 name: ");
            player_2_name = Console.ReadLine();
            Console.WriteLine();

            draw_grid();



            // Game loop
            while (is_game_over == false)
            {
                Console.WriteLine();

                if (try_again == false)
                {
                    if (active_player == 2)
                    {
                        active_player = 1;
                        Console.WriteLine($"{player_1_name} [X]");

                    }
                    else
                    {
                        active_player = 2;
                        Console.WriteLine($"{player_2_name} [O]");
                    }
                }

                

                // Ask 'active_player' for input (row, column)
                try
                {
                    Console.Write("Row: ");
                    int row = Int32.Parse(Console.ReadLine());

                    Console.Write("Column: ");
                    int column = Int32.Parse(Console.ReadLine());

                    if (row < 3 && row > -1 && column < 3 && column > -1)
                    {
                        // Place the symbol
                        bool was_placed = place_symbol(row, column, active_player);

                        if (was_placed == true)
                        {

                            // Draw updated grid (state of the game)
                            Console.Clear();
                            Console.Write($"Hello!\n\nPlayer 1 name: {player_1_name}\n\nPlayer 2 name: {player_2_name}\n\n");
                            draw_grid();

                            // Check if victorious
                            if (check_for_winner(active_player) == true)
                            {
                                is_game_over = true;

                            }

                            //Check if out of moves
                            if (turn == 9)
                            {
                                is_game_over = true;
                            }

                            turn++;
                            try_again = false;
                        }
                        else
                        {
                            Console.WriteLine("Try again!");
                            try_again = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                        try_again = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Select two numbers from 0 to 2");
                    try_again = true;
                }
            }


            // Game over
            if (check_for_winner(active_player) == true && active_player == 1)
            {
                Console.Write($"Game over! {player_1_name} won!");
            }
            else if (check_for_winner(active_player) == true && active_player == 2)
            {
                Console.Write($"Game over! {player_2_name} won!");
            }
            else if (is_game_over == true)
            {
                Console.Write("Game over!");
            }

            Console.ReadLine();
        }


        static bool place_symbol(int row, int column, int symbol)
        {
            if (grid[row, column] == 0)
            {
                grid[row, column] = symbol;

                return true;
            }
            else
            {
                return false;
            }
        }


        static bool check_for_winner(int symbol)
        {
            // Check all rows

            // Row 1
            if (grid[0, 0] == symbol && grid[0, 1] == symbol && grid[0, 2] == symbol)
            {
                return true;
            }
            // Row 2
            if (grid[1, 0] == symbol && grid[1, 1] == symbol && grid[1, 2] == symbol)
            {
                return true;
            }
            // Row 3
            if (grid[2, 0] == symbol && grid[2, 1] == symbol && grid[2, 2] == symbol)
            {
                return true;
            }



            // Check all columns

            // Column 1
            if (grid[0, 0] == symbol && grid[1, 0] == symbol && grid[2, 0] == symbol)
            {
                return true;
            }
            // Column 2
            if (grid[0, 1] == symbol && grid[1, 1] == symbol && grid[2, 1] == symbol)
            {
                return true;
            }
            // Column 3
            if (grid[0, 2] == symbol && grid[1, 2] == symbol && grid[2, 2] == symbol)
            {
                return true;
            }



            // Check diagonals

            // Forward diagonal:    '/'
            if (grid[0, 0] == symbol && grid[1, 1] == symbol && grid[2, 2] == symbol)
            {
                return true;
            }
            // Backwards diagonal:  '\'
            if (grid[2, 0] == symbol && grid[1, 1] == symbol && grid[0, 2] == symbol)
            {
                return true;
            }



            return false;
        }



        static string draw_symbol(int state)
        {
            if (state == 1)
            {
                return "X";
            }
            else if (state == 2)
            {
                return "O";
            }
            else
            {
                return " ";
            }
        }



        static void draw_grid()
        {
            Console.Write("\n");
            Console.Write("      [0]   [1]   [2]\n");
            Console.Write("    -------------------\n");
            Console.Write("    |     |     |     |\n");
            Console.Write("[0] |  " + draw_symbol(grid[0, 0]) + "  |  " + draw_symbol(grid[0, 1]) + "  |  " + draw_symbol(grid[0, 2]) + "  |\n");
            Console.Write("    |     |     |     |\n");
            Console.Write("    -------------------\n");
            Console.Write("    |     |     |     |\n");
            Console.Write("[1] |  " + draw_symbol(grid[1, 0]) + "  |  " + draw_symbol(grid[1, 1]) + "  |  " + draw_symbol(grid[1, 2]) + "  |\n");
            Console.Write("    |     |     |     |\n");
            Console.Write("    -------------------\n");
            Console.Write("    |     |     |     |\n");
            Console.Write("[2] |  " + draw_symbol(grid[2, 0]) + "  |  " + draw_symbol(grid[2, 1]) + "  |  " + draw_symbol(grid[2, 2]) + "  |\n");
            Console.Write("    |     |     |     |\n");
            Console.Write("    -------------------\n");
        }
    }
}
