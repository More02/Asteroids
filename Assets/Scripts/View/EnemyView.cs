using UnityEngine;

namespace View
{
    public class EnemyView : MonoBehaviour, IViewForBorder
    {
        [SerializeField] private PoolView _poolView;
        
        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }

        public void CreateEnemy(Vector2 position, Quaternion rotation)
        {
            var enemy = _poolView.GetPool().Get();
            enemy.transform.position = position;
            enemy.transform.rotation = rotation;
        }
    }
}
