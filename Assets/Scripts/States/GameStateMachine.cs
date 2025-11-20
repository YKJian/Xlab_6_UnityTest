using UnityEngine;

namespace Golf
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private BootstrapState m_bootstrapState;
        [SerializeField] private MainMenuState m_mainMenuState;
        [SerializeField] private GameplayState m_gameplayState;
        [SerializeField] private GameOverState m_gameOverState;

        private void Awake()
        {
            m_bootstrapState.Initialize(this);
            m_mainMenuState.Initialize(this);
            m_gameplayState.Initialize(this);
            m_gameOverState.Initialize(this);
        }

        private void Start()
        {
            Enter<BootstrapState>();
        }

        public void Enter<T>()
        {
            if (typeof(T) == typeof(BootstrapState))
            {
                m_bootstrapState.Enter();
            }
            else if (typeof(T) == typeof(MainMenuState))
            {
                m_bootstrapState.Exit();
                m_gameOverState.Exit();
                m_mainMenuState.Enter();
            }
            else if (typeof(T) == typeof(GameplayState))
            {
                m_bootstrapState.Exit();
                m_mainMenuState.Exit();
                m_gameOverState.Exit();
                m_gameplayState.Enter();
            }
            else if (typeof(T) == typeof(GameOverState))
            {
                m_gameplayState.Exit();
                m_gameOverState.Enter();
            }
        }
    }
}
