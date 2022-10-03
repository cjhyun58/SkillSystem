using System;
using UnityEngine;

namespace Script.Skill
{
    public class FireBallPrefab : MonoBehaviour
    {
        public int damage { get; set;}

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