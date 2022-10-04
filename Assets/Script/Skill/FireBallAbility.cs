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

            
            AbilityProjectile projectileClone = ObjectPool.GetObject();
            projectileClone.transform.SetPositionAndRotation(spawnTransform.position, spawnTransform.rotation);
            projectileClone.Initialize(damage);
            projectileClone.rigidbody2D.AddForce(direction * force);
            
            
            // 오브젝트 풀링 구현 필요
            //GameObject projectileClone = Instantiate(projectilePrefab, spawnTransform.position, spawnTransform.rotation);
            // 성능 개선 필요
            // FireBallProjectile fireBallProjectile = projectileClone.GetComponent<FireBallProjectile>();
            // fireBallProjectile.Initialize(damage);
            // fireBallProjectile.rigidbody2D.AddForce(direction * force);
        }

    }
}