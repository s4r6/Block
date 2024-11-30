using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Block
{
    public class BlockView : MonoBehaviour
    {
        IBlock _blockStatus;
        SpriteRenderer _render;
        void Start()
        {
            _blockStatus = GetComponent<IBlock>();
            _render = GetComponent<SpriteRenderer>();
            _blockStatus.OnChangeHp += ChangeColor;
            
            ChangeColor();
        }

        void ChangeColor()
        {
            _render.color = new Color((255f - _blockStatus._hp * 50) / 255f, 1, 1);
        }
    }
}

