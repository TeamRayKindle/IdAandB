using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup : MonoBehaviour
{
    
    void Start()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(0.5f, 0.5f, 0.5f), "time", 3f));
    }

   
}
