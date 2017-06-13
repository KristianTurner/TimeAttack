using System;
using System.Diagnostics;
using System.IO;

namespace TimeAttack
{
    internal class Attempt
    {
        private Stopwatch _timer;
        private TimeSpan _player1timer;
        private TimeSpan _player2timer;

        public Attempt()
        {
            _timer = new Stopwatch();
        }
        public string Player1Result => _player1timer.ToString("s\\.ff");
        public string Player2Result => _player2timer.ToString("s\\.ff");


        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
            if (File.Exists(@"c:\temp\Attempts.txt"))
            {
                File.AppendText($"Competetor 1: {Player1Result} | Competetor 2: {Player2Result}");
            }
            else
            {
                File.Create(@"c:\temp\test.txt");
                File.AppendText($"Competetor 1: {Player1Result} | Competetor 2: {Player2Result}");
            }
        }
    }
}