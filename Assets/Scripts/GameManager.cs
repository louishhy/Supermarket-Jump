using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager S;
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
        SetGenerateTime();
        time = minTime;
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
        Invoke("ReloadScene", 2f);
    }

    void ReloadScene()                                                                                     
    {                                                                                                    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
