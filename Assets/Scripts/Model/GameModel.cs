using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameModel : MonoBehaviour
    {
        private int _score { get; set; }
        private static bool _isGameOver { get; set; }
        private List<AsteroidModel> _asteroids { get; set; }
        private List<UfoModel> _ufos { get; set; }
        private List<ShardModel> _shards { get; set; }

        public GameModel()
        {
            _score = 0;
            _isGameOver = false;
            _asteroids = new List<AsteroidModel>();
            _ufos = new List<UfoModel>();
        }

        public void AddScore(int point)
        {
            _score += point;
        }

        public static void EndGame()
        {
            _isGameOver = true;
        }

        public void RestartGame()
        {
            _score = 0;
            _isGameOver = false;
            _asteroids.Clear();
            _ufos.Clear();
            _shards.Clear();
        }
        
    }
}
