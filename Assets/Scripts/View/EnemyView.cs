using UnityEngine;

namespace View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }

        public void SetEnemyPrefab(GameObject enemyPrefab)
        {
            _enemyPrefab = enemyPrefab;
        }
        
        public void CreateEnemy(Vector2 position, Quaternion rotation)
        {
            Instantiate(_enemyPrefab, position, rotation);
        }
    }
}
