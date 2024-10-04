using UnityEngine;

namespace View
{
    public class ShipView : MonoBehaviour, IViewForBorder
    {
        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }

        public void UpdateRotation(Quaternion newRotation)
        {
            transform.rotation = newRotation;
        }
    }
}