using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public AudioClip[] Audioclip;
    private AudioSource AD;
    public string currentscene ="";
    public int c=0;

    private void Start()
    {
        AD = gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        AD.clip = Audioclip[c];
        AD.Play();
    }
    
    public void Update()
    {
        if (SceneManager.GetActiveScene().name == StaticString.BaseMapLevelName || SceneManager.GetActiveScene().name == StaticString.LevelScreenlevelName || SceneManager.GetActiveScene().name == StaticString.LoadingScreenLevelName || SceneManager.GetActiveScene().name == StaticString.CarSelectionlevelName)
        {
            if (currentscene == SceneManager.GetActiveScene().name)
            {
                
            }
            else
            {
                currentscene = SceneManager.GetActiveScene().name;
                if (c + 1 >= Audioclip.Length)
                {
                    c = 0;
                }
                else
                {
                    c += 1;
                }
                AD.clip = Audioclip[c];
                AD.Play();

            }
        }
        else
        {
            currentscene = SceneManager.GetActiveScene().name;
            AD.Stop();
        }
    }
}
