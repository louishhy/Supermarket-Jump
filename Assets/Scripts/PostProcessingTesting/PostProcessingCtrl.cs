using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PostProcessingCtrl : MonoBehaviour
{
    [SerializeField] private GameObject normalPpv;
    [SerializeField] private GameObject invinciblePpv;
    [SerializeField] private GameObject splashCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            callNormal();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            callInvincible();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            callSplash();
        }
    }

    void callNormal()
    {
        normalPpv.SetActive(true);
        invinciblePpv.SetActive(false);
        splashCanvas.SetActive(false);
    }
    void callInvincible()
    {
        normalPpv.SetActive(false);
        invinciblePpv.SetActive(true);
        splashCanvas.SetActive(false);
    }
    void callSplash()
    {
        normalPpv.SetActive(false);
        invinciblePpv.SetActive(false);
        splashCanvas.SetActive(true);
    }


}
