using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private int m_missedCount;
        [SerializeField] [Min(0)] private float m_spawnRate = 0.5f;
        [SerializeField] private StoneSpawner m_stoneSpawner;

        private float m_time;
        private int m_currentMissedCount;

        private void Awake()
        {
            m_currentMissedCount = m_missedCount;
        }

        private void Update()
        {
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
            {
                Stone stone = m_stoneSpawner.Spawn();

                stone.Hit += OnHitStone;
                stone.Missed += OnMissed;

                m_time = 0;
            }
        }

        private void OnHitStone(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissed;

            Debug.Log("Score");
        }

        private void OnMissed(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissed;

            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {
                Debug.Log("Gameover");
            }
        }
    }
}
