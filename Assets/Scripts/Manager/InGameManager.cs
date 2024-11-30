using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Timer;
using VContainer;
using System.Threading;
using System.Threading.Tasks;

public enum GameEndState
{
    GameOver,
    GameClear
}

namespace Manager
{
    public class InGameManager
    {
        readonly IInputProvider _input;
        readonly Timer.Timer _timer;

        public event System.Action OnStartGame;
        public event System.Action OnPauseGame;
        public event System.Action<GameEndState> OnEndGame;

        [Inject]
        public InGameManager(IInputProvider input, Timer.Timer timer)
        {
            _input = input;
            _timer = timer;
            OnStartGame += StartGame;
        }

        public async Task WaitForInputKey()
        {
            Debug.Log("Wait For Space Key Pressed");
            while(true)
            {
                if(_input._decision)
                {
                    Debug.Log("Space Key is Pressed !");
                    OnStartGame?.Invoke();
                    OnStartGame -= StartGame;
                    break;
                }
                await Task.Delay(50);
            }
        }

        void StartGame()
        {
            Debug.Log("ゲームスタート");
            _timer.StartTimer();
        }

        public void GameOver()
        {
            _timer.StopTimer(); //時間ストップ
            OnEndGame?.Invoke(GameEndState.GameOver);    //終了イベント発行
        }

        public void GameClear()
        {
            _timer.StopTimer();
            OnEndGame?.Invoke(GameEndState.GameClear);
        }
    }
}

