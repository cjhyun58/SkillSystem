using System;
using UnityEngine;

namespace Script.Skill
{
    public class FireBall : MonoBehaviour
    {
        public new Rigidbody2D rigidbody;
        public int damage { get; set;}

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<Enemy>().GetDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}