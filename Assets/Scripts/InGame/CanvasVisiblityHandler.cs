using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasVisiblityHandler : MonoBehaviour
{
    public AudioManager am;//referencing audio manager
    public void call(int i)//method to make child objects visible
    {

        transform.GetChild(i).transform.gameObject.SetActive(true);

    }

    public void Invisible(int i)//method to make child objects invisible
    {
        transform.GetChild(i).transform.gameObject.SetActive(false);
    }

    public void  onclick()//next level transition button
    {
       // am.Play("star");//nusic
        
        SceneManager.LoadScene(1);//next level load
    }
}
