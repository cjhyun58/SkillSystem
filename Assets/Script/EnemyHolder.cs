using Script.Skill;
using UnityEngine;

namespace Script
{
    public class EnemyHolder : MonoBehaviour
    {
        private void Start()
        {
            InvokeRepeating(nameof(SpawnEnemy), 0f, 0.25f);
        }

        private void SpawnEnemy()
        {
                Enemy enemy = ObjectPoolEnemy.GetObject();
                enemy.transform.position = GetRandomPosition();
        }
        
        public Vector3 GetRandomPosition()
        {
            float radius = 7f;
            Vector3 playerPosition = transform.position;
 
            float a = playerPosition.x;
            float b = playerPosition.y;
 
            float x = Random.Range(-radius + a, radius + a);
            float y_b = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x - a, 2));
            y_b *= Random.Range(0, 2) == 0 ? -1 : 1;
            float y = y_b + b;
 
            Vector3 randomPosition = new Vector3(x, y, 0);
            return randomPosition;
        }

    }
    
}