using UnityEngine;

namespace Script.Rouge.Skill.Skills
{
    public class MeleeAbility : MonoBehaviour, IAbility
    {
        public void Use()
        {
            Debug.Log("Melee!");
        }
    }
}