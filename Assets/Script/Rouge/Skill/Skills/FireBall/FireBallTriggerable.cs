using UnityEngine;

namespace Script.Rouge.Skill.Skills.FireBall
{
    public class ProjectileShootTriggerable : MonoBehaviour {

        [HideInInspector] public Rigidbody projectile;
        public Transform bulletSpawn;
        [HideInInspector] public float projectileForce = 250f;

        public void Launch()
        {
            Rigidbody clonedBullet = Instantiate(projectile, bulletSpawn.position, transform.rotation) as Rigidbody;
            clonedBullet.AddForce(bulletSpawn.transform.forward * projectileForce);
        }
    }
}