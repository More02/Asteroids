using System.Collections;
using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class GameController : MonoBehaviour
    {
        private GameModel _gameModel;
        private ShipModel _shipModel;

        public static GameController Instance;

        private void Awake()
        {
            Instance = this;
            _gameModel = new GameModel();
        }

        public GameModel GetGameModel()
        {
            return _gameModel;
        }

        private void Start()
        {
            GameView.Instance.HideGameOverPanel();
            StartCoroutine(GameLoop());
        }

        private IEnumerator GameLoop()
        {
            while (!_gameModel.SsGameOver)
            {
                GameView.Instance.UpdateScore(_gameModel.Score);
                yield return new WaitForSeconds(1);
            }
        }

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
            GameView.Instance.HideGameOverPanel();
            ShipController.Instance.GetShipModel().Position = ShipController.Instance.ShipStartPosition;
            ShipController.Instance.GetShipView().UpdatePosition(ShipController.Instance.GetShipModel().Position);
            StartCoroutine(GameLoop());
        }
    }
}
