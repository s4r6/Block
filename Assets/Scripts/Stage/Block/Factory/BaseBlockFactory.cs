using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Block
{
    public abstract class BaseBlockFactory : MonoBehaviour
    {
        public int _createHp;
        public int _createSocre;
        [SerializeField]
        protected GameObject _blockPrefab;
        public abstract GameObject CreateBlock(Vector2 position);
    }
}

