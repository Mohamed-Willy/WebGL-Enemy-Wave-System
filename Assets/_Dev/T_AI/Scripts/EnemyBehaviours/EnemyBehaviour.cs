using System.Collections;
using UnityEngine;
using UnityEngine.AI;
namespace T_AI
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        [HideInInspector] public EnemyType mType;
        public EnemyTarget target;
        [SerializeField] NavMeshAgent agent;
        [SerializeField] float EnemySpeed;
        [SerializeField] float StopingDistance;
        [SerializeField] float ShootDelay;
        [SerializeField] float DamageApplied;
        private void OnEnable()
        {
            StartCoroutine(Logic());
        }
        private IEnumerator Logic()
        {
            yield return null;
            agent.speed = EnemySpeed;
            agent.stoppingDistance = StopingDistance;
            while (enabled)
            {
                if (target == null || !target.gameObject.activeSelf) target = TargetHolder.Instance.GetNearestTarget(transform, mType);
                if(target == null)
                {
                    gameObject.SetActive(false);
                    yield break;
                }
                agent.SetDestination(target.transform.position);
                while (agent.remainingDistance > agent.stoppingDistance && enabled)
                {
                    yield return null;
                }
                while (agent.remainingDistance <= agent.stoppingDistance && enabled)
                {
                    yield return new WaitForSeconds(ShootDelay);
                    ShootTarget();
                }
            }
        }

        public void ShootTarget()
        {
            target.TakeDamage(DamageApplied);
        }
    }
}
