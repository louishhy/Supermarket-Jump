using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoticeManager : MonoBehaviour
{
    public static NoticeManager NM;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject panelImageObject;
    [SerializeField] private TMP_Text descriptionText;

    //Storing image sprites and narrations.
    [SerializeField] private Sprite[] obstacleImages = new Sprite[7];
    [SerializeField] private string[] obstacleNarrations = new string[7];

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

    public void SetImage(int obstacleID)
    {
        panelImageObject.GetComponent<Image>().sprite = obstacleImages[obstacleID];
    }

    public void SetText(int obstacleID)
    {
        descriptionText.text = obstacleNarrations[obstacleID];
    }
}
