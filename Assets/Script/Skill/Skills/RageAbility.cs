using UnityEngine;

namespace Script.Skill.Skills
{
    public class RageAbility : MonoBehaviour, IAbility
    {
        public void Use()
        {
            Debug.Log("Rage!!");
        }
    }
}