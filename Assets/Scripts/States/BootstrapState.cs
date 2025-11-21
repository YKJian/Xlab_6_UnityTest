using UnityEngine;

namespace Golf
{
    public class BootstrapState : StateBase
    {
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private PlayerController m_playerController;
        
        private GameStateMachine m_gameStateMachine;

        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_levelController.enabled = false;
            m_playerController.enabled = false;

            m_gameStateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            m_gameStateMachine.Enter<MainMenuState>();
        }

        public override void Exit()
        {

        }
    }
}
