using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Block
{
    [System.Serializable]
    public class Factory
    {
        public string FactoryName;
        public int HPValue;
        public int ScoreValue;
        public int Probably;
    }
    [System.Serializable]
    public class StageData
    {
        public List<Factory> _factoryDataList;
    }

    public class JsonStageReader : IStageDataReader
    {
        readonly string _filePath = "Assets/StageData/BlockData.json";
        string json = "";

        public StageData FetchStageData()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Debug.LogError($"Jsonファイルが見つかりません:{_filePath}");
                    return null;
                }
                json = File.ReadAllText(_filePath);
                StageData data = JsonUtility.FromJson<StageData>(json);
                return data;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Json読み込み中にエラーが発生しました:{ex.Message}");
                return null;
            }
            
        }
    }

}
