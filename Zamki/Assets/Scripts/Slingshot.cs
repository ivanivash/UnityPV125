using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject launchPoint;
        private void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
    }
    // Start is called before the first frame update
    void OnMouseEnter()
    {
        launchPoint.SetActive(true);
        print("Навели мишку");
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        launchPoint.SetActive(false);
        print("Фокус втратив обʼєкт");
    }
}
