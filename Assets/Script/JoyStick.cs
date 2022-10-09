using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script
{
    public class JoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public RectTransform rectBack;
        public RectTransform rectJoystick;
 
        Transform trCube;
        float fRadius;
        float fSpeed = 20.0f;
        float fSqr = 0f;
        Vector3 vecMove;
        Vector2 vecNormal;
        bool isTouch = false;
 
 
        void Start()
        {
            trCube = GameObject.Find("Player").transform;
 
            fRadius = rectBack.rect.width * 0.5f;
        }
 
        void Update()
        {
            if (isTouch)
            {
                trCube.position += vecMove;
            }
            
        }
 
        void OnTouch(Vector2 vecTouch)
        {
            Vector2 vec = new Vector2(vecTouch.x - rectBack.position.x, vecTouch.y - rectBack.position.y);
 
            vec = Vector2.ClampMagnitude(vec, fRadius);
            rectJoystick.localPosition = vec;
 
            float fSqr = (rectBack.position - rectJoystick.position).sqrMagnitude / (fRadius * fRadius);
 
            Vector2 vecNormal = vec.normalized;
 
            vecMove = new Vector3(vecNormal.x * fSpeed * Time.deltaTime * fSqr, vecNormal.y * fSpeed * Time.deltaTime * fSqr, 0);
            trCube.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(vecNormal.x, vecNormal.y) * Mathf.Rad2Deg *-1);
        }
 
        public void OnDrag(PointerEventData eventData)
        {
            OnTouch(eventData.position);
            isTouch = true;
        }
 
        public void OnPointerDown(PointerEventData eventData)
        {
            OnTouch(eventData.position);
            isTouch = true;
        }
 
        public void OnPointerUp(PointerEventData eventData)
        {
            rectJoystick.localPosition = Vector3.zero;
            isTouch = false;
        }
    }
}
