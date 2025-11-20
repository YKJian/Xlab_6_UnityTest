using System;
using UnityEngine;

namespace Golf
{
    public class ScoreManager : MonoBehaviour
    {
        public event Action<int> ScoreChanged;

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

        public void Increase()
        {
            score++;
        }

        public void Reset()
        {
            score = 0;
        }
    }
}
