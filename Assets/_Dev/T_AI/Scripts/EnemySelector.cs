using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace T_AI
{
    public class EnemySelector : MonoBehaviour
    {
        [SerializeField] List<GameObject> enemyBehaviours;
        private void OnEnable()
        {
            StartCoroutine(StartDeath());
        }
        private IEnumerator StartDeath()
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(5, 20));
            gameObject.SetActive(false);
        }
        public void SetEnemyActive(EnemyType enemyType)
        {
            for (int i = 0; i < enemyBehaviours.Count; i++)
            {
                if (enemyBehaviours[i].GetComponent<EnemyBehaviour>().mType == enemyType)
                {
                    enemyBehaviours[i].GetComponent<EnemyBehaviour>().target = TargetHolder.Instance.GetNearestTarget(transform, enemyType);
                    enemyBehaviours[i].SetActive(true);
                }
                else enemyBehaviours[i].SetActive(false);
            }
        }
    }
    [Serializable]
    public enum EnemyType
    {
        Red, 
        Green, 
        Blue
    }
}
