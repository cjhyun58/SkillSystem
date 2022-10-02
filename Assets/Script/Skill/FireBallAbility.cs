using UnityEngine;

namespace Script.Skill
{
    [CreateAssetMenu(menuName = "Abilities/FireBallAblility")]
    public class FireBallAbility : Ability
    {
        public float fireBallForce = 500f;
        public Rigidbody2D fireBallRigidbody;
        private FireBallTriggerable hand;

        public override void Initialize(GameObject obj)
        {
            hand = obj.GetComponent<FireBallTriggerable>();
            hand.fireBallForce = fireBallForce;
            hand.fireBall = fireBallRigidbody;
        }
        public override void TriggerAbility()
        {
            hand.Launch();
        }
    }
}