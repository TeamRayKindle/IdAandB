using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outro : MonoBehaviour
{
    public Animator AD;
    public AudioSource ad;
    public int c;
    public void Start()
    {
        StartCoroutine(W());
    }
    public IEnumerator W()
    {
        yield return new WaitForSeconds(c);
        AD.SetBool("idle", true);
        ad.Play();
    }
}
