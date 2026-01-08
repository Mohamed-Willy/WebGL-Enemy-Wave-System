using UnityEngine;
namespace T_AI
{
    public class BlueAI : EnemyBehaviour
    {
        private void Awake()
        {
            mType = EnemyType.Blue;
        }
    }
}