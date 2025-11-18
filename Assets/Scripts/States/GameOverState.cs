using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private GameObject m_gameOverPanel;
        [SerializeField] private Button m_backMainMenu;
        [SerializeField] private ScoreManager m_scoreManager;

        private GameStateMachine m_gameStateMachine;

        public void Initialize(GameStateMachine gameStateMachine)
        {
            m_gameStateMachine = gameStateMachine;

            m_gameOverPanel.gameObject.SetActive(false);
        }

        public void Enter()
        {
            m_scoreText.text = m_scoreManager.Score.ToString();
            m_backMainMenu.onClick.AddListener(OnClicked);
            m_gameOverPanel.gameObject.SetActive(true);
        }

        public void Exit()
        {
            m_gameOverPanel.gameObject.SetActive(false);
        }
        private void OnClicked()
        {
            m_gameStateMachine.Enter<MainMenuState>();
        }
    }
}
