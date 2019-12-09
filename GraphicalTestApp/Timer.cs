using System;
using System.Diagnostics;

namespace GraphicalTestApp
{
    class Timer
    {
        private Stopwatch _stopwatch = new Stopwatch();

        private long _currentTime = 0;
        private long _previousTime = 0;

        private float _deltaTime = 0.005f;

        //Creates a new Timer and starts it ticking
        public Timer()
        {
            _stopwatch.Start();
        }

        //Reset the time to 0 and continue ticking
        public void Restart()
        {
            _stopwatch.Restart();
        }

        //The time in seconds that have ellapsed
        public float Seconds
        {
            get { return _stopwatch.ElapsedMilliseconds / 1000.0f; }
        }

        //The time in seonds that have elapsed since the last GetDeltaTime() call
        public float GetDeltaTime()
        {
            _previousTime = _currentTime;
            _currentTime = _stopwatch.ElapsedMilliseconds;
            _deltaTime = (_currentTime - _previousTime) / 1000.0f;
            return _deltaTime;
        }
    }
}
