using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using VContainer;

public class EntryPoint : MonoBehaviour
{
    [Inject]
    InGameManager _manager;
    // Start is called before the first frame update
    async void Start()
    {
        await _manager.WaitForInputKey();
    }
}
