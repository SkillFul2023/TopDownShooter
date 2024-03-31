using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Infrastructure
{
    public class MobSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private int countEnemySpawn = 3;
        [SerializeField] private int spawnRadius;

        private void Start()
        {
            for (int i = 0; i < countEnemySpawn; i++)
            {
                SpawnEnemy(enemy);
            }
        }
        private void SpawnEnemy(GameObject enemy)
        {
            Instantiate(enemy, Random.insideUnitCircle* spawnRadius, Quaternion.identity);
        }
        public void OnSpawnEnemy_EditorEvent()
        {
            SpawnEnemy(enemy);
        }
    }
}
