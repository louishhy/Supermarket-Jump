using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoticeManager : MonoBehaviour
{
    public static NoticeManager NM;
    [SerializeField] private Animator anim;
    [SerializeField] private Image objectImage;
    [SerializeField] private TMP_Text descriptionText;
    private void Awake()
    {
        NM = this;
    }

    //Interfaces for controlling the notice UI.
    //Please first set the objectImage and description texts before starting the UI!
    public void StartUI()
    {
        anim.SetTrigger("NoticeTrigger");
    }

    /*public void SetImage(Image image)
    {
        objectImage = image;
    }*/

    public void SetText(string text)
    {
        descriptionText.text = text;
    }
}
