using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script
{
    public class JoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public RectTransform rectBack;
        public RectTransform rectJoystick;

        public Vector3 joyDirection;
        private float backRadius;
        Player player;
 
        void Start()
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
            backRadius = rectBack.sizeDelta.y * 0.5f;
            backRadius *= transform.parent.GetComponent<RectTransform>().localScale.x;
        }
 
        void Update()
        {
            player.Move(joyDirection);
        }
 
        public void OnDrag(PointerEventData eventData)
        {
            Vector3 pos = eventData.position;
            Vector3 backPos = rectBack.transform.position;
            joyDirection = (pos - backPos).normalized;
 
            float distance = Vector3.Distance(pos, backPos);
        
            if (distance < backRadius)
                rectJoystick.position = backPos + joyDirection * distance;
            else
                rectJoystick.position = backPos + joyDirection * backRadius;
        }
 
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }
 
        public void OnPointerUp(PointerEventData eventData)
        {
            rectJoystick.localPosition = Vector3.zero;
            joyDirection = Vector3.zero;      
        }
    }
}
