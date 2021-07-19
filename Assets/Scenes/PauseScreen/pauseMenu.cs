using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public AudioSource[] amSource;
    public GameObject Pausing;
    private void Start()
    {
        //amSource = Pausing.GetComponent<AudioSource>();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        foreach(AudioSource audio in amSource)
        {
            audio.Pause();
        }
        //amSource.Pause();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        
        foreach (AudioSource audio in amSource)
        {
            audio.UnPause();
        }

    }
    public void nextscene(String c)
    {
        
        SceneManager.LoadScene(c);
        Time.timeScale = 1;
    }
    public void setvolume(float c)
    {
        amSource[0].volume = c;
    }
}
