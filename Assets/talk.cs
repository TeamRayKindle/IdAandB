using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talk : MonoBehaviour
{

    public AudioSource ad;
    public AudioSource adcc;
    public int tim;
    public float timc;
    public GameObject intro;
    public void talkBack()
    {
        StartCoroutine(Back());
    }
    public IEnumerator Back()
    {
        ad.Play();
        yield return new WaitForSeconds(tim);
        intro.SetActive(false);
        yield return new WaitForSeconds(timc);
        adcc.Play();
    }
}
