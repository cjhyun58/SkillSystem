using UnityEngine;

namespace Script.Rouge
{
    public class Player_R : MonoBehaviour
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
            Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        void Move(float horizontal, float vertical)
        {
            var moveValue = new Vector3
            {
                x = horizontal,
                y = vertical
            };
            transform.Translate(moveValue * (speed * Time.deltaTime));
        }
    }
}
