using UnityEngine;

namespace Golf
{
    public class BadStone : Stone
    {
        [SerializeField] private ParticleSystem m_particleSystem;

        protected override void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.GetComponent<Club>())
            {
                ParticleSystem particleSystem = Instantiate(m_particleSystem, transform.position, transform.rotation);
                particleSystem.Play();

                Destroy(gameObject);
            }
            else
            {
                base.OnCollisionEnter(collision);
            }
        }
    }
}
