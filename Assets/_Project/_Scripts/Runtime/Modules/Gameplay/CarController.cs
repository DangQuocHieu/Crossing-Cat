namespace CrossingCat
{
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class CarController : MonoBehaviour
    {
        [SerializeField] private Rigidbody carRb;
        [SerializeField] private Vector3 moveDirection = Vector3.down;
        [SerializeField] private float carSpeed = 10f;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            carRb.linearVelocity = moveDirection * carSpeed;
        }
    }

   
}

