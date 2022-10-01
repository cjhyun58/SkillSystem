using UnityEngine;

namespace Script.Rouge.Skill.Skills
{
    public class RageAbility : MonoBehaviour, IAbility
    {
        public void Use()
        {
            Debug.Log("Rage!!");
        }
    }
}