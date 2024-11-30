using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using UnityEngine.UI;

namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        Score _score;

        [SerializeField]
        Text _scoreText;

        // Start is called before the first frame update
        void Start()
        {
            _score = Score.CreateInstance();
            _scoreText.text = $"Score:{_score._score}";
            _score.OnScoreChanged += UpdateScoreText;
        }

        void UpdateScoreText()
        {
            _scoreText.text = $"Score:{_score._score}";
        }

        void OnDestroy()
        {
            _score.OnScoreChanged -= UpdateScoreText;    
        }
    }
}

