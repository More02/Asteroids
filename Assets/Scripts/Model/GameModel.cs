using System;
using System.Collections.Generic;

namespace Model
{
    public class GameModel 
    {
        public int Score { get; private set; }
        public bool SsGameOver { get; private set; }
        public List<AsteroidModel> _asteroids { get; set; }
        public List<UfoModel> _ufos { get; set; }
        public List<ShardModel> _shards { get; set; }

        public GameModel()
        {
            Score = 0;
            SsGameOver = false;
            _asteroids = new List<AsteroidModel>();
            _ufos = new List<UfoModel>();
            _shards = new List<ShardModel>();
        }

        public void AddScore(int point)
        {
            Score += point;
        }

        public void EndGame()
        {
            SsGameOver = true;
        }

        public void RestartGame()
        {
            Score = 0;
            SsGameOver = false;
            _asteroids?.Clear();
            _ufos?.Clear();
            _shards?.Clear();
        }
        
    }
}
