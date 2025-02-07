using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [Header("Movement Variables")]
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private Rigidbody2D playerRigidbody;
        public bool isGrounded;

        private void Update()
        {
            float moveInput = Input.GetAxis("Horizontal");
            playerRigidbody.velocity = new Vector2(moveInput * movementSpeed, playerRigidbody.velocity.y);

            if (Input.GetButtonDown("Jump") && isGrounded)
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground")) isGrounded = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground")) isGrounded = false;
        }
    }
}