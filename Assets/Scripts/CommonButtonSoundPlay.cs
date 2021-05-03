using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonButtonSoundPlay : MonoBehaviour
{
    [SerializeField] private AudioClip pointerEnter;
    [SerializeField] private AudioClip clicked;
    [SerializeField] private AudioClip gameStart;
    [SerializeField] private AudioClip splashSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip frenzyIn;
    [SerializeField] private AudioClip frenzyOut;
    [SerializeField] private AudioClip inFrenzy;
    [SerializeField] private Camera mainCam;

    [SerializeField] private AudioSource backgroundMusicSource;
    public static CommonButtonSoundPlay CBSP;

    private void Awake()
    {
        CBSP = this;
    }
    public void PlayPointerEnter()
    {
        AudioSource.PlayClipAtPoint(pointerEnter, mainCam.transform.position, 0.8f);
    }

    public void PlayClicked()
    {
        AudioSource.PlayClipAtPoint(clicked, mainCam.transform.position, 0.8f);
    }

    public void PlayGameStart()
    {
        AudioSource.PlayClipAtPoint(gameStart, mainCam.transform.position, 0.8f);
    }

    public void PlayFrenzyIn()
    {
        AudioSource.PlayClipAtPoint(frenzyIn, mainCam.transform.position, 1.0f);
        backgroundMusicSource.Pause();
        AudioSource.PlayClipAtPoint(inFrenzy, mainCam.transform.position, 1.0f);
        Invoke("PlayFrenzyOut", 5.0f);
    }

    public void PlayFrenzyOut()
    {
        backgroundMusicSource.Play();
        AudioSource.PlayClipAtPoint(frenzyOut, mainCam.transform.position, 1.0f);
    }

    public void PlayTinCrash()
    {
        AudioSource.PlayClipAtPoint(crashSound, mainCam.transform.position, 0.8f);
    }

    public void PlaySplash()
    {
        AudioSource.PlayClipAtPoint(splashSound, mainCam.transform.position, 0.8f);
    }
}
