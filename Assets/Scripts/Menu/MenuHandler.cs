using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private Animator menuAnim;
    [SerializeField] private Animator intoGameAnim;
    [SerializeField] private string intoGameAnimationName = "Menu-to-game-menu";

    private void Update()
    {
        
    }


    public void setOptionTrigger()
    {
        if(menuAnim != null) menuAnim.SetTrigger("IntoOption");
    }

    public void backToMainMenu()
    {
        if (menuAnim != null) menuAnim.SetTrigger("OutOption");
    }

    public void startingGame()
    {
        CommonButtonSoundPlay.CBSP.PlayGameStart();
        if (intoGameAnim != null) intoGameAnim.SetTrigger("IntoGame");
        if (menuAnim != null) menuAnim.SetTrigger("IntoGame");
        StartCoroutine("loadGame");
    }

    IEnumerator loadGame()
    {
        yield return null;
        AnimatorStateInfo animInfo = intoGameAnim.GetCurrentAnimatorStateInfo(0);
        if ((animInfo.IsName(intoGameAnimationName) && animInfo.normalizedTime > 1.0f)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            StartCoroutine("loadGame");
        }
        
    }

    public void QuitGame()
    {
        Debug.Log("Quitted Game");
        Application.Quit();
    }
}
