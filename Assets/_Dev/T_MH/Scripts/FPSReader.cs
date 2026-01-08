using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;
using System.Collections;

namespace T_MH
{
    [RequireComponent(typeof(TMP_Text)), HideMonoScript]
    public class FPSReader : MonoBehaviour
    {
        private TMP_Text text;
        private float deltaTime;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        private IEnumerator Start()
        {
            while (true)
            {
                deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

                float fps = 1f / deltaTime;

                if (text != null)
                    text.text = $"FPS: {Mathf.RoundToInt(fps)}";

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
