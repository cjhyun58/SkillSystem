using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Skill
{
    public abstract class Ability : ScriptableObject
    {
        public new string name = "New Ability";
        public int damage = 1;
        public float baseCoolDown = 1f;
        public float force = 500f;
        public Sprite sprite;
        public AudioClip castSound;
        public AudioClip hitSound;
        public GameObject projectilePrefab;

        public abstract void Activate(AbilityHolder holder);
    }
}