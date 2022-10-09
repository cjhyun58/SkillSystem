using UnityEngine;

namespace Script.Skill
{
    [CreateAssetMenu(menuName = "Ability/FireBallAbility")]
    public class FireBallAbility : Ability
    {
        public override void Activate(AbilityHolder holder)
        {
            // 스킬 생성 위치 설정 (무기)
            spawnTransform = holder.transform;
            // 스킬 방향 설정
            direction = spawnTransform.up.normalized;

            AbilityProjectile projectileClone = ObjectPoolAbility.GetObject();
            projectileClone.transform.SetPositionAndRotation(spawnTransform.position, spawnTransform.rotation);
            projectileClone.Initialize(damage);
            projectileClone.rigidbody2D.AddForce(direction * force);
        }
    }
}