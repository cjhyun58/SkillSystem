using System.Collections.Generic;
using UnityEngine;

namespace Script.Skill
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool instance;

        [SerializeField]
        private GameObject poolingObjectPrefab;

        Queue<AbilityProjectile> poolingObjectQueue = new Queue<AbilityProjectile>();

        private void Awake()
        {
            instance = this;
            Initialize(10);
        }

        private void Initialize(int initCount)
        {
            for(int i = 0; i < initCount; i++)
            {
                poolingObjectQueue.Enqueue(CreateNewObject());
            }
        }

        private AbilityProjectile CreateNewObject()
        {
            var newObj = Instantiate(poolingObjectPrefab).GetComponent<AbilityProjectile>();
            newObj.gameObject.SetActive(false);
            newObj.transform.SetParent(transform);
            return newObj;
        }

        public static AbilityProjectile GetObject()
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

        public static void ReturnObject(AbilityProjectile obj)
        {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(instance.transform);
            instance.poolingObjectQueue.Enqueue(obj);
        }
    }
}