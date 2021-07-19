using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisontrigerr : MonoBehaviour
{
    public Transform pos;
    public GameObject joy;
    public GameObject apple;
    public Apple ap;
    public GameObject effects;
    public void OnTriggerEnter(Collider other)
    {
       Debug.LogError( other.name);
        if(other.name == "on")
        {
            iTween.MoveTo(gameObject, iTween.Hash("position", pos, "time", 2, "easetype", iTween.EaseType.easeInOutSine));
            iTween.RotateTo(gameObject, iTween.Hash("rotation", pos, "time", 2, "easetype", iTween.EaseType.easeInOutSine));
            gameObject.GetComponent<FirstPersonController>().enabled = false;
            joy.SetActive(false);
            effects.SetActive(false);
            StartCoroutine(ap.into());
            apple.SetActive(true);
            
            
        }
    }
    public void nextscene(string c)
    {
        SceneManager.LoadScene(c);
    }
}
