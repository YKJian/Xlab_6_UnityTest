using TMPro;
using UnityEngine;

namespace Golf
{
    [RequireComponent(typeof(TMP_Text))]
    public class HighestScoreText : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_text;
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private string m_format;

        // on init, on change
        private void OnValidate()
        {
            if (!m_text)
            {
                m_text = GetComponent<TMP_Text>();
            }
        }

        private void OnEnable()
        {
            OnRecordChanged(m_scoreManager.score);
            m_scoreManager.HighestScoreChanged += OnRecordChanged;
        }

        private void OnDisable()
        {
            m_scoreManager.HighestScoreChanged -= OnRecordChanged;            
        }

        private void OnRecordChanged(int value)
        {
            m_format ??= string.Empty;
            m_text.text = string.Format(m_format, value.ToString());
        }
    }
}
