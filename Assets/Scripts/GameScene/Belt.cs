using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    public float time = 0;
    public float speedUpTime;
    [SerializeField] private float speedUpperBound = 3.0f;
    [SerializeField] private float speedUpRate = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > speedUpTime && speed<speedUpperBound)
        {
            speed += speedUpRate;
            time = 0;
        }
        Vector3 pos = rb.position;
        rb.position -= Vector3.back * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }
}