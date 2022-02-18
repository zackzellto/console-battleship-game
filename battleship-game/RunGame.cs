using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace battleship_game
{
     class Battleship
    {
        public int Missiles;
        public int EnemyBattleshipHealth;
        public string[,] boardGrid;

        string DisplayInstructions()
        {
            WriteLine("Welcome to Battleship!");
            WriteLine("The instructions are as followed:");
            WriteLine("1) The game is played on a 10 x 10 grid consisting of X-Coordinates: ABCDEFGHIJ and Y-Coordinates of 0123456789");
            WriteLine("2) To fire your missiles at the enemy ships, you must enter coordinates; (Example: A4, or D9");
            WriteLine("3) You have 8 missles at your disposal to try to sink the enemies Battleship!");
            WriteLine("4) If you have hit the enemy ship, you will be notified with HIT, or if you missed your shot, you will see MISS");
            WriteLine("5) After you've used up all of your missiles your Armada must retreat!");

            WriteLine("Press any key to start the battle!");

            ReadKey();

        return DisplayInstructions();
        }

        public WatersOfWar()
        {

            EnemyBattleshipHealth = 5;
            Missiles = 8;
            boardGrid = fillBoard();

            Random enemyCoords = new Random();
            int enemyY = enemyCoords.Next(0, 5);
            int enemyX = enemyCoords.Next(0, 10);

            EnemyYPosition5 = enemyY++;
            EnemyYPosition4 = enemyY++;
            EnemyYPosition3 = enemyY++;
            EnemyYPosition2 = enemyY++;
            EnemyYPosition1 = enemyY++;
            EnemyXPosition = enemyX;
        }


        public void drawGameBoard()
        {
            WriteLine("  A B C D E F G H I J");
            WriteLine(" ____________________");
        }

        static string[,] fillBoard()
        {
            string[,] boardContents = new string[10, 10];

            for (int i = 0; i < boardContents.GetLength(0); i++)
            {
                for (int j = 0; j < boardContents.GetLength(1); j++)
                {
                    boardContents[i, j] = "[ ~ ]";
                }
            }
            return boardContents;
        }

        public void startGame()
        {
           
            WriteLine("The Battle Has Commenced! Fire At The Enemy!");


        }
    }
}
