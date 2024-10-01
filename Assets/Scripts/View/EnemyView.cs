using UnityEngine;

namespace View
{
    public abstract class EnemyView : MonoBehaviour
    {
        public virtual void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }
    }
}
