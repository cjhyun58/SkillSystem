using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Skill.Skills.FireBall
{
    public class FireBallTriggerable : MonoBehaviour {

        [HideInInspector] public Rigidbody2D fireBall;
        public Transform bulletSpawn;
        [HideInInspector] public float fireBallForce = 250f;

        public void Launch()
        {
            Rigidbody2D clonedBullet = Instantiate(fireBall, bulletSpawn.position, transform.rotation) as Rigidbody2D;
            clonedBullet.AddForce(bulletSpawn.transform.right * fireBallForce);
        }
    }
}