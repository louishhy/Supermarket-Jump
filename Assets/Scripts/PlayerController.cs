using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;                       

    float timer;                        
    public float maxChargeTime;         
    public float jumpPower;             
    public bool doJump;                
    public bool isGround = true;               

    void Start()
    {
        isGround = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && timer < maxChargeTime && isGround == true)                                                      
        {
            timer += Time.deltaTime;                                                                                    
            transform.localScale = new Vector3(1, 0.5f + ((maxChargeTime - timer) / maxChargeTime) / 2, 1) * 0.2f;      
        }                                                                                                               
                                                                                                                        
        if (Input.GetKeyUp(KeyCode.Mouse0)  && isGround == true)
        {
            doJump = true;                                                                                              
            transform.localScale = Vector3.one * 0.2f;
        }
    }

    private void FixedUpdate()                                                                                          
    {
        if(doJump)
        {
            Jump();
            timer = 0;
            doJump = false;
        }
    }

    void Jump()
    {
        Vector3 dir = transform.forward;                         
        dir.y = 2;                                                                                                    
        rb.velocity = dir * jumpPower * timer;
        isGround = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")                    
        {
            GameManager.S.HitGround(transform.position);                                                                
            rb.velocity = Vector3.zero;                                                                                 
            rb.rotation = Quaternion.identity;
            isGround = true;
        }
        else if (collision.gameObject.tag == "Cube")
        {
            isGround = true;
        }
        else if(collision.gameObject.tag == "Plane")                                                              
        {
            GameManager.S.GameOver();
        }
    }
}
