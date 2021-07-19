using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisontrigerrButterfly : MonoBehaviour
{
    public Transform pos;
    public GameObject joy;
    public AudioManager ADM;
    public GameObject pointer;
    public GameObject Word;
    public GameObject Canv;

    public void Start()
    {
        Canv.SetActive(false);

    }
    public void OnTriggerEnter(Collider other)
    {
       Debug.LogError( other.name);
        if(other.name == "c")
        {
            iTween.MoveTo(gameObject, iTween.Hash("position", pos, "time", 2, "easetype", iTween.EaseType.easeInOutSine));
            iTween.RotateTo(gameObject, iTween.Hash("rotation", pos, "time", 2, "easetype", iTween.EaseType.easeInOutSine));
            gameObject.GetComponent<FirstPersonController>().enabled = false;
            joy.SetActive(false);
            StartCoroutine(Speak());
        }
    }
    public IEnumerator Speak()
    {
        ADM.Play("1");
        Word.SetActive(true);
        yield return new WaitForSeconds(3);
        ADM.Play("2");
        yield return new WaitForSeconds(2);
        ADM.Play("3");
        yield return new WaitForSeconds(3);
        pointer.SetActive(true);
        Canv.SetActive(true);
    }

    
    public void nextscene(int c)
    {
        SceneManager.LoadScene(c);
    }
}
