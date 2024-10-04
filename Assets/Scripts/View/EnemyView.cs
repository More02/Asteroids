using System.Collections;
using UnityEngine;

namespace View
{
    public class EnemyView : MonoBehaviour, IViewForBorder
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private PoolView _poolView;
        
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
            //Instantiate(_enemyPrefab, position, rotation);
            var enemy = _poolView.GetPool().Get();
            enemy.transform.position = position;
            enemy.transform.rotation = rotation;
            
           // StartCoroutine(ReturnObjectAfterDelay(enemy));
        }
        
        // private IEnumerator ReturnObjectAfterDelay(GameObject objectToReturn)
        // {
        //     yield return new WaitForSeconds(10f);
        //     
        //     _poolView.GetBulletPool().Release(objectToReturn);
        // }
    }
}
