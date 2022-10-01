using UnityEngine;

namespace Script.Skill.Skills
{
    public class MeleeAbility : MonoBehaviour, IAbility
    {
        public void Use()
        {
            Debug.Log("Melee!");
        }
    }
}