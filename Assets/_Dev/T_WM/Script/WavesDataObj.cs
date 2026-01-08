using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using System;
namespace T_WM
{
    [HideMonoScript]
    [CreateAssetMenu(fileName = "WavesDataObj", menuName = "T_WM/WavesData")]
    public class WavesDataObj : ScriptableObject
    {
        public List<WaveDataContainer> dataContainer;
        void OnValidate()
        {
            if(dataContainer.Count == 0) return;
            dataContainer[0].waveStart = 1;
            for (int i = 1; i < dataContainer.Count; i++)
            {
                dataContainer[i].isInfinite = false;
                dataContainer[i].waveStart = dataContainer[i - 1].waveStart + dataContainer[i - 1].wavesCount; 
            }
            dataContainer[^1].isInfinite = true;
        }
    }
    [Serializable]
    public class WaveDataContainer
    {
        [HideInInspector] public bool isInfinite;
        [ReadOnly] public int waveStart;
        [ShowIf("@!isInfinite")]
        [Tooltip("Amount of waves affected by this eqquation")]
        public int wavesCount;

        [Header("Equation Parameters")]
        [Tooltip("The initial count of enemies that will be added to any wave")] public int startCount;
        [Tooltip("The amount added to the initial multiplied by the wave count independent to previus ones")] public int multiplyCount;
    }
}