using UnityEngine;

namespace Script.Skill
{
    [CreateAssetMenu(menuName = "Ability/FireBallAbility")]
    public class FireBallAbility : Ability
    {
        public override void Activate(AbilityHolder holder)
        {
            // 스킬 생성 위치 설정 (무기)
            Transform holderTransform = holder.transform;
            // 스킬 방향 설정
            Vector2 direction = holderTransform.up.normalized;
            
            // 오브젝트 풀링 구현 필요
            GameObject projectileClone = Instantiate(projectilePrefab, holderTransform.position, holderTransform.rotation);
            
            // 성능 개선 필요
            FireBallPrefab fireBallPrefab = projectileClone.GetComponent<FireBallPrefab>();
            fireBallPrefab.Initialize(damage);
            fireBallPrefab.rigidbody2D.AddForce(direction * force);
        }
    }
}