using TMPro;
using UnityEngine;

namespace View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private GameObject _finalCanvas;
        [SerializeField] private TMP_Text _finalScoreText;

        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _rotationText;
        [SerializeField] private TMP_Text _instantaneousSpeedText;
        [SerializeField] private TMP_Text _laserShotsLimitText;
        [SerializeField] private TMP_Text _timeForLaserRecoverText;

        public static GameView Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void UpdateScoreText(int score)
        {
            _scoreText.text = "Score: " + score;
        }
        
        public void UpdateRotationText(float rotation)
        {
            _rotationText.text = "Rotation: " + rotation;
        }
        
        public void UpdateInstantaneousSpeedText(float instantaneousSpeed)
        {
            if (float.IsNaN(instantaneousSpeed)) return;
            _instantaneousSpeedText.text = "Instantaneous speed: " + instantaneousSpeed;
        }
        
        public void UpdateLaserShotsLimitText(int laserShotsLimit)
        {
            _laserShotsLimitText.text = "Laser shots limit: " + laserShotsLimit;
        }
        
        public void UpdateTimeForLaserRecoverText(int timeInSeconds)
        {
            _timeForLaserRecoverText.text = "Time for laser recover: " + timeInSeconds + " s";
        }

        public void ShowGameOverPanel(int finalScore)
        {
            _finalCanvas.SetActive(true);
            _finalScoreText.text = "Your score: " + finalScore;
        }

        public void HideGameOverPanel()
        {
            _finalCanvas.SetActive(false);
        }
    }
}
