using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;                       

    float timer;                        
    public float maxChargeTime;         
    public float jumpPower;             
    public bool doJump;                
    public bool isGround = true;
    [SerializeField] private GameObject soundRefPoint;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private float jumpPlayingSound = 1.0f;
    [SerializeField] private float chargeDeadZone = 0.5f;
    [SerializeField] private float frenzyDuration = 5.0f;
    [SerializeField] private float defaultLocalScale = 0.25f;
    [SerializeField] private AudioClip collisionSound;

    void Start()
    {
        isGround = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && timer < maxChargeTime && isGround == true)                                                      
        {
            timer += Time.deltaTime;                                                                                    
            transform.localScale = new Vector3(1, 0.5f + ((maxChargeTime - timer) / maxChargeTime) / 2, 1) * defaultLocalScale;      
        }                                                                                                               
                                                                                                                        
        if (Input.GetKeyUp(KeyCode.Space)  && isGround == true)
        {
            doJump = true;                                                                                              
            transform.localScale = Vector3.one * defaultLocalScale;
        }
    }

    private void FixedUpdate()                                                                                          
    {
        if(doJump)
        {
            if (jumpPower * timer >= chargeDeadZone) Jump();
            timer = 0;
            doJump = false;
        }
    }

    void Jump()
    {
        AudioSource.PlayClipAtPoint(jumpSound, soundRefPoint.transform.position, jumpPlayingSound);
        Vector3 dir = transform.forward;                         
        dir.y = 2;                                                                                                    
        rb.velocity = dir * jumpPower * timer;
        isGround = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("On collision with:" + collision.gameObject.name);
        if (collision.gameObject.tag == "Ground")                    
        {                                                                
            rb.velocity = Vector3.zero;                                                                                 
            //rb.rotation = Quaternion.identity;
            isGround = true;
        }
        else if (collision.collider.gameObject.tag == "DeadlyObstacle")
        {
            GameManager.S.GameOver(transform.position);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Plane")                                                              
        {
            GameManager.S.GameOver(transform.position);
            Destroy(gameObject);
        }
        else if (collision.collider.gameObject.tag == "Obstacle")
        {
            AudioSource.PlayClipAtPoint(collisionSound, soundRefPoint.transform.position, 1.0f);
            isGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "InvincibleTrigger" && !GameManager.S.IsFrenzy)
        {
            FrenzyModeOn();
        }
    }

    private void FrenzyModeOn()
    {
        CommonButtonSoundPlay.CBSP.PlayFrenzyIn();
        AfterEffectsManager.AEM.setInvincibleEffect(true);
        GameManager.S.SetFrenzy(true);
        Invoke("FrenzyModeOff", frenzyDuration);
    }

    private void FrenzyModeOff()
    {
        AfterEffectsManager.AEM.setInvincibleEffect(false);
        GameManager.S.SetFrenzy(false);
    }

}
