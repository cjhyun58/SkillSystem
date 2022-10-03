using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Skill
{
    public class AbilityHolder : MonoBehaviour
    {
        [SerializeField] private Ability ability;
        private float nextReadyTime;

        private void Update()
        {
            bool coolDownComplete = (Time.time > nextReadyTime);
            if (coolDownComplete)
                ActiveAbility();
        }
        
        private void ActiveAbility()
        {
            nextReadyTime = ability.baseCoolDown + Time.time;
            ability.Activate(this);
        }
    }
}