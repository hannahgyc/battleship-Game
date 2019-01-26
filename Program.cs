/*
Hannah Chang
01.25.2019

Program Overview:   User can play battleship on a 10 x 10 board game.
                    Note that each ship takes up 1 space and there are
                    a total of 5 ships. The user can chose from the main
                    menu to: enter coordinates to attempt to hit a ship,
                    display the board game, reset the game to an entirely
                    new game with new ship placements, or exit the game.
                    When entering the x and y coordinates, the user can
                    only enter numbers 0 to 9. The board will update that
                    x,y coordinate with an 'H' for a hit or an 'M' for
                    a miss. After every attempt to hit a ship, the new
                    updated board will be displayed. The game ends when
                    all 5 ships are hit.

Driver Overview:    The driver will only select case 0 from the main menu;
                    attempting to hit a ship. The driver will randomly enter
                    x, y values between 0 and the size of the board-1 (9).
                    The program will end when all ships are hit.
*/

using System;
namespace project1
{
    class driver
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battle Ship!");
            Console.Write("I will place 5 ships on random spots on" +
                        " a 10 by 10 board game. Every time you hit" +
                        " a ship on the board I will update that" +
                        " space with 'H' and every time you miss" +
                        " a ship I will update that space with 'M'." +
                        " I will show you the updated board after " +
                        " every hit or miss." +
                        " Note: 1 ship takes up one space.");
            Console.WriteLine();
            playGame();
        }

        static void playGame()
        {
            battleship myGame = new battleship();
            bool play = true;
            int caseNum = 0;
            int totalCases = 3;

            while (play && myGame.getState())
            {
                Console.WriteLine();
                Console.WriteLine("Enter 0 to play.");
                Console.WriteLine("Enter 1 to display the board.");
                Console.WriteLine("Enter 2 to reset the board.");
                Console.WriteLine("Enter 3 to stop playing.");
                caseNum = 0;//randomNumGenerator(myGame, (totalCases-totalCases), (totalCases+1));

                switch (caseNum)
                {
                    case 0:
                        casePlay(myGame);
                        break;
                    case 1:
                        caseDisplay(myGame);
                        break;
                    case 2:
                        caseReset(myGame);
                        break;
                    case 3:
                        play = false;
                        Console.WriteLine();
                        Console.WriteLine("Exiting...");
                        break;
                }
            }
        }
        static int randomNumGenerator(battleship myGame, int min, int max)
        {
            Random random = new Random();
            return (random.Next(min, max));
        }
        static void caseReset(battleship myGame)
        {
            Console.WriteLine();
            Console.WriteLine("Reseting the game...");
            myGame.reset();
        }
        static void caseDisplay(battleship myGame)
        {
            Console.WriteLine();
            int s = myGame.getSize();
            char [,] display = new char[s, s];

            display = myGame.displayBoard();

            for(int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    Console.Write(display[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void casePlay(battleship myGame)
        {
            int x,y = 0;
            
            
            do{
                Console.WriteLine();
                Console.WriteLine("Enter an x value between 0 and 3.");
                x = randomNumGenerator(myGame, 0, myGame.getSize());
            } while (x < 0 || x >= myGame.getSize());
                      
            do{
                Console.WriteLine("Enter a y value between 0 and 3.");
                y = randomNumGenerator(myGame, 0, myGame.getSize());
            } while (y < 0 || y >= myGame.getSize());

            Console.WriteLine();
            Console.WriteLine("Attempting to hit (" + x + ", " + y + ")..." +
                                myGame.hitShip(x,y));
            caseDisplay(myGame);           
        }
    }
}
