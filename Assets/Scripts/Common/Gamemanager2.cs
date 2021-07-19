 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager2 : MonoBehaviour
{
    public GameObject Ice;
    public AudioManager AM;
    public GameObject Highlight;
    public Animator smallLetter;
    public GameObject canvas;
    private float _speed;
    private bool GameFinished=false;
    private bool GameStarted=false;
    public CanvasVisiblityHandler SetVis { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        SetVis = canvas.GetComponent<CanvasVisiblityHandler>();
        gameObject.GetComponent<Button>().enabled = false;
        StartCoroutine(intro());
        Highlight.SetActive(false);
        _speed = Ice.GetComponent<Animator>().speed;


    }
    private void Update()
    {
        
        if (GameStarted&&Input.GetMouseButtonDown(0)&&GameFinished==false)
        {
            gameObject.GetComponent<Animator>().SetBool("burn", true);
           // AM.Play("dry");
            Ice.GetComponent<Animator>().speed=_speed;
        }
        if(Input.GetMouseButtonUp(0) )
        {
            gameObject.GetComponent<Animator>().SetBool("burn", false);
           // AM.Stop("dry");
            Ice.GetComponent<Animator>().speed = 0;
        }
        if (Ice.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("candyFinal") && GameFinished == false)
        {     
            GameFinished = true;
            StartCoroutine(finished());
        }
    }



    public void click()
    {
        gameObject.GetComponent<Button>().enabled = false;
        Highlight.SetActive(false);
        StartCoroutine(Icemelt());

       // gameObject.GetComponent<Animator>().
    }

    IEnumerator Icemelt()
    {
      
       
        yield return new WaitForSeconds(3f);
       
        
        Ice.GetComponent<Animator>().SetBool("melt", true);
        
        
      
    }

    IEnumerator intro()
    {
        yield return new WaitForEndOfFrame();
     //   AM.Play("sc9");
        yield return new WaitForSeconds(4f);

        gameObject.GetComponent<Button>().enabled = true;
        Highlight.SetActive(true);
        GameStarted=true;
    }
    IEnumerator finished()
    {
        //AM.Play("sc10");
        gameObject.GetComponent<Animator>().SetBool("burn", false);
        yield return new WaitForSeconds(3f);
        smallLetter.SetBool("melt", true);
        yield return new WaitForSeconds(3f);

      //  AM.Play("sc13");
        yield return new WaitForSeconds(3f);
     //   AM.Play("sc14");
        yield return new WaitForSeconds(4f);
        SetVis.Invisible(1);
        SetVis.Invisible(2);
        SetVis.Invisible(3);
        SetVis.call(4);
        SetVis.call(6);
        SetVis.call(7);
     //   AM.Play("sc12");
        yield return new WaitForSeconds(0.1f);
    }
}
