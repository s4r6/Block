using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField]
        GameObject _inputProvider;
        [SerializeField]
        float _speed;
        [SerializeField]
        Rigidbody2D _rb2D;
        IInputProvider _input;


        void Start()
        {
            _input = _inputProvider.GetComponent<IInputProvider>();    
        }

        void FixedUpdate()
        {
            _rb2D.velocity = _input._move * _speed;
        }
    }
}

