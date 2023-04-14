using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;


Snake snake = new Snake();


while (true)
{
    Console.Clear();
    Frame frame = new Frame(20, 20);
    frame.PaintFrame();
    snake.Logic();
    snake.Draw();
}

public class Frame
{
    public int _x;
    public int _y;

    public Frame(int x, int y)
    {
        _x = x;
        _y = y;
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
    public HeadPosition headPosition;

    public Snake()
    {
        headPosition = new HeadPosition();
    }

    ConsoleKey directToCrawl = ConsoleKey.DownArrow;
    public void Input()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            directToCrawl = keyInfo.Key;
        }
    }

    public void Logic()
    {
        Input();
        UpdatePosition(directToCrawl);
        Draw();
        Thread.Sleep(400);
    }
    public void Draw()
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
                    this.headPosition.y--;
                    break;
                }
            case ConsoleKey.DownArrow:
                {
                    this.headPosition.y++;
                    break;
                }
        }
    }
    public class HeadPosition
    {
        public int x = 1;
        public int y = 1;
    }
}


