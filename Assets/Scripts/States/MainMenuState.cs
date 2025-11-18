using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        [SerializeField] private GameObject m_mainMenuRoot;
        [SerializeField] private Button m_playButton;

        private GameStateMachine m_gameStateMachine;

        public void Initialize(GameStateMachine gameStateMachine)
        {
            m_mainMenuRoot.SetActive(false);
            m_gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            m_mainMenuRoot.SetActive(true);
            // instead of subscribing in Inspector
            m_playButton.onClick.AddListener(OnClicked);
        }

        public void Exit()
        {
            m_mainMenuRoot.SetActive(false);
            m_playButton.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            m_gameStateMachine.Enter<GameplayState>();
        }
    }
}
