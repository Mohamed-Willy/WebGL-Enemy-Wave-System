using System.Collections.Generic;
using UnityEngine;
namespace T_AI
{
    public class TargetHolder : MonoBehaviour
    {
        public static TargetHolder Instance { get; private set; }

        public List<EnemyTarget> allTargets = new();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public EnemyTarget GetNearestTarget(Transform obj, EnemyType type)
        {
            EnemyTarget nearest = null;
            float minDist = Mathf.Infinity;

            for (int i = 0; i < allTargets.Count; i++)
            {
                var target = allTargets[i];

                if (!target.enemyTypes.Contains(type))
                    continue;

                float d = Vector3.Distance(obj.position, target.transform.position);
                if (d < minDist)
                {
                    minDist = d;
                    nearest = target;
                }
            }

            return nearest;
        }
    }
}