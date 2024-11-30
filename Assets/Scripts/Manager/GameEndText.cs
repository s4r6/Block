using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using VContainer;
using UnityEngine.UI;

public class GameEndText : MonoBehaviour
{
    [Inject]
    InGameManager _manager;
    [SerializeField]
    Text _endText;
    void Awake()
    {
        _manager.OnEndGame += DisplayEndText;   
    }

    void Start()
    {
        _endText.gameObject.SetActive(false);    
    }

    void DisplayEndText(GameEndState endFlag)
    {
        switch(endFlag)
        {
            case GameEndState.GameClear:
                _endText.text = "GAME CLEAR!!";
                break;
            case GameEndState.GameOver:
                _endText.text = "GAME OVER...";
                break;
            default:
                Debug.LogError($"ïsê≥Ç»ílÇ≈Ç∑:{endFlag}");
                break;
        }
        _endText.gameObject.SetActive(true);
    }



    
}
