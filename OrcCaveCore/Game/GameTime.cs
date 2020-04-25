using System;
using System.Diagnostics;
using System.Timers;
using SDL2;

namespace OrcCave
{
    public class GameTime
    {
        private Stopwatch _stopwatch;

        public TimeSpan ElapsedTimeGame
        {
            get {
                return this._stopwatch.Elapsed;
            }
        }

        private GameTime()
        {
            this._stopwatch = new Stopwatch(); 
        }

        private static readonly object padlock = new object();
        private static GameTime instance = null;

        public static GameTime Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameTime();
                    }
                    return instance;
                }
            }
        }

        public void StartClock()
        {
            this._stopwatch.Start();
        }

        public void PauseClock()
        {
            this._stopwatch.Stop();
        }
        
    }

}
