using UnityEngine;

namespace Script.Skill
{
    public class AbilityCoolDown : MonoBehaviour
    {
        [SerializeField] private Ability ability;
        [SerializeField] private GameObject weaponHolder;
        private AudioSource abilitySource;
        private float coolDownDuration;
        private float nextReadyTime;

        private void Start()
        {
            Initialize(ability, weaponHolder);
        }

        private void Update()
        {
            bool coolDownComplete = (Time.time > nextReadyTime);
            if (coolDownComplete)
            {
                ButtonTriggered();
            }
            else
            {
                CoolDown();
            }
        }

        void Initialize(Ability selectedAbility, GameObject weaponHolder)
        {
            ability = selectedAbility;
            abilitySource = GetComponent<AudioSource>();
            coolDownDuration = ability.baseCoolDown;
            ability.Initialize(weaponHolder);
            AbilityReady();
        }
        void AbilityReady()
        {
            
        }
        void CoolDown()
        {
            
        }
        void ButtonTriggered()
        {
            nextReadyTime = coolDownDuration + Time.time;
            //abilitySource.clip = ability.sound;
            //abilitySource.Play();
            ability.TriggerAbility();
        }
    }
}