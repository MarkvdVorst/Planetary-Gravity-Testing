using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float gravity = 10f;
    [HideInInspector] public List<Attractable> attractedObjects = new();
    public CircleCollider2D attractorCollider; 

    private void FixedUpdate()
    {
        AttractObjects();
    }

    private void AttractObjects()
    {
        foreach (var attractableObject in attractedObjects)
        {
            attractableObject.Attract(this);
        }
    }
}
