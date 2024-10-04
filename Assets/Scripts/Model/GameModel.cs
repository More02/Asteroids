using System;

namespace Model
{
    public class GameModel
    {
        public int Score { get; private set; }
        public bool IsKeyboardInputEnabled { get; set; } = true;

        public event Action ScoreUpdated;

        public GameModel()
        {
            Score = 0;
        }

        public void AddScore(int point)
        {
            Score += point;
            ScoreUpdated!.Invoke();
        }
    }
}