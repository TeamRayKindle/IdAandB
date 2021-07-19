using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFastForward : MonoBehaviour
{
    public bool isFastForwardOn;
    public float fastForwardSpeed = 3f;
    public AudioManager AudioManager;
    private void FixedUpdate()
    {
        if (isFastForwardOn)
        {
            setGameSpeed(fastForwardSpeed);
        }
        else
        {
            setGameSpeed(1f);
        }
    }

    private void setGameSpeed(float speed)
    {
        Time.timeScale = speed;
        foreach (Sound s in AudioManager.sounds)
        {
            s.source.pitch = speed;

        }
    }
}
