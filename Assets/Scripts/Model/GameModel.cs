using System;
using System.Collections.Generic;

namespace Model
{
    public class GameModel 
    {
        public int Score { get; private set; }
        public bool IsGameOver { get; private set; }
        public List<AsteroidModel> _asteroids { get; set; }
        public List<UfoModel> _ufos { get; set; }
        public List<ShardModel> _shards { get; set; }

        public event Action ScoreUpdated;

        public GameModel()
        {
            Score = 0;
            IsGameOver = false;
            _asteroids = new List<AsteroidModel>();
            _ufos = new List<UfoModel>();
            _shards = new List<ShardModel>();
        }

        public void AddScore(int point)
        {
            Score += point;
            ScoreUpdated.Invoke();
        }

        public void EndGame()
        {
            IsGameOver = true;
        }

        public void RestartGame()
        {
            Score = 0;
            IsGameOver = false;
            _asteroids?.Clear();
            _ufos?.Clear();
            _shards?.Clear();
        }
        
    }
}
