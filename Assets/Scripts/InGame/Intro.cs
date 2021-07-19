using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public AudioClip clip;
    public GameObject carpet;
    
   
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("sc1");

        StartCoroutine(Narrate());
        

       

        
    }

    // Update is called once per frame
    public void nextScene()
    {
        //Debug.Log("hi");
        SceneManager.LoadScene(1);

       
        
    }
    IEnumerator Narrate()
    {
        yield return new WaitForSeconds(8f);
        FindObjectOfType<AudioManager>().Play("sc2");
        carpet.SetActive(true);
        yield return new WaitForSeconds(2f);
        
        Invoke("nextScene", clip.length);
        StopAllCoroutines();



    }



}
