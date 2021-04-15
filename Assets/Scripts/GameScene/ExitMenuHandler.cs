using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject exitMenuCanvas; //The in-game menu.
    [SerializeField] private bool exitMenuIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        exitMenuIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitMenuIsActive)
            {
                retryGame(); //Disable the in-game menu and continue the game.
            }
            else
            {
                stopGame(); //Stop the game and enable the in-game menu.
            }
        }
    }

    public void retryGame() //Binded to the Retry button's OnClick()
    {
        exitMenuIsActive = !exitMenuIsActive;
        Time.timeScale = 1;
        exitMenuCanvas.SetActive(false);
    }

    public void stopGame()
    {
        exitMenuIsActive = !exitMenuIsActive;
        Time.timeScale = 0;
        exitMenuCanvas.SetActive(true);
    }

    public void backToMain() //Binded to the "Back to main menu" button's OnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
