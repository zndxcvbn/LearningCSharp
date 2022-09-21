
namespace ConsoleApp1
{
    internal class Program
    {
        private const int maxMove = 9;
       
        private static int move = 1;

        private static string[] board = { "0", 
            "1", "2", "3", 
            "4", "5", "6", 
            "7", "8", "9" };

        private static void SetMarkerColor(string pos)
        {
            switch (pos)
            {
                case "O":
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case "X":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
        }

        private static void DrawPosLeft(string pos)
        {
            Console.Write(" ");
            SetMarkerColor(pos);
            Console.Write("{0}", pos);
            Console.ResetColor();
            Console.Write(" | ");
        }
        private static void DrawPosMiddle(string pos)
        {
            SetMarkerColor(pos);
            Console.Write("{0}", pos);
            Console.ResetColor();
            Console.Write(" | ");
        }
        private static void DrawPosRight(string pos)
        {
            SetMarkerColor(pos);
            Console.WriteLine("{0}", pos, " ");
            Console.ResetColor();
        }

        private static void DrawBoard()
        {
            DrawPosLeft(board[1]); DrawPosMiddle(board[2]); DrawPosRight(board[3]);
            Console.ResetColor();
            Console.WriteLine("---+---+---");
            DrawPosLeft(board[4]); DrawPosMiddle(board[5]); DrawPosRight(board[6]);
            Console.ResetColor();
            Console.WriteLine("---+---+---");
            DrawPosLeft(board[7]); DrawPosMiddle(board[8]); DrawPosRight(board[9]);
            Console.ResetColor();
        }

        private static void ResetBoard()
        {
            move = 1;
            for (int i = 1; i <= maxMove; i++)
            {
                board[i] = i.ToString();
            }
        }

        private static bool IsLine(int cell1, int cell2, int cell3)
        {
            return board[cell1] == board[cell2] && board[cell2] == board[cell3];
        }

        private static bool Winner()
        {
            if (IsLine(1, 2, 3) ||
                IsLine(4, 5, 6) ||
                IsLine(7, 8, 9) ||

                IsLine(1, 5, 9) ||
                IsLine(7, 5, 3) ||

                IsLine(1, 4, 7) ||
                IsLine(2, 5, 8) ||
                IsLine(3, 6, 9)) return true;
            return false;
        }

        /* private static void MessageError(string _error)
        {
            Console.WriteLine(errorMsg);
            for (int i = 3; i > 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА! {0} Попробуйте снова через [{1}] ", _error, i);
                Console.ResetColor();
                Thread.Sleep(1000);
            }
        }*/

        private static int AskTheUser(string msg, int min, int max)
        {
            int choice;
            while (true)
            {
                Console.Write(msg);
                if (int.TryParse(Console.ReadLine(), out choice))
                    if (choice >= min && choice <= max) break;
            }
            return choice;
        }

        private static bool PlayAgain()
        {
            Console.WriteLine("Желаете сыграть ещё раз?");
            Console.WriteLine("     1. Сыграть снова");
            Console.WriteLine("     2. Выйти из игры");

            int choice = AskTheUser("Ваш выбор => ", 1, 2);

            Console.Clear();
            return choice == 1;
        }

        private static bool StartGame()
        {
            char choice;
            while (true)
            {
                Console.Clear();
                Console.Write("Добро пожаловать в игру ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Крестики - Нолики!");
                Console.ResetColor();
                Console.Write("Желаете сыграть против другого игрока? [");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("y");

                Console.ResetColor();
                Console.Write("/");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("n");

                Console.ResetColor();
                Console.Write("] ");

                if (char.TryParse(Console.ReadLine(), out choice))
                    if (choice == 'y' || choice == 'n') break;
            }
            return choice == 'y'; 
        }

        private static string TitleGameResult()
        {
            return Winner() ? $" Игрок {move % 2 + 1} победил!" : " НИЧЬЯ!";
        }

        private static void GameProcess()
        {
            int cell;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Игрок #1: X");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Игрок #2: O");
            Console.ResetColor();
            Console.WriteLine("");
            DrawBoard();

            Console.WriteLine("\n" + "Ход Игрока #" + (move % 2 == 0 ? "2" : "1") + "\n");

            cell = AskTheUser("Какую позицию желаете занять? => ", 1, 9);

            if (board[cell] != "X" && board[cell] != "O")
            {
                board[cell] = move % 2 == 0 ? "O" : "X";
                move++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ячейка [{0}] уже занята !", cell);

                for (int i = 3; i > 0; i--)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Пожалуйста подождите {0} сек. пока доска перезагрузится...", i);
                    Thread.Sleep(1000);
                }
            }
        }

        private static void EndGame()
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(TitleGameResult());
            Console.ResetColor();
            ResetBoard();
            Console.WriteLine("");
        }


        static void Main(string[] args)
        {
            bool playing = StartGame();

            while (playing)
            {
                while (!Winner() && move <= maxMove)
                {
                    GameProcess();
                }

                EndGame();

                playing = PlayAgain();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + "Игра завершена." + "\n");
            Console.ResetColor();
        }
    }
}