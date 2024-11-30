using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using Manager;
using Block;

namespace Ball
{
    public class BallView : MonoBehaviour
    {
        [SerializeField]
        Rigidbody2D _rb2D;
        IBall _ball;
        bool _isStarted = false;

        [Inject]
        InGameManager _manager;

        float _threshold = 0f;

        void Awake()
        {
            _manager.OnStartGame += StartMoveBall;
            _manager.OnPauseGame += StopMoveBall;
            _manager.OnEndGame += DestroyBall;
        }
        void Start()
        {
            _ball = new Ball();
            _threshold = new Vector2(_ball._speed, _ball._speed).sqrMagnitude + 3;
        }

        /*void FixedUpdate()
        {
            if (!_isStarted) return;
            //速度を一定に保つ
            if(_rb2D.velocity.sqrMagnitude <= _threshold || _rb2D.velocity.sqrMagnitude >= _threshold )
                _rb2D.velocity = new Vector2(_ball._speed, _ball._speed);
        }*/

        void StartMoveBall()
        {
            Debug.Log("ボール移動開始");
            _rb2D.velocity = new Vector2(_ball._speed, _ball._speed);
            _manager.OnStartGame -= StartMoveBall;
            _isStarted = true;
        }

        void StopMoveBall()
        {

        }

        void DestroyBall(GameEndState state)
        {
            _manager.OnEndGame -= DestroyBall;
            _manager.OnPauseGame -= StopMoveBall;

            Destroy(gameObject);

        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var block = collision.gameObject.GetComponent<IDamageable>();
            if(block != null)
                block.AddDamage(_ball._power);
        }
    }
}

