using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField]
        Text text;
        [Inject]
        Timer _timer;

        void Update()
        {
            text.text = $"Time:{_timer._currentTime}";    
        }
    }
}

