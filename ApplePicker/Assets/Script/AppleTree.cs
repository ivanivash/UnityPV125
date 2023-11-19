using UnityEngine;

namespace Script
{
    public class AppleTree : MonoBehaviour
    {
        [Header("Set in Inspector")]
        //Ігровий обєкт який переміщається
        public GameObject applePrefab;
        
        //Швидкість переміщення
        public float speed = 1f;
        
        // Відстань, яку буде проходить яблуня
        public float leftAndRightEdge = 10f;
        
        // частота зміни яблук
        public float chanceToChangeDirections = 0.01f;
        
        // 1 раз у секунду буде падать яблука
        public float secondsBetweenAppleDrops = 1f;
        
        // Start is called before the first frame update
        void Start() {
            // скидає яблука  раз в секунду
            Invoke("DropApple", 2f);
        }

        void DropApple() {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            Invoke("DropApple", secondsBetweenAppleDrops);
            
        }

            //просте направлення яблуні
        void Update() {
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
            
            // зміна напрямку руху яблуні
            if (pos.x < -leftAndRightEdge) {
                speed = Mathf.Abs(speed);   // початок руху вліво
            }
            else if (pos.x > leftAndRightEdge) {
                speed = -Mathf.Abs(speed);  // початок руху вправо
            }
        }
        void FixedUpdate() {
            if (Random.value < chanceToChangeDirections) {
                speed *= -1; // Change direction
            }
        }
    }
}