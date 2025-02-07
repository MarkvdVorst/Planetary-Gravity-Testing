using System;
using UnityEngine;

namespace Player
{
    public class GravityLogic : MonoBehaviour
    {
        private GravityStateEnum _gravityState;
        private Transform _planetObject;
        [SerializeField] private Rigidbody2D playerRigidbody2D;
        [SerializeField] private Movement playerMovement;

        private void Awake()
        {
            _gravityState = GravityStateEnum.OffPlanet;
        }

        private void FixedUpdate()
        {
            switch (_gravityState)
            {
                case GravityStateEnum.OffPlanet:
                    FixedUpdateOffPlanet();
                    break;
                case GravityStateEnum.OnPlanet:
                    FixedUpdateOnPlanet();
                    break;
            }
        }

        private void FixedUpdateOnPlanet()
        {
            if (!_planetObject)
            {
                Debug.LogError("No planet Transform was found");
                return;
            }
        }

        private void FixedUpdateOffPlanet()
        {
            if (!playerMovement.isGrounded)
                playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.y, -1);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Planet")) return;
            _planetObject = other.transform.parent;
            _gravityState = GravityStateEnum.OnPlanet;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Planet")) return;
            _planetObject = null;
            _gravityState = GravityStateEnum.OffPlanet;
        }
    }
}
