using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Object index description
    public const int CHAIR = 0;
    public const int BASKET = 1;
    public const int COLA = 2;
    public const int TISSUE = 3;
    public const int BOX = 4;
    public const int JACK_IN_THE_BOX = 5;
    public const int PAINT_TIN = 6;

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
    [SerializeField] private bool isFrenzy = false;
    [SerializeField] private float frenzyBonusRate = 5.0f;
    [SerializeField] private GameObject frenzyNotice;

    public Vector3 presentPos;
    public GameObject[] cubePrefabs;
    [SerializeField] private bool[] prefabAlreadyGenerated;
    [SerializeField] private Vector3[] prefabDefaultGeneratingPoint;
    [SerializeField] private Vector3[] prefabDefaultGeneratingEuler;
    public float minTime;
    public float maxTime;
    private float time;
    private float generateTime;

    void Awake()
    {
        S = this;
    }

    

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
            if (isFrenzy == false) survivedTime += Time.deltaTime;
            else survivedTime += frenzyBonusRate * Time.deltaTime;
            scoreTextOnGUI.text = survivedTime.ToString("f1");
        }

    }

    public void SetFrenzy(bool isFrenzy)
    {
        this.isFrenzy = isFrenzy;
        frenzyNotice.SetActive(isFrenzy);
    }

    void GenerateNewCube(int index)
    {
        Instantiate(cubePrefabs[index], prefabDefaultGeneratingPoint[index], Quaternion.Euler(prefabDefaultGeneratingEuler[index]));
        if(prefabAlreadyGenerated[index] == false)
        {
            NoticeManager.NM.SetImage(index);
            NoticeManager.NM.SetText(index);
            NoticeManager.NM.StartUI();
            prefabAlreadyGenerated[index] = true;
        }
    }

    void SetGenerateTime()
    {
        generateTime = Random.Range(minTime, maxTime);
    }

    public int GenerateIndex()
    {
        int index = Random.Range(0, 7);
        return index;
    }

    

    public void GameOver(Vector3 overPosition)                                                                                  
    {
        AfterEffectsManager.AEM.StartDeathParticleEffect(overPosition);
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
        //RectTransform rt = circleImg.GetComponent<RectTransform>();
        //rt.position = new Vector3(-2171, 0, 0);
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
