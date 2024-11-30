using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ball
{
    public class Ball : IBall
    {
        public int _power { get; private set; } = 1;
        public int _speed { get; private set; } = 7;
    }
}

