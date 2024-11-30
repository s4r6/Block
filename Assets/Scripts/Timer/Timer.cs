using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    public class Timer
    {
        public int _currentTime = 0;
        bool _isRunning = false;
        CancellationTokenSource cts;

        public void StartTimer()
        {
            if (_isRunning) return; //‚·‚Å‚É“®ì’†‚Ìê‡‚Í–³Ž‹

            _isRunning = true;
            cts = new CancellationTokenSource();

            Task.Run(async () =>
            {
                while (_isRunning && !cts.Token.IsCancellationRequested) //1•b‚²‚Æ‚ÉƒJƒEƒ“ƒg
                {
                    await Task.Delay(1000, cts.Token);
                    _currentTime += 1;
                }
            }, cts.Token);
        }

        public void StopTimer()
        {
            if (!_isRunning) return;

            _isRunning = false;
            cts.Cancel();
        }

        public void ResetTimer()
        {
            StopTimer();
            _currentTime = 0;
        }
    }

}
