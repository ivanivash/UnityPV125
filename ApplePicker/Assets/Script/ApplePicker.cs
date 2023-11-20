using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class ApplePicker : MonoBehaviour
    {
        [Header("Set in Inspector")]
        public GameObject basketPrefab;
        public int numBaskets = 3;
        public float basketBottomY = -14f;
        public float basketSpacingY = 2f;
        public List<GameObject> basketList;
// Start is called before the first frame update
        void Start()
        {
            basketList = new List<GameObject>();
            for (int i = 0; i < numBaskets; i++) {
                GameObject tBasketGo = Instantiate(basketPrefab);
                Vector3 pos = Vector3.zero;
                pos.y = basketBottomY + (basketSpacingY * i);
                tBasketGo.transform.position = pos;
                basketList.Add(tBasketGo);
            }
        }

        public void AppleDestroyed() {
            GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
            foreach (GameObject tGo in tAppleArray) {
                Destroy(tGo);
            }

            //Індекс елемента кошика, який хочемо видалити
            int basketIndex = basketList.Count - 1;
            GameObject tBasketGo = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(tBasketGo);
            
            if (basketList.Count == 0) {
                SceneManager.LoadScene("GameOver");
            }
        }

// Update is called once per frame

    }
}