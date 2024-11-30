using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class Score
    {
        static Score instance = null;
        public event System.Action OnScoreChanged;
        public int _score { get; private set; } = 0;

        public static Score CreateInstance()
        {
            if (instance == null)
                instance = new Score();

            return instance;
        }
        public void AddScore(int addValue)
        {
            if (addValue < 0)
                Debug.LogError("�s���ȉ��Z�l�ł�");

            _score += addValue;
            OnScoreChanged?.Invoke();
        }

    }
}

