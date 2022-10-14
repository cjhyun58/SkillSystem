using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Skill
{
    public abstract class Ability : ScriptableObject
    {
        [Header("STATE")]
        public new string name = "New Ability";
        public int damage = 1;
        public float baseCoolDown = 1f;
        public float activeTime = 3f;
        public float force = 500f;
        
        public Sprite sprite;
        public AudioClip castSound;
        public AudioClip hitSound;
        public GameObject projectilePrefab;
        
        protected Transform spawnTransform;
        protected Vector2 direction;

        public abstract void Activate(AbilityHolder holder);
    }
}