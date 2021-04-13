using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject exitMenuCanvas;
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
                exitMenuIsActive = !exitMenuIsActive;
                //•r¤¬„Ó¤­³ö¤¹£¡
                Time.timeScale = 1;
                exitMenuCanvas.SetActive(false);
            }
            else
            {
                exitMenuIsActive = !exitMenuIsActive;
                //¥¶?¥ï©`¥ë¥É£¡•r¤òÖ¹¤Þ¤ì£¡
                Time.timeScale = 0;
                exitMenuCanvas.SetActive(true);
            }
        }
    }
}
