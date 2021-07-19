using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSlider : MonoBehaviour
{
    public GameObject SliderValueObject;
    public float SliderValue;
    public float MaxValue = 1;
    public float MinValue = 0;
    public float Percentage;
    public void Update()
    {
        SliderValue = MaxValue / 100 * Percentage;
        SliderValueObject.transform.localScale = new Vector3(SliderValue, 1, 1);
    }
}
