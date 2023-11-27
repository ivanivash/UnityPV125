using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ;

    private void Awake()
    {
        camZ = this.transform.position.z;
    }
    private void FixedUpdate()
    {
        // if (POI == null) return;
        // Vector3 destination = POI.transform.position;

        Vector3 destination;

        // якщо не має обʼєкта, то вернути Р:[ 0, 0, 0 ]
        if (POI == null){
            destination = Vector3.zero;
        }
        else{
            // отримати позицію обєкта
            destination = POI.transform.position;
            // якщо обʼєк снаряд, то переконуємося, що він зупинився
            if (POI.tag == "Projectile"){
                // якщо стоїть на місці (не рухається)
                if (POI.GetComponent<Rigidbody>().IsSleeping()) {
                    // повернути камеру на початок
                    POI = null;
                    return;
                }
            }
        }

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}
