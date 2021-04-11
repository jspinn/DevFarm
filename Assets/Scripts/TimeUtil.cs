using UnityEngine;
using System.Diagnostics;
using System;

public class TimeUtil
{
    private Stopwatch sw_;
    // Timespan will represent the Timespan of one day.  
    private TimeSpan time_;
    private int day;
    private static TimeUtil instance;
    private static readonly object padlock = new object();

    public static TimeUtil Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new TimeUtil();
                }
                return instance;
            }
        }
    }

    // Add a way to use user to pass in a specified timespan.
    private TimeUtil(Stopwatch sw, TimeSpan time)
    {
        this.sw_ = sw;
        this.time_ = time;
       
    }

    // Default is 10 minutes == one day.
    private TimeUtil() : this(new Stopwatch(), new TimeSpan(0,0,10,0,0))
    { }

    public void StartStopWatch()
    {
        if (sw_.IsRunning)
        {
            UnityEngine.Debug.LogWarning("Stopwatch is already running.");
            return;
        }
        sw_.Start();
    }   

    // Should be called when the timerange has reached the specified timerange. Will reset if the timespan on the stopwatch has reached 
    // the timespan given in the constructor.   
    public TimeSpan ResetStopWatchandGetTimeSpan()
    {
        if (!sw_.IsRunning)
        {
            UnityEngine.Debug.LogWarning("Stopwatch hasn't started.");
            return TimeSpan.Zero;
        }
        TimeSpan time = sw_.Elapsed;
        day++;
        sw_.Stop();
        sw_.Reset();
        return time;
    }

    // Returns time in type Timespan  
    public TimeSpan GetStopWatchTimeSpan()
    {
        if (!sw_.IsRunning)
        {
            UnityEngine.Debug.LogWarning("Stopwatch hasn't started.");
            return TimeSpan.Zero;
        }
        TimeSpan time = sw_.Elapsed;
        return time;
    }

    public TimeSpan getTimeSpan()
    {
        return time_;
    }

    public bool isRunning()
    {
        return sw_.IsRunning;
    }

    public int getDays()
    {
        return day;
    }
}
