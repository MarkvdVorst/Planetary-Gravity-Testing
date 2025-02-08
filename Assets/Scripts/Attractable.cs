using UnityEngine;

public class Attractable : MonoBehaviour
{
    [SerializeField] private bool rotateToCenter = true;
    [SerializeField] private float gravityStrength = 100;
    [SerializeField] private Collider2D attractableCollider;
    [SerializeField] private Rigidbody2D attractableRigidbody;
    
    private Attractor _currentAttractor;
    
    private void Update()
    {
        if (_currentAttractor)
        {
            if (!_currentAttractor.attractedObjects.Contains(this))
            {
                _currentAttractor = null;
                return;
            }
            attractableRigidbody.gravityScale = 0;
            if (rotateToCenter) RotateToCenter();
        }
        else
        {
            attractableRigidbody.gravityScale = 1;
        }
    }

    public void Attract(Attractor attractorObj)
    {
        Vector2 attractionDir = ((Vector2)attractorObj.transform.position - attractableRigidbody.position).normalized;
        attractableRigidbody.AddForce(attractionDir * (attractorObj.gravity * gravityStrength * Time.fixedDeltaTime));
        
        float distance = Vector2.Distance(attractorObj.transform.position, attractableRigidbody.position);
        attractableRigidbody.drag = distance < attractorObj.attractorCollider.radius ? Mathf.Lerp(attractableRigidbody.drag, 5f, Time.fixedDeltaTime) : 0f;

        if (!_currentAttractor) 
        {
            _currentAttractor = attractorObj;
        }
    }

    private void RotateToCenter()
    {
        if (!_currentAttractor) return;
        Vector2 distanceVector = (Vector2)_currentAttractor.transform.position - (Vector2)transform.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}