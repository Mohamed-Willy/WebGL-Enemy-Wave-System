using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using T_AI;
namespace T_WM
{
    [HideMonoScript]
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] WavesDataObj waveDataObj;
        [SerializeField] EnemySelector enemyPrefab;
        [SerializeField] float spawnRadius;
        [SerializeField] float spawnDelay;
        [SerializeField] float waveDelay;
        [HideInInspector] public List<EnemySelector> enemyPool;
        [HideInInspector] public int totalEnemies;
        [HideInInspector] public int curEnemies;
        [HideInInspector] public int waveCount;
        Vector3 center;
        Coroutine enumerator;
        private void Start()
        {
            center = transform.position;
            totalEnemies = 0;
            waveCount = 0;
        }

        public void DestroyWave()
        {
            totalEnemies = 0;
            curEnemies = 0;
            for (int i = 0; i < enemyPool.Count; i++)
            {
                enemyPool[i].gameObject.SetActive(false);
            }
        }

        public void StartNextWave()
        {
            waveCount++;
            SpawnWave(waveCount);
        }

        public void StopWave()
        {
            if (enumerator != null) StopCoroutine(enumerator);
        }
        public void ResumeWave()
        {
            enumerator = StartCoroutine(SpawnUnits());
        }

        private void SpawnWave(int waveNumber)
        {
            totalEnemies += GenWaveCount(waveNumber);
            if (enumerator != null) StopCoroutine(enumerator);
            enumerator = StartCoroutine(SpawnUnits());
        }

        private int GenWaveCount(int waveNumber)
        {
            for (int i = 0; i < waveDataObj.dataContainer.Count; i++)
            {
                if (waveNumber < waveDataObj.dataContainer[i].waveStart) return -1;
                if (waveNumber < waveDataObj.dataContainer[i].wavesCount + waveDataObj.dataContainer[i].waveStart || waveDataObj.dataContainer[i].isInfinite)
                {
                    return waveDataObj.dataContainer[i].startCount + (waveNumber - waveDataObj.dataContainer[i].waveStart + 1) * waveDataObj.dataContainer[i].multiplyCount;
                }
            }
            return -1;
        }

        private IEnumerator SpawnUnits()
        {
            bool gen;
            while (curEnemies < totalEnemies)
            {
                float angle = Random.Range(0f, Mathf.PI * 2f);
                Vector3 pos = GetPointOnCircle(angle);
                gen = true;
                for (int i = 0; i < enemyPool.Count; i++) {
                    if (!enemyPool[i].gameObject.activeSelf)
                    {
                        enemyPool[i].transform.SetPositionAndRotation(pos, Quaternion.identity);
                        enemyPool[i].gameObject.SetActive(true);
                        enemyPool[i].SetEnemyActive((EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length));
                        gen = false;
                        break;
                    }
                }

                if (gen)
                {
                    enemyPool.Add(Instantiate(enemyPrefab, pos, Quaternion.identity));
                    enemyPool[^1].SetEnemyActive((EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length));
                }

                curEnemies++;
                yield return new WaitForSeconds(spawnDelay);
            }
            yield return new WaitForSeconds(waveDelay);
            StartNextWave();
        }


        private Vector3 GetPointOnCircle(float angleRad)
        {
            return center + new Vector3(Mathf.Cos(angleRad) * spawnRadius, 0f, Mathf.Sin(angleRad) * spawnRadius);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            const int segments = 64;
            Vector3 prev = transform.position + new Vector3(spawnRadius, 0f, 0f);

            for (int i = 1; i <= segments; i++)
            {
                float t = i / (float)segments;
                float a = t * Mathf.PI * 2f;
                Vector3 next = transform.position + new Vector3(Mathf.Cos(a) * spawnRadius, 0f, Mathf.Sin(a) * spawnRadius);

                Gizmos.DrawLine(prev, next);
                prev = next;
            }
        }
    }
}