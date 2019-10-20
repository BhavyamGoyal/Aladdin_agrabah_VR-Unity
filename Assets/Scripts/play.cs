using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public int rideTime=50;
    public GameObject aladdin, fireworks,restart;
    public int waitTime = 30;
    // Start is called before the first frame update
    private void Awake()
    {
        Physics.autoSimulation = false;
    }
    void Start()
    {
        restart.SetActive(false);
        StartCoroutine(ShowRestart());
        StartCoroutine(startPlay());
        StartCoroutine(Deleteali());
        StartCoroutine(FireWorks());
    }
    IEnumerator ShowRestart()
    {
        yield return new WaitForSeconds(rideTime+waitTime+5);
        restart.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    float time = 10;
    // Update is called once per frame
    IEnumerator startPlay()
    {
        CPC_CameraPath path = FindObjectOfType<CPC_CameraPath>();
        yield return new WaitForSeconds(waitTime);
        path.PlayPath(rideTime);
    }
    IEnumerator Deleteali()
    {
       
        yield return new WaitForSeconds(waitTime+10);
        Destroy(aladdin);
    }
    IEnumerator FireWorks()
    {
        
        yield return new WaitForSeconds(rideTime);
        fireworks.SetActive(true);
    }
}
