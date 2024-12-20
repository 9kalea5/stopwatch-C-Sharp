using System;
using System.Threading;

public class Stopwatch
{
    public delegate void StopwatchEventHandler(string message);
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    private int _timeElapsed;
    private bool _isRunning;
    private Timer _timer;

    public Stopwatch()
    {
        _timeElapsed = 0;
        _isRunning = false;
    }

    public void Start()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            _timer = new Timer(Tick, null, 0, 1000);
            OnStarted?.Invoke("Stopwatch Started!");
        }
        else
        {
            Console.WriteLine("Stopwatch is already running.");
        }
    }

    public void Stop()
    {
        if (_isRunning)
        {
            _isRunning = false;
            _timer.Dispose();
            OnStopped?.Invoke("Stopwatch Stopped!");
        }
        else
        {
            Console.WriteLine("Stopwatch is not running.");
        }
    }

    public void Reset()
    {
        _timeElapsed = 0;
        if (_isRunning)
        {
            _timer.Dispose();
            _timer = new Timer(Tick, null, 0, 1000);
        }
        OnReset?.Invoke("Stopwatch Reset!");
    }

    private void Tick(object state)
    {
        _timeElapsed++;
        Console.WriteLine($"Time Elapsed: {_timeElapsed} seconds");
    }
}
