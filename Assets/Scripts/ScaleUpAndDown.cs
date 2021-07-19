using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpAndDown : MonoBehaviour
{
    private float s=0;
    public float c=0.01f;
    private bool up=false;
    public float x;
    public float y;
    public float z;
    public float Max;
    public void Start()
    {
        x = gameObject.transform.localScale.x;
        y = gameObject.transform.localScale.y;
        z = gameObject.transform.localScale.z;
    }
    public void Update()
    {
        if (up == false)
        {
            StartCoroutine(Scale());
        }
        
    }
    public IEnumerator Scale()
    {
        up = true;
        for (float i = 0; i < Max; i += 0.01f){

            gameObject.transform.localScale = new Vector3(x + i, y + i, z + i);
            yield return new WaitForSeconds(0.1f);
        }
        for (float i = 0; i < Max; i += 0.01f)
        {

            gameObject.transform.localScale = new Vector3(x - i, y - i, z - i);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
