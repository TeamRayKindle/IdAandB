using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    // Start is called before the first frame update
 public void intiate()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<Float2D>().enabled = true;

    }
}
