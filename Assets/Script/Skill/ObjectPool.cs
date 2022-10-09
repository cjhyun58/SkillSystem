using System.Collections.Generic;
using UnityEngine;

namespace Script.Skill
{
    public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static ObjectPool<T> instance;

        // 스킬(맵) 선택시 할당 해줄 예정  
        [SerializeField]
        private GameObject poolingObjectPrefab;
        
        Queue<T> poolingObjectQueue = new Queue<T>();
        [SerializeField]
        private int initCount;

        private void Awake()
        {
            instance = this;
            Initialize(initCount);
        }

        private void Initialize(int initCount)
        {
            for(int i = 0; i < initCount; i++)
            {
                poolingObjectQueue.Enqueue(CreateNewObject());
            }
        }

        private T CreateNewObject()
        {
            var newObj = Instantiate(poolingObjectPrefab).GetComponent<T>();
            newObj.gameObject.SetActive(false);
            newObj.transform.SetParent(transform);
            return newObj;
        }

        public static T GetObject()
        {
            if(instance.poolingObjectQueue.Count > 0)
            {
                var obj = instance.poolingObjectQueue.Dequeue();
                obj.transform.SetParent(null);
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                var newObj = instance.CreateNewObject();
                newObj.gameObject.SetActive(true);
                newObj.transform.SetParent(null);
                return newObj;
            }
        }

        public static void ReturnObject(T obj)
        {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(instance.transform);
            instance.poolingObjectQueue.Enqueue(obj);
        }
    }
}