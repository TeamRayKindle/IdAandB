using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class into : MonoBehaviour
{
    public GameObject gb;
    public float Tim = 2;
    public float k = 2;
    public AudioSource ad;
    public GameObject carpet;
    public AudioSource ADC;
    public AudioSource ADCc;
    public void intro()
    {
        StartCoroutine(AfterASecond(Tim));
    }
    public IEnumerator AfterASecond(float c)
    {
        ad.Play();
        yield return new WaitForSeconds(c-k);
        carpet.SetActive(true);
        ADC.Play();
        yield return new WaitForSeconds(k+1);
        gb.SetActive(false);
        ADCc.Play();
    }
}
