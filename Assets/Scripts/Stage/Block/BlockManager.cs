using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using Manager;
using Score;

namespace Block
{
    public class BlockManager : MonoBehaviour
    {
        int width = 11;
        int height = 1;
        Score.Score _score;

        List<IBlock> _blockList;
        [SerializeField]
        List<GameObject> _factoryProvider;
        Dictionary<string, BaseBlockFactoryProvider> _factoryProviderDic = new Dictionary<string, BaseBlockFactoryProvider>();
        Dictionary<BaseBlockFactory, int> _blockProbably = new Dictionary<BaseBlockFactory, int>();
        void Start()
        {
            IStageDataReader _reader = new JsonStageReader();
            StageData _data = _reader.FetchStageData();
            _score = Score.Score.CreateInstance();
            _blockList = new List<IBlock>();

            //すべてのFactory生成オブジェクトを取得
            foreach (var provider in _factoryProvider)
            {
                var providerComponent = provider.GetComponent<BaseBlockFactoryProvider>();
                _factoryProviderDic.Add(provider.name, providerComponent);  //Factory生成オブジェクトを(名前,BaseBlockFactoryProvider)で登録
            }

            //外部から取得してきたFactoryProviderのクラス名と、生成するブロックのHPを登録
            foreach (var element in _data._factoryDataList)
            {
                var factory = _factoryProviderDic[element.FactoryName].CreateFactory(element.HPValue, element.ScoreValue);
                _blockProbably.Add(factory, element.Probably);
            }

            GenerateStage();
        }

        void RemoveBlock(int score, IBlock block)
        {
            _blockList.Remove(block);
            _score.AddScore(score);
            block.OnDestroyThis -= RemoveBlock;
        }
        public void GenerateStage()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int randValue = Random.Range(1, 101);
                    foreach (var pair in _blockProbably)
                    {
                        if (pair.Value >= randValue)
                        {
                            var block = pair.Key.CreateBlock(new Vector2(-5 + j, 7 - i));
                            block.transform.SetParent(this.transform);
                            var iblock = block.GetComponent<IBlock>();
                            iblock.OnDestroyThis += RemoveBlock;
                            _blockList.Add(iblock);
                            break;
                        }
                    }
                }
            }
        }
    }
}

