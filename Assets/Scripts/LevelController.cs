using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public event Action Finished;

        [SerializeField] private int m_missedCount;
        [SerializeField] [Min(0)] private float m_spawnRate = 0.5f;
        [SerializeField] private StoneSpawner m_stoneSpawner;
        [SerializeField] private ScoreManager m_scoreManager;

        private float m_time;
        private List<Stone> m_stones;
        private int m_currentMissedCount;

        private void Awake()
        {
            m_currentMissedCount = m_missedCount;
            m_stones = new List<Stone>();
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
            Unsubscribe(stone);

            m_scoreManager.Increase();
        }

        private void OnMissed(Stone stone)
        {
            Unsubscribe(stone);

            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {
                Debug.Log("Gameover");
                Finished?.Invoke();

                foreach (var item in m_stones)
                {
                    Destroy(item.gameObject); 
                }
                m_stones.Clear();
            }
        }

        private void Unsubscribe(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissed;
        }
    }
}
