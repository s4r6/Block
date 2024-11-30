using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Block
{
    public class NormalBlock : MonoBehaviour,IBlock,IDamageable
    {
        public int _hp { get; private set; } = 1;
        public int _myScore { get; private set; } = 10;
        public event System.Action OnChangeHp;
        public event System.Action<int, IBlock> OnDestroyThis;
        public void Initialize(int hp, int score)
        {
            _hp = hp;
            _myScore = score;
        }

        public void AddDamage(int power)
        {
            if (_hp <= 0)
                Debug.LogError("•s³‚ÈHP‚Å‚·");

            _hp -= power;
            OnChangeHp?.Invoke();

            Debug.Log(_hp);

            if (_hp <= 0)
                Destroy(this.gameObject);
        }

        void OnDestroy()
        {
            OnDestroyThis?.Invoke(_myScore, this);
        }
    }
}

