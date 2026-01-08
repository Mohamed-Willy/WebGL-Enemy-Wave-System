using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace T_AI
{
    public class EnemyTarget : MonoBehaviour
    {
        [SerializeField] Image FillImage;
        public List<EnemyType> enemyTypes;
        [SerializeField] float MaxHealth;
        float CurHealth;
        private void Awake()
        {
            TargetHolder.Instance.allTargets.Add(this);
            CurHealth = MaxHealth;
        }
        public void TakeDamage(float damage)
        {
            CurHealth -= damage;
            if (CurHealth <= 0)
                gameObject.SetActive(false);
            else
                FillImage.fillAmount = CurHealth / MaxHealth;
        }
        private void OnDisable()
        {
            TargetHolder.Instance.allTargets.Remove(this);
        }
    }
}