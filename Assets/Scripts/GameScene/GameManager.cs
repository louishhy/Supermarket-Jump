using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager S;
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator exitAnim;
    [SerializeField] private Animator switchSceneAnim;
    [SerializeField] private float survivedTime;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text scoreTextOnGUI;
    [SerializeField] private bool gameEnded = false;
    [SerializeField] private Image circleImg;
    [SerializeField] private Belt belt;
    [SerializeField] private float beginningBeltSpeed = 1.0f;
    void Awake()
    {
        S = this;
    }

    public Vector3 presentPos;
    public GameObject[] cubePrefabs;
    float score;                          


    public float minTime;
    public float maxTime;
    private float time;
    private float generateTime;

    void Start()
    {
        belt.speed = 0;
        StartCoroutine("WaitForGoingInAnim");
        SetGenerateTime();
        time = minTime;
    }

    IEnumerator WaitForGoingInAnim()
    {
        yield return null;
        AnimatorStateInfo asi = switchSceneAnim.GetCurrentAnimatorStateInfo(0);
        if (asi.IsName("Menu-to-game-game") && asi.normalizedTime > 1.0f)
        {
            Debug.Log("Play finished!");
            belt.speed = beginningBeltSpeed;
        }
        else
        {
            StartCoroutine("WaitForGoingInAnim");
        }
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time > generateTime)
        {
            GenerateNewCube(GenerateIndex());
            SetGenerateTime();
            time = 0;
        }
    }

    private void Update()
    {
        if (!gameEnded)
        {
            survivedTime += Time.deltaTime;
            scoreTextOnGUI.text = survivedTime.ToString("f1");
        }

        //After effects test Interface. Plz disable after test.
        /*if (Input.GetKeyDown(KeyCode.K))
        {
            AfterEffectsManager.AEM.setInvincibleEffect(true);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            AfterEffectsManager.AEM.setInvincibleEffect(false);
        }*/

        //Notice test interface. Plz disable after test.
        if (Input.GetKeyDown(KeyCode.K))
        {
            NoticeManager.NM.StartUI();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            NoticeManager.NM.SetText("Test");
        }
    }

    void GenerateNewCube(int index)
    {
    //    GameObject tmp = new GameObject();
    //    tmp = cubePrefabs[index];
        Instantiate(cubePrefabs[index], new Vector3(0, 0.7f, 17), new Quaternion(0, 0, 0, 0));
    //    Destroy(tmp, 10);
    }

    void SetGenerateTime()
    {
        generateTime = Random.Range(minTime, maxTime);
    }

    public int GenerateIndex()
    {
        int index = Random.Range(0, 6);
        return index;
    }

    public void HitGround(Vector3 hitPos)                                                                   
    {                                                        
    /*    Vector3 hit = hitPos;                                                                               
        hit.y = 0;                                                                                          
        Vector3 cubePos = currentCube.position;
        cubePos.y = 0;

        float dist = Vector3.Distance(hit, cubePos);                                                       
        score += dist;*/
    }

    public void GameOver()                                                                                  
    {
        gameEnded = true;
        Invoke("EndGame", 1f);
    }

    void EndGame()                                                                                     
    {
        endGameCanvas.SetActive(true);
        scoreText.text = survivedTime.ToString("f1");
    }

    public void reloadLevel()
    {
        gameEnded = false;
        Time.timeScale = 1.0f;
        StartCoroutine("waitForReloadAnimFinish");
        RectTransform rt = circleImg.GetComponent<RectTransform>();
        rt.position = new Vector3(-2171, 0, 0);
        exitAnim.SetTrigger("RestartBtnClicked");
        StartCoroutine("waitForReloadAnimFinish");
    }

    IEnumerator waitForReloadAnimFinish()
    {
        yield return null;
        AnimatorStateInfo asi = exitAnim.GetCurrentAnimatorStateInfo(0);
        if (asi.IsName("InGameSwipe") && asi.normalizedTime > 1.0f)
        {
            Debug.Log("Play finished!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            StartCoroutine("waitForReloadAnimFinish");
        }
    }
}
