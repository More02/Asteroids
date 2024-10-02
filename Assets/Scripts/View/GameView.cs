using Model;
using TMPro;
using UnityEngine;

namespace View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private GameObject _finalCanvas;
        [SerializeField] private TMP_Text _finalScoreText;
        [SerializeField] private GameModel _gameModel;

        public static GameView Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void UpdateScore(int score)
        {
            _scoreText.text = "Score: " + score;
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
