using UnityEngine;

namespace Script
{
    public class MainCamera : MonoBehaviour
    {
        private Transform playerTransform;
        private readonly float speed = 7.5f;
        void Awake()
        {
            playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }

        void LateUpdate()
        {
            FollowPlayer();
        }

        void FollowPlayer()
        {
            transform.position = Vector2.Lerp(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }
}
