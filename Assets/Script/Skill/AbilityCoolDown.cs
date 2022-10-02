using UnityEngine;
using UnityEngine.UI;

namespace Script.Skill
{
    public class AbilityCoolDown : MonoBehaviour
    {
        public string abilityButtonAxisName = "Fire1";
        public Image darkMask;
        public Text coolDownTextDisplay;

        [SerializeField] private Ability ability;
        [SerializeField] private GameObject weaponHolder;
        private Image myButtonImage;
        private AudioSource abilitySource;
        private float coolDownDuration;
        private float nextReadyTime;
        private float coolDownTimeLeft;

        private void Start()
        {
            Initialize(ability, weaponHolder);
        }

        private void Update()
        {
            bool coolDownComplete = (Time.time > nextReadyTime);
            if (coolDownComplete)
            {
                AbilityReady();
                if (Input.GetButtonDown((abilityButtonAxisName)))
                {
                    ButtonTriggered();
                }
            }
            else
            {
                CoolDown();
            }
        }

        void Initialize(Ability selectedAbility, GameObject weaponHolder)
        {
            ability = selectedAbility;
            myButtonImage = GetComponent<Image>();
            abilitySource = GetComponent<AudioSource>();
            myButtonImage.sprite = ability.sprite;
            darkMask.sprite = ability.sprite;
            coolDownDuration = ability.baseCoolDown;
            ability.Initialize(weaponHolder);
            AbilityReady();
        }

        void AbilityReady()
        {
            coolDownTextDisplay.enabled = false;
            darkMask.enabled = false;
        }

        void CoolDown()
        {
            coolDownTimeLeft -= Time.deltaTime;
            float roundedCoolDown = Mathf.Round(coolDownTimeLeft);
            coolDownTextDisplay.text = roundedCoolDown.ToString();
            darkMask.fillAmount = coolDownTimeLeft / coolDownDuration;
        }

        void ButtonTriggered()
        {
            nextReadyTime = coolDownDuration + Time.time;
            coolDownTimeLeft = coolDownDuration;
            darkMask.enabled = true;
            coolDownTextDisplay.enabled = true;

            //abilitySource.clip = ability.sound;
            //abilitySource.Play();
            ability.TriggerAbility();
        }
    }
}