using UnityEngine;
using UnityEngine.Rendering;

namespace CrossingCat
{
    public class PlayerController : MonoBehaviour
    {
        [Header("---------------References---------------")]
        [SerializeField] private Rigidbody playerRb;
        [SerializeField] private BoxCollider playerCollider;
        [SerializeField] private Animator playerAnim;

        [Header("---------------Movement Properties---------------")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private Vector3 movementDirection = Vector3.right;
        private float movementInput;
        public bool canMove = true;
        

        private void FixedUpdate()
        {
            playerRb.linearVelocity = moveSpeed * movementDirection * movementInput;
        }

        public void StartMovingLeft() 
        {
            if (!canMove) return;
            movementInput = -1;
            playerAnim.SetBool(Constant.AnimatiorParam.IDLE, false);
        }

        public void StartMovingRight()
        {
            if(!canMove) return;
            movementInput = 1;
            playerAnim.SetBool(Constant.AnimatiorParam.IDLE, false);
        }

        public void OnIdle()
        {
            if (!canMove) return;
            movementInput = 0; 
            playerAnim.SetBool(Constant.AnimatiorParam.IDLE, true);

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Constant.GameTag.CAR))
            {
                StopMovement();
                GameplayManager.Instance.ChangeState(Enum.GameplayState.Lose);
            }
            else if (other.gameObject.CompareTag(Constant.GameTag.VICTORY_ZONE))
            {
                StopMovement();
                GameplayManager.Instance.ChangeState(Enum.GameplayState.Victory);
            }
        }

        private void StopMovement()
        {
            canMove = false;
            movementDirection = Vector3.zero;
            playerRb.linearVelocity = Vector3.zero;
        }
    }
}