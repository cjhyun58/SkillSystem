using UnityEngine;

namespace Script
{
    public class Enemy : MonoBehaviour
    {
        public int hp = 100;
        
        public void GetDamage(int damage)
        {
            hp -= damage;
        }
    }
}