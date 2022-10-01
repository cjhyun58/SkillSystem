using UnityEngine;

namespace Script.Rouge.Skill.Skills.FireBall
{
    [CreateAssetMenu(menuName = "Abilities/FireBallAblility")]
    public class FireBallAbility : AbstractAbility
    {
        public float projectileForce = 500f;
        public Rigidbody projectile;

        public override void Initialize(GameObject obj)
        {
            
        }
        public override void TriggerAbility()
        {
            
        }
    }
}