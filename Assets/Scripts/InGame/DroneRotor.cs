using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRotor : MonoBehaviour
{
    private float speed = 1.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * 700 * Time.deltaTime);
    }
}
