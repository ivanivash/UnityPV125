using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int numClouds = 45;                              // число хмаринок
    public GameObject cloudPrefab;                          // шаблон для хмаринок
    public Vector3 cloudPosMin = new Vector3(-50, -5, 10);
    public Vector3 cloudPosMax = new Vector3(150, 100, 10);
    public float cloudScaleMin = 1;                         // мінімальний маштаб хмаринки
    public float cloudScaleMax = 3;                         // максимальний маштаб хмаринки
    public float cloudSpeedMult = 0.5f;                     // коофіціент швидкості хмаринки

    private GameObject[] cloudInstances;

    private void Awake()
    {
        // стовіть масив для збереження всіх екземплярів хмаринки
        cloudInstances = new GameObject[numClouds];

        GameObject anchor = GameObject.Find("CloudAnchor");

        // створити в циклі задану кільькість хмаринок
        GameObject cloud;
        for (int i =0; i<numClouds; i++)
        {
            // створити екземпляр cloudPrefab
            cloud = Instantiate<GameObject>(cloudPrefab);
            // вибрати місце для хмарринки
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);
            // маштабувати хмаринку
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);
            cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);
            cPos.z = 100 - 90 * scaleU;
            // застосувати отримані координати і маштаби до хмаринки
            cloud.transform.position = cPos;
            cloud.transform.localScale = Vector3.one * scaleVal;

            cloud.transform.SetParent(anchor.transform);
            cloudInstances[i] = cloud;
        }

    }
    // Update is called once per frame
    void Update()
    {
        // проходимося циклом по всіх хмаринках
        foreach (GameObject cloud in cloudInstances)
        {
            //  отримуємо координати та маштаб хмаринки
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;
            // збільшити швидкість для ближніх хмаринок
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
            // якщо хмаринка змістилася дуже сильно в ліво
            if (cPos.x <= cloudPosMin.x)
            {
                // переміщаємо його вправо
                cPos.x = cloudPosMax.x;
            }
            // застосовуємо координати до хмаринки
            cloud.transform.position = cPos;
        }
    }
}
