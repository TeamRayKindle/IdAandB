using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinker : MonoBehaviour
{
    private GameObject[] lights;
    private bool isOn;
    private bool isTransitionProgress;
    public float frequencyInSecs=0.5f;
    public float randomness = 0.2f;
    public bool LightsOff;
    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("BlinkingLight");
    }

    // Update is called once per frame
    void Update()
    {

        if (LightsOff)
        {
            foreach (GameObject light in lights)
            {
                light.SetActive(false);
            }
        }
        else
        {

            if (!isTransitionProgress)
            {
                isTransitionProgress = true;
                StartCoroutine(lightToggle());

            }
        }


    }
    ///TODO: MODIFY so that only one light is on at a time
    IEnumerator lightToggle()
    {
        yield return new WaitForSeconds(frequencyInSecs);
        foreach (GameObject light in lights)
        {
            light.SetActive(!isOn);
            yield return new WaitForSeconds(randomness);
            light.SetActive(isOn);
        }
        isTransitionProgress = false;
        //isOn=!isOn;
    }
}
