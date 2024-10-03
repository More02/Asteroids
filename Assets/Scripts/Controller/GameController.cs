using System;
using System.Collections;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using View;

namespace Controller
{
    public class GameController : MonoBehaviour
    {
        private GameModel _gameModel;
        private ShipModel _shipModel;

        public static GameController Instance;
        
        private void OnEnable()
        {
            _gameModel.ScoreUpdated += ViewNewScore;
        }
        
        private void OnDisable()
        {
            _gameModel.ScoreUpdated -= ViewNewScore;
        }

        private void Awake()
        {
            Instance = this;
            _gameModel = new GameModel();
        }
        
        private void Start()
        {
            GameView.Instance.HideGameOverPanel();
            //StartCoroutine(GameLoop());
        }

        public GameModel GetGameModel()
        {
            return _gameModel;
        }

        private void ViewNewScore()
        {
            GameView.Instance.UpdateScore(_gameModel.Score);
        }
        // private IEnumerator GameLoop()
        // {
        //     while (!_gameModel.IsGameOver)
        //     {
        //         GameView.Instance.UpdateScore(_gameModel.Score);
        //         yield return new WaitForSeconds(1);
        //     }
        // }

        public void EndGame()
        {
            Time.timeScale = 0;
            _gameModel.EndGame();
            GameView.Instance.ShowGameOverPanel(_gameModel.Score);
        }

        public void Restart()
        {
            Time.timeScale = 1;
            _gameModel.RestartGame();
            //GameView.Instance.HideGameOverPanel();
            // for (int i = 0; i < _gameModel._asteroids.Count)
            // {
            //     _gameModel._asteroids[i].
            // }
            //ShipController.Instance.GetShipModel().Position = ShipController.Instance.ShipStartPosition;
            //ShipController.Instance.GetShipView().UpdatePosition(ShipController.Instance.GetShipModel().Position);
            //StartCoroutine(GameLoop());
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
