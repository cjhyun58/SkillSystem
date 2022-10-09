using UnityEngine;

namespace Script
{
    public class Player : MonoBehaviour
    {
        [Header("Player State")] 
        [SerializeField]
        private int maxHp = 100;
        [SerializeField]
        private int hp = 100;
        [SerializeField]
        public int power = 5;
        [SerializeField]
        private float speed = 3f;
        [SerializeField]
        private int xp = 0;
    
        void Update()
        {
            // Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        public void Move(float horizontal, float vertical)
        {
            var moveValue = new Vector2
            {
                x = horizontal,
                y = vertical
            };
            transform.Translate(moveValue * (speed * Time.deltaTime));
        }
        public void Move(Vector2 moveVector)
        {
            transform.Translate(moveVector * (speed * Time.deltaTime));
        }

        public void GetDamage(int damage)
        {
            hp -= damage;
            Debug.Log($"DMG : " + damage);
            Debug.Log($"HP : " + hp);
        }
    }
}
