using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public GameObject turtle;
    

    public void onclick()
    {
        gameObject.SetActive(false);
        turtle.SetActive(true);
    }
}
