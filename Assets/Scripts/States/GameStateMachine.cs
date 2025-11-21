using UnityEngine;

namespace Golf
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private StateBase[] m_states;

        private StateBase m_currentState;

        private void Awake()
        {
            foreach(var state in m_states)
            {
                state.Initialize(this);
            }
        }

        private void Start()
        {
            Enter<BootstrapState>();
        }

        public void Enter<T>()
        {
            m_currentState?.Exit();

            foreach (StateBase state in m_states)
            {
                if (state.GetType() == typeof(T))
                {
                    m_currentState = state;
                    state.Enter();

                    break;
                }
            }
        }
    }
}
