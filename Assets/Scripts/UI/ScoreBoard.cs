using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class ScoreBoard : MonoBehaviour
    {
        [SerializeField] private Button m_scoreBoardButton;
        [SerializeField] private GameObject m_scoreBoard;
        [SerializeField] private List<TextMeshProUGUI> m_scores;
        
        private List<string> m_stringScores;
        private int m_storedScore;

        private void Start()
        {
            m_stringScores = new List<string>() { "0", "0", "0"};
        }

        private void OnEnable()
        {
            m_scoreBoardButton.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            m_scoreBoardButton.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            m_scoreBoard.SetActive(!m_scoreBoard.activeSelf);
        }

        public void AddScore(int score)
        {
            if (m_storedScore >= m_stringScores.Count)
            {
                m_stringScores.RemoveAt(m_stringScores.Count - 1);
            }

            m_stringScores.Insert(0, score.ToString());
            m_storedScore++;

            for (int i = 0; i < m_scores.Count; i++)
            {
                m_scores[i].text = m_stringScores[i];
            }
        }
    }
}
