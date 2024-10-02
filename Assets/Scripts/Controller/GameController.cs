using System.Collections;
using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameModel _gameModel;
        [SerializeField] private GameView _gameView;

        private void Start()
        {
            _gameModel = new GameModel();
            _gameView.HideGameOverPanel();
            StartCoroutine(GameLoop());
        }

        private IEnumerator GameLoop()
        {
            while (!_gameModel.SsGameOver)
            {
                _gameView.UpdateScore(_gameModel.Score);
                yield return new WaitForSeconds(1);
            }
        }

        public void EndGame()
        {
            _gameModel.EndGame();
            _gameView.ShowGameOverPanel(_gameModel.Score);
        }

        public void Restart()
        {
            _gameModel.RestartGame();
            _gameView.HideGameOverPanel();
            StartCoroutine(GameLoop());
        }
    }
}
