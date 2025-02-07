using UnityEngine;

namespace Planet
{
    public class GravitationalRange : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D circleCollider2D;
        [SerializeField] private float planetGravitationalRange;

        private void Start()
        {
            circleCollider2D.radius = planetGravitationalRange;
        }
    }
}
