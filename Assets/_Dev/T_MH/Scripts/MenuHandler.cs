using T_WM;
using UnityEngine;
using UnityEngine.UI;
namespace T_MH
{
    public class MenuHandler : MonoBehaviour
    {
        [SerializeField] WaveManager waveManager;

        [SerializeField] TMPro.TMP_Text WaveNum;
        [SerializeField] TMPro.TMP_Text EnemyCount;
        [SerializeField] TMPro.TMP_Text StopResumeStartButton;

        [SerializeField] Button stopResumeStart_BTN;
        [SerializeField] Button nextWave_BTN;
        [SerializeField] Button destroyWave_BTN;

        private void Start()
        {
            StopResumeStartButton.text = "Start";
            stopResumeStart_BTN.onClick.AddListener(StartWave);
            nextWave_BTN.onClick.AddListener(NextWave);
            destroyWave_BTN.onClick.AddListener(DestroyWave);
            nextWave_BTN.interactable = false;
            destroyWave_BTN.interactable = false;
        }

        private void DestroyWave()
        {
            waveManager.DestroyWave();
            StopResumeStartButton.text = "Resume";
            waveManager.StopWave();
        }

        private void NextWave()
        {
            waveManager.StartNextWave();
        }

        private void StartWave()
        {
            nextWave_BTN.interactable = true;
            destroyWave_BTN.interactable = true;
            StopResumeStartButton.text = "Stop"; 
            stopResumeStart_BTN.onClick.RemoveAllListeners();
            stopResumeStart_BTN.onClick.AddListener(SwitchWaveManager);
            waveManager.StartNextWave();
            WaveNum.text = "Wave: " + waveManager.waveCount;
        }

        private void SwitchWaveManager()
        {
            if (StopResumeStartButton.text == "Stop")
            {
                StopResumeStartButton.text = "Resume";
                waveManager.StopWave();
            }
            else
            {
                StopResumeStartButton.text = "Stop";
                waveManager.ResumeWave();
            }
        }

        private void Update()
        {
            WaveNum.text = "Wave: " + waveManager.waveCount.ToString("0000");
            EnemyCount.text = "Enemy Count: " + waveManager.enemyPool.Count.ToString("0000");
        }
    }
}