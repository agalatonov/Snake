using System.Text;


Logic logic = new Logic();
logic.Start();

public class Logic
{

    public void Start()
    {
        Frame frame = new Frame(20, 20);
        frame.PaintFrame();
        Snake snake = new Snake();
        snake.Start();
        snake.UpdatePosition(Console.ReadKey().Key);
        Console.ReadKey();
    }

    public class Frame
    {
        public int _x;
        public int _y;

        public Frame(int x, int y)
        {
            _x= x;
            _y= y;
        }
        public void PaintFrame()
        {
            StringBuilder topLine = new StringBuilder();
            for (int i = 0; i < _x; i++)
            {
                topLine.Append("-");
            }
            Console.WriteLine(topLine);
            StringBuilder middleLine = new StringBuilder();

            for (int i = 0; i < _x; i++)
            {          
                if ((i == 0) || (i + 1 == _x))
                {
                    middleLine.Append("|");
                }
                else
                {
                    middleLine.Append(" ");
                }
            }

            for (int j = 0; j < _y; j++)
            {
                Console.WriteLine(middleLine);
            }

            Console.WriteLine(topLine);
        }
    }

    public class Snake
    {
        public readonly HeadPosition headPosition;

        public Snake()
        {
            headPosition = new HeadPosition();
        }

        public void Start()
        {
           
            Console.SetCursorPosition(headPosition.x, headPosition.y);
            Console.WriteLine("*");
        }

        public void UpdatePosition(ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.RightArrow:
                    {
                        this.headPosition.x++;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        this.headPosition.x--;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        this.headPosition.y++;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        this.headPosition.y--;
                        break;
                    }
            }

            Console.SetCursorPosition(headPosition.x, headPosition.y);
            Console.WriteLine("*");
        }
        public class HeadPosition
        {
            public int x = 1;
            public int y = 1;
        }
    }

}
