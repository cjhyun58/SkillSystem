using UnityEngine;

namespace Script.Skill.Skills
{
    public class HealAbility : MonoBehaviour, IAbility
    {
        public void Use()
        {
            Debug.Log("Heal~");
        }
    }
}