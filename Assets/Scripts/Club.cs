using UnityEngine;

namespace Golf
{
    public class Club : MonoBehaviour
    {
        [SerializeField] private float m_minAngleZ = -30;
        [SerializeField] private float m_maxAngleZ = 30;
        [SerializeField] [Min(0)] private float m_speed;

        private void Update()
        {
            var angles = transform.localEulerAngles;

            if (Input.GetKey(KeyCode.E))
            {
                angles.z = Rotate(angles.z, m_minAngleZ);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                angles.z = Rotate(angles.z, m_maxAngleZ);
            }

            transform.localEulerAngles = angles;
        }

        private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, Time.deltaTime * m_speed);
        }
    }
}
