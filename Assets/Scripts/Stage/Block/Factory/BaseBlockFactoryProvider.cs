using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Block
{
    public abstract class BaseBlockFactoryProvider : MonoBehaviour
    {
        public abstract BaseBlockFactory CreateFactory(int hp, int score);
    }
}

