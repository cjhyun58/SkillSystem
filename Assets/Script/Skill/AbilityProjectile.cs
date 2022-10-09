using UnityEngine;

namespace Script.Skill
{
    public abstract class AbilityProjectile : MonoBehaviour
    {
        private int damage;
        public Rigidbody2D rigidbody2D { get; private set;}

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            // 시간 기준 삭제 필요
        }

        public void Initialize(int damage)
        {
            this.damage = damage;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<Enemy>().GetDamage(damage);
                ObjectPoolAbility.ReturnObject(this);
            }
        }
    }
}