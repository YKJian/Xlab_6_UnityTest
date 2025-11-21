using System;
using UnityEngine;

namespace Golf
{
    public class ScoreManager : MonoBehaviour
    {
        public event Action<int> ScoreChanged;
        public event Action<int> HighestScoreChanged;

        private int m_score;

        public int score 
        { 
            get => m_score;
            private set
            {
                m_score = value;
                Debug.Log($"Score: {value}");
                ScoreChanged?.Invoke(value);
            }
        }
        public int highestScore
        {
            get => PlayerPrefs.GetInt(GlobalConstants.HighestScore, 0);
            
            private set
            {
                var temp = PlayerPrefs.GetInt(GlobalConstants.HighestScore, 0);

                if (temp < value)
                {
                    PlayerPrefs.SetInt(GlobalConstants.HighestScore, value);
                    HighestScoreChanged?.Invoke(value);
                }
            }
        }

        public void UpdateHighestScore()
        {
            highestScore = score;
        }

        public void Increase(int stoneScore)
        {
            score += stoneScore;
        }

        public void Reset()
        {
            score = 0;
        }
    }
}
