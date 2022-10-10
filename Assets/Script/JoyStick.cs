using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script
{
    public class JoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        private RectTransform rectBack;
        private RectTransform rectJoystick;
        private Vector2 firstRectPos;
        private float backRadius;
        
        public Vector2 joyDirection;
        public bool isDrag;
 
        void Start()
        {
            RectTransform[] rectTrans = GetComponentsInChildren<RectTransform>();
            rectBack = rectTrans[1];
            rectJoystick = rectTrans[2];
            
            backRadius = rectBack.sizeDelta.y * 0.5f;
            backRadius *= transform.parent.GetComponent<RectTransform>().localScale.x;
            
            joyDirection = Vector2.up;
        }
 
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos = eventData.position;
            Vector2 backPos = firstRectPos;
            joyDirection = (pos - backPos).normalized;
            
            float distance = Vector2.Distance(pos, backPos);
            if (distance < backRadius)
                rectJoystick.position = backPos + joyDirection * distance;
            else
                rectJoystick.position = backPos + joyDirection * backRadius;
            
            isDrag = true;
        }
 
        public void OnPointerDown(PointerEventData eventData)
        {
            firstRectPos = eventData.position;
            rectBack.position = firstRectPos;
        }
 
        public void OnPointerUp(PointerEventData eventData)
        {
            rectJoystick.localPosition = Vector3.zero;
            rectBack.anchoredPosition = Vector2.zero;
            
            isDrag = false;
        }
    }
}
