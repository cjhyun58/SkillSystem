using UnityEngine;

namespace Script.Skill
{
    [CreateAssetMenu(menuName = "Ability/FireBallAbility")]
    public class FireBallAbility : Ability
    {
        
        public override void Activate(AbilityHolder holder)
        {
            // 스킬 생성 위치 설정
            Transform spawnTransform = holder.transform;
            projectileClone = Instantiate(projectilePrefab, spawnTransform.position, spawnTransform.rotation);
            // projectileClone에서 필요한 데이터
            // Rigidbody2D, damage
            
            // 수정 필요 (Expensive Method)
            projectileClone.GetComponent<FireBallPrefab>().damage = damage;
            projectileClone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }

        public override void BeginCooldown(AbilityHolder holder)
        {
        }

        public override void DeleteEffect(AbilityHolder holder)
        {
        }
    }
}