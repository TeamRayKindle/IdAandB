using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongScaleWithTime : MonoBehaviour
{
    public float MinScaleAmount = 0.25f;
    public float MaxScaleAmount = 1.5f;
    public float Offset = 0.25f;
    public float Speed = 0.5f;
    // Update is called once per frame
    void Update()
    {
        float scaleAmount = Mathf.PingPong(Time.time * Speed, MaxScaleAmount + Offset);
        scaleAmount = Mathf.Clamp(scaleAmount,MinScaleAmount, MaxScaleAmount);
        transform.localScale = new Vector3(scaleAmount, scaleAmount, transform.localScale.z);
    }
}
