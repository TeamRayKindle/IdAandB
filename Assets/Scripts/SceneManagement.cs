using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneManagement : MonoBehaviour
{
    public int nextScene;
    public GameObject level;
    public double time;
    public double currentTime;
    // Use this for initialization
    void Start()
    {

        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }

    public void NextSc()
    {
        SceneManager.LoadScene(nextScene);
    }
    // Update is called once per frame
    void Update()
    {
        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (currentTime >= time)
        {
            level.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
