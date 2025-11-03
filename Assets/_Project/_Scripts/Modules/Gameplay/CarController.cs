namespace CrossingCat
{
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class CarController : MonoBehaviour
    {
        [SerializeField] private Rigidbody carRb;
        [SerializeField] private Vector3 moveDirection = Vector3.down;
        public float carSpeed;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            carRb.linearVelocity = moveDirection * carSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag(Constant.GameTag.CAR_HIDE_ZONE))
            {
                GameplayManager.Instance.carPool.Return(this);
            }
        }
    }
}

