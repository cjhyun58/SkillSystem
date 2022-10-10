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

        public void Initialize(int damage, float activeTime)
        {
            this.damage = damage;
            Invoke(nameof(DeleteProjectile), activeTime);
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<Enemy>().GetDamage(damage);
                DeleteProjectile();
            }
        }
        protected void DeleteProjectile()
        {
            ObjectPoolAbility.ReturnObject(this);
        }
    }
}