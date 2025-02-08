using UnityEngine;

public class GravitationalOrbit : MonoBehaviour
{
    [SerializeField] private Attractor attractor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attractable"))
        {
            Attractable attractable = other.GetComponent<Attractable>();
            if (!attractor.attractedObjects.Contains(attractable))
                attractor.attractedObjects.Add(attractable);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Attractable"))
        {
            Attractable attractable = other.GetComponent<Attractable>();
            if (!attractor.attractedObjects.Contains(attractable))
                attractor.attractedObjects.Remove(attractable);
        }
    }
}
