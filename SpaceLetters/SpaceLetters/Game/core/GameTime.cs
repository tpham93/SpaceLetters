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
    public TimeSpan tmpTotalTime { get; private set; }
    public TimeSpan tmpElapsedTime { get; private set; }

    public GameTime()
    {
        watch = new Stopwatch();
        TotalTime = TimeSpan.FromSeconds(0);
        ElapsedTime = TimeSpan.FromSeconds(0);
    }

    public void ReStart()
    {
        watch.Restart();
        TotalTime = tmpTotalTime;
        ElapsedTime = tmpElapsedTime;
    }
    public void Start()
    {
        watch.Restart();
        TotalTime = TimeSpan.FromSeconds(0);
        ElapsedTime = TimeSpan.FromSeconds(0);
    }

    public void Stop()
    {
        watch.Reset();
    }

    public void Update()
    {
        ElapsedTime = watch.Elapsed;
        TotalTime += watch.Elapsed;
        watch.Reset();
        watch.Restart();
    }
}