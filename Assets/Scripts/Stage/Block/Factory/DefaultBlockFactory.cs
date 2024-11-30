using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Block
{
    public class DefaultBlockFactory : BaseBlockFactory
    {
        
        public override GameObject CreateBlock(Vector2 position)
        {
            var block = Instantiate(_blockPrefab, position, Quaternion.identity);
            block.GetComponent<IBlock>().Initialize(_createHp, _createSocre);
            return block;
        }
    }
}

