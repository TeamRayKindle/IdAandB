using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Animationevent : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] GameObject Plane;
    [SerializeField] GameObject planet;
    [SerializeField] string ScenentoLoad;
    // Start is called before the first frame update
    public void intiateOn()
    {
        
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<Float2D>().enabled = true;
    }
public void Finializtion()
    {
       
        car.SetActive(true);
        planet.SetActive(true);
        Plane.SetActive(false);
    }
public void goback()
    {
        if (StaticString.End == true)
        {
            SceneManager.LoadScene(StaticString.LevelScreenlevelName);
        }
        else
        {
            SceneManager.LoadScene(StaticString.BaseMapLevelName);
        }
        
    }

}
