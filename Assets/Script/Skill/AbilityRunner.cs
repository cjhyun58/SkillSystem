using System.Collections.Generic;
using Script.Skill.Skills.FireBall;
using UnityEngine;

namespace Script.Skill
{
    public class AbilityRunner : MonoBehaviour
    {
        /* interface
        public List<IAbility> currentAbility = new List<IAbility>();
        private void Awake()
        {
            currentAbility.Add(ScriptableObject.CreateInstance<FireBallAbility>());
            currentAbility.Add(new RageAbility());
            currentAbility.Add(new HealAbility());
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                foreach (IAbility ability in currentAbility)
                {
                    ability.Use();
                }
            }
        }
        */

        public List<AbstractAbility> abilities = new List<AbstractAbility>();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                foreach (AbstractAbility ability in abilities)
                {
                    ability.TriggerAbility();
                }
            }
        }
    }
}