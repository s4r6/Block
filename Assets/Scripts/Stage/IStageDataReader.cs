using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Block
{
    public interface IStageDataReader
    {
        StageData FetchStageData();
    }
}

