using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;
namespace Block
{
    public interface IBlock
    {
        int _myScore { get; }
        int _hp { get; }
        event System.Action OnChangeHp;
        event System.Action<int, IBlock> OnDestroyThis;
        void Initialize(int hp, int score);
    }

}
