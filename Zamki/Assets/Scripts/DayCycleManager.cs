using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    [Range(0,1)]
    public float TimeOfDay;
    public float DayDuration = 30f;

    public Light Sun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeOfDay += Time.deltaTime / DayDuration;
        if (TimeOfDay >= 1) TimeOfDay -= 1;
        Sun.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f, 180, 0);
    }
}
