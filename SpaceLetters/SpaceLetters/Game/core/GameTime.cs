using SFML.Window;
using System;
using System.Diagnostics;

/// <summary>
/// This class manages the time computation, its used by AbstractGame.cs
/// </summary>
public class GameTime
{
    private Stopwatch watch;
    public TimeSpan TotalTime { get; private set; }
    public TimeSpan ElapsedTime { get; private set; }

    public GameTime()
    {
        watch = new Stopwatch();
        TotalTime = TimeSpan.FromSeconds(0);
        ElapsedTime = TimeSpan.FromSeconds(0);
    }

    public void Start()
    {
        watch.Start();
    }

    public void Stop()
    {
        watch.Reset();
        TotalTime = TimeSpan.FromSeconds(0);
        ElapsedTime = TimeSpan.FromSeconds(0);
    }

    public void Update()
    {
        ElapsedTime = watch.Elapsed - TotalTime;
        TotalTime = watch.Elapsed;
    }
}