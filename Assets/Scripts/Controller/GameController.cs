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

        [SerializeField] private GameView _gameView;

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
            _shipModel = (ShipModel)ShipController.Instance.GetModel();
            GameView.Instance.HideGameOverPanel();

            if (_shipModel is null) return;

            _gameView.UpdateScoreText(0);
            _gameView.UpdateRotationText(_shipModel.Rotation.eulerAngles.z);
            _gameView.UpdateInstantaneousSpeedText(_shipModel.InstantaneousSpeed);
            _gameView.UpdateLaserShotsLimitText(_shipModel.LaserShotsLimit);
            _gameView.UpdateTimeForLaserRecoverText(_shipModel.TimeForLaserRecover);
        }

        public GameModel GetGameModel()
        {
            return _gameModel;
        }

        private void ViewNewScore()
        {
            GameView.Instance.UpdateScoreText(_gameModel.Score);
        }

        public void EndGame()
        {
            _gameModel.IsKeyboardInputEnabled = false;
            Time.timeScale = 0;
            GameView.Instance.ShowGameOverPanel(_gameModel.Score);
        }

        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}