using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkSceneChange : MonoBehaviour
{
    public void reconect()
    {
        if (Application.internetReachability == 0)
        {
            Debug.LogError("No network");
            SceneManager.LoadScene(StaticString.LevelScreenlevelName);
        }
        else
        {  
        }
    }
    public void Update()
    {
        reconect();
    }
}
