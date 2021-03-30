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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("setAnimTrigger", fadeInAnimTime + waitingTime);
        Invoke("loadMenuScene", fadeInAnimTime + waitingTime + fadeOutAnimTime);
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
