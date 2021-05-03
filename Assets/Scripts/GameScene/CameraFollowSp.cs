using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSp : MonoBehaviour
{
    public Transform target;                                                                    
    public float smoothAmount;
    public Vector3[] positions = new Vector3[3];
    public Vector3[] eulerRots = new Vector3[3];
    public Vector3[] offsets = new Vector3[3];

    Vector3 originPos;                                                                          
    Vector3 offset;                                                                             

    void Start()
    {
        //offset = target.position - transform.position;                                          
        //originPos = transform.position;
        for (int i = 0; i<3; i++)
        {
            offsets[i] = target.position - positions[i];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.SetPositionAndRotation(positions[0], Quaternion.Euler(eulerRots[0]));
            offset = offsets[0];
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            transform.SetPositionAndRotation(positions[1], Quaternion.Euler(eulerRots[1]));
            offset = offsets[1];
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            transform.SetPositionAndRotation(positions[2], Quaternion.Euler(eulerRots[2]));
            offset = offsets[2];
        }
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
