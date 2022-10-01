using UnityEngine;

namespace Script.Rouge.Skill.Skills
{
    public class HealAbility : MonoBehaviour, IAbility
    {
        public void Use()
        {
            Debug.Log("Heal~");
        }
    }
}