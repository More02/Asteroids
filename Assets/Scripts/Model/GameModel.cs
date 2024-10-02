using System;
using System.Collections.Generic;

namespace Model
{
    public class GameModel 
    {
        public int Score { get; private set; }
        public bool SsGameOver { get; private set; }
        private List<AsteroidModel> _asteroids { get; set; }
        private List<UfoModel> _ufos { get; set; }
        private List<ShardModel> _shards { get; set; }

        public GameModel()
        {
            Score = 0;
            SsGameOver = false;
            _asteroids = new List<AsteroidModel>();
            _ufos = new List<UfoModel>();
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
            _asteroids.Clear();
            _ufos.Clear();
            _shards.Clear();
        }
        
    }
}
