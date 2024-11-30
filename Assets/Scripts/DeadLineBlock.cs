using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using Manager;
using Ball;

public class DeadLineBlock : MonoBehaviour
{
    [Inject]
    InGameManager _manager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("GameOver");
        _manager.GameOver();        
    }
}
