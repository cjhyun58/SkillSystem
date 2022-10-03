using System;
using UnityEngine;

namespace Script.Skill
{
    public class FireBallPrefab : MonoBehaviour
    {
        private int damage;
        public Rigidbody2D rigidbody2D { get; private set;}

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            // 오브젝트 풀링 구현 필요
            Destroy(gameObject, 3);
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
                // 오브젝트 풀링 구현 필요
                Destroy(gameObject);
            }
        }


    }
}