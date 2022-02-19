using System;
using static System.Console;
using System.Threading;



namespace battleship_game
{
     class WatersOfWar
    {
        public int Missiles;
        public int EnemyBattleshipHealth;
        public string[,] boardGrid;
        public int EnemyYPosition5;
        public int EnemyYPosition4;
        public int EnemyYPosition3;
        public int EnemyYPosition2;
        public int EnemyYPosition1;
        public int EnemyXPosition;



        public void enemyLocation(int missileY, int missileX)
        {

            if(boardGrid[missileX, missileY] == "[-]")
            {
                didMissileHit(missileY, missileX);
            }
            else
            {
                Clear();
                drawGameBoard();
                WriteLine("Location has already by fired upon, choose a different coordinate!");
            }
        }

        public void didMissileHit(int missleY, int missleX)
        {
            string targetStatus;

            var xPos = EnemyXPosition;
            var yPos1 = EnemyYPosition1;
            var yPos2 = EnemyYPosition2;
            var yPos3 = EnemyYPosition3;
            var yPos4 = EnemyYPosition4;
            var yPos5 = EnemyYPosition5;

            if (missleX == xPos && (missleY == yPos1 || missleY == yPos2 || missleY == yPos3 || missleY == yPos4 || missleY == yPos5))
            {
                
                boardGrid[missleX, missleY] = "[X]";
                EnemyBattleshipHealth-- ;
                targetStatus = "HIT!";
            }
            else
            {
                
                boardGrid[missleX, missleY] = "[O]";
                targetStatus = "MISS!";
            }

            Missiles--;
            Clear();
            drawGameBoard();

            WriteLine("Awaiting transmission...The outcome of the missile that was fired was a: {0}\n", targetStatus);
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
           
            ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    0   1   2   3   4   5   6   7   8   9    ");
            
            for (int i = 0; i < boardGrid.GetLength(0); i++)
            {
                Write("{0}| ", i);
                for (int j = 0; j < boardGrid.GetLength(1); j++)
                {
                    Write("{0} ", boardGrid[i, j]);
                }
                WriteLine("| ");
                
            }
            

            WriteLine($"\nEnemy Battleship Health: {EnemyBattleshipHealth}");
            WriteLine($"\nMissiles Left: {Missiles}");

        }

        static string[,] fillBoard()
        {
            string[,] boardContents = new string[10, 10];

            for (int i = 0; i < boardContents.GetLength(0); i++)
            {
                for (int j = 0; j < boardContents.GetLength(1); j++)
                {
                    boardContents[i, j] = "[~]";
                    BackgroundColor = ConsoleColor.DarkBlue;
                    ForegroundColor = ConsoleColor.White;
                }
            }
            return boardContents;
        }



        public void startGame()
        {
           
                WriteLine("Welcome to Battleship!");
                WriteLine("The instructions are as followed:");
                WriteLine("1) The game is played on a 10 x 10 grid consisting of X-Coordinates: 0123456789 and Y-Coordinates of 0123456789");
                WriteLine("2) To fire your missiles at the enemy ships, you must enter coordinates; (Example: 1, 4, or 8, 3");
                WriteLine("3) You have 8 missles at your disposal to try to sink the enemies Battleship!");
                WriteLine("4) If you have hit the enemy ship, you will be notified with HIT, or if you missed your shot, you will see MISS");
                WriteLine("5) If you hit the enemy Battleship 5 times you will SINK it!");
                WriteLine("6) After you've used up all of your missiles your Armada must retreat!");

            WriteLine("\n Battle will commence in 10 seconds. Prepare your fleet!");
            Thread.Sleep(500);

            
            

           

        PrepareNewGame:
            Clear();
            EnemyBattleshipHealth = 5;
            Missiles = 8;
            boardGrid = fillBoard();
            drawGameBoard();

            RestartGame:

            try
            {
                Console.Write("\nGive the strike coordinates for the latitude to be fire upon!: ");
                int missileX = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nGive the strike coordinates for the longitude to be fired upon!: ");
                int missileY = Convert.ToInt32(Console.ReadLine());

                didMissileHit(missileY, missileX);

            }
            catch (Exception e)
            {

                Console.Clear();
                drawGameBoard();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.WriteLine("Select the proper coordinates!\n");
                Console.ForegroundColor = ConsoleColor.White;
                goto RestartGame;
            }

            if (Missiles == 0 || EnemyBattleshipHealth == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Game Over!\nPress Y to play again!");
                Console.ForegroundColor = ConsoleColor.White;
                if (Console.ReadKey().Key != ConsoleKey.Y)
                {
                    Console.WriteLine("Pressed {0}\nThanks for playing!", Console.ReadKey().Key);
                }
                else
                {
                    goto PrepareNewGame;
                }

            }
            else
            {
                goto RestartGame;
            }
        }
    }
}
