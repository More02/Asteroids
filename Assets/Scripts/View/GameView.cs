using System;
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

        // private void OnEnable()
        // {
        //     _gameModel.GameEndedEvent += ShowGameOverPanel;
        // }
        //
        // private void OnDisable()
        // {
        //     _gameModel.GameEndedEvent -= ShowGameOverPanel;
        // }

        public void UpdateScore(int score)
        {
            _scoreText.text = _scoreText.ToString();
        }

        public void ShowGameOverPanel(int finalScore)
        {
            _finalCanvas.SetActive(true);
            _finalScoreText.text = "Game Over \n Your score: " + finalScore;
        }

        public void HideGameOverPanel()
        {
            gameObject.SetActive(false);
        }
    }
}
