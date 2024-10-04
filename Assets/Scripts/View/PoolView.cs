using UnityEngine;
using UnityEngine.Pool;

namespace View
{
    public class PoolView : MonoBehaviour
    {
        private ObjectPool<GameObject> _pool;
        [SerializeField] private Transform _objectsForPoolHolder;

        public ObjectPool<GameObject> GetPool()
        {
            return _pool;
        }

        private void Awake()
        {
            _pool = new ObjectPool<GameObject>(
                createFunc: () => new GameObject("Bullet"),
                actionOnGet: (obj) => obj.SetActive(true),
                actionOnRelease: (obj) => obj.SetActive(false),
                actionOnDestroy: (obj) => obj.SetActive(false),
                false, defaultCapacity: 20, maxSize: 20
            );
            ChildToPool();
        }

        private void ChildToPool()
        {
            for (var i = 0; i < _objectsForPoolHolder.childCount; i++)
            {
                _pool.Release(_objectsForPoolHolder.GetChild(i).gameObject);
            }
        }
    }
}