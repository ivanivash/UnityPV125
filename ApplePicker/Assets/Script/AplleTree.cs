using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Ігровий обєкт який переміщається
    public GameObject applePrefab;
    //Швидкість переміщення
    public float speed = 1f;
    // Відстань, яку буде проходить яблуня
    public float leftAndRightEdge = 10f;
    // частота зміни яблук
    public float chanceToChangeDirections = 0.1f;
    // 1 раз у секунду буде падать яблука
    public float secondsBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }
}
