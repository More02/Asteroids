using TMPro;
using UnityEngine;

namespace View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private GameObject _finalCanvas;
        [SerializeField] private TMP_Text _finalScoreText;

        public void UpdateScore(int score)
        {
            _scoreText.text = _scoreText.ToString();
        }

        public void ShowGameOverPanel()
        {
            _finalCanvas.SetActive(true);
            _finalScoreText.text = "Game Over \n Your score: " + _finalScoreText;
        }

        public void HideGameOverPanel()
        {
            gameObject.SetActive(false);
        }
    }
}
