using UnityEngine;
namespace T_AI
{
    public class RedAI : EnemyBehaviour
    {
        private void Awake()
        {
            mType = EnemyType.Red;
        }
    }
}