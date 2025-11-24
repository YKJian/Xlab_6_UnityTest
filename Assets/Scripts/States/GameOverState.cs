using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameOverState : StateBase
    {
        [SerializeField] private TextMeshProUGUI m_finalScoreText;
        [SerializeField] private GameObject m_gameOverPanel;
        [SerializeField] private Button m_backMainMenu;
        [SerializeField] private ScoreManager m_scoreManager;

        private GameStateMachine m_gameStateMachine;

        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_gameOverPanel.gameObject.SetActive(false);
            m_gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            m_finalScoreText.text = m_scoreManager.score.ToString();

            m_scoreManager.UpdateHighestScore();

            m_gameOverPanel.gameObject.SetActive(true);
            m_backMainMenu.onClick.AddListener(OnClicked);
        }

        public override void Exit()
        {
            m_gameOverPanel.gameObject.SetActive(false);
            m_backMainMenu.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            m_gameStateMachine.Enter<MainMenuState>();
        }
    }
}
