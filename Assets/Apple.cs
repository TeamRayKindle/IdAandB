using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Apple : MonoBehaviour
{
    public Transform scd;
    public GameObject self;
    public Transform frt;
    public GameObject canv;
    public GameObject particle;
    public GameObject A;
    public GameObject A1;
    public GameObject A1O;
    public GameObject A2;
    public GameObject A2O;
    public GameObject smallA;
    public Transform pos1;
    public Transform pos2;
    public GameObject canvd;
    public AudioSource cd;
    public AudioClip[] cl;
    public AudioSource StartB;
    public GameObject bn;
    public Button btn;
    public void OneClick()
    {
       // iTween.MoveTo(self, iTween.Hash("position", frt, "time", 1, "easetype", iTween.EaseType.easeInOutSine));
        StartCoroutine(popup());
        
    }
    public GameObject pointer;
    public IEnumerator into()
    {
        cd.clip = cl[0];
        cd.Play();
        yield return new WaitForSeconds(4);
        pointer.SetActive(true);
    }
    public IEnumerator popup()
    {
        // yield return new WaitForSeconds(2);
        // canv.SetActive(true);
        // Debug.LogError("falled");
        btn.interactable = false;
        iTween.MoveTo(self, iTween.Hash("position", scd, "time", 2.5f, "easetype", iTween.EaseType.easeInOutSine));
        iTween.ScaleTo(self, iTween.Hash("scale", new Vector3(3,3,3), "time", 2.5f));
        yield return new WaitForSeconds(2.4f);
        StartB.Play();
        particle.SetActive(true);
        yield return new WaitForSeconds(4);
        A.SetActive(true);
        cd.clip = cl[1];
        cd.Play();
        Debug.LogError("s");
        iTween.MoveTo(A2O, iTween.Hash("position", A1.transform, "time", 2.5f, "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(A1O, iTween.Hash("position", A2.transform, "time", 2.5f, "easetype", iTween.EaseType.easeInOutSine));
        //StartB.Play();
        yield return new WaitForSeconds(2.3f);
       
        A2O.SetActive(false);
        A1O.SetActive(false);
        iTween.MoveTo(A, iTween.Hash("position", pos1, "time", 1f, "easetype", iTween.EaseType.easeInOutSine));
        yield return new WaitForSeconds(1);
        iTween.ScaleTo(A, iTween.Hash("scale", new Vector3(0.1f, 0.1f, 0.1f), "time", 3f));
        StartB.Play();
        yield return new WaitForSeconds(1);
        smallA.SetActive(true);
        cd.clip = cl[2];
        cd.Play();
        iTween.MoveTo(smallA, iTween.Hash("position", pos2, "time", 1f, "easetype", iTween.EaseType.easeInOutSine));
        yield return new WaitForSeconds(1);
        iTween.ScaleTo(smallA, iTween.Hash("scale", new Vector3(0.1f, 0.1f, 0.1f), "time", 3f));
        StartB.Play();
        yield return new WaitForSeconds(5);
        canvd.SetActive(true);
        cd.clip = cl[3];
        cd.Play();
        yield return new WaitForSeconds(5);
        bn.SetActive(true);
        yield return new WaitForSeconds(3);
        btn.interactable = true;
    }
}
