using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerDriver : MonoBehaviour
{
    [SerializeField] private Vector3 moveVec = Vector3.zero;
    [SerializeField] private Vector3 rotationVec = Vector3.zero;
    [SerializeField] private Vector3 thrusterForce = Vector3.zero;
    [SerializeField] private Vector3 camRotationVec = Vector3.zero;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;

    public Vector3 MoveVec
    {
        set
        {
            this.moveVec = value;
        }
    }

    public Vector3 RotationVec
    {
        set
        {
            this.rotationVec = value;
        }
    }
    public Vector3 ThrusterForce
    {
        set
        {
            this.thrusterForce = value;
        }
    }
    public Vector3 CamRotationVec
    {
        set
        {
            this.camRotationVec = value;
        }
    }

    void performMove()
    {
        if (this.moveVec != Vector3.zero)
        {
            rb.MovePosition(transform.position + moveVec * Time.fixedDeltaTime);
        }
    }
    void performRotate()
    {
        if (this.rotationVec != Vector3.zero)
        {
            rb.MoveRotation(transform.rotation * Quaternion.Euler(rotationVec));
        }
    }
    void performCamRotate()
    {
        if (this.camRotationVec != Vector3.zero)
        {
            this.cam.transform.Rotate(this.camRotationVec);
        }
    }
    void performThrust()
    {
        if (this.thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce, ForceMode.Acceleration);
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 xMov = Input.GetAxis("Horizontal") * transform.right;
        Vector3 zMov = Input.GetAxis("Vertical") * transform.forward;
        moveVec = (xMov + zMov).normalized;
        rotationVec = Input.GetAxis("Mouse X") * Vector3.up * Time.deltaTime;
        camRotationVec = Input.GetAxis("Mouse Y") * transform.right * Time.deltaTime; 
    }

    //Updates physics.
    void FixedUpdate()
    {
        performCamRotate();
        performMove();
        performRotate();
        performThrust();
    }
}
