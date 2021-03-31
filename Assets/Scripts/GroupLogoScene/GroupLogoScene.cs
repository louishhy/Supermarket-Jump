using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class GroupLogoScene : MonoBehaviour
{
    [SerializeField] private float waitingTime = 1.0f;
    [SerializeField] private float fadeInAnimTime = 2.5f;
    [SerializeField] private float fadeOutAnimTime = 2.0f;
    [SerializeField] private Animator anim;
    [SerializeField] private bool alreadyInvokedGoingOut = false;
    [SerializeField] private string goingInAnimName = "Group_Logo_Scene_Fade_In";
    [SerializeField] private string goingOutAnimName = "Group_Logo_Scene_Fade_Out";

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Wait for goingInAnim to play to an end, then wait for waitingTime to set trigger.
        AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (animInfo.IsName(goingInAnimName) && animInfo.normalizedTime >1.0f && !alreadyInvokedGoingOut)
        {
            Invoke("setAnimTrigger", waitingTime);
        }

        if (animInfo.IsName(goingOutAnimName) && animInfo.normalizedTime > 1.0f)
        {
            Invoke("loadMenuScene", waitingTime);
        }
    }

    void setAnimTrigger()
    {
        anim.SetTrigger("Display_Complete");
    }

    void loadMenuScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    //Load next scene.
    }
    
}
