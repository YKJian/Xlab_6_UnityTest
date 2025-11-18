using System;
using UnityEngine;

namespace Golf
{
    [RequireComponent(typeof(Rigidbody))]
    public class Stone : MonoBehaviour
    {
        public event Action<Stone> Hit;
        public event Action<Stone> Missed;

        private Rigidbody m_rigidbody;

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Club>())
            {
                Hit?.Invoke(this);
            }
            else
            {
                Missed?.Invoke(this);
            }
        }

        public void AddForce(Vector3 power) =>
            m_rigidbody.AddForce(power, ForceMode.Force);
    }
}
