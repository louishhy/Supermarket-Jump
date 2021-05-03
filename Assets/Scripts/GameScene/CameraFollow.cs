using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                                                                    
    public float smoothAmount;                                                                 

    Vector3 originPos;                                                                          
    Vector3 offset;                                                                             

    void Start()
    {
        offset = target.position - transform.position;                                          
        originPos = transform.position;
    }
       
    void LateUpdate()                                                                          
    {
        if (!GameManager.S.GameEnded)
        {
            Vector3 targetPos = target.position - offset;
            targetPos.y = transform.position.y;
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothAmount);
        }
    }
}
