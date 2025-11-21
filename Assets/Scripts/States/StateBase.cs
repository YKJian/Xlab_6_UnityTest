using UnityEngine;

namespace Golf
{
    public abstract class StateBase : MonoBehaviour
    {
        public abstract void Initialize(GameStateMachine gameStateMachine);
        public abstract void Enter();
        public abstract void Exit();
    }
}
