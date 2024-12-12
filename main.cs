using System;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

        // Subscribe to events
        stopwatch.OnStarted += DisplayMessage;
        stopwatch.OnStopped += DisplayMessage;
        stopwatch.OnReset += DisplayMessage;

        bool exit = false;

        Console.WriteLine("Stopwatch Console Application");
        Console.WriteLine("=============================");
        Console.WriteLine("Commands:");
        Console.WriteLine("S - Start");
        Console.WriteLine("T - Stop");
        Console.WriteLine("R - Reset");
        Console.WriteLine("Q - Quit");
        Console.WriteLine("=============================\n");

        while (!exit)
        {
            Console.Write("Enter Command: ");
            var input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.S:
                    stopwatch.Start();
                    break;
                case ConsoleKey.T:
                    stopwatch.Stop();
                    break;
                case ConsoleKey.R:
                    stopwatch.Reset();
                    break;
                case ConsoleKey.Q:
                    exit = true;
                    Console.WriteLine("Exiting the application...");
                    break;
                default:
                    Console.WriteLine("Invalid Command. Use S, T, R, or Q.");
                    break;
            }
        }
    }

    static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}
