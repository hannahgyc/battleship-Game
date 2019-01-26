using System;
namespace project1
{
    public class battleship
    {
        private const int TOTAL_SHIPS = 5;
        private const int BOARD_SIZE = 10;
        private int [,] board;
        private char [,] display;
        private int countShips;
        private bool isActive;

        public battleship()
        {
            setUpBoard();
        }
        /*
        hitShip(int, int)
        PRECONDITIONS:  Object is active.
        POSTCONDITIONS: Object can change to inactive or stay active.
        */
        public bool hitShip(int x, int y)
        {
            if (board[x,y] == 1 || board[x,y] == -1)
            {
                if (board[x,y] == 1)
                {
                    board[x,y] = -1;
                    display[x,y] = 'H';
                    countShips--;
                    updateActive();
                }
                return true;
            }
            display[x,y] = 'M';
            return false;
        }
        public char[,] displayBoard()
        {
            return display;
        }
        public int getSize()
        {
            return BOARD_SIZE;
        }
        /*
        reset()
        PRECONDITIONS: Object can be inactive or active.
        POSTCONDITIONS: Object is changed to active.
        */
        public void reset()
        {
            setUpBoard();
        }
        /*
        checkActive()
        PRECONDITIONS:  Object is active.
        POSTCONDITIONS: Object can change to inactive or stay active.
        */
        private void updateActive()
        {
            if (countShips < 1)
            {
                isActive = false;
            }
        }
        public bool getState()
        {
            return isActive;
        }
        /*
        setUpBoard()
        PRECONDITIONS: Object can be inactive or active.
        POSTCONDITIONS: Object is changed to active.
        */
        private void setUpBoard()
        {
            clearBoard();
            setShips();
            setActive();
        }
        /*
        setActive()
        PRECONDITIONS: Object can be inactive or active.
        POSTCONDITIONS: Object is changed to active.
        */
        private void setActive()
        {
            isActive = true;
        }
        private void setShips()
        {
            int x,y = 0;
            
            for (countShips = 0; countShips < TOTAL_SHIPS; countShips++)
            {
                
                do {
                    x = randomNumGenerator();
                    y = randomNumGenerator();
                } while (board[x,y] != 0);
                board[x,y] = 1;
            }
        }
        private int randomNumGenerator()
        {
            Random random = new Random();
            return (random.Next(0, BOARD_SIZE));
        }
        private void clearBoard()
        {
            countShips = 0;

            board = new int[BOARD_SIZE, BOARD_SIZE];
            display = new char[BOARD_SIZE, BOARD_SIZE];
            
            for(int i = 0; i < BOARD_SIZE; i++)
            {
                for(int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i,j] = 0;
                    display[i,j] = 'O';
                }
            }
        }
    }
}
