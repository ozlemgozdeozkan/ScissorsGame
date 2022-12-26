using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Tracking : MonoBehaviour
{
    [SerializeField]
    GameObject player; // takip edece�i obje

    Vector3 distance;
    
    void Start()
    {
        distance = transform.position - player.transform.position;//Aralar�ndaki uzakl�k
    }

       void Update()
    {
        
    }
    void LateUpdate()
    {
        if (PlayerController.falling)
        {
            return;
        }
        transform.position = player.transform.position + distance;//Takip etmek

    }
}
