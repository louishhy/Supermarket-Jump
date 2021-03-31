using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void setOptionTrigger()
    {
        if(anim!=null) anim.SetTrigger("IntoOption");
    }

    public void backToMainMenu()
    {
        if (anim != null) anim.SetTrigger("OutOption");
    }
}
