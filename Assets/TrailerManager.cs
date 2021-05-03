using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerManager : MonoBehaviour
{
    public GameObject Can0;
    public GameObject Can1;
    public GameObject Can2;
    public GameObject Can3;
    //public GameObject Can4;
    public GameObject NameCan;
    public GameObject aud;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            aud.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Can0.SetActive(true);
            Can1.SetActive(false);
            Can2.SetActive(false);
            Can3.SetActive(false);
            //Can4.SetActive(false);
            NameCan.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("H!");
            Can0.SetActive(false);
            Can1.SetActive(true);
            Can2.SetActive(false);
            Can3.SetActive(false);
            //Can4.SetActive(false);
            NameCan.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            Can0.SetActive(false);
            Can1.SetActive(false);
            Can2.SetActive(true);
            Can3.SetActive(false);
            //Can4.SetActive(false);
            NameCan.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            Can0.SetActive(false);
            Can1.SetActive(false);
            Can2.SetActive(false);
            Can3.SetActive(true);
            //Can4.SetActive(false);
            NameCan.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Can0.SetActive(false);
            Can1.SetActive(false);
            Can2.SetActive(false);
            Can3.SetActive(false);
            //Can4.SetActive(false);
            NameCan.SetActive(true);
        }
        
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Can0.SetActive(false);
            Can1.SetActive(false);
            Can2.SetActive(false);
            Can3.SetActive(false);
            //Can4.SetActive(false);
            NameCan.SetActive(false);
        }
    }
}
