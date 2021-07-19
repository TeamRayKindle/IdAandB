using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class done : MonoBehaviour
{
    public GameObject nt;
    public GameObject A;
    public GameObject p;
    public GameObject X;
    public AudioSource ad;
    public GameObject pumb;
    public Animator Ac;
    public string indexS;
    public IEnumerator wait()
    {
        pumb.SetActive(false);
        Ac.Play("pumpup");
        yield return new WaitForSeconds(3);
        Debug.LogError("anim completed");
        ad.Play();
      //  nt.SetActive(true);
        A.SetActive(true);
        p.SetActive(false);
        X.transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(indexS);
    }
    public void ok()
    {
        StartCoroutine(wait());
    }
}
