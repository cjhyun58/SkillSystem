using UnityEngine;

namespace Script
{
    public class Player : MonoBehaviour
    {
        [Header("Player State")] 
        [SerializeField] private int baseHp = 100;
        [SerializeField] private int hp = 100;
        [SerializeField] public int power = 5;
        [SerializeField] private float speed = 3f;
        [SerializeField] private int xp = 0;

        [SerializeField] private JoyStick joyStick;
        [SerializeField] private Transform abilityHolderTrans;

        private void Update()
        {
            var dir = joyStick.joyDirection;
            if(joyStick.isDrag)
                Move(dir);
            LookAt(dir);
        }

        private void LookAt(Vector2 lookVector)
        {
            float rot = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg;
            abilityHolderTrans.rotation = Quaternion.Euler(0, 0, rot - 90);
        }

        private void Move(Vector2 moveVector)
        {
            transform.Translate(moveVector * (speed * Time.deltaTime));
        }

        public void GetDamage(int damage)
        {
            hp -= damage;
        }
    }
}