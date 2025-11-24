using UnityEngine;
using UnityEngine.EventSystems;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Club m_club;

        [SerializeField] private EventTrigger m_hitButton;

        private bool m_isDown;

        private void OnEnable()
        {
            var entryDown = new EventTrigger.Entry();
            entryDown.eventID = EventTriggerType.PointerDown;

            var entryUp = new EventTrigger.Entry();
            entryUp.eventID = EventTriggerType.PointerUp;

            entryUp.callback.AddListener(OnPointerUp);
            entryDown.callback.AddListener(OnPointerDown);

            m_hitButton.triggers.Add(entryDown);
            m_hitButton.triggers.Add(entryUp);
        }
        private void Update()
        {
            if (m_isDown)
            {
                m_club.Down();
            }
            else
            {
                m_club.Up();
            }
        }

        private void Down() => m_isDown = true;

        private void Up() => m_isDown = false;

        private void OnPointerDown(BaseEventData arg0) => Down();

        private void OnPointerUp(BaseEventData arg0) => Up();
    }
}
