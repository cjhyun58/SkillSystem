using UnityEngine;

namespace Script.Rouge.Skill.Skills.FireBall
{
    public abstract class AbstractAbility : ScriptableObject
    {
        public new string name = "New Ability";
        public Sprite sprite;
        public AudioClip sound;
        public float baseCoolDown = 1f;

        public abstract void Initialize(GameObject obj);
        public abstract void TriggerAbility();
    }
}