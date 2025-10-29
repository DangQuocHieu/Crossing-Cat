namespace CrossingCat
{
    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerRb;
        [SerializeField] private float playerSpeed;
        [SerializeField] private Vector3 movementDirection;
        [SerializeField] private float movementInput;

        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            playerRb.linearVelocity = movementDirection * playerSpeed * movementInput;
        }

        public void StartMovingLeft()
        {
            movementInput = -1;
        }

        public void StartMovingRight()
        {
            movementInput = 1;
        }

        public void Stop()
        {
            movementInput = 0;
        }
   }
}

