using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Skill
{
    public abstract class AbilityTrigger : MonoBehaviour
    {
        [SerializeField] private Ability ability;
        private FireBall projectile;
        private Rigidbody2D projectileRigidbody;
        private Transform spawnPosition;
        private float coolDownDuration;
        private float nextReadyTime;
        private float force;
        private int damage;

        private void Start()
        {
            Initialize(ability);
        }
        private void Update()
        {
            bool coolDownComplete = (Time.time > nextReadyTime);
            if (coolDownComplete)
                Launch();
        }
        
        private void Initialize(Ability selectedAbility)
        {
            ability = selectedAbility;
            projectile = ability.projectile;
            coolDownDuration = ability.baseCoolDown;
            force = ability.force;
            damage = ability.damage;
            spawnPosition = transform;
        }
        private void Launch()
        {
            nextReadyTime = coolDownDuration + Time.time;
            var clonedBullet = Instantiate(projectile, spawnPosition.position, transform.rotation) as FireBall;
            clonedBullet.damage = damage;
            clonedBullet.rigidbody.AddForce(Vector2.up * force);
        }
    }
}