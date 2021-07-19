using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pumpA : MonoBehaviour
{
    public Animator anim;
    public bool firstA  =true;
    public Animator ant;
    public AudioSource pumping;
    public void StartAnim()
    {
        if(firstA == true)
        {
            pumping.Play();
            anim.Play("pump");
            firstA = false;
            ant.Play("pumpup");
        }
        else
        {
            pumping.UnPause();
            anim.speed = 1;
            ant.speed = 0.4f;
        }
    }
    public void stopAnim()
    {
        pumping.Pause();
        anim.speed = 0;
        ant.speed = 0;
    }
    public void nextscene(int c)
    {
        pumping.Stop();
        SceneManager.LoadScene(c);
    }
}
