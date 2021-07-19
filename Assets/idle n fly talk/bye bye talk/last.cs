using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class last : MonoBehaviour
{
    public Animator ANim;
    void Start()
    {
        StartCoroutine(bye());
    }

    public IEnumerator bye()
    {
        yield return new WaitForSeconds(5);
        ANim.SetBool("ok",true);
    }
}
