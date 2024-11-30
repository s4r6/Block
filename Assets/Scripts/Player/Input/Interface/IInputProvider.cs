using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public interface IInputProvider
    {
        Vector2 _move { get; }
        bool _decision { get; }
    }
}

