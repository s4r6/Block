using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Block
{
    public class DefaultBlockFactoryProvider : BaseBlockFactoryProvider
    {
        [SerializeField]
        GameObject _factoryPrefab;
        
        //�w�肳�ꂽHP�̃u���b�N�𐶐�����Factory�𐶐�
        public override BaseBlockFactory CreateFactory(int hp, int score)  
        {
            var factory = Instantiate(_factoryPrefab, transform);
            factory.name = $"factory:{hp}";
            var baseBlockFac = factory.GetComponent<BaseBlockFactory>();
            baseBlockFac._createHp = hp;
            baseBlockFac._createSocre = score;

            return baseBlockFac;
        }
    }
}

