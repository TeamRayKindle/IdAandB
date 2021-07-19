using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class CheckNetwork : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public GameObject canv;

    public string SceneName;

    public void FixedUpdate()
    {
        reconect();
    }
    public void reconect()
    {
        if(Application.internetReachability == 0)
        {
            Debug.LogError("No network");
            canv.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            canv.SetActive(false);
        }
    }
    public void recconect()
    {
        StartCoroutine(CheckInternetConnection(isConnected =>
        {
            if (isConnected)
            {
                Debug.Log("Internet Available!");
                SceneManager.LoadScene(SceneName);
            }
            else
            {
                Debug.Log("Internet Not Available");
                SceneManager.LoadScene("network error");
            }
        }));
    }

    public void closeApp()
    {
        Application.Quit();
    }

   
    IEnumerator CheckInternetConnection(Action<bool> action)
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            Debug.Log("Error");
            action(false);
        }
        else
        {
            Debug.Log("Success");
            action(true);
        }
    }
}
