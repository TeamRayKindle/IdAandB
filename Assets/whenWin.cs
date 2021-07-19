using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whenWin : MonoBehaviour
{
    public GameObject bigger;
    public GameObject smaller;
    public GameObject smaller1;
    public GameObject smaller2;
    public GameObject smaller3;
    public GameObject smallB;
    public Transform smallPos;
    public GameObject canv;

    public AudioSource ad;
    public AudioClip[] cd;
    public AudioManager Adn;

    public Transform bigcB;
    public Transform smallcB;
    public void win()
    {
        StartCoroutine(Big());
    }
    public IEnumerator Big()
    {
        ad.clip = cd[0];
        ad.Play();
        iTween.ScaleTo(bigger, iTween.Hash("scale", new Vector3(0.6f, 0.6f, 0.6f), "time", 5f));
        iTween.ScaleTo(smaller, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 5f));
        iTween.ScaleTo(smaller1, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 5f));
        iTween.ScaleTo(smaller2, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 5f));
        iTween.ScaleTo(smaller3, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 5f));
        yield return new WaitForSeconds(2f);
        ad.clip = cd[1];
        ad.Play();
        smallB.SetActive(true);
        iTween.MoveTo(smallB, iTween.Hash("position", smallPos, "time", 2, "easetype", iTween.EaseType.easeInOutSine));
        yield return new WaitForSeconds(2f);
        iTween.ScaleTo(smallB, iTween.Hash("scale", new Vector3(0.5f, 0.5f, 0.5f), "time", 5f));
        yield return new WaitForSeconds(0.3f);
        Adn.Play("m");
        iTween.ScaleTo(bigger, iTween.Hash("scale", new Vector3(1.6f, 1.6f, 1.6f), "time", 2));
        iTween.MoveTo(bigger, iTween.Hash("position", bigcB, "time", 2, "easetype", iTween.EaseType.easeInOutSine));
        iTween.ScaleTo(smallB, iTween.Hash("scale", new Vector3(1.6f, 1.6f, 1.6f), "time", 2));
        iTween.MoveTo(smallB, iTween.Hash("position", smallcB, "time", 2, "easetype", iTween.EaseType.easeInOutSine));
        yield return new WaitForSeconds(3);
       // bigger.GetComponent<Float2D>().enabled = true;
    //    smallB.GetComponent<Float2D>().enabled = true;
        yield return new WaitForSeconds(5);
        ad.clip = cd[2];
        ad.Play();
        canv.SetActive(true);
    }
}
