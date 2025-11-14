using System;
using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        // name events without "On..."
        public event Action<Stone> Hit;
        public event Action<Stone> Missed;

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
    }
}
