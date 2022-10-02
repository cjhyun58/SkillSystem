using UnityEngine;

namespace Script.Skill
{
    public abstract class Ability : ScriptableObject
    {
        public new string name = "New Ability";
        public Sprite sprite;
        public AudioClip sound;
        public float baseCoolDown = 1f;

        public abstract void Initialize(GameObject obj);
        public abstract void TriggerAbility();
    }
}