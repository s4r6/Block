using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class KeyboardInputProvider : MonoBehaviour, IInputProvider
    {
        public Vector2 _move { get; private set; }
        public bool _decision { get; private set; }

        void Update()
        {
            _move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            
            _decision = Input.GetKeyDown(KeyCode.Space);
            
            if (_move != Vector2.zero)
                Debug.Log("Move:" + _move);
            if (_decision)
                Debug.Log("Decision:" + _decision);

        }
    }
}

